using System.Web.Http;
using Core.Interfaces.Services;
using Core.Models;

namespace AngularApp.Controllers
{
    public class TeacherController : ApiController
    {
	    private readonly ITeacherService _teacherService;

	    public TeacherController(ITeacherService teacherService)
	    {
		    _teacherService = teacherService;
	    }
	   
        // GET: api/Teacher/5
	   public Teacher Get(int teacherId)
        {
		   return _teacherService.Get(teacherId);
        }

        // POST: api/Teacher
        public void Post(Teacher saveTeacher)
        {
	        _teacherService.Save(saveTeacher);
        }

        // PUT: api/Teacher/5
	   public void Put(Teacher saveTeacher)
        {
		   _teacherService.Update(saveTeacher);
        }

        // DELETE: api/Teacher/5
	   public void Delete(int teacherId)
        {
		   _teacherService.Delete(teacherId);
        }
    }
}
