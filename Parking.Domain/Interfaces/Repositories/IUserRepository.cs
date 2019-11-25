using Parking.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parking.Domain.Interfaces.Repositories
{
	public interface IUserRepository
	{
		/// Add User (Register)
		void AddUser(string userName,string password,string salt);
		/// Update User
		void UpdateActiveStatus(int userId,int activeStatus);
		/// Get IsAmin By Id User
		bool GetIsAmin(int userId);
		/// Get User By Username and password
		UserDto LoginUser(string username, string password);
		/// Get UserId By UserName
		UserDto GetUserIdByUserName(string userName);
	}
}
