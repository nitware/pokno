   M S B A M L   `   `   `  ����   Pokno.Report4    .Pokno.Report.Views.Expenses.ExpensesReportView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     P LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8+regionshttp://www.codeplex.com/prism  .��� -     �Name$  
LayoutRoot��$��5,0,0,5q� � RowDefinitions �� $
��auto ��� $��* �.+���  �� Padding$ 0,0,0,2q����	#FF6F8CB9$��0,0,0,2q�._�� $��0��.+��� $��0,0,0,0q�$��80��$��85��._�	� -   $��rbDailyExpensesReport�� d� 	IsChecked$
 TrueY� 	� 	GroupName$ ExpensesReportMenu��   ReportButtonStyle#��[  ���� *DailyExpensesReportCommand+.��� $��Stretch=�$��Stretch=� �� $
��auto ��� $
��auto ��� $��* � � ColumnDefinitions �� �� .+��� $��0��$��2��$��18(�$
��Bold"�$
��Left=�$
��Wrap=�Daily�� $��1��$��2��$��11(�$
��Wrap=�
expenses�� $��0,0,0,0q�$��80��$��85��._�	� -   $��rbMonthlyExpensesReport��$ ExpensesReportMenu��#��[  ���� *MonthlyExpensesReportCommand+.��� $��Stretch=�$��Stretch=� �� $
��auto ��� $
��auto ��� $��* � �� �� .+��� $��0��$��2��$��18(�$
��Bold"�$
��Left=�$
��Wrap=�	Monthly�� $��1��$��2��$��11(�$
��Wrap=�
expenses�� $��0,0,0,0q�$��80��$��85��._�	� -   $��rbYearlyExpensesReport��$ ExpensesReportMenu��#��[  ���� *YearlyExpensesReportCommand+.��� $��Stretch=�$��Stretch=� �� $
��auto ��� $
��auto ��� $��* � �� �� .+��� $��0��$��2��$��18(�$
��Bold"�$
��Left=�$
��Wrap=�Yearly�� $��1��$��2��$��11(�$
��Wrap=�
expenses�� $��0,0,0,0q�$��80��$��85��._�	� -   $!��rbExpensesByDateRangeReport��$ ExpensesReportMenu��#��[  ���� *" ExpensesByDateRangeReportCommand+.��� $��Stretch=�$��Stretch=� �� $
��auto ��� $
��auto ��� $��* � �� �� .+��� $��0��$��2��$��18(�$
��Bold"�$
��Left=�$
��Wrap=�
Expenses�� $��1��$��2��$��11(�$
��Wrap=�By date range�� $��1��$��2,5,0,0q�._��� !  Prism.Regions.RegionManager   
RegionName$ ExpensesReportRegion��