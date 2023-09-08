Welcome the the readme on how to get the project running

On the repository, there are two projects, The api side which was written with dotnet 7
and the frontend which was written with react.

HOW TO SETUP THE API

1. Setup project dependencties by typing the command "dotnet restore"
2. Set project startup to the Presentation project
3. Setup a prosgres server using with the appropriate connection strings
4. apply the migration to the database by using the "update-database" command. This creates
   the database and applies the migration
5. Project runs on http://localhost:5288/
6. To access swagger on the api side, use http://localhost:5288/swagger/index.html
7. You can proceed to test on swagger

HOW TO SETUP THE FRONTEND PROJECT

1. After opening the project, on the integrated terminal, type npm install to restore all dependencies
2. You can confirm that the api url is same with the one that runs on the backend by going to the api
   folder on the frontend and the axios class. That way you won't run into issues
3. start the project using npm run start
