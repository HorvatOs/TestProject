using AutoMapper;
using AutoMapper.QueryableExtensions;
using Vehicle.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.DAL.Models;
using Vehicle.Api.Paging;
using Vehicle.Model.Models;
using Vehicle.Repository.Common.Models;


namespace Vehicle.Controllers
{
    public class VehicleMakeController : Controller
    {

        private readonly IVHMakeRepository _vehicleMakeRepository;
        private readonly IMapper _mapper;
        private readonly int _pageSize = 7;
        IConfigurationProvider _cfg;

        public VehicleMakeController(IVHMakeRepository vehicleMakeRepository, IMapper mapper, IConfigurationProvider cfg)
        {

            _vehicleMakeRepository = vehicleMakeRepository;
            _mapper = mapper;
            _cfg = cfg;
        }

        public async Task<IActionResult> Index(int pageindex = 1, string sort = "Name", string search = "")
        {

            var queryParams = new VehicleMakePaging { PageIndex = pageindex, Sort = sort, Search = search, PageSize = _pageSize };

            var query = _vehicleMakeRepository.GetVehicleMakesPaged(queryParams).ProjectTo<IndexMake>(_cfg);
            var page = await PagingList.CreateAsync(query, queryParams.PageSize, queryParams.PageIndex, queryParams.Sort, queryParams.Sort);

            page.RouteValue = new RouteValueDictionary
            {
                { "search", search }
            };

            return View(page);
        }

        // GET: VehicleMakes/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try

            {

                var vehicleMake = await _vehicleMakeRepository.GetVehicleMakeAsync(id);
                var detailsMake = _mapper.Map<VehicleMake, DetailsMake>(vehicleMake);
                return View(detailsMake);

            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }



        // GET: VehicleMakes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleMakes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Abrv")] CreateMake createMake)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var vehicleMake = _mapper.Map<CreateMake, VehicleMake>(createMake);
                    var numberOfSaves = await _vehicleMakeRepository.CreateVehicleMakeAsync(vehicleMake);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    return RedirectToAction("Error", "Home");
                }


            }
            return View(createMake);
        }


        // GET: VehicleMakes/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var vehicleMake = await _vehicleMakeRepository.GetVehicleMakeAsync(id);
                var editMake = _mapper.Map<VehicleMake, EditMake>(vehicleMake);
                return View(editMake);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }

        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Abrv")] EditMake editMake)
        {
            if (id != editMake.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var vehicleMake = _mapper.Map<EditMake, VehicleMake>(editMake);
                    var numberOfChanges = await _vehicleMakeRepository.UpdateVehicleMakeAsync(vehicleMake);
                }
                catch (Exception)
                {
                    return RedirectToAction("Error", "Home");
                }
                return RedirectToAction(nameof(Index));
            }
            return View(editMake);
        }


        // GET: VehicleMakes/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                var vehicleMake = await _vehicleMakeRepository.GetVehicleMakeAsync(id);
                var deleteMake = _mapper.Map<VehicleMake, DeleteMake>(vehicleMake);
                return View(deleteMake);
            }

            catch (Exception)
            {
                return RedirectToAction("Error", "Home");

            }

        }

        // POST: VehicleMakes/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //[HttpDelete]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var vehicleMake = await _vehicleMakeRepository.DeleteVehicleMakeAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }


        }




    }
}
