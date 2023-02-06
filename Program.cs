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


			double[] inputs = { 0, 2, -1, 3.3, -2.7, 1.1, 2.2, -100 };
			double[] outputs = new double[inputs.Length];

			// ReLU activation
			for (int i = 0; i < inputs.Length; i++)
			{
				if (inputs[i] > 0)
				{
					outputs[i] = inputs[i];
				}
				else
				{
					outputs[i] = 0;
				}
			}

			/*
			LayerDense l1 = new LayerDense(4,5);
			LayerDense l2 = new LayerDense(5,2);
			l1.Forward(X);
			l2.Forward(l1.outputs);

			Console.WriteLine(l2.outputs.ToString());*/
		}
	}
}