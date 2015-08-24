using System;
using System.ComponentModel.DataAnnotations;

namespace Samruk.Web.Models {
    public class RegistrationDataViewModel {
        public RegistrationDataViewModel(RegistrationData regData) {
            this.Xin = regData.Xin;
            this.IsResident = regData.IsResident;
            this.OrganizationName = regData.OrganizationName;
            this.TaxId = regData.TaxId;
            this.StateRegistrationCertificateNumber = regData.StateRegistrationCertificateNumber;
            this.StateRegistrationCertificateDate = regData.StateRegistrationCertificateDate;
            this.StateRegistrationCertificateIssuingAuthority = regData.StateRegistrationCertificateIssuingAuthority;
            this.Country = regData.Country;
            this.ProviderType = regData.ProviderType;
            this.LegalForm = regData.LegalForm;
            if (regData.Country != null) {
                this.CountryId = regData.Country.Id;
            }
            
            this.ProviderTypeId = regData.ProviderType.Id;
            this.LegalFormId = regData.LegalForm.Id;

            this.User = regData.User;
        }

        public string LegalFormId { get; set; }

        public string ProviderTypeId { get; set; }

        public string CountryId { get; set; }

        public RegistrationDataViewModel() {
        }

        [Display(Name = "БИН/ИИН")]
        public string Xin { get; set; }

        [Display(Name = "Признак резиденства")]
        public bool IsResident { get; set; }

        [Display(Name = "Название организации")]
        [Required(ErrorMessage = ValidationConstants.RequiredMessage)]
        public string OrganizationName { get; set; }

        [Display(Name = "Налоговый идентификатор")]
        public string TaxId { get; set; }

        [Display(Name = "Номер свидетельства о государственной регистрации")]
        public string StateRegistrationCertificateNumber { get; set; }

        [Display(Name = "Дата свидетельства о государственной регистрации")]
        public DateTime? StateRegistrationCertificateDate { get; set; }

        [Display(Name = "Орган выдачи свидетельства о государственной регистрации")]
        public string StateRegistrationCertificateIssuingAuthority { get; set; }

        [Display(Name = "Страна резидентства")]
        public virtual Country Country { get; set; }

        [Display(Name = "Тип поставщика")]
        public virtual ProviderType ProviderType { get; set; }

        [Display(Name = "Организационно-правовая форма")]
        public virtual LegalForm LegalForm { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}