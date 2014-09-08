using System;
using System.Text;
using System.Diagnostics;
using System.Reflection;

namespace Logger {
  class log {
    public static void Write(string text) {
      StackTrace Trace = new StackTrace();
      DateTime currentTime = DateTime.Now;
      String header = String.Format("{0,2}:{1,2}:{2,2}.{3,3} {4,8}:{5,-8} ", currentTime.Hour.ToString("D2"), currentTime.Minute.ToString("D2"), currentTime.Second.ToString("D2"), currentTime.Millisecond.ToString("D3"), Trace.GetFrame(1).GetMethod().ReflectedType.Name, Trace.GetFrame(1).GetMethod().Name);
      Console.WriteLine(header + text);
    }
  };
}
