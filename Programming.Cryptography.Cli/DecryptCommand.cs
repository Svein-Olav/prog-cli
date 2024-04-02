public class DecryptCommand
{
    private readonly ICryptographiService _cryptographiService;

    public DecryptCommand(ICryptographiService service)
    {
        _cryptographiService = service;
    }

    [Command("Decrypt")]
    public void Decrypt(string tekst)
    {
        var decryptedText = _cryptographiService.Decrypt(tekst);
        Console.WriteLine(decryptedText);
    }
    
}
