using Microsoft.AspNetCore.Mvc;
using TP1.Services;
using TP1.DTOs;

namespace TP1.Controllers;

[ApiController]
[Route("[controller]")]
public class ParticipantController : ControllerBase
{
    private readonly ILogger<ParticipantController> _logger;
    private readonly IParticipantService _participantService;

    // Injecter IParticipantService via le constructeur
    public ParticipantController(ILogger<ParticipantController> logger, IParticipantService participantService)
    {
        _logger = logger;
        _participantService = participantService;
    }


    [HttpGet]
    public async Task<IActionResult> GetAllParticipants()
    {
        try
        {
            // Appeler le service pour récupérer tous les événements
            var participants = await _participantService.GetAllParticipants();
            // Retourner les événements au format JSON
            return Ok(participants);
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "Une erreur est survenue lors de la récupération des événements.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetParticipantById(int id)
    {
        try
        {
            var participant = await _participantService.GetParticipantById(id);
            return Ok(participant);
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "Une erreur est survenue lors de la récupération des événements.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateParticipant([FromBody] ParticipantDTO participantDto)
    {
        try
        {
            // Appeler le service pour créer un nouvel événement
            var createdParticipant = await _participantService.CreateParticipant(participantDto);
            return CreatedAtAction(nameof(GetParticipantById), new { id = createdParticipant.Id }, createdParticipant);
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "Une erreur est survenue lors de la création de l'événement.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateParticipant(int id, [FromBody] ParticipantDTO participantDto)
    {
        try
        {
            // Appeler le service pour mettre à jour l'événement
            var updatedParticipant = await _participantService.UpdateParticipant(id, participantDto);
            return Ok(updatedParticipant);
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "Une erreur est survenue lors de la mise à jour de l'événement.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteParticipant(int id)
    {
        try
        {
            // Appeler le service pour supprimer l'événement
            await _participantService.DeleteParticipant(id);
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