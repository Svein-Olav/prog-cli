public class DecryptCommand
{
    private readonly ICryptographiService _cryptographiService;

    public DecryptCommand(ICryptographiService service)
    {
        _cryptographiService = service;
    }

    [Command("Decrypt")]
    public void Decrypt(string key, string iv, string tekst)
    {
        var decryptedText = _cryptographiService.Decrypt(String.Empty, String.Empty,  tekst);
        Console.WriteLine(decryptedText);
    }
    
}
