using System;
using SQLite;
namespace FropCorn.Model
{
	public abstract class BaseModel
	{

		[PrimaryKey, AutoIncrement]
		public int RowID { get; set;}

		public DateTime CreatedOn { get; set; }

	}
}

