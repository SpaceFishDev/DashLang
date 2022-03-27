using System;
using System.IO;    

namespace DashLang
{
    class Program
    {
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
            int insptr = 0;
            int req_loop = 0;
            int start_loop = 0;
            int flag = 0;

            for(; insptr != file.Length; ++ insptr)
            {
                char c = file[insptr];
                ++insptr;
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
                                registers[rp] ++;
                                break;
                            }
                        case '|':
                            {
                                registers[rp]--;
                                break;
                            }
                        case ':':
                            {
                                if (rp != 0)
                                {
                                    int i = registers[rp - 1];
                                    switch (i)
                                    {
                                        case 1:
                                            {
                                                int x = registers[rp];
                                                while (registers[x] != 0)
                                                {
                                                    Console.Write((char)registers[x]);
                                                    ++x;
                                                }
                                                break;
                                            }
                                        case 2:
                                            {
                                                int val = registers[rp];
                                                stack[sp] = val;
                                                break;
                                            }
                                    }
                                }
                                break;
                            }
                        case '{':
                            {
                                start_loop = insptr;
                                req_loop = sp;
                                sp--;
                                flag = 1;
                                break;
                            }
                        case '.':
                            {
                                if (flag == 1)
                                {
                                    if(stack[req_loop] == 0)
                                    {
                                        flag = 0;
                                    }
                                }
                                break;
                            }
                        case '}':
                            {
                                if(flag == 1)
                                {
                                    insptr = start_loop;
                                }
                                break;
                            }
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
