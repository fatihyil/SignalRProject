using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var socialMedias = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetListAll());
            return Ok(socialMedias);
        }
        [HttpGet("GetSocialMedia")]
        public IActionResult GetSocialMedia(int id)
        {
            var socialMedia = _mapper.Map<GetSocialMediaDto>(_socialMediaService.TGetById(id));
            return Ok(socialMedia);
        }
        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            _socialMediaService.TAdd(_mapper.Map<SocialMedia>(createSocialMediaDto));
            return Ok("Sosyal Medya Bilgisi Eklendi");
        }
        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            _socialMediaService.TUpdate(_mapper.Map<SocialMedia>(updateSocialMediaDto));    
            return Ok("Sosyal Medya Bilgisi Güncellendi");
        }
        [HttpDelete]
        public IActionResult DeleteSocialMedia(int id)
        {
            _socialMediaService.TDelete(_socialMediaService.TGetById(id));
            return Ok("Sosyal Medya Bilgisi Silinmiştir");
        }
    }
}
