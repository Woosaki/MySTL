using MySTL;
using System.ComponentModel;
using System.Diagnostics;

var queue = new MyQueue();
queue.Enqueue(5);
queue.Enqueue(6);
queue.Enqueue(7);

Console.WriteLine(queue.Dequeue());