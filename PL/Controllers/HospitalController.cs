using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class HospitalController : Controller
    {
        public IActionResult GetAllHospital()
        {
            Dictionary<string, object> resultado = BL.Hospital.GetAll();
            bool correct = (bool)resultado["Resultado"];
            if (correct)
            {
                ML.Hospital producto = (ML.Hospital)resultado["Hospital"];
                return View(producto);
            }
            return View();
        }

        [HttpPost]

        public ActionResult Form(ML.Hospital hospital)
        {
            ML.Hospital hosp = new ML.Hospital();
            return View(hosp);
        }






        [HttpGet]
        public ActionResult Delete(int idHospital)
        {
            Dictionary<string, object> result = BL.Hospital.Delete(idHospital);
            bool resultado = (bool)result["Resultado"];

            if (resultado == true)
            {

                ViewBag.Mensaje = "El Hospital ha sido eliminado";
                return PartialView("Modal");

            }
            else
            {
                //pendiente una alerta para la excepcion
                string excepcion = (string)result["Excepcion"];
                ViewBag.Mensaje = "El Hospital no se ha podido eliminar";
                return PartialView("Modal");

            }
        }
    }
}
