using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Quartz;
using Quartz.Impl;

namespace TA_Web_2020_API.Helper
{
    public class JobScheduler
    {
        public static async Task Start()
        {
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            if (!scheduler.IsStarted)
            {
                await scheduler.Start();
            }

            IJobDetail job = JobBuilder.Create<EmailJob>().Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                //.WithDailyTimeIntervalSchedule
                //  (s =>
                //     s.WithIntervalInHours(24)
                //    .OnEveryDay()
                //    .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(0, 0))
                //  )
                .StartNow()
                 .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(90)
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }
        public static async Task End()
        {
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            if (scheduler.IsStarted)
            {
                await scheduler.Shutdown();
            }
        }
    }
}