namespace GiftSender.Infrastructure
{
    using AutoMapper;
    using GiftSender.Data.Models;
    using GiftSender.Models.Users;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<ApplicationUser, UserInListViewModel>();
            this.CreateMap<ApplicationUser, UserCredits>();
        }
    }
}
