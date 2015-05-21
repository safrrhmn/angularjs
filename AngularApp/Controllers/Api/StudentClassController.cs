using System;
using System.Web.Http;
using Core.Models;
using Core.Services;

namespace AngularApp.Controllers.Api
{
	[RoutePrefix("api/studentclass")]
	public class StudentClassController : ApiController
	{
		private readonly IStudentClassService _studentClassService;

		public StudentClassController(IStudentClassService studentClassService)
		{
			_studentClassService = studentClassService;
		}

		[HttpGet]
		[Route("{id}")]
		public IHttpActionResult Get(int id)
		{
			var results = _studentClassService.Get(id);
			return Ok(results);
		}

		[HttpPost]
		[Route("")]
		public IHttpActionResult Save(StudentClass studentClass)
		{
			var results = _studentClassService.Insert(studentClass);
			return Ok(results);
		}

		[HttpDelete]
		[Route("{id}")]
		public IHttpActionResult Delete(int id)
		{
			try
			{
				_studentClassService.Delete(id);
				return Ok(true);
			}
			catch (Exception ex)
			{
				return Ok(ex);
			}
		}

		[HttpDelete]
		[Route("{studentId}/{classId}")]
		public IHttpActionResult Delete(int studentId, int classId)
		{
			try
			{
				_studentClassService.Delete(classId, studentId);
				return Ok(true);
			}
			catch (Exception ex)
			{
				return Ok(ex);
			}
		}
	}
}