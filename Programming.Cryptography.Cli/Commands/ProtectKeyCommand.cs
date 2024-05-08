public class ProtectKeyCommand
{
    private readonly ICryptographiService _cryptographiService;
    private readonly IFileService _fileService;    

    public ProtectKeyCommand(ICryptographiService cryptoService, IFileService fileService)
    {
        _cryptographiService = cryptoService;
        _fileService = fileService;

    }

    
    [Command("Protectkey", Description = @"Bruker DPAPI for å beskytte filene med Key og IV. Key and IV blir skrevet til filene Key.dat og Vector.dat. Det er kun brukeren som har tilgang til filene og de kan ikke flyttes til en annen maskin.
                                                                    Example: .\krypttool.exe protectkey --key-file Key.unprotected --iv-file Vector.unproteced ")]
    public string ProtectKey(
        [Option(Description = "Fil som inneholder ")] string keyFile, 
        [Option(Description = "File containing the IV")] string ivFile)
    {        
        var user = _cryptographiService.protectkey(keyFile, ivFile);
        return user;

    }
    
}
