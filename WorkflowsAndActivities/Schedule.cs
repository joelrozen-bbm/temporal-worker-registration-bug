using Temporalio.Client;
using Temporalio.Client.Schedules;
using Temporalio.Exceptions;

namespace WorkflowsAndActivities;

public record RandomSchedule
{
    public static readonly string _scheduleId = "random-schedule";
    private readonly ITemporalClient _temporalClient;

    public RandomSchedule(ITemporalClient temporalClient)
    {
        _temporalClient = temporalClient;
    }

    public async Task Run()
    {
        var action = ScheduleActionStartWorkflow.Create<ScheduledWorkflow>(
            wf => wf.RunAsync(),
            new WorkflowOptions
            {
                Id = Guid.NewGuid().ToString(),
                TaskQueue = "scheduled"
            }
        );

        var spec = new ScheduleSpec
        {
            Intervals = new[] { new ScheduleIntervalSpec(TimeSpan.FromSeconds(10)) }
        };

        var schedule = new Schedule(action, spec);

        try
        {
            await _temporalClient.CreateScheduleAsync(_scheduleId, schedule);
        }
        catch (ScheduleAlreadyRunningException)
        {
            return;
        }

        var handle = _temporalClient.GetScheduleHandle(_scheduleId);


        await handle.TriggerAsync();
    }
}