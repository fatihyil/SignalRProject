using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ContactList()
        {
            var contacts = _mapper.Map<List<ResultContactDto>>(_contactService.TGetListAll());
            return Ok(contacts);
        }
        [HttpPost]
        public IActionResult AddContact(CreateContactDto createContactDto)
        {
            Contact contact = new Contact()
            {
                FooterDescription = createContactDto.FooterDescription,
                Location = createContactDto.Location,
                Mail = createContactDto.Mail,
                Phone = createContactDto.Phone
            };
            _contactService.TAdd(contact);
            return Ok("İletişim Bilgisi Eklendi");
        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            Contact contact = new Contact()
            {
                ContactId = updateContactDto.ContactId,
                FooterDescription = updateContactDto.FooterDescription,
                Location = updateContactDto.Location,
                Mail = updateContactDto.Mail,
                Phone = updateContactDto.Phone
            };
            _contactService.TUpdate(contact);
            return Ok("İletişim Bilgisi Güncellendi");
        }
        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var contact = _mapper.Map<Contact>(_contactService.TGetById(id));
            _contactService.TDelete(contact);
            return Ok("İletişim Bilgisi Silinmiştir");
        }
        [HttpGet("GetContact")]
        public IActionResult GetContact(int id) 
        {
            var contact = _contactService.TGetById(id);
            return Ok(contact);
        }


    }
}
