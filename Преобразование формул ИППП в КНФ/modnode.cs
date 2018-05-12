using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Lab5
{
    public class modnode
    {
        public string data;
        public modnode left;
        public modnode right;
        public void Addr()
        {
            modnode temp;
            if (right == null)
            {
                right = new modnode();
            }
            else
            {
                temp = right;
                right = new modnode();
                right.right = temp;
            }
        }
        public void Addl()
        {
            modnode temp;
            if (left == null)
            {
                left = new modnode();
            }
            else
            {
                temp = left;
                left = new modnode();
                left.right = temp;
            }
        }
        public void Addr(string s)
        {
            modnode temp;
            if (right == null)
            {
                right = new modnode();
                right.data = s;
            }
            else
            {
                temp = right;
                right = new modnode();
                right.right = temp;
                right.data = s;
            }
        }
        public void Addl(string s)
        {
            modnode temp;
            if (left == null)
            {
                left = new modnode();
                left.data = s;
            }
            else
            {
                temp = left;
                left = new modnode();
                left.right = temp;
                left.data = s;
            }
        }
        public void Addr(modnode m)
        {
            right = m;
        }
        public void Addl(modnode m)
        {
            left = m;
        }
        public modnode Copy()
        {
            modnode r, l, t;
            t = new modnode();
            t.data = data;
            if (right != null)
            {
                r = right.Copy();
                t.right = r;              
            }
            if (left != null)
            {
                l = left.Copy();
                t.left = l;
            }
            return t;
        }
        public void Del()
        {
            if (right != null)
            {
                right.Del();
                right = null;
            }
            if (left != null)
            {
                left.Del();
                left = null;
            }
        }
        private int atomtoint(string a)
        {
            if (a != null)
            {
                if (a == "|" || a == "/") return 5;
                if (a == "=") return 4;
                if (a == ">") return 3;
                if (a == "+" || a == "V") return 2;
                if (a == "&") return 1;
                if (a[0] == '#' || a[0] == '$') return -1;
            }
            return 0;
        }
        public override string ToString()
        {
            string l="", r="";
            if (left != null)
            {
                l = left.ToString();
                if (atomtoint(left.data) > atomtoint(data)) l = '(' + l + ')';
            }
            if (right != null)
            {
                r = right.ToString();
                if (atomtoint(right.data) > atomtoint(data)) r = '(' + r + ')';
            }
            return l + data + r;
        }
        public string ToOPN()
        {
            string l = "", r = "";
            if (left != null)
            {
                l = left.ToOPN();
            }
            if (right != null)
            {
                r = right.ToOPN();
            }
            return l + r + data;
        }
        public string ToPPN()
        {
            string l = "", r = "";
            if (left != null)
            {
                l = left.ToOPN();
            }
            if (right != null)
            {
                r = right.ToOPN();
            }
            return data + l + r;
        }
    }
}
