# rabbitmq-gift-raffle

- This application shows us to RabbitMQ with using MassTransit in .Net Core 3.0 with the history of gift raffle to 10k lucky employees. 

 # Getting Started

## 1. Download or clone this repo with

```
git clone https://github.com/oktydag/rabbitmq-gift-raffle.git
```


# Steps For Run
## 1.  Download RabbitMQ Image via Docker

Run RabbitMQ container with default **Username: guest** and **Password: guest**

```
docker run -d --hostname my-rabbit --name my-rabbit -p 5672:5672 -p 15672:15672 rabbitmq:3-management
```

If you want to decleare your own username and password;

```
docker run -d --hostname my-rabbit --name my-rabbit -e RABBITMQ_DEFAULT_USER=oktydag -e RABBITMQ_DEFAULT_PASS=123456 -p 5672:5672 -p 15672:15672 rabbitmq:3-management
```

Then you can look default RabbitMQ port : 

```
http://localhost:15672/
```

## 2.  Install Packages

```
$ dotnet add package MassTransit.AspNetCore --version 6.3.0
$ dotnet add package Faker --version 1.2.0
```

## 3. Run Projects

Set a multiple projects and see the result such as images in SeeThis Folder.
