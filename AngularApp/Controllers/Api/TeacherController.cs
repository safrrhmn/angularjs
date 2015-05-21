using System;
using System.Web.Http;
using Core.Models;
using Core.Services;

namespace AngularApp.Controllers.Api
{
	[RoutePrefix("api/teacher")]
	public class TeacherController : ApiController
	{
		private readonly ITeacherService _teacherService;

		public TeacherController(ITeacherService teacherService)
		{
			_teacherService = teacherService;
		}

		[HttpGet]
		[Route("")]
		public IHttpActionResult Get()
		{
			var results = _teacherService.Get();
			return Ok(results);
		}
		
		[HttpGet]
		[Route("{id}")]
		public IHttpActionResult Get(int id)
		{
			var result = _teacherService.Get(id);
			return Ok(result);
		}

		[HttpPost]
		[Route("")]
		public IHttpActionResult Save(Teacher teacher)
		{
			var result = _teacherService.Insert(teacher);
			return Ok(result);
		}

		[HttpPut]
		[Route("")]
		public IHttpActionResult Update(Teacher teacher)
		{
			
			try
			{
				_teacherService.Update(teacher);
				return Ok(true);
			}
			catch (Exception ex)
			{
				return Ok(ex);
			}
		}

		[HttpDelete]
		[Route("{id}")]
		public IHttpActionResult Delete(int id)
		{
			try
			{
				_teacherService.Delete(id);
				return Ok(true);
			}
			catch (Exception ex)
			{
				return Ok(ex);
			}
		}
	}
}