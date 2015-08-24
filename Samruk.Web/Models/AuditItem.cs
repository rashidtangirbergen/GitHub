using System;

namespace Samruk.Web.Models {
    public class AuditItem {
        public AuditItem() {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string Key { get; set; }
        public double UserValue { get; set; }
        public double AuditorValue { get; set; }
        public string Comment { get; set; }
        public virtual Audit Audit { get; set; }
    }
}