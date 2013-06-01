using System;

namespace Arraybracket.TypedViews.Sample.Views.General {
	public sealed class SupportUnpostedViewModel {
		public RecipientOption[] RecipientOptions { get; set; }

		public sealed class RecipientOption {
			public Guid Id { get; set; }
			public string Description { get; set; }
		}
	}
}