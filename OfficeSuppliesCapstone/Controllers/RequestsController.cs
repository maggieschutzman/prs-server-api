using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OfficeSuppliesCapstone;
using OfficeSuppliesCapstone.Models;

namespace prs_server.Controllers {
    [Route("api/Requests")]
    [ApiController]
    public class RequestsController : ControllerBase {
        private readonly OfficeSuppliesContext _context;

        public RequestsController(OfficeSuppliesContext context) {
            _context = context;
        }

        // Set request to approved
        [HttpPut("/api/Requests/Approved/{id}")]
        public async Task<IActionResult> SetRequestApproved(int id) {

            var request = await _context.Request.FindAsync(id);

            if (request == null) {
                return NotFound();
            }

            request.Status = "APPROVED";

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Set request to rejected
        [HttpPut("/api/Requests/Rejected/{id}")]
        public async Task<IActionResult> SetRequestRejected(int id) {

            var request = await _context.Request.FindAsync(id);

            if (request == null) {
                return NotFound();
            }

           
            request.Status = "REJECTED";
           

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Set request to review 
        [HttpPut("/api/Requests/Review/{id}")]
        public async Task<IActionResult> SetRequestReview(int id) {

            var request = await _context.Request.FindAsync(id);

            if (request == null) {
                return NotFound();
            }
            if (request.Total <= 50) {
                request.Status = "APPROVED";
            }
            else {
                request.Status = "REVIEW";
            }
            
            await _context.SaveChangesAsync();
           
            return NoContent();
        }

        // GET: api/Requests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Request>>> GetRequests() {
            return await _context.Request.ToListAsync();
        }

        // GET: api/Requests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Request>> GetRequest(int id) {
            var request = await _context.Request.FindAsync(id);

            if (request == null) {
                return NotFound();
            }

            return request;
        }

        // PUT: api/Requests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequest(int id, Request request) {
            if (id != request.Id) {
                return BadRequest();
            }

            _context.Entry(request).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                if (!RequestExists(id)) {
                    return NotFound();
                }
                else {
                    throw;
                }
            }

            return NoContent();
        }







       // POST: api/Request
       [HttpPost]
        public async Task<ActionResult<Request>> PostRequest(Request request) {
            _context.Request.Add(request);
            try {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException) {
                if (RequestExists(request.Id)) {
                    return Conflict();
                }
                else {
                    throw;
                }
            }

            return CreatedAtAction("GetRequest", new { id = request.Id }, request);
        }


        //  POST: api/Requests
        //[HttpPost]
        // public async Task<ActionResult<Request>> PostRequest(Request request) {
        //     _context.Request.Add(request);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("GetRequest", new { id = request.Id }, request);
        // }


        // DELETE: api/Requests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Request>> DeleteRequest(int id) {
            var request = await _context.Request.FindAsync(id);
            if (request == null) {
                return NotFound();
            }

            _context.Request.Remove(request);
            await _context.SaveChangesAsync();

            return request;
        }

        private bool RequestExists(int id) {
            return _context.Request.Any(e => e.Id == id);
        }
    }
}
