using Microsoft.AspNetCore.Mvc;
using TP1.Services;
using TP1.DTOs;

namespace TP1.Controllers;

[ApiController]
[Route("[controller]")]
public class IntervenantController : ControllerBase
{
    private readonly ILogger<IntervenantController> _logger;
    private readonly IIntervenantService _intervenantService;

    // Injecter IIntervenantService via le constructeur
    public IntervenantController(ILogger<IntervenantController> logger, IIntervenantService intervenantService)
    {
        _logger = logger;
        _intervenantService = intervenantService;
    }


    [HttpGet]
    public async Task<IActionResult> GetAllIntervenants()
    {
        try
        {
            // Appeler le service pour récupérer tous les événements
            var intervenants = await _intervenantService.GetAllIntervenants();
            // Retourner les événements au format JSON
            return Ok(intervenants);
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "Une erreur est survenue lors de la récupération des événements.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetIntervenantById(int id)
    {
        try
        {
            var intervenant = await _intervenantService.GetIntervenantById(id);
            return Ok(intervenant);
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "Une erreur est survenue lors de la récupération des événements.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateIntervenant([FromBody] IntervenantDTO intervenantDto)
    {
        try
        {
            // Appeler le service pour créer un nouvel événement
            var createdIntervenant = await _intervenantService.CreateIntervenant(intervenantDto);
            return CreatedAtAction(nameof(GetIntervenantById), new { id = createdIntervenant.Id }, createdIntervenant);
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "Une erreur est survenue lors de la création de l'événement.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateIntervenant(int id, [FromBody] IntervenantDTO intervenantDto)
    {
        try
        {
            // Appeler le service pour mettre à jour l'événement
            var updatedIntervenant = await _intervenantService.UpdateIntervenant(id, intervenantDto);
            return Ok(updatedIntervenant);
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "Une erreur est survenue lors de la mise à jour de l'événement.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteIntervenant(int id)
    {
        try
        {
            // Appeler le service pour supprimer l'événement
            await _intervenantService.DeleteIntervenant(id);
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