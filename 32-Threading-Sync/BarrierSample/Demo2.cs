
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
public static class Demo2{
     private static Barrier _barrier = new Barrier(1);
    public static void Run(){
       
        for(var i = 0 ;i < 5; i++){
            _barrier.AddParticipant(); 
            T(i);
        }
        Console.WriteLine("enter to signal");
        var r = Console.ReadLine();
        _barrier.SignalAndWait();
        Console.Write("enter again quit");
        Console.ReadLine();
    }

    private static void T(int index){
        Task.Factory.StartNew(()=>{
            _barrier.SignalAndWait();

             Console.WriteLine($"child {index} doing work");
            Task.Delay(3000);
             Console.WriteLine($"child {index} done");
        });
    }

}