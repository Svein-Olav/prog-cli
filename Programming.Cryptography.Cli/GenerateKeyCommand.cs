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
    public void Execute()
    {
        var returnVerdi = _cryptographiService.GenerateKey();
        _fileService.WriteFile(@".\testfiles\key.dat", returnVerdi.Key);
        _fileService.WriteFile(@".\testfiles\iv.dat", returnVerdi.IV);

        Console.WriteLine($"Key: {returnVerdi.Key}");
        Console.WriteLine($"IV: {returnVerdi.IV}");

    }
    
}
