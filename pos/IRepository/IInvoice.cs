using pos.Models;

namespace pos.IRepository
{
    public interface IInvoice<TEntity>
    {
        IList<TEntity> List();
        TEntity Find(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        public string GetNewINNumber();

    }
}
