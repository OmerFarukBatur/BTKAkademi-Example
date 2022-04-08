using SehirRehberi.API;

var builder = WebApplication.CreateBuilder(args);

// Olusturulan configure servis dosyas�n� baslang�cta cal�smas� icin eklendi
builder.Services.AddServices();
// Veri taban�ndan gelen verileri maplemek icin Automapper baslang�ca eklendi
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseAuthentication();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
