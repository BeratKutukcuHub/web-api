

using Backend.Extensions;

var builder = WebApplication.CreateBuilder(); // => İnşaa Edicidir {burada servis kaydı yapılır}
builder.Services.AddControllers()
.AddApplicationPart(typeof(Presantation.Controller.ProductController).Assembly);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AllRepositoryServices();
// Yukarıda geçirilen Servicesler ile build işlemine başlanır.
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();