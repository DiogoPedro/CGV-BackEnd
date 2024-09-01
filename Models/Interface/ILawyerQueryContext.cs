namespace CGV_BackEnd.Models.Interface
{
	public interface ILawyerQueryContext
	{
		Lawyer GetLawyerById(string id);
		List<Lawyer> GetAllLawyers();

		//bool LawyerExists(string email);
		//Lawyer GetUserByEmail(string email);
	}
}
