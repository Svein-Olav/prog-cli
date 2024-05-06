var builder = CoconaApp.CreateBuilder();
builder.Services.AddScoped<ICryptographiService,CryptographiService>();
builder.Services.AddScoped<IFileService,FileService>();

var app = builder.Build();

app.AddCommands<DecryptCommand>();
app.AddCommands<EncryptCommand>();
app.AddCommands<GenerateKeyCommand>();
app.AddCommands<UnprotectKeyCommand>();
app.AddCommands<ProtectKeyCommand>();

app.Run();


