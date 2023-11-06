using pos.Data;
using pos.IRepository;
using pos.Models;

namespace pos.Repositories
{
    public class UnitRepo : IRepository<Unit>
    {
        private readonly posDbContext _context;

        public UnitRepo(posDbContext context)
        {
           _context = context;
        }

        public void Add(Unit entity)
        {
            _context.Units.Add(entity);
            _context.SaveChanges();
        }

      

        public void Delete(int id)
        {
            Unit unit = Find(id);
            _context.Units.Remove(unit);
            _context.SaveChanges();
        }

        public Unit Find(int id)
        {
            var unit = _context.Units.FirstOrDefault(p => p.Id == id);
            return unit;
        }

        public Unit Find(string code)
        {
            throw new NotImplementedException();
        }

        public IList<Unit> List()
        {
           return _context.Units.OrderByDescending(p => p.Id).ToList();
        }

       

        public void Update(Unit entity)
        {
            _context.Units.Update(entity);
            _context.SaveChanges();
        }

      

       
    }
}
