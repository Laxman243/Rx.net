using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace Rx.net
{
    class RxObservable4
    {
        public static void ReplaySubjectBuffer()
        {
            // just create a buffer with size 2
            var buffersize = 3;
            var subject = new ReplaySubject<string>(buffersize);
            subject.OnNext("Welcome");
            subject.OnNext("To");
            subject.OnNext("Cyber");
            subject.OnNext("World");
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
