namespace NeuralNetworkFromScratch
{
	internal class Program
	{
		static void Main(string[] args)
		{
			double[] inputs = { 1, 2, 3, 2.5 };
			double[,] weights = {{  0.20,  0.80, -0.50,  1.00 }, 
								 {  0.50, -0.91,  0.26, -0.50 }, 
								 { -0.26, -0.27,  0.17,  0.87 }};
			double[] biases = { 2, 3, 0.5 };

			TestNeurone neurone1 = new TestNeurone(inputs, weights, biases[0]);
			TestNeurone neurone2 = new TestNeurone(inputs, weights, biases[1]);
			TestNeurone neurone3 = new TestNeurone(inputs, weights, biases[2]);


			double[] output = { neurone1.Output(), neurone2.Output(), neurone3.Output() };
			foreach (double o in output) 
			{
				Console.WriteLine(o);
			}

			double[,] d = new double[,] { { 1, 1, 1 }, { 2, 2, 2 } };
			double[,] d2 = new double[,] { { 1, 1 }, { 2, 2 }, { 3, 3 } };
			Utils.Matrix A = new Utils.Matrix(d);
			Utils.Matrix B = new Utils.Matrix(d2);
			A.Show();
			B.Show();
			A.Mul(B).Show();
		}
	}
}