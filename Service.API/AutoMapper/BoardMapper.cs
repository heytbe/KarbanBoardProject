using AutoMapper;
using Entity.API.Models.Dto.KarbonDto.ListDto;
using Entity.API.Models.Dto.KarbonDto.UpdateDto;
using Entity.API.Models.KarbanModels;

namespace Service.API.AutoMapper
{
    public class BoardMapper: Profile
    {
        public BoardMapper()
        {
            //Liste

            CreateMap<Board,BoardListDto>().ReverseMap();
            CreateMap<Board, BoardListsListDto>().ReverseMap();
            CreateMap<BoardLists,BoardListsListDto>().ReverseMap();
            CreateMap<BoardUsers,BoardUserListDto>().ReverseMap();
            CreateMap<ListCard, ListCardDto>().ReverseMap();
            CreateMap<ListTicket,ListTicketDto>().ReverseMap();
            CreateMap<ListAddition,ListAdditionDto>().ReverseMap();
            CreateMap<Board,BoardNameListDto>().ReverseMap();

            //update

            CreateMap<Board,BoardUpdateDto>().ReverseMap();
            CreateMap<BoardUsers,BoardUsersUpdateDto>().ReverseMap();
        }
    }
}
