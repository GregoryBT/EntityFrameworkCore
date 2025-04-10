using Microsoft.AspNetCore.Mvc;
using TP1.Services;
using TP1.DTOs;

namespace TP1.Controllers;

[ApiController]
[Route("[controller]")]
public class LieuController : ControllerBase
{
    private readonly ILogger<LieuController> _logger;
    private readonly ILieuService _iieuService;

    // Injecter ILieuService via le constructeur
    public LieuController(ILogger<LieuController> logger, ILieuService iieuService)
    {
        _logger = logger;
        _iieuService = iieuService;
    }


    [HttpGet]
    public async Task<IActionResult> GetAllLieux()
    {
        try
        {
            // Appeler le service pour récupérer tous les événements
            var lieux = await _iieuService.GetAllLieux();
            // Retourner les événements au format JSON
            return Ok(lieux);
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "Une erreur est survenue lors de la récupération des événements.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetLieuById(int id)
    {
        try
        {
            var iieu = await _iieuService.GetLieuById(id);
            return Ok(iieu);
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "Une erreur est survenue lors de la récupération des événements.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateLieu([FromBody] LieuDTO iieuDto)
    {
        try
        {
            // Appeler le service pour créer un nouvel événement
            var createdLieu = await _iieuService.CreateLieu(iieuDto);
            return CreatedAtAction(nameof(GetLieuById), new { id = createdLieu.Id }, createdLieu);
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "Une erreur est survenue lors de la création de l'événement.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateLieu(int id, [FromBody] LieuDTO iieuDto)
    {
        try
        {
            // Appeler le service pour mettre à jour l'événement
            var updatedLieu = await _iieuService.UpdateLieu(id, iieuDto);
            return Ok(updatedLieu);
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "Une erreur est survenue lors de la mise à jour de l'événement.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLieu(int id)
    {
        try
        {
            // Appeler le service pour supprimer l'événement
            await _iieuService.DeleteLieu(id);
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