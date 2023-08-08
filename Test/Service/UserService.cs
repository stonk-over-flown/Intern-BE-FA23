using AutoMapper;
using Test.Entity;
using Test.Model;
using Test.Repository;

namespace Test.Service
{
    public interface IUserService
    {
        List<UserModel> GetAllUsers();
    }
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly UserRepo _userRepo;

        public UserService(UserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public List<UserModel> GetAllUsers()
        {
            List<UserEntity> list = _userRepo.GetAll().ToList();
            List<UserModel> result = null;
            foreach(UserEntity userEntity in list)
            {
                var user = new UserModel();
                var temp = _mapper.Map(userEntity, user);
                result.Add(user);
            }
            return result;
        }
    }
}
