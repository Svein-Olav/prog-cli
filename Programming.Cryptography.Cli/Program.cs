
ICryptoService cryptoService = new CryptoService();

var builder = CoconaApp.CreateBuilder();


var app = builder.Build();

app.AddCommand((string name, int age) =>
{
    Console.WriteLine($"Hello, {name}! You are {age} years old.");
});

app.Run();