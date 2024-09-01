using CGV_BackEnd.Models;
using CGV_BackEnd.Models.Interface;
using Microsoft.EntityFrameworkCore;

namespace CGV_BackEnd.Context
{
	public class LawyerQueryContext : DbContext, ILawyerQueryContext
	{
		public LawyerQueryContext(DbContextOptions<LawyerQueryContext> options) : base(options) { }

		public DbSet<Lawyer> Users { get; set; }
		public DbSet<Address> Addresses { get; set; }


		//Get all users
		public List<Lawyer> GetAllLawyers()
		{
			return Users.ToList();
		}

		//Get the user by id
		public Lawyer GetLawyerById(string id)
		{
			return Users.FirstOrDefault(u => u.Id == id);
		}

		//public bool LawyerExists(string email)
		//{
		//	return Users.Any(u => u.Email == email);
		//}

		//public Lawyer GetLawyerByEmail(string email)
		//{
		//	return Users.FirstOrDefault(u => u.Email == email);
		//}
	}
}
