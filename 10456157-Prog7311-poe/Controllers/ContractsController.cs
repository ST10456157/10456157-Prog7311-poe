using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _10456157_Prog7311_poe.Data;
using _10456157_Prog7311_poe.Models;

namespace _10456157_Prog7311_poe.Controllers
{
    public class ContractsController : Controller
    {
        private readonly AppDbContext _context;

        public ContractsController(AppDbContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            var contracts = _context.Contracts.Include(c => c.Client);
            return View(await contracts.ToListAsync());
        }

        
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Contract contract, IFormFile file)
        {
            
            if (contract.ClientId <= 0)
            {
                ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "Name");
                ModelState.AddModelError("", "Please select a client.");
                return View(contract);
            }

            
            if (file == null || file.Length == 0)
            {
                ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "Name");
                ModelState.AddModelError("", "Please upload a PDF file.");
                return View(contract);
            }

            
            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files");

            Directory.CreateDirectory(folder);

            var path = Path.Combine(folder, fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

           
            contract.FilePath = "/files/" + fileName;

            
            _context.Contracts.Add(contract);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var contract = await _context.Contracts
                .Include(c => c.Client)
                .FirstOrDefaultAsync(m => m.ContractId == id);

            if (contract == null) return NotFound();

            return View(contract);
        }

       
        public IActionResult Download(string filePath)
        {
            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filePath.TrimStart('/'));
            return PhysicalFile(fullPath, "application/pdf");
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var contract = await _context.Contracts
                .Include(c => c.Client)
                .FirstOrDefaultAsync(m => m.ContractId == id);

            return View(contract);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contract = await _context.Contracts.FindAsync(id);
            _context.Contracts.Remove(contract);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
