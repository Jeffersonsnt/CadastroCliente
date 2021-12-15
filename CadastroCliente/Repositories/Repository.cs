namespace CadastroCliente.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DAL.ClienteContext Context;

        public Repository(DAL.ClienteContext context)
        {
           Context = context;
        }

        public void Delete(T entity)
        {
            Context.Clientes.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetbyId(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
