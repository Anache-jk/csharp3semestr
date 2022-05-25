using System;
using System.Collections.Generic;

namespace oop4laba
{
    class Program
    {
        public class Сonnection
        {
            protected string settings = "Не установлено";

            public virtual void opencon()
            {
                Console.WriteLine("Проверка открытия подключения");
            }
            public virtual void closecon()
            {
                Console.WriteLine("Проверка закрытия подключения");
            }
            public virtual string enterrequire(string req)
            {

                Console.WriteLine("Проверка ввода запроса подключения ");
                return req;
            }

        }

        public class MySQLcon : Сonnection
        {
            protected string Mysqlsettings;
            public int checksecond;
            protected bool mysqlcheckop = false;
           

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
            public override string enterrequire(string req)
            {
                if (mysqlcheckop == true)
                {
                    DateTime checkdate = DateTime.Now;
                    int checkenter = checkdate.Second;
                    if (checkenter - checksecond <= 10)
                    {
                        Console.WriteLine("Your requiest is : ");
                        Console.WriteLine(req);
                        return req;
                    }
                    else
                    {
                        Console.WriteLine("Too much waiting for enter require, connection has closed");
                        settings = "закрыто!";
                        mysqlcheckop = false;
                        Console.WriteLine(Mysqlsettings + settings);
                        return "0";
                    }
                }
                else
                {
                    Console.WriteLine("For now open the connect!");
                }
                return "0";
            }

        }

        public class PostgreSqlcon : Сonnection
        {
            protected string postgresettings;
            protected int checksecondpostgre;
            protected bool checkop = false;

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
            public override string enterrequire(string req)
            {
                if (checkop == true)
                {
                    DateTime checkdate = DateTime.Now;
                    int checkenter = checkdate.Second;
                    if (checkenter - checksecondpostgre <= 10)
                    {
                        Console.WriteLine("Your requiest is : ");
                        Console.WriteLine(req);
                        return req;
                    }
                    else
                    {
                        Console.WriteLine("Too much waiting for enter require, connection has closed");
                        settings = "закрыто!";
                        checkop = false;
                        Console.WriteLine(postgresettings + settings);
                        return "0";
                    }
                }
                else
                {
                    Console.WriteLine("For now open the connect!");
                }
                return "0";
            }
        }
        public class Requiers 
        {
            List<string> requiers = new List<string>();
            bool checkerlist = false;

            public Requiers(Сonnection ob, string req)
            {
                Console.WriteLine("Object of require has created\n"+req);
                requiers.Add(req);
            }
            public void requiercon(Сonnection ob)
            {
                string checker;
                Console.WriteLine("CHOOSE WHAT YOU WANT:" +
                    "\nChange req - C" +
                    "\nMake req - M" +
                    "\nChoose and send req - CM\nExit - E");
                checker = Console.ReadLine();
                do
                {
                    switch (checker)
                    {
                        case "C":
                            {
                                Console.Clear();
                                if (checkerlist == true)
                                {
                                    int i = 0;
                                    for (i = 0; i < requiers.Count; i++) { 
                                        if (i != requiers.Count-1)
                                        {
                                            Console.WriteLine((i+1) + ".Requier is " + requiers[i+1]);
                                        }
                                    }
                                    Console.WriteLine("Choose what requier need to change");
                                    i = Convert.ToInt32(Console.ReadLine());
                                    if (i >= 0 && i < requiers.Count)
                                    {
                                        Console.WriteLine("Make new requier:");
                                        string req = Console.ReadLine();
                                        requiers[i] = req;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Exiting from limit of massive");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("For now create a requier(s)");
                                }
                                break;
                            }
                        case "M":
                            {
                                Console.Clear();
                                checkerlist = true;
                                Console.WriteLine("Print your requiest : ");
                                string req = Console.ReadLine();
                                ob.opencon();
                                requiers.Add(ob.enterrequire(req));
                                ob.closecon();
                                break;
                            }
                        case "CM":
                            {
                                Console.Clear();
                                if (checkerlist == true)
                                {
                                    int i = 0;
                                    for (i = 0; i < requiers.Count; i++)
                                    {
                                        if (i != requiers.Count - 1)
                                        {
                                            Console.WriteLine((i + 1) + ".Requier is " + requiers[i + 1]);
                                        }
                                    }
                                    Console.WriteLine("Choose what requier need send");
                                    i = Convert.ToInt32(Console.ReadLine());
                                    if (i > 0 && i < requiers.Count)
                                    {
                                        ob.opencon();
                                        string test = ob.enterrequire(requiers[i]);
                                        ob.closecon();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Exiting from limit of massive");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("For now create a requier(s)");

                                }
                                break;
                            }
                        default:
                            {
                                Console.Clear();
                                Console.WriteLine("Something wrong!\n");
                                break;
                            }
                    }
                    Console.WriteLine("CHOOSE WHAT YOU WANT:\nChange req - C\nMake req - M\nChoose and send req - CM\nExit - E");
                    checker = Console.ReadLine();
                } while(checker!="E");
            }
        }

        static void Main(string[] args)
        {
            MySQLcon mysqlob = new MySQLcon();
            PostgreSqlcon postgreob = new PostgreSqlcon();
            Requiers reqMYSQL = new Requiers(mysqlob, "Test of connection MYSQL");
            Requiers requPOSTGRE = new Requiers(postgreob, "Test of connection POSTGRESQL");
            Console.WriteLine("Choose\n1 - Send require to MySQL\n2 - Send require to PostgreSQL\n3 - Exit");
            string chek = Console.ReadLine();

            do
            {
                switch (chek)
                {
                    case "1":
                        {
                            Console.Clear();
                            reqMYSQL.requiercon(mysqlob);
                            break;
                        }
                    case "2":
                        {
                            Console.Clear();
                            requPOSTGRE.requiercon(postgreob);
                            break;
                        }
                    default:
                        Console.Clear();
                        Console.WriteLine("Something wrong!\n");
                        break;
                }
                Console.WriteLine("Choose\n1 - Send require to MySQL\n2 - Send require to PostgreSQL\n3 - Exit");
                chek = Console.ReadLine();
            } while (chek != "3");
        }
    }
}
