namespace Samruk.Web.Models {
    public class AuditDetailItemViewModel {
        public string Id { get; set; }
        public string Key { get; set; }
        public double UserValue { get; set; }
        public double AuditorValue { get; set; }
        public string Comment { get; set; }
    }
}