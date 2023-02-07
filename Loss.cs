using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NeuralNetworkFromScratch
{
	internal abstract class Loss
	{

		public double Calculate(Matrix<double> output, Matrix<double> y)
		{
			Matrix<double> sample_losses = this.Forward(output, y);
			double batchLoss = sample_losses.RowSums().Sum() / (sample_losses.ColumnCount * sample_losses.RowCount);
			return batchLoss;
		}

		public double Calculate(Matrix<double> output, Vector<double> y)
		{
			Matrix<double> sample_losses = this.Forward(output, y);
			double batchLoss = sample_losses.RowSums().Sum() / (sample_losses.ColumnCount * sample_losses.RowCount);
			return batchLoss;
		}

		public abstract Matrix<double> Forward(Matrix<double> yPred, Vector<double> yTrue);

		public abstract Matrix<double> Forward(Matrix<double> yPred, Matrix<double> yTrue);
	}

	internal class Loss_CategoricalCrossentropy : Loss
	{
		private readonly MatrixBuilder<double> M = Matrix<double>.Build;

		public override Matrix<double> Forward(Matrix<double> yPred, Vector<double> yTrue)
		{
			for(int j = 0; j < yPred.RowCount; j++)
			{
				for(int i = 0; i < yPred.ColumnCount; i++)
				{
					yPred[j, i] = Clip(yPred[j, i]);
				}
			}

			Vector<double> correctConfidences = Vector<double>.Build.DenseOfVector(yTrue);
			for (int i = 0; i < yTrue.Count; i++)
			{
				correctConfidences[i] = yPred[i, (int)yTrue[i]];
			}
			
			return M.DenseOfRowVectors(-correctConfidences.PointwiseLog());
		}

		public override Matrix<double> Forward(Matrix<double> yPred, Matrix<double> yTrue)
		{
			for (int j = 0; j < yPred.RowCount; j++)
			{
				for (int i = 0; i < yPred.ColumnCount; i++)
				{
					yPred[j, i] = Clip(yPred[j, i]);
				}
			}

			Matrix<double> correctConfidences = M.DenseOfRowVectors((yPred * yTrue).RowSums()); 
			return -correctConfidences.PointwiseLog();
		}

		private static double Clip(double x)
		{
			if (x > 1)
			{
				return 1 - 1e-7;
			}
			else if (x < 0)
			{
				return 1e-7;
			}

			return x;
		}
	}
}
