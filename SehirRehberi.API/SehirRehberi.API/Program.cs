using SehirRehberi.API;

var builder = WebApplication.CreateBuilder(args);

// Olusturulan configure servis dosyasýný baslangýcta calýsmasý icin eklendi
builder.Services.AddServices();
// Veri tabanýndan gelen verileri maplemek icin Automapper baslangýca eklendi
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
