using System;

namespace Arraybracket.TypedViews {
	public abstract class TypedViewPage<TViewModel> : TypedViewPage<TViewModel, object> {
		[Obsolete("You must explicitly specify both TViewModel and TModel to use the Model property. Use an @model declaration to specify both the view-model and model types.", true)]
		public new object Model {
			get { throw new InvalidOperationException("You must explicitly specify both TViewModel and TModel to use the Model property. Use an @model declaration to specify both the view-model and model types."); }
			set { throw new InvalidOperationException("You must explicitly specify both TViewModel and TModel to use the Model property. Use an @model declaration to specify both the view-model and model types."); }
		}
	}
}