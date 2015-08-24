using System;

namespace Samruk.Web.Models {
    public class LegalForm {
        public LegalForm() {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string NameRu { get; set; }
        public string NameKz { get; set; }

        public LegalFormEnum Enum { get; set; }
        public override string ToString() {
            return NameRu;
        }
    }

    public enum LegalFormEnum {
        AO = 1,
        TOO = 2,
        RGP = 3,
        Other = 4
    }
}