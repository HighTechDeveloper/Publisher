using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;
using RabbitMQ.Client;

Console.WriteLine("Hello, World!");

var factory = new ConnectionFactory() { HostName = "localhost" };




using (var connection = factory.CreateConnection())
{
    using (var chanel = connection.CreateModel())
    {
        chanel.QueueDeclare(queue: "first",
            exclusive: false,
            durable: true,
            autoDelete: false,
            arguments: null);

        var message = "4 message";
        var body = Encoding.UTF8.GetBytes(message);

        chanel.BasicPublish(exchange: "",
                     routingKey: "first",
                     basicProperties: null,
                     body: body);

        Console.WriteLine("Done");
    }
}