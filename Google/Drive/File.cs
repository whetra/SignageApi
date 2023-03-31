namespace Google.Drive;

public class File
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public DateTime? CreatedTime { get; set; }
    public string WebContentLink { get; set; } = "";

    public File(string name, string description, DateTime? createdTime, string webContentLink)
    {
        Name = name;
        Description = description;
        CreatedTime = createdTime;
        WebContentLink = webContentLink;
    }
}