# Insight.Scheduler

### Overview:
Insight.Scheduler is a scheduled console app that connects to the IEX API for stock-exchange data. By using the
Quartz.Net library, the app is able to schedule requests made to the IEX API. This app is meant to be used in conjunction
with other apps, in which the data from the scheduler will be processed.

### Architecture:
- Insight.Scheduler utilizes the built-in dependency injection functionality of .NET Core, in which the
IJob interface is implemented by the IScheduledJob interface, which is registered to the service container
- The IScheduledJob services are resolved from the container, and then processed by the Quartz.Net library for scheduling
- Once the IScheduledJob services are called, they will reach-out to the IEX Cloud API for specific stock exchange data,
and persist said data in a SQL Server database by calling T-SQL stored procedures

### Future Work:
- Create a Repository service for Job data, in order to check for possible duplicate
Group number entries from the GenerateGroup() method in the BaseJob type