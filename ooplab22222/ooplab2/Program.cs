using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


namespace ooplab1
{

    class BlogWrite
    {
        private string header,bruh;
        private string maininformation;
        private DateTime time;
        private string fortime;
        
        private int like;
        //public string seconds;

        public BlogWrite()
        {

        }
        public BlogWrite(string beruh)
        {
            like = 0;
            header = "";
            maininformation = "";
            fortime = "";
            Console.WriteLine("Creating write in your blog\n\nPrint your header -");
            header = Console.ReadLine();
            Console.WriteLine("\nPrint your main part -");
            maininformation = Console.ReadLine();
            time = DateTime.UtcNow;
            fortime = Convert.ToString(time);
            bruh = beruh;
        }
        public string outputheader()
        {
            return header;
        }
        public string outputmaininformation()
        {
            return maininformation;
        }
        public string outputtime()
        {
            return fortime;
        }
        public int outputlikes()
        {
            return like;
        }

    }

    class Blog
    {
        private string[] arrheaders = new string[256];
        private string[] arrmaininformation = new string[256];
        private string[] arrtime = new string[256];
        private int[] score = new int[256];
        private int checker = 0;
        private bool checkmass = true;
        
        //public string seconds;

        public void MakeEntry(string head, string mainer, string times, int likes)
        {
            if (checkmass)
            {
                for(int i = 0; i < 256; i++)
                {
                    arrheaders[i] = "";
                    arrmaininformation[i] = "";
                    arrtime[i] = "";
                }
                checkmass = false;
                arrheaders[checker] = head;
                arrmaininformation[checker] = mainer;
                arrtime[checker] = times;
                score[checker] = likes;
                checker++;
            }
            else
            {
                arrheaders[checker] = head;
                arrmaininformation[checker] = mainer;
                arrtime[checker] = times;
                score[checker] = likes;
                checker++;
            }
        }
        public void outputentry()
        {
            for(int i =0; i < 256; i++)
            {
                if (arrheaders[i] != "" && arrmaininformation[i] != "" && arrtime[i] != "")
                {
                    Console.WriteLine("Header - " + arrheaders[i]);
                    Console.WriteLine("Go to tall about:" + "\n" + arrmaininformation[i]);
                    Console.WriteLine(arrtime[i]);
                    Console.WriteLine("Likes - " + score[i] + "\n\n");
                }
            }
        }
        public void sortentry()
        {
            int temp;
            String temp1, temp2, temp3;
            for(int i = 0; i < 255; i++)
            {
                for(int j = i + 1; j < 256; j++)
                {
                    if (score[i] < score[j])
                    {
                        temp = score[j];
                        temp1 = arrheaders[j];
                        temp2 = arrmaininformation[j];
                        temp3 = arrtime[j];
                        arrheaders[j] = arrheaders[i];
                        arrmaininformation[j] = arrmaininformation[i];
                        arrtime[j] = arrtime[i];
                        score[j] = score[i];
                        score[i] = temp;
                        arrheaders[i] = temp1;
                        arrmaininformation[i] = temp2;
                        arrtime[i] = temp3;
                    }
                }
            }
            outputentry();


        }

    }








    class Program
    {


        static void Main(string[] args)
        {
            //string[] arrString;
            //arrString = new string[10];
            //for (int i = 0; i < 10; i++)
            //{
            //    arrString[i] = "";
            // }
            bool checkerswitch = true, checkerlikes = false, checkerglobal = false;
            string secondheader = "", secondmain= "", secondtime = "";
            int secondlikes = 0;
            Console.Clear();
            Console.WriteLine("Choose\nS - Create a blog entry\nQ - Post your entry\nL - Put a like to your entry\nD - Put dislike your entry\nA - Sort your entries in blog\nE - Exit");
            string chek = Console.ReadLine();
            Blog First = new Blog();
            do
            {
                switch (chek)
                {
                    case "S":
                        {
                            Console.Clear();
                            if (checkerswitch)
                            {
                                BlogWrite one = new BlogWrite("fgh");
                                secondheader = one.outputheader();
                                secondmain = one.outputmaininformation();
                                secondtime = one.outputtime();
                                secondlikes = one.outputlikes();
                                checkerswitch = false;
                                checkerlikes = true;
                            }
                            else
                            {
                                Console.WriteLine("For now post your current entry!\n");
                            }
                            break;
                        }
                    case "Q":
                        {
                            Console.Clear();
                            if (checkerswitch == false)
                            {
                                First.MakeEntry(secondheader, secondmain, secondtime, secondlikes);
                                checkerlikes = false;
                                checkerswitch = true;
                                checkerglobal = true;
                            }
                            else
                            {
                                Console.WriteLine("For now create your entry!\n");
                            }
                            break;
                        }
                    case "L":
                        {
                            Console.Clear();
                            if (checkerlikes) {
                                secondlikes++;
                         Console.WriteLine("Now your rating is " + secondlikes + "\n");
                            }
                else
                {
                    Console.WriteLine("For now create your entry!\n");
                }
                            break;
                        }
                    case "D":
                        {
                            Console.Clear();
                            if (checkerlikes)
                            {
                                secondlikes--;
                                Console.WriteLine("Now your rating is " + secondlikes + "\n");
                            }
                            else
                            {
                                Console.WriteLine("For now create your entry!\n");
                            }
                            break;
                        }
                    case "A":
                        {
                            Console.Clear();
                            if (checkerglobal)
                            {
                                First.sortentry();
                            }
                            else
                            {
                                Console.WriteLine("For now create your BLOG!\n");
                            }
                            break;
                        }
                    default:
                        Console.Clear();
                        Console.WriteLine("Something wrong!\n");
                        break;
                }
                Console.WriteLine("Choose\nS - Create a blog entry\nQ - Post your entry\nL - Put a like to your entry\nD - Put dislike your entry\nA - Sort your entries in blog\nE - Exit"); chek = Console.ReadLine();
            } while (chek != "E");
        }
    }
}
