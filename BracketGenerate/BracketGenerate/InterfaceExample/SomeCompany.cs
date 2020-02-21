using System;
using System.Collections.Generic;

namespace BracketGenerate.InterfaceExample
{
    /// <summary>
    /// As you can see all Classes based on IWorker can be in same collection even if they are
    /// completly diffrent classes.
    /// Additionally everything what was declared in interface can be called out.
    /// Each of I worker class can implement own specific logic and can do diffrent thing, but as long as it shares the same interface 
    /// It can be threated similar to other classes with the same interface
    /// </summary>
    public class SomeCompany
    {
        List<IWorker> Workers = new List<IWorker>();

        public SomeCompany()
        {
            GenerateWorkerSeed();
            //Businness is going good
            foreach(var worker in Workers)
            {
                worker.IncreaseSalary(9000m);
            }
        }

        private void GenerateWorkerSeed()
        {
            Random rnd = new Random();
            for (int i = 0; i < 50; i++)
            {
                Workers.Add(new OfficePlancton
                    (
                        _active: true,
                        _name: $"Joe Nr.{i}",
                        _salary:rnd.Next(10000,90000)/100
                    ));
            }
            for (int i = 0; i < 10; i++)
            {
                Workers.Add(new SoftwareEngeneer
                    (
                        _name: $"OverMind Nr.{i}",
                        _salary: rnd.Next(1000000, 9000000) / 100
                    ));
            }
            Workers.Add(new CEO
                   (
                       _name: $"Corp. Commander"
                   ));

        }
    }
}
