namespace Services;

public class GoogleDriveService : Google.Drive.Service
{
    public GoogleDriveService(IConfiguration configuration) : base(configuration["Google:GoogleDriveApiKey"]) { }
}