using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using TextLand.BL.Models;
using TextLand.BL.Services.Interfaces;
using TextLand.DAL.Models;
using TextLand.DAL.Repositories.Interfaces;

namespace TextLand.BL.Services
{
    public class AdminsService : IAdminsService
    {
        private readonly IUsersService _usersService;
        private readonly IAdminsRepository _adminsRepository;
        private readonly IMapper _mapper;

        public AdminsService(IUsersService usersService, IAdminsRepository adminsRepository, IMapper mapper)
        {
            _usersService = usersService;
            _adminsRepository = adminsRepository;
            _mapper = mapper;
        }

        public List<PayoffDto> GetUndonePayoffs(int adminId)
        {
            if (!CheckIfAdmin(adminId)) return null;

            return _adminsRepository.GetUndonePayoffs().Select(x => _mapper.Map<PayoffDto>(x)).ToList();
        }

        public List<PayoffDto> RealizePayoffs(int adminId, int[] payoffsIds)
        {
            if (!CheckIfAdmin(adminId) || payoffsIds == null) return null;
            List<PayoffDto> realizedPayoffs = new List<PayoffDto>();
            foreach(var id in payoffsIds)
            {
                var payoffToRealize = _mapper.Map<PayoffDto>(_adminsRepository.RealizePayoff(id));
                realizedPayoffs.Add(payoffToRealize);
            }

            return realizedPayoffs;
        }

        private bool CheckIfAdmin (int id)
        {
            return (_usersService.GetUserById(id).IsAdmin);
        }
    }
}
