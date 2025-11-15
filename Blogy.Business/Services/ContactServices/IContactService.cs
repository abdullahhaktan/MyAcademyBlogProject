using Blogy.Business.DTOs.ContactDtos;
using Blogy.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Services.ContactServices
{
    public interface IContactService : IGenericService<ResultContactDto,UpdateContactDto,CreateContactDto>
    {
    }
}
