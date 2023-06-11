namespace NoteIt.Infrastructure.Migrations;
[ApiController]
[Route("api/[controller]/[action]")]
public class RollbackController : ControllerBase
{
    private readonly ILogger<RollbackController> _logger;
    private readonly IMigrationRunner _migrationRunner;

    public RollbackController(
        ILogger<RollbackController> logger
        , IMigrationRunner migrationRunner
        )
    { 
        _logger = logger;
        _migrationRunner = migrationRunner;
    }

    [HttpGet]
    public ActionResult Rollback()
    {
        _logger.LogInformation("Rollback transaction");
        _migrationRunner.Rollback(1);
        return Ok();
    }
}
