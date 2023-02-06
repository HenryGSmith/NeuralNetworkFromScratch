using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace NeuralNetworkFromScratch
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// training data set
			Matrix<double> X = DenseMatrix.OfArray(new double[,]
								{{  1.00,  2.00,  3.00,  2.50 },
								 {  2.00,  5.00, -1.00,  2.00 },
								 { -1.50,  2.70,  3.30, -0.80 }});


			Matrix<double> inputs = Matrix<double>.Build.DenseOfArray(
				new double[,] { { 0, 2, -1, 3.3, -2.7, 1.1, 2.2, -100 } });
			Activation_ReLU reLU = new Activation_ReLU();
			reLU.Forward(inputs);
			Console.Write(reLU.Output.ToString());

			/*
			LayerDense l1 = new LayerDense(4,5);
			LayerDense l2 = new LayerDense(5,2);
			l1.Forward(X);
			l2.Forward(l1.Outputs);

			Console.WriteLine(l2.Outputs.ToString());*/
		}
	}
}