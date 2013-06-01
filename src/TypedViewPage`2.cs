using System;
using System.Web;
using System.Web.Mvc;
using JetBrains.Annotations;

namespace Arraybracket.TypedViews {
	public abstract class TypedViewPage<TViewModel, TModel> : WebViewPage<TModel> {
		static TypedViewPage() {
			if (typeof(TViewModel) == typeof(object))
				throw new InvalidOperationException("You must explicitly specify TViewModel when creating a typed view. Use an @model declaration to set the view-model type. Note that TViewModel cannot be object or dynamic.");
		}

		private TViewModel _ViewModel;

		public override void InitHelpers() {
			base.InitHelpers();

			if (this.ViewBag.ViewModel == null)
				throw new InvalidOperationException("You must specify ViewModel when rendering a typed view. Derive your controllers from TypedController and use an overload of View() that accepts a viewModel parameter.");
			if (!(this.ViewBag.ViewModel is TViewModel))
				throw new InvalidOperationException(string.Format("The specified ViewModel value is of type '{0}' and must be of type '{1}'.", this.ViewBag.ViewModel.GetType(), typeof(TViewModel)));
			this._ViewModel = this.ViewBag.ViewModel;
		}

		[NotNull]
		public TViewModel ViewModel {
			get { return this._ViewModel; }
		}

		public IHtmlString SetLayout([PathReference] string layout, [AspMvcModelType, NotNull] object layoutModel) {
			if (layoutModel == null)
				throw new ArgumentNullException("layoutModel");
			this.ViewBag.LayoutModel = layoutModel;
			base.Layout = layout;

			return null;
		}

		[Obsolete("You cannot use the Layout property when rendering a typed view. Use the SetLayout() method instead.", true)]
		public new string Layout {
			get { throw new InvalidOperationException("You cannot use the Layout property when rendering a typed view. Use the SetLayout() method instead."); }
			set { throw new InvalidOperationException("You cannot use the Layout property when rendering a typed view. Use the SetLayout() method instead."); }
		}
	}
}