using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class SentimentController : ControllerBase
{
    private readonly SentimentDbContext _context;

        public SentimentController(SentimentDbContext context)
            {
                    _context = context;
                        }

                            [HttpGet]
                                public async Task<ActionResult<IEnumerable<Sentiment>>> GetSentiments()
                                    {
                                            return await _context.Sentiments.ToListAsync();
                                                }

                                                    [HttpGet("{id}")]
                                                        public async Task<ActionResult<Sentiment>> GetSentiment(int id)
                                                            {
                                                                    var sentiment = await _context.Sentiments.FindAsync(id);

                                                                            if (sentiment == null)
                                                                                    {
                                                                                                return NotFound();
                                                                                                        }

                                                                                                                return sentiment;
                                                                                                                    }

                                                                                                                        [HttpPost]
                                                                                                                            public async Task<ActionResult<Sentiment>> PostSentiment(Sentiment sentiment)
                                                                                                                                {
                                                                                                                                        _context.Sentiments.Add(sentiment);
                                                                                                                                                await _context.SaveChangesAsync();

                                                                                                                                                        return CreatedAtAction(nameof(GetSentiment), new { id = sentiment.Id }, sentiment);
                                                                                                                                                            }

                                                                                                                                                                [HttpPut("{id}")]
                                                                                                                                                                    public async Task<IActionResult> PutSentiment(int id, Sentiment sentiment)
                                                                                                                                                                        {
                                                                                                                                                                                if (id != sentiment.Id)
                                                                                                                                                                                        {
                                                                                                                                                                                                    return BadRequest();
                                                                                                                                                                                                            }

                                                                                                                                                                                                                    _context.Entry(sentiment).State = EntityState.Modified;

                                                                                                                                                                                                                            try
                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                await _context.SaveChangesAsync();
                                                                                                                                                                                                                                                        }
                                                                                                                                                                                                                                                                catch (DbUpdateConcurrencyException)
                                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                                                    if (!SentimentExists(id))
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
                                                                                                                                                                                                                                                                                                                                                                                                            public async Task<IActionResult> DeleteSentiment(int id)
                                                                                                                                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                                                                                                                                        var sentiment = await _context.Sentiments.FindAsync(id);
                                                                                                                                                                                                                                                                                                                                                                                                                                if (sentiment == null)
                                                                                                                                                                                                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                                                                                                                                                                                                                    return NotFound();
                                                                                                                                                                                                                                                                                                                                                                                                                                                            }

                                                                                                                                                                                                                                                                                                                                                                                                                                                                    _context.Sentiments.Remove(sentiment);
                                                                                                                                                                                                                                                                                                                                                                                                                                                                            await _context.SaveChangesAsync();

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    return NoContent();
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        }

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            private bool SentimentExists(int id)
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        return _context.Sentiments.Any(e => e.Id == id);
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            }