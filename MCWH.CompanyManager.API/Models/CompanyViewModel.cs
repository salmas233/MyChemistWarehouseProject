using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MCWH.CompanyManager.API.Models
{
    public class CompanyViewModel : IValidatableObject
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Company name is required.")]
        public string companyName { get; set; }
        public int yearEstablished { get; set; }

        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$", ErrorMessage = "Please enter valid email address.")]
        public string email { get; set; }

        [RegularExpression(@"^[A-Za-z0-9]+$", ErrorMessage = "Please enter valid phone number.")]
        public string phone { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (yearEstablished <= 1900 || this.yearEstablished > DateTime.Now.Year)
            {
                yield return new ValidationResult($"Year established should be between 1900 and {DateTime.Now.Year}");
            }


            //var _companyService = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(ICompanyService));

            //var emailExitsForOtherCompany = _companyService.FindByQuery(c => c.Email == email).Where(c => c.Id != id).Any();
            //var phoneExitsForOtherCompany = _companyService.FindByQuery(c => c.Phone == phone).Where(c => c.Id != id).Any();

            //if (emailExitsForOtherCompany)
            //    yield return new ValidationResult($"This email address is assigned for another company.");

            //if (phoneExitsForOtherCompany)
            //    yield return new ValidationResult($"This phone number is assigned for another company.");
        }
    }
}