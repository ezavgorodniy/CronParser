Project is written using Visual Studio 2019. 

To build the project please install .NET Core 3.1 SDK https://dotnet.microsoft.com/download/dotnet-core/3.1

Than cd into the project and run 

- dotnet build 
- dotnet run --project CronParser "<your-cron-expression>"
  
  Examples of commands are:
  
  d:\Personal\CronParser\src>dotnet run --project CronParser
  d:\Personal\CronParser\src>dotnet build
  
  To familiarise yourself with a code - debug how CronParser.Tests.FunctionalTests is working. 
  
  Currently CronParser only support basic operations for minutes, hours, days of month, month, day of week. Without any cross operations like 5W (closest weekday to 5th day of month), 6L (last Friday of the month) or 2#2 (second Monday of the month).
