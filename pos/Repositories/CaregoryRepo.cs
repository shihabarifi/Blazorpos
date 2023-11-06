using pos.Data;
using pos.IRepository;
using pos.Models;

namespace pos.Repositories
{
    public class CaregoryRepo : IRepository<Category>
    {
        private readonly posDbContext _context;

        public CaregoryRepo(posDbContext context)
        {
           _context = context;
        }

        public void Add(Category entity)
        {
            _context.Categories.Add(entity);
            _context.SaveChanges();
        }

     

        public void Delete(int id)
        {
            var cat = Find(id);
            _context.Categories.Remove(cat);
            _context.SaveChanges();
        }

        public Category Find(int id)
        {
            var unit = _context.Categories.FirstOrDefault(p => p.Id == id);
            return unit;
        }

      

        public IList<Category> List()
        {
           return _context.Categories.OrderByDescending(p=>p.Id).ToList();
        }

       

        public void Update(Category entity)
        {
            _context.Categories.Update(entity);
            _context.SaveChanges();
        }

    
    }
}
