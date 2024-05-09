public class GenerateKeyCommand
{
    private readonly ICryptographiService _cryptographiService;
    private readonly IFileService _fileService;    

    public GenerateKeyCommand(ICryptographiService cryptoService, IFileService fileService)
    {
        _cryptographiService = cryptoService;
        _fileService = fileService;

    }

    
    [Command("Generatekey", Description = "Lager ny Key.unprotected og Vector.unprotected. Begge er p� base64format.")]
    public void GenerateKey([Option(Description = "Katalog hvor n�kkelen blir lagret")] string folder = @".\")
    {
        var returnVerdi = _cryptographiService.GenerateKey();
        _fileService.WriteFile(@$"{folder}\Key.unprotected", returnVerdi.Key);
        _fileService.WriteFile(@$"{folder}\Vector.unprotected", returnVerdi.IV);

    }
    
}
