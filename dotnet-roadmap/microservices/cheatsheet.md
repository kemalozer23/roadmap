
# Microservices in .NET Cheat Sheet

## Message-Broker

### RabbitMQ
- Open-source message broker for asynchronous communication.
- Features:
  - Supports AMQP protocol.
  - Ensures reliable message delivery (acknowledgments, retries).
- Installation:
  - Docker: `docker run -d --hostname rabbitmq --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:management`
  - NuGet: `RabbitMQ.Client`
- Example:
  ```csharp
  var factory = new ConnectionFactory() { HostName = "localhost" };
  using var connection = factory.CreateConnection();
  using var channel = connection.CreateModel();
  channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);
  channel.BasicPublish(exchange: "", routingKey: "hello", basicProperties: null, body: Encoding.UTF8.GetBytes("Hello World!"));
  ```

### Apache Kafka
- Distributed event streaming platform for real-time data pipelines.
- Features:
  - High throughput and fault tolerance.
  - Topics-based pub/sub messaging.
- Installation:
  - Docker: Use Kafka with Zookeeper.
  - NuGet: `Confluent.Kafka`
- Example:
  ```csharp
  var config = new ProducerConfig { BootstrapServers = "localhost:9092" };
  using var producer = new ProducerBuilder<Null, string>(config).Build();
  await producer.ProduceAsync("my-topic", new Message<Null, string> { Value = "Hello Kafka!" });
  ```

## Message-Bus

### MassTransit
- Lightweight service bus for .NET applications.
- Features:
  - Supports multiple transports: RabbitMQ, Azure Service Bus, Kafka.
  - Simplifies message-based communication.
- Installation: `dotnet add package MassTransit`
- Example:
  ```csharp
  services.AddMassTransit(x =>
  {
      x.UsingRabbitMq((context, cfg) =>
      {
          cfg.Host("rabbitmq://localhost");
      });
  });
  ```

## API-Gateway

### Ocelot
- Lightweight API Gateway for managing microservices traffic.
- Features:
  - Routing, load balancing, and rate limiting.
  - Authentication and authorization support.
- Installation: `dotnet add package Ocelot`
- Configuration:
  ```json
  {
    "Routes": [
      {
        "DownstreamPathTemplate": "/api/service",
        "UpstreamPathTemplate": "/service",
        "DownstreamScheme": "http",
        "DownstreamHostAndPorts": [{ "Host": "localhost", "Port": 5001 }]
      }
    ]
  }
  ```

### YARP (Yet Another Reverse Proxy)
- Modern, extensible reverse proxy for .NET.
- Features:
  - Easy integration with ASP.NET Core applications.
  - Dynamic routing capabilities.
- Installation: `dotnet add package Microsoft.ReverseProxy`
- Example:
  ```csharp
  app.UseRouting();
  app.UseEndpoints(endpoints =>
  {
      endpoints.MapReverseProxy();
  });
  ```

## Containerization

### Docker
- Tool for containerizing applications for consistent deployment.
- Features:
  - Portability across environments.
  - Isolated application runtime.
- Commands:
  - Build: `docker build -t myapp .`
  - Run: `docker run -d -p 8080:80 myapp`
  - Stop: `docker stop <container-id>`
- Dockerfile Example:
  ```dockerfile
  FROM mcr.microsoft.com/dotnet/aspnet:6.0
  COPY ./app /app
  WORKDIR /app
  ENTRYPOINT ["dotnet", "MyApp.dll"]
  ```

## Orchestration

### Kubernetes
- Open-source container orchestration platform.
- Features:
  - Automates deployment, scaling, and management of containerized applications.
  - Manages clusters of containers.
- Example YAML Deployment:
  ```yaml
  apiVersion: apps/v1
  kind: Deployment
  metadata:
    name: myapp
  spec:
    replicas: 3
    selector:
      matchLabels:
        app: myapp
    template:
      metadata:
        labels:
          app: myapp
      spec:
        containers:
        - name: myapp
          image: myapp:latest
          ports:
          - containerPort: 80
  ```

#### Tools
- **Kubectl**
  - Command-line tool for Kubernetes.
  - Commands:
    - Apply configuration: `kubectl apply -f deployment.yaml`
    - View pods: `kubectl get pods`
    - Delete deployment: `kubectl delete deployment myapp`

- **Rancher**
  - UI for managing Kubernetes clusters.
  - Features:
    - Simplifies cluster setup and monitoring.
    - Provides multi-cluster management.