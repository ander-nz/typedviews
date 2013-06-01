using System;
using System.Web.Mvc;
using JetBrains.Annotations;

namespace Arraybracket.TypedViews {
	public abstract class TypedLayoutPage<TLayoutModel> : WebViewPage {
		private TLayoutModel _LayoutModel;

		public override void InitHelpers() {
			base.InitHelpers();

			if (this.ViewBag.LayoutModel == null)
				throw new InvalidOperationException("You must specify LayoutModel when rendering a typed layout. Use the SetLayout() method from within your view.");
			if (!(this.ViewBag.LayoutModel is TLayoutModel))
				throw new InvalidOperationException(string.Format("The specified LayoutModel value is of type '{0}' and must be of type '{1}'.", this.ViewBag.LayoutModel.GetType(), typeof(TLayoutModel)));
			this._LayoutModel = this.ViewBag.LayoutModel;
		}

		[NotNull]
		public TLayoutModel LayoutModel {
			get { return this._LayoutModel; }
		}

		public void SetLayout([PathReference] string layout, [NotNull] object layoutModel) {
			if (layoutModel == null)
				throw new ArgumentNullException("layoutModel");
			this.ViewBag.LayoutModel = layoutModel;
			base.Layout = layout;
		}

		[Obsolete("You cannot use the Layout property when rendering a typed layout. Use the SetLayout() method instead.", true)]
		public new string Layout {
			get { throw new InvalidOperationException("You cannot use the Layout property when rendering a typed layout. Use the SetLayout() method instead."); }
			set { throw new InvalidOperationException("You cannot use the Layout property when rendering a typed layout. Use the SetLayout() method instead."); }
		}
	}
}