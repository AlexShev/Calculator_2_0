using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator_2_0
{
    //класс, реализующий интерфейс InterfaceCalc
    public class Calculator
    {
        private double _first = 0;
        private double _second = 0;

        public bool ThereIsFirst { get; private set; } = false;
        public bool ThereIsSecond { get; private set; } = false;

        public double First
        {
            get => _first;
            set
            {
                _first = value;
                FirstNum = value.ToString();
                ThereIsFirst = true;
            }
        }

        public double Second
        {
            get => _second;
            set
            {
                _second = value;
                SecondNum = value.ToString();
                ThereIsSecond = true;
            }
        }

        public bool IsFirst { get; set; } = true;

        public double Memory { get; set; } = 0;

        public string FirstNum { get; private set; } = string.Empty;
        public string SecondNum { get; private set; } = string.Empty;
        public string Result { get; private set; } = string.Empty;

        public void ClearFirst()
        {
            _first = 0;

            FirstNum = string.Empty;

            ThereIsFirst = false;
        }

        public void ClearSecond()
        {
            _second = 0;

            SecondNum = string.Empty;

            ThereIsSecond = false;
        }

        //стереть содержимое регистра мамяти
        public void MemoryClear() => Memory = 0;

        public double Multiplication()
        {
            Result = FirstNum + " × " + SecondNum;

            _first *= _second;

            FirstNum = _first.ToString();

            return _first;
        }

        public double Division()
        {
            if (_second == 0)
            {
                throw new Exception("На ноль делить нельзя!");
            }

            Result = FirstNum + " ÷ " + SecondNum;

            _first /= _second;

            FirstNum = _first.ToString();

            return _first;
        }

        public double Sum()
        {
            Result = FirstNum + " + " + SecondNum;

            _first += _second;

            FirstNum = _first.ToString();

            return _first;
        }

        //вычитание
        public double Subtraction()
        {
            Result = FirstNum + " - " + SecondNum;

            _first -= _second;

            FirstNum = _first.ToString();

            return _first;
        }

        public double Sqrt()
        {
            if (IsFirst)
            {
                FirstNum = $"sqrt({FirstNum})";

                return _first = Math.Sqrt(_first);
            }
            else
            {
                SecondNum = $"sqrt({SecondNum})";

                return _second = Math.Sqrt(_second);
            }
        }

        public double Square()
        {
            if (IsFirst)
            {
                FirstNum = $"sqr({FirstNum})";

                return _first = Math.Pow(_first, 2.0);
            }
            else
            {
                SecondNum = $"sqr({SecondNum})";

                return _second = Math.Pow(_second, 2.0);
            }
        }

        public double Factorial()
        {
            double f = 1;

            if (IsFirst)
            {
                if ((_first % 1) != 0)
                {
                    throw new Exception("NaN");
                }

                FirstNum = $"{FirstNum}!";

                for (int i = 1; i <= _first; i++)
                    f *= i;

                return _first = f;
            }
            else
            {
                if ((_second % 1) == 0)
                {
                    throw new Exception("NaN");
                }

                SecondNum = $"{SecondNum}!";

                for (int i = 1; i <= _second; i++)
                    f *= i;

                return _second = f;
            }
        }

        public double ReversNumber()
        {
            if (IsFirst)
            {
                FirstNum = $"1/({FirstNum})";

                return _first = 1.0 / _first;
            }
            else
            {
                SecondNum = $"1/({SecondNum})";

                return _second = 1.0 / _second;
            }
        }

        public double Negate()
        {
            if (IsFirst)
            {
                FirstNum = $"negate({FirstNum})";

                return _first = -_first;
            }
            else
            {
                SecondNum = $"negate({SecondNum})";

                return _second = -_second;
            }
        }

        // + - к регистру памяти
        public void MemorySum(double number) => Memory += number;

        public void MemorySubtraction(double number) => Memory -= number;
    }
}
