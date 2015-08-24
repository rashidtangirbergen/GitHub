using System;
using System.Collections.Generic;

namespace Samruk.Web.Models {
    public class Audit {
        public Audit() {
            this.Id = Guid.NewGuid().ToString();
            this.Items =new HashSet<AuditItem>();
        }
        public string Id { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationUser Auditor { get; set; }
        public virtual ICollection<AuditItem> Items { get; set; }
    }
}