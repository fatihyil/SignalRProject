using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            //var categories = _categoryService.TGetListAll();
            //return Ok(categories);
            var values = _mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            Category category = new Category()
            {
                CategoryName = createCategoryDto.CategoryName,
                Status = true
            };
            _categoryService.TAdd(category);
            return Ok("Kategori Bilgisi Eklenmiştir");

        }
        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            Category category = new Category()
            {
                CategoryId = updateCategoryDto.CategoryId,
                Status = updateCategoryDto.Status,
                CategoryName = updateCategoryDto.CategoryName
            };            
            _categoryService.TUpdate(category);
            return Ok("Kategori Güncellenmiştir");
        }
        [HttpGet("GetCategory")]
        public IActionResult GetCategoryById(int id)
        {
            var category  = _categoryService.TGetById(id);
            return Ok(category);
        }
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var category = _categoryService.TGetById(id);
            _categoryService.TDelete(category);
            return Ok("Kategori Silinmiştir");
        }




    }
}
