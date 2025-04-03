using System.Reflection;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using TesteWebAPI.data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.SwaggerDoc(
        "v1",
        new Microsoft.OpenApi.Models.OpenApiInfo()
        {
            Title = "Teste Prático",
            Version = "1.0"
        }
    );

    var xmlCommentsFile = "TesteWebAPI.xml";
    var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);
    // Console.WriteLine($"Swagger XML Path: {xmlCommentsFullPath}");


    options.IncludeXmlComments(xmlCommentsFullPath);
}
);
builder.Services.AddControllers()
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); //ignorar o Loop
builder.Services.AddScoped<IRepository, Repository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API v1"); // ⚠️ Isso define o caminho correto
    });
}

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

// app.UseHttpsRedirection();

app.Run();


// Para detalhar erro
// app.UseExceptionHandler(appBuilder =>
// {
//     appBuilder.Run(async context =>
//     {
//         var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
//         if (exception != null)
//         {
//             Console.WriteLine($"Erro: {exception.Message}");
//         }
//         context.Response.StatusCode = 500;
//         await context.Response.WriteAsync("Erro interno no servidor");
//     });
// });
