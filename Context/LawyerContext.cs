using CGV_BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace CGV_BackEnd.Context
{
	public class LawyerContext: DbContext
	{
		public LawyerContext(DbContextOptions<LawyerContext> options) : base(options) { }

		public DbSet<Lawyer> Users { get; set; }
		public DbSet<Address> Addresses { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Lawyer>()
				.HasOne(l => l.Lawyer)
				.WithOne(a => a.Addresses)
				.HasForeignKey<Address>(a => a.LawyerId);
		}


	}
}
