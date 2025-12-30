using System;
using System.Collections;
using System.Collections.Generic;
public class Queues
{
    public static void q()
    {
        Queue que=new Queue();
        que.Enqueue(10);
        que.Enqueue(20);
        Console.WriteLine(que.Dequeue());
    }
}