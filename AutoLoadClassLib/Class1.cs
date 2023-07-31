using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AutoLoadClassLib
{
    public class Class1
    {
        private int fire = 0;
        public Class1()
        {
        }

        public int Fire
        {
            get { return fire; }
            set 
            { 
                fire = value;
                if(value == 61)
                {
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    {
                        File.WriteAllText("/tmp/arale_was_here", "arale61 was here");
                    }
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    {
                        Process.Start("calc.exe");
                    }
                    else
                    {
                        throw new NotSupportedException("OS Platform not supported!");
                    }
                }
            }
        }
    }
}