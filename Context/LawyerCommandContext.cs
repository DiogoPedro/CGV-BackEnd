using CGV_BackEnd.Models;
using CGV_BackEnd.Models.Interface;
using Microsoft.EntityFrameworkCore;

namespace CGV_BackEnd.Context
{
	public class LawyerCommandContext : DbContext, ILawyerCommandContext
	{
		public LawyerCommandContext(DbContextOptions<LawyerCommandContext> options) : base(options) { }

		public DbSet<Lawyer> Users { get; set; }
		public DbSet<Address> Addresses { get; set; }

		public void AddLawyer(Lawyer user)
		{
			Users.Add(user);
			SaveChanges();
		}
		public void UpdateLawyer(Lawyer user)
		{
			Users.Update(user);
			SaveChanges();
		}
		public void DeleteLawyer(string id)
		{
			var firstUser = Users.FirstOrDefault(u => u.Id == id);
			Users.Remove(firstUser);
			SaveChanges();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Lawyer>().HasKey(u => u.Id);
			modelBuilder.Entity<Lawyer>().Property(u => u.Name).IsRequired();

			modelBuilder.Entity<Address>()
				.HasOne(a => a.Lawyer)
				.WithOne(l => l.Address)
				.HasForeignKey<Address>(a => a.LawyerId);
		}

	}
}
