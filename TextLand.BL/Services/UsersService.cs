using AutoMapper;
using TextLand.BL.Models;
using TextLand.BL.Services.Interfaces;
using TextLand.DAL.Models;
using TextLand.DAL.Repositories.Interfaces;

namespace TextLand.BL.Services
{
    public class UsersService : IUsersService
    {
        private readonly IMapper _mapper;
        private readonly IUsersRepository _usersRepository;

        public UsersService(IMapper mapper, IUsersRepository usersRepository)
        {
            _mapper = mapper;
            _usersRepository = usersRepository;
        }

        private UserDto CreateUser ()
        {
            var createdUser = new UserDto
            {
                Name = "Marian",
                Surname = "Nowak",
                Email = "mariann@gmail.com",
                Password = "marian"
            };
            return createdUser;
        }

        public UserDto GetUserByEmail (string email)
        {
            var user = _usersRepository.GetUserByEmail(email);
            return _mapper.Map<UserDto>(user);
        }

        public UserDto RegisterUser(UserDto userDto)
        {
            if (CheckUserData(userDto))
            {
                var user = _mapper.Map<User>(userDto);
                user.AddedOrders = null;
                user.ExecutedOrders = null;
                var registeredUser = _usersRepository.RegisterUser(user);
                return _mapper.Map<UserDto>(registeredUser);
            }
            else return null;
        }

        private bool CheckUserData(UserDto userToCheck)
        {
            if (userToCheck == null || string.IsNullOrEmpty(userToCheck.Email) || string.IsNullOrEmpty(userToCheck.Password) || string.IsNullOrEmpty(userToCheck.Name)) return false;
            var userWithTheSameEmail = _usersRepository.GetUserByEmail(userToCheck.Email);
            if (userWithTheSameEmail != null) return false;
            return true;
        }

        public UserDto AddExampleUser ()
        {
            var createdUser = CreateUser();
            return RegisterUser(createdUser);
        }

        public UserDto GetUserById(int userId)
        {
            var user = _usersRepository.GetUserById(userId);
            return _mapper.Map<UserDto>(user);
        }

        public bool DeleteUser(int userId, string password)
        {
            var userToDelete = _usersRepository.GetUserById(userId);
            if (userToDelete == null) return false;
            return (userToDelete.Password != password)? false : _usersRepository.DeleteUser(userToDelete, password);
        }

        public UserDto LogIn(string email, string password)
        {
            var user = _usersRepository.LogIn(email, password);
            return _mapper.Map <UserDto>(user);
        }

        public UserDto ChangeUserData(UserDto changedUserDto)
        {
            if (CheckUserData(changedUserDto))
            {
                var changedUser = _mapper.Map<User>(changedUserDto);
                var userWithNewData = _usersRepository.ChangeUserData(changedUser);
                return _mapper.Map<UserDto>(userWithNewData);
            }
            else return null;
        }

        public bool SetAdminPrivilage(int userId)
        {
            return _usersRepository.SetAdminPrivilage(userId);
        }
    }
}
