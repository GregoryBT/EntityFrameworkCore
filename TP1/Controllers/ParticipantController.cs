using Microsoft.AspNetCore.Mvc;
using TP1.Models;

namespace TP1.Controllers;

[ApiController]
[Route("[controller]")]
public class ParticipantController : ControllerBase
{
    private readonly ILogger<ParticipantController> _logger;

    public ParticipantController(ILogger<ParticipantController> logger)
    {
        _logger = logger;
    }
}
