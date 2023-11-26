using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult FeatureList()
        {
            var features = _mapper.Map<List<ResultFeatureDto>>(_featureService.TGetListAll());
            return Ok(features);
        }
        [HttpGet("GetFeature")]
        public IActionResult GetFeature(int id)
        {
            var feature = _mapper.Map<GetFeatureDto>(_featureService.TGetById(id));
            return Ok(feature);
        }
        [HttpPost]
        public IActionResult CreateFeture(CreateFeatureDto createFeatureDto) 
        {
            _featureService.TAdd(_mapper.Map<Feature>(createFeatureDto));
            return Ok("Öne Çıkan Bilgisi Eklenmiştir");

        }
        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            _featureService.TUpdate(_mapper.Map<Feature>(updateFeatureDto));
            return Ok("Öne Çıkan Bilgisi Güncellenmiştir");
        }
        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            _featureService.TDelete(_featureService.TGetById(id));
            return Ok("Öne Çıkan Bilgisi Silinmiştir");
        }
    }
}
