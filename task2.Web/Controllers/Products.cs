using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using task2.Core.DTO;
using task2.Core.Models;
using task2.Core.Services;
using task2.Service.Services;
using task2.Web.Models;

namespace task2.Web.Controllers
{
    public class Products : Controller
    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;


        public Products(IProductService service, IMapper mapper, IWebHostEnvironment hostEnvironment)
        {
            _service = service;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync());
        }
        public async Task<IActionResult> Add(ProductDto productDto)
        {



            if (productDto.ImageP.FileName.Length > 0)
            {
                //var uploadsFolder = Path.Combine(env.ContentRootPath, "wwwroot", "images");
                var uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + productDto.ImageP.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await productDto.ImageP.CopyToAsync(fileStream);
                }
                productDto.Picture = "/Images/" + uniqueFileName;


            }
            productDto.CreatedDate = DateTime.Now;
            await _service.AddAsync(_mapper.Map<Product>(productDto));
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            
            var product = await _service.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }
            await _service.RemoveAsync(product);

            return RedirectToAction(nameof(Index));
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            
            var product = await _service.GetByIdAsync(id);

            if (product == null)
            {
                
                return null;
            }

            
            var productDto = _mapper.Map<ProductDto>(product);

            return productDto;
        }

        public async Task<IActionResult> UpdateProduct(ProductDto productDto)
        {


            if (ModelState.IsValid)
            {
                
                var existingProduct = await _service.GetByIdAsync(productDto.Id);

                if (existingProduct != null)
                {
                    
                    if (productDto.ImageP != null && productDto.ImageP.FileName.Length > 0)
                    {
                        
                        if (!string.IsNullOrEmpty(existingProduct.Picture))
                        {
                            var existingFilePath = Path.Combine(_hostEnvironment.WebRootPath, existingProduct.Picture.TrimStart('/'));

                            
                            if (System.IO.File.Exists(existingFilePath))
                            {
                                System.IO.File.Delete(existingFilePath);
                            }
                        }

                        var uniqueFileName = Guid.NewGuid().ToString() + "_" + productDto.ImageP.FileName;
                        var filePath = Path.Combine(_hostEnvironment.WebRootPath, "Images", uniqueFileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await productDto.ImageP.CopyToAsync(fileStream);
                        }
                        
                        existingProduct.Picture = "/Images/" + uniqueFileName;
                    }

                    
                    existingProduct.Name = productDto.Name;
                    existingProduct.Code = productDto.Code;
                    existingProduct.Price = productDto.Price;
                    existingProduct.CreatedDate = DateTime.Now; 

                    
                    await _service.UpdateAsync(existingProduct);

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // Ürün bulunamadı
                    ModelState.AddModelError("", "Ürün bulunamadı.");
                    return View(productDto);
                }
            }


            return View(productDto);
        }
    }
}
