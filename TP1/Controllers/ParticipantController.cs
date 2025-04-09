using Microsoft.AspNetCore.Mvc;
using TP1.Models;

namespace TP1.Controllers;

[ApiController]
[Route("[controller]")]
public class ParticipantController : ControllerBase
{
    private readonly ILogger<ParticipantController> _logger;

    public ParticipantController(ILogger<ParticipantController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Participant>> GetParticipants()
    {
        try
        {
            var participants = Enumerable.Range(1, 5).Select(index => new Participant
            {
                Id = index,
                Nom = "Participant " + index,
                Prenom = "Prénom " + index,
                Email = "email" + index + "@example.com",
                Telephone = "0123456789",
            }).ToArray();

            return Ok(participants);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Une erreur est survenue lors de la récupération des participants.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpGet("{id}")]
    public ActionResult<Participant> GetParticipantById(int id)
    {
        try
        {
            var participant = new Participant
            {
                Id = id,
                Nom = "Participant " + id,
                Prenom = "Prénom " + id,
                Email = "email" + id + "@example.com",
                Telephone = "0123456789",
            };

            if (participant == null)
            {
                return NotFound();
            }

            return Ok(participant);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Une erreur est survenue lors de la récupération du participant.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpPost]
    public ActionResult<Participant> CreateParticipant([FromBody] Participant participant)
    {
        if (participant == null)
        {
            return BadRequest("Participant invalide.");
        }

        try
        {
            // Simuler l'ajout du participant à la base de données
            participant.Id = new Random().Next(1, 1000); // Simuler un ID généré par la base de données

            return CreatedAtAction(nameof(GetParticipantById), new { id = participant.Id }, participant);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Une erreur est survenue lors de la création du participant.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpPut("{id}")]
    public ActionResult UpdateParticipant(int id, [FromBody] Participant participant)
    {
        if (participant == null || participant.Id != id)
        {
            return BadRequest("Participant invalide.");
        }

        try
        {
            // Simuler la mise à jour du participant dans la base de données
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Une erreur est survenue lors de la mise à jour du participant.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteParticipant(int id)
    {
        try
        {
            // Simuler la suppression du participant de la base de données
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Une erreur est survenue lors de la suppression du participant.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }
}
