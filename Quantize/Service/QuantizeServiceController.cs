using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web;
using Umbraco.Web.Mvc;
using Umbraco.Web.WebApi;

namespace UmbracoPlugins.App_Plugins.Quantize.Service
{
	[PluginController("BJW")]
	public class QuantizeServiceController : UmbracoApiController
	{
		public string GetCurrentJsonDataForProperty(int id, string alias)
		{
			var output = string.Empty;

			var umbHelper = new UmbracoHelper(UmbracoContext.Current);

			var content = umbHelper.TypedContent(id);
			var propertyData = content?.GetPropertyValue<string>(alias);
			
			return propertyData;
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