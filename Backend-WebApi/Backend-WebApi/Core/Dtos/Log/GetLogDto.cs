namespace Backend_WebApi.Core.Dtos.Log;

public class GetLogDto
{
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public string UsrName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
