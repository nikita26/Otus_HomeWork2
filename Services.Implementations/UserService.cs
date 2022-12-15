using AutoMapper;
using Domain.Entities;
using Services.Abstractons;
using Services.Contracts;
using Services.Repositories.Abstractions;

namespace Services.Implementations
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public UserDto Create(UserDto user)
        {
            var nU = _userRepository.Add(_mapper.Map<User>(user));
            return _mapper.Map<UserDto>(nU);
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDto> GetAll()
        {
            return _mapper.Map<IEnumerable<UserDto>>(_userRepository.GetAll().ToList());
        }

        public Task<UserDto> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(UserDto comment)
        {
            throw new NotImplementedException();
        }
    }
}