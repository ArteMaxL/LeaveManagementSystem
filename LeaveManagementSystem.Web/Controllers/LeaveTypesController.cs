using LeaveManagementSystem.Web.Models.LeaveTypes;
using LeaveManagementSystem.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Controllers;

public class LeaveTypesController(ILeaveTypesService leaveTypesService) : Controller
{
    private const string NameExistsValidationMessage = "Name already exists";

    // GET: LeaveTypes
    public async Task<IActionResult> Index()
    {
        var viewData = await leaveTypesService.GetAllAsync();
        return View(viewData);
    }

    // GET: LeaveTypes/Details/5
    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null) return BadRequest();

        var leaveType = await leaveTypesService.GetAsync<LeaveTypeReadOnlyVM>(id.Value);

        if (leaveType == null) return NotFound();  

        return View(leaveType);
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
        if (await leaveTypesService.LeaveTypeExistsAsync(name:leaveTypeCreate.Name))
            ModelState.AddModelError(nameof(LeaveTypeCreateVM.Name), NameExistsValidationMessage);      

        if (ModelState.IsValid)
        {
            await leaveTypesService.CreateAsync(leaveTypeCreate);
            return RedirectToAction(nameof(Index));
        }

        return View(leaveTypeCreate);
    }

    // GET: LeaveTypes/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null) return BadRequest();

        var leaveType = await leaveTypesService.GetAsync<LeaveTypeEditVM>(id.Value);

        if (leaveType == null) return NotFound();

        return View(leaveType);
    }

    // POST: LeaveTypes/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, LeaveTypeEditVM leaveTypeEdit)
    {
        if (id != leaveTypeEdit.Id) return NotFound();        

        if (await leaveTypesService.LeaveTypeExistsForEditAsync(leaveTypeEdit))
            ModelState.AddModelError(nameof(LeaveTypeCreateVM.Name), NameExistsValidationMessage);        

        if (ModelState.IsValid)
        {
            try
            {
                await leaveTypesService.EditAsync(leaveTypeEdit);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await leaveTypesService.LeaveTypeExistsAsync(leaveTypeEdit.Id))
                    return NotFound();
                else
                    throw;
            }

            return RedirectToAction(nameof(Index));
        }

        return View(leaveTypeEdit);
    }     

    // GET: LeaveTypes/Delete/5
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null) return BadRequest();

        var leaveType = await leaveTypesService.GetAsync<LeaveTypeReadOnlyVM>(id.Value);

        if (leaveType == null) return NotFound();

        return View(leaveType);
    }

    // POST: LeaveTypes/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        await leaveTypesService.RemoveAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
