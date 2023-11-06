using Microsoft.EntityFrameworkCore;
using pos.Data;
using pos.IRepository;
using pos.Models;
using POS.Models;

namespace pos.Repositories
{
    public class InvoiceRepo : IInvoice<Invoice>
    {
        private readonly posDbContext _context;

        public InvoiceRepo(posDbContext context)
        {
           _context = context;
        }

        public void Add(Invoice entity)
        {
            _context.Invoices.Add(entity);
            _context.SaveChanges();
        }

        public string GetNewINNumber()
        {
            string exnumber = "";

            var LastPoNumber = _context.Invoices.Max(cd => cd.InvoiceNo);
            if (LastPoNumber == null)
                exnumber = "IN001";
            else
            {
                int lastdigit = 1;
                int.TryParse(LastPoNumber.Substring(2, 3).ToString(), out lastdigit);


                exnumber = "IN" + (lastdigit + 1).ToString().PadLeft(3, '0');
            }



            return exnumber;
        }

        public void Delete(int id)
        {
            var inv = Find(id);
            _context.Invoices.Remove(inv);
            _context.SaveChanges();
        }

        public Invoice Find(int id)
        {
            Invoice item = _context.Invoices.Where(p => p.Id == id).Include(c=>c.Customer)
                .Include(p => p.Sales)
                .ThenInclude(i => i.Product)
                .ThenInclude(u => u.Units)
                     .FirstOrDefault();

            item.Sales.ForEach(i => i.UnitName = i.Product.Units.Name);
            item.Sales.ForEach(p => p.Description = p.Product.Description);
            item.Sales.ForEach(p => p.SubTotal = p.Quantity * p.Price);
            return item;
        }

      

        public IList<Invoice> List()
        {
           return _context.Invoices.Include(c => c.Customer).Include(s => s.Sales).ToList();
        }

       

        public void Update(Invoice entity)
        {
            _context.Invoices.Update(entity);
            _context.SaveChanges();
        }

    
    }
}
