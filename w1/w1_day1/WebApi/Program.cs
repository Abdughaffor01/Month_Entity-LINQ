using Infrastructure;
using Infrastructure.Context;
using Infrastructure.Services.FileService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<DataContext>();
builder.Services.AddSingleton<ICategoryService,CategoryService>();
builder.Services.AddSingleton<IFileService,FileService>();
builder.Services.AddSingleton<IQuoteService,QuoteService>();
builder.Services.AddSingleton<IQuoteImageService,QuoteImageService>();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
