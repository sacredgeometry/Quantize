using System;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;

namespace BJW.Quantize.Storage.Pocos
{
    [TableName(TABLE_NAME)]
    [PrimaryKey("Id", autoIncrement = true)]
    public class Preset
    {
		public const string TABLE_NAME = "QuantizePresets";

        [Column("id")]
        [PrimaryKeyColumn(AutoIncrement = true)]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Value")]
		[SpecialDbType(SpecialDbTypes.NTEXT)]
        public string Value { get; set; }
    }
}