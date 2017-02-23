using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web;
using Umbraco.Web.Mvc;
using Umbraco.Web.WebApi;

namespace BJW.Quantize.Service
{
	[PluginController("BJW")]
	public class QuantizeServiceController : UmbracoApiController
	{
		public string GetCurrentJsonDataForProperty(int id)
		{
			
			
			return "";
		}

		public object LoadCurrentPresetForProperty(int id, string alias, string value)
		{
			var umbHelper = new UmbracoHelper(UmbracoContext.Current);

			var content = umbHelper.TypedContent(id);
			var propertyData = content?.GetPropertyValue<string>(alias);

			ApplicationContext.Services.ContentService.GetById(id).SetValue(alias, value);


			return new { status = "Sucessful" };
		}	
	}
}	