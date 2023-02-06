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


			LayerDense l1 = new LayerDense(4,5);
			LayerDense l2 = new LayerDense(5,2);
			l1.Forward(X);
			l2.Forward(l1.outputs);

			//Console.WriteLine(l1.outputs.ToString());
			Console.WriteLine(l2.outputs.ToString());
		}
	}
}