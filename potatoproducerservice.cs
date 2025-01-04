using System;
using Confluent.Kafka;

namespace potatoproducer;
public class potatoproducerservice
{

    public async void Fn()
    {

        var config = new ProducerConfig {  // producerconfig is from confluent kafka
            BootstrapServers = "localhost:9092",
            AllowAutoCreateTopics=true,
            Acks=Acks.All
        };

        using var produer = new ProducerBuilder<string, string>(config).Build();


        Random rnd =  new Random();
        int rndIndx = rnd.Next(10);
        var deliveryResult = await produer.ProduceAsync( topic: "potatotopic1", 
        message: new Message<string, string> {Key ="kafka key 1",  Value = $"🥔 kafka potato {rndIndx}"});

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
