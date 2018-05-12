using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Lab5
{
    public partial class Form1 : Form
    {
        string F;
        modnode tree;
        bool correct;
        ArrayList perems, kvants;

        public Form1()
        {
            InitializeComponent();
            Text = Application.ProductName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            F = textBox_input.Text;
            if (F != "")
            {
                F = F.Replace(" ", "");
                tree = new modnode();
                perems = new ArrayList();
                kvants = new ArrayList();
                tree.data = F;
                correct = true;
                tree = Pars(tree);
                if (correct)
                {
                    tree = ConvertToAON(tree);
                    tree = NotDown(tree);
                    tree = RenameKvants(tree);
                    tree = ConvertToPNF(tree);
                    tree = ConvertToKNF(tree);
                    textBox_output.Text = tree.ToString();
                }
                else textBox_output.Text = "Bad";
                tree.Del();
                tree = null;
                perems = null;
                kvants = null;
            }
        }

        private modnode ConvertToKNF(modnode m)//Приводит к коньюнктивной нормальной форме. Работает только с формулами приведёнными к ПНФ.
        {
            modnode t0, t1;
            if (m.right != null && m.right.right != null) m.right = ConvertToKNF(m.right);
            if (m.left != null && m.left.right != null) m.left = ConvertToKNF(m.left);
            if (m.data == "V")
            {
                t0 = new modnode();
                if (m.right.data == "&")
                {
                    t0.data = "&";
                    t0.left = new modnode();
                    t0.left.data = "V";
                    t0.left.left = m.left;
                    t0.left.right = m.right.left;
                    t0.right = new modnode();
                    t0.right.data = "V";
                    t1 = m.left.Copy();
                    t0.right.left = t1;
                    t0.right.right = m.right.right;
                    m = t0;
                    m.right = ConvertToKNF(m.right);
                    m.left = ConvertToKNF(m.left);
                    return m;
                }
                if (m.left.data == "&")
                {
                    t0.data = "&";
                    t0.left = new modnode();
                    t0.left.data = "V";
                    t0.left.left = m.left.left;
                    t0.left.right = m.right;
                    t0.right = new modnode();
                    t0.right.data = "V";
                    t1 = m.right.Copy();
                    t0.right.left = m.left.right;
                    t0.right.right = t1;
                    m = t0;
                    m.right = ConvertToKNF(m.right);
                    m.left = ConvertToKNF(m.left);
                    return m;
                }
            }
            return m;
        }

        private modnode ConvertToPNF(modnode m)//Приводит к пренексной нормальной форме. Работает только с формулами приведёнными к базису и-или-не, в которых отрицания продвинуты до атомов и переименованы связаные переменные.
        {
            modnode r, l, t0 = new modnode(), t1;
            if (m.right != null && m.right.right != null) m.right = ConvertToPNF(m.right);
            if (m.left != null && m.left.right != null) m.left = ConvertToPNF(m.left);
            if (m.data == "V" || m.data == "&")
            {
                l = m.left; t1 = t0;
                while (l.data[0] == '#' || l.data[0] == '$')
                {
                    t1.data = l.data;
                    t1.right = new modnode();
                    t1 = t1.right;
                    l = l.right;
                }
                r = m.right;
                while (r.data[0] == '#' || r.data[0] == '$')
                {
                    t1.data = r.data;
                    t1.right = new modnode();
                    t1 = t1.right;
                    r = r.right;
                }
                t1.data = m.data;
                t1.right = r;
                t1.left = l;
                return t0;
            }            
            return m;
        }

        private modnode RenameKvants(modnode m)//Переименовывает связанные переменные.
        {
            int l, i;
            string x, xn;
            if (m.data[0] == '#' || m.data[0] == '$')
            {
                l = m.data.Length;
                x = m.data.Substring(1, l - 1);
                if (kvants.IndexOf(x) == -1)
                {
                    kvants.Add(x);
                }
                else
                {
                    if (l > 2)
                        i = Convert.ToInt32(x.Substring(1, l - 2)) + 1;
                    else
                        i = 1;
                    while (perems.IndexOf(x[0] + i.ToString()) != -1)
                        i++;
                    xn = x[0] + i.ToString();
                    perems.Add(xn);
                    kvants.Add(xn);
                    m = ExchangePerem(m, x, xn);
                }
            }
            if (m.right != null && m.right.right != null) m.right = RenameKvants(m.right);
            if (m.left != null && m.left.right != null) m.left = RenameKvants(m.left);
            return m;
        }

        private modnode ExchangePerem(modnode m, string o, string n)//Замена переменной "o" на "n" в дереве "m".
        {
            int i = 0, j;
            if ((m.data[0] == '#' || m.data[0] == '$') && m.data.Substring(1, m.data.Length - 1) == o)
            {
                m.data = m.data[0] + n;
            }
            if (pred(m.data))
            {
                while (m.data[i] != '(')
                    i++;
                i++;
                while (i != m.data.Length)
                {
                    j = i;
                    while (m.data[j] != ',' && m.data[j] != ')')
                        j++;
                    if (m.data.Substring(i, j - i) == o)
                        m.data = m.data.Substring(0, i) + n + m.data.Substring(j, m.data.Length - j);
                    i = j + 1;
                }
            }
            if (perem(m.data) && m.data == o)
                m.data = n;
            if (m.right != null) m.right = ExchangePerem(m.right, o, n);
            if (m.left != null) m.left = ExchangePerem(m.left, o, n);
            return m;
        }

        private modnode NotDown(modnode m)//Продвижение отрацаний до атомов. Работает только с формулами приведёнными к базису и-или-не.
        {
            if (m.right == null) return m;
            if (m.data == "!")
                switch (m.right.data[0])
                {
                    case '#':
                        {
                            m.data = "$" + m.right.data.Substring(1, m.right.data.Length - 1);
                            m.right.data = "!";
                            m.right = NotDown(m.right);
                            return m;
                        }
                    case '$':
                        {
                            m.data = "#" + m.right.data.Substring(1, m.right.data.Length - 1);
                            m.right.data = "!";
                            m.right = NotDown(m.right);
                            return m;
                        }
                    case 'V':
                        {
                            m.data = "&";
                            m.left = m.right.left;
                            m.right = m.right.right;
                            m.Addl("!");
                            m.Addr("!");
                            m.right = NotDown(m.right);
                            m.left = NotDown(m.left);
                            return m;
                        }
                    case '&':
                        {
                            m.data = "V";
                            m.left = m.right.left;
                            m.right = m.right.right;
                            m.Addl("!");
                            m.Addr("!");
                            m.right = NotDown(m.right);
                            m.left = NotDown(m.left);
                            return m;
                        }
                    case '!':
                        {
                            return m.right.right;
                        }
                }
            if (m.right != null) m.right = NotDown(m.right);
            if (m.left != null) m.left = NotDown(m.left);
            return m;
        }

        private modnode ConvertToAON(modnode m) //Исключает штрих Шеффера, стрелку Пирса, импликацию, эквивалентность и сложение по модулю 2.
        {
            modnode tl, tr;
            if (m.right != null) m.right = ConvertToAON(m.right);
            if (m.left != null) m.left = ConvertToAON(m.left);
            if (m.data == "/")
            {
                m.data = "V";
                m.Addl("!");
                m.Addr("!");
                return m;
            }
            if (m.data == "|")
            {
                m.data = "&";
                m.Addl("!");
                m.Addr("!");
                return m;
            }
            if (m.data == ">")
            {
                m.data = "V";
                m.Addl("!");
                return m;
            }
            if (m.data == "=") //(x = y) == (!y V x) & (!x V y)
            {
                tl = m.left.Copy();
                tr = m.right.Copy();
                m.data = "&";
                m.Addl("V");
                m.left.left = tr;
                m.left.Addl("!");
                m.Addr("V");
                m.right.left = tl;
                m.right.Addl("!");
                return m;
            }
            if (m.data == "+") //(x + y) == (y V x) & (!x V !y)
            {
                tl = m.left.Copy();
                tr = m.right.Copy();
                m.data = "&";
                m.Addl("V");
                m.left.left = tr;
                m.Addr("V");
                m.right.Addr("!");
                m.right.left = tl;
                m.right.Addl("!");
                return m;
            }
            return m;
        }

        private modnode Pars(modnode m) //Разбивает логическое выражение на атомы.
        {
            int sk = 0, j, k;
            char[] pr3 = { '/', '|' };
            int p3 = m.data.IndexOfAny(pr3);
            if (p3 != -1)
            {
                for (int i = m.data.Length - 1; i >= 0; i--)
                {
                    if (sk == 0)
                        switch (m.data[i])
                        {
                            case '/':
                                {
                                    m.Addl(m.data.Substring(0, i));
                                    m.Addr(m.data.Substring(i + 1, m.data.Length - i - 1));
                                    m.data = "/";
                                    m.left = Pars(m.left);
                                    m.right = Pars(m.right);
                                    return m;
                                }
                            case '|':
                                {
                                    m.Addl(m.data.Substring(0, i));
                                    m.Addr(m.data.Substring(i + 1, m.data.Length - i - 1));
                                    m.data = "|";
                                    m.left = Pars(m.left);
                                    m.right = Pars(m.right);
                                    return m;
                                }
                        }
                    if (m.data[i] == ')') sk++;
                    if (m.data[i] == '(') sk--;
                }
            }
            if (m.data.Contains('='))
            {
                sk = 0;
                for (int i = m.data.Length - 1; i >= 0; i--)
                {
                    if ((sk == 0) && (m.data[i] == '='))
                    {
                        m.Addl(m.data.Substring(0, i));
                        m.Addr(m.data.Substring(i + 1, m.data.Length - i - 1));
                        m.data = "=";
                        m.left = Pars(m.left);
                        m.right = Pars(m.right);
                        return m;
                    }
                    if (m.data[i] == ')') sk++;
                    if (m.data[i] == '(') sk--;
                }
            }
            if (m.data.Contains('>'))
            {
                sk = 0;
                for (int i = m.data.Length - 1; i >= 0; i--)
                {
                    if ((sk == 0) && (m.data[i] == '>'))
                    {
                        m.Addl(m.data.Substring(0, i));
                        m.Addr(m.data.Substring(i + 1, m.data.Length - i - 1));
                        m.data = ">";
                        m.left = Pars(m.left);
                        m.right = Pars(m.right);
                        return m;
                    }
                    if (m.data[i] == ')') sk++;
                    if (m.data[i] == '(') sk--;
                }
            }
            char[] pr4 = { 'V', '+' };
            int p4 = m.data.IndexOfAny(pr4);
            if (p4 != -1)
            {
                sk = 0;
                for (int i = m.data.Length - 1; i >= 0; i--)
                {
                    if (sk == 0)
                        switch (m.data[i])
                        {
                            case '+':
                                {
                                    m.Addl(m.data.Substring(0, i));
                                    m.Addr(m.data.Substring(i + 1, m.data.Length - i - 1));
                                    m.data = "+";
                                    m.left = Pars(m.left);
                                    m.right = Pars(m.right);
                                    return m;
                                }
                            case 'V':
                                {
                                    m.Addl(m.data.Substring(0, i));
                                    m.Addr(m.data.Substring(i + 1, m.data.Length - i - 1));
                                    m.data = "V";
                                    m.left = Pars(m.left);
                                    m.right = Pars(m.right);
                                    return m;
                                }
                        }
                    if (m.data[i] == ')') sk++;
                    if (m.data[i] == '(') sk--;

                }
            }
            if (m.data.Contains('&'))
            {
                sk = 0;
                for (int i = m.data.Length - 1; i >= 0; i--)
                {
                    if ((sk == 0) && (m.data[i] == '&'))
                    {
                        m.Addl(m.data.Substring(0, i));
                        m.Addr(m.data.Substring(i + 1, m.data.Length - i - 1));
                        m.data = "&";
                        m.left = Pars(m.left);
                        m.right = Pars(m.right);
                        return m;
                    }
                    if (m.data[i] == ')') sk++;
                    if (m.data[i] == '(') sk--;

                }
            }
            if (m.data.StartsWith("!"))
            {
                m.Addr(m.data.Substring(1));
                m.data = "!";
                m.right = Pars(m.right);
                return m;
            }
            if (m.data.StartsWith("(") && m.data.EndsWith(")"))
            {
                m.data = m.data.Substring(1, m.data.Length - 2);
                m = Pars(m);
                return m;
            }
            if (m.data.StartsWith("$") || m.data.StartsWith("#"))
            {
                j = 2;
                if (m.data[1] >= 'a' && m.data[1] <= 'z')
                {
                    while (j<m.data.Length && m.data[j] >= '0' && m.data[j] <= '9')
                    {
                        j++;
                    }
                    m.Addr(m.data.Substring(j, m.data.Length - j));
                    m.data = m.data.Substring(0, j);
                    m.right = Pars(m.right);
                }
                else correct = false;
                return m;
            }            
            if (pred(m.data))
            {
                k = 1;
                string x;
                while (m.data[k] != '(')
                    k++;
                k++;
                while (k != m.data.Length)
                {
                    j = k;
                    while (m.data[j] != ',' && m.data[j] != ')')
                        j++;
                    x = m.data.Substring(k, j-k);
                    if (perems.IndexOf(x) == -1)
                        perems.Add(x);
                    k = j + 1;
                }                
                return m;
            }
            if (perem(m.data))
            {
                if (perems.IndexOf(m.data) == -1)
                    perems.Add(m.data);
                return m;
            }
            correct = false;
            return m;
        }

        private bool pred(string s) //Является ли s предикатом первого порядка, например A12(y23, x5) - ППП.
        {
            int i=1;
            bool sk = false;
            if (s != "" && s.Length>1)
            {
                if (s[0] != 'V' && s[0] >= 'A' && s[0] <= 'Z')
                {
                    while (i < s.Length && !sk)
                        if (s[i] >= '0' && s[i] <= '9')
                            i++;
                        else if (s[i] == '(')
                        {
                            sk = true;
                            i++;
                        }
                        else return false;
                    while (i < s.Length && sk)
                    { 
                        if (s[i] >= 'a' && s[i] <= 'z')
                            i++;
                        else return false;
                        while (i < s.Length && sk)
                        {
                            if (s[i] >= '0' && s[i] <= '9')
                                i++;
                            else if (s[i] == ')')
                            {
                                sk = false;
                                i++;
                            }
                            else if (s[i] == ',')
                            {
                                i++;
                                break;
                            }
                            else return false;
                        }
                    }
                    if (i == s.Length)
                        return true;
                    else return false;
                }
                else return false;
            }
            else return false;
        }

        private void Clean_Click(object sender, EventArgs e)
        {
            textBox_input.Text = "";
            textBox_output.Text = "";
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox1 = new AboutBox1();
            aboutBox1.ShowDialog();
        }

        private bool perem(string s) //Является ли s переменной или константой, например x11 - переменная.
        {
            if (s != "")
            {
                if (s.Length == 1 && (s[0] == '1' || s[0] == '0'))
                    return true;
                if (s[0] < 'a' || s[0] > 'z')
                    return false;
                for (int i=1; i<s.Length; i++)
                    if (s[i] < '0' || s[i] > '9')
                        return false;
                return true;
            }
            else return false;       
        }
    }
}
