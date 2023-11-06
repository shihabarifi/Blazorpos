
using Microsoft.EntityFrameworkCore;
using pos.Data;
using pos.Models;



namespace pos.Repositories
{
    public class PersonRepository:IPersonRepository
    {

        private readonly posDbContext _appDbContext;

        public PersonRepository(posDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Person> AddPerson(Person person)
        {
            var result = await _appDbContext.People.AddAsync(person);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Person?> DeletePerson(int personId)
        {
            var result = await _appDbContext.People.FirstOrDefaultAsync(p => p.PersonId==personId);
            if (result!=null)
            {
                _appDbContext.People.Remove(result);
                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Person not found");
            }
            return result;
        }

        public async Task<Person?> GetPerson(int personId)
        {
            var result = await _appDbContext.People
                .Include(p => p.Addresses)
                .FirstOrDefaultAsync(p => p.PersonId==personId);
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new KeyNotFoundException("Person not found");
            }
        }

        public IList<Person> GetPeople(string? name)
        {
          
            
            if (name != null)
            {
                return _appDbContext.People.ToList();
            }
            else
            {
                return _appDbContext.People.ToList();
            }
        }

        public async Task<Person?> UpdatePerson(Person person)
        {
            var result = await _appDbContext.People.Include("Addresses").FirstOrDefaultAsync(p => p.PersonId==person.PersonId);
            if (result!=null)
            {
                // Update existing person
                _appDbContext.Entry(result).CurrentValues.SetValues(person);
                
                // Remove deleted addresses
                foreach (var existingAddress in result.Addresses.ToList())
                {
                   if(!person.Addresses.Any(o => o.AddressId == existingAddress.AddressId))
                     _appDbContext.Addresses.Remove(existingAddress);
                }

                // Update and Insert Addresses
                 foreach (var addressModel in person.Addresses)
                 {
                    var existingAddress = result.Addresses
                        .Where(a => a.AddressId == addressModel.AddressId)
                        .SingleOrDefault();
                    if (existingAddress != null)
                        _appDbContext.Entry(existingAddress).CurrentValues.SetValues(addressModel);
                    else
                    {
                        var newAddress = new Address
                        {
                            AddressId = addressModel.AddressId,
                            Street = addressModel.Street,
                            City = addressModel.City,
                            State = addressModel.State,
                            ZipCode = addressModel.ZipCode
                        };
                        result.Addresses.Add(newAddress);
                    }
                }
                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Person not found");
            }
            return result;
        }
    }
}