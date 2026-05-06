using ApplicationLayer;    // Extension Method بتاعتك
using InfrastructureLayer; // Extension Method بتاعتك

var builder = WebApplication.CreateBuilder(args);

// 1. تسجيل خدمات كل طبقة (Clean & Organized)
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

// 2. خدمات الـ API التقليدية
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Clean Arch Product API", Version = "v1" });
});

builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// 3. الـ Middleware Pipeline
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clean Arch Product API v1");
        c.RoutePrefix = string.Empty;   // عشان يفتح Swagger على الـ Root مباشرة
    });
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

app.Run();