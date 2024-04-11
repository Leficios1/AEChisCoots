using SWP391_BL3W.Database;
using SWP391_BL3W.DTO.Request;
using SWP391_BL3W.DTO.Response;

namespace SWP391_BL3W.Services.Interface
{
    public interface IProductService
    {
        public Task<StatusResponse<CreateProductDTO>> create(CreateProductDTO dto);
        public Task<StatusResponse<Products>> getAll(int? size, int? page);
        public Task<StatusResponse<Products>> getProductbyId(int id);
    }
}
