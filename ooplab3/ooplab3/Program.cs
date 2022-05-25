using System;

namespace ooplab3
{
   class Program
    {
        abstract class Сonnection
        {
            protected string settings = "Не установлено";
           
            public abstract void opencon();
            public abstract void closecon();
            public abstract void enterrequire();

            public Сonnection(string settings)
            {
                this.settings = settings;
            }
        }

        class MySQLcon : Сonnection
        {
            protected string Mysqlsettings;
            public int checksecond;
            protected bool mysqlcheckop = false;
            public MySQLcon(string Mysqlset, string settings) : base(settings)
            {
                Mysqlsettings = Mysqlset;
            }

            public override void opencon() 
            {
                if (mysqlcheckop == false)
                {
                    DateTime checkdate = DateTime.Now;
                    checksecond = checkdate.Second;
                    Mysqlsettings = "Соединение к MySQL DB : ";
                    settings = "Открыто";
                    mysqlcheckop = true;
                    Console.WriteLine(Mysqlsettings + settings);
                }
                else
                {
                    Console.WriteLine("For now close the connect!");
                }
            }

            public override void closecon()
            {
                if (mysqlcheckop == true)
                {
                    Mysqlsettings = "Соединение к MySQL DB : ";
                    settings = "Закрыто";
                    mysqlcheckop = false;
                    Console.WriteLine(Mysqlsettings + settings);
                }
                else
                {
                    Console.WriteLine("For now open the connect!");
                }
            }
            public override void enterrequire()
            {
                if (mysqlcheckop == true)
                {
                    DateTime checkdate = DateTime.Now;
                    int checkenter = checkdate.Second;
                    if (checkenter - checksecond <= 10)
                    {
                        
                        Console.WriteLine("Print your requiest : \n ");
                        string entiremysql = Console.ReadLine();
                        checksecond = checkenter;
                        Console.WriteLine("Your requiest is : \n");
                        Console.WriteLine(entiremysql);
                    }
                    else
                    {
                        Console.WriteLine("Too much waiting for enter require, connection has closed");
                        settings = "закрыто!";
                        mysqlcheckop = false;
                        Console.WriteLine(Mysqlsettings + settings);
                    }
                }
                else
                {
                    Console.WriteLine("For now open the connect!");
                }
            }

        }

        class PostgreSqlcon : Сonnection
        {
            protected string postgresettings;
            protected int checksecondpostgre;
            protected bool checkop = false;
            public PostgreSqlcon(string postgre, string settings) : base(settings)
            {
                postgresettings = postgre;
            }

            public override void opencon()
            {
                if (checkop == false)
                {
                    DateTime checkdate = DateTime.Now;
                    checksecondpostgre = checkdate.Second;
                    postgresettings = "Соединение к PostgreSQL DB : ";
                    settings = "Открыто";
                    checkop = true;
                    Console.WriteLine(postgresettings + settings);
                }
                else
                {
                    Console.WriteLine("For now close the connect!");
                }
            }

            public override void closecon()    
            {
                if (checkop == true)
                {
                    postgresettings = "Соединение к PostgreSQL DB : ";
                    settings = "Закрыто";
                    checkop = false;
                    Console.WriteLine(postgresettings + settings);
                }
                else
                {
                    Console.WriteLine("For now open the connect!");
                }
            }
            public override void enterrequire()
            {
                if (checkop == true)
                {
                    DateTime checkdate = DateTime.Now;
                    int checkenter = checkdate.Second;
                    if (checkenter - checksecondpostgre <= 10)
                    {
                        Console.WriteLine("Print your requiest : ");
                        string entire = Console.ReadLine();
                        checksecondpostgre = checkenter;
                        Console.WriteLine("Your requiest is : \n");
                        Console.WriteLine(entire);
                    }
                    else
                    {
                        Console.WriteLine("Too much waiting for enter require, connection has closed");
                        settings = "закрыто!";
                        checkop = false;
                        Console.WriteLine(postgresettings + settings);
                    }
                }
                else
                {
                    Console.WriteLine("For now open the connect!");
                }
            }
        }
        class Blogcon : Blog
        {
            protected string blogsettings;
            protected int checksecondBLOG;
            protected bool checkop = false;
            public Blogcon(string sett):base(sett)
            {
                blogsettings = sett;
            }

            public override void opencon()
            {
                if (checkop == false)
                {
                    DateTime checkdate = DateTime.Now;
                    checksecondBLOG = checkdate.Second;
                    blogsettings = "Соединение к блогу : ";
                    settings = "Открыто";
                    checkop = true;
                    Console.WriteLine(blogsettings + settings);
                }
                else
                {
                    Console.WriteLine("For now close the connect!");
                }
            }

            public override void closecon()
            {
                if (checkop == true)
                {
                    blogsettings = "Соединение к блогу : ";
                    settings = "Закрыто";
                    checkop = false;
                    Console.WriteLine(blogsettings + settings);
                }
                else
                {
                    Console.WriteLine("For now open the connect!");
                }
            }
            public override void enterrequire()
            {
                if (checkop == true)
                {
                    DateTime checkdate = DateTime.Now;
                    int checkenter = checkdate.Second;
                    if (checkenter - checksecondBLOG <= 10)
                    {
                        Console.WriteLine("Print your requiest : ");
                        string entire = Console.ReadLine();
                        checksecondBLOG = checkenter;
                        Console.WriteLine("Your requiest is : \n");
                        if (entire == "Select all")
                        {
                            outputentry();
                        }
                        else if (entire == "Select 5")
                        {
                            sortentry();
                        }
                        else
                        {
                            Console.WriteLine(entire);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Too much waiting for enter require, connection has closed");
                        settings = "закрыто!";
                        checkop = false;
                        Console.WriteLine(blogsettings + settings);
                    }
                }
                else
                {
                    Console.WriteLine("For now open the connect!");
                }
            }
        }

