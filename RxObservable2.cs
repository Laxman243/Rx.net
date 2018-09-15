using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace Rx.net
{
    class RxObservable2
    {
        static void WriteSequenceToConsole(IObservable<string> sequence)
        {
            sequence.Subscribe(value => Console.WriteLine(value));
        }
        static void AsyncSubject(AsyncSubject<string> subject)
        {
            // AsyncSubject -> Represent the result of asyncronous operation.last value before OnComplete Notification ,it sent all the subscribed Observer
            subject.OnNext("hello");
            WriteSequenceToConsole(subject); // calling method which has subscription inside it 
            subject.OnNext("to");
            subject.OnNext("All"); //only all will publish
            subject.OnCompleted();
        }
        static void Main(string[] args)
        {
            var subject = new AsyncSubject<string>();
            AsyncSubject(subject);
            Console.ReadKey();
        }
    }
 
}
