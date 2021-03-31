using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcens.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            // Fluent Validator dokümantasyondan geliyor. Kullanım şekli
            var context = new ValidationContext<object>(entity);

            // validator => örneğin productValidator gelirse o olacak
            var result = validator.Validate(context);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
