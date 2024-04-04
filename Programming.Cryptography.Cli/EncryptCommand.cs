using Cocona;
using Cocona.Command;
using Cocona.Help.DocumentModel;


public class EncryptCommand
{
    private readonly ICryptographiService _cryptographiService;
    private readonly IFileService _fileService;

    public EncryptCommand(ICryptographiService service, IFileService fileService)
    {
        _cryptographiService = service;
        _fileService = fileService;
    }

    [Command("Encrypt", Description = "Encrypt a text using a key and an IV.\n Example: dotnet run encrypt .\\key.txt .\\iv.txt \"Hello World\"")]
    public void Encrypt(
         [Argument(Description = "File containing the key")]
         string keyFile, 
         [Argument(Description = "File containing the IV")]
         string ivFile, 
         [Argument(Description = "Your text to encrypt")]
         string tekst)
    {
                        
        var key = _fileService.ReadFile(keyFile);
        var iv = _fileService.ReadFile(ivFile);
        
        var encryptText = _cryptographiService.Encrypt(key, iv, tekst);

        byte[] encryptedBytes = Convert.FromBase64String(encryptText);
        string hexString = BitConverter.ToString(encryptedBytes).Replace("-", "");
        Console.WriteLine(hexString);
        Console.WriteLine(encryptText);
        
    }

    
    
}
