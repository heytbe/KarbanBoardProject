using AutoMapper;
using Core.API.Response;
using Data.API.Dal.TaskListDal.Abstract;
using Data.API.UnitOfWork;
using Entity.API.Models.Dto.KarbonDto.ListDto;
using Microsoft.EntityFrameworkCore;
using Service.API.Service.Abstract;

namespace Service.API.Service.Concrate
{
    public class TaskListService : ITaskListService
    {
        private readonly ITaskListDal _taskListDal;
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkRepo _unitOfWork;

        public TaskListService(ITaskListDal taskListDal, IMapper mapper, IUnitOfWorkRepo unitOfWork)
        {
            _taskListDal = taskListDal;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDto<IEnumerable<BoardListsListDto>>> GetAllTaskListByBoardAsync(bool trackChanges, Guid id)
        {
            var result = await _taskListDal.GetAllThenInclude(trackChanges, x => x.Include(x => x.ListCards).ThenInclude(x => (x.ListAdditions))
            .Include(x => x.ListCards).ThenInclude(x => x.ListTickets), x => (x.IsDeleted.Equals(false) && x.BoardId.Equals(id))).ToListAsync();

            if (result is null)
                ResponseDto<IEnumerable<BoardListsListDto>>.Fail($"{id} 'li kayıt bulunamadı", 404, true);

            var mapper = _mapper.Map<IEnumerable<BoardListsListDto>>(result);

            return ResponseDto<IEnumerable<BoardListsListDto>>.Success(mapper, 200);
        }
    }
}
