using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Samruk.Web.Helpers;

namespace Samruk.Web.Models {
    public class AppDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext> {
        protected override void Seed(ApplicationDbContext context) {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            userManager.PasswordValidator = //new CustomPasswordValidator();
                new PasswordValidator {
                    //RequiredLength = 6,
                    RequireNonLetterOrDigit = false,
                    RequireDigit = false,
                    RequireLowercase = false,
                    RequireUppercase = false,
                };
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            
            var adminRole = new IdentityRole { Name = SiteConstants.Administrator};
            var userRole = new IdentityRole { Name = SiteConstants.User };
            var auditorRole = new IdentityRole { Name = SiteConstants.Auditor };

            // ��������� ���� � ��
            roleManager.Create(adminRole);
            roleManager.Create(userRole);
            roleManager.Create(auditorRole);

            // ������� �������������
            var admin = new ApplicationUser { UserName = "Admin" };
            const string password = "111";
            var result = userManager.Create(admin, password);

            // ���� �������� ������������ ������ �������
            if (result.Succeeded) {
                // ��������� ��� ������������ ����
                userManager.AddToRole(admin.Id, adminRole.Name);
            }

            AddReferences(context);
            context.SaveChanges();
            base.Seed(context);
        }

        private void AddReferences(ApplicationDbContext context) {
            #region Country
            context.Countries.Add(new Country() { NameRu = "����������" });
            context.Countries.Add(new Country() { NameRu = "���������" });
            context.Countries.Add(new Country() { NameRu = "�������" });
            context.Countries.Add(new Country() { NameRu = "�����������" });
            context.Countries.Add(new Country() { NameRu = "�������" });
            context.Countries.Add(new Country() { NameRu = "�����" });
            context.Countries.Add(new Country() { NameRu = "������������ �����" });
            context.Countries.Add(new Country() { NameRu = "�������" });
            context.Countries.Add(new Country() { NameRu = "������" });
            context.Countries.Add(new Country() { NameRu = "�������" });
            context.Countries.Add(new Country() { NameRu = "����������" });
            context.Countries.Add(new Country() { NameRu = "������� � �������" });
            context.Countries.Add(new Country() { NameRu = "���������" });
            context.Countries.Add(new Country() { NameRu = "�������" });
            context.Countries.Add(new Country() { NameRu = "�����" });
            context.Countries.Add(new Country() { NameRu = "������" });
            context.Countries.Add(new Country() { NameRu = "���������" });
            context.Countries.Add(new Country() { NameRu = "��������" });
            context.Countries.Add(new Country() { NameRu = "�������" });
            context.Countries.Add(new Country() { NameRu = "��������" });
            context.Countries.Add(new Country() { NameRu = "�����" });
            context.Countries.Add(new Country() { NameRu = "�������" });
            context.Countries.Add(new Country() { NameRu = "�����" });
            context.Countries.Add(new Country() { NameRu = "�������" });
            context.Countries.Add(new Country() { NameRu = "��������" });
            context.Countries.Add(new Country() { NameRu = "�������" });
            context.Countries.Add(new Country() { NameRu = "������ � �����������" });
            context.Countries.Add(new Country() { NameRu = "��������" });
            context.Countries.Add(new Country() { NameRu = "��������" });
            context.Countries.Add(new Country() { NameRu = "���������� ���������� � ��������� ������" });
            context.Countries.Add(new Country() { NameRu = "������ - ����������" });
            context.Countries.Add(new Country() { NameRu = "������� - ����" });
            context.Countries.Add(new Country() { NameRu = "�������" });
            context.Countries.Add(new Country() { NameRu = "�����" });
            context.Countries.Add(new Country() { NameRu = "�������" });
            context.Countries.Add(new Country() { NameRu = "�������" });
            context.Countries.Add(new Country() { NameRu = "���������" });
            context.Countries.Add(new Country() { NameRu = "���������� �������, ����������" });
            context.Countries.Add(new Country() { NameRu = "���������� �������, ���" });
            context.Countries.Add(new Country() { NameRu = "��������� �����" });
            context.Countries.Add(new Country() { NameRu = "�������" });
            context.Countries.Add(new Country() { NameRu = "�����" });
            context.Countries.Add(new Country() { NameRu = "������" });
            context.Countries.Add(new Country() { NameRu = "�����" });
            context.Countries.Add(new Country() { NameRu = "������" });
            context.Countries.Add(new Country() { NameRu = "����" });
            context.Countries.Add(new Country() { NameRu = "���������" });
            context.Countries.Add(new Country() { NameRu = "���������" });
            context.Countries.Add(new Country() { NameRu = "������" });
            context.Countries.Add(new Country() { NameRu = "������ - �����" });
            context.Countries.Add(new Country() { NameRu = "��������" });
            context.Countries.Add(new Country() { NameRu = "���������" });
            context.Countries.Add(new Country() { NameRu = "��������" });
            context.Countries.Add(new Country() { NameRu = "�������" });
            context.Countries.Add(new Country() { NameRu = "�������" });
            context.Countries.Add(new Country() { NameRu = "����������" });
            context.Countries.Add(new Country() { NameRu = "������" });
            context.Countries.Add(new Country() { NameRu = "������" });
            context.Countries.Add(new Country() { NameRu = "����" });
            context.Countries.Add(new Country() { NameRu = "�����" });
            context.Countries.Add(new Country() { NameRu = "�������" });
            context.Countries.Add(new Country() { NameRu = "��������" });
            context.Countries.Add(new Country() { NameRu = "������������� ����������" });
            context.Countries.Add(new Country() { NameRu = "������" });
            context.Countries.Add(new Country() { NameRu = "������" });
            context.Countries.Add(new Country() { NameRu = "�������� ������" });
            context.Countries.Add(new Country() { NameRu = "��������" });
            context.Countries.Add(new Country() { NameRu = "�����" });
            context.Countries.Add(new Country() { NameRu = "�������" });
            context.Countries.Add(new Country() { NameRu = "�����" });
            context.Countries.Add(new Country() { NameRu = "���������" });
            context.Countries.Add(new Country() { NameRu = "��������" });
            context.Countries.Add(new Country() { NameRu = "����" });
            context.Countries.Add(new Country() { NameRu = "����, ��������� ����������" });
            context.Countries.Add(new Country() { NameRu = "��������" });
            context.Countries.Add(new Country() { NameRu = "��������" });
            context.Countries.Add(new Country() { NameRu = "�������" });
            context.Countries.Add(new Country() { NameRu = "������" });
            context.Countries.Add(new Country() { NameRu = "���� - �����" });
            context.Countries.Add(new Country() { NameRu = "���������" });
            context.Countries.Add(new Country() { NameRu = "��������" });
            context.Countries.Add(new Country() { NameRu = "�������" });
            context.Countries.Add(new Country() { NameRu = "������" });
            context.Countries.Add(new Country() { NameRu = "�����" });
            context.Countries.Add(new Country() { NameRu = "�����" });
            context.Countries.Add(new Country() { NameRu = "����" });
            context.Countries.Add(new Country() { NameRu = "��������" });
            context.Countries.Add(new Country() { NameRu = "��������" });
            context.Countries.Add(new Country() { NameRu = "�����" });
            context.Countries.Add(new Country() { NameRu = "��������� (������) �������" });
            context.Countries.Add(new Country() { NameRu = "��������" });
            context.Countries.Add(new Country() { NameRu = "������" });
            context.Countries.Add(new Country() { NameRu = "�����" });
            context.Countries.Add(new Country() { NameRu = "�����, ��������������� ����������" });
            context.Countries.Add(new Country() { NameRu = "�����, ������� - ��������������� ����������" });
            context.Countries.Add(new Country() { NameRu = "�����, ����������" });
            context.Countries.Add(new Country() { NameRu = "����� - ����" });
            context.Countries.Add(new Country() { NameRu = "��� �''�����" });
            context.Countries.Add(new Country() { NameRu = "����" });
            context.Countries.Add(new Country() { NameRu = "������" });
            context.Countries.Add(new Country() { NameRu = "�������� ������� - ��������������� ����������" });
            context.Countries.Add(new Country() { NameRu = "������" });
            context.Countries.Add(new Country() { NameRu = "������" });
            context.Countries.Add(new Country() { NameRu = "�������" });
            context.Countries.Add(new Country() { NameRu = "�����" });
            context.Countries.Add(new Country() { NameRu = "��������� �������� ����������" });
            context.Countries.Add(new Country() { NameRu = "�����" });
            context.Countries.Add(new Country() { NameRu = "�����������" });
            context.Countries.Add(new Country() { NameRu = "����������" });
            context.Countries.Add(new Country() { NameRu = "��������" });
            context.Countries.Add(new Country() { NameRu = "����������" });
            context.Countries.Add(new Country() { NameRu = "����������" });
            context.Countries.Add(new Country() { NameRu = "�������" });
            context.Countries.Add(new Country() { NameRu = "�����" });
            context.Countries.Add(new Country() { NameRu = "���������, ������ ����������� ����������" });
            context.Countries.Add(new Country() { NameRu = "������" });
            context.Countries.Add(new Country() { NameRu = "��������" });
            context.Countries.Add(new Country() { NameRu = "����" });
            context.Countries.Add(new Country() { NameRu = "����� ������������� ���������� ������� ����������� ������" });
            context.Countries.Add(new Country() { NameRu = "��������" });
            context.Countries.Add(new Country() { NameRu = "������" });
            context.Countries.Add(new Country() { NameRu = "�������" });
            context.Countries.Add(new Country() { NameRu = "���������" });
            context.Countries.Add(new Country() { NameRu = "���������� �������" });
            context.Countries.Add(new Country() { NameRu = "�������" });
            context.Countries.Add(new Country() { NameRu = "����������, ������������ �����" });
            context.Countries.Add(new Country() { NameRu = "��������" });
            context.Countries.Add(new Country() { NameRu = "�������, ����������" });
            context.Countries.Add(new Country() { NameRu = "������" });
            context.Countries.Add(new Country() { NameRu = "��������" });
            context.Countries.Add(new Country() { NameRu = "����������" });
            context.Countries.Add(new Country() { NameRu = "������" });
            context.Countries.Add(new Country() { NameRu = "�������" });
            context.Countries.Add(new Country() { NameRu = "�����" });
            context.Countries.Add(new Country() { NameRu = "�����" });
            context.Countries.Add(new Country() { NameRu = "�����" });
            context.Countries.Add(new Country() { NameRu = "�������" });
            context.Countries.Add(new Country() { NameRu = "������������� ������" });
            context.Countries.Add(new Country() { NameRu = "����������" });
            context.Countries.Add(new Country() { NameRu = "���������" });
            context.Countries.Add(new Country() { NameRu = "����" });
            context.Countries.Add(new Country() { NameRu = "����� ��������" });
            context.Countries.Add(new Country() { NameRu = "����� ���������" });
            context.Countries.Add(new Country() { NameRu = "��������" });
            context.Countries.Add(new Country() { NameRu = "������������ �������� �������" });
            context.Countries.Add(new Country() { NameRu = "����" });
            context.Countries.Add(new Country() { NameRu = "������ ����" });
            context.Countries.Add(new Country() { NameRu = "������ �������" });
            context.Countries.Add(new Country() { NameRu = "������ ���������" });
            context.Countries.Add(new Country() { NameRu = "������ ���� � ������� ����������" });
            context.Countries.Add(new Country() { NameRu = "������� ������" });
            context.Countries.Add(new Country() { NameRu = "������� ����" });
            context.Countries.Add(new Country() { NameRu = "������� ����� � ������" });
            context.Countries.Add(new Country() { NameRu = "��������" });
            context.Countries.Add(new Country() { NameRu = "�����" });
            context.Countries.Add(new Country() { NameRu = "������������ ����������, ��������������" });
            context.Countries.Add(new Country() { NameRu = "������" });
            context.Countries.Add(new Country() { NameRu = "������� ������� (����������� - ����� �������)" });
            context.Countries.Add(new Country() { NameRu = "����� - ����� ������" });
            context.Countries.Add(new Country() { NameRu = "��������" });
            context.Countries.Add(new Country() { NameRu = "����" });
            context.Countries.Add(new Country() { NameRu = "�������" });
            context.Countries.Add(new Country() { NameRu = "������" });
            context.Countries.Add(new Country() { NameRu = "����������" });
            context.Countries.Add(new Country() { NameRu = "������ - ����" });
            context.Countries.Add(new Country() { NameRu = "�������" });
            context.Countries.Add(new Country() { NameRu = "������" });
            context.Countries.Add(new Country() { NameRu = "������" });
            context.Countries.Add(new Country() { NameRu = "�������" });
            context.Countries.Add(new Country() { NameRu = "���������" });
            context.Countries.Add(new Country() { NameRu = "�����" });
            context.Countries.Add(new Country() { NameRu = "��� - ������" });
            context.Countries.Add(new Country() { NameRu = "��� - ���� � ��������" });
            context.Countries.Add(new Country() { NameRu = "���������� ������" });
            context.Countries.Add(new Country() { NameRu = "���������" });
            context.Countries.Add(new Country() { NameRu = "������ �����" });
            context.Countries.Add(new Country() { NameRu = "�������� ���������� �������" });
            context.Countries.Add(new Country() { NameRu = "�������" });
            context.Countries.Add(new Country() { NameRu = "��� - ���� � �������" });
            context.Countries.Add(new Country() { NameRu = "�������" });
            context.Countries.Add(new Country() { NameRu = "���� - ������� � ���������" });
            context.Countries.Add(new Country() { NameRu = "���� - ���� � �����" });
            context.Countries.Add(new Country() { NameRu = "���� - �����" });
            context.Countries.Add(new Country() { NameRu = "��������" });
            context.Countries.Add(new Country() { NameRu = "��������� �������� ����������" });
            context.Countries.Add(new Country() { NameRu = "��������" });
            context.Countries.Add(new Country() { NameRu = "��������" });
            context.Countries.Add(new Country() { NameRu = "����������� �����������" });
            context.Countries.Add(new Country() { NameRu = "����������� �����" });
            context.Countries.Add(new Country() { NameRu = "���������� �������" });
            context.Countries.Add(new Country() { NameRu = "������" });
            context.Countries.Add(new Country() { NameRu = "�����" });
            context.Countries.Add(new Country() { NameRu = "�������" });
            context.Countries.Add(new Country() { NameRu = "������ - �����" });
            context.Countries.Add(new Country() { NameRu = "�����������" });
            context.Countries.Add(new Country() { NameRu = "������� (�����)" });
            context.Countries.Add(new Country() { NameRu = "�������" });
            context.Countries.Add(new Country() { NameRu = "��������, ������������ ����������" });
            context.Countries.Add(new Country() { NameRu = "����" });
            context.Countries.Add(new Country() { NameRu = "�������" });
            context.Countries.Add(new Country() { NameRu = "�����" });
            context.Countries.Add(new Country() { NameRu = "�������� � ������" });
            context.Countries.Add(new Country() { NameRu = "������" });
            context.Countries.Add(new Country() { NameRu = "�����" });
            context.Countries.Add(new Country() { NameRu = "���������" });
            context.Countries.Add(new Country() { NameRu = "������" });
            context.Countries.Add(new Country() { NameRu = "������" });
            context.Countries.Add(new Country() { NameRu = "����������" });
            context.Countries.Add(new Country() { NameRu = "�������" });
            context.Countries.Add(new Country() { NameRu = "������ � ������" });
            context.Countries.Add(new Country() { NameRu = "�������" });
            context.Countries.Add(new Country() { NameRu = "��������� �������" });
            context.Countries.Add(new Country() { NameRu = "�����" });
            context.Countries.Add(new Country() { NameRu = "���������" });
            context.Countries.Add(new Country() { NameRu = "���������" });
            context.Countries.Add(new Country() { NameRu = "������������ ������� (�����������)" });
            context.Countries.Add(new Country() { NameRu = "�������" });
            context.Countries.Add(new Country() { NameRu = "����������� ������" });
            context.Countries.Add(new Country() { NameRu = "����������� ���������" });
            context.Countries.Add(new Country() { NameRu = "����������� ����� ����������" });
            context.Countries.Add(new Country() { NameRu = "��������" });
            context.Countries.Add(new Country() { NameRu = "���������� - ����������� ����������" });
            context.Countries.Add(new Country() { NameRu = "���" });
            context.Countries.Add(new Country() { NameRu = "������� ����������" });
            context.Countries.Add(new Country() { NameRu = "����" });
            context.Countries.Add(new Country() { NameRu = "���������" });
            context.Countries.Add(new Country() { NameRu = "������" });
            context.Countries.Add(new Country() { NameRu = "���������� � �� �����" });
            context.Countries.Add(new Country() { NameRu = "��� - �����" });
            context.Countries.Add(new Country() { NameRu = "�������" });
            context.Countries.Add(new Country() { NameRu = "�������������� ������" });
            context.Countries.Add(new Country() { NameRu = "�������" });
            context.Countries.Add(new Country() { NameRu = "�������" });
            context.Countries.Add(new Country() { NameRu = "�������" });
            context.Countries.Add(new Country() { NameRu = "���������" });
            context.Countries.Add(new Country() { NameRu = "����� ������" });
            context.Countries.Add(new Country() { NameRu = "����� �������� � ����� ���������� �������" });
            context.Countries.Add(new Country() { NameRu = "������" });
            context.Countries.Add(new Country() { NameRu = "������" });
            #endregion

            #region ProviderType

            context.ProviderTypes.Add(new ProviderType() {NameRu = "����������� ����", Enum = ProviderTypeEnum.LegalPerson});
            context.ProviderTypes.Add(new ProviderType() {NameRu = "���������� ����", Enum = ProviderTypeEnum.PhysPerson});

            #endregion

            #region LegalForm

            context.LegalForms.Add(new LegalForm() { NameRu = "��", Enum = LegalFormEnum.AO});
            context.LegalForms.Add(new LegalForm() { NameRu = "���", Enum = LegalFormEnum.TOO });
            context.LegalForms.Add(new LegalForm() { NameRu = "���", Enum = LegalFormEnum.RGP });
            context.LegalForms.Add(new LegalForm() { NameRu = "����", Enum = LegalFormEnum.Other });

            #endregion

            #region CriteriaSetting

            context.CriteriaSettings.Add(new CriteriaSetting() { Name = "������� ����� ������ (���)", Weight = 0.5 });
            context.CriteriaSettings.Add(new CriteriaSetting() { Name = "������� ����������������� ������� ����������� ��������", Weight = 1 });
            context.CriteriaSettings.Add(new CriteriaSetting() { Name = "���� �������� ���������� (%) ", Weight = 0.1 });
            context.CriteriaSettings.Add(new CriteriaSetting() { Name = "�������� ��� ����� ������������� ���������� ", Weight = 5 });

            #endregion
        }
    }
}