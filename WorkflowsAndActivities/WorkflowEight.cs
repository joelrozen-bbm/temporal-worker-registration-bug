using Temporalio.Workflows;

namespace WorkflowsAndActivities;

[Workflow]
public class WorkflowEight
{
    [WorkflowRun]
    public async Task RunAsync()
    {
        await Workflow.ExecuteActivityAsync((Activities act) => act.SomeActivity("eight"), new ActivityOptions
            {
                StartToCloseTimeout = TimeSpan.FromMinutes(1)
            }
        );
    }
}