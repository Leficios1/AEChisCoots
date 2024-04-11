using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SWP391_BL3W.Database;
using SWP391_BL3W.DTO.Request;
using SWP391_BL3W.DTO.Response;
using SWP391_BL3W.Repository.Interface;
using SWP391_BL3W.Services.Interface;
using System.Net;

namespace SWP391_BL3W.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Products> _baseRepository;
        private readonly SWPContext _context;
        private readonly IBaseRepository<ProductsDetails> _category;

        public ProductService(IMapper mapper, IBaseRepository<Products> baseRepository, SWPContext context, IBaseRepository<ProductsDetails> category)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
            _context = context;
            _category = category;
        }

        public async Task<StatusResponse<CreateProductDTO>> create(CreateProductDTO dto)
        {
            var response = new StatusResponse<CreateProductDTO>();
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var existingProduct = await _baseRepository.FindOne(x => x.Name.ToUpper() == dto.Name.ToUpper());
                    if (existingProduct != null)
                    {
                        response.statusCode = HttpStatusCode.BadRequest;
                        response.Errormessge = "Sản phẩm đã tồn tại!";
                        return response;
                    }

                    var existingCategory = await _context.Categories.Where(x => x.CategoryID == dto.CategoryID).FirstOrDefaultAsync();
                    if (existingCategory == null)
                    {
                        response.statusCode = HttpStatusCode.BadRequest;
                        response.Errormessge = "Danh mục không tồn tại!";
                        return response;
                    }

                    var productEntity = _mapper.Map<Products>(dto);
                    productEntity.Category = existingCategory;

                    await _baseRepository.AddAsync(productEntity);
                    await _baseRepository.SaveChangesAsync();
                    response.Data = dto;
                    response.statusCode = HttpStatusCode.Created;
                    response.Errormessge = "Create Successful";
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    response.statusCode = HttpStatusCode.InternalServerError;
                    response.Errormessge = "Đã xảy ra lỗi khi tạo sản phẩm.";
                    return response;
                }
                transaction.Commit();
                return response;
            }
        }


        public Task<StatusResponse<Products>> getAll(int? size, int? page)
        {
            throw new NotImplementedException();
        }

        public Task<StatusResponse<Products>> getProductbyId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
