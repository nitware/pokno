   M S B A M L   `   `   `  ����   Pokno.Report8    2Pokno.Report.Views.Returns.ReturnedStockReportView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     P LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8+regionshttp://www.codeplex.com/prism  .���   � RowDefinitions  �� $
��auto ��� $��* �.+���  �� Padding$ 0,0,0,2q����	#FF6F8CB9$��0,0,0,2q�._�� $��0��.+��� $��0,0,0,0q�$��80��$��85��._�	� -   $��rbYearlyStockReturnReport�� d� 	IsChecked$
 TrueY� 	� 	GroupName$ StockReturnReportMenu��   ReportButtonStyle#��[  ���� * YearlyStockReturnReportCommand+.��� $��Stretch=�$��Stretch=�  �� $
��auto ��� $
��auto ��� $��* � � ColumnDefinitions �� �� .+��� $��0��$��2��$��18(�$
��Bold"�$
��Left=�$
��Wrap=�Stock�� $��1��$��2��$��11(�$
��Wrap=�Yearly returned stock�� $��0,0,0,0q�$��80��$��85��._�	� -   $$��rbStockReturnByDateRangeReport��$ StockReturnReportMenu��#��[  ���� *%#StockReturnByDateRangeReportCommand+.��� $��Stretch=�$��Stretch=�  �� $
��auto ��� $
��auto ��� $��* � �� �� .+��� $��0��$��2��$��18(�$
��Bold"�$
��Left=�$
��Wrap=�Stock�� $��1��$��2��$��11(�$
��Wrap=�Returned stock by date range�� $��1��$��2,5,0,0q�._��� !  Prism.Regions.RegionManager   
RegionName$ ReturnedStockReportRegion��