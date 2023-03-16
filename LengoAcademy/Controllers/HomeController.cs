using LengoAcademy.Models;
using LengoAcademy.SpecificReposoitory;
using System.Web.Mvc;

namespace LengoAcademy.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int Id)
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            CourseRepository courseRepository = new CourseRepository();
            SectiontRepository sectiontRepository = new SectiontRepository();
            VmHome vm = new VmHome();

            vm.LiCategory = categoryRepository.MainCategory();
            vm.LiCourse = courseRepository.LoadCourses();
/*            vm.Section = sectiontRepository.LoadSectionByCourseID(Id);
*/            return View("Index",vm);
        }
    }
}
