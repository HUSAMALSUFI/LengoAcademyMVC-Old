using LengoAcademy.Domain;
using LengoAcademy.Entity;
using LengoAcademy.Generic;
using System.Collections.Generic;
using System.Linq;

namespace LengoAcademy.SpecificReposoitory
{
    public class PlanRepository : IPlanRepository
    {
        public int Insert(PlanDTO planDTO)
        {
            Generic<Plan> generic = new Generic<Plan>();
            var newPlan = new Plan()
            {
                Name = planDTO.Name,
            };
            return generic.Insert(newPlan);
        }
        public List<PlanDTO> LoadAll()
        {
            Generic<Plan> generic = new Generic<Plan>();
            var Plans = new List<PlanDTO>();
            var allPlans =  generic.LoadAll();
            if (allPlans?.Any() == true)
            {
                foreach (var Plan in allPlans)
                {
                    Plans.Add(new PlanDTO()
                    {
                        Id = Plan.Id,
                        Name = Plan.Name,
                    });
                }
            }
            return Plans;
        }
        public PlanDTO Load(int Id)
        {
            Generic<Plan> generic = new Generic<Plan>();
            var Plans =  generic.Load(Id);
            if (Plans != null)
            {
                var plansDetails = new PlanDTO()
                {
                    Name = Plans.Name,
                };
                return plansDetails;
            }
            return null;
        }
        public void Update(PlanDTO planDTO)
        {
            Generic<Plan> generic = new Generic<Plan>();
            var newPlans = new Plan()
            {
                Id = planDTO.Id,
                Name = planDTO.Name,
            };
             generic.Update(newPlans);
        }
        public void Delete(int Id)
        {
            Generic<Plan> generic = new Generic<Plan>();
            generic.Delete(Id);
        }
    }
}