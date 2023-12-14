using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class SentimentTagController : ControllerBase
{
    private readonly SentimentDbContext _context;

        public SentimentTagController(SentimentDbContext context)
            {
                    _context = context;
                        }

                            [HttpGet]
                                public async Task<ActionResult<IEnumerable<SentimentTag>>> GetSentimentTags()
                                    {
                                            return await _context.SentimentTags.ToListAsync();
                                                }

                                                    [HttpGet("{id}")]
                                                        public async Task<ActionResult<SentimentTag>> GetSentimentTag(int id)
                                                            {
                                                                    var sentimentTag = await _context.SentimentTags.FindAsync(id);

                                                                            if (sentimentTag == null)
                                                                                    {
                                                                                                return NotFound();
                                                                                                        }

                                                                                                                return sentimentTag;
                                                                                                                    }

                                                                                                                        [HttpPost]
                                                                                                                            public async Task<ActionResult<SentimentTag>> PostSentimentTag(SentimentTag sentimentTag)
                                                                                                                                {
                                                                                                                                        _context.SentimentTags.Add(sentimentTag);
                                                                                                                                                await _context.SaveChangesAsync();

                                                                                                                                                        return CreatedAtAction(nameof(GetSentimentTag), new { id = sentimentTag.Id }, sentimentTag);
                                                                                                                                                            }

                                                                                                                                                                [HttpPut("{id}")]
                                                                                                                                                                    public async Task<IActionResult> PutSentimentTag(int id, SentimentTag sentimentTag)
                                                                                                                                                                        {
                                                                                                                                                                                if (id != sentimentTag.Id)
                                                                                                                                                                                        {
                                                                                                                                                                                                    return BadRequest();
                                                                                                                                                                                                            }

                                                                                                                                                                                                                    _context.Entry(sentimentTag).State = EntityState.Modified;

                                                                                                                                                                                                                            try
                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                await _context.SaveChangesAsync();
                                                                                                                                                                                                                                                        }
                                                                                                                                                                                                                                                                catch (DbUpdateConcurrencyException)
                                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                                                    if (!SentimentTagExists(id))
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
                                                                                                                                                                                                                                                                                                                                                                                                            public async Task<IActionResult> DeleteSentimentTag(int id)
                                                                                                                                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                                                                                                                                        var sentimentTag = await _context.SentimentTags.FindAsync(id);
                                                                                                                                                                                                                                                                                                                                                                                                                                if (sentimentTag == null)
                                                                                                                                                                                                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                                                                                                                                                                                                                    return NotFound();
                                                                                                                                                                                                                                                                                                                                                                                                                                                            }

                                                                                                                                                                                                                                                                                                                                                                                                                                                                    _context.SentimentTags.Remove(sentimentTag);
                                                                                                                                                                                                                                                                                                                                                                                                                                                                            await _context.SaveChangesAsync();

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    return NoContent();
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        }

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            private bool SentimentTagExists(int id)
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        return _context.SentimentTags.Any(e => e.Id == id);
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            }