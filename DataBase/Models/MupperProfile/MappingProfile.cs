using AutoMapper;
using System.Runtime.InteropServices;

namespace DataBase.Models.MupperProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<AddUserModel, User>(); // задаем маппинг из AddUserModel в User.  ReverseMap() - работа в обоих направлениях
        }
    }
}
