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
    public IEnumerable<Participant> GetParticipants()
    {
        return Enumerable.Range(1, 5).Select(index => new Participant
        {
            Id = index,
            Nom = "Participant " + index,
            Prenom = "Prénom " + index,
            Email = "email" + index + "@example.com",
            Telephone = "0123456789",
        })
        .ToArray();
    }

    [HttpGet("{id}")]
    public ActionResult<Participant> GetParticipantById(int id)
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

    [HttpPost]
    public ActionResult<Participant> CreateParticipant([FromBody] Participant participant)
    {
        if (participant == null)
        {
            return BadRequest("Participant invalide.");
        }

        // Simuler l'ajout du participant à la base de données
        participant.Id = new Random().Next(1, 1000); // Simuler un ID généré par la base de données

        return CreatedAtAction(nameof(GetParticipantById), new { id = participant.Id }, participant);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateParticipant(int id, [FromBody] Participant participant)
    {
        if (participant == null || participant.Id != id)
        {
            return BadRequest("Participant invalide.");
        }

        // Simuler la mise à jour du participant dans la base de données
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteParticipant(int id)
    {
        // Simuler la suppression du participant de la base de données
        return NoContent();
    }

}