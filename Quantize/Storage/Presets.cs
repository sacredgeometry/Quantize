using System;
using Umbraco.Core;
using Umbraco.Core.Persistence;
using BJW.Quantize.Pocos;

namespace BJW.Quantize.Storage
{
   public class Presets
   {
       public static Preset CreatePreset(string name, string val)
       {
           var db = ApplicationContext.Current.DatabaseContext.Database;
 
           var preset = new Preset
           {
               Name = name,
               Value = val
           };
 
           db.Insert(Preset);
 
           return preset;
       }
 
       public static Preset GetPreset(int id)
       {
           var db = ApplicationContext.Current.DatabaseContext.Database;
 
           var preset = db.SingleOrDefault(id);
 
           return preset;
       }
   }
}