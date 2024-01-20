using AutoMapper;
using Core.API.Response;
using Data.API.Dal.TaskListDal.Abstract;
using Data.API.Extensions.Upload;
using Data.API.UnitOfWork;
using Entity.API.Models.Dto.KarbonDto.CreateDto;
using Entity.API.Models.Dto.KarbonDto.ListDto;
using Entity.API.Models.Dto.KarbonDto.UpdateDto;
using Entity.API.Models.KarbanModels;
using Service.API.Service.Abstract;

namespace Service.API.Service.Concrate
{
    public class TaskListCardService : ITaskListCardService
    {
        private readonly ITaskListCardDal _taskListDal;
        private readonly ITaskCardAdditionDal _taskCardAdditionDal;
        private readonly ITaskListCardTicketDal _taskListCardTicketDal;
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkRepo _unitOfWork;

        public TaskListCardService(ITaskListCardDal taskListDal, IMapper mapper, IUnitOfWorkRepo unitOfWork, ITaskCardAdditionDal taskCardAdditionDal, ITaskListCardTicketDal taskListCardTicketDal)
        {
            _taskListDal = taskListDal;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _taskCardAdditionDal = taskCardAdditionDal;
            _taskListCardTicketDal = taskListCardTicketDal;
        }

        public async Task<ResponseDto<Response>> CreateAsync(TaskListCreateDto createDto, Guid BoardListId)
        {
            var result = await _taskListDal.CreateAsync(createDto, BoardListId);
            await _taskListDal.AddAsync(result);
            await _unitOfWork.SaveAsync();
            return ResponseDto<Response>.Success("Kayıt Edildi", 201);
        }

        public async Task<ResponseDto<Response>> DeleteAsync(bool trackChanges, Guid id)
        {
            var result = await _taskListDal.GetOne(trackChanges, x => (x.IsDeleted.Equals(false) && x.Id.Equals(id)),x => x.ListAdditions,a => a.ListTickets);
            if(result is null)
            {
                return ResponseDto<Response>.Fail($"{id} 'li card bulunamadı", 404, true);
            }

            if(result.ListAdditions.Count > 0)
            {
                foreach(var item in result.ListAdditions)
                {
                    if (File.Exists(Path.GetFullPath("wwwRoot") + item.Path))
                    {
                        File.Delete(Path.GetFullPath("wwwRoot") + item.Path);
                    }
                }
            }

            _taskListDal.Remove(result);
            await _unitOfWork.SaveAsync();

            return ResponseDto<Response>.Success("Silindi", 200);
        }

        public async Task<ResponseDto<ListCardDto>> GetByIdAsync(bool trakChanges, Guid id)
        {
            var result = await _taskListDal.GetOne(trakChanges, x => (x.IsDeleted.Equals(false) && x.Id.Equals(id))
            , x => x.ListTickets, a => a.ListAdditions);

            if (result is null)
                return ResponseDto<ListCardDto>.Fail($"{id} 'li card bulunamadı",404,true);

            var mapper = _mapper.Map<ListCardDto>(result);
            return ResponseDto<ListCardDto>.Success(mapper, 200);
        }

        public async Task<ResponseDto<Response>> UpdateAsync(bool trackChanges, ListCardUpdateDto updateDto, Guid id)
        {
            var result = await _taskListDal.UpdateAsync(trackChanges, updateDto, id);

            _taskListDal.Update(result);

            if(updateDto.ListAddition.Any())
            {
                foreach(var item in updateDto.ListAddition)
                {
                    var file = await UploadExtensions.UploadExtension(item);
                    var cardAddition = new ListAddition();
                    cardAddition.Name = file.Name;
                    cardAddition.Path = file.Path;
                    cardAddition.ListCardId = id;
                    await _taskCardAdditionDal.AddAsync(cardAddition);
                }
            }

            if(updateDto.ListTicket.Any())
            {
                foreach(var item in updateDto.ListTicket)
                {
                    var ticket = new ListTicket();
                    ticket.Name = item;
                    ticket.ListCardId = id;
                    await _taskListCardTicketDal.AddAsync(ticket);
                }
            }

            await _unitOfWork.SaveAsync();
            return ResponseDto<Response>.Success($"{result.CardName} isimli card güncellendi", 200);
        }
    }
}
