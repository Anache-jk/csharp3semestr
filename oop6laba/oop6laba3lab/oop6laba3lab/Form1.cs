using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oop6laba3lab
{
    public partial class databaseconnect : Form
    {
        class LikesComparer : IComparer<string[]>
        {
            public int Compare(string[] o1, string[] o2)
            {
                int a = Convert.ToInt32(o1[3]);
                int b = Convert.ToInt32(o2[3]);

                if (a > b)
                {
                    return 1;
                }
                else if (a < b)
                {
                    return -1;
                }

                return 0;
            }
        }
        public abstract class Сonnection
        {
            protected string settings = "Не установлено";

            public abstract string opencon();
            public abstract string closecon();
            public abstract string enterrequire(string entire);

            public Сonnection(string settings)
            {
                this.settings = settings;
            }
        }

        public class MySQLcon : Сonnection
        {
            protected string Mysqlsettings;
            public int checksecond;
            protected bool mysqlcheckop = false;
            public MySQLcon(string Mysqlset, string settings) : base(settings)
            {
                Mysqlsettings = Mysqlset;
            }

            public override string opencon()
            {
                if (mysqlcheckop == false)
                {
                    DateTime checkdate = DateTime.Now;
                    checksecond = checkdate.Second;
                    Mysqlsettings = "Соединение к MySQL DB : ";
                    settings = "Открыто";
                    mysqlcheckop = true;
                    return Mysqlsettings + settings;
                }
                else
                {
                    return "For now close the connect!";
                }
            }

            public override string closecon()
            {
                if (mysqlcheckop == true)
                {
                    Mysqlsettings = "Соединение к MySQL DB : ";
                    settings = "Закрыто";
                    mysqlcheckop = false;
                    return Mysqlsettings + settings;
                }
                else
                {
                    return "For now open the connect!";
                }
            }
            public override string enterrequire(string entire)
            {
                if (mysqlcheckop == true)
                {
                    DateTime checkdate = DateTime.Now;
                    int checkenter = checkdate.Second;
                    if (checkenter - checksecond <= 10)
                    {
                        checksecond = checkenter;
                        return entire;
                    }
                    else
                    {
                        settings = "закрыто!";
                        mysqlcheckop = false;
                        return "Too much waiting for enter require, connection has closed \n" + Mysqlsettings + settings;
                    }
                }
                else
                {
                    return "For now open the connect!";
                }
            }

        }

        public class PostgreSqlcon : Сonnection
        {
            protected string postgresettings;
            protected int checksecondpostgre;
            protected bool checkop = false;
            public PostgreSqlcon(string postgre, string settings) : base(settings)
            {
                postgresettings = postgre;
            }

            public override string opencon()
            {
                if (checkop == false)
                {
                    DateTime checkdate = DateTime.Now;
                    checksecondpostgre = checkdate.Second;
                    postgresettings = "Соединение к PostgreSQL DB : ";
                    settings = "Открыто";
                    checkop = true;
                    return postgresettings + settings;
                }
                else
                {
                    return "For now close the connect!";
                }
            }

            public override string closecon()
            {
                if (checkop == true)
                {
                    postgresettings = "Соединение к PostgreSQL DB : ";
                    settings = "Закрыто";
                    checkop = false;
                    return postgresettings + settings;
                }
                else
                {
                    return "For now open the connect!";
                }
            }
            public override string enterrequire(string entire)
            {
                if (checkop == true)
                {
                    DateTime checkdate = DateTime.Now;
                    int checkenter = checkdate.Second;
                    if (checkenter - checksecondpostgre <= 10)
                    {
                        checksecondpostgre = checkenter;
                        return entire;
                        
                    }
                    else
                    {
                        settings = "закрыто!";
                        checkop = false;
                        return "Too much waiting for enter require, connection has closed \n" + postgresettings + settings;
                    }
                }
                else
                {
                    return "For now open the connect!";
                }
            }
        }

        public class Blogcon : Blog
        {
            protected string blogsettings;
            protected int checksecondBLOG;
            protected bool checkop = false;
            public Blogcon(string sett) : base(sett)
            {
                blogsettings = sett;
            }

            public override string opencon()
            {
                if (checkop == false)
                {
                    DateTime checkdate = DateTime.Now;
                    checksecondBLOG = checkdate.Second;
                    blogsettings = "Соединение к блогу : ";
                    settings = "Открыто";
                    checkop = true;
                    return blogsettings + settings;
                }
                else
                {
                    return "For now close the connect!";
                }
            }

            public override string closecon()
            {
                if (checkop == true)
                {
                    blogsettings = "Соединение к блогу : ";
                    settings = "Закрыто";
                    checkop = false;
                    return blogsettings + settings;
                }
                else
                {
                    return  "For now open the connect!";
                }
            }
            public override string enterrequire(string entire)
            {
                if (checkop == true)   
                {
                    DateTime checkdate = DateTime.Now;
                    int checkenter = checkdate.Second;
                    if (checkenter - checksecondBLOG <= 10)
                    {
                        if (entire == "Select all" || entire == "SELECT ALL"|| entire == "select all")
                        {
                            return outputentry();
                        }
                        else if (entire == "Select 5" || entire == "SELECT 5" || entire == "select 5")
                        {
                            return sortentry();
                        }
                        else
                        {
                            return entire;
                        }
                    }
                    else
                    {
                        settings = "закрыто!";
                        checkop = false;
                        return "Too much waiting for enter require, connection has closed \n" + blogsettings + settings;
                    }
                }
                else
                {
                    settings = "закрыто!";
                    checkop = false;
                    return "Too much waiting for enter require, connection has closed\n" + blogsettings + settings;
                }
            }
        }

        public class BlogWrite
        {
            private string bruh;
            private string maininformation;
            private DateTime time;
            private string fortime;

            public BlogWrite()
            {

            }
            public BlogWrite(string beruh)
            {
                
                bruh = beruh;
            }
        }

        public class Blog : Сonnection
        {
            public List<string[]> blogs = new List<string[]>();

            private int checker = 0;
            private bool checkmass = true;
            private string settingblog;

            public Blog(string sett) : base(sett)
            {
                settingblog = sett;
                blogs.Add(new string[] { "Тема - говорим о политике", "комментарий - Если бы не дед, было бы всё хуже(правда или нет, решать вам)", "Лайки - ", "9" });
                blogs.Add(new string[] { "Тема - Овощи и фрукты", "комментарий - если подумали о своих одногруппниках, я вас понимаю" , "Лайки - ", "88" });
                blogs.Add(new string[] { "Тема - Для кого нужно программировние", "комментарий - для вас, для нас и для intervolga" , "Лайки - ", "0" });
                blogs.Add(new string[] { "Тема - Что такое плюмбус", "комментарий - плюмбус делает плюмс" , "Лайки - ", "12" });
                blogs.Add(new string[] { "Тема - Как жить в обществе психов", "комментарий - пора бы смириться уже со своей биполяркой", "Лайки - ", "9" });
                blogs.Add(new string[] { "Тема - Здесь и сейчас", "комментарий - нет, блин, завтра и потом", "Лайки - ", "5" });
                blogs.Add(new string[] { "Тема - Жизнь", "комментарий - а существует ли она? А вдруг мы просто обученные куски мяса, которые обречены на гибель - p.s дед внутри", "Лайки - ", "11"});
            }
            public string outputentry()
            {
                string bigstr = "";
                for(int i =0; i<blogs.Count; i++)
                {
                    bigstr = bigstr + blogs[i][0] + Environment.NewLine + blogs[i][1] + Environment.NewLine + blogs[i][2] + blogs[i][3] + Environment.NewLine + Environment.NewLine;
                }
                return bigstr;
            }
            public string sortentry()
            {
             List<string[]> blogssecond = new List<string[]>();
                blogssecond.AddRange(blogs);
             LikesComparer likenum = new LikesComparer();

                blogssecond.Sort(likenum);
                string bigstr = "";
                for (int i = 0; i < blogssecond.Count; i++)
                {
                    bigstr = bigstr + blogssecond[i][0] + Environment.NewLine + blogssecond[i][1] + Environment.NewLine + blogssecond[i][2] + blogssecond[i][3] + Environment.NewLine + Environment.NewLine;
                }
                return bigstr;
            }

            public override string opencon()
            { return ""; }

            public override string closecon()
            { return ""; }
            public override string enterrequire(string entire)
            { return ""; }
        }
        MySQLcon mysqlob = new MySQLcon("Состояние подключения к MySQL DB : ", "Отключено");
        PostgreSqlcon postgreob = new PostgreSqlcon("Состояние подключения к PostgreSQL DB : ", "Отключено");
        Blogcon blogob = new Blogcon("Состояние подключения к блогу : ");

        public databaseconnect()
        {
            InitializeComponent();
            button4.Enabled = false;
            button5.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button4.Enabled = true;
            button5.Enabled = true;
            MessageBox.Show(blogob.opencon());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = true;
            button5.Enabled = true;
            MessageBox.Show(postgreob.opencon());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = true;
            button5.Enabled = true;
            MessageBox.Show(mysqlob.opencon());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(button1.Enabled == false && button2.Enabled == false)
            {
                MessageBox.Show(blogob.closecon());
            }
            else if(button2.Enabled == false && button3.Enabled == false)
            {
                MessageBox.Show(mysqlob.closecon());
            }
            else
            {
                MessageBox.Show(postgreob.closecon());
            }
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = false;
            button5.Enabled = false;
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button1.Enabled == false && button2.Enabled == false)
            {
                textBox1.Text = "";
                textBox1.Text = blogob.enterrequire(textBox2.Text);
            }
            else if (button2.Enabled == false && button3.Enabled == false)
            {
                textBox1.Text = "";
                textBox1.Text = mysqlob.enterrequire(textBox2.Text);
            }
            else
            {
                textBox1.Text = "";
                textBox1.Text = postgreob.enterrequire(textBox2.Text);
            }
        }
    }
}
