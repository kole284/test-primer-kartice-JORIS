    using backend.Data;
    using backend.Services;
    using Microsoft.EntityFrameworkCore;

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddDbContext<KlijentiKontekst>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
    builder.Services.AddScoped<IRepozitorijumKnjiga, RepozitorijumKnjiga>();
    builder.Services.AddControllers();
    builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
    });

    var app = builder.Build();

    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseCors();

    app.MapControllers();
    app.Run();
