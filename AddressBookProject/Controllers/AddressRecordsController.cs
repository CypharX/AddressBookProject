using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AddressBookProject.Data;
using AddressBookProject.Models;
using Microsoft.AspNetCore.Http;
using AddressBookProject.Services;

namespace AddressBookProject.Controllers
{
    public class AddressRecordsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddressRecordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AddressRecords
        public async Task<IActionResult> Index()
        {
            var states = new List<SelectListItem>()
            {
                 new SelectListItem() {Text="Alabama", Value="AL"},
                 new SelectListItem() { Text="Alaska", Value="AK"},
                 new SelectListItem() { Text="Arizona", Value="AZ"},
                 new SelectListItem() { Text="Arkansas", Value="AR"},
                 new SelectListItem() { Text="California", Value="CA"},
                 new SelectListItem() { Text="Colorado", Value="CO"},
                 new SelectListItem() { Text="Connecticut", Value="CT"},
                 new SelectListItem() { Text="Washington DC", Value="DC"},
                 new SelectListItem() { Text="Delaware", Value="DE"},
                 new SelectListItem() { Text="Florida", Value="FL"},
                 new SelectListItem() { Text="Georgia", Value="GA"},
                 new SelectListItem() { Text="Hawaii", Value="HI"},
                 new SelectListItem() { Text="Idaho", Value="ID"},
                 new SelectListItem() { Text="Illinois", Value="IL"},
                 new SelectListItem() { Text="Indiana", Value="IN"},
                 new SelectListItem() { Text="Iowa", Value="IA"},
                 new SelectListItem() { Text="Kansas", Value="KS"},
                 new SelectListItem() { Text="Kentucky", Value="KY"},
                 new SelectListItem() { Text="Louisiana", Value="LA"},
                 new SelectListItem() { Text="Maine", Value="ME"},
                 new SelectListItem() { Text="Maryland", Value="MD"},
                 new SelectListItem() { Text="Massachusetts", Value="MA"},
                 new SelectListItem() { Text="Michigan", Value="MI"},
                 new SelectListItem() { Text="Minnesota", Value="MN"},
                 new SelectListItem() { Text="Mississippi", Value="MS"},
                 new SelectListItem() { Text="Missouri", Value="MO"},
                 new SelectListItem() { Text="Montana", Value="MT"},
                 new SelectListItem() { Text="Nebraska", Value="NE"},
                 new SelectListItem() { Text="Nevada", Value="NV"},
                 new SelectListItem() { Text="New Hampshire", Value="NH"},
                 new SelectListItem() { Text="New Jersey", Value="NJ"},
                 new SelectListItem() { Text="New Mexico", Value="NM"},
                 new SelectListItem() { Text="New York", Value="NY"},
                 new SelectListItem() { Text="North Carolina", Value="NC"},
                 new SelectListItem() { Text="North Dakota", Value="ND"},
                 new SelectListItem() { Text="Ohio", Value="OH"},
                 new SelectListItem() { Text="Oklahoma", Value="OK"},
                 new SelectListItem() { Text="Oregon", Value="OR"},
                 new SelectListItem() { Text="Pennsylvania", Value="PA"},
                 new SelectListItem() { Text="Rhode Island", Value="RI"},
                 new SelectListItem() { Text="South Carolina", Value="SC"},
                 new SelectListItem() { Text="South Dakota", Value="SD"},
                 new SelectListItem() { Text="Tennessee", Value="TN"},
                 new SelectListItem() { Text="Texas", Value="TX"},
                 new SelectListItem() { Text="Utah", Value="UT"},
                 new SelectListItem() { Text="Vermont", Value="VT"},
                 new SelectListItem() { Text="Virginia", Value="VA"},
                 new SelectListItem() { Text="Washington", Value="WA"},
                 new SelectListItem() { Text="West Virginia", Value="WV"},
                 new SelectListItem() { Text="Wisconsin", Value="WI"},
                 new SelectListItem() { Text="Wyoming", Value="WY"}
            };
            ViewData["StateList"] = new SelectList(states, "Value", "Text");

            return View(await _context.AddressRecord.ToListAsync());
        }

        // GET: AddressRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addressRecord = await _context.AddressRecord
                .FirstOrDefaultAsync(m => m.id == id);
            if (addressRecord == null)
            {
                return NotFound();
            }

