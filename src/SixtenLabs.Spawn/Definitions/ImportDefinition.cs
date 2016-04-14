using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixtenLabs.Spawn
{
	public class ImportDefinition : TypeDefinition
	{
		public ImportDefinition()
		{
		}

		public void AddSuccessCodes(string successCodes)
		{
			var codes = successCodes.Split(',');

			foreach(var code in codes)
			{
				SuccessCodes.Add(code);
			}
		}

		public void AddErrorCodes(string errorCodes)
		{
			var codes = errorCodes.Split(',');

			foreach (var code in codes)
			{
				ErrorCodes.Add(code);
			}
		}

		public string Value { get; }

		public IList<ParameterDefinition> Parameters { get; } = new List<ParameterDefinition>();

		public IList<string> Validity { get; } = new List<string>();

		public IList<string> SuccessCodes { get; } = new List<string>();

		public IList<string> ErrorCodes { get; } = new List<string>();
	}
}
