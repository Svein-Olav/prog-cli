public class GenerateKeyCommand
{
    private readonly ICryptographiService _cryptographiService;
    private readonly IFileService _fileService;    

    public GenerateKeyCommand(ICryptographiService cryptoService, IFileService fileService)
    {
        _cryptographiService = cryptoService;
        _fileService = fileService;

    }

    
    [Command("Generatekey", Description = "Generate a key and an IV. Example: dotnet run generatekey. The key and IV will be written to the files key.dat and iv.dat. In folder testfiles.")]
    public void GenerateKey([Option(Description = "Outputfolder")] string folder = @".\")
    {
        var returnVerdi = _cryptographiService.GenerateKey();
        _fileService.WriteFile(@$"{folder}\Key.unprotected", returnVerdi.Key);
        _fileService.WriteFile(@$"{folder}\Vector.unprotected", returnVerdi.IV);

    }
    
}
