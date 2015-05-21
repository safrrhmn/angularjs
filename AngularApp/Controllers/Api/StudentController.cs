﻿using Core.Models;
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
	}
}