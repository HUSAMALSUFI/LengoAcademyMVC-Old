using LengoAcademy.Domain;
using LengoAcademy.Entity;
using LengoAcademy.Generic;
using LengoAcademy.Context;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LengoAcademy.SpecificReposoitory
{
    public class Plan_ItemRepository : IPlan_ItemRepositorycs
    {
        public int Insert(Plan_ItemDTO plan_ItemDTO)
        {
            LengoAcademyContext context = new LengoAcademyContext();
            var newPlan = new Plan_Item()
            {
                Course_ID = plan_ItemDTO.Course_ID,
                Plan_ID = plan_ItemDTO.Plan_ID,
            };
            context.plan_Item.Add(newPlan);
            return  context.SaveChanges();
        }
        public List<Plan_ItemDTO> LoadAll()
        {
            LengoAcademyContext context = new LengoAcademyContext();
            var Plans = new List<Plan_ItemDTO>();
            var allPlans =  context.plan_Item.ToList();
            if (allPlans?.Any() == true)
            {
                foreach (var Plan in allPlans)
                {
                    Plans.Add(new Plan_ItemDTO()
                    {
                        Course_ID = Plan.Course_ID,
                        Plan_ID = Plan.Plan_ID,
                    });
                }
            }
            return Plans;
        }
        public void Delete(int Id)
        {
            LengoAcademyContext context = new LengoAcademyContext();
            Plan_Item obj =  context.plan_Item.Find(Id);
            context.plan_Item.Remove(obj);
             context.SaveChanges();
        }
        public void Update(Plan_ItemDTO plan_ItemDTO)
        {
            LengoAcademyContext context = new LengoAcademyContext();
            var newPlans = new Plan_Item()
            {
                Course_ID = plan_ItemDTO.Course_ID,
                Plan_ID = plan_ItemDTO.Plan_ID,
            };
            context.plan_Item.Attach(newPlans);
            context.Entry(newPlans).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
