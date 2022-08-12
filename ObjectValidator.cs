using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ObjectValidationLib
{
    public static class ObjectValidator
    {
        public static IEnumerable<ValidationResult> Validate(Object source)
        {
            List<ValidationResult> validateResult = new List<ValidationResult>();
            System.Type _classRef = source.GetType();
            var properties = _classRef.GetProperties();
            
            foreach (var property in properties)
            {
                Console.WriteLine(property.Name);

                ValidationResult results = new ValidationResult
                    {PropertyName = property.Name, ValidationRules = new List<ValidationRule>()};
                List<ValidationRule> validationRule = new List<ValidationRule>();

                var reqAttribute =
                    property.GetCustomAttributes(typeof(ValidationAttribute), true) as ValidationAttribute[];
                if (reqAttribute != null)
                {
                    foreach (var attribute in reqAttribute)
                    {
                        ValidationRule attributeRule = new ValidationRule();
                        attributeRule.ValidationType = attribute.ValidationName;
                        if (attribute.Validate(property.GetValue(source)))
                        {
                            attributeRule.Status = validationStatus.INVALID;
                            attributeRule.ErrorMessage = attribute.Error;
                        }
                        else
                        {
                            attributeRule.Status = validationStatus.VALID;
                        }

                        validationRule.Add(attributeRule);
                    }

                    results.ValidationRules = validationRule;
                    validateResult.Add(results);
                }
            }

            return validateResult;
        }
    }
}

