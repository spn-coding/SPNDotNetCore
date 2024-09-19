// See https://aka.ms/new-console-template for more information



using DotNetTrainingBatch5.ConsoleApp;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");
// Console.ReadLine();

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
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
// dapperExample.Delete(2);


EFCoreExample eFCoreExample = new EFCoreExample();
// eFCoreExample.Read();
// eFCoreExample.Create("Hello", "Hello Myanmar", "Save Myanmar");
// eFCoreExample.Edit(2);
// eFCoreExample.Update(2, "Hay", "Hay sir", "Nay kaung lar?");
eFCoreExample.Delete(3);

Console.ReadKey();


