<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/968640557/25.1.0%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1296766)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# DevExpress Blazor Grid - Customize Group Summaries

The [DevExpress Blazor Grid](https://docs.devexpress.com/Blazor/403143/components/grid) can calculate [group summary](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxGrid.GroupSummary) values across all records in a group. You can use the [DataColumnGroupRowTemplate](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxGrid.DataColumnGroupRowTemplate) property to specify custom content and appearance for summary rows.

![Custom Group Summaries](images/blazor-grid-summaries.png)

## Implementation Details

The [GroupRowContent.razor](CS/GroupSummaries/Components/GroupRowContent.razor) custom Razor component defines the template used for both group row content and group summaries aligned with their respective columns. Its internal structure is built with a standard HTML table layout.

This template is included with our Blazor Grid (DxGrid) component through the [DataColumnGroupRowTemplate](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxGrid.DataColumnGroupRowTemplate) property. Row data is passed through the [Context](https://docs.devexpress.com/Blazor/DevExpress.Blazor.GridDataColumnGroupRowTemplateContext) property to the `GroupRowContent` custom component. Row context allows you to access a Grid's instance. We use it to render the required column structure within the HTML table element, the group row, and group summary values. Visual styles for these elements are defined in the accompanying [GroupRowContent.razor.css](CS/GroupSummaries/Components/GroupRowContent.razor.css) stylesheet.

```razor
<DataColumnGroupRowTemplate>
    <GroupRowContent Context="context"></GroupRowContent>
</DataColumnGroupRowTemplate>
```

The `InitializeSummaryTable` JavaScript function synchronizes template column width with individual Grid columns. It also attaches a [ResizeObserver](https://developer.mozilla.org/en-US/docs/Web/API/ResizeObserver) to the Grid to automatically update table column width whenever the Grid is resized. JavaScript functions are defined in the [root component](CS/GroupSummaries/Components/App.razor). They are invoked from the page's `OnAfterRender` lifecycle event using Blazor [JS Interop](https://learn.microsoft.com/en-us/aspnet/core/blazor/javascript-interoperability/call-javascript-from-dotnet).

```cs
protected override async Task OnAfterRenderAsync(bool firstRender)
{
    await JS.InvokeVoidAsync("InitializeSummaryTable", ".myGrid");
}
```

Our Blazor Grid’s [LayoutAutoSaving](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxGrid.LayoutAutoSaving) event is used to handle Grid layout changes.

```cs
async Task OnLayoutAutoSaving(GridPersistentLayoutEventArgs e)
{
    stateService.GridLayoutChanged = true;
}
```

When the event fires, the custom component invokes the `AdjustSummaryTable` JavaScript function to ensure group row display is updated correctly.

## Files to Review

- [Index.razor](CS/GroupSummaries/Components/Pages/Index.razor)
- [GroupRowContent.razor](CS/GroupSummaries/Components/GroupRowContent.razor)
- [GroupRowContent.razor.css](CS/GroupSummaries/Components/GroupRowContent.razor.css)
- [App.razor](CS/GroupSummaries/Components/App.razor)

## Documentation

- [DxGrid Component](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxGrid)
- [DxGrid.GroupSummary Property](https://github.com/DevExpress-Examples/blazor-DxGrid-Detail-Information-DxFormLayout)
- [DxGrid.DataColumnGroupRowTemplate Property](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxGrid.DataColumnGroupRowTemplate)
- [GridDataColumnGroupRowTemplateContext Class](https://docs.devexpress.com/Blazor/DevExpress.Blazor.GridDataColumnGroupRowTemplateContext)
- [DxGrid.LayoutAutoSaving Event](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxGrid.LayoutAutoSaving)

## More Examples

- [Grid for Blazor - Customize cell appearance based on custom conditions](https://github.com/DevExpress-Examples/blazor-dxgrid-conditional-formatting)
- [Blazor Grid - How to display detail information using DxFormLayout](https://github.com/DevExpress-Examples/blazor-DxGrid-Detail-Information-DxFormLayout)

<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=blazor-grid-customize-group-summaries&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=blazor-grid-customize-group-summaries&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
