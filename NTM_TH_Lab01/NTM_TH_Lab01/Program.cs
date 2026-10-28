
using Microsoft.EntityFrameworkCore;
using NTM_TH_Lab01.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    var messages = options.ModelBindingMessageProvider;
    messages.SetValueMustBeANumberAccessor(
        field => $"{field} phải là số.");
    messages.SetAttemptedValueIsInvalidAccessor(
        (value, field) => $"Giá trị '{value}' không hợp lệ cho {field}.");
    messages.SetValueIsInvalidAccessor(
        value => $"Giá trị '{value}' không hợp lệ.");
    messages.SetValueMustNotBeNullAccessor(
        _ => "Vui lòng nhập dữ liệu.");
});

builder.Services.AddDbContext<SchoolContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("SchoolContext")
        ?? throw new InvalidOperationException("Thiếu cấu hình SchoolContext.")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<SchoolContext>();
    DbInitializer.Initialize(db);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
