namespace CEROK_STAJ_WEB.DAL.Interfaces
{
    public interface IRepository<T> 
    {
        public List<T> GetAll();
        public T Get(int id);
        public void Add(T entity);
        
        public void Delete(T entity);
        public void Update(int id, T entity);
    }
}
