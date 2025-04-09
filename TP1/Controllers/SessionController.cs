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
    public ActionResult<IEnumerable<Session>> GetSessions()
    {
        try
        {
            var sessions = Enumerable.Range(1, 5).Select(index => new Session
            {
                Id = index,
                HeureDebut = DateTime.Now.AddHours(index),
                HeureFin = DateTime.Now.AddHours(index + 1),
                EvenementId = index,
            })
            .ToArray();

            return Ok(sessions);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Une erreur est survenue lors de la récupération des sessions.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpGet("{id}")]
    public ActionResult<Session> GetSessionById(int id)
    {
        try
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
        catch (Exception ex)
        {
            _logger.LogError(ex, "Une erreur est survenue lors de la récupération de la session.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpPost]
    public ActionResult<Session> CreateSession([FromBody] Session session)
    {
        if (session == null)
        {
            return BadRequest("Session invalide.");
        }

        try
        {
            // Simuler l'ajout de la session à la base de données
            session.Id = new Random().Next(1, 1000); // Simuler un ID généré par la base de données

            return CreatedAtAction(nameof(GetSessionById), new { id = session.Id }, session);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Une erreur est survenue lors de la création de la session.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpPut("{id}")]
    public ActionResult UpdateSession(int id, [FromBody] Session session)
    {
        if (session == null || session.Id != id)
        {
            return BadRequest("Session invalide.");
        }

        try
        {
            // Simuler la mise à jour de la session dans la base de données
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Une erreur est survenue lors de la mise à jour de la session.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteSession(int id)
    {
        try
        {
            // Simuler la suppression de la session de la base de données
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Une erreur est survenue lors de la suppression de la session.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }
}
