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

        [Display(Name = "���/���")]
        public string Xin { get; set; }

        [Display(Name = "������� �����������")]
        public bool IsResident { get; set; }

        [Display(Name = "�������� �����������")]
        [Required(ErrorMessage = ValidationConstants.RequiredMessage)]
        public string OrganizationName { get; set; }

        [Display(Name = "��������� �������������")]
        public string TaxId { get; set; }

        [Display(Name = "����� ������������� � ��������������� �����������")]
        public string StateRegistrationCertificateNumber { get; set; }

        [Display(Name = "���� ������������� � ��������������� �����������")]
        public DateTime? StateRegistrationCertificateDate { get; set; }

        [Display(Name = "����� ������ ������������� � ��������������� �����������")]
        public string StateRegistrationCertificateIssuingAuthority { get; set; }

        [Display(Name = "������ ������������")]
        public virtual Country Country { get; set; }

        [Display(Name = "��� ����������")]
        public virtual ProviderType ProviderType { get; set; }

        [Display(Name = "��������������-�������� �����")]
        public virtual LegalForm LegalForm { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}