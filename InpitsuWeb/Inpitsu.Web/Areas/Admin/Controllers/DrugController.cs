using System;
using System.Linq;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Inpitsu.Repositories.Data;
using Inpitsu.Web.ViewModels;
using Inpitsu.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Inpitsu.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class DrugsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public DrugsController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }
        public IActionResult CreateComing()
        {
            ComingDrugCreate comingDrugCreate = new ComingDrugCreate();
            comingDrugCreate.Contragents = dbContext.Contragents.ToList();
            return View(comingDrugCreate);
        }
        [HttpPost]
        public IActionResult CreateComing([FromForm]ComingDrugCreate comingDrugCreate)
        {
            ComingDrug comingDrug = new ComingDrug();
            comingDrug.NameOfComing = comingDrugCreate.NameOfComing;
            comingDrug.Contragent = dbContext.Contragents.Where(c=>c.Id == comingDrugCreate.Id).FirstOrDefault();
            dbContext.ComingDrug.Add(comingDrug);
            dbContext.SaveChanges();
            comingDrugCreate.ComingDrug = dbContext.ComingDrug.Where(c=>c.NameOfComing==comingDrugCreate.NameOfComing).FirstOrDefault();
            comingDrugCreate.Id = comingDrugCreate.ComingDrug.ID;
            return View("ShowComing",comingDrugCreate);
        }
        [HttpPost]
        public IActionResult ShowComing([FromForm] ComingDrugCreate comingDrugCreate)
        {
            comingDrugCreate.ComingDrug = dbContext.ComingDrug.Where(c => c.ID == comingDrugCreate.Id).FirstOrDefault();
            comingDrugCreate.Id = comingDrugCreate.ComingDrug.ID;
            
            
            return View("CreateDrug", comingDrugCreate);
        }
        
        [HttpPost]
        public IActionResult CreateDrug([FromForm] ComingDrugCreate comingDrugCreate)
        {
            Drug drug = new Drug();
            drug.NameOfDrug = comingDrugCreate.NameOfDrug;
            drug.ComingPrice = comingDrugCreate.ComingPrice;
            drug.Creator = comingDrugCreate.Creator;
            drug.Counts = comingDrugCreate.Counts;
            drug.ComingDrug = dbContext.ComingDrug.Where(c => c.ID == comingDrugCreate.Id).FirstOrDefault();
            dbContext.Drug.Add(drug);
            dbContext.SaveChanges();
            comingDrugCreate.ComingDrug = dbContext.ComingDrug.Where(c => c.ID == comingDrugCreate.Id).FirstOrDefault();
            comingDrugCreate.Id = comingDrugCreate.ComingDrug.ID;
            comingDrugCreate.NameOfComing = comingDrugCreate.ComingDrug.NameOfComing;
            comingDrugCreate.Drugss = new List<Drug>();
            var drugs = dbContext.Drug.Where(c => c.ComingDrug.ID == comingDrugCreate.Id).ToList();
            if (drugs.Any())
            {
                comingDrugCreate.Drugss.AddRange(drugs);
            }
            return View("ShowComing", comingDrugCreate);
        }
        public IActionResult GetAllDrugs()
        {
            var drugs = dbContext.Drug.Where(c => c.Counts > 0).Include(c=>c.ComingDrug).ToList();
            return View(drugs);
        }
        public IActionResult GetComingDrug(string Id)
        {
            var comingDrug = dbContext.ComingDrug.Where(c => c.ID == Guid.Parse(Id)).FirstOrDefault();
            var drugs = dbContext.Drug.Where(c => c.ComingDrug.ID == comingDrug.ID).ToList();
            ComingDrugCreate comingDrugCreate = new ComingDrugCreate();
            comingDrugCreate.Drugss = new List<Drug>();
            comingDrugCreate.Drugss.AddRange(drugs);
            comingDrugCreate.ComingDrug = comingDrug;
            comingDrugCreate.NameOfComing = comingDrug.NameOfComing;
            return View(comingDrugCreate);
        }
        public IActionResult GetAllComings()
        {
            var comings = dbContext.ComingDrug.Include(c=>c.Drugss).ToList();
            return View(comings);
        }
        public IActionResult CreateReleaseDrugs()
        {
            ReleaseDrugsViewModel releaseDrugsViewModel = new ReleaseDrugsViewModel();
            releaseDrugsViewModel.Contragents = dbContext.Contragents.ToList();
            return View(releaseDrugsViewModel);
        }
        [HttpPost]
        public IActionResult CreateReleaseDrugs(ReleaseDrugsViewModel releaseDrugsViewModel)
        {
            var relDrug = new ReleaseDrugs();
            relDrug.Name = releaseDrugsViewModel.Name;
            relDrug.ReleaseDate = DateTime.Now;
            relDrug.ContragentId = releaseDrugsViewModel.ContragentId;
            dbContext.ReleaseDrugs.Add(relDrug);
            dbContext.SaveChanges();
            releaseDrugsViewModel.Id = dbContext.ReleaseDrugs.Where(c=>c.Name == relDrug.Name && c.ContragentId == relDrug.ContragentId).FirstOrDefault().Id;
            releaseDrugsViewModel.DrugListAll = dbContext.Drug.Where(c => c.Counts > 0).ToList();
            releaseDrugsViewModel.Contragent = dbContext.Contragents.Where(c => c.Id == releaseDrugsViewModel.ContragentId).FirstOrDefault();
            return View("ReleaseWithDrugs",releaseDrugsViewModel);
        }
        [HttpPost]
        public IActionResult ReleaseWithDrugs(ReleaseDrugsViewModel releaseDrugsViewModel)
        {
            var drug = dbContext.Drug.Where(c=>c.Id == releaseDrugsViewModel.DrugId).FirstOrDefault();
            drug.ReleaseDrug = dbContext.ReleaseDrugs.Where(c => c.Id == releaseDrugsViewModel.Id).FirstOrDefault();
            var relDrugItem = new ReleaseDrugItem();
            relDrugItem.NameOfDrug = drug.NameOfDrug;
            relDrugItem.Counts = releaseDrugsViewModel.Counts;
            relDrugItem.Creator = drug.Creator;
            relDrugItem.ComingPrice = drug.ComingPrice;
            relDrugItem.ReleaseDrug = drug.ReleaseDrug;
            releaseDrugsViewModel.Contragent = dbContext.Contragents.Where(c=>c.Id == releaseDrugsViewModel.ContragentId).FirstOrDefault();
            if (relDrugItem.Counts > drug.Counts)
            {
                var drugss = dbContext.ReleaseDrugItems.Where(c => c.ReleaseDrug.Id == releaseDrugsViewModel.Id).ToList();
                releaseDrugsViewModel.DrugList = new List<ReleaseDrugItem>();
                releaseDrugsViewModel.DrugList.AddRange(drugss);
                releaseDrugsViewModel.DrugListAll = dbContext.Drug.ToList();
                return View(releaseDrugsViewModel);
            }
            else
            {
                if ((drug.Counts -= relDrugItem.Counts) <= 0)
                {
                    dbContext.Drug.Remove(drug);
                }
                else
                {
                    drug.Counts -= relDrugItem.Counts;
                    dbContext.Drug.Update(drug);
                }
            }
            dbContext.ReleaseDrugItems.Add(relDrugItem);
            
            
            dbContext.SaveChanges();
            var drugs = dbContext.ReleaseDrugItems.Where(c=>c.ReleaseDrug.Id == releaseDrugsViewModel.Id).ToList();
            releaseDrugsViewModel.DrugList = new List<ReleaseDrugItem>();
            releaseDrugsViewModel.DrugList.AddRange(drugs);
            releaseDrugsViewModel.DrugListAll = dbContext.Drug.Where(c=>c.Counts > 0).ToList();
            return View(releaseDrugsViewModel);
        }
        public IActionResult GetAllReleaseDrugs()
        {
            var release = dbContext.ReleaseDrugs.ToList();

            return View(release);
        }
        public IActionResult GetReleaseDrug(Guid Id)
        {
            var release = dbContext.ReleaseDrugs.Where(c => c.Id == Id).Include(c => c.DrugList).Include(c=>c.Contragent).FirstOrDefault();
            return View("GetReleaseDrug", release);
        }
    }
}
