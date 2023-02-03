namespace NeuralNetworkFromScratch
{
	internal class Program
	{
		static void Main(string[] args)
		{
			double[] inputs = { 1, 2, 3, 2.5 };
			double[] weights1 = { 0.2, 0.8, -0.5, 1.0 };
			double[] weights2 = { 0.5, -0.91, 0.26, -0.5 };
			double[] weights3 = { -0.26, -0.27, 0.17, 0.87 };
			double bias1 = 2;
			double bias2 = 3;
			double bias3 = 0.5;

			TestNeurone neurone1 = new TestNeurone(inputs, weights1, bias1);
			TestNeurone neurone2 = new TestNeurone(inputs, weights2, bias2);
			TestNeurone neurone3 = new TestNeurone(inputs, weights3, bias3);


			double[] output = { neurone1.Output(), neurone2.Output(), neurone3.Output() };
			foreach (double o in output) 
			{
				Console.WriteLine(o);
			}
		}
	}
}