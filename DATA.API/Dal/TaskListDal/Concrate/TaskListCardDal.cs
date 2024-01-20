using Data.API.Context;
using Data.API.Dal.TaskListDal.Abstract;
using Data.API.Extensions.ErrorHandler;
using Data.API.Extensions.Upload;
using Data.API.Repositories;
using Entity.API.Models.Dto.KarbonDto.CreateDto;
using Entity.API.Models.Dto.KarbonDto.UpdateDto;
using Entity.API.Models.KarbanModels;

namespace Data.API.Dal.TaskListDal.Concrate
{
    public class TaskListCardDal : GenericRepository<ListCard>, ITaskListCardDal
    {
        public TaskListCardDal(AppDbContext context) : base(context)
        {
        }

        public async Task<ListCard> CreateAsync(TaskListCreateDto createDto,Guid BoardId)
        {
            var card = new ListCard();

            card.BoardListsId = BoardId;

            card.CardName = createDto.CardName;
            card.CardColor = createDto.CardColor;
            card.Description = createDto.Description;
            if(createDto.StartDate is not null)
            {
                card.StartDate = createDto.StartDate;
            }

            if(createDto.FinisDate is not null)
            {
                card.FinisDate = createDto.FinisDate;
            }

            if(createDto.ListTicketCreateDtos is not null)
            {
                foreach (var items in createDto.ListTicketCreateDtos)
                {
                    card.ListTickets.Add(new ListTicket()
                    {
                       Name = items
                    });
                }
            }

            if(createDto.ListAddition is not null)
            {
                foreach(var items in createDto.ListAddition)
                {
                    var file = await UploadExtensions.UploadExtension(items);

                    card.ListAdditions.Add(new ListAddition()
                    {
                        Name = file.Name,
                        Path = file.Path
                    });
                }
            }

            return card;
        }

        public async Task<ListCard> UpdateAsync(bool trackChanges, ListCardUpdateDto updateDto, Guid id)
        {
            var card = await GetOne(trackChanges, x => (x.IsDeleted.Equals(false) && x.Id.Equals(id)), x => x.ListAdditions, a => a.ListTickets);
            if (card is null)
                throw new BaseException($"{id} 'li card bulunamadı");
            if (card.CardName != updateDto.CardName)
            {
                card.CardName = updateDto.CardName;
            }

            if (card.CardColor != updateDto.CardColor)
            {
                card.CardColor = updateDto.CardColor;
            }

            if (card.Description != updateDto.Description)
            {
                card.Description = updateDto.Description;
            }

            if (card.StartDate != updateDto.StartDate)
            {
                card.StartDate = updateDto.StartDate;
            }

            if (card.FinisDate != updateDto.FinisDate)
            {
                card.FinisDate = updateDto.FinisDate;
            }

            return card;

        }
    }
}
