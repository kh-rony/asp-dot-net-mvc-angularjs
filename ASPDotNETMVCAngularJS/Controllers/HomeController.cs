using System.Web.Mvc;
using ASPDotNETMVCAngularJS.DataAccessLayer;
using ASPDotNETMVCAngularJS.DataAccessLayer.Repositories;
using ASPDotNETMVCAngularJS.Models;
using Newtonsoft.Json;

namespace ASPDotNETMVCAngularJS.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentRepository studentRepository = new StudentRepository();

        public HomeController()
        {
        }

        [HttpGet]
        public ActionResult GetStudents()
        {
            var list = studentRepository.GetStudents();

            var jsonData = JsonConvert.SerializeObject(list);

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddStudent(Student student)
        {
            var result = studentRepository.AddStudent(student);

            var list = studentRepository.GetStudents();

            var jsonData = JsonConvert.SerializeObject(list);

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateStudent(Student student)
        {
            var result = studentRepository.UpdateStudent(student);

            var list = studentRepository.GetStudents();

            var jsonData = JsonConvert.SerializeObject(list);

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteStudent(int id)
        {
            var result = studentRepository.DeleteStudent(id);

            var list = studentRepository.GetStudents();

            var jsonData = JsonConvert.SerializeObject(list);

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}