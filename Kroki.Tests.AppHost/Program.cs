var builder = DistributedApplication.CreateBuilder(args);

builder.AddKrokiServer("kroki")
    .WithKrokiMermaidServer()
    .WithKrokiBpmnServer()
    .WithKrokiExcalidrawServer()
    .WithKrokiDiagramsNetServer();


builder.Build().Run();
