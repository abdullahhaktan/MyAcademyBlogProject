using Blogy.DataAccess.Context;
using Blogy.DataAccess.Repositories.GenericRepositories;
using Blogy.Entity.Entities;

namespace Blogy.DataAccess.Repositories.ContactRepositories
{
    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {
        public ContactRepository(AppDbContext context) : base(context)
        {
        }
    }
}
