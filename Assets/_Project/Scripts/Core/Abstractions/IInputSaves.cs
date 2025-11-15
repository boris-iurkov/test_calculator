namespace Calculator.Core.Abstractions
{
	public interface IInputSaves
	{
		string LoadInput();
		void SaveInput(string input);
	}
}