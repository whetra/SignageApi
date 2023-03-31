using Microsoft.AspNetCore.Mvc;
namespace SignageApi.Controllers;

[ApiController]
[Route("[controller]")]
public class GoogleController : ControllerBase
{
    #region Variables

    private readonly ILogger<GoogleController> _logger;
    private readonly Services.GoogleCalendarService _calendarService;
    private readonly Services.GoogleDriveService _driveService;

    #endregion

    #region Constructor

    public GoogleController(ILogger<GoogleController> logger, Services.GoogleCalendarService calendarService, Services.GoogleDriveService driveService)
    {
        _logger = logger;
        _calendarService = calendarService;
        _driveService = driveService;
    }

    #endregion

    #region GetCalendarEvents

    [HttpGet("GetCalendarEvents/{calendarId}/{days}")]
    public Models.ApiResult<List<Google.Calendar.Event>> GetCalendarEvents(string calendarId, int days)
    {
        try
        {
            var events = _calendarService.GetEvents(calendarId, days);
            return new Models.ApiResult<List<Google.Calendar.Event>> { Result = events.ToList() };
        }
        catch (System.Exception ex)
        {
            return new Models.ApiResult<List<Google.Calendar.Event>> { Error = ex.Message };
        }
    }

    #endregion

    #region GetDriveFiles

    [HttpGet("GetDriveFiles/{folderId}")]
    public Models.ApiResult<List<Google.Drive.File>> GetDriveFiles(string folderId)
    {
        try
        {
            var files = _driveService.GetFiles(folderId);
            return new Models.ApiResult<List<Google.Drive.File>> { Result = files.ToList() };
        }
        catch (System.Exception ex)
        {
            return new Models.ApiResult<List<Google.Drive.File>> { Error = ex.Message };
        }
    }

    #endregion
}
