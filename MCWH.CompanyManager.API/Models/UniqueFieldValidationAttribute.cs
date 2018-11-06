using System.Linq;
using MCWH.CompanyManager.Service.Company;
using System.ComponentModel.DataAnnotations;

namespace MCWH.CompanyManager.API.Models
{
    public enum FieldType
    {
        Email,
        Phone
    }

    public class UniqueFieldValidationAttributes : ValidationAttribute
    {
        #region Private Variables
        private readonly FieldType _fieldType;
        #endregion

        #region Constructor
        public UniqueFieldValidationAttributes(FieldType fieldType)
        {
            _fieldType = fieldType;
        }
        #endregion

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var fieldValue = value?.ToString();

            if (!string.IsNullOrWhiteSpace(fieldValue))
            {
                var _companyService = (ICompanyService)validationContext.GetService(typeof(ICompanyService));

                var duplicateExists = _companyService.FindByQuery(c => c.Email == fieldValue).Where(c => c.Id != 1).Any();
                if (duplicateExists)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}