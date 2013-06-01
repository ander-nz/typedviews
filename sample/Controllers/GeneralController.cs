using System;
using System.Linq;
using System.Web.Mvc;
using Arraybracket.TypedViews.Sample.Models;
using Arraybracket.TypedViews.Sample.Views.General;

namespace Arraybracket.TypedViews.Sample.Controllers {
	public sealed class GeneralController : TypedController {
		private static readonly SupportUnpostedViewModel.RecipientOption[] _RecipientOptions = new[] {
			new SupportUnpostedViewModel.RecipientOption { Id = new Guid("CF527FAA-A5F4-40E0-8939-55DE39D7856F"), Description = "Technical Support" }, new SupportUnpostedViewModel.RecipientOption { Id = new Guid("3302DDAA-2303-42CB-97C1-61E937DDDE2E"), Description = "Business Support" },
		};

		public ActionResult Home() {
			return this.View(new HomeViewModel {
				FeaturedTitle = "This is the featured product", FeaturedDescription = "The featured product is loaded from the database and is passed to the view using ViewModel. ViewModel works as a view-specific, strongly-typed replacement to ViewBag, and is separate to Model. Model works best if it's used exclusively for a form, i.e. for posted data.",
			});
		}

		public ActionResult About() {
			return this.View(new AboutViewModel());
		}

		public ActionResult Support() {
			return this._SupportUnpostedView(null);
		}

		[HttpPost]
		public ActionResult Support(SupportModel model) {
			if (model.Recipient != null && !_RecipientOptions.Any(o => o.Id == model.Recipient))
				ModelState.AddModelError("Recipient", "Must be a valid option");
			if (!ModelState.IsValid)
				return this._SupportUnpostedView(model);
			return this.View("SupportPosted", new SupportPostedViewModel());
		}

		private ActionResult _SupportUnpostedView(SupportModel model) {
			return this.View("SupportUnposted", new SupportUnpostedViewModel { RecipientOptions = _RecipientOptions }, model);
		}
	}
}