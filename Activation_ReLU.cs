using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkFromScratch
{
	internal class Activation_ReLU
	{
		public Matrix<double>? Output { get; private set; }

		public Matrix<double> Forward(Matrix<double> input)
		{
			Output = Matrix<double>.Build.Dense(input.ColumnCount, input.RowCount);

			for(int i = 0; i < input.RowCount; i++)
			{
				for(int j = 0; j < input.ColumnCount; j++)
				{
					Output[j,i] = (input[i,j] > 0)? input[i,j]: 0;
				}
			}

			return Output;
		}
	}
}
