using Microsoft.AspNetCore.Mvc;
using TP1.Services;
using TP1.DTOs;

namespace TP1.Controllers;

[ApiController]
[Route("[controller]")]
public class EvenementController : ControllerBase
{
    private readonly ILogger<EvenementController> _logger;
    private readonly IEvenementService _evenementService;

    // Injecter IEvenementService via le constructeur
    public EvenementController(ILogger<EvenementController> logger, IEvenementService evenementService)
    {

        _logger = logger;
        _evenementService = evenementService;
    }


    [HttpGet]
    public async Task<IActionResult> GetAllEvenements()
    {
        try
        {
            // Appeler le service pour récupérer tous les événements
            var evenements = await _evenementService.GetAllEvenements();
            // Retourner les événements au format JSON
            return Ok(evenements);
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "Une erreur est survenue lors de la récupération des événements.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEvenementById(int id)
    {
        try
        {
            var evenement = await _evenementService.GetEvenementById(id);
            return Ok(evenement);
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "Une erreur est survenue lors de la récupération des événements.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateEvenement([FromBody] EvenementDTO evenementDto)
    {
        try
        {
            // Appeler le service pour créer un nouvel événement
            var createdEvenement = await _evenementService.CreateEvenement(evenementDto);
            return CreatedAtAction(nameof(GetEvenementById), new { id = createdEvenement.Id }, createdEvenement);
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "Une erreur est survenue lors de la création de l'événement.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEvenement(int id, [FromBody] EvenementDTO evenementDto)
    {
        try
        {
            // Appeler le service pour mettre à jour l'événement
            var updatedEvenement = await _evenementService.UpdateEvenement(id, evenementDto);
            return Ok(updatedEvenement);
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "Une erreur est survenue lors de la mise à jour de l'événement.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEvenement(int id)
    {
        try
        {
            // Appeler le service pour supprimer l'événement
            await _evenementService.DeleteEvenement(id);
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