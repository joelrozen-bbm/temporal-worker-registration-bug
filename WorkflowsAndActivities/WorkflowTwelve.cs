using Temporalio.Workflows;

namespace WorkflowsAndActivities;

[Workflow]
public class WorkflowTwelve
{
    [WorkflowRun]
    public async Task RunAsync()
    {
        await Workflow.ExecuteActivityAsync((Activities act) => act.SomeActivity("twelve"), new ActivityOptions
            {
                StartToCloseTimeout = TimeSpan.FromMinutes(1)
            }
        );
    }
}