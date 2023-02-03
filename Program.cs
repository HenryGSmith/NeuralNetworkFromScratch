using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace NeuralNetworkFromScratch
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Matrix<double> batch = DenseMatrix.OfArray(new double[,]
								{{  1.00,  2.00,  3.00,  2.50 },
								 {  2.00,  5.00, -1.00,  2.00 },
								 { -1.50,  2.70,  3.30, -0.80 }});

			Matrix<double> weights = DenseMatrix.OfArray(new double[,]
								{{  0.20,  0.80, -0.50,  1.00 }, 
								 {  0.50, -0.91,  0.26, -0.50 }, 
								 { -0.26, -0.27,  0.17,  0.87 }});
			Matrix<double> biases = DenseMatrix.OfArray(new double[,]
								{{ 2, 3, 0.5 }, { 2, 3, 0.5 }, { 2, 3, 0.5 } });

			Matrix<double> outputs = (batch * weights.Transpose()) + biases;

			Console.WriteLine(outputs.ToString());
		}
	}
}