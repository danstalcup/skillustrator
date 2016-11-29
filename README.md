# Skillustrator

## API

### Run the application in ASP.NET Core container and database container

1. If you haven't built yet, run: 

    `docker-compose build`

1. To start the containers, run: 

    `docker-compose up -d`

### NOTE: To run a web container only

1. If you haven't built the image, run:

    `docker build -t <tag>:<image name> . `

1. Then run this to create the container: 

    `docker run -dt -p 5000:5000 -v $(pwd):/app -t msexcella:aspnetcore-dev-env`

1. To log into the container:

    `docker exec -it <container_name> bash`

### Add a database migration when model changes 

1. Run: 

    `dotnet ef migrations add <name>`

1. Add an item to the database. You can either use the following curl command, or your favorite tool like Postman:

    `
    curl -H "Content-Type: application/json" -X POST -d '{"name":"Posted"}' http://localhost:5000/api/articles
    `

## UI

### To run this Angular 2/Angular-CLI UI:

First, you will need Node 4 or higher, as well as NPM 3 or higher (download here https://nodejs.org/en/download/).

Second, install Angular-CLI globally:
```bash
npm install -g angular-cli
```

Run the following commands to install dependencies and create a server:

```bash
cd Vending-Machine-ng2
npm install
ng serve
```
Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.


## Specs

- Database
    - Local: SQL Server localdb, Production: Azure SQL
- API: 
    - ASP.NET Core Web API in a Docker container
    - Data layer: EF Core 1.0, repository pattern
- UI: Angular 2