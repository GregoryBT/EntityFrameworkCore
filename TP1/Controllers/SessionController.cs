using Microsoft.AspNetCore.Mvc;
using TP1.Models;

namespace TP1.Controllers;

[ApiController]
[Route("[controller]")]
public class SessionController : ControllerBase
{
    private readonly ILogger<SessionController> _logger;

    public SessionController(ILogger<SessionController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Session> GetSessions()
    {
        return Enumerable.Range(1, 5).Select(index => new Session
        {
            Id = index,
            HeureDebut = DateTime.Now.AddHours(index),
            HeureFin = DateTime.Now.AddHours(index + 1),
            EvenementId = index,

        })
        .ToArray();
    }

    [HttpGet("{id}")]
    public ActionResult<Session> GetSessionById(int id)
    {
        var session = new Session
        {
            Id = id,
            HeureDebut = DateTime.Now.AddHours(id),
            HeureFin = DateTime.Now.AddHours(id + 1),
            EvenementId = id,
        };

        if (session == null)
        {
            return NotFound();
        }

        return Ok(session);
    }

    [HttpPost]
    public ActionResult<Session> CreateSession([FromBody] Session session)
    {
        if (session == null)
        {
            return BadRequest("Session invalide.");
        }

        // Simuler l'ajout du session à la base de données
        session.Id = new Random().Next(1, 1000); // Simuler un ID généré par la base de données

        return CreatedAtAction(nameof(GetSessionById), new { id = session.Id }, session);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateSession(int id, [FromBody] Session session)
    {
        if (session == null || session.Id != id)
        {
            return BadRequest("Session invalide.");
        }

        // Simuler la mise à jour du session dans la base de données
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteSession(int id)
    {
        // Simuler la suppression du session de la base de données
        return NoContent();
    }

}