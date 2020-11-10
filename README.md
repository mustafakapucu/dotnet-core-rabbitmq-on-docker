# dotnet-core-rabbitmq-on-docker

# RabbitMQ on Docker
docker run -d --name some-rabbit -p 5672:5672 -p 5673:5673 -p 15672:15672 rabbitmq:3-management

http://localhost:15672/ for web

localhost for connection

# .Net Core Producer
dotnet new mvc --name=RabbitMQ.Producer

dotnet watch run

dotnet add package Rabbitmq.Client

# .Net Core Consumer
dotnet new console --name=RabbitMQ.Consumer

dotnet add package Rabbitmq.Client

dotnet run

