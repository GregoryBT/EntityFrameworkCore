using Microsoft.AspNetCore.Mvc;
using TP1.Services;
using TP1.DTOs;

namespace TP1.Controllers;

[ApiController]
[Route("[controller]")]
public class NotationController : ControllerBase
{
    private readonly ILogger<NotationController> _logger;
    private readonly INotationService _notationService;

    // Injecter INotationService via le constructeur
    public NotationController(ILogger<NotationController> logger, INotationService notationService)
    {
        _logger = logger;
        _notationService = notationService;
    }


    [HttpGet]
    public async Task<IActionResult> GetAllNotations()
    {
        try
        {
            // Appeler le service pour récupérer tous les événements
            var notations = await _notationService.GetAllNotations();
            // Retourner les événements au format JSON
            return Ok(notations);
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "Une erreur est survenue lors de la récupération des événements.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetNotationById(int id)
    {
        try
        {
            var notation = await _notationService.GetNotationById(id);
            return Ok(notation);
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "Une erreur est survenue lors de la récupération des événements.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateNotation([FromBody] NotationDTO notationDto)
    {
        try
        {
            // Appeler le service pour créer un nouvel événement
            var createdNotation = await _notationService.CreateNotation(notationDto);
            return CreatedAtAction(nameof(GetNotationById), new { id = createdNotation.Id }, createdNotation);
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "Une erreur est survenue lors de la création de l'événement.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateNotation(int id, [FromBody] NotationDTO notationDto)
    {
        try
        {
            // Appeler le service pour mettre à jour l'événement
            var updatedNotation = await _notationService.UpdateNotation(id, notationDto);
            return Ok(updatedNotation);
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "Une erreur est survenue lors de la mise à jour de l'événement.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNotation(int id)
    {
        try
        {
            // Appeler le service pour supprimer l'événement
            await _notationService.DeleteNotation(id);
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