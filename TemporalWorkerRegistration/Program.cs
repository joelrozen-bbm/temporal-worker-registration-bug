using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Temporalio.Client;
using Temporalio.Extensions.Hosting;
using WorkflowsAndActivities;

async Task RunWorkerAsync()
{
    var builder = Host.CreateApplicationBuilder();

    builder.Services.AddTemporalClient(options =>
    {
        options.TargetHost = "localhost:7233";
        options.Namespace = "default";
        options.LoggerFactory = LoggerFactory.Create(builder =>
            builder.AddSimpleConsole(options => options.TimestampFormat = "[HH:mm:ss] ")
                .SetMinimumLevel(LogLevel.Information));
    });

    builder.Services.AddHostedTemporalWorker("workflow-one")
        .AddScopedActivities<Activities>()
        .AddWorkflow<WorkflowOne>();

    builder.Services.AddHostedTemporalWorker("workflow-two")
        .AddScopedActivities<Activities>()
        .AddWorkflow<WorkflowTwo>();

    builder.Services.AddHostedTemporalWorker("workflow-three")
        .AddScopedActivities<Activities>()
        .AddWorkflow<WorkflowThree>();


    builder.Services.AddHostedTemporalWorker("workflow-four")
        .AddScopedActivities<Activities>()
        .AddWorkflow<WorkflowFour>();

    builder.Services.AddHostedTemporalWorker("workflow-five")
        .AddScopedActivities<Activities>()
        // .AddWorkflow<WorkflowOne>()
        // .AddWorkflow<WorkflowTwo>()
        // .AddWorkflow<WorkflowThree>()
        // .AddWorkflow<WorkflowFour>()
        .AddWorkflow<WorkflowFive>();
        // .AddWorkflow<WorkflowSix>();

    builder.Services.AddHostedTemporalWorker("workflow-six")
        .AddScopedActivities<Activities>()
        .AddWorkflow<WorkflowSix>();

    builder.Services.AddHostedTemporalWorker("workflow-seven")
        .AddScopedActivities<Activities>()
        .AddWorkflow<WorkflowSeven>();

    builder.Services.AddHostedTemporalWorker("workflow-eight")
        .AddScopedActivities<Activities>()
        .AddWorkflow<WorkflowEight>();

    builder.Services.AddHostedTemporalWorker("workflow-nine")
        .AddScopedActivities<Activities>()
        .AddWorkflow<WorkflowNine>();

    builder.Services.AddHostedTemporalWorker("workflow-ten")
        .AddScopedActivities<Activities>()
        .AddWorkflow<WorkflowTen>();

    builder.Services.AddHostedTemporalWorker("workflow-eleven")
        .AddScopedActivities<Activities>()
        .AddWorkflow<WorkflowEleven>();

    builder.Services.AddHostedTemporalWorker("workflow-twelve")
        .AddScopedActivities<Activities>()
        .AddWorkflow<WorkflowTwelve>();

    builder.Services.AddHostedTemporalWorker("workflow-thirteen")
        .AddScopedActivities<Activities>()
        .AddWorkflow<WorkflowThirteen>();

    builder.Services.AddHostedTemporalWorker("workflow-fourteen")
        .AddScopedActivities<Activities>()
        .AddWorkflow<WorkflowFourteen>();

    builder.Services.AddHostedTemporalWorker("workflow-fifteen")
        .AddScopedActivities<Activities>()
        .AddWorkflow<WorkflowFifteen>()
        .AddWorkflow<WorkflowFifteenChild>();
    
    builder.Services.AddHostedTemporalWorker("scheduled")
        .AddScopedActivities<Activities>()
        .AddWorkflow<ScheduledWorkflow>();



    builder.Services.AddTransient<RandomSchedule>();

    var host = builder.Build();
    var schedule = host.Services.GetRequiredService<RandomSchedule>();
    
    try
    {
        await schedule.Run();
        host.Run();

    }
    catch (OperationCanceledException)
    {
        Console.WriteLine("Workers cancelled");
    }
}

