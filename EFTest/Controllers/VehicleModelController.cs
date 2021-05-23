using AutoMapper;
using Vehicle.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.Model.Models;
using Vehicle.Repository.Common.Models;

namespace Vehicle.Controllers
{
    public class VehicleModelController : Controller
    {
        private readonly IVHModelRepository _vehicleModelRepository; IMapper _mapper;

        public VehicleModelController(IVHModelRepository vehicleModelService, IMapper mapper)
        {
            _vehicleModelRepository = vehicleModelService;
            _mapper = mapper;
        }

        // GET: VehicleModels
        public async Task<IActionResult> Index(int makeId)
        {

            ViewBag.MakeId = makeId;
            var vehicleModel = await _vehicleModelRepository.GetVehicleModelAsync(makeId);
            var indexModel = _mapper.Map<IEnumerable<VehicleModel>, IEnumerable<IndexModel>>(vehicleModel);

            return View(indexModel);

        }

        // GET: VehicleModels/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                var vehicleModel = await _vehicleModelRepository.GetVehicleModelAsync(id);
                var detailsModel = _mapper.Map<VehicleModel, DetailsModel>(vehicleModel);
                return View(detailsModel);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }


        }

        // GET: VehicleModels/Create
        public IActionResult Create(int makeId)
        {

            var vehicleModel = new VehicleModel { MakeId = makeId };
            var createModel = _mapper.Map<VehicleModel, CreateModel>(vehicleModel);
            return View(createModel);
        }

        // POST: VehicleModels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Abrv,MakeId")] CreateModel createModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var vehicleModel = _mapper.Map<CreateModel, VehicleModel>(createModel);
                    var numberOfSaves = await _vehicleModelRepository.CreateVehicleModelAsync(vehicleModel);
                    return RedirectToAction(nameof(Index), new { makeId = vehicleModel.MakeId });
                }
                catch (Exception)
                {
                    return RedirectToAction("Error", "Home");
                }
            }

            return View(createModel);
        }

        // GET: VehicleModels/Edit
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            try
            {

                var vehicleModel = await _vehicleModelRepository.GetVehicleModelAsync(id);
                var editModel = _mapper.Map<VehicleModel, EditModel>(vehicleModel);
                var vehicleMake = await _vehicleModelRepository.GetVehicleMakeAsync(vehicleModel.MakeId);
                ViewBag.VehicleMakeName = vehicleMake.Name;
                return View(editModel);

            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }



        }

        // POST: VehicleModels/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Abrv,MakeId")] EditModel editModel)
        {

            if (id != editModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var vehicleModel = _mapper.Map<EditModel, VehicleModel>(editModel);
                    await _vehicleModelRepository.UpdateVehicleModelAsync(vehicleModel);

                }
                catch (Exception)
                {
                    return RedirectToAction("Error", "Home");
                }
                return RedirectToAction(nameof(Index), new { makeId = editModel.MakeId });
            }
            return View(editModel);

        }

        // GET: VehicleModels/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                var vehicleModel = await _vehicleModelRepository.GetVehicleModelAsync(id);
                var deleteModel = _mapper.Map<VehicleModel, DeleteModel>(vehicleModel);
                return View(deleteModel);
            }

            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }

        }

        // POST: VehicleModels/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, [Bind("Id,Name,Abrv,MakeId")] VehicleModel vehicleModel)
        {

            try
            {
                await _vehicleModelRepository.DeleteVehicleModelAsync(id);

                return RedirectToAction(nameof(Index), new { makeId = vehicleModel.MakeId });

            }

            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        private bool VehicleModelExists(int id)
        {
            _vehicleModelRepository.VehicleModelExists(id);
            return true;
        }


    }
}
