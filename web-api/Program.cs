using System.Text;
using web_api.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using web_api.Models;
using web_api.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});;
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAuthentication();

builder.Services.AddScoped<IRandevuService, RandevuService>();

builder.Services.AddIdentityApiEndpoints<IdentityUser>().
    AddRoles<IdentityRole>().
    AddEntityFrameworkStores<AppDbContext>();




builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});



var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseHttpsRedirection();
app.MapIdentityApi<IdentityUser>();


//app.UseHttpsRedirection();
app.UseAuthentication();
app.UseRouting();
app.MapControllers();
app.Use(async (context, next) =>
{
    var initialBody = context.Request.Body;

    using (var bodyReader = new StreamReader(context.Request.Body))
    {
        string body = await bodyReader.ReadToEndAsync();
        Console.WriteLine(context.Request.Path);
        Console.WriteLine(body);
        context.Request.Body = new MemoryStream(Encoding.UTF8.GetBytes(body));
        await next.Invoke();
        context.Request.Body = initialBody;
    }
});
app.UseAuthorization();
app.Run();


