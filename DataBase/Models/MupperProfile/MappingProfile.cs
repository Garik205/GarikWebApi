using AutoMapper;
using System.Runtime.InteropServices;

namespace DataBase.Models.MupperProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<AddUserModel, User>().ReverseMap(); // задаем маппинг из AddUserModel в User.  ReverseMap() - работа в обоих направлениях
            CreateMap<AddOrderForUser, Order>().ReverseMap(); // Для работы с заказами
        }
    }
}
