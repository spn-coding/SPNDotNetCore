// See https://aka.ms/new-console-template for more information



using DotNetTrainingBatch5.ConsoleApp;

Console.WriteLine("Hello, World!");
// Console.ReadLine();

// AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
// adoDotNetExample.Read();
// adoDotNetExample.Create();
// adoDotNetExample.Edit();
// adoDotNetExample.Update();
// adoDotNetExample.Delete();

DapperExample dapperExample = new DapperExample();
// dapperExample.Read();
// dapperExample.Create("Hello", "hello mandalay", "welcome to mandalay");
// dapperExample.Edit(10);
// dapperExample.Update(2, "hello", "hello", "hello world");
dapperExample.Delete(2);


Console.ReadKey();


