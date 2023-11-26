using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult TestimonialList() 
        {
            var testimonials = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll());
            return Ok(testimonials); 
        }
        [HttpGet("GetTestimonial")]
        public IActionResult GetTestimonial(int id) 
        {
            var testimonial = _testimonialService.TGetById(id);
            return Ok(testimonial);
        }
        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            _testimonialService.TAdd(_mapper.Map<Testimonial>(createTestimonialDto));
            return Ok("Müşteri Yorumu Eklenmiştir");
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            _testimonialService.TUpdate(_mapper.Map<Testimonial>(updateTestimonialDto));
            return Ok("Müşteri Yorumu Güncellenmiştir");
        }
        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            _testimonialService.TDelete(_testimonialService.TGetById(id));
            return Ok("Müşteri Yorum Bilgisi Silinmiştir");
        }
    }
}
