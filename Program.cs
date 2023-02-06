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


			Matrix<double> inputs = spiral_data(100, 3);
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

		// standin dataset
		static Matrix<double> spiral_data(int points, int classes)
		{
			//Matrix<double> X;
			//Vector<double> y;
			var M = Matrix<double>.Build; //shortcut to Matrix builder
			var V = Vector<double>.Build; //shortcut to Vector builder

			//build vectors of size points*classesx1 for y, r and theta
			var y = V.Dense(points * classes); //at this point this is full of zeros
			for (int j = 0; j < classes; j++)
			{
				var y_step = V.DenseOfArray(Generate.Step(points * classes, 1, (j + 1) * points));
				y = y + y_step;
			}
			var r = V.DenseOfArray(Generate.Sawtooth(points * classes, points, 0, 1));
			var theta = 4 * (r + y) + (V.DenseOfArray(Generate.Standard(points * classes)) * 0.2);
			var sin_theta = theta.PointwiseSin();
			var cos_theta = theta.PointwiseCos();

			var X = M.DenseOfColumnVectors(r.PointwiseMultiply(sin_theta), r.PointwiseMultiply(cos_theta));
			return X;
		}
	}
}