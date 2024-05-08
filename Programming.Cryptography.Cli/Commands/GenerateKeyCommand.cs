public class GenerateKeyCommand
{
    private readonly ICryptographiService _cryptographiService;
    private readonly IFileService _fileService;    

    public GenerateKeyCommand(ICryptographiService cryptoService, IFileService fileService)
    {
        _cryptographiService = cryptoService;
        _fileService = fileService;

    }

    
    [Command("Generatekey", Description = "Lager ny Key og IV. Example: dotnet run generatekey. Key and IV vil bli skrevet til filene Key.unprotected and Vector.unprotected. Nøkkel og vektor er på base64format.")]
    public void GenerateKey([Option(Description = "Katalog hvor nøkkelen blir lagret")] string folder = @".\")
    {
        var returnVerdi = _cryptographiService.GenerateKey();
        _fileService.WriteFile(@$"{folder}\Key.unprotected", returnVerdi.Key);
        _fileService.WriteFile(@$"{folder}\Vector.unprotected", returnVerdi.IV);

    }
    
}
