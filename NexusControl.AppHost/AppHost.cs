var builder = DistributedApplication.CreateBuilder(args);

var web = builder.AddProject<Projects.NexusControl_Web>("web")
    .WithExternalHttpEndpoints();

builder.Build().Run();
