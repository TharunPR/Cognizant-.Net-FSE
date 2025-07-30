
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();       // 👈 Required for Swagger
builder.Services.AddSwaggerGen();                // 👈 Required for Swagger

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();                            // 👈 Enables Swagger middleware
    app.UseSwaggerUI();                          // 👈 Enables Swagger UI
}

app.UseAuthorization();

app.MapControllers();

app.Run();
