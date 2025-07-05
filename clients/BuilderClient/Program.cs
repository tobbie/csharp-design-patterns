using Builder;


Console.Title = "Builder";




// The garage is our director. It is where we build our cars
var garage  = new Garage();

// we are building two brands
var miniBuilder = new MiniBuilder();
var bmwBuilder = new BMWBuilder();

garage.Construct(miniBuilder);
garage.Show();



garage.Construct(bmwBuilder);
garage.Show();

//Console.WriteLine(miniBuilder.Car.ToString());
//Console.WriteLine(bmwBuilder.Car.ToString());


Console.ReadKey();
