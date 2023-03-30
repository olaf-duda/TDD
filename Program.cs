using System;

namespace TDD_dudao
{
    class Program
    {
        string[] delimiters = { ",", "\n" };
        string numbers_ = "";

        public void AddDelimiters()
        {
            delimiters = new string[] { ",", "\n" };
            string new_delimiter = "";
            bool add_delimiter = false;
            if (numbers_[0] == '/' && numbers_[1] == '/')
            {
                int i = 2;
                while (numbers_[i] != '\n')
                {
                    if (numbers_[i] == '[')
                    {
                        add_delimiter = true;
                    }
                    else if (numbers_[i] == ']')
                    {
                        Array.Resize(ref delimiters, delimiters.Length + 1);
                        delimiters[delimiters.Length - 1] = new_delimiter;
                        new_delimiter = "";
                        add_delimiter = false;
                    }
                    else if (add_delimiter)
                    {
                        new_delimiter += numbers_[i];
                    }
                    else
                    {
                        new_delimiter += numbers_[i];
                        Array.Resize(ref delimiters, delimiters.Length + 1);
                        delimiters[delimiters.Length - 1] = new_delimiter;
                        new_delimiter = "";
                    }
                    i++;
                }
            }
        }

        public double Add(string numbers)
        {
            double a = 0, result = 0, l = 0;
            string negatives = "";
            string my_delimiter = "";
            numbers_ = numbers;

            int i;
            AddDelimiters();

            bool neg = false;
            for (i = numbers.Length - 1; i >= 0; i--)
            {
                if (Array.Exists(delimiters, element => element == my_delimiter))
                {
                    if (neg)
                    {
                        negatives += '-' + a.ToString() + ' ';
                        neg = false;
                        a = 0; l = 0;
                    }
                    else
                    {
                        if (a > 1000)
                            a = 0;
                        result += a;
                        l = 0; a = 0; my_delimiter = ""; i++;
                    }

                    if (Array.Exists(delimiters, element => element == "-") && numbers[i] == '-')
                    {
                        neg = true;
                    }
                }
                else
                {
                    if (numbers[i] == '-' && Array.Exists(delimiters, element => element != "-"))
                        neg = true;
                    else if (numbers[i] >= 48 && numbers[i] <= 57)
                    {
                        a += (numbers[i] - '0') * Math.Pow(10, l);
                        l++;
                    }
                    else
                    {
                        my_delimiter += numbers[i];
                    }
                }
            }
            if (negatives != "")
            {
                Console.WriteLine("Your negatives are: " + negatives + "\nnegatives not allowed");
                return -1;
            }
            result += a;
            return result;
        }
    }
}

