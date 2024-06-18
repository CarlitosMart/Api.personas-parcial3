using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using Repository.Models.BD;
using Services.Logica;
using Services.Validaciones;

namespace api.Facturas.Controllers
{
    //[ApiController]
    //[Route("/Api/v1/")]
    public class FacturaController : Controller
    {
        private FacturaService FacturaService;
        public FacturaValidator Validations { get; }
        public FacturaController(IConfiguration configuracion, FacturaValidator T_validations)
        {
            FacturaService = new FacturaService(configuracion.GetConnectionString("postgres"));
            Validations = T_validations;
        }

        [HttpGet("ListF")]
        public async Task<ActionResult<List<FacturaModel>>> List()
        {
            var a = FacturaService.list();
            return a;
        }
        // GET: FacturaController/Create
        [HttpPost("AddF")]
        public async Task<ActionResult> AddAsync(Repository.Data.FacturaModel Factura)
        {
            var validationResult = await Validations.ValidateAsync(Factura); if (!validationResult.IsValid) { return BadRequest(validationResult.Errors); }
            FacturaService.add(Factura);
            return Ok(new { message = $"La Factura con nombre {Factura.Nro_factura} fue insertado correctamente!!!"});
        }
        [HttpPost("EditF")]
        public async Task<ActionResult> EditAsync(Repository.Data.FacturaModel Factura)
        {
            var validationResult = await Validations.ValidateAsync(Factura); if (!validationResult.IsValid) { return BadRequest(validationResult.Errors); }
            FacturaService.edit(Factura);
            return Ok(new { message = $"La Factura con nombre {Factura.Nro_factura} fue actualizado correctamente!!!" });
        }

        [HttpPost("deleteF")]
        public ActionResult delete(int id)
        {
            FacturaService.delete(id);
            return Ok(new { message = $"La Factura fue eliminada correctamente!!!" });
        }


        // POST: FacturaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FacturaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FacturaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FacturaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FacturaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
