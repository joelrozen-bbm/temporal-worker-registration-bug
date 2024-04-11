using Temporalio.Activities;

namespace WorkflowsAndActivities;

public class Activities
{
    [Activity]
    public async Task SomeActivity(string workflowNumber)
    {
        Console.WriteLine($"Activity for workflow {workflowNumber}");
    }
}