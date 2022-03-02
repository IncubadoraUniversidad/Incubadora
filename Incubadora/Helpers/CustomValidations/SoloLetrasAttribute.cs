using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Incubadora.Helpers.CustomValidations
{
    public class SoloLetrasAttribute : ValidationAttribute
    {

        private readonly Regex SoloLetrasRegex = new Regex(@"^[A-ZÁÉÍÓÚÑ]+$", RegexOptions.IgnoreCase);
        public string GetErrorMessage() =>
        "Este campo solo acepta letras sin espacios en blanco";

        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Este campo es requerido");
            }
            if (!SoloLetrasRegex.IsMatch(value.ToString()))
            {
                return new ValidationResult(GetErrorMessage());
            }
            return ValidationResult.Success;
        }
    }
}