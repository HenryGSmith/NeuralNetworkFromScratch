namespace NeuralNetworkFromScratch
{
	internal class Program
	{
		static void Main(string[] args)
		{
			TestNeurone neurone = new TestNeurone();
			Console.WriteLine(neurone.Output());
		}
	}
}