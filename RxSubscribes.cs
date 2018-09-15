using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace Rx.net
{
    class RxSubscribes
    {
        static void Main(string[] args)
        {
            var values = new Subject<int>();
            values.OnNext(2);
            values.Subscribe(
            value => Console.WriteLine("1st subscription received {0}", value),
            ex => Console.WriteLine("Caught an exception : {0}", ex));
            values.OnNext(0);
            values.OnError(new Exception("Dummy exception"));

            unsubscibes();
        }
        static void unsubscibes()
        {
            var values = new Subject<int>();
            var firstSubscription = values.Subscribe(value =>
            Console.WriteLine("1st subscription received {0}", value));
            var secondSubscription = values.Subscribe(value =>
            Console.WriteLine("2nd subscription received {0}", value));
            values.OnNext(0);
            values.OnNext(1);
            values.OnNext(2);
            values.OnNext(3);
            firstSubscription.Dispose();
            Console.WriteLine("Disposed of 1st subscription");
            values.OnNext(4);
            values.OnNext(5);
        }
    }
}
