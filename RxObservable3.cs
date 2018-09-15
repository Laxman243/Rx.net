using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace Rx.net
{
    class RxObservable3
    {
        static void WriteSequenceToconsole(IObservable<string> sequence)
        {
            sequence.Subscribe(value => Console.WriteLine(value));
        }
        static void ReplaySubject(ReplaySubject<string> subject)
        {
            subject.OnNext("Welcome");
            WriteSequenceToconsole(subject);
            subject.OnNext("To");
            subject.OnNext("My Kingdom");
        }
        static void Main(string[] args)
        {
            var subject = new ReplaySubject<string>();
            ReplaySubject(subject);
            subject.Subscribe(Console.WriteLine);
            Console.ReadKey();
        }
    }
}
