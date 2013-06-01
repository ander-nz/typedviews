using System;
using System.Web.Mvc;
using JetBrains.Annotations;

namespace Arraybracket.TypedViews {
	public abstract class TypedController : Controller {
		public new ViewResult View([NotNull] object viewModel) {
			this._SetViewModel(viewModel);
			return base.View();
		}

		public ViewResult View([NotNull] object viewModel, [AspMvcModelType, CanBeNull] object model) {
			this._SetViewModel(viewModel);
			return base.View(model);
		}

		public new ViewResult View([AspMvcView] string viewName, [NotNull] object viewModel) {
			this._SetViewModel(viewModel);
			return base.View(viewName);
		}

		public ViewResult View([AspMvcView] string viewName, [NotNull] object viewModel, [AspMvcModelType, CanBeNull] object model) {
			this._SetViewModel(viewModel);
			return base.View(viewName, model);
		}

		private void _SetViewModel([NotNull] object viewModel) {
			if (viewModel == null)
				throw new ArgumentNullException("viewModel");
			this.ViewBag.ViewModel = viewModel;
		}

		[Obsolete("You must specify viewModel when rendering a typed view. Use an overload of View() that accepts a viewModel parameter.", true)]
		public new ViewResult View() {
			throw new InvalidOperationException("You must specify viewModel when rendering a typed view. Use an overload of View() that accepts a viewModel parameter.");
		}

		[Obsolete("You must specify viewModel when rendering a typed view. Use an overload of View() that accepts a viewModel parameter.", true)]
		public new ViewResult View(string viewName) {
			throw new InvalidOperationException("You must specify viewModel when rendering a typed view. Use an overload of View() that accepts a viewModel parameter.");
		}

		[Obsolete("You cannot specify masterName when rendering a typed view. Use SetLayout() within the typed view.", true)]
		public new ViewResult View(string viewName, string masterName) {
			throw new InvalidOperationException("You cannot specify masterName when rendering a typed view. Use SetLayout() within the typed view.");
		}

		[Obsolete("You cannot specify masterName when rendering a typed view. Use SetLayout() within the typed view.", true)]
		public new ViewResult View(string viewName, string masterName, object model) {
			throw new InvalidOperationException("You cannot specify masterName when rendering a typed view. Use SetLayout() within the typed view.");
		}
	}
}