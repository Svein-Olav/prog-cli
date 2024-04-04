public class DecryptCommand
{
    private readonly ICryptographiService _cryptographiService;
    private readonly IFileService _fileService;

    public DecryptCommand(ICryptographiService service, IFileService fileService)
    {
        _cryptographiService = service;
        _fileService = fileService;
        
    }

    [Command("Decrypt")]
    public void Decrypt(string keyFile, string ivFile, string tekst)
    {                        
        var key = _fileService.ReadFile(keyFile);
        var iv = _fileService.ReadFile(ivFile);

        var decryptedText = _cryptographiService.Decrypt(key, iv, tekst);
        Console.WriteLine(decryptedText);
    }    
    
}
