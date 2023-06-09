using TodoAppNTier.Busniess.DependencyResolvers.Microsoft;
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
//builder.Services.AddRazorPages();
builder.Services.AddDependencies();
builder.Services.AddControllersWithViews();






var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/Home/NotFound", "?code{0}");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthorization();
app.MapDefaultControllerRoute();

app.Run();
