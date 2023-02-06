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
			Output = input.PointwiseMaximum(0);
			return Output;
		}
	}
}
