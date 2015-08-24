using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Samruk.Web.Models;
using DevExpress.Web.Mvc;
using DevExpress.XtraPrinting.Native;
using Samruk.Web.Helpers;

namespace Samruk.Web.Controllers {
    [Authorize]
    public class HomeController : BaseController {
        public ActionResult Index() {
            if (this.HttpContext.ApplicationInstance.Context.IsAdministrator(User.Identity.Name)) {
                return RedirectToAction("CriteriaSetting");
            }

            if (this.HttpContext.ApplicationInstance.Context.IsAuditor(User.Identity.Name)) {
                return RedirectToAction("CompanyList");
            }

            if (this.HttpContext.ApplicationInstance.Context.IsUser(User.Identity.Name)) {
                return RedirectToAction("RegistrationData");
            }

            return View();
        }

        #region Форма "регистрационные данные"
        [Authorize(Roles = "User")]
        public ActionResult RegistrationData() {
            var user = this.GetAuthUser();
            var context = ApplicationDbContext.Create();
            var regData = context.RegistrationDatas.SingleOrDefault(x => x.User.Id == user.Id);

            var model = regData == null ? new RegistrationDataViewModel() { IsResident = true } : new RegistrationDataViewModel(regData);
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public ActionResult RegistrationData(RegistrationDataViewModel model) {
            if (!ModelState.IsValid) {
                return View(model);
            }

            var user = this.GetAuthUser();
            var context = ApplicationDbContext.Create();
            var regData = context.RegistrationDatas.SingleOrDefault(x => x.User.Id == user.Id);
            if (regData == null) {
                regData = new RegistrationData();
                context.RegistrationDatas.Add(regData);
            }

            regData.IsResident = model.IsResident;
            regData.LegalForm = context.LegalForms.Single(x => x.Id == model.LegalFormId);
            regData.OrganizationName = model.OrganizationName;
            regData.ProviderType = context.ProviderTypes.Single(x => x.Id == model.ProviderTypeId);
            regData.StateRegistrationCertificateDate = model.StateRegistrationCertificateDate;
            regData.StateRegistrationCertificateIssuingAuthority = model.StateRegistrationCertificateIssuingAuthority;
            regData.StateRegistrationCertificateNumber = model.StateRegistrationCertificateNumber;
            regData.User = context.Users.Single(x => x.Id == user.Id);

            if (!model.IsResident) {
                regData.Country = context.Countries.Single(x => x.Id == model.CountryId);
                regData.TaxId = model.TaxId;
                regData.Xin = string.Empty;
            }
            else {
                regData.Xin = model.Xin;
                regData.Country = null;
                regData.TaxId = string.Empty;
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

        #region Форма «опросник»
        [Authorize(Roles = "User")]
        public ActionResult Questionnaire() {
            var user = this.GetAuthUser();
            var context = ApplicationDbContext.Create();
            var questionnaire = context.Questionnaires.SingleOrDefault(x => x.User.Id == user.Id);

            if (questionnaire == null) {
                questionnaire = new Questionnaire() {
                    User = context.Users.Single(x => x.Id == user.Id),
                    Date = DateTime.Now,
                };
                foreach (var setting in context.CriteriaSettings) {
                    questionnaire.Items.Add(new QuestionnaireItem {
                        Key = setting.Name,
                        Value = 0,
                    });
                }
                context.Questionnaires.Add(questionnaire);
                context.SaveChanges();
            }

            var model = new QuestionnaireViewModel(questionnaire);
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public ActionResult Questionnaire(QuestionnaireViewModel model) {
            if (!ModelState.IsValid) {
                return View(model);
            }
            var user = this.GetAuthUser();
            var context = ApplicationDbContext.Create();
            var questionnaire = context.Questionnaires.Single(x => x.User.Id == user.Id);

            foreach (var item in model.QuestionnaireItemViewModels) {
                var questionnaireItem = questionnaire.Items.Single(x => x.Id == item.Id);
                questionnaireItem.Value = item.Value;
            }
            questionnaire.Date = DateTime.Now;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "User")]
        public ActionResult QuestionnairePrint(){
            ViewData["Report"] = new Reports.XtraReportQuestionnaire();
            return View();
        }

        public ActionResult DocumentViewerPart() {
            ViewData["Report"] = new Reports.XtraReportQuestionnaire();
            return PartialView("ReportQuestionnairePrint");
        }

        public ActionResult ExportDocumentViewPart() {
            return DocumentViewerExtension.ExportTo(new Reports.XtraReportQuestionnaire());
        }
        #endregion

        #region Форма настройки критериев

        [Authorize(Roles = "Administrator")]
        public ActionResult CriteriaSetting() {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult CriteriaSettingMaster() {
            var model = GetMasterModel();
            return PartialView("_CriteriaSettingMaster", model);
        }

        private IQueryable<CriteriaSetting> GetMasterModel() {
            var context = ApplicationDbContext.Create();
            var model = context.CriteriaSettings.OrderBy(x => x.Name);
            return model;
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult CriteriaSettingAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] CriteriaSetting criteriaSetting) {
            if (ModelState.IsValid) {
                try {
                    var context = ApplicationDbContext.Create();
                    context.CriteriaSettings.Add(criteriaSetting);
                    context.Questionnaires.ToArray().ForEach(x => x.Items.Add(new QuestionnaireItem() {
                        Key = criteriaSetting.Name
                    }));

                    context.SaveChanges();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else {
                ViewData["EditError"] = "Пожалуйста исправьте ошибки.";
            }
            var model = GetMasterModel();
            return PartialView("_CriteriaSettingMaster", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult CriteriaSettingEdit([ModelBinder(typeof(DevExpressEditorsBinder))] CriteriaSetting criteriaSetting) {
            if (ModelState.IsValid) {
                try {
                    var context = ApplicationDbContext.Create();
                    var oldСriteriaSetting = context.CriteriaSettings.Single(x => x.Id == criteriaSetting.Id);
                   
                    var existingItems = context.AuditItems.Where(x => x.Key == oldСriteriaSetting.Name);
                    existingItems.ForEach(x => x.Key = criteriaSetting.Name);
                    var existingQItems = context.QuestionnaireItems.Where(x => x.Key == oldСriteriaSetting.Name);
                    existingQItems.ForEach(x => x.Key = criteriaSetting.Name);

                    oldСriteriaSetting.Name = criteriaSetting.Name;
                    oldСriteriaSetting.Weight = criteriaSetting.Weight;
                    context.SaveChanges();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Пожалуйста исправьте ошибки.";
            var model = GetMasterModel();
            return PartialView("_CriteriaSettingMaster", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CriteriaSettingDelete(string id) {
            if (!string.IsNullOrEmpty(id)) {
                try {
                    var context = ApplicationDbContext.Create();
                    var criteriaSetting = context.CriteriaSettings.Single(x => x.Id == id);
                    var existingItems = context.AuditItems.Where(x => x.Key == criteriaSetting.Name);
                    var existingQItems = context.QuestionnaireItems.Where(x => x.Key == criteriaSetting.Name);
                    context.CriteriaSettings.Remove(criteriaSetting);
                    context.AuditItems.RemoveRange(existingItems);
                    context.QuestionnaireItems.RemoveRange(existingQItems);


                    context.SaveChanges();

                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            var model = GetMasterModel();
            return PartialView("_CriteriaSettingMaster", model);
        }
        #endregion

        [Authorize(Roles = "Auditor")]
        public ActionResult CompanyList() {
            return View();
        }

        [Authorize(Roles = "Auditor")]
        public ActionResult CompanyListMaster() {
            var model = GetCompanyListMasterModel();
            return PartialView("_CompanyListMaster", model);
        }

        private IQueryable<AuditViewModel> GetCompanyListMasterModel() {
            var context = ApplicationDbContext.Create();

            var list = new List<AuditViewModel>();
            foreach (var regData in context.RegistrationDatas.ToArray()) {
                var questionnaire = context.Questionnaires.Single(x => x.User.Id == regData.User.Id);
                var auditModel = new AuditViewModel() {
                    UserId = questionnaire.User.Id,
                    Xin = regData.Xin,
                    CompanyName = regData.OrganizationName,
                };

                var audit = context.Audits.SingleOrDefault(x => x.User.Id == questionnaire.User.Id);
                if (audit == null) {
                    auditModel.IsAudit = false;
                }
                else {
                    auditModel.AuditId = audit.Id;
                    var userTotal = 0.0;
                    var auditorTotal = 0.0;
                    foreach (var item in audit.Items) {
                        var criteriaSetting = context.CriteriaSettings.SingleOrDefault(x => x.Name == item.Key);
                        if (criteriaSetting == null) {
                            continue;
                        }
                        userTotal += item.UserValue*criteriaSetting.Weight;
                        auditorTotal += item.AuditorValue*criteriaSetting.Weight;
                    }
                    auditModel.UserTotal = userTotal;
                    auditModel.AuditorTotal = auditorTotal;
                    auditModel.IsAudit = auditorTotal > 0;
                }

                list.Add(auditModel);
            }



            var model = list.AsQueryable();
            return model;
        }

        [Authorize(Roles = "Auditor")]
        public ActionResult AuditForm(string userId) {
            var auditor = this.GetAuthUser();
            var context = ApplicationDbContext.Create();
            var questionnaire = context.Questionnaires.Single(x => x.User.Id == userId);
            var audit = context.Audits.SingleOrDefault(x => x.User.Id == questionnaire.User.Id);
            if (audit == null) {
                audit = new Audit() {
                    User = context.Users.Single(x=>x.Id == userId),
                    Auditor = context.Users.Single(x=>x.Id== auditor.Id),
                };
                foreach (var item in questionnaire.Items) {
                    audit.Items.Add(new AuditItem() {
                        Key = item.Key,
                        UserValue = item.Value,
                    });
                }
                context.Audits.Add(audit);
                context.SaveChanges();
            }

            var model = new AuditDetailViewModel(audit);
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Auditor")]
        public ActionResult AuditForm(AuditDetailViewModel model) {
            if (!ModelState.IsValid) {
                return View(model);
            }
            var auditor = this.GetAuthUser();
            var context = ApplicationDbContext.Create();

            var audit = context.Audits.Single(x => x.Id == model.AuditId);
            audit.Auditor = context.Users.Single(x => x.Id == auditor.Id);
            foreach (var item in model.Items) {
                var auditItem = audit.Items.Single(x => x.Id == item.Id);
                auditItem.AuditorValue = item.AuditorValue;
                auditItem.Comment = item.Comment;
            }
            context.SaveChanges();
            return RedirectToAction("CompanyList");
        }

        public ActionResult AuditFormReport(string auditId) {
            ViewData["Report"] = new Reports.XtraReportAuditForm(auditId);
            return View();
        }

        public ActionResult DocumentViewerPartAudit(string auditId) {
            ViewData["Report"] = new Reports.XtraReportAuditForm(auditId);
            return PartialView("AuditFormReportPrint");
        }

        public ActionResult ExportDocumentViewPartAudit(string auditId) {
            return DocumentViewerExtension.ExportTo(new Reports.XtraReportAuditForm(auditId));
        }
    }
}