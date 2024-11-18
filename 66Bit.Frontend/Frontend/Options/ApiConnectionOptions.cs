namespace Frontend.Options;

public class ApiConnectionOptions
{
    public const string SECTION_NAME = "ApiConnection";
    
    public string ApiConnectionString { get; set; } = null!;
}