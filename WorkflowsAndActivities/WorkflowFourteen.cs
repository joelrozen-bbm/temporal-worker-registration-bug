using Temporalio.Workflows;

namespace WorkflowsAndActivities;

[Workflow]
public class WorkflowFourteen
{
    [WorkflowRun]
    public async Task RunAsync()
    {
        await Workflow.ExecuteActivityAsync((Activities act) => act.SomeActivity("fourteen"), new ActivityOptions
            {
                StartToCloseTimeout = TimeSpan.FromMinutes(1)
            }
        );
    }
}