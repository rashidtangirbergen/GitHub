using System;

namespace Samruk.Web.Models {
    public class RegistrationData {
        public RegistrationData() {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string Xin { get; set; }
        public bool IsResident { get; set; }
        public string OrganizationName { get; set; }
        public string TaxId { get; set; }
        public string StateRegistrationCertificateNumber { get; set; }
        public DateTime? StateRegistrationCertificateDate { get; set; }
        public string StateRegistrationCertificateIssuingAuthority { get; set; }
        public virtual Country Country { get; set; }
        public virtual ProviderType ProviderType { get; set; }
        public virtual LegalForm LegalForm { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}