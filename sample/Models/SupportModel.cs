using System;
using System.ComponentModel.DataAnnotations;

namespace Arraybracket.TypedViews.Sample.Models {
	public sealed class SupportModel {
		[Required(ErrorMessage = "Required"), StringLength(100, ErrorMessage = "Must be no more than 100 characters")]
		public string From { get; set; }

		[Required(ErrorMessage = "Required")]
		public Guid? Recipient { get; set; }

		[Required(ErrorMessage = "Required"), StringLength(1000, ErrorMessage = "Must be no more than 1000 characters")]
		public string Message { get; set; }
	}
}