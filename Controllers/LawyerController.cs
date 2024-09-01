using CGV_BackEnd.Models;
using CGV_BackEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CGV_BackEnd.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LawyerController : ControllerBase
	{
		private LawyerService _lawyerService;

		public LawyerController(LawyerService lawyerService)
		{
			_lawyerService = lawyerService;
		}

		[HttpGet("getAll")]
		public IActionResult GetAllUsers()
		{
			try
			{
				List<Lawyer> returnLawyer = _lawyerService.GetAllUsers();
				return Ok(returnLawyer);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("{id}")]
		public IActionResult GetById(string id)
		{
			try
			{
				Lawyer returnUser = _lawyerService.GetLawyerById(id);
				return Ok(returnUser);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost]
		public IActionResult CreateUser([FromBody] Lawyer NewLawyer)
		{
			try
			{
				_lawyerService.AddLawyer(NewLawyer);
				return Ok("Lawyer created successfully");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("{id}")]
		public IActionResult AttUser(string id, [FromBody] Lawyer AttLawyer)
		{
			try
			{
				AttLawyer.Id = id;
				_lawyerService.UpdateLawyer(AttLawyer);
				return Ok("Lawyer updated successfully");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete("ById/{id}")]
		public IActionResult DeleteUser(string id)
		{
			try
			{
				_lawyerService.DeleteLawyerById(id);
				return Ok("Lawyer deleted successfully");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		//[HttpDelete("ByEmail/{email}")]
		//public IActionResult DeleteUserByEmail(string email)
		//{
		//	try
		//	{
		//		_lawyerService.DeleteUserByEmail(email);
		//		return Ok("User deleted successfully");
		//	}
		//	catch (Exception ex)
		//	{
		//		return BadRequest(ex.Message);
		//	}
		//}

		//[HttpGet]
		//public IActionResult GetByEmail(string email)
		//{
		//	try
		//	{
		//		User returnUser = _lawyerService.GetUserByEmail(email);
		//		return Ok(returnUser);
		//	}
		//	catch (Exception ex)
		//	{
		//		return BadRequest(ex.Message);
		//	}
		//}

	}
}
