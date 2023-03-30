using NUnit.Framework;
using System;

namespace TDD_dudao
{
    public class Tests
    {
        Program _program;

        [SetUp]
        public void Setup()
        {
            _program = new Program();
        }

        [Test]

        public void Test_add1()
        {
            //Given
            string numbers = "2,k";
            double exp = 2;

            //Then
            Assert.That(exp, Is.EqualTo(_program.Add(numbers)));
        }

        [Test]
        public void Test_add_multi()
        {
            //Given
            string numbers = "2,21,131";
            double exp = 154;

            Assert.That(exp, Is.EqualTo(_program.Add(numbers)));
        }

        [Test]
        public void Test_add_space()
        {
            //Given
            string numbers = "2,\n131";
            double exp = 133;

            Assert.That(exp, Is.EqualTo(_program.Add(numbers)));
        }

        [Test]
        public void Test_add_delimiters()
        {
            //Given
            string numbers = "//;\n1;2";
            double exp = 3;

            Assert.That(exp, Is.EqualTo(_program.Add(numbers)));
        }

        [Test]
        public void Test_add_negative()
        {
            //Given
            string numbers = "//;\n-1;-2";
            int exp = -1;

            Assert.That(exp, Is.EqualTo(_program.Add(numbers)));
        }

        [Test]
        public void Test_add_bigger()
        {
            //Given
            string numbers = "//;\n1001;2";
            double exp = 2;

            Assert.That(exp, Is.EqualTo(_program.Add(numbers)));
        }

        [Test]
        public void Test_add_bigger_deli()
        {
            //Given
            string numbers = "//[***]\n1***2***3";
            double exp = 6;

            Assert.That(exp, Is.EqualTo(_program.Add(numbers)));
        }

        [Test]
        public void Test_add_more_deli()
        {
            //Given
            string numbers = "//[*][%]\n1*2%3";
            double exp = 6;

            Assert.That(exp, Is.EqualTo(_program.Add(numbers)));
        }

        [Test]
        public void Test_add_more_bigger_deli()
        {
            //Given
            string numbers = "//[***][%]\n1***2%3";
            double exp = 6;

            Assert.That(exp, Is.EqualTo(_program.Add(numbers)));
        }
    }
}