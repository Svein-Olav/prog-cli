var builder = CoconaApp.CreateBuilder();
builder.Services.AddScoped<ICryptographiService,CryptographiService>();

var app = builder.Build();

app.AddCommands<DecryptCommand>();

app.Run();