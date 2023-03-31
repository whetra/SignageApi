using Google.Apis.Services;
using Google.Apis.Calendar.v3;
namespace Google.Calendar;

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

    #region GetEvents

    public IEnumerable<Event> GetEvents(string calendarId, int days)
    {
        var eventsList = doGetEvents(calendarId, days);
        if (eventsList == null)
            return new List<Event>();
        return eventsList.Items.Select(e => mapEvent(e));
    }

    public Apis.Calendar.v3.Data.Events doGetEvents(string calendarId, int days)
    {
        var calendarService = new CalendarService(new BaseClientService.Initializer
        {
            ApplicationName = "GoogleCalendarService",
            ApiKey = _apiKey,
        });
        var eventsListRequest = calendarService.Events.List(calendarId);
        eventsListRequest.SingleEvents = true;
        eventsListRequest.TimeMin = DateTime.Now.AddDays(days < 0 ? days : 0);
        eventsListRequest.TimeMax = DateTime.Now.AddDays(days >= 0 ? days : 0);
        eventsListRequest.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
        return eventsListRequest.Execute();
    }

    #endregion

    #region mapEvent

    private Event mapEvent(Apis.Calendar.v3.Data.Event googleApiEvents)
    {
        return new Event(
            googleApiEvents.Summary,
            googleApiEvents.Start.DateTime,
            googleApiEvents.End.DateTime,
            googleApiEvents.Description
        );
    }

    #endregion
}
