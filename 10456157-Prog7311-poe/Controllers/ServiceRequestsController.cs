using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _10456157_Prog7311_poe.Data;
using _10456157_Prog7311_poe.Models;
using _10456157_Prog7311_poe.Services;

namespace _10456157_Prog7311_poe.Controllers
{
    public class ServiceRequestsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ServiceRequestService _service;

        public ServiceRequestsController(AppDbContext context, ServiceRequestService service)
        {
            _context = context;
            _service = service;
        }

        
        public async Task<IActionResult> Index()
        {
            var requests = _context.ServiceRequests.Include(s => s.Contract);
            return View(await requests.ToListAsync());
        }

        
        public IActionResult Create()
        {
            ViewData["ContractId"] = new SelectList(_context.Contracts, "ContractId", "Status");
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Create(ServiceRequest serviceRequest)
        {
            var contract = await _context.Contracts.FindAsync(serviceRequest.ContractId);

            if (!_service.CanCreate(contract))
            {
                ModelState.AddModelError("", "Invalid contract");
            }

            ICostStrategy strategy = contract.ServiceLevel == "Express"
                ? new ExpressStrategy()
                : new StandardStrategy();

            serviceRequest.Cost = strategy.Calculate(serviceRequest.Cost);

            if (!ModelState.IsValid)
            {
                ViewData["ContractId"] = new SelectList(_context.Contracts, "ContractId", "Status");
                return View(serviceRequest);
            }

            _context.Add(serviceRequest);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
