using Core.API.Response;
using Data.API.Dal.TaskListDal.Abstract;
using Data.API.UnitOfWork;
using Service.API.Service.Abstract;

namespace Service.API.Service.Concrate
{
    public class AdditionService : IAdditionService
    {
        private readonly ITaskCardAdditionDal _taskCard;
        private readonly IUnitOfWorkRepo _unitOfWork;

        public AdditionService(ITaskCardAdditionDal taskCard, IUnitOfWorkRepo unitOfWork)
        {
            _taskCard = taskCard;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDto<Response>> DeleteAsync(bool trackChanges, Guid id)
        {
            var result = await _taskCard.GetOne(trackChanges, x => (x.IsDeleted.Equals(false) && x.Id.Equals(id)));
            if (result is null)
                return ResponseDto<Response>.Fail("Dosya Bulunamadı", 404, true);

            if (File.Exists(Path.GetFullPath("wwwRoot") + result.Path))
            {
                File.Delete(Path.GetFullPath("wwwRoot") + result.Path);
            }

            _taskCard.Remove(result);
            await _unitOfWork.SaveAsync();
            return ResponseDto<Response>.Success("Dosya Silidi", 200);
        }
    }
}
