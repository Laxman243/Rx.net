using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class IgnoreElement
    {
        static void IgnoreElementExample()
        {
            var subject = new Subject<int>();
            //Could use subject.Where(_=>false);
            var noElements = subject.IgnoreElements();
            subject.Subscribe(
            i => Console.WriteLine("subject.OnNext({0})", i),
            () => Console.WriteLine("subject.OnCompleted()"));
            noElements.Subscribe(
            i => Console.WriteLine("noElements.OnNext({0})", i),
            () => Console.WriteLine("noElements.OnCompleted()"));
            subject.OnNext(1);
            subject.OnNext(2);
            subject.OnNext(2);
            subject.OnNext(3);
            subject.OnCompleted();
        }
        static void TakeElementExample()
        {
            Observable.Range(0, 10)
            .Take(3)
            .Subscribe(Console.WriteLine, () => Console.WriteLine("Completed"));
        }
        static void SkipElementExample()
        {
            Observable.Range(0, 10)
            .Skip(3)
            .Subscribe(Console.WriteLine, () => Console.WriteLine("Completed"));
        }
        static void SkipWhileElementExample()
        {
            var subject = new Subject<int>();
            subject
                .SkipWhile(i => i < 4)
                .Subscribe(Console.WriteLine, () => Console.WriteLine("Completed"));
            subject.OnNext(1);
            subject.OnNext(2);
            subject.OnNext(3);
            subject.OnNext(4);
            subject.OnNext(3);
            subject.OnNext(2);
            subject.OnNext(1);
            subject.OnNext(0);
            subject.OnCompleted();
        }
        static void TakeWhileElementExample()
        {
            var subject = new Subject<int>();
            subject
                .TakeWhile(i => i < 5)
                .Subscribe(Console.WriteLine, () => Console.WriteLine("Completed"));
            subject.OnNext(1);
            subject.OnNext(2);
            subject.OnNext(3);
            subject.OnNext(4);
            subject.OnNext(5);
            subject.OnNext(4);
            subject.OnNext(3);
            subject.OnNext(2);
            subject.OnNext(1);
            subject.OnCompleted();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("..............example of ignore element.........");
            IgnoreElementExample();
            Console.WriteLine();
            Console.WriteLine("..............example of skip element...........");
            SkipElementExample();
            Console.WriteLine();
            Console.WriteLine("..............example of take element...........");
            TakeElementExample();
            Console.WriteLine();
            Console.WriteLine("..............example of skipwhile element......");
            SkipWhileElementExample();
            Console.WriteLine();
            Console.WriteLine("..............example of takewhile element......");
            TakeWhileElementExample();
            Console.ReadKey();
        }
    }
}
