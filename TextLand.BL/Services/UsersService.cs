using AutoMapper;
using System.Collections.Generic;
using TextLand.BL.Models;
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
            if (userDto == null) return null;
            var user = _mapper.Map<User>(userDto);
            var registeredUser = _usersRepository.RegisterUser(user);
            return _mapper.Map<UserDto>(registeredUser);
        }

        public UserDto AddExampleUser ()
        {
            var createdUser = CreateUser();
            return RegisterUser(createdUser);
        }
    }
}
