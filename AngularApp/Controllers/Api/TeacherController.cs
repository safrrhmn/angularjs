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
		[Route("{id}")]
		public IHttpActionResult Get(int id)
		{
			var result = _teacherService.Get(id);
			return Ok(result);
		}

		[HttpPost]
		[Route("save")]
		public IHttpActionResult Save(Teacher teacher)
		{
			var result = _teacherService.Insert(teacher);
			return Ok(result);
		}
	}
}