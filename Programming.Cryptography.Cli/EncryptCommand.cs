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
        var key = _fileService.ReadAllByte(keyFile);
        var iv = _fileService.ReadAllByte(ivFile);
        
        var encryptText = _cryptographiService.Encrypt(key, iv, tekst);

        byte[] encryptedBytes = Convert.FromBase64String(encryptText);
        string hexString = BitConverter.ToString(encryptedBytes).Replace("-", "");
        Console.WriteLine(hexString);
        
    }
    
}
