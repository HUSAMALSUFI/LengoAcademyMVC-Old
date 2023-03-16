/*using DareAcademy_DataAccess.Application;
using LengoAcademy.Domain;
using LengoAcademy.Entity;
using LengoAcademy.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;

namespace LengoAcademy.SpecificReposoitory
{
    public class AccountRepository: IAccountRepository
    {
        public IdentityResult CreateUser(SignUpDTO signUp)
        {
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>();
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>();

            var newUser = new ApplicationUser()
            {
                FName = signUp.FName,
                LName=signUp.LName,
                Email = signUp.Email,
                PhoneNo = signUp.PhoneNo,
                Course_ID= signUp.Course_ID,
                Section_ID=signUp.Section_ID,
                UserName=signUp.Email
            };
            var result =  userManager.Create(newUser);
            var student = "7f7849ae-3d4b-46cf-a2ee-a334907268b3";
            if (result.Succeeded)
            {
                var role =  roleManager.FindById(student);
                result =  userManager.AddToRole(newUser.ToString(), role.Name);
            }
            return result;
        }

        public IdentityResult NewRole(RoleDTO roleModel)
        {
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>();
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>();

            var newRole = new IdentityRole()
            {
                Name = roleModel.Name
            };

            var result =  roleManager.Create(newRole);
            return result;
        }
        public List<IdentityRole> GetRoles()
        {
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>();
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>();

            List<IdentityRole> liRole = roleManager.Roles.ToList();
            return liRole;
        }
       
    }
}
*/