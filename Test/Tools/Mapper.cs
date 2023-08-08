using AutoMapper;
using Test.Entity;
using Test.Model;

namespace Test.Tools
{
    public class Mapper : Profile
    {
        public void MappingProfile()
        {
            CreateMap<CardEntity, CardModel>().ReverseMap();
            CreateMap<UserEntity, UserModel>().ReverseMap();
        }
    }
}
