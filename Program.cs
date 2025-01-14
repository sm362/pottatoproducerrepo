using potatoproducer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// 🌵
// builder.Services.AddHostedService<recurrentjob>();
// builder.Services.AddHostedService<lifecyclebackgroundjob>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/producer",()=>{
    potatoproducerservice ob= new potatoproducerservice();
    ob.Fn();
});

app.MapGet("/listtopics" , ()=> {
    potatoproducerservice ob= new potatoproducerservice();
    ob.listTopics();
});

app.MapGet("/createtopic",()=>{
    potatoproducerservice ob =  new potatoproducerservice();
    ob.createTopic();
});

app.Run();






// 🌵 
// > docker exec kafka kafka-topics --create --bootstrap-server localhost:9092 --partitions 1 --replication-factor 1 --topic Test12
// > docker exec kafka kafka-topics  --list --bootstrap-server localhost:9092

