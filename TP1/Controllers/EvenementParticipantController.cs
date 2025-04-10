using Microsoft.AspNetCore.Mvc;
using TP1.Services;
using TP1.DTOs;

namespace TP1.Controllers;

[ApiController]
[Route("[controller]")]
public class EvenementParticipantController : ControllerBase
{
    private readonly ILogger<EvenementParticipantController> _logger;
    private readonly IEvenementParticipantService _evenementParticipantService;

    // Injecter IEvenementParticipantService via le constructeur
    public EvenementParticipantController(ILogger<EvenementParticipantController> logger, IEvenementParticipantService evenementParticipantService)
    {

        _logger = logger;
        _evenementParticipantService = evenementParticipantService;
    }


    [HttpGet]
    public async Task<IActionResult> GetAllEvenementParticipants()
    {
        try
        {
            // Appeler le service pour récupérer tous les événements
            var evenementParticipants = await _evenementParticipantService.GetAllEvenementParticipants();
            // Retourner les événements au format JSON
            return Ok(evenementParticipants);
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "Une erreur est survenue lors de la récupération des événements.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpGet("participant/{id}")]
    public async Task<IActionResult> GetEvenementsParticipantByParticipantId(int id)
    {
        try
        {
            var evenementParticipant = await _evenementParticipantService.GetEvenementsParticipantByParticipantId(id);
            return Ok(evenementParticipant);
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "Une erreur est survenue lors de la récupération des événements.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpGet("evenement/{id}")]
    public async Task<IActionResult> GetEvenementsParticipantByEvenementId(int id)
    {
        try
        {
            var evenementParticipant = await _evenementParticipantService.GetEvenementParticipantByEvenementId(id);
            return Ok(evenementParticipant);
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "Une erreur est survenue lors de la récupération des événements.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateEvenementParticipant([FromBody] EvenementParticipantDTO evenementParticipantDto)
    {
        try
        {
            // Appeler le service pour créer un nouvel événement
            var createdEvenementParticipant = await _evenementParticipantService.CreateEvenementParticipant(evenementParticipantDto);
            return CreatedAtAction(nameof(GetEvenementsParticipantByEvenementId), new { id = createdEvenementParticipant.EvenementId }, createdEvenementParticipant);
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "Une erreur est survenue lors de la création de l'événement.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEvenementParticipant(int id, [FromBody] EvenementParticipantDTO evenementParticipantDto)
    {
        try
        {
            // Appeler le service pour mettre à jour l'événement
            var updatedEvenementParticipant = await _evenementParticipantService.UpdateEvenementParticipant(id, evenementParticipantDto);
            return Ok(updatedEvenementParticipant);
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "Une erreur est survenue lors de la mise à jour de l'événement.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEvenementParticipant(int id)
    {
        try
        {
            // Appeler le service pour supprimer l'événement
            await _evenementParticipantService.DeleteEvenementParticipant(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "Une erreur est survenue lors de la suppression de l'événement.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }
}