using System;

namespace NCalculator
{
    class Point
    {
        public Point() { }
        public Point(in float x, in float y)
        {
            this.x = x;
            this.y = y;
        }
        void Show()
        {
            Console.WriteLine($"X: {x}\nY: {y} ");
        }
        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }

        private 
            float x, y;
    }

    class Counter
    {
        public Counter() { }
        public Counter(in uint min, in uint max)
        {
            this.min = min;
            this.max = max;
        }
        public uint Min { get => min; private set => min = value; }
        public uint Max { get => max; private set => max = value; }
        public void Increment()
        {
            if (min == max) min = 0;
            if (min < max) min++;
        }

        private
            uint min, max;
    }

    class Fraction
    {
        public Fraction() { }
        public Fraction(uint numerator, uint denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }
        public uint Numerator { 
            get => numerator; 
            private set => numerator = value; 
        }
        public uint Denominator { 
            get => denominator; 
            private set => denominator = value; 
        }

        public Fraction Addition(ref Fraction other) // Toplama
        {
            Fraction tmp = new Fraction();
            if (denominator == other.Denominator)
            {
                tmp.Numerator = this.numerator + other.Numerator;
                tmp.Denominator = this.denominator;
            }
            else
            {
                uint common;
                _ = (denominator > other.denominator) ? common = denominator : common = other.denominator; 
                while (true)
                {
                    if (common % denominator == 0 && common % other.denominator == 0)
                    {
                        tmp.numerator = (numerator * (common / denominator)) + (other.numerator * (common / other.denominator));
                        tmp.denominator = common;
                        break;
                    }
                    common++;
                }
            }
            return tmp;
        }
        public Fraction Subtraction(ref Fraction other) // Cixma
        {
            Fraction tmp = new Fraction();
            if (denominator == other.Denominator)
            {
                tmp.Numerator = other.numerator - this.Numerator;
                tmp.Denominator = this.denominator;
            }
            else
            {
                uint common;
                _ = (denominator > other.denominator) ? common = denominator : common = other.denominator;
                while (true)
                {
                    if (common % denominator == 0 && common % other.denominator == 0)
                    {
                        tmp.numerator =  (other.numerator * (common / other.denominator)) - (numerator * (common / denominator));
                        tmp.denominator = common;
                        break;
                    }
                    common++;
                }
            }
            return tmp;
        }
        public Fraction Multiplication(ref Fraction other) // Vurma
        {
            Fraction tmp = new Fraction();
            tmp.numerator = other.numerator * numerator;
            tmp.denominator = other.denominator * denominator;
            return tmp;
        }
        public Fraction Division(ref Fraction other) // Bolme
        {
            Fraction tmp = new Fraction();
            tmp.numerator = other.numerator * denominator;
            tmp.denominator = other.denominator * numerator;
            return tmp;
        }
        public void IncorFractToCorFract()
        { // Incorrect Fraction To Correct Fraction - Düzgün olmayan kəsri düzgün olana çevirmə
            residual = numerator / denominator;
            numerator = numerator - (residual * denominator);
        }
        public void Abbreviation() 
        {
            if (numerator == denominator) numerator = denominator = 1;
            else
            {
                for (uint i = 2; i < numerator; i++)
                {
                    if (numerator % i == 0 && denominator % i == 0)
                    {
                        numerator = numerator / i;
                        denominator = denominator / i;
                        i = 1;
                    }
                }
            }
        }

        public void Print()
        {
            if (numerator == denominator) Console.WriteLine($" {numerator}");
            else Console.WriteLine($"   {numerator}\n{residual} ---\n   {denominator}");
        }

        private
            uint numerator, denominator, residual;
    }//            sürət      məxrəc       qaliq

    class Program
    {
        static void Main(string[] args)
        {
            //Point point = new Point();
            //Console.WriteLine(point.X);

            //Counter counter = new Counter(0,5);

            //Console.WriteLine(counter.GetIncrement());

            //for (int i = 0; i < counter.Max; i++)
            //{
            //    counter.Increment();
            //    Console.WriteLine(counter.Min);
            //}

            Fraction a = new Fraction(29,12);
            Fraction b = new Fraction(3,7);

            Fraction result = new Fraction();

            //result = b.Addition(ref a); // <------------- Toplama
            //result = b.Subtraction(ref a); // <---------- Cıxma
            //result = b.Multiplication(ref a); // <------- Vurma
            //result = b.Division(ref a); // <------------- Bölmə
            //result.Abbreviation(); // <------------------ İxtisar
            // result = a; 
            result.IncorFractToCorFract(); // Düzgün olmayan kəsri düzgün olan kəsrə çevirmə. 
            result.Print();
        }
    }
}