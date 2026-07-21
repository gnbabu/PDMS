using PDMS.DataAccess.Helpers;
using PDMS.DataAccess.Interfaces;
using PDMS.DataAccess.Repositories;
using PDMS.DataAccess.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Provide the connection string used by the DataAccessUpgrade repositories.
DataAccessConfiguration.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register DataAccessUpgrade repositories (Repository Pattern).
builder.Services.AddScoped<IACHRepository, ACHRepository>();
builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
builder.Services.AddScoped<IC4Repository, C4Repository>();
builder.Services.AddScoped<ICMSRepository, CMSRepository>();
builder.Services.AddScoped<ICallTrackingRepository, CallTrackingRepository>();
builder.Services.AddScoped<ICredentialRepository, CredentialRepository>();
builder.Services.AddScoped<INUBCRepository, NUBCRepository>();
builder.Services.AddScoped<IPaperRequestRepository, PaperRequestRepository>();
builder.Services.AddScoped<IPartyRepository, PartyRepository>();
builder.Services.AddScoped<IProviderFeedRepository, ProviderFeedRepository>();
builder.Services.AddScoped<IRDMRepository, RDMRepository>();
builder.Services.AddScoped<IRegistrationProviderRepository, RegistrationProviderRepository>();
builder.Services.AddScoped<IStagingDataRepository, StagingDataRepository>();
builder.Services.AddScoped<IStateRepository, StateRepository>();
builder.Services.AddScoped<IUploadAttachmentRepository, UploadAttachmentRepository>();
builder.Services.AddScoped<IWPCRepository, WPCRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
