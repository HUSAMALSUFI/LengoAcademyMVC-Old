using LengoAcademy.Generic;
using LengoAcademy.Context;
using LengoAcademy.Domain;
using LengoAcademy.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LengoAcademy.SpecificReposoitory
{
    public class CategoryRepository : ICategoryRepository
    {
        public int Insert(CategoryDTO categoryDTO)
        {
            Generic<Category> generic = new Generic<Category>();
            var newCategory = new Category()
            {
                Name = categoryDTO.Name,
                IconPath = categoryDTO.IconPath,
                SubCategoryID = categoryDTO.SubCategoryID
            };
            return generic.Insert(newCategory);
        }
        public  List<CategoryDTO> LoadAll()
        {
            LengoAcademyContext context = new LengoAcademyContext();
            var categories = new List<CategoryDTO>();
            var allcategory =  context.categories.ToList();
            if (allcategory?.Any() == true)
            {
                foreach (var category in allcategory)
                {
                    categories.Add(new CategoryDTO()
                    {
                        Id = category.Id,
                        Name = category.Name,
                        IconPath = category.IconPath,
                        SubCategoryID = category.SubCategoryID
                    });
                }
            }
            return categories;
        }
        public CategoryDTO Load(int Id)
        {
            Generic<Category> generic = new Generic<Category>();
            var category = generic.Load(Id);
            if (category != null)
            {
                var categoryDetails = new CategoryDTO()
                {
                    Name = category.Name,
                    IconPath = category.IconPath,
                    SubCategoryID = category.SubCategoryID
                };
                return categoryDetails;
            }
            return null;
        }
        public void Update(CategoryDTO categoryDTO)
        {
            Generic<Category> generic = new Generic<Category>();
            var newCategory = new Category()
            {
                Id = categoryDTO.Id,
                Name = categoryDTO.Name,
                IconPath = categoryDTO.IconPath,
                SubCategoryID = categoryDTO.SubCategoryID
            };
            generic.Update(newCategory);
        }
        public void Delete(int Id)
        {Generic<Category> generic = new Generic<Category>();
            generic.Delete(Id);
        }
        public List<Category> MainCategory()
        {
            LengoAcademyContext context = new LengoAcademyContext();
            List<Category> category = context.categories.Where(p => p.SubCategoryID == null).ToList();
            foreach (Category item in category)
            {
                item.LiCourse = new List<Course>();
                List<Category> liSub= context.categories.Where(c => c.SubCategoryID == item.Id).ToList();
                foreach (Category liSubItem in liSub)
                {
                    item.LiCourse.AddRange( context.courses.Where(c => c.SubCategoriesID == liSubItem.Id).ToList());
                }

            }
            return category;
        }
        public List<Category> LoadSubCategoryByID(int Id)
        {
            LengoAcademyContext context = new LengoAcademyContext();
            List<Category> category = context.categories.Where(s => s.SubCategoryID == Id).ToList();
            return category;
        }
        public List<Category> SubCategory()
        {
            LengoAcademyContext context = new LengoAcademyContext();
            List<Category> category = context.categories.Where(s => s.SubCategoryID != null).ToList();
            return category;
        }

        public List<Category> SubCategory1(int Id)
        {
            LengoAcademyContext context = new LengoAcademyContext();
            Category x =context.categories.Where(c=>c.Id== Id).FirstOrDefault();
            List<Category> licategory = context.categories.Where(s => s.SubCategoryID == x.SubCategoryID).ToList();
            return licategory;
        }

        public List<Count_Courses> Count()
        {
            LengoAcademyContext context = new LengoAcademyContext();
            List<Count_Courses> li = context.categories.Select(data =>
            new Count_Courses()
            {
                category = data,
                Count = data.LiCourse.Count()
            }
            ).ToList();
            return li;
        }
    }
}
