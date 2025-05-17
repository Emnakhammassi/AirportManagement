using AM.Applactioncore.Domaine;
using AM.Applactioncore.Intterfaces;
using AM.Applactioncore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AM.UI.WEB.Controllers
{
    public class FlightController : Controller
    {
        IServiceFlight sf;
        IServicePlane sp;

        public FlightController(IServiceFlight sf, IServicePlane sp)
        {
            this.sf = sf;
            this.sp = sp;
        }

        // GET: FlightController
        public ActionResult Index(DateTime? dateDepart)
        {
            //return View(sf.GetMany());
            if (dateDepart == null)
                return View(sf.GetMany().ToList());
            else
                return View(sf.GetMany(f => f.FlightDate.Date.Equals(dateDepart)).ToList());
        }

        // GET: FlightController/Details/5
        public ActionResult Details(int id)
        {
            
            
            return View(sf.GetById(id));
        }

        // GET: FlightController/Create
        //formulair vide
        public ActionResult Create()
        {
            ViewBag.planeFK =
                new SelectList(sp.GetMany(), "PlaneId", "Information");


            return View();
        }

        // POST: FlightController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Flight collection, IFormFile PilotImage)
        {
            try
            {
                if (PilotImage != null && PilotImage.Length > 0)
                {
                    // Créer le dossier uploads s'il n'existe pas
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    // Générer un nom de fichier unique
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + PilotImage.FileName;
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        PilotImage.CopyTo(stream);
                    }

                    collection.Pilot = uniqueFileName;
                }

                sf.Add(collection);
                sf.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.planeFK = new SelectList(sp.GetMany(), "PlaneId", "Information");
                return View(collection);
            }
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Flight collection)
        //{
        //    try
        //    {   //ajout dans la base de données
        //        sf.Add(collection);
        //        sf.Commit();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}




        // GET: FlightController/Edit/5
        public ActionResult Edit(int id)
        {
            var flight = sf.GetById(id);
            if (flight == null)
            {
                return NotFound();
            }

            ViewBag.planeFK = new SelectList(sp.GetMany(), "PlaneId", "Information", flight.planeFK);
            return View(flight);
        }

        // POST: FlightController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Flight flight, IFormFile PilotImage)
        {
            if (id != flight.FlightId)
            {
                return NotFound();
            }

            try
            {
                if (PilotImage != null && PilotImage.Length > 0)
                {
                    // Supprimer l'ancienne image si elle existe
                    if (!string.IsNullOrEmpty(flight.Pilot))
                    {
                        var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", flight.Pilot);
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    // Enregistrer la nouvelle image
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + PilotImage.FileName;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        PilotImage.CopyTo(stream);
                    }

                    flight.Pilot = uniqueFileName;
                }

                sf.Update(flight);
                sf.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.planeFK = new SelectList(sp.GetMany(), "PlaneId", "Information", flight.planeFK);
                return View(flight);
            }
        }

        // GET: FlightController/Delete/5
        public ActionResult Delete(int id)
        {

            return View(sf.GetById(id));
        }

        // POST: FlightController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Flight collection)
        {
            try
            {
                sf.Delete(sf.GetById(id));

                sf.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Sort()
        {
            var sortedFlights = sf.SortFlights(); // Utilise la méthode de tri du service
            return View("Index", sortedFlights); // Réutilise la vue Index avec les vols triés
        }
    }
}
