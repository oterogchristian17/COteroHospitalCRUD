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



        [HttpGet]
        public ActionResult Form()
        {
            ML.Hospital emisor = new ML.Hospital();
            return View(emisor);
        }







        [HttpPost]
        public ActionResult Form(ML.Hospital hospital)
        {

            if (hospital.IdHospital > 0)
            {

                Dictionary<string, object> result = BL.Hospital.Update(hospital);
                bool resultado = (bool)result["Resultado"];

                if (resultado == true)
                {
                    ViewBag.Mensaje = "El Hospital ha sido actualizado";
                    return PartialView("Modal");
                }
                else
                {
                    string excepcion = (string)result["Excepcion"];
                    ViewBag.Mensaje = "El Hospital no se pudo actualizar" + excepcion;
                    return PartialView("Modal");
                }

            }
            else
            {
                Dictionary<string, object> resultado = BL.Hospital.Add(hospital);

                bool result = (bool)resultado["Resultado"];
                if (result)
                {
                    ViewBag.Mensaje = "El Hospital ha sido agregado";
                    return PartialView("Modal");
                }
                else
                {
                    string exepcion = (string)resultado["Excepcion"];
                    ViewBag.Mensaje = "El Hospital no se pudo agregar" + exepcion;
                    return PartialView("Modal");
                }

            }
            return View(hospital);

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
