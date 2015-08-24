namespace Samruk.Web.Models {
    public class QuestionnaireItemViewModel {
        public QuestionnaireItemViewModel(QuestionnaireItem item) {
            this.Id = item.Id;
            this.Key = item.Key;
            this.Value = item.Value;
        }

        public QuestionnaireItemViewModel() {
        }

        public string Id { get; set; }
        public string Key { get; set; }
        public int Value { get; set; }
    }
}