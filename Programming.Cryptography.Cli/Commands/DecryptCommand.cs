using Cocona;

public class DecryptCommand
{
    private readonly ICryptographiService _cryptographiService;
    private readonly IFileService _fileService;

    public DecryptCommand(ICryptographiService service, IFileService fileService)
    {
        _cryptographiService = service;
        _fileService = fileService;
        
    }
    
    [Command("Decrypt", Description = "Dekrypterer en tekst ved hjelp av Key.unprotected og Vektor.unprotected")]   
    public string Decrypt(
        [Option(Description = "File som inneholder Key på base64format (Key.unprotected)")] string keyFile, 
        [Option(Description = "File som inneholder IV vektor på base64format (Vector.unprotected)")] string ivFile, 
        [Argument(Description = @"Tekst som skal dekrypteres (""YAU8va3yN4wL8CnneXVj4g=="")")] string kryptertTekst)
    {                        
        var key = _fileService.ReadFile(keyFile);
        var iv = _fileService.ReadFile(ivFile);

        var decryptedText = _cryptographiService.Decrypt(key, iv, kryptertTekst);

        Console.WriteLine(decryptedText);
        return decryptedText;
    }    
    
}
