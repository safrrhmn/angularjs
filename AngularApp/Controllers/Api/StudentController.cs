using System;
using Core.Models;
using Core.Services;
using System.Web.Http;

namespace AngularApp.Controllers.Api
{
	[RoutePrefix("api/student")]
	public class StudentController : ApiController
	{
		private readonly IStudentService _studentService;

		public StudentController(IStudentService studentService)
		{
			_studentService = studentService;
		}

		[HttpGet]
		[Route("{id}")]
		public IHttpActionResult Get(int id)
		{
			var result = _studentService.Get(id);
			return Ok(result);
		}

		[HttpPost]
		[Route("")]
		public IHttpActionResult Save(Student student)
		{
			var result = _studentService.Insert(student);
			return Ok(result);
		}

		[HttpPut]
		[Route("")]
		public IHttpActionResult Update(Student student)
		{
			try
			{
				_studentService.Update(student);
				return Ok(true);
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}

		[HttpDelete]
		[Route("")]
		public IHttpActionResult Delete(int id)
		{
			try
			{
				_studentService.Delete(id);
				return Ok(true);
			}
			catch (Exception ex)
			{
				return Ok(ex);
			}
		}
	}
}