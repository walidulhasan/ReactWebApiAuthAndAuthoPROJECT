namespace Backend_WebApi.Core.Entities
{
    public class Log:BaseEntity<long>
    {
        public string UserName { get; set; } = string.Empty;
        public string Description { get; set; }
    }
}
