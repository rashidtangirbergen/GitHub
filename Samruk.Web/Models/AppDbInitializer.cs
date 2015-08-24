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

            // äîáàâëÿåì ğîëè â áä
            roleManager.Create(adminRole);
            roleManager.Create(userRole);
            roleManager.Create(auditorRole);

            // ñîçäàåì ïîëüçîâàòåëåé
            var admin = new ApplicationUser { UserName = "Admin" };
            const string password = "111";
            var result = userManager.Create(admin, password);

            // åñëè ñîçäàíèå ïîëüçîâàòåëÿ ïğîøëî óñïåøíî
            if (result.Succeeded) {
                // äîáàâëÿåì äëÿ ïîëüçîâàòåëÿ ğîëü
                userManager.AddToRole(admin.Id, adminRole.Name);
            }

            AddReferences(context);
            context.SaveChanges();
            base.Seed(context);
        }

        private void AddReferences(ApplicationDbContext context) {
            #region Country
            context.Countries.Add(new Country() { NameRu = "ÀÔÃÀÍÈÑÒÀÍ" });
            context.Countries.Add(new Country() { NameRu = "ÀÂÑÒĞÀËÈß" });
            context.Countries.Add(new Country() { NameRu = "ÀÂÑÒĞÈß" });
            context.Countries.Add(new Country() { NameRu = "ÀÇÅĞÁÀÉÄÆÀÍ" });
            context.Countries.Add(new Country() { NameRu = "ÀËÁÀÍÈß" });
            context.Countries.Add(new Country() { NameRu = "ÀËÆÈĞ" });
            context.Countries.Add(new Country() { NameRu = "ÀÌÅĞÈÊÀÍÑÊÎÅ ÑÀÌÎÀ" });
            context.Countries.Add(new Country() { NameRu = "ÀÍÃÈËÜß" });
            context.Countries.Add(new Country() { NameRu = "ÀÍÃÎËÀ" });
            context.Countries.Add(new Country() { NameRu = "ÀÍÄÎĞĞÀ" });
            context.Countries.Add(new Country() { NameRu = "ÀÍÒÀĞÊÒÈÄÀ" });
            context.Countries.Add(new Country() { NameRu = "ÀÍÒÈÃÓÀ È ÁÀĞÁÓÄÀ" });
            context.Countries.Add(new Country() { NameRu = "ÀĞÃÅÍÒÈÍÀ" });
            context.Countries.Add(new Country() { NameRu = "ÀĞÌÅÍÈß" });
            context.Countries.Add(new Country() { NameRu = "ÀĞÓÁÀ" });
            context.Countries.Add(new Country() { NameRu = "ÁÀÃÀÌÛ" });
            context.Countries.Add(new Country() { NameRu = "ÁÀÍÃËÀÄÅØ" });
            context.Countries.Add(new Country() { NameRu = "ÁÀĞÁÀÄÎÑ" });
            context.Countries.Add(new Country() { NameRu = "ÁÀÕĞÅÉÍ" });
            context.Countries.Add(new Country() { NameRu = "ÁÅËÀĞÓÑÜ" });
            context.Countries.Add(new Country() { NameRu = "ÁÅËÈÇ" });
            context.Countries.Add(new Country() { NameRu = "ÁÅËÜÃÈß" });
            context.Countries.Add(new Country() { NameRu = "ÁÅÍÈÍ" });
            context.Countries.Add(new Country() { NameRu = "ÁÅĞÌÓÄÛ" });
            context.Countries.Add(new Country() { NameRu = "ÁÎËÃÀĞÈß" });
            context.Countries.Add(new Country() { NameRu = "ÁÎËÈÂÈß" });
            context.Countries.Add(new Country() { NameRu = "ÁÎÑÍÈß È ÃÅĞÖÅÃÎÂÈÍÀ" });
            context.Countries.Add(new Country() { NameRu = "ÁÎÒÑÂÀÍÀ" });
            context.Countries.Add(new Country() { NameRu = "ÁĞÀÇÈËÈß" });
            context.Countries.Add(new Country() { NameRu = "ÁĞÈÒÀÍÑÊÀß ÒÅĞĞÈÒÎĞÈß Â ÈÍÄÈÉÑÊÎÌ ÎÊÅÀÍÅ" });
            context.Countries.Add(new Country() { NameRu = "ÁĞÓÍÅÉ - ÄÀĞÓÑÑÀËÀÌ" });
            context.Countries.Add(new Country() { NameRu = "ÁÓĞÊÈÍÀ - ÔÀÑÎ" });
            context.Countries.Add(new Country() { NameRu = "ÁÓĞÓÍÄÈ" });
            context.Countries.Add(new Country() { NameRu = "ÁÓÒÀÍ" });
            context.Countries.Add(new Country() { NameRu = "ÂÀÍÓÀÒÓ" });
            context.Countries.Add(new Country() { NameRu = "ÂÅÍÃĞÈß" });
            context.Countries.Add(new Country() { NameRu = "ÂÅÍÅÑÓİËÀ" });
            context.Countries.Add(new Country() { NameRu = "ÂÈĞÃÈÍÑÊÈÅ ÎÑÒĞÎÂÀ, ÁĞÈÒÀÍÑÊÈÅ" });
            context.Countries.Add(new Country() { NameRu = "ÂÈĞÃÈÍÑÊÈÅ ÎÑÒĞÎÂÀ, ÑØÀ" });
            context.Countries.Add(new Country() { NameRu = "ÂÎÑÒÎ×ÍÛÉ ÒÈÌÎĞ" });
            context.Countries.Add(new Country() { NameRu = "ÂÜÅÒÍÀÌ" });
            context.Countries.Add(new Country() { NameRu = "ÃÀÁÎÍ" });
            context.Countries.Add(new Country() { NameRu = "ÃÀÉÀÍÀ" });
            context.Countries.Add(new Country() { NameRu = "ÃÀÈÒÈ" });
            context.Countries.Add(new Country() { NameRu = "ÃÀÌÁÈß" });
            context.Countries.Add(new Country() { NameRu = "ÃÀÍÀ" });
            context.Countries.Add(new Country() { NameRu = "ÃÂÀÄÅËÓÏÀ" });
            context.Countries.Add(new Country() { NameRu = "ÃÂÀÒÅÌÀËÀ" });
            context.Countries.Add(new Country() { NameRu = "ÃÂÈÍÅß" });
            context.Countries.Add(new Country() { NameRu = "ÃÂÈÍÅß - ÁÈÑÀÓ" });
            context.Countries.Add(new Country() { NameRu = "ÃÅĞÌÀÍÈß" });
            context.Countries.Add(new Country() { NameRu = "ÃÈÁĞÀËÒÀĞ" });
            context.Countries.Add(new Country() { NameRu = "ÃÎÍÄÓĞÀÑ" });
            context.Countries.Add(new Country() { NameRu = "ÃÎÍÊÎÍÃ" });
            context.Countries.Add(new Country() { NameRu = "ÃĞÅÍÀÄÀ" });
            context.Countries.Add(new Country() { NameRu = "ÃĞÅÍËÀÍÄÈß" });
            context.Countries.Add(new Country() { NameRu = "ÃĞÅÖÈß" });
            context.Countries.Add(new Country() { NameRu = "ÃĞÓÇÈß" });
            context.Countries.Add(new Country() { NameRu = "ÃÓÀÌ" });
            context.Countries.Add(new Country() { NameRu = "ÄÀÍÈß" });
            context.Countries.Add(new Country() { NameRu = "ÄÆÈÁÓÒÈ" });
            context.Countries.Add(new Country() { NameRu = "ÄÎÌÈÍÈÊÀ" });
            context.Countries.Add(new Country() { NameRu = "ÄÎÌÈÍÈÊÀÍÑÊÀß ĞÅÑÏÓÁËÈÊÀ" });
            context.Countries.Add(new Country() { NameRu = "ÅÃÈÏÅÒ" });
            context.Countries.Add(new Country() { NameRu = "ÇÀÌÁÈß" });
            context.Countries.Add(new Country() { NameRu = "ÇÀÏÀÄÍÀß ÑÀÕÀĞÀ" });
            context.Countries.Add(new Country() { NameRu = "ÇÈÌÁÀÁÂÅ" });
            context.Countries.Add(new Country() { NameRu = "ÉÅÌÅÍ" });
            context.Countries.Add(new Country() { NameRu = "ÈÇĞÀÈËÜ" });
            context.Countries.Add(new Country() { NameRu = "ÈÍÄÈß" });
            context.Countries.Add(new Country() { NameRu = "ÈÍÄÎÍÅÇÈß" });
            context.Countries.Add(new Country() { NameRu = "ÈÎĞÄÀÍÈß" });
            context.Countries.Add(new Country() { NameRu = "ÈĞÀÊ" });
            context.Countries.Add(new Country() { NameRu = "ÈĞÀÍ, ÈÑËÀÌÑÊÀß ĞÅÑÏÓÁËÈÊÀ" });
            context.Countries.Add(new Country() { NameRu = "ÈĞËÀÍÄÈß" });
            context.Countries.Add(new Country() { NameRu = "ÈÑËÀÍÄÈß" });
            context.Countries.Add(new Country() { NameRu = "ÈÑÏÀÍÈß" });
            context.Countries.Add(new Country() { NameRu = "ÈÒÀËÈß" });
            context.Countries.Add(new Country() { NameRu = "ÊÀÁÎ - ÂÅĞÄÅ" });
            context.Countries.Add(new Country() { NameRu = "ÊÀÇÀÕÑÒÀÍ" });
            context.Countries.Add(new Country() { NameRu = "ÊÀÌÁÎÄÆÀ" });
            context.Countries.Add(new Country() { NameRu = "ÊÀÌÅĞÓÍ" });
            context.Countries.Add(new Country() { NameRu = "ÊÀÍÀÄÀ" });
            context.Countries.Add(new Country() { NameRu = "ÊÀÒÀĞ" });
            context.Countries.Add(new Country() { NameRu = "ÊÅÍÈß" });
            context.Countries.Add(new Country() { NameRu = "ÊÈÏĞ" });
            context.Countries.Add(new Country() { NameRu = "ÊÈĞÃÈÇÈß" });
            context.Countries.Add(new Country() { NameRu = "ÊÈĞÈÁÀÒÈ" });
            context.Countries.Add(new Country() { NameRu = "ÊÈÒÀÉ" });
            context.Countries.Add(new Country() { NameRu = "ÊÎÊÎÑÎÂÛÅ (ÊÈËÈÍÃ) ÎÑÒĞÎÂÀ" });
            context.Countries.Add(new Country() { NameRu = "ÊÎËÓÌÁÈß" });
            context.Countries.Add(new Country() { NameRu = "ÊÎÌÎĞÛ" });
            context.Countries.Add(new Country() { NameRu = "ÊÎÍÃÎ" });
            context.Countries.Add(new Country() { NameRu = "ÊÎÍÃÎ, ÄÅÌÎÊĞÀÒÈ×ÅÑÊÀß ĞÅÑÏÓÁËÈÊÀ" });
            context.Countries.Add(new Country() { NameRu = "ÊÎĞÅß, ÍÀĞÎÄÍÎ - ÄÅÌÎÊĞÀÒÈ×ÅÑÊÀß ĞÅÑÏÓÁËÈÊÀ" });
            context.Countries.Add(new Country() { NameRu = "ÊÎĞÅß, ĞÅÑÏÓÁËÈÊÀ" });
            context.Countries.Add(new Country() { NameRu = "ÊÎÑÒÀ - ĞÈÊÀ" });
            context.Countries.Add(new Country() { NameRu = "ÊÎÒ Ä''ÈÂÓÀĞ" });
            context.Countries.Add(new Country() { NameRu = "ÊÓÁÀ" });
            context.Countries.Add(new Country() { NameRu = "ÊÓÂÅÉÒ" });
            context.Countries.Add(new Country() { NameRu = "ËÀÎÑÑÊÀß ÍÀĞÎÄÍÎ - ÄÅÌÎÊĞÀÒÈ×ÅÑÊÀß ĞÅÑÏÓÁËÈÊÀ" });
            context.Countries.Add(new Country() { NameRu = "ËÀÒÂÈß" });
            context.Countries.Add(new Country() { NameRu = "ËÅÑÎÒÎ" });
            context.Countries.Add(new Country() { NameRu = "ËÈÁÅĞÈß" });
            context.Countries.Add(new Country() { NameRu = "ËÈÂÀÍ" });
            context.Countries.Add(new Country() { NameRu = "ËÈÂÈÉÑÊÀß ÀĞÀÁÑÊÀß ÄÆÀÌÀÕÈĞÈß" });
            context.Countries.Add(new Country() { NameRu = "ËÈÒÂÀ" });
            context.Countries.Add(new Country() { NameRu = "ËÈÕÒÅÍØÒÅÉÍ" });
            context.Countries.Add(new Country() { NameRu = "ËŞÊÑÅÌÁÓĞÃ" });
            context.Countries.Add(new Country() { NameRu = "ÌÀÂĞÈÊÈÉ" });
            context.Countries.Add(new Country() { NameRu = "ÌÀÂĞÈÒÀÍÈß" });
            context.Countries.Add(new Country() { NameRu = "ÌÀÄÀÃÀÑÊÀĞ" });
            context.Countries.Add(new Country() { NameRu = "ÌÀÉÎÒÒÀ" });
            context.Countries.Add(new Country() { NameRu = "ÌÀÊÀÎ" });
            context.Countries.Add(new Country() { NameRu = "ÌÀÊÅÄÎÍÈß, ÁÛÂØÀß ŞÃÎÑËÀÂÑÊÀß ĞÅÑÏÓÁËÈÊÀ" });
            context.Countries.Add(new Country() { NameRu = "ÌÀËÀÂÈ" });
            context.Countries.Add(new Country() { NameRu = "ÌÀËÀÉÇÈß" });
            context.Countries.Add(new Country() { NameRu = "ÌÀËÈ" });
            context.Countries.Add(new Country() { NameRu = "ÌÀËÛÅ ÒÈÕÎÎÊÅÀÍÑÊÈÅ ÎÒÄÀËÅÍÍÛÅ ÎÑÒĞÎÂÀ ÑÎÅÄÈÍÅÍÍÛÕ ØÒÀÒÎÂ" });
            context.Countries.Add(new Country() { NameRu = "ÌÀËÜÄÈÂÛ" });
            context.Countries.Add(new Country() { NameRu = "ÌÀËÜÒÀ" });
            context.Countries.Add(new Country() { NameRu = "ÌÀĞÎÊÊÎ" });
            context.Countries.Add(new Country() { NameRu = "ÌÀĞÒÈÍÈÊÀ" });
            context.Countries.Add(new Country() { NameRu = "ÌÀĞØÀËËÎÂÛ ÎÑÒĞÎÂÀ" });
            context.Countries.Add(new Country() { NameRu = "ÌÅÊÑÈÊÀ" });
            context.Countries.Add(new Country() { NameRu = "ÌÈÊĞÎÍÅÇÈß, ÔÅÄÅĞÀÒÈÂÍÛÅ ØÒÀÒÛ" });
            context.Countries.Add(new Country() { NameRu = "ÌÎÇÀÌÁÈÊ" });
            context.Countries.Add(new Country() { NameRu = "ÌÎËÄÎÂÀ, ĞÅÑÏÓÁËÈÊÀ" });
            context.Countries.Add(new Country() { NameRu = "ÌÎÍÀÊÎ" });
            context.Countries.Add(new Country() { NameRu = "ÌÎÍÃÎËÈß" });
            context.Countries.Add(new Country() { NameRu = "ÌÎÍÒÑÅĞĞÀÒ" });
            context.Countries.Add(new Country() { NameRu = "ÌÜßÍÌÀ" });
            context.Countries.Add(new Country() { NameRu = "ÍÀÌÈÁÈß" });
            context.Countries.Add(new Country() { NameRu = "ÍÀÓĞÓ" });
            context.Countries.Add(new Country() { NameRu = "ÍÅÏÀË" });
            context.Countries.Add(new Country() { NameRu = "ÍÈÃÅĞ" });
            context.Countries.Add(new Country() { NameRu = "ÍÈÃÅĞÈß" });
            context.Countries.Add(new Country() { NameRu = "ÍÈÄÅĞËÀÍÄÑÊÈÅ ÀÍÒÈËÛ" });
            context.Countries.Add(new Country() { NameRu = "ÍÈÄÅĞËÀÍÄÛ" });
            context.Countries.Add(new Country() { NameRu = "ÍÈÊÀĞÀÃÓÀ" });
            context.Countries.Add(new Country() { NameRu = "ÍÈÓİ" });
            context.Countries.Add(new Country() { NameRu = "ÍÎÂÀß ÇÅËÀÍÄÈß" });
            context.Countries.Add(new Country() { NameRu = "ÍÎÂÀß ÊÀËÅÄÎÍÈß" });
            context.Countries.Add(new Country() { NameRu = "ÍÎĞÂÅÃÈß" });
            context.Countries.Add(new Country() { NameRu = "ÎÁÚÅÄÈÍÅÍÍÛÅ ÀĞÀÁÑÊÈÅ İÌÈĞÀÒÛ" });
            context.Countries.Add(new Country() { NameRu = "ÎÌÀÍ" });
            context.Countries.Add(new Country() { NameRu = "ÎÑÒĞÎÂ ÁÓÂÅ" });
            context.Countries.Add(new Country() { NameRu = "ÎÑÒĞÎÂ ÍÎĞÔÎËÊ" });
            context.Countries.Add(new Country() { NameRu = "ÎÑÒĞÎÂ ĞÎÆÄÅÑÒÂÀ" });
            context.Countries.Add(new Country() { NameRu = "ÎÑÒĞÎÂ ÕÅĞÄ È ÎÑÒĞÎÂÀ ÌÀÊÄÎÍÀËÜÄ" });
            context.Countries.Add(new Country() { NameRu = "ÎÑÒĞÎÂÀ ÊÀÉÌÀÍ" });
            context.Countries.Add(new Country() { NameRu = "ÎÑÒĞÎÂÀ ÊÓÊÀ" });
            context.Countries.Add(new Country() { NameRu = "ÎÑÒĞÎÂÀ ÒÅĞÊÑ È ÊÀÉÊÎÑ" });
            context.Countries.Add(new Country() { NameRu = "ÏÀÊÈÑÒÀÍ" });
            context.Countries.Add(new Country() { NameRu = "ÏÀËÀÓ" });
            context.Countries.Add(new Country() { NameRu = "ÏÀËÅÑÒÈÍÑÊÀß ÒÅĞĞÈÒÎĞÈß, ÎÊÊÓÏÈĞÎÂÀÍÍÀß" });
            context.Countries.Add(new Country() { NameRu = "ÏÀÍÀÌÀ" });
            context.Countries.Add(new Country() { NameRu = "ÏÀÏÑÊÈÉ ÏĞÅÑÒÎË (ÃÎÑÓÄÀĞÑÒÂÎ - ÃÎĞÎÄ ÂÀÒÈÊÀÍ)" });
            context.Countries.Add(new Country() { NameRu = "ÏÀÏÓÀ - ÍÎÂÀß ÃÂÈÍÅß" });
            context.Countries.Add(new Country() { NameRu = "ÏÀĞÀÃÂÀÉ" });
            context.Countries.Add(new Country() { NameRu = "ÏÅĞÓ" });
            context.Countries.Add(new Country() { NameRu = "ÏÈÒÊÅĞÍ" });
            context.Countries.Add(new Country() { NameRu = "ÏÎËÜØÀ" });
            context.Countries.Add(new Country() { NameRu = "ÏÎĞÒÓÃÀËÈß" });
            context.Countries.Add(new Country() { NameRu = "ÏÓİĞÒÎ - ĞÈÊÎ" });
            context.Countries.Add(new Country() { NameRu = "ĞÅŞÍÜÎÍ" });
            context.Countries.Add(new Country() { NameRu = "ĞÎÑÑÈß" });
            context.Countries.Add(new Country() { NameRu = "ĞÓÀÍÄÀ" });
            context.Countries.Add(new Country() { NameRu = "ĞÓÌÛÍÈß" });
            context.Countries.Add(new Country() { NameRu = "ÑÀËÜÂÀÄÎĞ" });
            context.Countries.Add(new Country() { NameRu = "ÑÀÌÎÀ" });
            context.Countries.Add(new Country() { NameRu = "ÑÀÍ - ÌÀĞÈÍÎ" });
            context.Countries.Add(new Country() { NameRu = "ÑÀÍ - ÒÎÌÅ È ÏĞÈÍÑÈÏÈ" });
            context.Countries.Add(new Country() { NameRu = "ÑÀÓÄÎÂÑÊÀß ÀĞÀÂÈß" });
            context.Countries.Add(new Country() { NameRu = "ÑÂÀÇÈËÅÍÄ" });
            context.Countries.Add(new Country() { NameRu = "ÑÂßÒÀß ÅËÅÍÀ" });
            context.Countries.Add(new Country() { NameRu = "ÑÅÂÅĞÍÛÅ ÌÀĞÈÀÍÑÊÈÅ ÎÑÒĞÎÂÀ" });
            context.Countries.Add(new Country() { NameRu = "ÑÅÉØÅËÛ" });
            context.Countries.Add(new Country() { NameRu = "ÑÅÍ - ÏÜÅĞ È ÌÈÊÅËÎÍ" });
            context.Countries.Add(new Country() { NameRu = "ÑÅÍÅÃÀË" });
            context.Countries.Add(new Country() { NameRu = "ÑÅÍÒ - ÂÈÍÑÅÍÒ È ÃĞÅÍÀÄÈÍÛ" });
            context.Countries.Add(new Country() { NameRu = "ÑÅÍÒ - ÊÈÒÑ È ÍÅÂÈÑ" });
            context.Countries.Add(new Country() { NameRu = "ÑÅÍÒ - ËŞÑÈß" });
            context.Countries.Add(new Country() { NameRu = "ÑÈÍÃÀÏÓĞ" });
            context.Countries.Add(new Country() { NameRu = "ÑÈĞÈÉÑÊÀß ÀĞÀÁÑÊÀß ĞÅÑÏÓÁËÈÊÀ" });
            context.Countries.Add(new Country() { NameRu = "ÑËÎÂÀÊÈß" });
            context.Countries.Add(new Country() { NameRu = "ÑËÎÂÅÍÈß" });
            context.Countries.Add(new Country() { NameRu = "ÑÎÅÄÈÍÅÍÍÎÅ ÊÎĞÎËÅÂÑÒÂÎ" });
            context.Countries.Add(new Country() { NameRu = "ÑÎÅÄÈÍÅÍÍÛÅ ØÒÀÒÛ" });
            context.Countries.Add(new Country() { NameRu = "ÑÎËÎÌÎÍÎÂÛ ÎÑÒĞÎÂÀ" });
            context.Countries.Add(new Country() { NameRu = "ÑÎÌÀËÈ" });
            context.Countries.Add(new Country() { NameRu = "ÑÓÄÀÍ" });
            context.Countries.Add(new Country() { NameRu = "ÑÓĞÈÍÀÌ" });
            context.Countries.Add(new Country() { NameRu = "ÑÜÅĞĞÀ - ËÅÎÍÅ" });
            context.Countries.Add(new Country() { NameRu = "ÒÀÄÆÈÊÈÑÒÀÍ" });
            context.Countries.Add(new Country() { NameRu = "ÒÀÉÂÀÍÜ (ÊÈÒÀÉ)" });
            context.Countries.Add(new Country() { NameRu = "ÒÀÈËÀÍÄ" });
            context.Countries.Add(new Country() { NameRu = "ÒÀÍÇÀÍÈß, ÎÁÚÅÄÈÍÅÍÍÀß ĞÅÑÏÓÁËÈÊÀ" });
            context.Countries.Add(new Country() { NameRu = "ÒÎÃÎ" });
            context.Countries.Add(new Country() { NameRu = "ÒÎÊÅËÀÓ" });
            context.Countries.Add(new Country() { NameRu = "ÒÎÍÃÀ" });
            context.Countries.Add(new Country() { NameRu = "ÒĞÈÍÈÄÀÄ È ÒÎÁÀÃÎ" });
            context.Countries.Add(new Country() { NameRu = "ÒÓÂÀËÓ" });
            context.Countries.Add(new Country() { NameRu = "ÒÓÍÈÑ" });
            context.Countries.Add(new Country() { NameRu = "ÒÓĞÊÌÅÍÈß" });
            context.Countries.Add(new Country() { NameRu = "ÒÓĞÖÈß" });
            context.Countries.Add(new Country() { NameRu = "ÓÃÀÍÄÀ" });
            context.Countries.Add(new Country() { NameRu = "ÓÇÁÅÊÈÑÒÀÍ" });
            context.Countries.Add(new Country() { NameRu = "ÓÊĞÀÈÍÀ" });
            context.Countries.Add(new Country() { NameRu = "ÓÎËËÈÑ È ÔÓÒÓÍÀ" });
            context.Countries.Add(new Country() { NameRu = "ÓĞÓÃÂÀÉ" });
            context.Countries.Add(new Country() { NameRu = "ÔÀĞÅĞÑÊÈÅ ÎÑÒĞÎÂÀ" });
            context.Countries.Add(new Country() { NameRu = "ÔÈÄÆÈ" });
            context.Countries.Add(new Country() { NameRu = "ÔÈËÈÏÏÈÍÛ" });
            context.Countries.Add(new Country() { NameRu = "ÔÈÍËßÍÄÈß" });
            context.Countries.Add(new Country() { NameRu = "ÔÎËÊËÅÍÄÑÊÈÅ ÎÑÒĞÎÂÀ (ÌÀËÜÂÈÍÑÊÈÅ)" });
            context.Countries.Add(new Country() { NameRu = "ÔĞÀÍÖÈß" });
            context.Countries.Add(new Country() { NameRu = "ÔĞÀÍÖÓÇÑÊÀß ÃÂÈÀÍÀ" });
            context.Countries.Add(new Country() { NameRu = "ÔĞÀÍÖÓÇÑÊÀß ÏÎËÈÍÅÇÈß" });
            context.Countries.Add(new Country() { NameRu = "ÔĞÀÍÖÓÇÑÊÈÅ ŞÆÍÛÅ ÒÅĞĞÈÒÎĞÈÈ" });
            context.Countries.Add(new Country() { NameRu = "ÕÎĞÂÀÒÈß" });
            context.Countries.Add(new Country() { NameRu = "ÖÅÍÒĞÀËÜÍÎ - ÀÔĞÈÊÀÍÑÊÀß ĞÅÑÏÓÁËÈÊÀ" });
            context.Countries.Add(new Country() { NameRu = "×ÀÄ" });
            context.Countries.Add(new Country() { NameRu = "×ÅØÑÊÀß ĞÅÑÏÓÁËÈÊÀ" });
            context.Countries.Add(new Country() { NameRu = "×ÈËÈ" });
            context.Countries.Add(new Country() { NameRu = "ØÂÅÉÖÀĞÈß" });
            context.Countries.Add(new Country() { NameRu = "ØÂÅÖÈß" });
            context.Countries.Add(new Country() { NameRu = "ØÏÈÖÁÅĞÃÅÍ È ßÍ ÌÀÉÅÍ" });
            context.Countries.Add(new Country() { NameRu = "ØĞÈ - ËÀÍÊÀ" });
            context.Countries.Add(new Country() { NameRu = "İÊÂÀÄÎĞ" });
            context.Countries.Add(new Country() { NameRu = "İÊÂÀÒÎĞÈÀËÜÍÀß ÃÂÈÍÅß" });
            context.Countries.Add(new Country() { NameRu = "İĞÈÒĞÅß" });
            context.Countries.Add(new Country() { NameRu = "İÑÒÎÍÈß" });
            context.Countries.Add(new Country() { NameRu = "İÔÈÎÏÈß" });
            context.Countries.Add(new Country() { NameRu = "ŞÃÎÑËÀÂÈß" });
            context.Countries.Add(new Country() { NameRu = "ŞÆÍÀß ÀÔĞÈÊÀ" });
            context.Countries.Add(new Country() { NameRu = "ŞÆÍÀß ÄÆÎĞÄÆÈß È ŞÆÍÛÅ ÑÀÍÄÂÈ×ÅÂÛ ÎÑÒĞÎÂÀ" });
            context.Countries.Add(new Country() { NameRu = "ßÌÀÉÊÀ" });
            context.Countries.Add(new Country() { NameRu = "ßÏÎÍÈß" });
            #endregion

            #region ProviderType

            context.ProviderTypes.Add(new ProviderType() {NameRu = "Şğèäè÷åñêîå ëèöî", Enum = ProviderTypeEnum.LegalPerson});
            context.ProviderTypes.Add(new ProviderType() {NameRu = "Ôèçè÷åñêîå ëèöî", Enum = ProviderTypeEnum.PhysPerson});

            #endregion

            #region LegalForm

            context.LegalForms.Add(new LegalForm() { NameRu = "ÀÎ", Enum = LegalFormEnum.AO});
            context.LegalForms.Add(new LegalForm() { NameRu = "ÒÎÎ", Enum = LegalFormEnum.TOO });
            context.LegalForms.Add(new LegalForm() { NameRu = "ĞÃÏ", Enum = LegalFormEnum.RGP });
            context.LegalForms.Add(new LegalForm() { NameRu = "èíîå", Enum = LegalFormEnum.Other });

            #endregion

            #region CriteriaSetting

            context.CriteriaSettings.Add(new CriteriaSetting() { Name = "íàëè÷èå îïûòà ğàáîòû (ëåò)", Weight = 0.5 });
            context.CriteriaSettings.Add(new CriteriaSetting() { Name = "íàëè÷èå ñåğòèôèöèğîâàííîé ñèñòåìû ìåíåäæìåíòà êà÷åñòâà", Weight = 1 });
            context.CriteriaSettings.Add(new CriteriaSetting() { Name = "äîëÿ ìåñòíîãî ñîäåğæàíèÿ (%) ", Weight = 0.1 });
            context.CriteriaSettings.Add(new CriteriaSetting() { Name = "ó÷àñòíèê ÑİÇ «Ïàğê èííîâàöèîííûõ òåõíîëîãèé» ", Weight = 5 });

            #endregion
        }
    }
}