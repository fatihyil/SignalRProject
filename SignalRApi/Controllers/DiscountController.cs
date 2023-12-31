﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult DiscountList()
        {
            var discounts = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
            return Ok(discounts);
        }
        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            var discount =_mapper.Map<Discount>(createDiscountDto);
            _discountService.TAdd(discount);
            return Ok("İndirim Eklendi");
        }
        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            var discount = _mapper.Map<Discount>(updateDiscountDto);
            _discountService.TUpdate(discount);
            return Ok("İndirim Bilgisi Güncellenmiştir");
        }
        [HttpDelete]
        public IActionResult DeleteDiscount(int id)
        {
            Discount discount = _discountService.TGetById(id);
            _discountService.TDelete(discount);
            return Ok("İndirim Bilgisi Silinmiştir");
        }
        [HttpGet("GetDiscount")]
        public IActionResult GetDiscount(int id)
        {
            var discount = _discountService.TGetById(id);
            return Ok(discount);
        }


    }
}
