using System;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;

namespace BJW.Quantize.Storage.Pocos
{
    [TableName("BJW.Quantize.Presets")]
    [PrimaryKey("Id", autoIncrement = true)]
    public class Preset
    {
        [Column("id")]
        [PrimaryKeyColumn(AutoIncrement = true)]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Value")]
        public string Value { get; set; }
    }
}