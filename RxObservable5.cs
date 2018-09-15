using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rx.net
{
    class RxObservable5
    {
        public static void ReplaySubjectBuffer()
        {
            // creating an window for cache
            var window = TimeSpan.FromMilliseconds(50);
            var subject = new ReplaySubject<string>(window);
            subject.OnNext("Hello");
            Thread.Sleep(TimeSpan.FromMilliseconds(100));
            subject.OnNext("Hello guys!");
            Thread.Sleep(TimeSpan.FromMilliseconds(1000));
            subject.OnNext("Welcome to india");
            subject.Subscribe(Console.WriteLine);
            subject.OnNext("!");
        }
        static void WriteSequenceToConsole(IObservable<string> sequence)
        {
            sequence.Subscribe(value => Console.WriteLine(value));
        }
        static void Main(string[] args)
        {
            ReplaySubjectBuffer();
            Console.ReadKey();
        }
    }
}
