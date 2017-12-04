using System;
using System.Collections.Generic;
using System.Text;

namespace XmlComments
{
    /// <summary>
    /// This is a class that represents
    /// a simple mathematical calculator.
    /// <para>
    /// You can use it to add, subtract,
    /// divide and multiply integers and
    /// fractional numbers.
    /// </para>
    /// <list type="bullet">
    /// <listheader>Supported Operations</listheader>
    /// <item>Addition</item>
    /// <item>Subtraction</item>
    /// <item>Division</item>
    /// <item>Multiplication</item>
    /// </list>
    /// </summary>
    /// <remarks>
    /// This class is developed on .NET Framework 4.7
    /// </remarks>
    public class Calculator
    {
        /// <summary>
        /// This method adds two integers.
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <returns>An integer representing addition of a and b</returns>
        /// <permission cref="Add">Public method</permission>
        /// <seealso cref="Subtract"/>

        public int Add(int a, int b)
        {
            return (a + b);
        }

        /// <summary>
        /// This method subtracts two integers.
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <returns>A double representing subtraction of a and b</returns>
        /// <permission cref="Subtract">Public method</permission>
        /// <seealso cref="Add"/>

        public int Subtract(int a, int b)
        {
            return (a - b);
        }

        /// <summary>
        /// This method divides two integers.
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <returns>An integer representing result of division of a and b</returns>
        /// <permission cref="Divide">Public method</permission>
        /// <seealso cref="Subtract"/>

        public int Divide(int a, int b)
        {
            return (a / b);
        }

        /// <summary>
        /// This method multiplies two integers.
        /// </summary>
        /// <param name="a">The first number</param>
        /// <param name="b">The second number</param>
        /// <returns>An integer representing multiplication of a and b</returns>
        /// <permission cref="Multiply">Public method</permission>
        /// <seealso cref="Subtract"/>

        public int Multiply(int a, int b)
        {
            return (a * b);
        }
    }
}
