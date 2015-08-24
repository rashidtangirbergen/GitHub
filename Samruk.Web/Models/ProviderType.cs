using System;

namespace Samruk.Web.Models {
    public class ProviderType {
        public ProviderType() {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string NameRu { get; set; }
        public string NameKz { get; set; }

        public ProviderTypeEnum Enum { get; set; }
        public override string ToString() {
            return NameRu;
        }
    }

    public enum ProviderTypeEnum {
        PhysPerson = 1,
        LegalPerson = 2
    }
}