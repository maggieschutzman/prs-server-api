  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeSuppliesCapstone;

namespace OfficeSuppliesCapstone.Controllers {
    [Route("api/RequestLine")]
    [ApiController]
    public class RequestLinesController : ControllerBase {
        private readonly OfficeSuppliesContext _context;

        public RequestLinesController(OfficeSuppliesContext context) {
            _context = context;
        }

        // GET: api/RequestLines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequestLine>>> GetRequestLine() {
            return await _context.RequestLine.ToListAsync();
        }

        // GET: api/RequestLines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RequestLine>> GetRequestLine(int id) {
            var requestLine = await _context.RequestLine.FindAsync(id);

            if (requestLine == null) {
                return NotFound();
            }

            return requestLine;
        }

        // PUT: api/RequestLines/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequestLine(int id, RequestLine requestLine, int requestId) {
            var request = _context.Request.SingleOrDefault(r => r.Id == requestId);

            if (id != requestLine.Id) {
                return BadRequest();
            }

            _context.Entry(requestLine).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                if (!RequestLineExists(id)) {
                    return NotFound();
                }
                else {
                    throw;
                }
            }
            var success = RecalculateRequestTotal(id);
            if (!RecalculateRequestTotal(requestLine.Request.Id)) {
            }
            return NoContent();
        }

        // POST: api/RequestLines
        [HttpPost]
        public async Task<ActionResult<RequestLine>> PostRequestLine(RequestLine requestLine) {
            _context.RequestLine.Add(requestLine);
            
            try {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException) {
                if (RequestLineExists(requestLine.Id)) {
                    return Conflict();
                }
                if (!RecalculateRequestTotal(requestLine.RequestId)) {

                }
            }
            var success = RecalculateRequestTotal(requestLine.RequestId);

            return CreatedAtAction("GetRequestLine", new { id = requestLine.Id }, requestLine);
        }

        // DELETE: api/RequestLines/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RequestLine>> DeleteRequestLine(int id) {
            var requestLine = await _context.RequestLine.FindAsync(id);
            var request = _context.Request.SingleOrDefault(r => r.Id == requestLine.RequestId);


            if (requestLine == null) {
                return NotFound();
            }

            _context.RequestLine.Remove(requestLine);
            await _context.SaveChangesAsync();

            if (!RecalculateRequestTotal(request.Id)) {

            }
            return requestLine;
        }

        private bool RequestLineExists(int id) {
            return _context.RequestLine.Any(e => e.Id == id);
        }

        // Recalculate the total in the Request
        
        private bool RecalculateRequestTotal(int requestId) {
            var request = _context.Request.SingleOrDefault(r => r.Id == requestId);
            if (request == null) {
                return false;
            }
            request.Total = _context.RequestLine.Include(l => l.Product)
                                    .Where(l => l.RequestId == requestId)
                                    .Sum(l => l.Quantity * l.Product.Price);
            if (request.Status == "REVIEW")
                request.Status = "REVISED";

            _context.SaveChanges();
            return true;
        }
    }
}

