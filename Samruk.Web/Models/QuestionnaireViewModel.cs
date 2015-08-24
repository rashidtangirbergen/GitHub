using System.Linq;

namespace Samruk.Web.Models {
    public class QuestionnaireViewModel {
        public QuestionnaireViewModel(Questionnaire questionnaire) {
            this.QuestionnaireItemViewModels = questionnaire.Items.Select(x => new QuestionnaireItemViewModel(x)).ToArray();
        }

        public QuestionnaireViewModel() {
        }

        public QuestionnaireItemViewModel[] QuestionnaireItemViewModels { get; set; }
    }

    public class AuditViewModel {
        public string UserId { get; set; }
        public string AuditId { get; set; }
        public string Xin { get; set; }
        public string CompanyName { get; set; }
        public bool IsAudit { get; set; }
        public double UserTotal { get; set; }
        public double AuditorTotal { get; set; }
    }
}