

using pos.Models;

namespace pos.Repositories
{
    public interface IPersonRepository
    {
        IList<Person> GetPeople(string? name);
        Task<Person?> GetPerson(int personId);
        Task<Person> AddPerson(Person person);
        Task<Person?> UpdatePerson(Person person);
        Task<Person?> DeletePerson(int personId);
    }
}