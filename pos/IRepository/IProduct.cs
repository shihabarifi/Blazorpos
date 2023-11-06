using pos.Models;

namespace pos.IRepository
{
    public interface IProduct<TEntity>
    {
        IList<TEntity> List();
        TEntity Find(string code);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(string code);
        public string GetNewPRNumber();
    }
}
