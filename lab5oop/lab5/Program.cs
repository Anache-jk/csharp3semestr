using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace lab5
{
    class Program
    {
        interface questions
        {
            public void useranswer(int numquest, testerquestions ob);
            public float checkansw(int numquest, string answ);
        }

        class testerquestions
        {
            public float coinsoneansw, coinsmanyansw, coinsorderansw;
            protected string[] quest = new string[] {
                "1. Какой любимый цвет у Taylor Swift\n\n1 - красный\n2 - чёрный\n3 - бежевый\n4 - розовый\n",
                "2. Что менее калорийно?\n\n1 - помидор\n2 - огурец\n3 - хлеб\n4 - борщ\n",
                "3. Сколько хромосом у человека\n\n1 - 12\n2 - 46\n3 - 47\n4 - 23\n",
                "4. Выберете несколько через запятую:\n\nКто играл человека-паука?\n\n1 - Тоби Магвайр\n2 - Том Хиддлстон\n3 - Эндрю Гарфилд\n4 - Том Холланд\n5 - Крис Хемсворт\n",
                "5. Выберете несколько через запятую:\n\nКакие были песни у Taylor Swift в эре Reputation\n\n1 - Look what you made me do\n2 - Ready for it\n3 - Red\n4 - Cornelia Street\n5 - You need to calm down\n",
                "6. Выберете несколько через запятую:\n\nКакие фильмы Marvell самые популярные\n\n1 - Война бесконечности\n2 - Чёрная пантера\n3 - Первый мститель\n4 - Человек паук\n5 - Бэтмен\n",
                "7. Установите порядок через запятую:\n\nПорядок выхода песен у Taylor Swift в эре Lover\n\n1 - You need to calm down\n2 - ME!\n3 - Lover\n4 - The Man\n",
                "8. Установите порядок через запятую:\n\nУпорядочьте по росту(возрастание) животных\n\n1 - Лошадь\n2 - Слон\n3 - Жираф\n4 - Бык\n",
                "9. Установите порядок через запятую:\n\nКаков правильный порядок действий\n\n1 - Запустить лабораторную\n2 - Плакать\n3 - Включить компьютер\n4 - Убедиться, что она не работает\n"
            };
            public int[] numques = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            public string[] typequest = new string[] { "one", "one", "one", "many", "many", "many", "order", "order", "order" };
            protected string[] anserquest = new string[] { "1", "2", "2", "1,3,4", "1,2", "1,4", "2,1,3,4", "4,1,2,3", "3,1,4,2" };

            public void startquiz()
            {
                coinsoneansw = 0;
                coinsmanyansw = 0;
                coinsorderansw = 0;
            }
            public float coins()
            {
                return (coinsoneansw + coinsmanyansw + coinsorderansw);
            }
            public void listofquestions(string options)
            {
                if (options == "random")
                {
                    Random rand = new Random();

                    for (int i = numques.Length - 1; i >= 1; i--)
                    {
                        int j = rand.Next(i + 1);

                        int tmp = numques[j];
                        numques[j] = numques[i];
                        numques[i] = tmp;
                    }
                }
                else if (options == "default")
                {
                    Array.Sort(numques);
                }
            }
        }

        class oneanswer : testerquestions, questions
        {
            bool checkusbool = false;
            public void useranswer(int numquest, testerquestions ob)
            {
                Console.WriteLine(quest[numquest]);
                string answ = Console.ReadLine();
                ob.coinsoneansw = ob.coinsoneansw + this.checkansw(numquest, answ);
            }

            public float checkansw(int numquest, string answ)
            {
                int checkque = Convert.ToInt32(anserquest[numquest]);
                int checkus = 0;
                while (!checkusbool)
                {
                    try
                    {
                        checkus = Convert.ToInt32(answ);
                        if (checkus < 1 || checkus > 4)
                        {
                            Console.WriteLine(quest[numquest]);
                            Console.WriteLine("Введите число в нужном диапазоне:\n");
                            answ = Console.ReadLine();
                        }
                        else
                        {
                            checkusbool = true;
                        }
                    }
                    catch
                    {
                        Console.WriteLine(quest[numquest]);
                        Console.WriteLine("Введите допустимое число:\n");
                        answ = Console.ReadLine();
                    }
                }
                if (checkus == checkque)
                {
                    checkusbool = false;
                    return 1;
                }
                else
                {
                    checkusbool = false;
                    return 0;
                }
            }
        }

            class manyanswer : testerquestions, questions
            {
                bool checkusbool = false;
                public void useranswer(int numquest, testerquestions ob)
                {
                    Console.WriteLine(quest[numquest]);
                    string answ = Console.ReadLine();
                    ob.coinsmanyansw = ob.coinsmanyansw + this.checkansw(numquest, answ);
                }
                public float checkansw(int numquest, string answ)
                {
                    float checoins = 0;
                    string[] checkstr = anserquest[numquest].Split(',');
                    int[] myans = new int[checkstr.Length];
                    bool check;
                    for (int i = 0; i < myans.Length; i++)
                    {
                    myans[i] = Convert.ToInt32(checkstr[i]);
                    }
                    while (!checkusbool)
                    {
                    check = true;
                    string[] checkuserstr = answ.Split(',');
                        try
                        {
                            int[] userans = new int[checkuserstr.Length];
                            for (int i = 0; i < checkuserstr.Length; i++)
                            {
                                userans[i] = Convert.ToInt32(checkuserstr[i]);
                            }
                            for (int i = 0; i < checkuserstr.Length; i++)
                            {
                                for(int j = 0; j< checkuserstr.Length; j++)
                                {
                                    if (i != j)
                                    {
                                        if (userans[i] == userans[j] || userans[i]<1 || userans[j]<1)
                                        {
                                            check = false;
                                        }
                                    }
                                }
                            }
                            if (check ==  true)
                            {
                                for(int i = 0; i< checkuserstr.Length; i++)
                                {
                                    for(int j = 0; j< checkstr.Length; j++)
                                    {
                                        if(userans[i] == myans[j])
                                        {
                                            checoins++;
                                        }
                                    }
                                }
                                if (checoins > 0)
                                {
                                    if ((checkuserstr.Length != checkstr.Length) && (checkuserstr.Length - checoins > 0))
                                    {
                                        checoins = checoins / (checkstr.Length+checkuserstr.Length);
                                    }
                                    else if(checkuserstr.Length - checoins == 0)
                                    {
                                        checoins = 1;
                                    }
                                    else if((checkuserstr.Length == checkstr.Length) && (checkuserstr.Length - checoins > 0))
                                    {
                                        checoins = checoins / checkstr.Length;
                                    }

                                }
                                checkusbool = true;
                            }
                            else
                            {
                                Console.WriteLine(quest[numquest]);
                                Console.WriteLine("Введите допустимые неповторяющиеся числа:\n");
                                answ = Console.ReadLine();
                            }

                        }
                        catch
                        {
                            Console.WriteLine(quest[numquest]);
                            Console.WriteLine("Введите допустимые числа:\n");
                            answ = Console.ReadLine();
                        }
                    }
                checkusbool = false;
                return checoins;
                }
            }



            class orderanswer : testerquestions, questions
            {
                bool checkusbool = false;
                public void useranswer(int numquest, testerquestions ob)
                {
                    Console.WriteLine(quest[numquest]);
                    string answ = Console.ReadLine();
                ob.coinsorderansw = ob.coinsorderansw + this.checkansw(numquest, answ);
                }
                public float checkansw(int numquest, string answ)
                {
                    float checoins = 0;
                    string[] checkstr = anserquest[numquest].Split(',');
                    while (!checkusbool)
                    {
                        checoins = 0;
                        string[] checkuserstr = answ.Split(',');
                        try
                        {
                            if (checkuserstr.Length != checkstr.Length)
                            {
                                Console.WriteLine(quest[numquest]);
                                Console.WriteLine("Введите нужное количество цифр:\n");
                                answ = Console.ReadLine();
                            }
                            else
                            {
                                int[] myans = new int[checkstr.Length];
                                int[] usans = new int[checkuserstr.Length];
                                bool check = true;
                                for (int i = 0; i < myans.Length; i++)
                                {
                                myans[i] = Convert.ToInt32(checkstr[i]);
                                    usans[i] = Convert.ToInt32(checkuserstr[i]);
                                    if (usans[i] < 0 || usans[i] > checkstr.Length)
                                    {
                                        Console.WriteLine(quest[numquest]);
                                        Console.WriteLine("Были введены недопустимые числа, введите новые и неотрицательные:\n");
                                        answ = Console.ReadLine();
                                        check = false;
                                        break;
                                    }
                                    else if (myans[i] == usans[i])
                                    {
                                        checoins++;
                                    }
                                }
                                if (check == true)
                                {
                                    checkusbool = true;
                                }
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Введите допустимые числа:\n");
                            answ = Console.ReadLine();
                        }
                    }
                    if (checoins > 0)
                    {
                    checkusbool = false;
                    return ((checoins * 2) / checkstr.Length);
                    }
                    else
                    {
                    checkusbool = false;
                    return 0;
                    }
                }
            }






            static void Main(string[] args)
            {
            testerquestions quest = new testerquestions();
            oneanswer onean = new oneanswer();
            manyanswer manyan = new manyanswer();
            orderanswer orderan = new orderanswer();
                Console.WriteLine("Choose\n1 - Выбрать вывод вопросов\n2 - Начать тестирование\n3 - Вывести количество баллов\n4 - Выйти");
                string chek = Console.ReadLine();
                do
                {
                    switch (chek)
                    {
                        case "1":
                            {
                            Console.Clear();
                            Console.WriteLine("\n1 - Выводить вопросы по порядку\n2 - Вывод вопросов рандомно\n3 - Выйти");
                            string checkorder = Console.ReadLine();
                            do
                            {
                                switch (checkorder)
                                {
                                    case "1":
                                        {
                                            Console.Clear();
                                            quest.listofquestions("default");
                                            break;
                                        }
                                    case "2":
                                        {
                                            Console.Clear();
                                            quest.listofquestions("random");
                                            break;
                                        }
                                    case "3":
                                        {
                                            break;
                                        }
                                    default:
                                        Console.Clear();
                                        Console.WriteLine("Something wrong!\n");
                                        break;
                                }
                                Console.Clear();
                                Console.WriteLine("\n1 - Выводить вопросы по порядку\n2 - Вывод вопросов рандомно\n3 - Выйти");
                                checkorder = Console.ReadLine();
                            } while (checkorder != "3");
                            break;
                            }
                        case "2":
                            {
                            quest.startquiz();
                            for(int i = 0; i< quest.numques.Length; i++)
                            {
                                if(quest.typequest[quest.numques[i]] == "one")
                                {
                                    onean.useranswer(quest.numques[i], quest);
                                }
                                else if (quest.typequest[quest.numques[i]] == "many")
                                {
                                    manyan.useranswer(quest.numques[i], quest);
                                }
                                else if (quest.typequest[quest.numques[i]] == "order")
                                {
                                    orderan.useranswer(quest.numques[i], quest);
                                }
                            }
                            break;
                            }
                        case "3":
                            {
                            Console.WriteLine("Количество ваших баллов после прохождения тестирования составляет - " + quest.coins());
                                break;
                            }
                        default:
                            Console.Clear();
                            Console.WriteLine("Something wrong!\n");
                            break;
                    }
                Console.WriteLine("Choose\n1 - Выбрать вывод вопросов\n2 - Начать тестирование\n3 - Вывести количество баллов\n4 - Выйти");
                chek = Console.ReadLine();
            } while (chek != "4");
            }
        }
    }
