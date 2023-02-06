using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace NeuralNetworkFromScratch
{
	internal class LayerDense
	{
		public Matrix<double> weights { get; set; }
		public Matrix<double> biases { get; set; }
		public Matrix<double>? Output { get; private set; }
		
		private MatrixBuilder<double> M = Matrix<double>.Build;

		public LayerDense(int nInputs, int nNeurons) 
		{
			weights = M.Random(nInputs, nNeurons) * 0.10;
			biases = M.Dense(1, nNeurons);
		}

		public Matrix<double> Forward(Matrix<double> inputs)
		{ 
			Matrix<double> v = M.Dense(inputs.RowCount, 1, 1.0);
			Matrix<double> biasMat = v * biases;

			Output = inputs * weights + biasMat;
			return Output;
		}
	}
}
