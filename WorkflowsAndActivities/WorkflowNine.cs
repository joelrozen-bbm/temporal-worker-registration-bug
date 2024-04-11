using Temporalio.Workflows;

namespace WorkflowsAndActivities;

[Workflow]
public class WorkflowNine
{
    [WorkflowRun]
    public async Task RunAsync()
    {
        await Workflow.ExecuteActivityAsync((Activities act) => act.SomeActivity("nine"), new ActivityOptions
            {
                StartToCloseTimeout = TimeSpan.FromMinutes(1)
            }
        );
    }
}