using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class TagController : ControllerBase
{
    private readonly SentimentDbContext _context;

        public TagController(SentimentDbContext context)
            {
                    _context = context;
                        }

                            [HttpGet]
                                public async Task<ActionResult<IEnumerable<Tag>>> GetTags()
                                    {
                                            return await _context.Tags.ToListAsync();
                                                }

                                                    [HttpGet("{id}")]
                                                        public async Task<ActionResult<Tag>> GetTag(int id)
                                                            {
                                                                    var tag = await _context.Tags.FindAsync(id);

                                                                            if (tag == null)
                                                                                    {
                                                                                                return NotFound();
                                                                                                        }

                                                                                                                return tag;
                                                                                                                    }

                                                                                                                        [HttpPost]
                                                                                                                            public async Task<ActionResult<Tag>> PostTag(Tag tag)
                                                                                                                                {
                                                                                                                                        _context.Tags.Add(tag);
                                                                                                                                                await _context.SaveChangesAsync();

                                                                                                                                                        return CreatedAtAction(nameof(GetTag), new { id = tag.Id }, tag);
                                                                                                                                                            }

                                                                                                                                                                [HttpPut("{id}")]
                                                                                                                                                                    public async Task<IActionResult> PutTag(int id, Tag tag)
                                                                                                                                                                        {
                                                                                                                                                                                if (id != tag.Id)
                                                                                                                                                                                        {
                                                                                                                                                                                                    return BadRequest();
                                                                                                                                                                                                            }

                                                                                                                                                                                                                    _context.Entry(tag).State = EntityState.Modified;

                                                                                                                                                                                                                            try
                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                await _context.SaveChangesAsync();
                                                                                                                                                                                                                                                        }
                                                                                                                                                                                                                                                                catch (DbUpdateConcurrencyException)
                                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                                                    if (!TagExists(id))
                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                                return NotFound();
                                                                                                                                                                                                                                                                                                                            }
                                                                                                                                                                                                                                                                                                                                        else
                                                                                                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                                                                                                                    throw;
                                                                                                                                                                                                                                                                                                                                                                                }
                                                                                                                                                                                                                                                                                                                                                                                        }

                                                                                                                                                                                                                                                                                                                                                                                                return NoContent();
                                                                                                                                                                                                                                                                                                                                                                                                    }

                                                                                                                                                                                                                                                                                                                                                                                                        [HttpDelete("{id}")]
                                                                                                                                                                                                                                                                                                                                                                                                            public async Task<IActionResult> DeleteTag(int id)
                                                                                                                                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                                                                                                                                        var tag = await _context.Tags.FindAsync(id);
                                                                                                                                                                                                                                                                                                                                                                                                                                if (tag == null)
                                                                                                                                                                                                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                                                                                                                                                                                                                    return NotFound();
                                                                                                                                                                                                                                                                                                                                                                                                                                                            }

                                                                                                                                                                                                                                                                                                                                                                                                                                                                    _context.Tags.Remove(tag);
                                                                                                                                                                                                                                                                                                                                                                                                                                                                            await _context.SaveChangesAsync();

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    return NoContent();
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        }

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            private bool TagExists(int id)
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        return _context.Tags.Any(e => e.Id == id);
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            }