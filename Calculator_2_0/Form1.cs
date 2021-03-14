using System;
using System.Windows.Forms;
using Button = System.Windows.Forms.Button;

namespace Calculator_2_0
{
    public partial class Form1 : Form
    {
        Calculator calculator = new Calculator();

        bool tochange = false;

        bool isNew = false;

        string _operetion = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void numbersOnly(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (isNew)
            {
                buttonClear.PerformClick();
                lblOperetion.Text = string.Empty;

                tochange = false;
                isNew = false;
            }
            else if (tochange)
            {
                buttonClear.PerformClick();

                tochange = false;
            }     

            txtDesplay.Text += button.Text;

            CorrectNumber();
        }

        //удаляем лишний ноль впереди числа, если таковой имеется
        private void CorrectNumber()
        {
            //если есть знак "бесконечность" - не даёт писать цифры после него
            if (txtDesplay.Text.IndexOf("∞") != -1)
                txtDesplay.Text = txtDesplay.Text.Substring(0, txtDesplay.Text.Length - 1);

            //ситуация: слева ноль, а после него НЕ запятая, тогда ноль можно удалить
            if (txtDesplay.Text[0] == '0' && (txtDesplay.Text.IndexOf(",") != 1))
                txtDesplay.Text = txtDesplay.Text.Remove(0, 1);

            //аналогично предыдущему, только для отрицательного числа
            if (txtDesplay.Text[0] == '-')
                if (txtDesplay.Text[1] == '0' && (txtDesplay.Text.IndexOf(",") != 2))
                    txtDesplay.Text = txtDesplay.Text.Remove(1, 1);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            txtDesplay.Text = "0";

            if (calculator.IsFirst)
            {
                calculator.ClearFirst();
            }
            else
            {
                calculator.ClearSecond();
            }

            tochange = false;
        }

        private void buttonС_Click(object sender, EventArgs e)
        {
            txtDesplay.Text = "0";

            calculator.ClearFirst();

            calculator.ClearSecond();

            calculator.IsFirst = true;

            lblOperetion.Text = string.Empty;

            _operetion = string.Empty;

            tochange = false;

            isNew = false;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (!txtDesplay.Text.Contains('E'))
            {
                txtDesplay.Text = txtDesplay.Text.Length == 1 ? "0" :
                    txtDesplay.Text.Remove(txtDesplay.Text.Length - 1);
            }
        }

        private void BinaryOperathionLogic(string operetion)
        {
            if (calculator.IsFirst)
            {
                if (!calculator.ThereIsFirst)
                {
                    calculator.First = double.Parse(txtDesplay.Text);
                }

                calculator.IsFirst = false;

                tochange = true;

                _operetion = operetion;

                lblOperetion.Text = $"{calculator.FirstNum} {_operetion}";
            }
            else if (_operetion != operetion)
            {
                _operetion = operetion;

                lblOperetion.Text = $"{calculator.FirstNum} {_operetion}";
            }
            else
            {
                calculator.ClearSecond();

                tochange = true;

                isNew = false;
            }
        }

        private void buttonCalc_Click(object sender, EventArgs e)
        {
            if (!calculator.ThereIsFirst)
            {
                calculator.First = Double.Parse(txtDesplay.Text);

                lblOperetion.Text = calculator.FirstNum + " = ";
            }
            else
            {
                lblOperetion.Text = $"{calculator.FirstNum} {_operetion}";
            }

            tochange = true;

            isNew = true;

            Calculete();
        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {
            BinaryOperathionLogic("÷");
        }

        private void buttonMult_Click(object sender, EventArgs e)
        {
            BinaryOperathionLogic("×");
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            BinaryOperathionLogic("-");
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            BinaryOperathionLogic("+");
        }

        private void Calculete()
        {
            if (!calculator.ThereIsSecond)
            {
                calculator.Second = double.Parse(txtDesplay.Text);
            }

            switch (_operetion)
            {
                case "+":
                    txtDesplay.Text = calculator.Sum().ToString();
                    break;
                case "-":
                    txtDesplay.Text = calculator.Subtraction().ToString();
                    break;
                case "×":
                    txtDesplay.Text = calculator.Multiplication().ToString();
                    break;
                case "÷":
                    txtDesplay.Text = calculator.Division().ToString();
                    break;
                default:
                    break;
            }

            lblOperetion.Text = calculator.Result;

            calculator.IsFirst = true;
        }

        private void UnaryOperationLogic()
        {
            if (calculator.IsFirst)
            {
                if (!calculator.ThereIsFirst)
                    calculator.First = Double.Parse(txtDesplay.Text);
            }
            else
            {
                if (!calculator.ThereIsSecond)
                    calculator.Second = Double.Parse(txtDesplay.Text);
            }

            tochange = true;
        }

        private void buttonSquare_Click(object sender, EventArgs e)
        {
            UnaryOperationLogic();

            txtDesplay.Text = calculator.Square().ToString();

            lblOperetion.Text = calculator.IsFirst ? calculator.FirstNum : calculator.SecondNum;
        }

        private void buttonFactorial_Click(object sender, EventArgs e)
        {
            UnaryOperationLogic();

            txtDesplay.Text = calculator.Factorial().ToString();

            lblOperetion.Text = calculator.IsFirst ? calculator.FirstNum : calculator.SecondNum;
        }

        private void buttonSqrt_Click(object sender, EventArgs e)
        {
            UnaryOperationLogic();

            txtDesplay.Text = calculator.Sqrt().ToString();

            lblOperetion.Text = calculator.IsFirst ? calculator.FirstNum : calculator.SecondNum;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            UnaryOperationLogic();

            txtDesplay.Text = calculator.ReversNumber().ToString();

            lblOperetion.Text = calculator.IsFirst ? calculator.FirstNum : calculator.SecondNum;
        }

        private void buttonChangeSign_Click(object sender, EventArgs e)
        {
            UnaryOperationLogic();

            txtDesplay.Text = calculator.Negate().ToString();

            lblOperetion.Text = calculator.IsFirst ? calculator.FirstNum : calculator.SecondNum;
        }

        private void buttonMC_Click(object sender, EventArgs e)
        {
            calculator.MemoryClear();
        }

        private void buttonMR_Click(object sender, EventArgs e)
        {
            if (isNew)
            {
                buttonClear.PerformClick();
                lblOperetion.Text = string.Empty;

                tochange = false;
                isNew = false;
            }
            else if (tochange)
            {
                buttonClear.PerformClick();

                tochange = false;
            }

            txtDesplay.Text = calculator.Memory.ToString();
        }

        private void buttonMPlus_Click(object sender, EventArgs e)
        {
            calculator.MemorySum(Convert.ToDouble(txtDesplay.Text));
        }

        private void buttonMMinus_Click(object sender, EventArgs e)
        {
            calculator.MemorySubtraction(Convert.ToDouble(txtDesplay.Text));
        }

        private void buttonMS_Click(object sender, EventArgs e)
        {
            calculator.Memory = Convert.ToDouble(txtDesplay.Text);
        }

        private void buttonM_Click(object sender, EventArgs e)
        {
            MessageBox.Show(calculator.Memory.ToString());
        }
    }
}
