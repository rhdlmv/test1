using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPoolTest2
{
    class Program
    {
        public static void Main()
        {
            for (int i = 0; i < 5000; i++)
            {
                ThreadPool.QueueUserWorkItem(Method, i);
            }

            Console.ReadKey();
        }

        public static void Method(object o)
        {
            Console.WriteLine("object:{0}  thread:{1}", o.ToString(), Thread.CurrentThread.GetHashCode());
            while (true) ;
            //Thread.Sleep(3000);
        }
    }


    //[HostProtection(SecurityAction.LinkDemand, Synchronization = true, ExternalThreading = true)]

    //public static class ThreadPool
    //{
    //    [Obsolete("ThreadPool.BindHandle(IntPtr)hasbeendeprecated.PleaseuseThreadPool.BindHandle(SafeHandle)instead.", false), SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
    //    public static bool BindHandle(IntPtrosHandle)
    //    {
    //        returnBindIOCompletionCallbackNative(osHandle);
    //    }

    //    if(osHandle==null){throw new ArgumentNullException("osHandle"); }
    //    bool flag = false;
    //    bool success = false;
    //    RuntimeHelpers.PrepareConstrainedRegions();
    //    try
    //    {
    //        osHandle.DangerousAddRef(refsuccess);
    //        flag=BindIOCompletionCallbackNative(osHandle.DangerousGetHandle());
    //    }
    //    finally
    //    {
    //        if(success)
    //        osHandle.DangerousRelease();
    //    }
    //    returnflag;
    //}
}
