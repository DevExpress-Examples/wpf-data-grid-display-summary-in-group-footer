<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128647637/13.2.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4626)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [MainWindow.xaml](./CS/GroupFootersWPF/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/GroupFootersWPF/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/GroupFootersWPF/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/GroupFootersWPF/MainWindow.xaml.vb))
<!-- default file list end -->
# DXGrid - How to show group summaries in a group footer


<p>Starting with version 13.2, group footers are supported out of the box. To display summaries in group footers, set the <a href="https://documentation.devexpress.com/#WPF/DevExpressXpfGridTableView_ShowGroupFooterstopic">TableView.ShowGroupFooters</a> property to true and specify the field where the summary should be displayed using the <a href="https://documentation.devexpress.com/#WPF/DevExpressXpfGridGridSummaryItem_ShowInGroupColumnFootertopic">GridSummaryItem.ShowInGroupColumnFooter</a> property.<br /><br />The text below describes a custom solution that can be used in versions prior to 13.2.<br /><br /><em>This example demonstrates how to create group footers in the grid and show summaries there. For this, you will need to create a TableView descendant and use custom templates for ordinary and group rows. Please note that the demonstrated approach has certain limitations:</em></p>
<p><em>1) It works only for one-level grouping;</em></p>
<p><em>2) The row indicator for a row that contains a group footer will be drawn both for the row and for the footer;</em></p>
<p><em>3) The group footer will replicate summaries that can be shown in the group row;</em></p>
<p><em>4) It is necessary to create a group footer template for each theme used in the application.</em></p>

<br/>


