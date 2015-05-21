using Core.Services;
using System.Web.Http;

namespace AngularApp.Controllers.Api
{
	[RoutePrefix("api/class")]
	public class ClassController : ApiController
	{
		private readonly IClassService _classService;

		public ClassController(IClassService classService)
		{
			_classService = classService;
		}

		[HttpGet]
		[Route("")]
		public IHttpActionResult Get()
		{
			var results = _classService.Get();
			return Ok(results);
		}

		[HttpGet]
		[Route("{id}")]
		public IHttpActionResult Get(int id)
		{
			var results = _classService.Get(id);
			return Ok(results);
		}
	}
}