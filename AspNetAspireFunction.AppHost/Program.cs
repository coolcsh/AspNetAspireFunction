var builder = DistributedApplication.CreateBuilder(args);

var function = builder.AddAzureFunctionsProject<Projects.AspNetAspireFunction>("function");

builder.AddProject<Projects.BlazorFrontEnd>("blazorfrontend")
    .WithReference(function)
    .WaitFor(function)
    .WithExternalHttpEndpoints();

builder.Build().Run();
