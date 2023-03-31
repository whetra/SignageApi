namespace Services;

public class GoogleCalendarService : Google.Calendar.Service
{
    public GoogleCalendarService(IConfiguration configuration) : base(configuration["Google:GoogleCalendarApiKey"]) { }
}