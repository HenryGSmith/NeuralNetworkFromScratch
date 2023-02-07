using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkFromScratch
{
	internal class Activation_SoftMax
	{
		public Matrix<double>? Output { get; private set; }

		private readonly MatrixBuilder<double> M = Matrix<double>.Build;

		public Matrix<double> Forward(Matrix<double> input)
		{
			for (int i = 0; i < input.RowCount; i++)
			{
				Vector<double> row = input.Row(i) - input.Row(i).Max();
				input.SetRow(i, row);
			}

			Matrix<double> expValues = input.PointwiseExp();
			Output = M.Dense(expValues.RowCount, expValues.ColumnCount);

			for (int i = 0; i < expValues.RowCount; i++)
			{
				double normBase = expValues.RowSums()[i];
				Vector<double> row = expValues.Row(i);
				row /= normBase;
				Output.SetRow(i, row);
			}

			return Output;
		}
	}
}
