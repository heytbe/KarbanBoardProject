using Core.API.Response;

namespace Service.API.Service.Abstract
{
    public interface ITicketService
    {
        Task<ResponseDto<Response>> DeleteAsync(bool trackChanges,Guid id);
    }
}
