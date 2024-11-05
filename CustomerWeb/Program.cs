using CustomerWeb.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient(); 
builder.Services.AddScoped<CustomerService>(); 
builder.WebHost.UseSetting("detailedErrors", "true");

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddScoped<ICustomerService, CustomerService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{   
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Customer}/{action=Index}/{id?}");

app.Run();
