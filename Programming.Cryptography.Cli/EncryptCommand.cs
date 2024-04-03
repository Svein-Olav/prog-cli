public class EncryptCommand
{
    private readonly ICryptographiService _cryptographiService;
    private readonly IFileService _fileService;

    public EncryptCommand(ICryptographiService service, IFileService fileService)
    {
        _cryptographiService = service;
        _fileService = fileService;
    }

    [Command("Encrypt")]
    public void Encrypt(string keyFile, string ivFile, string tekst)
    {
        var key = _fileService.ReadAllText(keyFile);
        var iv = _fileService.ReadAllText(ivFile);
        
        var encryptText = _cryptographiService.Encrypt(key, iv, tekst);
        Console.WriteLine(encryptText);
    }
    
}
