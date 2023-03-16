using LengoAcademy.Models;
using LengoAcademy.SpecificReposoitory;
using System;
using System.Web.Mvc;

namespace LengoAcademy.Controllers
{
    public class CoursesController : Controller
    {
        public ActionResult NewCourses(int Id)
        {

            CategoryRepository categoryRepository = new CategoryRepository();
            CourseRepository courseRepository = new CourseRepository();
            VmCourses vm = new VmCourses();

            vm.MainLiCategory = categoryRepository.MainCategory();
            vm.LiSubCategoryById = categoryRepository.SubCategory1(Id);
            vm.LiCourse = courseRepository.LoadCoursesBySubCategoriesID(Id);
            return View("NewCourses", vm);
        }
        public ActionResult AllCourses(int Id)
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            CourseRepository courseRepository = new CourseRepository();
            int MainId = 0;
            if (Id>0)
            {
                MainId= Id;
                TempData["MainCatId"] = Id;
            }
            else
            {
                 MainId = Convert.ToInt32(TempData["MainCatId"]);
                TempData.Keep("MainCatId");
            }
            VmCourses vm = new VmCourses();
            vm.MainLiCategory = categoryRepository.MainCategory();
            vm.LiSubCategoryById = categoryRepository.LoadSubCategoryByID(MainId);
            vm.LiCourse = courseRepository.LoadAllByMainCategoryID(MainId);
            

            return View("NewCourses", vm);
        }

        public ActionResult LoadAllByDefaultCategory()
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            CourseRepository courseRepository = new CourseRepository();
            VmCourses vm = new VmCourses();

            vm.MainLiCategory = categoryRepository.MainCategory();
            vm.LiSubCategoryById = categoryRepository.LoadSubCategoryByID(vm.MainLiCategory[0].Id);
            vm.LiCourse = courseRepository.LoadAllByMainCategoryID(vm.MainLiCategory[0].Id);
            TempData["MainCatId"] = vm.MainLiCategory[0].Id;

            return View("NewCourses", vm);
        }
    }
}
