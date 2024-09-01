using CGV_BackEnd.Models;
using CGV_BackEnd.Models.Interface;
using System.Diagnostics.Metrics;

namespace CGV_BackEnd.Services
{
	public class LawyerService : ILawyerService
	{
		private readonly ILawyerCommandContext _lawyerCommandContext;
		private readonly ILawyerQueryContext _lawyerQueryContext;

		public LawyerService(ILawyerCommandContext lawyerCommandContext, ILawyerQueryContext lawyerQueryContext)
		{
			this._lawyerCommandContext = lawyerCommandContext;
			this._lawyerQueryContext = lawyerQueryContext;
		}

		public Lawyer GetLawyerById(string id)
		{
			//Find if the user exists
			var user = _lawyerQueryContext.GetLawyerById(id);
			if (user == null)
			{
				throw new Exception("User does not exist");
			}

			return user;
		}

		public List<Lawyer> GetAllUsers()
		{
			return _lawyerQueryContext.GetAllLawyers();
		}

		public void AddLawyer(Lawyer user)
		{
			_lawyerCommandContext.AddLawyer(user);
		}

		public void UpdateLawyer(Lawyer user)
		{
			_lawyerCommandContext.UpdateLawyer(user);
		}

		public void DeleteLawyerById(string id)
		{
			_lawyerCommandContext.DeleteLawyer(id);
		}

	}

	public interface ILawyerService
	{
		List<Lawyer> GetAllUsers();
		Lawyer GetLawyerById(string id);
		void AddLawyer(Lawyer user);
		void UpdateLawyer(Lawyer user);
		void DeleteLawyerById(string id);
		//void DeleteUserByEmail(string email);
		//Lawyer GetUserByEmail(string email);
	}
}
