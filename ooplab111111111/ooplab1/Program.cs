using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


namespace ooplab1
{

    class Secundomer
    {
        public DateTime times1;
        public DateTime times2;
        public TimeSpan diff;
        public string seconds;
        public void Start()
        {
            times1 = DateTime.UtcNow;
            Console.WriteLine(times1 + "\n");
        }
        public string Stop()
        {
            times2 = DateTime.UtcNow;
            Console.WriteLine(times1 + "\n");
            diff = times2 - times1;
            Console.WriteLine(diff.TotalSeconds + "\n");
            seconds = diff.TotalSeconds.ToString();
            return seconds;
        }
        public void sort(ref String[] A)
        {
            int i = 0;
            for(i = 0; i<A.Length; i++)
            {
                if(A[i] == "")
                {
                    A[i] = Stop();
                    break;
                }
            }
            i = 0;
            if(A[A.Length-1] != "")
            {
                while (i < A.Length)
                {
                    if (i != (A.Length - 1))
                    {
                        A[i] = A[i + 1];
                    }
                    else
                    {
                        A[i] = "";
                    }
                }
            }
        }

    }
    

    





    class Program
    {
        
       
        static void Main(string[] args)
        {
            string[] arrString;
            arrString = new string[10];
            for (int i = 0; i < 10; i++)
            {
                arrString[i] = "";
            }
            bool checkerswitch = true;
            Console.Clear();
            Secundomer test = new Secundomer();
            Console.WriteLine("Choose\nS - Start timer\nQ - Stop timer\nP - Print information about previous timers\nE - Exit");
            string chek = Console.ReadLine();
            do
            {
                switch (chek) {
                    case "S":
                        {
                            if (checkerswitch)
                            {
                                Console.Clear();
                                Console.WriteLine("Timer is start!\n");
                                test.Start();
                                checkerswitch = false;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Stop the current timer!\n");
                            }
                            break;
                        }
                    case "Q":
                        {
                            if (checkerswitch == false) {
                                test.sort(ref arrString);
                            checkerswitch = true;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("For now start the timer!\n");
                        }
                            break;
                        }
                        case "P": {
                            Console.Clear();
                            for (int i = 0; i < 10; i++)
                            {
                                Console.WriteLine(arrString[i]);
                            }
                            break;
                        }
                    default:
                        Console.Clear();
                        Console.WriteLine("Something wrong!\n");
                        break;
                }
                Console.WriteLine("Choose\nS - Start timer\nQ - Stop timer\nP - Print information about previous timers\nE - Exit");
                chek = Console.ReadLine();
            } while (chek != "E");
            }
    }
}
