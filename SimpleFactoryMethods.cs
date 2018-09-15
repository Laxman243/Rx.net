using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class SimpleFactoryMethods
    {
        static void Main(string[] args)
        {
            // Observable.Return method
            var singleValue = Observable.Return<string>("Value");
            //which could have also been simulated with a replay subject
           // var subject = new ReplaySubject<string>();
            //subject.OnNext("Value");
            //subject.OnCompleted();

            singleValue.Subscribe(Console.WriteLine);
            Console.Read();

            // Observable.Empty method
            var empty = Observable.Empty<string>();
            //Behaviorally equivalent to
            //var subject1 = new ReplaySubject<string>();
            //subject1.OnCompleted();
            empty.Subscribe();

            // Observable.Never
            var never = Observable.Never<string>();
            // equivalent to Subject 

            // Observable.Throw
            var throws = Observable.Throw<string>(new Exception());
            // Behaviorally equivalent to Subject<T>
            var subject2 = new Subject<string>();
            subject2.OnError(new Exception());

            SimpleFactoryMethods smp = new SimpleFactoryMethods();
            smp.BlockingMethod();
            smp.NonBlocking();
        }
        private IObservable<string> BlockingMethod()
        {
            var subject = new ReplaySubject<string>();
            subject.OnNext("a");
            subject.OnNext("b");
            subject.OnCompleted();
            Thread.Sleep(1000);
            return subject;
        }
        private IObservable<string> NonBlocking()
        {
            return Observable.Create<string>(
            (IObserver<string> observer) =>
            {
                observer.OnNext("a");
                observer.OnNext("b");
                observer.OnCompleted();
                Thread.Sleep(1000);
                return Disposable.Create(() => Console.WriteLine("Observer has unsubscribed"));
    //or can return an Action like 
    //return () => Console.WriteLine("Observer has unsubscribed"); 
});
        }
    }
}
