using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System.Xml;

namespace NeuralNetworkFromScratch
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Vector<double> y;
			Matrix<double> X = SpiralData(100, 3, out y);

			LayerDense dense1 = new(2, 3);
			Activation_ReLU a1 = new();

			LayerDense dense2 = new(3, 3);
			Activation_SoftMax a2 = new();

			dense1.Forward(X);
			a1.Forward(dense1.Output);
			dense2.Forward(a1.Output);
			a2.Forward(dense2.Output);
			
			Console.WriteLine(a2.Output.ToString());

			Loss_CategoricalCrossentropy lossFunc = new();
			double loss = lossFunc.Calculate(a2.Output, y);
			Console.WriteLine(loss);
		}

		// standin dataset
		static Matrix<double> SpiralData(int points, int classes, out Vector<double> y)
		{
			//Matrix<double> X;
			//Vector<double> y;
			var M = Matrix<double>.Build; //shortcut to Matrix builder
			var V = Vector<double>.Build; //shortcut to Vector builder

			//build vectors of size points*classesx1 for y, r and theta
			y = V.Dense(points * classes); //at this point this is full of zeros
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