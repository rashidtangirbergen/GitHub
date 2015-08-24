using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using Samruk.Web.Models;

namespace Samruk.Web.Reports {
    public partial class XtraReportQuestionnaire : DevExpress.XtraReports.UI.XtraReport {
        public XtraReportQuestionnaire() {
            InitializeComponent();
        }

        private void XtraReportQuestionnaire_DataSourceDemanded(object sender, EventArgs e) {
            var db = ApplicationDbContext.Create();
            var currentUserName = HttpContext.Current.User.Identity.Name;
            var items = db.QuestionnaireItems.Where(x => x.Questionnaire.User.UserName == currentUserName);
            this.DataSource = items.ToArray();
        }



    }
}
