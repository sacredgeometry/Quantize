using Umbraco.Core;
using Umbraco.Core.Persistence;
using BJW.Quantize.Storage.Pocos;

namespace BJW.Quantize.Storage
{
   public class QuantizeEventHandler : ApplicationEventHandler
   {
       protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
       {
           var dbCtx = applicationContext.DatabaseContext;
			var dbHelper = new DatabaseSchemaHelper(dbCtx.Database, applicationContext.ProfilingLogger.Logger, dbCtx.SqlSyntax);

           if (!dbHelper.TableExist("Quantize.Presets"))
           {
				dbHelper.CreateTable<Preset>(false);
           }
       }
   }
}