using LengoAcademy.Domain;
using LengoAcademy.Entity;
using LengoAcademy.Models;
using LengoAcademy.SpecificReposoitory;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LengoAcademy.Controllers
{
    public class RegisterEnrollController : Controller
    {
        public ActionResult Enroll()
        {
            CourseRepository courseRepository = new CourseRepository();
            VmEnroll vm = new VmEnroll();
            vm.LiCourse = courseRepository.LoadAll();
            return View("Enroll", vm);
        }
        public ActionResult FillSections(int Id)
        {
            SectiontRepository sectiontRepository = new SectiontRepository();
            List<Section>  li = sectiontRepository.LoadSectionByCourseID(Id);
            foreach (Section item in li)
            {
                item.StartDate.ToShortDateString();
            }
            return Json(li);
        }

        public ActionResult Save(VmEnroll signUp)
        {
            CourseRepository courseRepository = new CourseRepository();
         /*   AccountRepository accountRepository = new AccountRepository();
            List<IdentityRole> liRole = accountRepository.GetRoles();*/

/*            signUp.liRoles = liRole;
*/            signUp.LiCourse = courseRepository.LoadAll();
/*            var result =  accountRepository.CreateUser(signUp.signUpDTO);
*/            signUp.signUpDTO = new SignUpDTO();
            return View("DoneEnroll", signUp);
        }
    }
}
