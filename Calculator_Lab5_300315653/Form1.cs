using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_Lab5_300315653
{
    public partial class Form1 : Form
    {
        double firstValue = 0;
        double secondValue = 0;
        double bufferedValue = 0;
        string displayString = "";
        string operation = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void updateDisplay()
        {
            if (displayString == "") textBoxDisplay.Text = "0";
            else textBoxDisplay.Text = displayString;
        }

        private void ifEmptyForceZero()
        {
            if (displayString == "" && textBoxDisplay.Text == "0")
                displayString = "0";
            else displayString = textBoxDisplay.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            displayString += "1";
            updateDisplay();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            displayString += "2";
            updateDisplay();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            displayString += "3";
            updateDisplay();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            displayString += "4";
            updateDisplay();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            displayString += "5";
            updateDisplay();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            displayString += "6";
            updateDisplay();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            displayString += "7";
            updateDisplay();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            displayString += "8";
            updateDisplay();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            displayString += "9";
            updateDisplay();
        }

        private void button0_Click(object sender, EventArgs e)
        {
            if (displayString != "0")
            {
                displayString += "0";
                updateDisplay();
            }
        }

        private void buttonDot_Click(object sender, EventArgs e)
        {
            if (!displayString.Contains('.'))
            {
                if (displayString == "")
                {
                    displayString += "0.";
                }
                else
                {
                    displayString += ".";
                }
            }

            updateDisplay();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (displayString != "" && displayString != "0")
            {
                displayString = displayString.Remove(displayString.Length - 1, 1);
                updateDisplay();
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            firstValue = 0;
            secondValue = 0;
            bufferedValue = 0;
            displayString = "";
            operation = "";
            updateDisplay();
        }

        private void buttonChangeSignal_Click(object sender, EventArgs e)
        {
            if (displayString != "" && displayString != "0")
            {
                if (displayString.StartsWith("-"))
                {
                    displayString = displayString.Remove(0, 1);
                }
                else
                {
                    displayString = displayString.Insert(0, "-");
                }
            }
            updateDisplay();
            
        }

        private void buttonSqrt_Click(object sender, EventArgs e)
        {
            ifEmptyForceZero();
            double value = double.Parse(displayString);
            if (value >= 0)
            {
                double sqrtValue = Calculator.sqrt(value);
                displayString = sqrtValue.ToString();
                updateDisplay();
            }
            else
            {
                displayString = "ERROR: invalid input. Press the Clear button.";
                updateDisplay();
            }

        }

        private void buttonInvert_Click(object sender, EventArgs e)
        {
            ifEmptyForceZero();
            try
            {
                decimal value = Convert.ToDecimal(displayString);
                decimal invertedValue = Calculator.invert(value);
                displayString = invertedValue.ToString();
                updateDisplay();
            } 
            catch (DivideByZeroException)
            {
                displayString = "ERROR: invalid input. Press the Clear button.";
                updateDisplay();
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ifEmptyForceZero();
            firstValue = double.Parse(displayString);
            operation = "add";
            displayString = "";
            bufferedValue = 0;
        }

        private void buttonSubtract_Click(object sender, EventArgs e)
        {
            ifEmptyForceZero();
            firstValue = double.Parse(displayString);
            operation = "subtract";
            displayString = "";
            bufferedValue = 0;
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            ifEmptyForceZero();
            firstValue = double.Parse(displayString);
            operation = "multiply";
            displayString = "";
            bufferedValue = 0;
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            ifEmptyForceZero();
            firstValue = double.Parse(displayString);
            operation = "divide";
            displayString = "";
            bufferedValue = 0;
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            double result = 0;
            ifEmptyForceZero();
            secondValue = double.Parse(displayString);
            if (bufferedValue != 0)
            {
                firstValue = bufferedValue;
            }
            switch (operation)
            {
                case "add":
                    result = Calculator.add(firstValue, secondValue);
                    break;

                case "subtract":
                    if (bufferedValue != 0)
                    {
                        firstValue = secondValue;
                        secondValue = bufferedValue;
                    }
                    result = Calculator.subtract(firstValue, secondValue);
                    break;

                case "multiply":
                    result = Calculator.multiply(firstValue, secondValue);
                    break;

                case "divide":
                    if (bufferedValue != 0)
                    {
                        firstValue = secondValue;
                        secondValue = bufferedValue;
                    }
                    try
                    {
                        decimal firstValueDecimal = Convert.ToDecimal(firstValue);
                        decimal secondValueDecimal = Convert.ToDecimal(secondValue);
                        result = Convert.ToDouble(Calculator.divide(firstValueDecimal, 
                            secondValueDecimal));
                        break;
                    } catch (DivideByZeroException)
                    {
                        displayString = "ERROR: invalid input. Press the Clear button.";
                        updateDisplay();
                        return;
                    }
                    
                    

                default:
                    break;


            }

            if (bufferedValue == 0)
            {
                bufferedValue = secondValue;
            }
            
            displayString = result.ToString();
            updateDisplay();
            displayString = "";
        }
    }
}
