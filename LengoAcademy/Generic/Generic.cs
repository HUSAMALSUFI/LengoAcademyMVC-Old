using LengoAcademy.Context;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace LengoAcademy.Generic
{
    public class Generic<T> : IGeneric<T> where T : class
    {
        public int Insert(T obj)
        {
            LengoAcademyContext context = new LengoAcademyContext();
            context.Set<T>().Add(obj);
            context.SaveChanges();
            var Id = obj.GetType().GetProperty("Id").GetValue(obj, null);
            return (int)Id;
        }

        public void Update(T Obj)
        {
            LengoAcademyContext context = new LengoAcademyContext();
            context.Set<T>().Attach(Obj);
            context.Entry(Obj).State = EntityState.Modified;
            context.SaveChanges();
        }

         public void Delete(int Id)
        {
            LengoAcademyContext context = new LengoAcademyContext();
            T Obj = context.Set<T>().Find(Id);
            context.Set<T>().Remove(Obj);
            context.SaveChanges();
        }

        public T Load(int Id)
        {
            LengoAcademyContext context = new LengoAcademyContext();
            return context.Set<T>().Find(Id);
        }

        public List<T> LoadAll()
        {
            LengoAcademyContext context = new LengoAcademyContext();
            return context.Set<T>().ToList();
        }

    }
}
