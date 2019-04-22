# Gateways

General description
---
The project was developed following the structure of an enterprise arquitecture application, 
by using n-tiers and applying different patterns like:
- Unit of Work
- Repository
- Dependency Injection
- Dependency Inversion
- Inversion of Control

Technologies and tools
---
- VS 2017
- MSSQL Server 2017
- Entity Framework 6.2.0 (Code First approach)
- Automapper (Map Entities <=> Dto objects)
- Ninject (Dependency Injection)
- ASP.NET Web API 2

Project Structure
---
- ABSTRACTION > DATA ACCESS
	- Musala.GatewayMgmt.Interfaces.DataAccess (Repository Contracts)
- BUSINESS
	- Musala.GatewayMgmt.Services (Business concrete implementation)
- DEPENDENCY
	- Musala.GatewayMgmt.Repositories.Ef (Repositories concrete implementation, EF Mapping, Fluent API,  )
- COMMON
	- Musala.GatewayMgmt.Mapper (For Mapper profiles)
	- Musala.GatewayMgmt.Model (Entities, DTOs)
	- Musala.Infrastructure (base infraestructure stuff, reusable by others projects)
- PRESENTATION > SYSTEM INTERFACES
	- Musala.GatewayMgmt.SystemInterfaces.Services (Business Contracts)
- PRESENTATION
	- Musala.GatewayMgmt.Web.Api

Prerequisites
---
- Visual Studio 2017/MSBuild
- Windows O.S.
- Microsoft SQL Server
- Optional: Internet Information Services (IIS), if you want to publish the solution)

Other requirements:
---
- NUKE: Build Automation Tool
- Install by using powershell/cmd console: 
> dotnet tool install Nuke.GlobalTool --global


Instructions
---
1. Clone project: 
	git clone https://github.com/dbarrera1984/Gateways.git
2. Compile & Build project with the automated build tool included.
3. Open a powershell console with the path of the working dir.
4. Execute powershell script in the working dir root: 
> .\build.ps1
5. Open the solution with VS 2017 for test the solution with VS.
6. Before run migrations you must verify connection string in Web.config file. You must provide your own settings.
6. Open "Nuget Package Console"
7. Select "Default Project": Musala.GatewayMgmt.Repositories.Ef
8. Execute the command: 
> Update-Database -Verbose
9. Run project in VS (verify that Startup Project is: "Musala.GatewayMgmt.Presentation.Web.Api")
10. (Optional) Publish solution in VS2017: Right-click in Musala.GatewayMgmt.Presentation.Web.Api project => "Publish ..."
11. (Optional) Create a Website by using IIS, select the folder (previously selected in "Publish settings")
12. (Optional) Test API in web browser: For example: http://localhost/
13. Test api in Web browser (by using Swagger):
> http://localhost/

> http://localhost/swagger/
14. SQL Script with demo data is in:
> https://github.com/dbarrera1984/Gateways/blob/master/db/INSERT_DEMO_DATA.sql
