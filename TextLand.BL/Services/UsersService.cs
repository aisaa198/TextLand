using AutoMapper;
using TextLand.BL.Models;
using TextLand.BL.Services.Interfaces;
using TextLand.DAL.Models;
using TextLand.DAL.Repositories;

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
            if (userDto == null || string.IsNullOrEmpty(userDto.Email) || string.IsNullOrEmpty(userDto.Password) || string.IsNullOrEmpty(userDto.Name)) return null;
            var userWithTheSameEmail = _usersRepository.GetUserByEmail(userDto.Email);
            if (userWithTheSameEmail != null) return null;

            var user = _mapper.Map<User>(userDto);
            var registeredUser = _usersRepository.RegisterUser(user);
            return _mapper.Map<UserDto>(registeredUser);
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

        
    }
}
