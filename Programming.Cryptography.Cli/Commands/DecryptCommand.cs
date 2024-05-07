public class DecryptCommand
{
    private readonly ICryptographiService _cryptographiService;
    private readonly IFileService _fileService;

    public DecryptCommand(ICryptographiService service, IFileService fileService)
    {
        _cryptographiService = service;
        _fileService = fileService;
        
    }
    
    [Command("Decrypt", Description = "Decrypt a text using a key and an IV. Example: dotnet run decrypt --key-file .\\testfiles\\key.dat .\\testfiles\\iv.dat \"YAU8va3yN4wL8CnneXVj4g==\"")]
    public string Decrypt(
        [Option(Description = "File containing the key")] string keyFile, 
        [Option(Description = "File containing the IV")] string ivFile, 
        [Argument(Description = "Your text to decrypt")] string kryptertTekst)
    {                        
        var key = _fileService.ReadFile(keyFile);
        var iv = _fileService.ReadFile(ivFile);

        var decryptedText = _cryptographiService.Decrypt(key, iv, kryptertTekst);
        return decryptedText;
    }    
    
}
