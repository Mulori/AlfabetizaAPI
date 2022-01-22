using AlfabetizaAPI.Models.DTO;
using AlfabetizaAPI.Models.Entities;
using AutoMapper;

namespace AlfabetizaAPI.Helpers
{
    public class AlfabetizaProfile : Profile
    {
        public AlfabetizaProfile()
        {
            //<Entrou, Saiu>
            CreateMap<User, UserResume>();
            CreateMap<UserUpdate, User>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<UserAdd, User>();
        }
    }
}
