using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using c11.Models;

namespace c11.Controllers{
    public class MedicamentsController : Controller{
        private readonly s18911Context _context;

        public MedicamentsController(s18911Context context){
            _context = context;
        }

        // GET: Medicaments
        public async Task<IActionResult> Index(){
            return View(await _context.Medicament.ToListAsync());
        }

        // GET: Medicaments/Details/5
        public async Task<IActionResult> Details(int? id){
            if (id == null){
                return NotFound();
            }

            var medicament = await _context.Medicament
                .FirstOrDefaultAsync(m => m.IdMedicament == id);
            if (medicament == null){
                return NotFound();
            }

            return View(medicament);
        }

        public IActionResult Search() {
            return View();
        }

        [HttpPost]
        public IActionResult Search(string SearchName) {
            var medicament = new Medicament();
            if (_context.Medicament.Where(m => m.Name == SearchName).Any()){
                medicament = _context.Medicament.SingleOrDefault(m => m.Name == SearchName);
            }
            else{
                medicament = null;
            }
            return View(medicament);
        }

        // GET: Medicaments/Create
        public IActionResult Create(){
            return View();
        }

        // POST: Medicaments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMedicament,Name,Description,Type")] Medicament medicament){
            if (ModelState.IsValid){
                _context.Add(medicament);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicament);
        }

        // GET: Medicaments/Edit/5
        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            var medicament = await _context.Medicament.FindAsync(id);
            if (medicament == null){
                return NotFound();
            }
            return View(medicament);
        }

        // POST: Medicaments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMedicament,Name,Description,Type")] Medicament medicament){
            if (id != medicament.IdMedicament){
                return NotFound();
            }

            if (ModelState.IsValid){
                try{
                    _context.Update(medicament);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!MedicamentExists(medicament.IdMedicament)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(medicament);
        }

        // GET: Medicaments/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            var medicament = await _context.Medicament
                .FirstOrDefaultAsync(m => m.IdMedicament == id);
            if (medicament == null){
                return NotFound();
            }

            return View(medicament);
        }

        // POST: Medicaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id){
            var medicament = await _context.Medicament.FindAsync(id);
            _context.Medicament.Remove(medicament);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicamentExists(int id){
            return _context.Medicament.Any(e => e.IdMedicament == id);
        }
    }
}
