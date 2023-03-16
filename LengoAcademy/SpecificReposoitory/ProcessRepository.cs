using LengoAcademy.Domain;
using LengoAcademy.Entity;
using LengoAcademy.Generic;
using LengoAcademy.Context;
using System.Collections.Generic;
using System.Linq;

namespace LengoAcademy.SpecificReposoitory
{
    public class ProcessRepository : IProcessRepository
    {
        public int Insert(ProcessDTO processDTO)
        {
            Generic<Process> generic = new Generic<Process>();
            var newProcess = new Process()
            {
                Title = processDTO.Title,
                Descrption = processDTO.Descrption,
                Course_ID = processDTO.Course_ID,
            };
            return generic.Insert(newProcess);
        }
        public List<ProcessDTO> LoadAll()
        {
            Generic<Process> generic = new Generic<Process>();
            var process = new List<ProcessDTO>();
            var allprocess = generic.LoadAll();
            if (allprocess?.Any() == true)
            {
                foreach (var process1 in allprocess)
                {
                    process.Add(new ProcessDTO()
                    {
                        Id = process1.Id,
                        Title = process1.Title,
                        Descrption = process1.Descrption,
                        Course_ID = process1.Course_ID
                    });
                }
            }
            return process;
        }
        public ProcessDTO Load(int Id)
        {
            Generic<Process> generic = new Generic<Process>();
            var process = generic.Load(Id);
            if (process != null)
            {
                var processDetails = new ProcessDTO()
                {
                    Id = process.Id,
                    Title = process.Title,
                    Descrption = process.Descrption,
                    Course_ID = process.Course_ID,
                };
                return processDetails;
            }
            return null;
        }

        /*
               public Process Load(int Id)
               {
                   return context.Process.Where(e => e.Course_ID == Id).FirstOrDefault();
               }*/
        public void Update(ProcessDTO processDTO)
        {
            Generic<Process> generic = new Generic<Process>();
            var newprocess = new Process()
            {
                Id = processDTO.Id,
                Title = processDTO.Title,
                Descrption = processDTO.Descrption,
                Course_ID = processDTO.Course_ID,
            };
            generic.Update(newprocess);
        }
        public void Delete(int Id)
        {
            Generic<Process> generic = new Generic<Process>();
            generic.Delete(Id);
        }

        public List<Process> LoadProcessByCourseID(int Id)
        {
            LengoAcademyContext context = new LengoAcademyContext();
            List<Process> processes = context.Process.Where(s => s.Course_ID == Id).ToList();
            return processes;
        }
    }
}
