using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

enum Sign {none, plus, minus, multiply, divide};

namespace Kalkulator
{
    public partial class Form1 : Form
    {
        string currentNumber;
        double elementNumber;
        Sign specyficSign;


        public Form1()
        {
            InitializeComponent();
            currentNumber = "";
            elementNumber = 0;
            specyficSign = Sign.none;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            numberButtonHandler(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            numberButtonHandler(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            numberButtonHandler(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            numberButtonHandler(4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            numberButtonHandler(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            numberButtonHandler(6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            numberButtonHandler(7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            numberButtonHandler(8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            numberButtonHandler(9);
        }

        private void button0_Click(object sender, EventArgs e)
        {
            numberButtonHandler(0);
        }

        private void button_plus_Click(object sender, EventArgs e)
        {
            signHandler(Sign.plus, sender, e);
        }

        private void button_equal_Click(object sender, EventArgs e)
        {
            if (currentNumber != "")
            {
                switch (specyficSign)
                {
                    case Sign.plus:
                        elementNumber = elementNumber + Double.Parse(currentNumber);
                        break;
                    case Sign.minus:
                        elementNumber = elementNumber - Double.Parse(currentNumber);
                        break;
                    case Sign.multiply:
                        elementNumber = elementNumber * Double.Parse(currentNumber);
                        break;
                    case Sign.divide:
                        elementNumber = elementNumber / Double.Parse(currentNumber);
                        break;
                }
            }
                if (specyficSign != Sign.none)
                {
                    textBox1.Text = elementNumber.ToString();
                    currentNumber = ""; // nessecery to propriate printing
                    specyficSign = Sign.none;
                }
        }

        private void button_minus_Click(object sender, EventArgs e)
        {
            signHandler(Sign.minus, sender, e);
        }

        private void button_multi_Click(object sender, EventArgs e)
        {
            signHandler(Sign.multiply, sender, e);
        }

        private void button_divide_Click(object sender, EventArgs e)
        {
            signHandler(Sign.divide, sender, e);
        }

        private void signHandler(Sign thisSign, object sender, EventArgs e)
        {
            if (specyficSign == Sign.none && currentNumber != "")
            {
                specyficSign = thisSign;
                elementNumber = Double.Parse(currentNumber);
                currentNumber = "";
            }
            else if (specyficSign == Sign.none && currentNumber == "")
                specyficSign = thisSign;
            else
            {
                button_equal_Click(sender, e);
                specyficSign = thisSign;
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            currentNumber = "";
            textBox1.Text = "";
            elementNumber = 0;
            specyficSign = Sign.none;
        }

        private void numberButtonHandler(int num)
        {
            if (currentNumber == "0")
                currentNumber = "";
            currentNumber = currentNumber + num.ToString();
            textBox1.Text = currentNumber;
        }

        private void button_dot_Click(object sender, EventArgs e)
        {
            if (currentNumber == "")
                currentNumber = currentNumber + "0.";
            else
                currentNumber = currentNumber + ",";
            textBox1.Text = currentNumber;
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            if (currentNumber != "")
            {
                currentNumber = currentNumber.Substring(0, currentNumber.Length - 1);
                textBox1.Text = currentNumber;
            }
        }

        private void button_sqrt_Click(object sender, EventArgs e)
        {
            Double help;
            if (currentNumber != "") // Necessary 'if' becauce equal sign
                help = Double.Parse(currentNumber);
            else
                help = elementNumber;
            help = Math.Sqrt(help);
            textBox1.Text = help.ToString();
            currentNumber = "";
            elementNumber = help;
            specyficSign = Sign.none;
        }

        private void button_square_Click(object sender, EventArgs e)
        {
            Double help;
            if (currentNumber != "") // Necessary if becauce equal sign
                help = Double.Parse(currentNumber);
            else
                help = elementNumber;
            help *= help;
            textBox1.Text = help.ToString();
            currentNumber = "";
            elementNumber = help;
            specyficSign = Sign.none;
        }
    }
}

//currentNumber = help.ToString();
//textBox1.Text = currentNumber;