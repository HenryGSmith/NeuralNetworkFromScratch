using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace NeuralNetworkFromScratch
{
	internal class LayerDense
	{
		Matrix<double> weights;
		double[] biases;
		int nNeurons;

		public Matrix<double> outputs { get; private set; }

		MatrixBuilder<double> M = Matrix<double>.Build;

		public LayerDense(int nInputs, int nNeurons) 
		{
			weights = M.Random(nInputs, nNeurons) * 0.10;
			biases = new double[nNeurons];
			this.nNeurons = nNeurons;
		}

		public Matrix<double> Forward(Matrix<double> inputs)
		{
			Matrix<double> bias = M.Dense(inputs.RowCount, nNeurons, (i, j) => biases[j]);
			outputs = (inputs * weights) + bias;
			return outputs;
		}
	}
}
