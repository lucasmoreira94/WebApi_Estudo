using WebApi_Estudo.DataContext;
using Microsoft.EntityFrameworkCore;
using WebApi_Estudo.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//***************************

builder.Services.AddScoped<IInscricaoInterface, InscricaoService>();
builder.Services.AddScoped<ILeadInterface, LeadService>();
builder.Services.AddScoped<IOfertaInterface, OfertaService>();
builder.Services.AddScoped<IProcessoSeletivoInterface, ProcessoSeletivoService>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
//***************************

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
