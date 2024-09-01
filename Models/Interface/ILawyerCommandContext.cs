namespace CGV_BackEnd.Models.Interface
{
	public interface ILawyerCommandContext
	{
		public void AddLawyer(Lawyer user);
		public void UpdateLawyer(Lawyer user);
		public void DeleteLawyer(string id);
	}
}
