using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ProductList()
        {
            var products = _mapper.Map<List<GetProductDto>>(_productService.TGetListAll());
            return Ok(products);
        }
        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var product = _mapper.Map<ResultProductDto>(_productService.TGetById(id));
            return Ok(product);
        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            var product = _mapper.Map<Product>(createProductDto);
            _productService.TAdd(product);
            return Ok("Ürün Eklenmiştir");
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto) 
        {
            var product = _mapper.Map<Product>(updateProductDto);
            _productService.TUpdate(product);
            return Ok("Ürün Bilgisi Güncellenmiştir"); 
        }
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            _productService.TDelete(_productService.TGetById(id));
            return Ok("Ürün Silinmiştir");
        }



    }
}
