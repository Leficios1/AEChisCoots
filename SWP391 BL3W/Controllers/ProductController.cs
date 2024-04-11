using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWP391_BL3W.DTO.Request;
using SWP391_BL3W.Services.Interface;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Net.Http.Json;

namespace SWP391_BL3W.Controllers
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

        [HttpPost("/create")]
        public async Task<IActionResult> create(CreateProductDTO dto)
        {
            var response = await _productService.create(dto);
            return StatusCode((int)response.statusCode, new { data = response.Data, message = response.Errormessge });
        }
    }
}
