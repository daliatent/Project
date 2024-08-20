using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Services;
using Project.Exceptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<AddressesService>();
builder.Services.AddScoped<SeedServices>();
builder.Services.AddScoped<StudentsServices>();
builder.Services.AddScoped<MarksServices>();
builder.Services.AddScoped<SubjectsServices>();
builder.Services.AddControllers(options =>
{
    options.Filters.Add<CustomException>();
});
builder.Services.AddDbContext<StudentRegistryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StudentsDb")));
builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
