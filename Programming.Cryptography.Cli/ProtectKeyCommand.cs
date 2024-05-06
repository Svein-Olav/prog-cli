public class ProtectKeyCommand
{
    private readonly ICryptographiService _cryptographiService;
    private readonly IFileService _fileService;    

    public ProtectKeyCommand(ICryptographiService cryptoService, IFileService fileService)
    {
        _cryptographiService = cryptoService;
        _fileService = fileService;

    }

    
    [Command("Protectkey", 
            Description = @"Protects the key so that only the user kan decrypt the files containing the key, 
                            Example: dotnet run protectkey. The key and IV will be written to the files key.protected and iv.proteced. In folder testfiles.")]
    public void ProtectKey(
        [Option(Description = "File containing the key")] string keyFile, 
        [Option(Description = "File containing the IV")] string ivFile)
    {
        if (!_fileService.HasDatExtension(keyFile) || !_fileService.HasDatExtension(ivFile))
        {
            Console.WriteLine("The key and IV files must have the .dat extension");
            return;
        }

        _cryptographiService.protectkey(keyFile, ivFile);        

    }
    
}
