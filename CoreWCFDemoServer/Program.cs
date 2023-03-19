using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Server.IISIntegration;

var builder = WebApplication.CreateBuilder();

builder.Services.AddServiceModelServices();
builder.Services.AddServiceModelMetadata();
builder.Services.AddSingleton<IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior>();
builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme).AddNegotiate();
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseServiceModel(serviceBuilder =>
{
    serviceBuilder.AddService<Service>();
    var binding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
    binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Windows;
    serviceBuilder.AddServiceEndpoint<Service, IService>(binding, "/Service.svc");

    var serviceMetadataBehavior = app.Services.GetRequiredService<ServiceMetadataBehavior>();
    serviceMetadataBehavior.HttpsGetEnabled = true;
});

app.Run();
