using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Complex_with_seialization
{
    public class Program
    {
        public class Complex //creat a class
        {
            //added datas
            public int x;
            public int y;
            public Complex(int x, int y) //creat a constructor
            {
                //initialize class attributes
                this.x = x;
                this.y = y;
            }
            public Complex() { }
            //function to find gcd of two complex numbers
            public static int gcd(int x, int y)
            {
                if (y < x)
                    swap(x, y);
                if (x == 0)
                    return y;
                return gcd(y % x, x);
            }

            private static void swap(int x, int y)
            {
                throw new NotImplementedException();
            }

            //provide overload a binary operator +
            public static Complex operator +(Complex x, Complex y)
            {
                //changed the purpose of  +  by adding new class 
                Complex c = new Complex(x.x * y.y + y.x * x.y, x.y * y.y);
                return c;
            }
            //provide overload a binary operator -
            public static Complex operator -(Complex x, Complex y)
            {
                //changed the purpose of  -  by adding new class 
                Complex c = new Complex(x.x * y.y - y.x * x.y, x.y * y.y);
                return c;
            }
            //provide overload a binary operator /
            public static Complex operator /(Complex x, Complex y)
            {
                //changed the purpose of  /  by adding new class 
                Complex c = new Complex(x.x * y.y, x.y * y.x);
                return c;
            }
            //provide overload a binary operator *
            public static Complex operator *(Complex x, Complex y)
            {
                //changed the purpose of  *  by adding new class 
                Complex c = new Complex(x.x * y.x, x.y * y.y);
                return c;
            }
            //rewrite function ToString() to divide to gcd()
            public override string ToString()
            {
                return this.x / gcd(this.x, this.y) + "/" + this.y / gcd(this.x, this.y);
            }

        }
        static void Main(string[] args)
        {

            string s = Console.ReadLine(); // insert values  
            string[] arr = s.Split(); //divide them by the space
            Complex sum = new Complex(0, 0); //creat a new complex with zero atributes 
            foreach (string ss in arr) //rewrite values from array to string 
            {
                string[] t = ss.Split('/'); //divide them by /
                Complex p = new Complex(int.Parse(t[0]), int.Parse(t[1]));
                if (sum.x == 0 & sum.y == 0)
                {
                    sum = p;
                }
                else
                {
                    sum = sum + p;
                }
            }
            FileStream fs = new FileStream("sum.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            xs.Serialize(fs, sum);
            fs.Close();
            Complex sub = new Complex(0, 0);
            foreach (string ss in arr)
            {
                string[] t = ss.Split('/');
                Complex p = new Complex(int.Parse(t[0]), int.Parse(t[1]));
                if (sub.x == 0 & sub.y == 0)
                {
                    sub = p;
                }
                else
                {
                    sub = sub - p;
                }
            }
            FileStream fx = new FileStream("sub.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xx = new XmlSerializer(typeof(Complex));
            xs.Serialize(fx, sub);
            fx.Close();
            Complex mul = new Complex(0, 0);
            foreach (string ss in arr)
            {
                string[] t = ss.Split('/');
                Complex p = new Complex(int.Parse(t[0]), int.Parse(t[1]));
                if (mul.x == 0 & mul.y == 0)
                {
                    mul = p;
                }
                else
                {
                    mul = mul * p;
                }
            }
            FileStream fy = new FileStream("mul.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xy = new XmlSerializer(typeof(Complex));
            xs.Serialize(fy, mul);
            fy.Close();
            Complex div = new Complex(0, 0);
            foreach (string ss in arr)
            {
                string[] t = ss.Split('/');
                Complex p = new Complex(int.Parse(t[0]), int.Parse(t[1]));
                if (div.x == 0 & div.y == 0)
                {
                    div = p;
                }
                else
                {
                    div = div / p;
                }
            }
            FileStream fz = new FileStream("div.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xz = new XmlSerializer(typeof(Complex));
            xs.Serialize(fz, div);
            fz.Close();
            //show results 
            //we rewrited ToString, so we can just write names of operations(complex)
            Console.WriteLine(sum);
            Console.WriteLine(sub);
            Console.WriteLine(mul);
            Console.WriteLine(div);
            Console.ReadKey();
        }
    }
}