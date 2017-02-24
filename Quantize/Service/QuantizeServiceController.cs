using BJW.Quantize.Storage;
using BJW.Quantize.Storage.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Umbraco.Web;
using Umbraco.Web.Editors;
using Umbraco.Web.Mvc;
using Umbraco.Web.WebApi;

namespace BJW.Quantize.Service
{
	[PluginController("BJW")]
	public class QuantizeServiceController : UmbracoAuthorizedJsonController
	{
		/// <summary>
		/// Takes Preset Id and returns the Json value data
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet]
		public string GetPresetJsonDataFromId(int id)
		{
			return Presets.GetPreset(id).Value;
		}

		/// <summary>
		/// Get All Presets
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IEnumerable<Preset> GetPresets()
		{
			return Presets.GetPresets() ?? new List<Preset>();
		}

		[HttpPost]
		public Preset AddPreset(string name, string value)
		{
			return Presets.CreatePreset(name, value);
		}


		//public object LoadCurrentPresetForProperty(int id, string alias, string value)
		//{
		//	var umbHelper = new UmbracoHelper(UmbracoContext.Current);

		//	var content = umbHelper.TypedContent(id);
		//	var propertyData = content?.GetPropertyValue<string>(alias);

		//	ApplicationContext.Services.ContentService.GetById(id).SetValue(alias, value);


		//	return new { status = "Sucessful" };
		//}	
	}
}	