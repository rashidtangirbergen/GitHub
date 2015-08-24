using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Samruk.Web.Models {
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false) {
        }

        public static ApplicationDbContext Create() {
            return new ApplicationDbContext();
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<ProviderType> ProviderTypes { get; set; }
        public DbSet<LegalForm> LegalForms { get; set; }
        public DbSet<RegistrationData> RegistrationDatas { get; set; }
        public DbSet<CriteriaSetting> CriteriaSettings { get; set; }
        public DbSet<Questionnaire> Questionnaires { get; set; }
        public DbSet<QuestionnaireItem> QuestionnaireItems { get; set; }
        public DbSet<Audit> Audits { get; set; }
        public DbSet<AuditItem> AuditItems { get; set; }
    }
}