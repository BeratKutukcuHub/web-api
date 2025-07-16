
using Backend.Extensions;
using NLog;
using Services.Contract;

var builder = WebApplication.CreateBuilder(); // => İnşaa Edicidir {burada servis kaydı yapılır}
var logger = LogManager.Setup()
    .LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
    

    
builder.Services.AddControllers()
.AddApplicationPart(typeof(Presantation.Controller.ProductController).Assembly);
builder.Services.ConfigureDbContextExtension(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AllRepositoryServices();
builder.Services.LoggerService();


var app = builder.Build();
app.ConfigureExtensionsHandler(app.Services.GetRequiredService<ILoggerService>());
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();