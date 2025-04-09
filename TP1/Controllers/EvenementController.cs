using Microsoft.AspNetCore.Mvc;
using TP1.Models;

namespace TP1.Controllers;

[ApiController]
[Route("[controller]")]
public class EvenementController : ControllerBase
{
    private readonly ILogger<EvenementController> _logger;

    public EvenementController(ILogger<EvenementController> logger)
    {
        _logger = logger;
    }
}