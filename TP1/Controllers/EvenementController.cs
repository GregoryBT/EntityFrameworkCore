using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP1.Models;
using TP1.Services;

namespace TP1.Controllers;

[ApiController]
[Route("[controller]")]
public class EvenementController : ControllerBase
{
    private readonly IEvenementService _evenementService;

    // Injecter IEvenementService via le constructeur
    public EvenementController(IEvenementService evenementService)
    {
        _evenementService = evenementService;
    }


    [HttpGet]
    public async Task<IActionResult> GetAllEvenements()
    {
        var evenements = await _evenementService.GetAllEventsAsync();
        return Ok(evenements);  // Retourne les événements sous forme de réponse HTTP
    }

    // [HttpGet("{id}")]
    // public ActionResult<Evenement> GetEvenementById(int id)
    // {
    //     try
    //     {
    //         var evenement = _context.Evenements.FirstOrDefault(l => l.Id == id);

    //         if (evenement == null)
    //         {
    //             return NotFound();
    //         }

    //         return Ok(evenement);
    //     }
    //     catch (Exception ex)
    //     {
    //         _logger.LogError(ex, "Une erreur est survenue lors de la récupération du lieu.");
    //         return StatusCode(500, "Une erreur inattendue est survenue.");
    //     }
    // }

    // [HttpPost]
    // public ActionResult<Evenement> CreateEvenement([FromBody] Evenement evenement)
    // {
    //     if (evenement == null)
    //     {
    //         return BadRequest("Le lieu ne peut pas être nul.");
    //     }

    //     try
    //     {
    //         _context.Evenements.Add(evenement);
    //         _context.SaveChanges();

    //         return CreatedAtAction(nameof(GetEvenementById), new { id = evenement.Id }, evenement);
    //     }
    //     catch (DbUpdateException ex)
    //     {
    //         _logger.LogError(ex, "Erreur lors de la création du lieu.");
    //         return StatusCode(500, "Erreur lors de la création du lieu.");
    //     }
    // }

    // [HttpPut("{id}")]
    // public ActionResult<Evenement> UpdateEvenement(int id, [FromBody] Evenement evenement)
    // {
    //     if (evenement == null || id != evenement.Id)
    //     {
    //         return BadRequest("Le lieu ne peut pas être nul.");
    //     }

    //     try
    //     {
    //         var existingEvenement = _context.Evenements.FirstOrDefault(l => l.Id == id);
    //         if (existingEvenement == null)
    //         {
    //             return NotFound();
    //         }

    //         _context.Entry(existingEvenement).CurrentValues.SetValues(evenement);
    //         _context.SaveChanges();

    //         return Ok(existingEvenement);
    //     }
    //     catch (DbUpdateException ex)
    //     {
    //         _logger.LogError(ex, "Erreur lors de la mise à jour du lieu.");
    //         return StatusCode(500, "Erreur lors de la mise à jour du lieu.");
    //     }
    // }

    // [HttpDelete("{id}")]
    // public ActionResult DeleteEvenement(int id)
    // {
    //     try
    //     {
    //         var evenement = _context.Evenements.FirstOrDefault(l => l.Id == id);
    //         if (evenement == null)
    //         {
    //             return NotFound();
    //         }

    //         _context.Evenements.Remove(evenement);
    //         _context.SaveChanges();

    //         return NoContent();
    //     }
    //     catch (DbUpdateException ex)
    //     {
    //         _logger.LogError(ex, "Erreur lors de la suppression du lieu.");
    //         return StatusCode(500, "Erreur lors de la suppression du lieu.");
    //     }
    // }

}