async Task ExecuteWorkflowsAsync()
{
    var client = await TemporalClient.ConnectAsync(new TemporalClientConnectOptions("localhost:7233")
    {
        LoggerFactory = LoggerFactory.Create(builder =>
            builder.AddSimpleConsole(options => options.TimestampFormat = "[HH:mm:ss] ")
                .SetMinimumLevel(LogLevel.Information))
    });

    for (var i = 0; i < 10; i++)
    {
        var wfOne = client.StartWorkflowAsync(
            (WorkflowOne wf) => wf.RunAsync(), new WorkflowOptions(Guid.NewGuid().ToString(), "workflow-one"));

        var wfTwo = client.StartWorkflowAsync((WorkflowTwo wf) => wf.RunAsync(),
            new WorkflowOptions(Guid.NewGuid().ToString(), "workflow-two"));

        var wfThree = client.StartWorkflowAsync((WorkflowThree wf) => wf.RunAsync(), new WorkflowOptions(
            Guid.NewGuid().ToString(), "workflow-three"));

        var wfFour = client.StartWorkflowAsync((WorkflowFour wf) => wf.RunAsync(), new WorkflowOptions(
            Guid.NewGuid().ToString(), "workflow-four"));

        var wfFive = client.StartWorkflowAsync((WorkflowFive wf) => wf.RunAsync(), new WorkflowOptions(
            Guid.NewGuid().ToString(), "workflow-five"));

        var wfSix = client.StartWorkflowAsync((WorkflowSix wf) => wf.RunAsync(), new WorkflowOptions(
            Guid.NewGuid().ToString(), "workflow-six"));

        var wdSeven = client.StartWorkflowAsync((WorkflowSeven wf) => wf.RunAsync(), new WorkflowOptions(
            Guid.NewGuid().ToString(), "workflow-seven"));

        var wfEight = client.StartWorkflowAsync((WorkflowEight wf) => wf.RunAsync(), new WorkflowOptions(
            Guid.NewGuid().ToString(), "workflow-eight"));

        var wfNine = client.StartWorkflowAsync((WorkflowNine wf) => wf.RunAsync(), new WorkflowOptions(
            Guid.NewGuid().ToString(), "workflow-nine"));

        var wfTen = client.StartWorkflowAsync((WorkflowTen wf) => wf.RunAsync(), new WorkflowOptions(
            Guid.NewGuid().ToString(), "workflow-ten"));

        var wfEleven = client.StartWorkflowAsync((WorkflowEleven wf) => wf.RunAsync(), new WorkflowOptions(
            Guid.NewGuid().ToString(), "workflow-eleven"));

        var wfTwelve = client.StartWorkflowAsync((WorkflowTwelve wf) => wf.RunAsync(), new WorkflowOptions(
            Guid.NewGuid().ToString(), "workflow-twelve"));

        var wfThirteen = client.StartWorkflowAsync((WorkflowThirteen wf) => wf.RunAsync(), new WorkflowOptions(
            Guid.NewGuid().ToString(), "workflow-thirteen"));

        var wfFourteen = client.StartWorkflowAsync((WorkflowFourteen wf) => wf.RunAsync(), new WorkflowOptions(
            Guid.NewGuid().ToString(), "workflow-fourteen"));

        var wfFifteen = client.StartWorkflowAsync((WorkflowFifteen wf) => wf.RunAsync(), new WorkflowOptions(
            Guid.NewGuid().ToString(), "workflow-fifteen"));

        await Task.WhenAll(wfOne, wfTwo, wfThree, wfFour, wfFive, wfSix, wdSeven, wfEight, wfNine, wfTen, wfEleven,
            wfTwelve, wfThirteen, wfFourteen, wfFifteen);
    }
}

switch (args.ElementAtOrDefault(0))
{
    case "workers":
        await RunWorkerAsync();
        break;
    case "workflows":
        await ExecuteWorkflowsAsync();
        break;
    default:
        throw new ArgumentException("Must pass 'workers' or 'workflows' as the first argument");
}