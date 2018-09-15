using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;

namespace Rx.net
{
    class RxObservable1
    {
        static void Main(string[] args)
        {
            var numbers = new MySequenceOfNumbers(); // new class call which inherits the IObservable<T> interface
            var observer = new MyConsoleObserver<int>(); // new class call which inherits IObserver<T> interface
            numbers.Subscribe(observer); // subscription 
            Console.ReadLine();
        }
    }
    public class MyConsoleObserver<T> : IObserver<T>
    {
        // first method OnNext which takes emmited values and display 
        public void OnNext(T value)
        {
            Console.WriteLine("Received value {0}", value);
        }
        // if any error occure then exception will thrown
        public void OnError(Exception error)
        {
            Console.WriteLine("Sequence faulted with {0}", error);
        }
        // stream completing signal
        public void OnCompleted()
        {
            Console.WriteLine("Sequence terminated");
        }
    }
    public class MySequenceOfNumbers : IObservable<int>
    {
        public IDisposable Subscribe(IObserver<int> observer)
        {
            // starts emmitting Observable Values
            observer.OnNext(1);
            observer.OnNext(2);
            observer.OnNext(3);
            observer.OnCompleted();
            // Disposing when Observable gets completed
            return Disposable.Empty;
        }
    }

}
