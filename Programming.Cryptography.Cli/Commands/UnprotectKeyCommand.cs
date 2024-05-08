public class UnprotectKeyCommand
{
    private readonly ICryptographiService _cryptographiService;
    private readonly IFileService _fileService;    

    public UnprotectKeyCommand(ICryptographiService cryptoService, IFileService fileService)
    {
        _cryptographiService = cryptoService;
        _fileService = fileService;

    }

    
    [Command("Unprotectkey", 
            Description = @"Protects the key so that only the user kan decrypt the files containing the key, 
                            Example: .\krypttool.exe protectkey. The key and IV will be written to the files key.unprotected and iv.unprotected. In folder testfiles.")]
    public void UnprotectKey(
        [Option(Description = "File som inneholder Key på base64format")] string keyFile, 
        [Option(Description = "File som inneholder IV på base64format")] string ivFile)
    {
        if (!_fileService.HasDatExtension(keyFile) || !_fileService.HasDatExtension(ivFile))
        {
            Console.WriteLine("The key and IV files must have the .dat extension");
            return;
        }
        
        _cryptographiService.unprotectkey(keyFile, ivFile);        

    }    
}
