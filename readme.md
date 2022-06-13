<!-- PROJECT LOGO -->
<br />
<p align="center">
  <a href="https://github.com/BlindGarret/rabbit-example">
    <img src="images/logo.png" alt="Logo" width="300">
  </a>

  <p align="center">
    Simple example of using RabbitMQ with C# for demoing.
    <br />
    <a href="https://github.com/BlindGarret/rabbit-example/issues">Report Bug</a> |
    <a href="https://github.com/BlindGarret/rabbit-example/issues">Request Feature</a>
  </p>
</p>

### Built With

* [Docker](https://www.docker.com/)
* [Docker Compose](https://github.com/docker/compose)
* [RabbitMQ](https://www.rabbitmq.com/)
* [DotNet 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

<!-- GETTING STARTED -->
## Getting Started

To get a local copy up and running follow these simple steps.

### Prerequisites

Requires a Docker and Docker Compose installed on your local system.

### Installation

1. Standup the RabbitMQ Service - User/Pass will default to guest:guest for the [Dashboard](http://localhost:15672/) 
   ```sh
   docker-compose up -d
   ```
2. Start up the API from Visual studio at ./api/Api.sln. This will boot up a Swagger Document which will have a single route allowing you to send messages.
3. Start up the Consumer from Visual studio at ./consumer/Consumer.sln. This will startup a console which will consume messages from the MQ and display them in the CLI.

