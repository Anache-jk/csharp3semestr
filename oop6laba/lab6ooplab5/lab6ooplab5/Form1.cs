using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab6ooplab5
{
    public partial class Form1 : Form
    {
        interface questions
        {
             string useranswer(int numquest);
             string checkansw(int numquest, string answ);
        }

        class testerquestions
        {
            public double coinsoneansw, coinsmanyansw, coinsorderansw;
            protected string[] quest = new string[] {
                "1. Какой любимый цвет у Taylor Swift"+ Environment.NewLine +"1 - красный"+ Environment.NewLine +"2 - чёрный"+ Environment.NewLine +"3 - бежевый"+ Environment.NewLine +"4 - розовый\n",
                "2. Что менее калорийно?"+ Environment.NewLine +"1 - помидор"+ Environment.NewLine +"2 - огурец"+ Environment.NewLine +"3 - хлеб"+ Environment.NewLine +"4 - борщ\n",
                "3. Сколько хромосом у человека"+ Environment.NewLine +"1 - 12"+ Environment.NewLine +"2 - 46"+ Environment.NewLine +"3 - 47"+ Environment.NewLine +"4 - 23\n",
                "4. Выберете несколько через запятую:"+ Environment.NewLine +"Кто играл человека-паука?"+ Environment.NewLine +"1 - Тоби Магвайр"+ Environment.NewLine +"2 - Том Хиддлстон"+ Environment.NewLine +"3 - Эндрю Гарфилд"+ Environment.NewLine +"4 - Том Холланд"+ Environment.NewLine +"5 - Крис Хемсворт\n",
                "5. Выберете несколько через запятую:"+ Environment.NewLine +"Какие были песни у Taylor Swift в эре Reputation"+ Environment.NewLine +"1 - Look what you made me do"+ Environment.NewLine +"2 - Ready for it"+ Environment.NewLine +"3 - Red"+ Environment.NewLine +"4 - Cornelia Street"+ Environment.NewLine +"5 - You need to calm down\n",
                "6. Выберете несколько через запятую:"+ Environment.NewLine +"Какие фильмы Marvell самые популярные"+ Environment.NewLine +"1 - Война бесконечности"+ Environment.NewLine +"2 - Чёрная пантера"+ Environment.NewLine +"3 - Первый мститель"+ Environment.NewLine +"4 - Человек паук"+ Environment.NewLine +"5 - Бэтмен\n",
                "7. Установите порядок через запятую:"+ Environment.NewLine +"Порядок выхода песен у Taylor Swift в эре Lover"+ Environment.NewLine +"1 - You need to calm down"+ Environment.NewLine +"2 - ME!"+ Environment.NewLine +"3 - Lover"+ Environment.NewLine +"4 - The Man\n",
                "8. Установите порядок через запятую:"+ Environment.NewLine +"Упорядочьте по росту(возрастание) животных"+ Environment.NewLine +"1 - Лошадь"+ Environment.NewLine +"2 - Слон"+ Environment.NewLine +"3 - Жираф"+ Environment.NewLine +"4 - Бык\n",
                "9. Установите порядок через запятую:"+ Environment.NewLine +"Каков правильный порядок действий"+ Environment.NewLine +"1 - Запустить лабораторную"+ Environment.NewLine +"2 - Плакать"+ Environment.NewLine +"3 - Включить компьютер"+ Environment.NewLine +"4 - Убедиться, что она не работает\n"
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
            public double coins()
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
            public string useranswer(int numquest)
            {
                return quest[numquest];
                
               // ob.coinsoneansw = ob.coinsoneansw + this.checkansw(numquest, answ);
            }

            public string checkansw(int numquest, string answ)
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
                           MessageBox.Show("Введите число в нужном диапазоне");
                            return "-1";
                        }
                        else
                        {
                            checkusbool = true;
                        }
                    }
                    catch (Exception e)
                    {
                       MessageBox.Show("Введите допустимое число");
                        return "-1";

                    }
                }
                if (checkus == checkque)
                {
                    checkusbool = false;
                    return "1";
                }
                else
                {
                    checkusbool = false;
                    return "0";
                }
            }
        }

        class manyanswer : testerquestions, questions
        {
            bool checkusbool = false;
            public string useranswer(int numquest)
            {
                return quest[numquest];

                //ob.coinsmanyansw = ob.coinsmanyansw + this.checkansw(numquest, answ);
            }
            public string checkansw(int numquest, string answ)
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
                            for (int j = 0; j < checkuserstr.Length; j++)
                            {
                                if (i != j)
                                {
                                    if (userans[i] == userans[j] || userans[i] < 1 || userans[j] < 1)
                                    {
                                        check = false;
                                    }
                                }
                            }
                        }
                        if (check == true)
                        {
                            for (int i = 0; i < checkuserstr.Length; i++)
                            {
                                for (int j = 0; j < checkstr.Length; j++)
                                {
                                    if (userans[i] == myans[j])
                                    {
                                        checoins++;
                                    }
                                }
                            }
                            if (checoins > 0)
                            {
                                if ((checkuserstr.Length != checkstr.Length) && (checkuserstr.Length - checoins > 0))
                                {
                                    checoins = checoins / (checkstr.Length + checkuserstr.Length);
                                }
                                else if (checkuserstr.Length - checoins == 0)
                                {
                                    checoins = 1;
                                }
                                else if ((checkuserstr.Length == checkstr.Length) && (checkuserstr.Length - checoins > 0))
                                {
                                    checoins = checoins / checkstr.Length;
                                }

                            }
                            checkusbool = true;
                        }
                        else
                        {
                            MessageBox.Show("Введите допустимые неповторяющиеся числа");
                            return "-1";
                        }

                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Введите допустимые числа");
                        return "-1";
                    }
                }
                checkusbool = false;
                return Convert.ToString(checoins);
            }
        }



        class orderanswer : testerquestions, questions
        {
            bool checkusbool = false;
            public string useranswer(int numquest)
            {
                return quest[numquest];

              //  ob.coinsorderansw = ob.coinsorderansw + this.checkansw(numquest, answ);
            }
            public string checkansw(int numquest, string answ)
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
                            MessageBox.Show("Введите нужное количество цифр");
                            return "-1";
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
                                    check = false;
                                    MessageBox.Show("Были введены недопустимые числа, введите новые и неотрицательные");
                                    return "-1";
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
                    catch (Exception e)
                    {
                        MessageBox.Show("Введите допустимые числа");
                        return "-1";
                    }
                }
                if (checoins > 0)
                {
                    checkusbool = false;
                    return Convert.ToString((checoins * 2) / checkstr.Length);
                }
                else
                {
                    checkusbool = false;
                    return "0";
                }
            }
        }
        testerquestions quest = new testerquestions();
        oneanswer onean = new oneanswer();
        manyanswer manyan = new manyanswer();
        orderanswer orderan = new orderanswer();
        int numquiz;

        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            numquiz = 0;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            quest.startquiz();
            if (numquiz < quest.numques.Length)
            {
                if (quest.typequest[quest.numques[numquiz]] == "one")
                {
                    textBox1.Text = onean.useranswer(quest.numques[numquiz]);
                }
                else if (quest.typequest[quest.numques[numquiz]] == "many")
                {
                    textBox1.Text = manyan.useranswer(quest.numques[numquiz]);

                }
                else if (quest.typequest[quest.numques[numquiz]] == "order")
                {
                    textBox1.Text = orderan.useranswer(quest.numques[numquiz]);
                }
            }
            else
            {
                textBox1.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            button2.Enabled = true;
            quest.listofquestions("random");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
            button2.Enabled = true;
            quest.listofquestions("default");

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (numquiz < quest.numques.Length)
            {
                if (quest.typequest[quest.numques[numquiz]] == "one")
                {
                    if(onean.checkansw(quest.numques[numquiz], textBox2.Text) != "-1")
                    {
                        quest.coinsoneansw = quest.coinsoneansw + Convert.ToDouble(onean.checkansw(quest.numques[numquiz], textBox2.Text));
                        textBox2.Text = "";
                        numquiz++;
                    }
                    else
                    {
                        textBox2.Text = "";
                    }

                }
                else if (quest.typequest[quest.numques[numquiz]] == "many")
                {
                    if (manyan.checkansw(quest.numques[numquiz], textBox2.Text) != "-1")
                    {
                        quest.coinsmanyansw = quest.coinsmanyansw + Convert.ToDouble(manyan.checkansw(quest.numques[numquiz], textBox2.Text));
                        textBox2.Text = "";
                        numquiz++;
                    }
                    else
                    {
                        textBox2.Text = "";
                    }
                }
                else if (quest.typequest[quest.numques[numquiz]] == "order")
                {
                    if (orderan.checkansw(quest.numques[numquiz], textBox2.Text) != "-1")
                    {
                        quest.coinsorderansw = quest.coinsorderansw + Convert.ToDouble(orderan.checkansw(quest.numques[numquiz], textBox2.Text));
                        textBox2.Text = "";
                        numquiz++;
                    }
                    else
                    {
                        textBox2.Text = "";
                    }
                }
            }
            
            if (numquiz < quest.numques.Length)
            {
                if (quest.typequest[quest.numques[numquiz]] == "one")
                {
                    textBox1.Text = onean.useranswer(quest.numques[numquiz]);
                }
                else if (quest.typequest[quest.numques[numquiz]] == "many")
                {
                    textBox1.Text = manyan.useranswer(quest.numques[numquiz]);

                }
                else if (quest.typequest[quest.numques[numquiz]] == "order")
                {
                    textBox1.Text = orderan.useranswer(quest.numques[numquiz]);
                }
            }
            else
            {
                textBox1.Text = "";
            }
            if(numquiz == quest.numques.Length - 1)
            {
                button1.Text = "Вывести баллы";
            }
            if(numquiz == quest.numques.Length)
            {
                button1.Text = "Отправить ответ";
                MessageBox.Show("Количество полученных баллов = " + quest.coins());
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                button2.Enabled = false;
                button3.Enabled = true;
                button4.Enabled = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
