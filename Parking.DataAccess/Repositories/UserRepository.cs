using Parking.DataAccess.Contexts;
using Parking.Domain.Dtos;
using Parking.Domain.Entities;
using Parking.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking.DataAccess.Repositories
{
	public class UserRepository: IUserRepository
	{
		private readonly ParkingContext _context;
		public UserRepository(ParkingContext context)
		{
			_context = context;
		}
		public void AddUser(string userName, string password,string salt)
		{
			//throw new NotImplementedException();
			User user = new User()
			{
				UserName = userName,
				IsAdministrator = false,
				ActiveStatus =1,
				UpdateDate=DateTime.Now,
				Password= password,
				Salt = salt
			};
			_context.Users.Add(user);
			_context.SaveChanges();
		}

		public bool GetIsAmin(int userId)
		{
			bool IsAmin  =  _context.Users.Where(u=>u.Id==userId).Select(u=> u.IsAdministrator).FirstOrDefault();
			return IsAmin;
		}

		public UserDto GetUserIdByUserName(string userName)
		{
			var userId = _context.Users.Where(u => u.UserName == userName).Select(u => u.Id).FirstOrDefault();
			UserDto user = new UserDto()
			{
				Id = userId
			};
			return user;
		}

		public UserDto LoginUser(string username, string password)
		{
			int userId = _context.Users.Where(u => u.UserName == username && u.Password == password).Select(u => u.Id).FirstOrDefault();
			UserDto user = new UserDto()
			{
				Id = userId
			};
			return user;
		}

		public void UpdateActiveStatus(int userId, int activeStatus)
		{
		     var user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();
			 user.ActiveStatus = activeStatus;
			_context.SaveChanges();
		}
	}
}
