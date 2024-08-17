using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecomendaLivro.Shared.Data.DataBase
{

    public class DAL<T> where T : class
    {
        protected readonly DatabaseContext context;

        public DAL(DatabaseContext context)
        {
            this.context = context;
        }

        public IEnumerable<T> List()
        {
            return context.Set<T>().ToList();
        }
        public void Add(T objeto)
        {
            context.Set<T>().Add(objeto);
            context.SaveChanges();
        }
        public void Update(T objeto)
        {
            context.Set<T>().Update(objeto);
            context.SaveChanges();
        }
        public void Delete(T objeto)
        {
            context.Set<T>().Remove(objeto);
            context.SaveChanges();
        }

        public T? RecoverBy(Func<T, bool> condicao)
        {
            return context.Set<T>().FirstOrDefault(condicao);
        }

        public IEnumerable<T> ListBy(Func<T, bool> condicao)
        {
            return context.Set<T>().Where(condicao);
        }
    }
}