            return View(addressRecord);
        }

        // GET: AddressRecords/Create
        public IActionResult Create()
        {
            var states = new List<SelectListItem>()
            {
                 new SelectListItem() {Text="Alabama", Value="AL"},
                 new SelectListItem() { Text="Alaska", Value="AK"},
                 new SelectListItem() { Text="Arizona", Value="AZ"},
                 new SelectListItem() { Text="Arkansas", Value="AR"},
                 new SelectListItem() { Text="California", Value="CA"},
                 new SelectListItem() { Text="Colorado", Value="CO"},
                 new SelectListItem() { Text="Connecticut", Value="CT"},
                 new SelectListItem() { Text="Washington DC", Value="DC"},
                 new SelectListItem() { Text="Delaware", Value="DE"},
                 new SelectListItem() { Text="Florida", Value="FL"},
                 new SelectListItem() { Text="Georgia", Value="GA"},
                 new SelectListItem() { Text="Hawaii", Value="HI"},
                 new SelectListItem() { Text="Idaho", Value="ID"},
                 new SelectListItem() { Text="Illinois", Value="IL"},
                 new SelectListItem() { Text="Indiana", Value="IN"},
                 new SelectListItem() { Text="Iowa", Value="IA"},
                 new SelectListItem() { Text="Kansas", Value="KS"},
                 new SelectListItem() { Text="Kentucky", Value="KY"},
                 new SelectListItem() { Text="Louisiana", Value="LA"},
                 new SelectListItem() { Text="Maine", Value="ME"},
                 new SelectListItem() { Text="Maryland", Value="MD"},
                 new SelectListItem() { Text="Massachusetts", Value="MA"},
                 new SelectListItem() { Text="Michigan", Value="MI"},
                 new SelectListItem() { Text="Minnesota", Value="MN"},
                 new SelectListItem() { Text="Mississippi", Value="MS"},
                 new SelectListItem() { Text="Missouri", Value="MO"},
                 new SelectListItem() { Text="Montana", Value="MT"},
                 new SelectListItem() { Text="Nebraska", Value="NE"},
                 new SelectListItem() { Text="Nevada", Value="NV"},
                 new SelectListItem() { Text="New Hampshire", Value="NH"},
                 new SelectListItem() { Text="New Jersey", Value="NJ"},
                 new SelectListItem() { Text="New Mexico", Value="NM"},
                 new SelectListItem() { Text="New York", Value="NY"},
                 new SelectListItem() { Text="North Carolina", Value="NC"},
                 new SelectListItem() { Text="North Dakota", Value="ND"},
                 new SelectListItem() { Text="Ohio", Value="OH"},
                 new SelectListItem() { Text="Oklahoma", Value="OK"},
                 new SelectListItem() { Text="Oregon", Value="OR"},
                 new SelectListItem() { Text="Pennsylvania", Value="PA"},
                 new SelectListItem() { Text="Rhode Island", Value="RI"},
                 new SelectListItem() { Text="South Carolina", Value="SC"},
                 new SelectListItem() { Text="South Dakota", Value="SD"},
                 new SelectListItem() { Text="Tennessee", Value="TN"},
                 new SelectListItem() { Text="Texas", Value="TX"},
                 new SelectListItem() { Text="Utah", Value="UT"},
                 new SelectListItem() { Text="Vermont", Value="VT"},
                 new SelectListItem() { Text="Virginia", Value="VA"},
                 new SelectListItem() { Text="Washington", Value="WA"},
                 new SelectListItem() { Text="West Virginia", Value="WV"},
                 new SelectListItem() { Text="Wisconsin", Value="WI"},
                 new SelectListItem() { Text="Wyoming", Value="WY"}
            };
            ViewData["StateList"] = new SelectList(states, "Value", "Text");
            return View();
        }

        // POST: AddressRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Email,ImagePath,ImageData,Address1,Address2,City,State,ZipCode,PhoneNumber,Created,Updated,Note")] AddressRecord addressRecord, IFormFile imageData)
        {
            if (ModelState.IsValid)
            {
                if (imageData != null)
                {
                    addressRecord.ImagePath = imageData.FileName;
                    addressRecord.ImageData = AvatarHelper.EncodeImage(imageData);
                }             
                addressRecord.Created = DateTime.Now;
                var truncPhone = addressRecord.PhoneNumber
                    .Replace(" ", "")
                    .Replace("(", "")
                    .Replace(")", "")
                    .Replace("-", "");

                var formated = $"({truncPhone.Substring(0, 3)}) {truncPhone.Substring(3, 3)}-{truncPhone.Substring(6, 4)}";
                addressRecord.PhoneNumber = formated;
                _context.Add(addressRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(addressRecord);
        }

        // GET: AddressRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addressRecord = await _context.AddressRecord.FindAsync(id);
            if (addressRecord == null)
            {
                return NotFound();
            }

            var states = new List<SelectListItem>()
            {
                 new SelectListItem() {Text="Alabama", Value="AL"},
                 new SelectListItem() { Text="Alaska", Value="AK"},
                 new SelectListItem() { Text="Arizona", Value="AZ"},
                 new SelectListItem() { Text="Arkansas", Value="AR"},
                 new SelectListItem() { Text="California", Value="CA"},
                 new SelectListItem() { Text="Colorado", Value="CO"},
                 new SelectListItem() { Text="Connecticut", Value="CT"},
                 new SelectListItem() { Text="Washington DC", Value="DC"},
                 new SelectListItem() { Text="Delaware", Value="DE"},
                 new SelectListItem() { Text="Florida", Value="FL"},
                 new SelectListItem() { Text="Georgia", Value="GA"},
                 new SelectListItem() { Text="Hawaii", Value="HI"},
                 new SelectListItem() { Text="Idaho", Value="ID"},
                 new SelectListItem() { Text="Illinois", Value="IL"},
                 new SelectListItem() { Text="Indiana", Value="IN"},
                 new SelectListItem() { Text="Iowa", Value="IA"},
                 new SelectListItem() { Text="Kansas", Value="KS"},
                 new SelectListItem() { Text="Kentucky", Value="KY"},
                 new SelectListItem() { Text="Louisiana", Value="LA"},
                 new SelectListItem() { Text="Maine", Value="ME"},
                 new SelectListItem() { Text="Maryland", Value="MD"},
                 new SelectListItem() { Text="Massachusetts", Value="MA"},
                 new SelectListItem() { Text="Michigan", Value="MI"},
                 new SelectListItem() { Text="Minnesota", Value="MN"},
                 new SelectListItem() { Text="Mississippi", Value="MS"},
                 new SelectListItem() { Text="Missouri", Value="MO"},
                 new SelectListItem() { Text="Montana", Value="MT"},
                 new SelectListItem() { Text="Nebraska", Value="NE"},
                 new SelectListItem() { Text="Nevada", Value="NV"},
                 new SelectListItem() { Text="New Hampshire", Value="NH"},
                 new SelectListItem() { Text="New Jersey", Value="NJ"},
                 new SelectListItem() { Text="New Mexico", Value="NM"},
                 new SelectListItem() { Text="New York", Value="NY"},
                 new SelectListItem() { Text="North Carolina", Value="NC"},
                 new SelectListItem() { Text="North Dakota", Value="ND"},
                 new SelectListItem() { Text="Ohio", Value="OH"},
                 new SelectListItem() { Text="Oklahoma", Value="OK"},
                 new SelectListItem() { Text="Oregon", Value="OR"},
                 new SelectListItem() { Text="Pennsylvania", Value="PA"},
                 new SelectListItem() { Text="Rhode Island", Value="RI"},
                 new SelectListItem() { Text="South Carolina", Value="SC"},
                 new SelectListItem() { Text="South Dakota", Value="SD"},
                 new SelectListItem() { Text="Tennessee", Value="TN"},
                 new SelectListItem() { Text="Texas", Value="TX"},
                 new SelectListItem() { Text="Utah", Value="UT"},
                 new SelectListItem() { Text="Vermont", Value="VT"},
                 new SelectListItem() { Text="Virginia", Value="VA"},
                 new SelectListItem() { Text="Washington", Value="WA"},
                 new SelectListItem() { Text="West Virginia", Value="WV"},
                 new SelectListItem() { Text="Wisconsin", Value="WI"},
                 new SelectListItem() { Text="Wyoming", Value="WY"}
            };
            ViewData["StateList"] = new SelectList(states, "Value", "Text");

            return View(addressRecord);
        }

        // POST: AddressRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,FirstName,LastName,Email,ImagePath,ImageData,Address1,Address2,City,State,ZipCode,PhoneNumber,Created,Note")] AddressRecord addressRecord, IFormFile imageData)
        {
            if (id != addressRecord.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (imageData != null)
                    {
                        addressRecord.ImagePath = imageData.FileName;
                        addressRecord.ImageData = AvatarHelper.EncodeImage(imageData);
                    }
                    addressRecord.Updated = DateTime.Now;
                    _context.Update(addressRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressRecordExists(addressRecord.id))
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
            return View(addressRecord);
        }

        // GET: AddressRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addressRecord = await _context.AddressRecord
                .FirstOrDefaultAsync(m => m.id == id);
            if (addressRecord == null)
            {
                return NotFound();
            }

            return View(addressRecord);
        }

        // POST: AddressRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var addressRecord = await _context.AddressRecord.FindAsync(id);
            _context.AddressRecord.Remove(addressRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddressRecordExists(int id)
        {
            return _context.AddressRecord.Any(e => e.id == id);
        }
    }
}
