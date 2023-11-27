using Microsoft.AspNetCore.Mvc;
using Inpitsu.Servises.Interfaces;
using Inpitsu.Logger;
using Inpitsu.Filters;
using Inpitsu.Data.DtoObjects;
using Microsoft.AspNetCore.Authorization;
using Inpitsu.Repositories.Data;
using Inpitsu.Data.Models;

namespace Inpitsu.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ContragentsController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IServiceManager _service;
        private readonly ApplicationDbContext dbContext;
        public ContragentsController(ILoggerManager logger, IServiceManager service, ApplicationDbContext context)
        {
            _logger = logger;
            _service = service;
            this.dbContext = context;

        }
        [HttpGet]
        public IActionResult Index(PaginationFilter paginationFilter)
        {
            try
            {
                var contragentes = _service.ContragentService.GetAll(trackChanges: false, paginationFilter);
                var contragentesCount = _service.ContragentService.GetContragentCount(trackChanges: false);
                ViewData["contragentCount"] = contragentesCount;
                ViewData["PaginationPageSize"] = paginationFilter.PageSize;
                ViewData["PaginationPageNumber"] = paginationFilter.PageNumber;
                return View("Index", contragentes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }
        public IActionResult Details(Guid Id)
        {
            var contragentes = _service.ContragentService.GetContragent(Id, trackChanges: false);
            return View(contragentes);
        }
        public RedirectToActionResult Cansel()
        {
            return RedirectToAction("Index");
        }
        public RedirectToActionResult Submit([FromForm] ContragentCreateDto contragentCreateDto)
        {
            try
            {
                _service.ContragentService.CreateContragent(contragentCreateDto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return RedirectToAction("Index");
            }
        }
        public IActionResult AddContragent()
        {
            return View("AddContragent");
        }
        [HttpPost]
        public IActionResult AddContragent([FromForm]ContragentCreateDto model)
        {
            Contragent contragent = new Contragent()
            {
                Name = model.Name,
                Description = model.Description,
                Contact = model.Contact,
                Pin = model.Pin,
                Inn = model.Inn,
                Email = model.Email,
                Address = model.Address,
            };
            dbContext.Contragents.Add(contragent);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public RedirectToActionResult Deletecontragent(Guid id)
        {
            try
            {
                _service.ContragentService.DeleteContragent(id, trackChanges: false);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return RedirectToAction("Index");
            }
        }
        public IActionResult Edit(Guid id)
        {
            try
            {
                var contragent = _service.ContragentService.GetContragent(id, trackChanges: false);
                if (contragent == null)
                {
                    return BadRequest();
                }
                
                return View(contragent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Edit([FromForm] ContragentDto model)
        {
            Contragent contragent = dbContext.Contragents.Where(c=>c.Id == model.Id).FirstOrDefault();
            contragent.Name = model.Name;
            contragent.Description = model.Description;
            contragent.Contact = model.Contact;
            contragent.Pin = model.Pin;
            contragent.Inn = model.Inn;
            contragent.Email = model.Email;
            contragent.Address = model.Address;
            
            dbContext.Contragents.Update(contragent);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
