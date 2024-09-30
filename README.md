# API and Cunsummer projects

## Scenario
In the dynamic world of online betting, capturing and analyzing data is paramount for business success. Every time a player initiates a spin in a casino game, it's essential to capture and store relevant data. This project aims to develop an API and service capable of receiving, storing, and retrieving player casino data.

## Pre-Requisites
- **RabbitMQ:** Set up a local RabbitMQ instance running on `localhost` with credentials `guest/guest`.
    > [Run RabbitMQ Windows Service](https://www.rabbitmq.com/docs/install-windows#installer) or
    > [Docker Compose Rabbit Image](docker/RabbitMQ/docker-up.bat)
- **SQL Server:** Setup a local SQL Server 2022 Developer Edition (or EXPRESS) with the connection string: `"SERVER=localhost; DATABASE=OT_Assessment_DB; Integrated Security=SSPI;"`.

## Solution
### 1. API Service (OT.Assessment.App)
An API poject that provides the following endpoints:
- **POST** `api/player/casinowager`: Receives player casino wager events to publish to the local RabbitMQ queue.
- The format of the record is as follows
    ```json
    {
      "wagerId": "aa6700eb-1a06-483e-9739-d293dc7a9383",
      "theme": "adventure",
      "provider": "Ergonomic Soft Fish",
      "gameName": "Ergonomic Granite Cheese",
      "transactionId": "410b7161-3473-4d74-85c3-a533d050a9d3",
      "brandId": "8a2016f8-c4c4-471f-9a9c-337a54664650",
      "accountId": "5ac75fec-23e9-27d1-b660-179eee70003d",
      "Username": "Jay.Bernhard67",
      "externalReferenceId": "0267dbca-2760-4a9e-ab42-5ce766fa8ca0",
      "transactionTypeId": "8aaece0c-5d53-4225-a937-adb454c4da31",
      "amount": 38273.974454660885,
      "createdDateTime": "2024-05-04T02:25:05.9906387+02:00",
      "numberOfBets": 3,
      "countryCode": "BS",
      "sessionData": "Central Chile Awesome Cotton Gloves cross-platform Handmade Rubber Shoes portals leading-edge Coordinator Data Producer end-to-end encoding Gorgeous Clothing View Health, Outdoors & Music embrace Metrics Facilitator morph",
      "duration": 1827254
    }
    ```
- **GET** `api/player/{playerId}/casino`: Returns a paginated list of the latest casino wagers for a specific player.
- The format of the record is as follows
    ```
    {
      "data": [
        {
          "wagerId": "string",
          "game": "string",
          "provider": "string",
          "amount": 0,
          "createdDate": "2024-07-10T07:25:13.577Z"
        }
      ],
      "page": 0,
      "pageSize": 0,
      "total": 0,
      "totalPages": 0
    }
    ```
- **GET** `api/player/topSpenders?count=10`: Returns the top {count} Player based on their total spending.
- The format of the record is as follows
    ```json
    {
        "accountId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "username": "string",
        "totalAmountSpend": 0
    }
    ```
### 2. .NET Service (OT.Assessment.Consumer)
This service will consume messages published to the aforementioned queue (RabbitMQ) and store consumed messages in a database (the SQL Server):
- Save the Player Account to the database if it does not already exist.
- Save entries to the Player Casino Wager table *see files under folder:.

### 3. SQL Database
Design tables, indexes, keys, and stored procedures necessary for populating and retrieving data from:
- **Player Account Table**: Includes fields for Account ID and Username.
- **Player CasinoWager Table**: Contains fields for Wager ID, Game, Provider, Account ID, Amount, and Created DateTime.
- **DatabaseGenerate.sql**: Populated the file in the root of the directory with the necessary statements to recreate the database.

