using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectValidationLib
{
    public class PatientInfoModel
    {
        [ObjectValidationLib.RequiredValidatorAttributor(Error  = "MRN Required Value")]
        [Required(ErrorMessage = "MRN is required")]
        public string MRN { get; set; } = Guid.NewGuid().ToString();

        [ObjectValidationLib.RequiredValidatorAttributor(Error  = "Name is required")]
        public string Name { get; set; } = null!;

        [ObjectValidationLib.RangeValidator(1, 100, Error = "Age Value Must be with in range 1-100")]
        public int Age { get; set; }
    }
}
