using System;
using System.Web.Http;
using Core.Models;
using Core.Services;

namespace AngularApp.Controllers.Api
{
	[RoutePrefix("api/studentclass")]
	public class TeacherClassController : ApiController
	{
		private readonly ITeacherClassService _teacherClassService;

		public TeacherClassController(ITeacherClassService teacherClassService)
		{
			_teacherClassService = teacherClassService;
		}

		[HttpGet]
		[Route("{id}")]
		public IHttpActionResult Get(int id)
		{
			var results = _teacherClassService.Get(id);
			return Ok(results);
		}

		[HttpPost]
		[Route("")]
		public IHttpActionResult Save(TeacherClass teacherClass)
		{
			var results = _teacherClassService.Insert(teacherClass);
			return Ok(results);
		}

		[HttpDelete]
		[Route("{id}")]
		public IHttpActionResult Delete(int id)
		{
			try
			{
				_teacherClassService.Delete(id);
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
				_teacherClassService.Delete(classId, studentId);
				return Ok(true);
			}
			catch (Exception ex)
			{
				return Ok(ex);
			}
		}
	}
}