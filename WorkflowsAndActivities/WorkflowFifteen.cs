using Temporalio.Workflows;

namespace WorkflowsAndActivities;

[Workflow]
public class WorkflowFifteen
{
    [WorkflowRun]
    public async Task RunAsync()
    {
        await Workflow.ExecuteActivityAsync((Activities act) => act.SomeActivity("fifteen"), new ActivityOptions
            {
                StartToCloseTimeout = TimeSpan.FromMinutes(1)
            }
        );

        await Workflow.ExecuteChildWorkflowAsync<WorkflowFifteenChild>(wf => wf.RunAsync());
    }
}