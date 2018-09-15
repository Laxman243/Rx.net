using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rx.net
{
    class Observer : IObserver<int>
    {
        public void OnCompleted()
        {
            Console.WriteLine("Observation Completed");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine($"Error:{error.Message}");
        }

        public void OnNext(int value)
        {

            Console.WriteLine($"Value received :{value}");
        }
    }
    class Rx1
    {
        static void Main(string[] args)
        {
            // another way of creating Observable using methods here static method we used to create Observable which is reference type of IObservable
            IObservable<int> observable = Observable.Range(5, 8);
            var subscription = observable.Subscribe(new Observer());
            Console.ReadKey();
            subscription.Dispose();
        }
    }
}
