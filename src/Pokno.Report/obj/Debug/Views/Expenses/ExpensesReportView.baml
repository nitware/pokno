   M S B A M L   `   `   `  ����  Pokno.Report4    .Pokno.Report.Views.Expenses.ExpensesReportView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      P LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8+regionshttp://www.codeplex.com/prism  5      .��5
      � -   5          �Name$  
LayoutRoot��5
      $��5,0,0,5q�6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   ��  �� Padding$ 0,0,0,2q�6   ���	#FF6F8CB9$��0,0,0,2q�6;   ._�5      � $��0��6   .+�5      �� $��0,0,0,0q�6   $��80��6*   $��85��66   ._�5      	� -   5        $��rbDailyExpensesReport��5   "    d� 	IsChecked$
 TrueY�6n    	� 	GroupName$ ExpensesReportMenu��6      ReportButtonStyle#��[  6�   ��6?   �� *DailyExpensesReportCommand+.��5      � $��Stretch=�6   $��Stretch=�6=    5      �� 5   "   $
��auto �60   �� 5   "   $
��auto �60   �� 5   "   $��* �60    � ColumnDefinitions 5      �� 5   "   �� 5   "   .+�5"      �� $��0��6(   $��2��65   $��18(�6I   $
��Bold"�6W   $
��Left=�6i   $
��Wrap=�6�   Daily6�   �� 5#      $��1��6(   $��2��65   $��11(�6I   $
��Wrap=�6W   
expenses6v   5%      5&      5'      �� 5*      $��0,0,0,0q�6   $��80��6*   $��85��66   ._�5+      	� -   5        $��rbMonthlyExpensesReport��5+   "   $ ExpensesReportMenu��6r   #��[  6�   ��6A   �� *MonthlyExpensesReportCommand+.��5-      � $��Stretch=�6   $��Stretch=�6=    5.      �� 5/   "   $
��auto �60   �� 50   "   $
��auto �60   �� 51   "   $��* �60    53      �� 54   "   �� 55   "   .+�59      �� $��0��6(   $��2��65   $��18(�6I   $
��Bold"�6W   $
��Left=�6i   $
��Wrap=�6�   	Monthly6�   �� 5:      $��1��6(   $��2��65   $��11(�6I   $
��Wrap=�6W   
expenses6v   5<      5=      5>      �� 5A      $��0,0,0,0q�6   $��80��6*   $��85��66   ._�5B      	� -   5        $��rbYearlyExpensesReport��5B   "   $ ExpensesReportMenu��6p   #��[  6�   ��6@   �� *YearlyExpensesReportCommand+.��5D      � $��Stretch=�6   $��Stretch=�6=    5E      �� 5F   "   $
��auto �60   �� 5G   "   $
��auto �60   �� 5H   "   $��* �60    5J      �� 5K   "   �� 5L   "   .+�5P      �� $��0��6(   $��2��65   $��18(�6I   $
��Bold"�6W   $
��Left=�6i   $
��Wrap=�6�   Yearly6�   �� 5Q      $��1��6(   $��2��65   $��11(�6I   $
��Wrap=�6W   
expenses6v   5S      5T      5U      �� 5W      $��0,0,0,0q�6   $��80��6*   $��85��66   ._�5X      	� -   5        $!��rbExpensesByDateRangeReport��5X   "   $ ExpensesReportMenu��6z   #��[  6�   ��6E   �� *" ExpensesByDateRangeReportCommand+.��5Z      � $��Stretch=�6   $��Stretch=�6=    5[      �� 5\   "   $
��auto �60   �� 5]   "   $
��auto �60   �� 5^   "   $��* �60    5`      �� 5a   "   �� 5b   "   .+�5f      �� $��0��6(   $��2��65   $��18(�6I   $
��Bold"�6W   $
��Left=�6i   $
��Wrap=�6�   
Expenses6�   �� 5g      $��1��6(   $��2��65   $��11(�6I   $
��Wrap=�6W   By date range6{   5i      5j      5k      5p      5q      �� 5s   
   $��1��6   $��2,5,0,0q�6   ._�5t      �� !  Prism.Regions.RegionManager   
RegionName$ ExpensesReportRegion��6   5u      5w      5x      