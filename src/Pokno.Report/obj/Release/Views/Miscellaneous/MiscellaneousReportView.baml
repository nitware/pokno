   M S B A M L   `   `   `  ����   Pokno.Report>    8Pokno.Report.Views.Miscellaneous.MiscellaneousReportView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     P LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8+regionshttp://www.codeplex.com/prism  .��� -     �Name$  
LayoutRoot��$��5,0,0,5q� � RowDefinitions �� $
��auto ��� $��* �.+���  �� Padding$ 0,0,0,2q����	#FF6F8CB9$��0,0,0,2q�._�� $��0��.+��� $��0,0,0,0q�$��80��$��85��._�	� -   $��rbDailyTransactionReport�� d� 	IsChecked$
 TrueY� 	� 	GroupName$ MiscReportMenu��   ReportButtonStyle#��[  ���� *DailyTransactionReportCommand+.��� $��Stretch=�$��Stretch=� �� $
��auto ��� $
��auto ��� $��* � � ColumnDefinitions �� �� .+��� $��0��$��2��$��18(�$
��Bold"�$
��Left=�$
��Wrap=�
Activity�� $��1��$��2��$��11(�$
��Wrap=�Daily transaction�� $��0,0,0,0q�$��80��$��85��._�	� -   $ ��rbYearlyStockSummaryReport��$ MiscReportMenu��#��[  ���� *!YearlyStockSummaryReportCommand+.��� $��Stretch=�$��Stretch=� �� $
��auto ��� $
��auto ��� $��* � �� �� .+��� $��0��$��2��$��18(�$
��Bold"�$
��Left=�$
��Wrap=�Stock�� $��1��$��2��$��11(�$
��Wrap=�Yearly summary�� $��0,0,0,0q�$��80��$��85��._�	� -   $"��rbYearlySummaryByStockReport��$ MiscReportMenu��#��[  ���� *#!YearlySummaryByStockReportCommand+.��� $��Stretch=�$��Stretch=� �� $
��auto ��� $
��auto ��� $��* � �� �� .+��� $��0��$��2��$��18(�$
��Bold"�$
��Left=�$
��Wrap=�Stock�� $��1��$��2��$��11(�$
��Wrap=�Yearly summary by stock�� $��0,0,0,0q�$��80��$��85��._�	� -   $#��rbMonthlyStockBreakDownReport��$ MiscReportMenu��#��[  ���� *$"MonthlyStockBreakDownReportCommand+.��� $��Stretch=�$��Stretch=� �� $
��auto ��� $
��auto ��� $��* � �� �� .+��� $��0��$��2��$��18(�$
��Bold"�$
��Left=�$
��Wrap=�Stock�� $��1��$��2��$��11(�$
��Wrap=�Monthly summary�� $��0,0,0,0q�$��80��$��85��._�	� -   $#��rbYearlyStockStatisticsReport��$ MiscReportMenu��#��[  ���� *$"YearlyStockStatisticsReportCommand+.��� $��Stretch=�$��Stretch=� �� $
��auto ��� $
��auto ��� $��* � �� �� .+��� $��0��$��2��$��18(�$
��Bold"�$
��Left=�$
��Wrap=�
Statistics�� $��1��$��2��$��11(�$
��Wrap=�For stock by year�� $��0,0,0,0q�$��80��$��85��._�	� -   $#��rbMontlyStockStatisticsReport��$ MiscReportMenu��#��[  ���� *$"MontlyStockStatisticsReportCommand+.��� $��Stretch=�$��Stretch=� �� $
��auto ��� $
��auto ��� $��* � �� �� .+��� $��0��$��2��$��18(�$
��Bold"�$
��Left=�$
��Wrap=�
Statistics�� $��1��$��2��$��11(�$
��Wrap=�For stock by month�� $��0,0,0,0q�$��80��$��85��._�	� -   $(��"rbStockStatisticsByDateRangeReport��$ MiscReportMenu��#��[  ���� *)'StockStatisticsByDateRangeReportCommand+.��� $��Stretch=�$��Stretch=� �� $
��auto ��� $
��auto ��� $��* � �� �� .+��� $��0��$��2��$��18(�$
��Bold"�$
��Left=�$
��Wrap=�
Statistics�� $��1��$��2��$��11(�$
��Wrap=�For stock by date range�� $��0,0,0,0q�$��80��$��85��._�	� -	   $1��+rbYearlyCustomerTransactionStatisticsReport��$ MiscReportMenu��#��[  ���� *20YearlyCustomerTransactionStatisticsReportCommand+.��� $��Stretch=�$��Stretch=� �� $
��auto ��� $
��auto ��� $��* � �� �� .+��� $��0��$��2��$��18(�$
��Bold"�$
��Left=�$
��Wrap=�
Statistics�� $��1��$��2��$��11(�$
��Wrap=�For customer by year�� $��0,0,0,0q�$��80��$��85��._�	� -
   $6��0rbCustomerTransactionStatisticsByDateRangeReport��$ MiscReportMenu��#��[  ���� *75CustomerTransactionStatisticsByDateRangeReportCommand+.��� $��Stretch=�$��Stretch=� �� $
��auto ��� $
��auto ��� $��* � �� �� .+��� $��0��$��2��$��18(�$
��Bold"�$
��Left=�$
��Wrap=�
Statistics�� $��1��$��2��$��11(�$
��Wrap=�For customer by date range�� $��1��$��2,5,0,0q�._��� !  Prism.Regions.RegionManager   
RegionName$ MiscReportRegion��