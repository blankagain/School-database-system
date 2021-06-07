using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace School_1
{
    [Authorize]
    public class Schooltable1Controller : Controller
    {
        private readonly School_dataContext _context;

        public Schooltable1Controller(School_dataContext context)
        {
            _context = context;
        }

        // GET: Schooltable1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Schooltable1s.ToListAsync());
        }
        //public async Task<IActionResult> Index1()
        //{
        //    return Json(await _context.Schooltable1s.ToListAsync());
        //}
        public async Task<IActionResult> Class1()
        {
            return View(await _context.Schooltable1s.Where(x=>x.Class==1).ToListAsync());
        }
        public async Task<IActionResult> Class2()
        {
            return View(await _context.Schooltable1s.Where(x => x.Class == 2).ToListAsync());
        }
        public async Task<IActionResult> Class3()
        {
            return View(await _context.Schooltable1s.Where(x => x.Class == 3).ToListAsync());
        }
        public async Task<IActionResult> Class4()
        {
            return View(await _context.Schooltable1s.Where(x => x.Class == 4).ToListAsync());
        }
        public async Task<IActionResult> Class5()
        {
            return View(await _context.Schooltable1s.Where(x => x.Class == 5).ToListAsync());
        }
        // GET: Schooltable1/Details/5

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schooltable1 = await _context.Schooltable1s
                .FirstOrDefaultAsync(m => m.SchoolId == id);
            if (schooltable1 == null)
            {
                return NotFound();
            }

            return View(schooltable1);
        }

        // GET: Schooltable1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Schooltable1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,RollNumber,Class,FatherName,MotherName,Age,Height,Gender,SchoolId")] Schooltable1 schooltable1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(schooltable1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(schooltable1);
        }

        // GET: Schooltable1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schooltable1 = await _context.Schooltable1s.FindAsync(id);
            if (schooltable1 == null)
            {
                return NotFound();
            }
            return View(schooltable1);
        }

        // POST: Schooltable1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,RollNumber,Class,FatherName,MotherName,Age,Height,Gender,SchoolId")] Schooltable1 schooltable1)
        {
            if (id != schooltable1.SchoolId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schooltable1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Schooltable1Exists(schooltable1.SchoolId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(schooltable1);
        }

        // GET: Schooltable1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schooltable1 = await _context.Schooltable1s
                .FirstOrDefaultAsync(m => m.SchoolId == id);
            if (schooltable1 == null)
            {
                return NotFound();
            }

            return View(schooltable1);
        }

        // POST: Schooltable1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var schooltable1 = await _context.Schooltable1s.FindAsync(id);
            _context.Schooltable1s.Remove(schooltable1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Schooltable1Exists(int id)
        {
            return _context.Schooltable1s.Any(e => e.SchoolId == id);
        }
    }
}
