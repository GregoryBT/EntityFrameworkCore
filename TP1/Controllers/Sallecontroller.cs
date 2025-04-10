using Microsoft.AspNetCore.Mvc;
using TP1.Services;
using TP1.DTOs;

namespace TP1.Controllers;

[ApiController]
[Route("[controller]")]
public class SalleController : ControllerBase
{
    private readonly ILogger<SalleController> _logger;
    private readonly ISalleService _salleService;

    // Injecter ISalleService via le constructeur
    public SalleController(ILogger<SalleController> logger, ISalleService salleService)
    {
        _logger = logger;
        _salleService = salleService;
    }


    [HttpGet]
    public async Task<IActionResult> GetAllSalles()
    {
        try
        {
            // Appeler le service pour récupérer tous les événements
            var salles = await _salleService.GetAllSalles();
            // Retourner les événements au format JSON
            return Ok(salles);
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "Une erreur est survenue lors de la récupération des événements.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSalleById(int id)
    {
        try
        {
            var salle = await _salleService.GetSalleById(id);
            return Ok(salle);
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "Une erreur est survenue lors de la récupération des événements.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateSalle([FromBody] SalleDTO salleDto)
    {
        try
        {
            // Appeler le service pour créer un nouvel événement
            var createdSalle = await _salleService.CreateSalle(salleDto);
            return CreatedAtAction(nameof(GetSalleById), new { id = createdSalle.Id }, createdSalle);
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "Une erreur est survenue lors de la création de l'événement.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSalle(int id, [FromBody] SalleDTO salleDto)
    {
        try
        {
            // Appeler le service pour mettre à jour l'événement
            var updatedSalle = await _salleService.UpdateSalle(id, salleDto);
            return Ok(updatedSalle);
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "Une erreur est survenue lors de la mise à jour de l'événement.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSalle(int id)
    {
        try
        {
            // Appeler le service pour supprimer l'événement
            await _salleService.DeleteSalle(id);
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