using BookManager.Db;
using BookManager.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddDbContext<BookDbContext>(options =>
    options.UseInMemoryDatabase("BookDb"));

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()   // Allow all origins
              .AllowAnyMethod()   // Allow all HTTP methods (GET, POST, etc.)
              .AllowAnyHeader();  // Allow all headers
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Apply CORS policy before other middleware
app.UseCors("AllowAll");  // This should be placed here

app.UseHttpsRedirection(); // Redirect HTTP to HTTPS
app.UseAuthorization();    // Enable authorization

app.MapControllers();

app.Run();
