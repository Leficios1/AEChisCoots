
using AutoMapper;
using SWP391_BL3W.Database;
using SWP391_BL3W.DTO.Request;
using SWP391_BL3W.DTO.Response;
using SWP391_BL3W.Repository.Interface;
using SWP391_BL3W.Services.Interface;
using System.Net;

namespace SWP391_BL3W.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Order> _baseRepository;
        private readonly SWPContext _context;

        public OrderService(IMapper mapper, IBaseRepository<Order> baseRepository, SWPContext context)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
            _context = context;
        }

        public Task<StatusResponse<OrderResponseDTO>> create(OrderResquestDTO dto)
        {
            var response = new StatusResponse<OrderResponseDTO>();
            try
            {

            }catch (Exception ex)
            {
                response.statusCode = HttpStatusCode.InternalServerError;
                response.Errormessge = ex.Message;
                response.Data = null;
                return response;
            }
            return response;
        }

        public Task<StatusResponse<OrderResponseDTO>> getAllOrderAsync(int? page, int? size)
        {
            throw new NotImplementedException();
        }

        public Task<StatusResponse<OrderResponseDTO>> getOrderbyUserId(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
