using System;
using System.Numerics;

namespace QuadraticEquationSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var os = new QuadraticEquationSolver(new OrdinaryDiscriminantStrategy());
            var tuple1 = os.Solve(1, 5, 3);
            Console.WriteLine($"Solutions: {tuple1.Item1}, {tuple1.Item2}");
            var tuple2 = os.Solve(1, 2, 3);
            Console.WriteLine($"Solutions: {tuple2.Item1}, {tuple2.Item2}");
            var rs = new QuadraticEquationSolver(new RealDiscriminantStrategy());
            tuple1 = rs.Solve(1, 5, 3);
            Console.WriteLine($"Solutions: {tuple1.Item1}, {tuple1.Item2}");
            tuple2 = rs.Solve(1, 2, 3);
            Console.WriteLine($"Solutions: {tuple2.Item1}, {tuple2.Item2}");
        }
    }
}
