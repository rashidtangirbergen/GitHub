using System;

namespace Samruk.Web.Models {
    public class CriteriaSetting {
        public CriteriaSetting() {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
    }
}