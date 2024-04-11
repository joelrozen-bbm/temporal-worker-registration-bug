using Temporalio.Workflows;

namespace WorkflowsAndActivities;

[Workflow]
public class WorkflowThree
{
    [WorkflowRun]
    public async Task RunAsync()
    {
        await Workflow.ExecuteActivityAsync((Activities act) => act.SomeActivity("three"), new ActivityOptions
            {
                StartToCloseTimeout = TimeSpan.FromMinutes(1)
            }
        );
    }
}