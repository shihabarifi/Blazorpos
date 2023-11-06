using Microsoft.EntityFrameworkCore;
using pos.Data;
using pos.IRepository;
using pos.Models;

namespace pos.Repositories
{
    public class ProductRepo : IProduct<Product>
    {
        private readonly posDbContext _context;

        public ProductRepo(posDbContext context)
        {
           _context = context;
        }

        public void Add(Product entity)
        {
            _context.Products.Add(entity);
            _context.SaveChanges();
        }

        public string GetNewPRNumber()
        {
            string exnumber = "";

            var LastPoNumber = _context.Products.Max(cd => cd.Code);
            if (LastPoNumber == null)
                exnumber = "PR0001";
            else
            {
                int lastdigit = 1;
                int.TryParse(LastPoNumber.Substring(2, 4).ToString(), out lastdigit);


                exnumber = "PR" + (lastdigit + 1).ToString().PadLeft(4, '0');
            }



            return exnumber;
        }

        public void Delete(string code)
        {
            var mon = Find(code);
            _context.Products.Remove(mon);
            _context.SaveChanges();
        }

        public Product Find(string code)
        {
            var pro = _context.Products.FirstOrDefault(p => p.Code == code);
            return pro;
        }

      

        public IList<Product> List()
        {
           return _context.Products.OrderByDescending(d=>d.Code).Include(u=>u.Units).Include(c=>c.Categories).ToList();
        }

       

        public void Update(Product entity)
        {
            _context.Products.Update(entity);
            _context.SaveChanges();
        }

    
    }
}
