
In the JobHub web API project, Layered Architecture has been implemented, and I have tried to write code that adheres to the SOLID principles as much as possible. 
I believe that only 40% of the project has been completed so far.

Since the project is not large, I found it more appropriate to use folders instead of separate Class Libraries for each layer. 

Of course, using Class Libraries makes testing much easier. Currently, only APIs for Authentication and Job List have been developed in the project. 

The reason for having separate ViewModel and DTO folders is that I use DTOs for EF Core performance tuning. 

In the coming days, I will develop APIs for the Account section and features like adding jobs to meet the project's requirements.

Features that are currently missing but will be added within this week include xUnit (FakeItEasy), Filters, Security Measures, Logging with SeriLog, and Indexes in SQL Server. 

In addition to GitIgnore, I have stored configuration data in the secret.json file.

WHAT I USED

MS SQL 
JWT 
Entity Framework Core and Performance Tuning Feature
Layered Architecture
Relational DataBase MS

Contact : nihadelesgerov0@gmail.com