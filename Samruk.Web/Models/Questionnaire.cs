using System;
using System.Collections.Generic;

namespace Samruk.Web.Models {
    public class Questionnaire {
        public Questionnaire() {
            this.Id = Guid.NewGuid().ToString();
            this.Items = new HashSet<QuestionnaireItem>();
        }
        public string Id { get; set; }

        public DateTime Date { get; set; }
        public virtual ICollection<QuestionnaireItem> Items { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}