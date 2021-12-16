﻿using Microsoft.EntityFrameworkCore;

namespace CadastroCliente.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DAL.ClienteContext Context;
        private readonly DbSet<T> Table;

        public Repository(DAL.ClienteContext context)
        {
           Context = context;
            Table = context.Set<T>();
        }

        public void Delete(T entity)
        {
            Table.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return Table.ToList();
        }

        public T GetbyId(object id)
        {
            return Table.Find(id);
        }

        public void Insert(T entity)
        {
            Table.Add(entity);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Update(T entity)
        {
            Table.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
