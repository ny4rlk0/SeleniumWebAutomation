using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ny4rlk0IdleBrowser
{
    public partial class Form1 : Form
    {
        static List<string> loginUserList = new List<string> { };
        static List<string> loginPwList = new List<string> { };
        static List<Thread> threadList = new List<Thread>();
        public static bool showChromeWindow { get; set; }
        public static int userCount { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Thread(() => startJob()) { IsBackground = !checkBox1.Checked }.Start();
            logic.logOutTriggered = false;
        }

        private void startJob()
        {
            int beklenecekZaman;
            beklenecekZaman = Convert.ToInt32(textBox4.Text.Trim());
            beklenecekZaman *= 60;//saniyeye çevir
            loginUserList.Clear();
            loginPwList.Clear();
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                loginUserList.Add(listBox1.Items[i].ToString());
                loginPwList.Add(listBox2.Items[i].ToString());
            }
            if (beklenecekZaman != 0)
            {
                for (int i = 0; i < loginUserList.Count;i++) {
                    int _1 = 15;
                    int _2 = 240;
                    int _3 = beklenecekZaman;
                    string _4 = listBox1.Items[i].ToString();
                    string _5 = listBox2.Items[i].ToString();
                    Thread bt = new Thread(()=> logic.chromeDriver(_1, _2, _3, _4, _5));
                    bt.IsBackground = !checkBox1.Checked;
                    bt.Start();
                    threadList.Add(bt);
                    //thread1.Start(15, 240, beklenecekZaman, listBox1.Items[i].ToString(), listBox2.Items[i].ToString());
                }
            }
            else
            {
                MessageBox.Show("Süre (dakika): hatalı bir değer girdiniz!");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //Kullanıcı adı kutusundan değeri al 
            string user=textBox2.Text.Trim();
            //Şifre kutusundan değeri al
            string pw=textBox3.Text.Trim();
            //Aynı kullanıcı adı mevcutsa uyar ve ekleme
            foreach (string item in listBox1.Items)
                if (item == user) { MessageBox.Show($"{user} isimli kullanıcı zaten ekli!"); return; }
            //Kullanıcı adı ve Şifre boş değilse Liste kutusuna ekle
            if (user != null && pw != null && user != "" && pw != "" && user != " " && pw != " ")
            {
                //Liste kutusu bir'e kullanıcı adı değerini ekle
                listBox1.Items.Add(user);
                //Liste kutusu iki'ye şifre değerini ekle
                listBox2.Items.Add(pw);
            }
            else { MessageBox.Show("Kullanıcı adı veya şifre boş olamaz!"); return; }
            //Kullanıcı adı kutusunu temizle
            textBox2.Clear();
            //Şifre kutusunu temizle
            textBox3.Clear();
        }


        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) showChromeWindow = true;
            if (!checkBox1.Checked) showChromeWindow = false;
        }
        public void writeRTB(string text)
        {
            if (Application.OpenForms.OfType<Form1>().Any())
            {
                Form1 f1 = Application.OpenForms["Form1"] as Form1;
                this.Invoke((MethodInvoker)delegate { f1.richTextBox1.Text = f1.richTextBox1.Text + "\n" + text.ToString().Trim(); });
            }
        }
        public void clearRTB()
        {
            if (Application.OpenForms.OfType<Form1>().Any())
            {
                Form1 f1 = Application.OpenForms["Form1"] as Form1;
                this.Invoke((MethodInvoker)delegate { f1.richTextBox1.Clear(); });
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/ny4rlk0");
        }

        private void label9_Click(object sender, EventArgs e)
        {
            
            Process.Start("https://github.com/ny4rlk0");
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/ny4rlk0");
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/ny4rlk0");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            listBox2.SelectedIndex = index;
            userCount = listBox1.Items.Count;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox2.SelectedIndex;
            listBox1.SelectedIndex = index;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox2.Items.Count != 0 && listBox1.Items.Count != 0)
            {
                listBox1.SelectedIndex = 0;
                listBox1.SelectedIndex = 0;
            }
            if (listBox1.Items.Count != 0 && listBox2.Items.Count != 0)
            {
                int index = listBox1.SelectedIndex;
                listBox1.Items.RemoveAt(index);
                listBox2.Items.RemoveAt(index);
            }
            if (listBox2.Items.Count != 0 && listBox1.Items.Count != 0)
            {
                listBox1.SelectedIndex = 0;
                listBox1.SelectedIndex = 0;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (System.IO.File.Exists("./logininfo.txt"))
            {
                var lines = File.ReadLines("./logininfo.txt");
                foreach (var line in lines)
                {
                    var line2 = line.Split(';');
                    listBox1.Items.Add(line2[0]);
                    listBox2.Items.Add(line2[1]);
                }
            }
            if (listBox2.Items.Count != 0 && listBox1.Items.Count != 0)
            {
                listBox1.SelectedIndex = 0;
                listBox1.SelectedIndex = 0;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists("./logininfo.txt")) System.IO.File.Delete("./logininfo.txt");
            List<string> userList = new List<string> { };
            List<string> pwList = new List<string> { };
            for (int i = 0; i < listBox1.Items.Count; i++) userList.Add(listBox1.Items[i].ToString());
            for (int i = 0; i < listBox2.Items.Count; i++) pwList.Add(listBox2.Items[i].ToString());
            using (TextWriter tw = new StreamWriter("./logininfo.txt"))
                for (int i = 0; i < userList.Count; i++) tw.WriteLine(userList[i].ToString() +";" +pwList[i].ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists("./logininfo.txt"))
            {
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                var lines = File.ReadLines("./logininfo.txt");
                foreach (var line in lines)
                {
                    var line2 = line.Split(';');
                    listBox1.Items.Add(line2[0]);
                    listBox2.Items.Add(line2[1]);
                }
            }
            if (listBox2.Items.Count != 0 && listBox1.Items.Count != 0)
            {
                listBox1.SelectedIndex = 0;
                listBox1.SelectedIndex = 0;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            foreach (var thread in threadList)
                thread.Abort();
            new Thread(() => logic.logOutAll()) { IsBackground = !checkBox1.Checked }.Start();
            logic.logOutTriggered = true;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            // Set the current caret position to the end
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            // Scroll to the caret position
            richTextBox1.ScrollToCaret();
            if (richTextBox1.TextLength> 1012345678)
            {
                richTextBox1.Clear();
            }
        }
    }
}
