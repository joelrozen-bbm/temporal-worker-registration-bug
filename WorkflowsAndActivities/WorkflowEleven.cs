using Temporalio.Workflows;

namespace WorkflowsAndActivities;

[Workflow]
public class WorkflowEleven
{
    [WorkflowRun]
    public async Task RunAsync()
    {
        await Workflow.ExecuteActivityAsync((Activities act) => act.SomeActivity("eleven"), new ActivityOptions
            {
                StartToCloseTimeout = TimeSpan.FromMinutes(1)
            }
        );
    }
}