using Temporalio.Workflows;

namespace WorkflowsAndActivities;

[Workflow]
public class WorkflowThirteen
{
    [WorkflowRun]
    public async Task RunAsync()
    {
        await Workflow.ExecuteActivityAsync((Activities act) => act.SomeActivity("thirteen"), new ActivityOptions
            {
                StartToCloseTimeout = TimeSpan.FromMinutes(1)
            }
        );
    }
}