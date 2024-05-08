public class DecryptCommand
{
    private readonly ICryptographiService _cryptographiService;
    private readonly IFileService _fileService;

    public DecryptCommand(ICryptographiService service, IFileService fileService)
    {
        _cryptographiService = service;
        _fileService = fileService;
        
    }
    
    [Command("Decrypt", Description = "Dekrypterer en tekst ved brukt av Key og IV vektor Eksempel: .\\krypttool.exe decrypt --key-file .\\testfiles\\Key.unprotected .\\testfiles\\Vecktor.unprotected \"YAU8va3yN4wL8CnneXVj4g==\"")]
    public string Decrypt(
        [Option(Description = "File som inneholder Key på base64format")] string keyFile, 
        [Option(Description = "File som inneholder IV vektor på base64format ")] string ivFile, 
        [Argument(Description = "Tekst som skal dekrypteres")] string kryptertTekst)
    {                        
        var key = _fileService.ReadFile(keyFile);
        var iv = _fileService.ReadFile(ivFile);

        var decryptedText = _cryptographiService.Decrypt(key, iv, kryptertTekst);

        Console.WriteLine(decryptedText);
        return decryptedText;
    }    
    
}
