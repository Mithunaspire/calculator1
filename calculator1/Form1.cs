using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textbox.Text = textbox.Text + btn1.Text;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            textbox.Text = textbox.Text + btn2.Text;
        }
        private void btn3_Click(object sender, EventArgs e)
        {
            textbox.Text = textbox.Text + btn3.Text;
        }
        private void btn4_Click(object sender, EventArgs e)
        {
            textbox.Text = textbox.Text + btn4.Text;
        }
        private void btn5_Click(object sender, EventArgs e)
        {
            textbox.Text = textbox.Text + btn5.Text;
        }
        private void btn6_Click(object sender, EventArgs e)
        {
            textbox.Text = textbox.Text + btn6.Text;
        }
        private void btn7_Click(object sender, EventArgs e)
        {
            textbox.Text = textbox.Text + btn7.Text;
        }
        private void btn8_Click(object sender, EventArgs e)
        {
            textbox.Text = textbox.Text + btn8.Text;
        }
        private void btn9_Click(object sender, EventArgs e)
        {
            textbox.Text = textbox.Text + btn9.Text;
        }
        private void button19_Click(object sender, EventArgs e)
        {
            textbox.Text = textbox.Text + btn0.Text;
        }
        private void btndot_Click(object sender, EventArgs e)
        {
            textbox.Text = textbox.Text + btndot.Text;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button13_Click(object sender, EventArgs e)
        {
            textbox.Text = textbox.Text + btnmul.Text;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            textbox.Text = textbox.Text + btnadd.Text;
        }

        private void btnsub_Click(object sender, EventArgs e)
        {
            textbox.Text = textbox.Text + btnsub.Text;
        }

        private void btndiv_Click(object sender, EventArgs e)
        {
            textbox.Text = textbox.Text + btndiv.Text;
        }

        private void btnopen_Click(object sender, EventArgs e)
        {
            textbox.Text = textbox.Text + btnopen.Text;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            textbox.Text = textbox.Text + btnclose.Text;
        }

        private void btneql_Click(object sender, EventArgs e)  //ACTION
        {
            try
            {
                char[] ch = textbox.Text.ToCharArray();
                Stack<int> n = new Stack<int>();
                Stack<char> s = new Stack<char>();
                for (int i = 0; i < ch.Length; i++)
                {
                    if (ch[i] == ' ')
                    {
                        continue;
                    }
                    if (ch[i] >= '0' && ch[i] <= '9')
                    {
                        StringBuilder sb = new StringBuilder();
                        while (i < ch.Length && ch[i] >= '0' && ch[i] <= '9')
                        {
                            sb.Append(ch[i++]);
                        }
                        n.Push(int.Parse(sb.ToString()));
                        i--;
                    }
                    else if (ch[i] == '(')
                    {
                        s.Push(ch[i]);
                    }
                    else if (ch[i] == ')')
                    {
                        while (s.Peek() != '(')
                        {
                            n.Push(cal(s.Pop(), n.Pop(), n.Pop()));
                        }
                        s.Pop();
                    }
                    else if (ch[i] == '+' || ch[i] == '-' || ch[i] == '*' || ch[i] == '/' || ch[i] == '%')
                    {
                        while (s.Count > 0 && hasPrecedence(ch[i], s.Peek()))
                        {
                            n.Push(cal(s.Pop(), n.Pop(), n.Pop()));
                        }
                        s.Push(ch[i]);
                    }
                }
                while (s.Count > 0)
                {
                    n.Push(cal(s.Pop(), n.Pop(), n.Pop()));
                }
                textbox.Text = n.Pop().ToString();
            }
            catch(Exception ex) { 
                MessageBox.Show("Invalid Use of Operators ");
            }
        }
        public static bool hasPrecedence(char op1,char op2)
        {
            if (op2 == '(' || op2 == ')')
            {
                return false;
            }
            if ((op1 == '*' || op1 == '/') &&
                   (op2 == '+' || op2 == '-'))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public int cal(char c, int b, int a)
        {
            switch (c)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a * b;
                case '/':
                    if (b == 0)
                    {
                        try
                        {
                            return a / b;
                        }catch(DivideByZeroException e)
                        {
                            MessageBox.Show("Invalid"); 
                            return 0;
                        }
                    }
                    return a / b;
                case '%':
                    return a % b;
            }
            return 0;
        }
        private void btnmod_Click(object sender, EventArgs e)
        {
            textbox.Text += btnmod.Text;
        }
        private void btnclr_Click(object sender, EventArgs e)
        {
            textbox.Clear();
        }
    }
}
