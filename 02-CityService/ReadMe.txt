EF code first
0.download .netcore sdk2.2+ from 
https://dotnet.microsoft.com/download

1. create .net core mvc application using vs2017 or vs2019

2. install entity framework core 2.2.2

3. add code 'City.cs' under DbModels and CityRepo.cs

4.run command (to seed configuration data into db)
EntityFrameworkCore\Add-Migration
EntityFrameworkCore\update-database

5. complete Controller code (dbcontext will be injected)
6. complete view.cshtml 

7. create app on azure
8. create db on azure 
9. put connect string in appsettings.json
10. download publish profile from azure 
11. publish app into app service 