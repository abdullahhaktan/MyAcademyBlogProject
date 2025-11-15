using AutoMapper;
using Blogy.Business.DTOs.ContactDtos;
using Blogy.Business.DTOs.ContactDtos;
using Blogy.DataAccess.Repositories.ContactRepositories;
using Blogy.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Services.ContactServices
{
    public class ContactService(IContactRepository _contactRepository,IMapper _mapper) : IContactService
    {

        public async Task CreateAsync(CreateContactDto contactDto)
        {
            var contact = _mapper.Map<Contact>(contactDto);
            await _contactRepository.CreateAsync(contact);
        }

        public async Task DeleteAsync(int id)
        {
            await _contactRepository.DeleteAsync(id);
        }

        public async Task<List<ResultContactDto>> GetAllAsync()
        {
            var categories = await _contactRepository.GetAllAsync();
            return _mapper.Map<List<ResultContactDto>>(categories);
        }

        public async Task<UpdateContactDto> GetByIdAsync(int id)
        {
            var contact = await _contactRepository.GetByIdAsync(id);
            return _mapper.Map<UpdateContactDto>(contact);
        }

        public async Task UpdateAsync(UpdateContactDto updateContactDto)
        {
            var contact = _mapper.Map<Contact>(updateContactDto);
            await _contactRepository.UpdateAsync(contact);
        }
    }
}
