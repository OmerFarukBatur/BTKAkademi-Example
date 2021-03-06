using SehirRehberi.API;

var builder = WebApplication.CreateBuilder(args);


// Olusturulan configure servis dosyasını baslangıcta calısması icin eklendi
builder.Services.AddServices();
// Veri tabanından gelen verileri maplemek icin Automapper baslangıca eklendi
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
