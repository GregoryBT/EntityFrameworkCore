using Microsoft.AspNetCore.Mvc;
using TP1.Services;
using TP1.DTOs;

namespace TP1.Controllers;

[ApiController]
[Route("[controller]")]
public class SessionController : ControllerBase
{
    private readonly ILogger<SessionController> _logger;
    private readonly ISessionService _sessionService;

    // Injecter ISessionService via le constructeur
    public SessionController(ILogger<SessionController> logger, ISessionService sessionService)
    {
        _logger = logger;
        _sessionService = sessionService;
    }


    [HttpGet]
    public async Task<IActionResult> GetAllSessions()
    {
        try
        {
            // Appeler le service pour récupérer tous les événements
            var sessions = await _sessionService.GetAllSessions();
            // Retourner les événements au format JSON
            return Ok(sessions);
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "Une erreur est survenue lors de la récupération des événements.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSessionById(int id)
    {
        try
        {
            var session = await _sessionService.GetSessionById(id);
            return Ok(session);
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "Une erreur est survenue lors de la récupération des événements.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateSession([FromBody] SessionDTO sessionDto)
    {
        try
        {
            // Appeler le service pour créer un nouvel événement
            var createdSession = await _sessionService.CreateSession(sessionDto);
            return CreatedAtAction(nameof(GetSessionById), new { id = createdSession.Id }, createdSession);
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "Une erreur est survenue lors de la création de l'événement.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSession(int id, [FromBody] SessionDTO sessionDto)
    {
        try
        {
            // Appeler le service pour mettre à jour l'événement
            var updatedSession = await _sessionService.UpdateSession(id, sessionDto);
            return Ok(updatedSession);
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "Une erreur est survenue lors de la mise à jour de l'événement.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSession(int id)
    {
        try
        {
            // Appeler le service pour supprimer l'événement
            await _sessionService.DeleteSession(id);
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