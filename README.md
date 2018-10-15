# No longer maintained!
This repository exists only as a reference.

Arraybracket.TypedViews
=======================

<b>Arraybracket.TypedViews</b> adds a <code>ViewModel</code> property to your MVC/Razor views, as a strongly-typed replacement for <code>ViewBag</code> and <code>Page</code>.

Normally, in an MVC/Razor view, you use the <code>@model</code> construct to specify a strongly-typed model. However, this works best for form data that gets posted back to the controller. This library changes the behavior of <code>@model</code> so that you can specify both a view model type and a model type.

This results in an improved design-time experience - since there is no intellisense for <code>ViewBag</code> - in both the controller and the view. It also results in improved refactoring support and error-checking.

Example: a typed view with a model
----------------------------------

```
@model ContactUsViewModel, ContactUsModel

@using (Html.BeginForm()) {
	<label>Department:</label>
	@Html.DropDownListFor(m => m.Department, ViewModel.DepartmentOptions)
}
```

Example: a typed view without a model
-------------------------------------

```
@model HomeViewModel

<div class="featured">
	<h3>@ViewModel.Featured.Title</h3>
	<p>@ViewModel.Featured.Description</p>
</div>
```

Usage
=====

From your web project, add a NuGet package reference by running:

```
Install-Package Arraybracket.TypedViews
```

This should modify your web.config specifying that the base type for views is <code>TypedViewPage</code>, instead of the normal <code>WebViewPage</code>. Then, when creating a controller, ensure it derives from <code>TypedController</code> and uses the new overloads of <code>View()</code>:

```csharp
public sealed class GeneralController : TypedController {
	public ActionResult ContactUs() {
		var viewModel = new ContactUsViewModel {
			DepartmentOptions = this._LoadDepartmentOptions(),
		};

		var model = new ContactUsModel {
			Department = this._GetDefaultDepartmentId(),
		};

		return this.View("ContactUs", viewModel, model);
	}
}
```

Layouts
=======

Layout pages have a similar <code>LayoutModel</code> property, which must be specified using an <code>@inherits</code> construct. You can use <code>SetLayout</code> from the view to specify the layout path and the layout model to use.

Example: declaring a layout
---------------------------

```
@inherits TypedLayoutPage<LayoutModel>

@helper NavItem(LayoutNav nav, string url, string text) {
	<a href="@url" class="(LayoutModel.SelectedNav == nav ? "selected" : null)">@text</a>
}

<title>@LayoutModel.Title</title>
@NavItem(LayoutNav.Home, "/", "Home")
```

Example: using a layout
-----------------------

```
@model HomeViewModel

@this.SetLayout("~/Views/Shared/Layout.cshtml", new LayoutModel {
	Title = "Welcome",
	SelectedNav = LayoutNav.Home,
})
```
