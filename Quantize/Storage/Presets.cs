using System;
using Umbraco.Core;
using Umbraco.Core.Persistence;
using BJW.Quantize.Storage.Pocos;
using System.Collections.Generic;

namespace BJW.Quantize.Storage
{
   public class Presets
   {
		public static Preset CreatePreset(string name, string val)
       {
			var db = ApplicationContext.Current.DatabaseContext.Database;
			var output = db.Insert(new Preset { Name = name, Value = val });

			return output as Preset;
       }
 
       public static Preset GetPreset(int id)
       {
           var db = ApplicationContext.Current.DatabaseContext.Database;
 
           var preset = db.SingleOrDefault<Preset>(id);
 
           return null;
       }

		public static IEnumerable<Preset> GetPresets()
		{
			var db = ApplicationContext.Current.DatabaseContext.Database;
			return  db.Query<Preset>($"SELECT * FROM {Preset.TABLE_NAME}");
		}
	}
}