using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyGarageApp.Data;
using MyGarageApp.Models;

namespace MyGarageApp.Pages.Services
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public DetailsModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public ServiceHeader serviceHeader { get; set; }
        public List<ServiceDetails> serviceDetails { get; set; }
        public void OnGet(int serviceId)
        {
            serviceHeader = _db.ServiceHeader.Include(s => s.Car).Include(s => s.Car.ApplicationUser).FirstOrDefault(s=>s.Id==serviceId);
            serviceDetails = _db.ServiceDetails.Where(s => s.ServiceHeaderId == serviceId).ToList();
        }
    }
}
