using Temporalio.Workflows;

namespace WorkflowsAndActivities;

[Workflow]
public class WorkflowFifteenChild
{
    [WorkflowRun]
    public async Task RunAsync()
    {
        await Workflow.ExecuteActivityAsync((Activities act) => act.SomeActivity("fifteen-child"), new ActivityOptions
            {
                StartToCloseTimeout = TimeSpan.FromMinutes(1)
            }
        );
    }
}