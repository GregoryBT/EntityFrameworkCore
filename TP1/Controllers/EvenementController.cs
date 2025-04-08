using Microsoft.AspNetCore.Mvc;
using TP1.Models;

namespace TP1.Controllers;

[ApiController]
[Route("[controller]")]
public class EvenementController : ControllerBase
{
    private readonly ILogger<EvenementController> _logger;

    public EvenementController(ILogger<EvenementController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Evenement> GetEvenements()
    {
        return Enumerable.Range(1, 5).Select(index => new Evenement
        {
            Id = index,
            Name = "Evenement " + index,
            Description = "Description de l'événement " + index,
            LieuId = index,
            Sessions = new List<Session>()
        })
        .ToArray();
    }

    [HttpGet("{id}")]
    public ActionResult<Evenement> GetEvenementById(int id)
    {
        var evenement = new Evenement
        {
            Id = id,
            Name = "Evenement " + id,
            Description = "Description de l'événement " + id,
            LieuId = id,
            Sessions = new List<Session>()
        };

        if (evenement == null)
        {
            return NotFound();
        }

        return Ok(evenement);
    }

    [HttpPost]
    public ActionResult<Evenement> CreateEvenement([FromBody] Evenement evenement)
    {
        if (evenement == null)
        {
            return BadRequest("Événement invalide.");
        }

        // Simuler l'ajout de l'événement à la base de données
        evenement.Id = new Random().Next(1, 1000); // Simuler un ID généré par la base de données

        return CreatedAtAction(nameof(GetEvenementById), new { id = evenement.Id }, evenement);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateEvenement(int id, [FromBody] Evenement evenement)
    {
        if (evenement == null || evenement.Id != id)
        {
            return BadRequest("Événement invalide.");
        }

        // Simuler la mise à jour de l'événement dans la base de données
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteEvenement(int id)
    {
        // Simuler la suppression de l'événement de la base de données
        return NoContent();
    }

}