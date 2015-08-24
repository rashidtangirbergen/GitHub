using System;
using System.Security.Principal;

namespace Samruk.Web.Models {
    public class Country {
        public Country() {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string NameRu { get; set; }
        public string NameKz { get; set; }
        public override string ToString() {
            return NameRu;
        }
    }
}