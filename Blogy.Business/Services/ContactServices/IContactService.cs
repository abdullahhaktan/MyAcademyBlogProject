using Blogy.Business.DTOs.ContactDtos;

namespace Blogy.Business.Services.ContactServices
{
    public interface IContactService : IGenericService<ResultContactDto, UpdateContactDto, CreateContactDto>
    {
    }
}
