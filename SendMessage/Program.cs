using RabbitMQ.Client;
using SendMessage.Model;
using System;
using System.Text;

namespace SendMessage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                // Set up the factory
                var factory = new ConnectionFactory() { HostName = "localHost" };

                // Factory connection
                using (var connection = factory.CreateConnection())

                // New channel for pushing the message
                using (var channel = connection.CreateModel())
                {
                    // Queue properties
                    channel.QueueDeclare(queue: "messageSaver",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                    // Get input from the user
                    Console.Write("Input the sender's name: ");
                    var person = new Person();
                    person.name = Console.ReadLine();

                    while (string.IsNullOrEmpty(person.name))
                    {
                        Console.WriteLine("Name can't be empty! Enter your name once more");
                        person.name = Console.ReadLine();
                    }

                    // Build a message
                    string message = $"Hello my name is, {person.name}";

                    // Convert the message to bytes
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(exchange: "",
                        routingKey: "messageSaver",
                        basicProperties: null,
                        body: body);

                    Console.WriteLine("{0}", message);
                    Console.WriteLine("------------------------ MESSAGE SENT -------------------------");
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Press [Enter] to exit");
            Console.ReadLine();
       
        }
    }
}
