using LengoAcademy.Domain;
using LengoAcademy.Entity;
using LengoAcademy.Models;
using LengoAcademy.SpecificReposoitory;
using System.Web.Mvc;

namespace LengoAcademy.Controllers
{
    public class ContactUsController : Controller
    {
        public ActionResult Contact_Us()
        {
           ContactRepository contactRepository = new ContactRepository();
           VmContact vm = new VmContact();
           vm.Contact= contactRepository.LoadAll();
           return View("Contact_Us", vm);
        }
    }
}
