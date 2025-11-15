namespace Calculator.Core.Data
{
	public readonly struct Expression
	{
		public string Raw { get; }

		public Expression(string raw)
		{
			Raw = raw;
		}
	}
}