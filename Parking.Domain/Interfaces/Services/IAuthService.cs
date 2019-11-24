using Parking.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parking.Domain.Interfaces.Services
{
	public interface IAuthService
	{
		UserDto LoginUser(string username, string password);
	}
}
