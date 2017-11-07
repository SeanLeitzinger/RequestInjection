using Newtonsoft.Json;
using RequestInjectionTest.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;

namespace ApiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            TestMediatr();
            Console.WriteLine();
            TestControllerInjection();
            Console.WriteLine();
            TestRequestInjection();
            Console.ReadKey();
        }

        static void TestRequestInjection()
        {
            var requestInjectionClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:51231/api/")
            };
            var request = new
            {
                TestModel = new TestModel
                {
                    TestDateTime = DateTime.Now,
                    TestInt = 100,
                    TestString = "Test",
                    ChildClass1 = new ChildClass1
                    {
                        String1 = "Test",
                        String2 = "Test"
                    },
                    ChildClass2 = new List<ChildClass2>
                    {
                        new ChildClass2
                        {
                            String1 = "Test"
                        },
                        new ChildClass2
                        {
                            String1 = "Test"
                        }
                    }
                }
            };
            var json = JsonConvert.SerializeObject(request);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            Console.WriteLine("Request injection test begin.");
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine("Get test");

            for (int i = 0; i < 10000; i++)
            {
                var result = requestInjectionClient.GetAsync("RequestInjection/Get?id=1").Result;
            }

            Console.WriteLine(stopwatch.Elapsed);
            stopwatch.Restart();
            Console.WriteLine("Add test");

            for (int i = 0; i < 10000; i++)
            {
                var result = requestInjectionClient.PostAsync("RequestInjection/Add", stringContent).Result;
            }

            Console.WriteLine(stopwatch.Elapsed);
        }

        static void TestControllerInjection()
        {
            var controllerInjectionClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:57939/api/")
            };

            var testModel = new TestModel
            {
                TestDateTime = DateTime.Now,
                TestInt = 100,
                TestString = "Test",
                ChildClass1 = new ChildClass1
                {
                    String1 = "Test",
                    String2 = "Test"
                },
                ChildClass2 = new List<ChildClass2>
                {
                    new ChildClass2
                    {
                        String1 = "Test"
                    },
                    new ChildClass2
                    {
                        String1 = "Test"
                    }
                }
            };
            var json = JsonConvert.SerializeObject(testModel);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            Console.WriteLine("Controller injection test begin.");
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine("Get test");

            for (int i = 0; i < 10000; i++)
            {
                var result = controllerInjectionClient.GetAsync("ControllerInjection/Get?id=1").Result;
            }

            Console.WriteLine(stopwatch.Elapsed);
            stopwatch.Restart();
            Console.WriteLine("Add test");

            for (int i = 0; i < 10000; i++)
            {
                var result = controllerInjectionClient.PostAsync("ControllerInjection/Add", stringContent).Result;
            }

            Console.WriteLine(stopwatch.Elapsed);
        }

        static void TestMediatr()
        {
            var mediatrClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:59491/api/")
            };

            var request = new
            {
                TestModel = new TestModel
                {
                    TestDateTime = DateTime.Now,
                    TestInt = 100,
                    TestString = "Test",
                    ChildClass1 = new ChildClass1
                    {
                        String1 = "Test",
                        String2 = "Test"
                    },
                    ChildClass2 = new List<ChildClass2>
                    {
                        new ChildClass2
                        {
                            String1 = "Test"
                        },
                        new ChildClass2
                        {
                            String1 = "Test"
                        }
                    }
                }
            };
            var json = JsonConvert.SerializeObject(request);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            Console.WriteLine("Mediatr injection test begin.");
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine("Get test");

            for (int i = 0; i < 10000; i++)
            {
                var result = mediatrClient.GetAsync("Mediatr/Get?id=1").Result;
            }

            Console.WriteLine(stopwatch.Elapsed);
            stopwatch.Restart();
            Console.WriteLine("Add test");

            for (int i = 0; i < 10000; i++)
            {
                var result = mediatrClient.PostAsync("Mediatr/Add", stringContent).Result;
            }

            Console.WriteLine(stopwatch.Elapsed);
        }
    }
}
