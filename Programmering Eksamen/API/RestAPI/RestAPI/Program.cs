using CLassLib;
using Microsoft.AspNetCore.Cors;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAny",
        builder => builder.AllowAnyOrigin().
                           AllowAnyMethod().
                           AllowAnyHeader()
    );
    options.AddPolicy("AllowOnlyGetPut",
        builder => builder.AllowAnyOrigin().
                           WithMethods("GET","PUT").
                           AllowAnyHeader()
    );
});

builder.Services.AddSingleton<TestClassRepository>(new TestClassRepository());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAny");

app.UseAuthorization();

app.MapControllers();

app.Run();
