using Temporalio.Workflows;

namespace WorkflowsAndActivities;

[Workflow]
public class ScheduledWorkflow
{
    [WorkflowRun]
    public async Task RunAsync()
    {
        await Workflow.ExecuteActivityAsync((Activities act) => act.SomeActivity("scheduled"), new ActivityOptions
            {
                StartToCloseTimeout = TimeSpan.FromMinutes(1)
            }
        );
    }
}