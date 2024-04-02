public class GenerateKeyCommand
{
    private readonly ICryptographiService _cryptographiService;

    public GenerateKeyCommand(ICryptographiService service)
    {
        _cryptographiService = service;
    }

    [Command("Generatekey")]
    public void Execute()
    {
        var returnVerdi = _cryptographiService.GenerateKey();
        Console.WriteLine($"Key: {returnVerdi.Key}");
        Console.WriteLine($"IV: {returnVerdi.IV}");

    }
    
}
