using System.Linq;

namespace Samruk.Web.Models {
    public class AuditDetailViewModel {
        public string AuditId { get; set; }
        public AuditDetailViewModel() {
        }

        public AuditDetailViewModel(Audit audit) {
            this.AuditId = audit.Id;
            this.Items = audit.Items.Select(x => new AuditDetailItemViewModel {
                Id = x.Id,
                Key = x.Key,
                UserValue = x.UserValue,
                AuditorValue = x.AuditorValue,
                Comment = x.Comment
            }).ToArray();
        }


        public AuditDetailItemViewModel[] Items { get; set; }

    }
}