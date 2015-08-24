using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using Samruk.Web.Models;

namespace Samruk.Web.Reports {
    public partial class XtraReportAuditForm : DevExpress.XtraReports.UI.XtraReport {
        public XtraReportAuditForm(string auditId) {
            InitializeComponent();
            AuditId = auditId;
        }

        public string AuditId { get; set; }

        private void XtraReportAuditForm_DataSourceDemanded(object sender, EventArgs e) {
            var db = ApplicationDbContext.Create();
            var currentUserName = HttpContext.Current.User.Identity.Name;
            var items = db.AuditItems.Where(x => x.Audit.Id == AuditId);
            this.DataSource = items.ToArray();
        }

    }
}
