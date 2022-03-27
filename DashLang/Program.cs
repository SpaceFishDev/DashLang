using System;
using System.IO;    

namespace DashLang
{
    class Program
    {
        public enum interupts
        {
            PRINT
        }
        static void Main(string[] args)
        {
            string file = "";
            if(args.Length != 0) 
            {
               file = File.ReadAllText(args[0]);
            }
            int rp = 0;
            int sp = 0;
            int[] stack = new int[1000];
            int[] registers = new int[1000];
            bool error = false;

            foreach (char c in file)
            {
                if (!error)
                {
                    switch (c)
                    {
                        case '_':
                            {
                                sp++;
                                if(sp > 1000)
                                {
                                    error = false;
                                    Console.WriteLine("ERROR: STACK POINTER ABOVE ACCEPTABLE RANGE OF 1000");
                                }
                                break;
                            }
                        case '-':
                            {
                                sp--;
                                if(sp < 0)
                                {
                                    error = true;
                                    Console.WriteLine("ERROR: STACK POINTER SET TO VALUE BELOW ZERO");
                                }
                                break;
                            }
                        case '>':
                            {
                                rp++;
                                if (rp > 1000)
                                {
                                    error = true;
                                    Console.WriteLine("ERROR: REGISTER POINTER SET TO VALUE OUTSIDE OF RANGE OF REGISTERS");
                                }
                                break;
                            }
                        case '<':
                            {
                                rp--;
                                if (rp < 0)
                                {
                                    error = true;
                                    Console.WriteLine("ERROR: REGISTER POINTER SET TO VALUE BELOW ZERO");
                                }
                                break;
                            }
                        case '+':
                            {

                                break;
                            }
                        case ':':
                            {
                                if (rp != 0)
                                {
                                    interupts i = (interupts)registers[rp - 1];
                                    switch (i)
                                    {
                                        case interupts.PRINT:
                                            {
                                                
                                                break;
                                            }  
                                    }
                                }
                                break;
                            }
                    }
                }
            }
        }
    }
}
