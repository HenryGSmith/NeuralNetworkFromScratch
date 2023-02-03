using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace NeuralNetworkFromScratch
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Vector<double> inputs = DenseVector.OfArray(new double[]{ 1, 2, 3, 2.5 });
			Matrix<double> weights = DenseMatrix.OfArray(new double[,]
								{{  0.20,  0.80, -0.50,  1.00 }, 
								 {  0.50, -0.91,  0.26, -0.50 }, 
								 { -0.26, -0.27,  0.17,  0.87 }});
			Vector<double> biases = DenseVector.OfArray(new double[]{ 2, 3, 0.5 });

			Vector<double> outputs = (weights * inputs) + biases;

			Console.WriteLine(outputs.ToString());
		}
	}
}