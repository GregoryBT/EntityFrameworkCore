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
    public IEnumerable<Lieu> GetLieux()
    {
        return _context.Lieux.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Lieu> GetLieuById(int id)
    {
        var lieu = _context.Lieux.FirstOrDefault(l => l.Id == id);

        if (lieu == null)
        {
            return NotFound();
        }

        return Ok(lieu);
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
        catch (DbUpdateException dbEx)
        {
            // Erreur spécifique lors de la mise à jour de la base de données
            _logger.LogError(dbEx, "Erreur lors de l'ajout du lieu à la base de données.");
            return StatusCode(500, "Une erreur est survenue lors de la sauvegarde du lieu.");
        }
        catch (TimeoutException timeoutEx)
        {
            // Erreur de timeout de la base de données
            _logger.LogError(timeoutEx, "Le délai de connexion à la base de données a expiré.");
            return StatusCode(504, "Délai de connexion dépassé. Veuillez réessayer plus tard.");
        }
        catch (Exception ex)
        {
            // Gestion d'autres erreurs générales
            _logger.LogError(ex, "Une erreur inattendue est survenue.");
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

    [HttpDelete("{id}")]
    public ActionResult DeleteLieu(int id)
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

}