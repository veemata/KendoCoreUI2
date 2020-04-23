using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MH.PLCM.Core.Entities;
using MH.PLCM.Data;

namespace MH.PLCM.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DynamicFeaturesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DynamicFeaturesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/DynamicFeatures
        public async Task<IActionResult> Index()
        {
            return View(await _context.DynamicFeatures.ToListAsync());
        }

        // GET: Admin/DynamicFeatures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dynamicFeature = await _context.DynamicFeatures
                .FirstOrDefaultAsync(m => m.RowId == id);
            if (dynamicFeature == null)
            {
                return NotFound();
            }

            return View(dynamicFeature);
        }

        // GET: Admin/DynamicFeatures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/DynamicFeatures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RowId,Description,DataTypeId,LookupId,ReportGroupId,GroupOrder,DefaultValue,UnitOfMeasure,IsBaanFeature,ResponsibleGroupId,Active")] DynamicFeature dynamicFeature)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dynamicFeature);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dynamicFeature);
        }

        // GET: Admin/DynamicFeatures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dynamicFeature = await _context.DynamicFeatures.FindAsync(id);
            if (dynamicFeature == null)
            {
                return NotFound();
            }
            return View(dynamicFeature);
        }

        // POST: Admin/DynamicFeatures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RowId,Description,DataTypeId,LookupId,ReportGroupId,GroupOrder,DefaultValue,UnitOfMeasure,IsBaanFeature,ResponsibleGroupId,Active")] DynamicFeature dynamicFeature)
        {
            if (id != dynamicFeature.RowId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dynamicFeature);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DynamicFeatureExists(dynamicFeature.RowId))
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
            return View(dynamicFeature);
        }

        // GET: Admin/DynamicFeatures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dynamicFeature = await _context.DynamicFeatures
                .FirstOrDefaultAsync(m => m.RowId == id);
            if (dynamicFeature == null)
            {
                return NotFound();
            }

            return View(dynamicFeature);
        }

        // POST: Admin/DynamicFeatures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dynamicFeature = await _context.DynamicFeatures.FindAsync(id);
            _context.DynamicFeatures.Remove(dynamicFeature);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DynamicFeatureExists(int id)
        {
            return _context.DynamicFeatures.Any(e => e.RowId == id);
        }
    }
}
