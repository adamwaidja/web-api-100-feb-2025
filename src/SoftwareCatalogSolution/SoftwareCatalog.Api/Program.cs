var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//ABOVE THIS LINE IS CONFIGURING THE INTERNALS OF THE API PROJECT

var app = builder.Build(); //THE LINE IN THE SAND

//EVERYTHING AFTER THIS LINE IS CONFIGUTING HOW THE WEB SERVER HANDLES INCOMING REQUESTS/RESPONSES

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); //JSON OPEN API spec
    app.UseSwaggerUI(); //html page - visualise
}

app.UseAuthorization();
// trying initial commit
app.MapControllers(); //this will scan your entire project for any controllers & use those attributes (httpGet,) to create a "route table" like a phone book.
//REFLECTION - The ability to have code look at itself
app.Run();

//I WILL EXPLAIN THIS LATER
public partial class Program { }