using System;

namespace Samruk.Web.Models {
    public class QuestionnaireItem {
        public QuestionnaireItem() {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        public string Key { get; set; }
        public int Value { get; set; }

        public virtual Questionnaire Questionnaire { get; set; }
    }
}