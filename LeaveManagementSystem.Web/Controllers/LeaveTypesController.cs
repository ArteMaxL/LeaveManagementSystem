using AutoMapper;
using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Models.LeaveTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Controllers
{
    public class LeaveTypesController(ApplicationDbContext context, IMapper mapper) : Controller
    {
        private const string NameExistsValidationMessage = "Name already exists";

        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
            var data = await context.LeaveTypes.ToListAsync();
            //var viewData = data.Select(v => new IndexVM
            //{
            //    Id = v.Id,
            //    Name = v.Name,
            //    NumberOfDays = v.NumberOfDays,
            //});

            var viewData = mapper.Map<List<LeaveTypeReadOnlyVM>>(data);

            return View(viewData);
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveType = await context.LeaveTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveType == null)
            {
                return NotFound();
            }

            var viewModel = mapper.Map<LeaveTypeReadOnlyVM>(leaveType);

            return View(viewModel);
        }

        // GET: LeaveTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveTypeCreateVM leaveTypeCreate)
        {
            if (await LeaveTypeExistsAsync(name: leaveTypeCreate.Name))
            {
                ModelState.AddModelError(nameof(LeaveTypeCreateVM.Name), NameExistsValidationMessage);
            }

            if (ModelState.IsValid)
            {
                var leaveType = mapper.Map<LeaveType>(leaveTypeCreate);
                context.Add(leaveType);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeCreate);
        }

        // GET: LeaveTypes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveType = await context.LeaveTypes.FindAsync(id);
            if (leaveType == null)
            {
                return NotFound();
            }

            var viewData = mapper.Map<LeaveTypeEditVM>(leaveType);

            return View(viewData);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, LeaveTypeEditVM leaveTypeEdit)
        {
            if (id != leaveTypeEdit.Id)
            {
                return NotFound();
            }

            if (await LeaveTypeExistsForEditAsync(leaveTypeEdit))
            {
                ModelState.AddModelError(nameof(LeaveTypeCreateVM.Name), NameExistsValidationMessage);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var leaveType = mapper.Map<LeaveType>(leaveTypeEdit);
                    context.Update(leaveType);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await LeaveTypeExistsAsync(leaveTypeEdit.Id))
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
            return View(leaveTypeEdit);
        }     

        // GET: LeaveTypes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveType = await context.LeaveTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveType == null)
            {
                return NotFound();
            }

            var viewData = mapper.Map<LeaveTypeReadOnlyVM>(leaveType);
            return View(viewData);
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var leaveType = await context.LeaveTypes.FindAsync(id);
            if (leaveType != null)
            {
                context.LeaveTypes.Remove(leaveType);
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> LeaveTypeExistsAsync(Guid? id = null, string? name = null)
        {
            return await context.LeaveTypes.AnyAsync(e =>
                (id != null && e.Id == id) ||
                (name != null &&  e.Name.ToLower() == name.ToLower())
            );
        }

        private async Task<bool> LeaveTypeExistsForEditAsync(LeaveTypeEditVM leaveTypeEdit)
        {
            var lowerCaseName = leaveTypeEdit.Name.ToLower();
            return await context.LeaveTypes.AnyAsync(e => 
                e.Name.ToLower().Equals(lowerCaseName) &&
                e.Id != leaveTypeEdit.Id);
        }
    }
}
