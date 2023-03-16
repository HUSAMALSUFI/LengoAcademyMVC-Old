using LengoAcademy.Generic;
using LengoAcademy.Domain;
using LengoAcademy.Entity;
using System.Collections.Generic;
using System.Linq;


namespace LengoAcademy.SpecificReposoitory

{
    public class Course_ScheduleRepository : ICourse_ScheduleRepository
    {
        public int Insert(Course_ScheduleDTO course_ScheduleDTO)
        {
            Generic<Course_Schedule> generic = new Generic<Course_Schedule>();
            var newCourse_Schedule = new Course_Schedule()
            {
                Day = course_ScheduleDTO.Day,
                Section_ID = course_ScheduleDTO.Section_ID,

            };
            return generic.Insert(newCourse_Schedule);
        }
        public List<Course_ScheduleDTO> LoadAll()
        {
            Generic<Course_Schedule> generic = new Generic<Course_Schedule>();
            var course_Schedule = new List<Course_ScheduleDTO>();
            var allcourse_Schedule = generic.LoadAll();
            if (allcourse_Schedule?.Any() == true)
            {
                foreach (var course_Schedule1 in allcourse_Schedule)
                {
                    course_Schedule.Add(new Course_ScheduleDTO()
                    {
                        Id = course_Schedule1.Id,
                        Day = course_Schedule1.Day,
                        Section_ID = course_Schedule1.Section_ID,
                    });
                }
            }
            return course_Schedule;
        }
        public Course_ScheduleDTO Load(int Id)
        {
            Generic<Course_Schedule> generic = new Generic<Course_Schedule>();
            var course_Schedule =  generic.Load(Id);
            if (course_Schedule != null)
            {
                var course_ScheduleDetails = new Course_ScheduleDTO()
                {
                    Id = course_Schedule.Id,
                    Day = course_Schedule.Day,
                    Section_ID = course_Schedule.Section_ID,
                };
                return course_ScheduleDetails;
            }
            return null;
        }
        public void Update(Course_ScheduleDTO course_ScheduleDTO)
        {
            Generic<Course_Schedule> generic = new Generic<Course_Schedule>();
            var newcourse_Schedule = new Course_Schedule()
            {
                Id = course_ScheduleDTO.Id,
                Day = course_ScheduleDTO.Day,
                Section_ID = course_ScheduleDTO.Section_ID,
            };
             generic.Update(newcourse_Schedule);
        }
        public void Delete(int Id)
        {
            Generic<Course_Schedule> generic = new Generic<Course_Schedule>();
            generic.Delete(Id);
        }
    }
}
