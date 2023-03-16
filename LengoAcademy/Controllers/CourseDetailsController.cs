using LengoAcademy.Models;
using LengoAcademy.SpecificReposoitory;
using System.Web.Mvc;

namespace LengoAcademy.Controllers
{
    public class CourseDetailsController : Controller
    {
        public ActionResult Course_Details(int Id)
        {

            CourseRepository courseRepository = new CourseRepository();
            SectiontRepository sectiontRepository = new SectiontRepository();
            TopicsRepository topicsRepository = new TopicsRepository();
            ProcessRepository processRepository = new ProcessRepository();
            VmCourse_Details vm = new VmCourse_Details();

            vm.course = courseRepository.Load(Id);
            vm.liMainTopics = topicsRepository.MainTopics1(Id);
            vm.liSubTopics = topicsRepository.LoadTopicsByCourseID(Id);
            vm.LiSection =  sectiontRepository.LoadSectionByCourseID(Id);
            vm.LiProcess= processRepository.LoadProcessByCourseID(Id);
            vm.licourses = courseRepository.LoadPlan_ItemByCourse_ID(Id);
            vm.section = courseRepository.LoadCourseSectionByCourseId(Id);
            return View("Course_Details", vm);
        }
    }
}
