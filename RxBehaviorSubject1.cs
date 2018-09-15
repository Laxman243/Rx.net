using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class RxBehaviorSubject1
    {
        public void BehaviorSubjectExample()
        {
            //Need to provide a default value.
            var subject = new BehaviorSubject<string>("a");
            subject.Subscribe(Console.WriteLine);
        }
        // second example of BehaviorSubject passind default values and also emitting new value
        public void BehaviorSubjectExample2()
        {
            var subject = new BehaviorSubject<string>("a");
            subject.OnNext("b");
            subject.Subscribe(Console.WriteLine);
            // output is b -> it gives latest values to subscribers 
        }
        // BehaviorSubject example 3
        public void BehaviorSubjectExample3()
        {
            var subject = new BehaviorSubject<string>("a");
            subject.OnNext("b");
            subject.Subscribe(Console.WriteLine);
            subject.OnNext("c");
            subject.OnNext("d");
            // ouptut is b c d   -> previous one value and all latest value
        }
        // Complete Example
        public void BehaviorSubjectCompletedExample()
        {
            var subject = new BehaviorSubject<string>("a");
            subject.OnNext("b");
            subject.OnNext("c");
            subject.OnCompleted();
            subject.Subscribe(Console.WriteLine);
            // output nothing will display -> empty 
        }
    }
    class RxBehaviorSubjects
    {
        static void Main(string[] args)
        {
            RxBehaviorSubject1 obj1 = new RxBehaviorSubject1();
            //obj1.BehaviorSubjectExample();
            //obj1.BehaviorSubjectExample2();
            //obj1.BehaviorSubjectExample3();
            obj1.BehaviorSubjectCompletedExample();
            Console.Read();
        }
    }
}
