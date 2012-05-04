using System;
using System.Threading;
using GoogleAnalyticsTracker;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            var tracker = new Tracker("UA-8318723-11", "exceptrack.com");

            for (int i = 0; i < 1000; i++)
            {
                tracker.TrackPageView("GA API No Session", "GaapiNosession");
                tracker.TrackEvent("AAAAA", "MyAction","L1", "V1");
                Thread.Sleep(500);
            }


            Console.ReadLine();


        }
    }
}
