using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.CompilerServices;
using task2.API.Security;
using task2.Core.DTO;
using task2.Core.Models;
using task2.Core.Services;
using TokenHandler = task2.API.Security.TokenHandler;

namespace task2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize("RequireToken")]
    public class Products : CustomBaseController
    {
        private readonly IMapper _mapper;
        //private readonly IService<Product> _service;
        private readonly IProductService _service;
        private readonly IConfiguration _configuration;

        public Products(IMapper mapper, IProductService productService, IConfiguration configuration)
        {
            _mapper = mapper;
            _service = productService;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            
            var products = await _service.GetAllAsync();
            var productsDto = _mapper.Map<List<ProductDto>>(products.ToList());
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productsDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            var productsDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productsDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var product = await _service.AddAsync(_mapper.Map<Product>(productDto));
            var productsDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, productsDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            await _service.UpdateAsync(_mapper.Map<Product>(productDto));
            
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(product);
            
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

    }
}
