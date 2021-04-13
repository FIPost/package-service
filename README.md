![ipost-logo](https://github.com/FIPost/docs/blob/master/assets/logo-name.png?raw=true)
[![Publish Docker image](https://github.com/FIPost/pakketservice/actions/workflows/docker-publish.yml/badge.svg)](https://github.com/FIPost/pakketservice/actions/workflows/docker-publish.yml)
# Package Service
.NET Core 3.1 API service for Fontys Internal Packages.
<h3 align="center">
  <a href="https://github.com/FIPost/docs">Documentation</a>
</h3>

## Getting Started with Docker
```zsh
docker-compose up --build
```

<b>Note</b><br/>
Make sure that you are in the directory of `docker-compose.yml` when running these commands.

### Inspect the database
I use `Azure Data Studio` to do this, but you can also use any other database program compatible for sql server.

In `docker-compose.yml` you can see that port 1433 is exposed on the MSSQL container. You can connect to this database with the following properties:

| Property | Value       |
|--------------|-------------|
| Server | `localhost`          |
| Authentication type | `sa`    |
| Password | `Your_password123` |
| Database | `<Default>`        |
| Server group | `<Default>`    |


### Insert Data
POST: `http://localhost:5001/api/Packages`

```json
{
    "ReceiverId": "1",
    "TrackAndTraceId": "1",
    "CollectionPointId": "1",
    "Sender": "Cheese Factory",
    "Name": "1KG of hot cheese"
}
```

POST: `http://localhost:5001/api/Packages`
```json
{
    "ReceiverId": "2",
    "TrackAndTraceId": "3",
    "CollectionPointId": "3",
    "Sender": "Apple",
    "Name": "10x Ipads"
}
```

### Get Data
GET: `http://localhost:5001/api/Packages`
