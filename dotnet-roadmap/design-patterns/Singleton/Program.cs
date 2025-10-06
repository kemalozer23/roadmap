/*var singleton = new Singleton();
Console.WriteLine(DateTime.Now.ToLongTimeString());
var numbers = await singleton.GetNumbers();
Console.WriteLine(string.Join(",", numbers));

var singleton2 = new Singleton();
var numbers2 = await singleton.GetNumbers();
Console.WriteLine(DateTime.Now.ToLongTimeString());
Console.WriteLine(string.Join(",", numbers2));*/


Console.WriteLine(DateTime.Now.ToLongTimeString());
var singleton1 = Singleton.Instance;
Console.WriteLine("Instance1");

var numbers2 = Singleton.Instance;
Console.WriteLine("Instance2");
Console.WriteLine(DateTime.Now.ToLongTimeString());