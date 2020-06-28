using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace QuadraticEquationSolver
{
    public class QuadraticEquationSolver
    {
        private readonly IDiscriminantStrategy strategy;

        public QuadraticEquationSolver(IDiscriminantStrategy strategy)
        {
            this.strategy = strategy;
        }

        public Tuple<Complex, Complex> Solve(double a, double b, double c)
        {
            var d = strategy.CalculateDiscriminant(a, b, c);

            var s1 = (-b + Complex.Sqrt(d)) / 2 / a;
            var s2 = (-b - Complex.Sqrt(d)) / 2 / a;
            return (s1, s2).ToTuple();
        }
    }
}
