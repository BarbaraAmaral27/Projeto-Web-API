using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepositoriesEntity
{
    public class Doce
    {
        public static void save(Models.Doce doce)
        {
            using (Context context = new Context())
            {
                context.doce.Add(doce);
                context.SaveChanges();
            }
        }

        public static List<Models.Doce> getAll()
        {
            using (Context context = new Context())
            {
                return context.doce.ToList();
            }
        }

        public static Models.Doce getById(int id)
        {
            using (Context context = new Context())
            {
                return context.doce.FirstOrDefault(d => d.Id == id);
            }
        }

        public static void deleteById(int id)
        {
            using (Context context = new Context())
            {
                //context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
                Models.Doce doce = context.doce.FirstOrDefault(d => d.Id == id);
                if (doce != null)
                {
                    context.doce.Remove(doce);
                    context.SaveChanges();
                }
            }
        }

        public static List<Models.Doce> getByDescricao(string descricao)
        {
            using (Context context = new Context())
            {
                return context.doce.Where(c => c.Descricao.Contains(descricao)).ToList();
            }
        }

        public static void update(Models.Doce doce)
        {
            using (Context context = new Context())
            {
                //context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
                context.Entry(doce).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}