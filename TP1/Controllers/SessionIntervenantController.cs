using Microsoft.AspNetCore.Mvc;
using TP1.Services;
using TP1.DTOs;

namespace TP1.Controllers;

[ApiController]
[Route("[controller]")]
public class SessionIntervenantController : ControllerBase
{
    private readonly ILogger<SessionIntervenantController> _logger;
    private readonly ISessionIntervenantService _sessionIntervenantService;

    // Injecter ISessionIntervenantService via le constructeur
    public SessionIntervenantController(ILogger<SessionIntervenantController> logger, ISessionIntervenantService sessionIntervenantService)
    {

        _logger = logger;
        _sessionIntervenantService = sessionIntervenantService;
    }


    [HttpGet]
    public async Task<IActionResult> GetAllSessionIntervenants()
    {
        try
        {
            // Appeler le service pour récupérer tous les événements
            var sessionIntervenants = await _sessionIntervenantService.GetAllSessionIntervenants();
            // Retourner les événements au format JSON
            return Ok(sessionIntervenants);
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "Une erreur est survenue lors de la récupération des événements.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpGet("session/{id}")]
    public async Task<IActionResult> GetSessionIntervenantBySessionId(int id)
    {
        try
        {
            var sessionIntervenant = await _sessionIntervenantService.GetSessionIntervenantBySessionId(id);
            return Ok(sessionIntervenant);
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "Une erreur est survenue lors de la récupération des événements.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpGet("intervenant/{id}")]
    public async Task<IActionResult> GetSessionIntervenantByIntervenantId(int id)
    {
        try
        {
            var sessionIntervenant = await _sessionIntervenantService.GetSessionIntervenantByIntervenantId(id);
            return Ok(sessionIntervenant);
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "Une erreur est survenue lors de la récupération des événements.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateSessionIntervenant([FromBody] SessionIntervenantDTO sessionIntervenantDto)
    {
        try
        {
            // Appeler le service pour créer un nouvel événement
            var createdSessionIntervenant = await _sessionIntervenantService.CreateSessionIntervenant(sessionIntervenantDto);
            return CreatedAtAction(nameof(GetSessionIntervenantBySessionId), new { id = createdSessionIntervenant.SessionId }, createdSessionIntervenant);
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "Une erreur est survenue lors de la création de l'événement.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSessionIntervenant(int id, [FromBody] SessionIntervenantDTO sessionIntervenantDto)
    {
        try
        {
            // Appeler le service pour mettre à jour l'événement
            var updatedSessionIntervenant = await _sessionIntervenantService.UpdateSessionIntervenant(id, sessionIntervenantDto);
            return Ok(updatedSessionIntervenant);
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "Une erreur est survenue lors de la mise à jour de l'événement.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSessionIntervenant(int id)
    {
        try
        {
            // Appeler le service pour supprimer l'événement
            await _sessionIntervenantService.DeleteSessionIntervenant(id);
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