namespace Google.Calendar;

public class Event
{
    public string Summary { get; set; } = "";
    public DateTime? StartDateTime { get; set; }
    public DateTime? EndDateTime { get; set; }
    public string Description { get; set; } = "";

    public Event(string summary, DateTime? endDateTime, DateTime? startDateTime, string description)
    {
        Summary = summary;
        EndDateTime = endDateTime;
        StartDateTime = startDateTime;
        Description = description;
    }
}