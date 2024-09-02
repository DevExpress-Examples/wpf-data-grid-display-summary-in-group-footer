<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128647637/24.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4626)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# WPF Data Grid - Display Data Summaries in Group Footers

This example demonstrates how to display data summaries in [group footers](https://docs.devexpress.com/WPF/16114/controls-and-libraries/data-grid/visual-elements/common-elements/group-footer).

![WPF Data Grid - Display Data Summaries in Group Footers, DevExpress](https://raw.githubusercontent.com/DevExpress-Examples/dxgrid-how-to-show-group-summaries-in-a-group-footer-e4626/22.2.2%2B/i/wpf-data-grid-group-footer-devexpress.png)

## Implementation

1. Enable the [TableView.ShowGroupFooters](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.TableView.ShowGroupFooters) option.
2. Specify a column that displays the summary. Use the [GridSummaryItem.ShowInGroupColumnFooter](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridSummaryItem.ShowInGroupColumnFooter) property to specify the field name of the column.

```xaml
<dxg:GridControl x:Name="grid" ItemsSource="{Binding}">
    <dxg:GridControl.Columns>
        <dxg:GridColumn FieldName="Text"/>
        <dxg:GridColumn FieldName="Number0"/>
        <dxg:GridColumn FieldName="Number1"/>
        <dxg:GridColumn FieldName="Number2" Fixed="Left"/>
        <dxg:GridColumn FieldName="Group" GroupIndex="0"/>
    </dxg:GridControl.Columns>
    <dxg:GridControl.View>
        <dxg:TableView ShowGroupFooters="True" GroupSummaryDisplayMode="AlignByColumns"/>
    </dxg:GridControl.View>
    <dxg:GridControl.GroupSummary>
        <dxg:GridSummaryItem FieldName="Text" SummaryType="Count" ShowInGroupColumnFooter="Text"/>
        <dxg:GridSummaryItem FieldName="Number0" SummaryType="Sum" ShowInGroupColumnFooter="Number0"/>
        <dxg:GridSummaryItem FieldName="Number1" SummaryType="Sum" ShowInGroupColumnFooter="Number1"/>
        <dxg:GridSummaryItem FieldName="Number2" SummaryType="Max" ShowInGroupColumnFooter="Number2"/>
    </dxg:GridControl.GroupSummary>
</dxg:GridControl>
```

## Files to Review

* [MainWindow.xaml](./CS/GroupFootersWPF/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/GroupFootersWPF/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/GroupFootersWPF/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/GroupFootersWPF/MainWindow.xaml.vb))


## Documentation

* [Group Summary](https://docs.devexpress.com/WPF/6127/controls-and-libraries/data-grid/data-summaries/group-summary)
* [Data Summaries](https://docs.devexpress.com/WPF/7354/controls-and-libraries/data-grid/data-summaries)


<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-data-grid-display-summary-in-group-footer&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-data-grid-display-summary-in-group-footer&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
