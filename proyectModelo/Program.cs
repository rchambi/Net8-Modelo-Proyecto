using Microsoft.EntityFrameworkCore;
using proyectModelo.Modelos;
using proyectModelo.Repositories;
using proyectModelo.Services;
using proyectModelo.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
///INICIO KOKI
builder.Services.AddDbContext<ApplicationDbContext>((Action<DbContextOptionsBuilder>)(options => options
.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
.UseSeeding(GenerarSeedNew())// se recomienda tener los dos metodos---> SEED
.UseAsyncSeeding(GenerarSeedNewAsync())// se recomienda tener los dos metodos---> SEED
));



builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
//builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddScoped<IPersonaService, PersonaService>();
///FIN KOKI


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

//--->SEED
using (var scope= app.Services.CreateScope())
{
    var appDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();//no es el contexto del proyecto es el global
    appDbContext.Database.EnsureCreated();
}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static Action<DbContext, bool> GenerarSeedNew()
{
    return (context, _) =>
    {
        var existePersona = context.Set<Persona>().Any(x => x.Nombre == "juan");

        if (!existePersona)
        {
            context.Set<Persona>().Add(new Persona { Nombre = "juan", Apellido="Perez", FechaNacimiento = DateTime.Now });
            context.SaveChanges();
        }

    };
}


static Func<DbContext, bool, CancellationToken, Task> GenerarSeedNewAsync()
{
    return async (context, _, CancellationToken) =>
    {
        var existePersona = await context.Set<Persona>().AnyAsync(x => x.Nombre == "Roly", cancellationToken: CancellationToken);

        if (!existePersona)
        {
            context.Set<Persona>().Add(new Persona { Nombre = "KOKIII", FechaNacimiento = DateTime.Now });
            await context.SaveChangesAsync();
        }
    };
}