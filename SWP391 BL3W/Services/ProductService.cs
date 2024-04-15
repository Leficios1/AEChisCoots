using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SWP391_BL3W.Database;
using SWP391_BL3W.DTO.Request;
using SWP391_BL3W.DTO.Response;
using SWP391_BL3W.Repository.Interface;
using SWP391_BL3W.Services.Interface;
using System.Net;
using static System.Net.Mime.MediaTypeNames;

namespace SWP391_BL3W.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Product> _baseRepository;
        private readonly SWPContext _context;
        private readonly IBaseRepository<ProductsDetail> _category;
        private readonly IBaseRepository<Images> _image;

        public ProductService(IMapper mapper, IBaseRepository<Product> baseRepository, SWPContext context, IBaseRepository<ProductsDetail> category, IBaseRepository<Images> images)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
            _context = context;
            _category = category;
            _image = images;
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
                        response.Errormessge = "Product is exist!";
                        return response;
                    }

                    var existingCategory = await _context.Categories.Where(x => x.CategoryID == dto.CategoryID).FirstOrDefaultAsync();
                    if (existingCategory == null)
                    {
                        response.statusCode = HttpStatusCode.NotFound;
                        response.Errormessge = "Category Not Found";
                        return response;
                    }

                    var productEntity = _mapper.Map<Product>(dto);
                    productEntity.Category = existingCategory;
                    await _baseRepository.AddAsync(productEntity);
                    await _baseRepository.SaveChangesAsync();

                    foreach (var imageDTO in dto.ImageDTOs)
                    {
                        var image = new Images
                        {
                            Url = imageDTO.Url,
                            ProductId = productEntity.Id
                        };
                        await _image.AddAsync(image);
                    }
                    await _baseRepository.SaveChangesAsync();
                    response.Data = dto;
                    response.statusCode = HttpStatusCode.Created;
                    response.Errormessge = "Create Successful";
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    response.statusCode = HttpStatusCode.InternalServerError;
                    response.Errormessge = $"Error: {ex.Message}";
                    return response;
                }
                transaction.Commit();
                return response;
            }
        }

        public async Task<StatusResponse<ProductsResponseDTO>> getAll(int? size, int? page)
        {
            var response = new StatusResponse<ProductsResponseDTO>();
            try
            {
                int pageSize = size ?? 15;
                int pageNumber = page ?? 1;
                List<Product> allProducts = await _context.Products.ToListAsync();
                int totalItems = allProducts.Count;
                int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

                var productsForPage = allProducts
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new ProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    Quantity = p.quantity,
                    Price = p.price
                }).ToList();
                var responseDTO = new ProductsResponseDTO
                {
                    Products = productsForPage,
                    TotalPages = totalPages,
                    CurrentPage = pageNumber,
                    PageSize = pageSize,
                    TotalItems = totalItems
                };
                response.Data = responseDTO;
                response.statusCode = HttpStatusCode.OK;
                response.Errormessge = "Get all products with pagination successfully.";
            }
            catch (Exception ex)
            {
                response.statusCode = HttpStatusCode.InternalServerError;
                response.Errormessge = ex.Message;
                response.Data = null;
                return response;
            }
            return response;
        }

        public async Task<StatusResponse<ProductDetailsResponseDTO>> getProductDetailbyId(int id)
        {
            var response = new StatusResponse<ProductDetailsResponseDTO>();
            try
            {
                var product = await _context.Products
                    .Include(p => p.Details)
                    .Include(p => p.Images)
                    .Include(p => p.Reviews)
                    .FirstOrDefaultAsync(p => p.Id == id);

                if (product == null)
                {
                    response.statusCode = HttpStatusCode.NotFound;
                    response.Errormessge = "Product not found.";
                    return response;
                }
                var productDetailsResponseDTO = new ProductDetailsResponseDTO
                {
                    Products = new ProductDTOs
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        Quantity = product.quantity,
                        Price = product.price,
                        WarrantyPeriod = product.WarrantyPeriod,
                        CategoryID = product.CategoryID
                    },
                    Details = product.Details.Select(d => new ProductsDetailDTO
                    {
                        Id = d.Id,
                        Name = d.Name,
                        Value = d.Value
                    }).ToList(),
                    Images = product.Images.Select(i => new ImageDTOs
                    {
                        Id = i.Id,
                        Url = i.Url
                    }).ToList(),
                    Reviews = product.Reviews.Select(r => new ReviewDTO
                    {
                        Id = r.Id,
                        UserId = r.UserId,
                        Comment = r.Comment,
                        Rating = r.Rating
                    }).ToList()
                };

                response.Data = productDetailsResponseDTO;
                response.statusCode = HttpStatusCode.OK;
                response.Errormessge = "Successful";
            }
            catch (Exception ex)
            {
                response.statusCode = HttpStatusCode.BadRequest;
                response.Errormessge = ex.Message;
                response.Data = null;
            }

            return response;
        }

        public async Task<StatusResponse<ProductsResponseDTO>> search(int? page, int? size, string name, int? watt, int? volt, string? producer)
        {
            var response = new StatusResponse<ProductsResponseDTO>();
            try
            {
                int pageSize = size ?? 15;
                int pageNumber = page ?? 1;

                var query = _context.Products.AsQueryable();
                query = query.Where(p => p.Name.ToUpper().Contains(name));
                if (watt.HasValue)
                {
                    query = query.Where(p => p.Details.Any(d => d.Name.Equals("Watt") && d.Value == watt.ToString()));
                }
                if (volt.HasValue)
                {
                    query = query.Where(p => p.Details.Any(d => d.Name == "Volt" && d.Value == volt.ToString()));
                }
                if (!string.IsNullOrEmpty(producer))
                {
                    query = query.Where(p => p.Details.Any(d => d.Name == "Producer" && d.Value.Contains(producer)));
                }
                if (query == null)
                {
                    response.Data = null;
                    response.statusCode = HttpStatusCode.NotFound;
                    response.Errormessge = "Not found Product!";
                    return response;
                }
                var totalItems = await query.CountAsync();
                var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

                var products = await query.Skip((pageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToListAsync();

                var mappedProducts = _mapper.Map<IEnumerable<ProductDTO>>(products);

                response.Data = new ProductsResponseDTO
                {
                    Products = mappedProducts.ToList(),
                    TotalPages = totalPages,
                    CurrentPage = pageNumber,
                    PageSize = pageSize,
                    TotalItems = totalItems
                };
                response.statusCode = HttpStatusCode.OK;
                response.Errormessge = "Success";
            }
            catch (Exception ex)
            {
                response.statusCode = HttpStatusCode.InternalServerError;
                response.Errormessge = ex.Message;
            }
            return response;
        }

        public async Task<StatusResponse<UpdateProductsDTO>> updateProduct(UpdateProductsDTO dto)
        {
            var response = new StatusResponse<UpdateProductsDTO>();
            try
            {
                var existingProduct = await _context.Products.Where(x => x.Id == dto.Id).FirstOrDefaultAsync();
                if (existingProduct == null)
                {
                    response.statusCode = HttpStatusCode.NotFound;
                    response.Errormessge = "Not Found Products!!";
                    return response;
                }
                _mapper.Map(dto, existingProduct);
                await _context.SaveChangesAsync();
                response.Data = dto;
                response.statusCode = HttpStatusCode.OK;
                response.Errormessge = "Successful";
            }catch(Exception ex)
            {
                response.statusCode = HttpStatusCode.InternalServerError;
                response.Errormessge=ex.Message;
            }
            return response;
        }
    }
}
