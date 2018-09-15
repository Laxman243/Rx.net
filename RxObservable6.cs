using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace Rx.net
{
    class RxObservable6
    {
        /*
        static void Subject(Subject<string> subject)
        {
            WriteSequenceToConsole(subject);
            subject.OnNext("Welcome");
            subject.OnNext("To");
            subject.OnNext("India");
        }
        static void WriteSequenceToConsole(IObservable<string> sequence)
        {
            sequence.Subscribe(value => Console.WriteLine(value));
        }
        static void Main(string[] args)
        {
            var subject = new Subject<string>();
            Subject(subject);
            Console.ReadKey();
        }*/
        static void Main(string[] args)
        {
            var subject = new Subject<string>();
           // WriteSequenceToConsole(subject);
            subject.OnNext("a");
            subject.OnNext("b");
            subject.Subscribe(Console.Write);// here will get only c as an ouptput it ignores a and b 
            subject.OnNext("c");
            Console.ReadKey();
        }
        //Takes an IObservable<string> as its parameter. 
        //Subject<string> implements this interface.
        static void WriteSequenceToConsole(IObservable<string> sequence)
        {
            //The next two lines are equivalent.
            //sequence.Subscribe(value=>Console.WriteLine(value));
            sequence.Subscribe(Console.WriteLine);
        }
    }
}
