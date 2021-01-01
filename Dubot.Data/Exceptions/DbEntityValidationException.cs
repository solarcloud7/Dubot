using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Dubot.Data.Exceptions
{

    public class FormattedDbEntityValidationException : Exception
    {
        public FormattedDbEntityValidationException(ValidationException innerException) :
            base(null, innerException)
        {
        }

        public override string Message
        {
            get
            {
                var innerException = InnerException as ValidationException;
                if (innerException != null)
                {
                    var msg = innerException.ValidationResult.ErrorMessage;
                    msg += $" member: {innerException.ValidationResult.MemberNames.FirstOrDefault()}";
                    return msg;
                }

                return base.Message;
            }
        }
    }
}
