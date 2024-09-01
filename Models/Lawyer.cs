using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;
namespace CGV_BackEnd.Models
{
	public class Lawyer
	{
		[Key]
		public string? Id { get; set; } = Guid.NewGuid().ToString();
		public string Name { get; set; }
		public Seniority Seniority { get; set; }
		public Address Address { get; set; }

		public Lawyer() { }
		public Lawyer(string name, Seniority seniority, Address address)
		{
			Name = name;
			Seniority = seniority;
			Address = address ?? throw new ArgumentNullException(nameof(address));
		}

		public bool ValidateSeniority()
		{
			return Enum.IsDefined(typeof(Seniority), Seniority);
		}
	}

	public enum Seniority
	{
		JR, // Júnior
		PL, // Pleno
		SR  // Sênior
	}


}
