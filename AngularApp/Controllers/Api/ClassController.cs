using System;
using Core.Models;
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

		[HttpPost]
		[Route("")]
		public IHttpActionResult Save(SlimClass slimClass)
		{
			var results = _classService.Insert(slimClass);
			return Ok(results);
		}

		[HttpPut]
		[Route("")]
		public IHttpActionResult Update(SlimClass slimClass)
		{
			try
			{
				_classService.Update(slimClass);
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
				_classService.Delete(id);
				return Ok(true);
			}
			catch (Exception ex)
			{
				return Ok(ex);
			}
		}
	}
}