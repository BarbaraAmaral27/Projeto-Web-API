using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepositoriesEntity
{
    public static class Caderno
    {
        public static void save(Models.Caderno caderno)
        {
            using (Context context = new Context())
            {
                context.caderno.Add(caderno);
                context.SaveChanges();
            }
        }

        public static List<Models.Caderno> getAll()
        {
            using (Context context = new Context())
            {
                return context.caderno.ToList();
            }
        }

        public static void deleteById(int id)
        {
            using (Context context = new Context())
            {
                //context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
                Models.Caderno caderno = context.caderno.FirstOrDefault(c => c.Id == id);
                if (caderno != null)
                {
                    context.caderno.Remove(caderno);
                    context.SaveChanges();
                }                
            }
        }

        public static Models.Caderno getById(int id)
        {
           using (Context context = new Context())
           {
                //Models.Caderno caderno = context.caderno.FirstOrDefault(c => c.Id == id);
                //return (caderno != null ? caderno : new Models.Caderno());

                return context.caderno.FirstOrDefault(c => c.Id == id);
           }
        }

        public static List<Models.Caderno> getByTitulo(string titulo)
        {
            using (Context context = new Context())
            {
                return context.caderno.Where(c => c.Titulo.Contains(titulo)).ToList();
            }
        }

        public static void update(Models.Caderno caderno)
        {
            using (Context context = new Context())
            {
                //context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
                context.Entry(caderno).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}