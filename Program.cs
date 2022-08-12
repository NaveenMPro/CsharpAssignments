using System;
using System.ComponentModel.DataAnnotations;
using ObjectValidationLib;

namespace ValidatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PatientInfoModel objPatient = new PatientInfoModel()
            {
                MRN="mrn_value",Name ="Tom",Age=30
            };

            var result = ObjectValidator.Validate(objPatient);

            foreach (var validationRes in result)
            {
                //foreach (var rule in result.ValidationRule)
                //{
                //    Console.WriteLine($"{rule.ValidationType}: {rule.Status}: {rule.ErrorMessage}");
                //}
            }
            Console.Read();
        }
        }
    }

