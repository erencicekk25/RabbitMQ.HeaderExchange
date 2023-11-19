using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory();
factory.Uri = new Uri("amqps://wylxhthv:9gEUm_Hi-PGavdDsheGhvL106sliPAi5@shark.rmq.cloudamqp.com/wylxhthv");

using var connection = factory.CreateConnection();
var channel = connection.CreateModel();

channel.ExchangeDeclare("header-exchange", durable: true, type: ExchangeType.Headers);


Dictionary<string, object> headers = new Dictionary<string, object>();

headers.Add("format", "pdf");
headers.Add("shape", "a4");

var properties = channel.CreateBasicProperties();
properties.Headers = headers;

channel.BasicPublish("header-exchange",String.Empty,properties,
        Encoding.UTF8.GetBytes("header mesajım"));


Console.WriteLine("Mesaj gönderilmiştir.");
Console.ReadLine();


//Eren Çiçek
//Merhabalar, bu proje eğitim için yapılmıştır