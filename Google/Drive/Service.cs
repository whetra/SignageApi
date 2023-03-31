using Google.Apis.Services;
using Google.Apis.Drive.v3;
namespace Google.Drive;

public class Service
{
    #region Variables

    private string _apiKey;

    #endregion

    #region Constructor
    public Service(string apiKey)
    {
        _apiKey = apiKey;
    }

    #endregion

    #region GetFiles

    public IEnumerable<File> GetFiles(string folderId)
    {
        var service = new DriveService(new BaseClientService.Initializer
        {
            ApplicationName = "GoogleDriveService",
            ApiKey = _apiKey,
        });

        var request = service.Files.List();
        request.Q = $"'{folderId}' in parents";
        request.Fields = "files(id,mimeType,name,description,createdTime,webContentLink)";
        request.OrderBy = "createdTime";
        var result = request.Execute();
        return result.Files.Select(f => mapFile(f));
    }
    #endregion

    #region mapFile

    private File mapFile(Apis.Drive.v3.Data.File googleApiFile)
    {
        return new File(
            googleApiFile.Name,
            googleApiFile.Description,
            googleApiFile.CreatedTime,
            googleApiFile.WebContentLink
        );
    }

    #endregion
}