using Server.API.Extensions;
using Server.Application.Extensions;
using Server.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

{
    builder.Host.AddLogging();

    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
}

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// add auto mapper validation.
app.AddAutoMapperValidation();

app.MigrateDatabase();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
