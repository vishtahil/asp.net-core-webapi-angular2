using Microsoft.Extensions.Configuration;

public interface IGreeter
{
    string GetGreeting();
}

public class Greeter : IGreeter
{
    private string _greeting;
    public Greeter(IConfiguration configuration){
        _greeting=configuration["greeting"];
    }
    public string GetGreeting()
    {
        return _greeting;
    }
}
