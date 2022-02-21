using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepositoriesEntity
{
    public class Gibi
    {
        public static void save(Models.Gibi gibi)
        {
            using (Context context = new Context())
            {
                context.gibi.Add(gibi);
                context.SaveChanges();
            }
        }

        public static List<Models.Gibi> getAll()
        {
            using (Context context = new Context())
            {
                return context.gibi.ToList();
            }
        }

        public static Models.Gibi getById(int id)
        {
            using (Context context = new Context())
            {
                return context.gibi.FirstOrDefault(g => g.Id == id);
            }
        }

        public static void deleteById(int id)
        {
            using (Context context = new Context())
            {
                Models.Gibi gibi = context.gibi.FirstOrDefault(g => g.Id == id);
                if (gibi != null)
                {
                    context.gibi.Remove(gibi);
                    context.SaveChanges();
                }
            }
        }

        public static List<Models.Gibi> getByTitulo(string titulo)
        {
            using (Context context = new Context())
            {
                return context.gibi.Where(c => c.Titulo.Contains(titulo)).ToList();
            }
        }

        public static void update(Models.Gibi gibi)
        {
            using (Context context = new Context())
            {
                context.Entry(gibi).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
