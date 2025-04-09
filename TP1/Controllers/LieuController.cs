using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP1.Models;

namespace TP1.Controllers;

[ApiController]
[Route("[controller]")]
public class LieuController : ControllerBase
{
    private readonly ILogger<LieuController> _logger;
    private readonly AppDbContext _context;

    public LieuController(ILogger<LieuController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Lieu>> GetLieux()
    {
        try
        {
            var lieux = _context.Lieux.ToList();
            return Ok(lieux);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Une erreur est survenue lors de la récupération des lieux.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpGet("{id}")]
    public ActionResult<Lieu> GetLieuById(int id)
    {
        try
        {
            var lieu = _context.Lieux.FirstOrDefault(l => l.Id == id);

            if (lieu == null)
            {
                return NotFound();
            }

            return Ok(lieu);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Une erreur est survenue lors de la récupération du lieu.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpPost]
    public ActionResult<Lieu> CreateLieu([FromBody] Lieu lieu)
    {
        if (lieu == null)
        {
            return BadRequest("Lieu invalide.");
        }

        try
        {
            // Ajout du lieu dans la base de données
            _context.Lieux.Add(lieu);

            // Sauvegarde des changements
            _context.SaveChanges();

            // Retourne une réponse "Created" avec le lieu ajouté
            return CreatedAtAction(nameof(GetLieuById), new { id = lieu.Id }, lieu);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Une erreur est survenue lors de la mise à jour du lieu.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpPut("{id}")]
    public ActionResult UpdateLieu(int id, [FromBody] Lieu lieu)
    {
        if (id == 0)
        {
            return BadRequest("Lieu invalide.");
        }

        try
        {
            var existingLieu = _context.Lieux.FirstOrDefault(l => l.Id == id);
            if (existingLieu == null)
            {
                return NotFound();
            }

            existingLieu.Nom = lieu.Nom;
            existingLieu.Adresse = lieu.Adresse;

            _context.SaveChanges();

            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Une erreur est survenue lors de la mise à jour du lieu.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteLieu(int id)
    {
        try
        {
            var lieu = _context.Lieux.FirstOrDefault(l => l.Id == id);
            if (lieu == null)
            {
                return NotFound();
            }

            _context.Lieux.Remove(lieu);
            _context.SaveChanges();

            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Une erreur est survenue lors de la suppression du lieu.");
            return StatusCode(500, "Une erreur inattendue est survenue.");
        }
    }
}
