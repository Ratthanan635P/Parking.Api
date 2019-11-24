using Parking.Domain.Dtos;
using Parking.Domain.Interfaces.Repositories;
using Parking.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parking.Domain.Services
{
	public class AuthService : IAuthService
	{
		private readonly IUserRepository _userRepository;

		public AuthService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public UserDto LoginUser(string username, string password)
		{
			throw new NotImplementedException();
		}
	}
}
