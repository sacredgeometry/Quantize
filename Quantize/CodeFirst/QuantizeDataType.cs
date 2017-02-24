using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Felinesoft.UmbracoCodeFirst.DataTypes;
using Felinesoft.UmbracoCodeFirst.Attributes;
using Newtonsoft.Json;

namespace UmbracoPlugins.App_Plugins.Quantize.CodeFirst
{
	[DataType("BJW.Quantize", "Quantize")]
	public class QuantizeDataType : IUmbracoNtextDataType
	{
		public dynamic Value { get; set; }

		public void Initialise(string dbValue)
		{
			if (!string.IsNullOrWhiteSpace(dbValue))
			{
				Value = JsonConvert.DeserializeObject(dbValue);
			}
		}

		public string Serialise()
		{
			return JsonConvert.SerializeObject(Value);
		}
	}
}