        class BlogWrite
        {
            private string header, bruh;
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

        class Blog : Сonnection
        {
            private string[] arrheaders = new string[256];
            private string[] arrmaininformation = new string[256];
            private string[] arrtime = new string[256];
            private int[] score = new int[256];
            private int checker = 0;
            private bool checkmass = true;
            private string settingblog;

            public Blog(string sett):base(sett)
            {
                settingblog = sett;
            }
            public void MakeEntry(string head, string mainer, string times, int likes)
            {
                if (checkmass)
                {
                    for (int i = 0; i < 256; i++)
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
                for (int i = 0; i < 256; i++)
                {
                    if (arrheaders[i]!="" && arrmaininformation[i]!="" && arrtime[i]!= "")
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
                for (int i = 0; i < 255; i++)
                {
                    for (int j = i + 1; j < 256; j++)
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

            public override void opencon()
            { }

            public override void closecon()
            {}
            public override void enterrequire()
            { }
        }

        static void Main(string[] args)
        {
            bool checkerswitch = true, checkerlikes = false, checkerglobal = false;
            string secondheader = "", secondmain = "", secondtime = "";
            int secondlikes = 0;
            bool checkblog = false;
            Console.Clear();
            MySQLcon mysqlob = new MySQLcon("Состояние подключения к MySQL DB : ", "Отключено");
            PostgreSqlcon postgreob = new PostgreSqlcon("Состояние подключения к PostgreSQL DB : ", "Отключено");
            Blogcon blogob = new Blogcon("Состояние подключения к блогу : ");
            Console.WriteLine("Choose\n1 - Open MySQL connection\n2 - Enter the requiest in MySQL\n3 - Close MySQL connection\n4 - Open PostgreSQL connection\n5 - Enter the requiest in PostgreSQL\n6 - Close PostgreSQL connection\n7 - Create blog with pages\n8 - Enter the requiest to the blog\n9 - Open connect to the blog\n10 - Close connect to the blog\n11 - exit\n");
            string chek = Console.ReadLine();
            do
            {
                switch (chek)
                {
                    case "1":
                        {
                            Console.Clear();
                            mysqlob.opencon();
                            break;
                        }
                    case "2":
                        {
                            Console.Clear();
                            mysqlob.enterrequire();
                            break;
                        }
                    case "3":
                        {
                            Console.Clear();
                            mysqlob.closecon();
                            break;
                        }
                    case "4":
                        {
                            Console.Clear();

                            postgreob.opencon();

                            break;
                        }
                    case "5":
                        {
                            Console.Clear();
                            postgreob.enterrequire();

                            break;
                        }
                    case "6":
                        {
                            Console.Clear();
                            postgreob.closecon();

                            break;
                        }
                    case "7":
                        {
                            Console.Clear();
                            Console.WriteLine("Choose\nS - Create a blog entry\nQ - Post your entry\nL - Put a like to your entry\nD - Put dislike your entry\nE - Exit");
                            string cheks = Console.ReadLine();
                            do
                            {
                                switch (cheks)
                                {
                                    case "S":
                                        {
                                            Console.Clear();
                                            if (checkerswitch)
                                            {
                                                BlogWrite one = new BlogWrite("Не определено");
                                                secondheader = one.outputheader();
                                                secondmain = one.outputmaininformation();
                                                secondtime = one.outputtime();
                                                secondlikes = one.outputlikes();
                                                checkerswitch = false;
                                                checkerlikes = true;
                                                checkblog = true;
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
                                                blogob.MakeEntry(secondheader, secondmain, secondtime, secondlikes);
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
                                            if (checkerlikes)
                                            {
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
                                    default:
                                        Console.Clear();
                                        Console.WriteLine("Something wrong!\n");
                                        break;
                                }
                                Console.WriteLine("Choose\nS - Create a blog entry\nQ - Post your entry\nL - Put a like to your entry\nD - Put dislike your entry\nE - Exit");
                                cheks = Console.ReadLine();
                            } while (cheks != "E");
                            
                        break;
                        }
                    case "8":
                        {
                            Console.Clear();
                            if(checkblog == true)
                            {
                                blogob.enterrequire();
                            }
                            else
                            {
                                Console.WriteLine("For now create BLOG");
                            }
                            break;
                        }
                    case "9":
                        {
                            Console.Clear();
                            if (checkblog == true)
                            {
                                blogob.opencon();
                            }
                            else
                            {
                                Console.WriteLine("For now create BLOG");
                            }
                            break;
                        }
                    case "10":
                        {
                            Console.Clear();
                            if (checkblog == true)
                            {
                                blogob.closecon();
                            }
                            else
                            {
                                Console.WriteLine("For now create BLOG");
                            }
                            break;
                        }
                    case "11":
                        {
                            Console.Clear();
                            break;
                        }
                    default:
                        Console.Clear();
                        Console.WriteLine("Something wrong!\n");
                        break;
                }
                Console.WriteLine("Choose\n1 - Open MySQL connection\n2 - Enter the requiest in MySQL\n3 - Close MySQL connection\n4 - Open PostgreSQL connection\n5 - Enter the requiest in PostgreSQL\n6 - Close PostgreSQL connection\n7 - Create blog with pages\n8 - Enter the requiest to the blog\n9 - Open connect to the blog\n10 - Close connect to the blog\n11 - exit\n");
                chek = Console.ReadLine();
            } while (chek != "11");
        }
    }
}
  
