using System;
using System.Text.Json;
using Confluent.Kafka;

namespace potatoproducer;


public class Cl_A {
    public int Id { get; set; }
    public string Name { get; set; } = "";
}
public class potatoproducerservice
{
    public async void Fn()
    {

        var config = new ProducerConfig {  // producerconfig is from confluent kafka
            BootstrapServers = "localhost:9092",
            AllowAutoCreateTopics=true,
            Acks=Acks.All
        };

        Cl_A ob = new Cl_A() { Id=1, Name="🫎 Xyz"};
        var message = new Message<string, string> {
            Key ="kafka key 1", Value = JsonSerializer.Serialize<Cl_A>(ob)
        };
 
        using var produer = new ProducerBuilder<string, string>(config).Build();

        Random rnd =  new Random();
        int rndIndx = rnd.Next(10);
        var deliveryResult = await produer.ProduceAsync( topic: "potatotopic1", 
        //message: new Message<string, string> {Key ="kafka key 1",  Value = $"🥔 kafka potato {rndIndx}"}
        message: message
        );

        Console.WriteLine( $"{deliveryResult.Value} | ${deliveryResult.Offset}" );

        produer.Flush();
    } 

    public void listTopics() 
    {
        using var adminClient = new AdminClientBuilder(new AdminClientConfig() { BootstrapServers = "localhost:9092"}).Build();
        var meta = adminClient.GetMetadata(TimeSpan.FromSeconds(20));

        meta.Brokers.ForEach(broker => {
            Console.WriteLine($"📭 {broker.BrokerId} | {broker.Host} | {broker.Port}"); 
        });

        meta.Topics.ForEach(topic => {
            Console.WriteLine($"🦬 {topic.Topic}");
        });


    }
}
