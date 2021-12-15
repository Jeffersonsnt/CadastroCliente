namespace CadastroCliente.Repositories
{
    public interface IRepository<T> where T : class
    {
        T GetbyId(object id);
        IEnumerable<T> GetAll();
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
