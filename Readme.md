Welcome the the readme on how to get the project running

On the repository, there are two projects, The api side which was written with dotnet 7
and the frontend which was written with react.

HOW TO SETUP THE API
1. Setup project dependencties by typing the command "dotnet restore"
1. Set project startup to the Presentation project
2. Setup a prosgres server using with the appropriate connection strings
3. apply the migration to the database by using the "update-database" command. This creates
the database and applies the migration
4. Project runs on http://localhost:5288/
5. To access swagger on the api side, use http://localhost:5288/swagger/index.html
6. You can proceed to test on swagger

HOW TO SETUP THE FRONTEND PROJECT
1. After opening the project
