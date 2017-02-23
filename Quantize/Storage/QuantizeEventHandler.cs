using Umbraco.Core;
using Umbraco.Core.Persistence;
 
namespace BJW.Quantize.Storage
{
   public class QuantizeEventHandler : ApplicationEventHandler
   {
       protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
       {
           var db = applicationContext.DatabaseContext.Database;
 
           if (!db.TableExist("BJW.Quantize.Presets"))
           {
               db.CreateTable<Preset>(false);
           }
       }
   }
}