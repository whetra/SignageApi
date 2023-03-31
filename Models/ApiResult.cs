namespace Models;

public class ApiResult<T> //where T : new()
{
    public string Error { get; set; } = "";
    public T? Result { get; set; }
}