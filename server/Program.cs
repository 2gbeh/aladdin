using server.Shared.Extensions;
using server.Infrastructure.Persistence;
using server.Infrastructure.Persistence.Seeders;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container using extension methods
builder.Services.AddSwaggerDocumentation();
builder.Services.AddApiControllers();
builder.Services.AddRazorPagesWrapper();
builder.Services.AddApplicationServices();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddFileUploadServices(builder.Configuration);

var app = builder.Build();

// using (var scope = app.Services.CreateScope())
// {
//     var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
//     context.Database.Migrate();
//     DbSeeder.Seed(context);
// }

// Configure the HTTP request pipeline.
app.UseSwaggerDocumentation();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
// app.UseAuthentication();
// app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
