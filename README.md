# Temporal Worker Registration Bug

## Steps:
1) Spin local temporal server on :7233
2) in terminal run `dotnet run workers` in the `TemporalWorkerRegistration` folder
3) in a new terminal, run `dotnet run workflows`
4) Observe in Temporal UI, all workflows are actioned, except the one on a schedule. It never starts, and the worker is not registered as a Workflow Poller.
5) ctrl+c the workers, swap the order of the `.AddHostedTemporalWorker` call of the "scheduled" workflow and `workflow-fifteen`

```csharp
builder.Services.AddHostedTemporalWorker("workflow-fifteen")
    .AddScopedActivities<Activities>()
    .AddWorkflow<WorkflowFifteen>()
    .AddWorkflow<WorkflowFifteenChild>();

builder.Services.AddHostedTemporalWorker("scheduled")
    .AddScopedActivities<Activities>()
    .AddWorkflow<ScheduledWorkflow>();
```

becomes

```csharp
builder.Services.AddHostedTemporalWorker("scheduled")
    .AddScopedActivities<Activities>()
    .AddWorkflow<ScheduledWorkflow>();

builder.Services.AddHostedTemporalWorker("workflow-fifteen")
    .AddScopedActivities<Activities>()
    .AddWorkflow<WorkflowFifteen>()
    .AddWorkflow<WorkflowFifteenChild>();
```

7) Repeat steps 2-4. Observe the "Scheduled" workflows are now handled, but all "Workflow Fifteens" fail to start.


![img.png](img.png)

Whichever Worker is registered *last* is the one that never picks up and starts any workflows.

## Expected Behaviour
All workflows should be picked up by their respective workers, and started as expected.

### Interim fix
This behaviour does not appear to occur if the workers are registered using `new TemporalWorker()` instead of the Services Extension Methods.
