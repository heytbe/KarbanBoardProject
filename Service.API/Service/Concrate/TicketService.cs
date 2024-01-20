using Core.API.Response;
using Data.API.Dal.TaskListDal.Abstract;
using Data.API.UnitOfWork;
using Service.API.Service.Abstract;

namespace Service.API.Service.Concrate
{
    public class TicketService : ITicketService
    {
        private readonly ITaskListCardTicketDal _ticketDal;
        private readonly IUnitOfWorkRepo _unitOfWork;

        public TicketService(ITaskListCardTicketDal ticketDal, IUnitOfWorkRepo unitOfWork)
        {
            _ticketDal = ticketDal;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDto<Response>> DeleteAsync(bool trackChanges, Guid id)
        {
            var result = await _ticketDal.GetOne(trackChanges, x => (x.IsDeleted.Equals(false) && x.Id.Equals(id)));
            if (result is null)
                return ResponseDto<Response>.Fail("Etiket Bulunamadı", 404, true);

            _ticketDal.Remove(result);
            await _unitOfWork.SaveAsync();
            return ResponseDto<Response>.Success("Etiket Silindi", 200);
        }
    }
}
