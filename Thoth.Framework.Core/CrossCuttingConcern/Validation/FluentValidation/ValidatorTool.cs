using Thoth.Framework.Core.CrossCuttingConcern.ExceptionHandling.Exceptions;
using FluentValidation;

namespace Thoth.Framework.Core.CrossCuttingConcern.Validation.FluentValidation
{
    public class ValidatorTool
    {
        public static void FluentValidate(IValidator validator, object entity)
        {
            var result = validator.Validate(entity);

            foreach (var error in result.Errors)
            {
                throw new ValidationCoreException(error.ErrorMessage);
            }
        }
    }
}
