using cadastro_livros.Data;
using cadastro_livros.Domain;
using cadastro_livros.Exceptions;
using cadastro_livros.Exceptions.Interfaces;
using cadastro_livros.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IEditora, EditoraDomain>();
builder.Services.AddScoped<IAutor, AutorDomain>();
builder.Services.AddScoped<ILivro, LivroDomain>();
builder.Services.AddScoped<IEditoraException, EditoraException>(); //open space usa transient

//DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseLazyLoadingProxies().UseNpgsql(builder.Configuration.GetConnectionString("Default"),
    assembly => assembly.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
});

// AddAutoMapper 
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.

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


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
