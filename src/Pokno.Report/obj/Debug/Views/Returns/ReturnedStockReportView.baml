   M S B A M L   `   `   `  ����  Pokno.Report8    2Pokno.Report.Views.Returns.ReturnedStockReportView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      P LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8+regionshttp://www.codeplex.com/prism  5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   ��  �� Padding$ 0,0,0,2q�6   ���	#FF6F8CB9$��0,0,0,2q�6;   ._�5      � $��0��6   .+�5      �� $��0,0,0,0q�6   $��80��6*   $��85��66   ._�5      	� -   5        $��rbYearlyStockReturnReport��5   "    d� 	IsChecked$
 TrueY�6v    	� 	GroupName$ StockReturnReportMenu��6�      ReportButtonStyle#��[  6�   ��6C   �� * YearlyStockReturnReportCommand+.��5      � $��Stretch=�6   $��Stretch=�6=     5      �� 5   "   $
��auto �60   �� 5   "   $
��auto �60   �� 5   "   $��* �60    � ColumnDefinitions 5      �� 5   "   �� 5   "   .+�5"      �� $��0��6(   $��2��65   $��18(�6I   $
��Bold"�6W   $
��Left=�6i   $
��Wrap=�6�   Stock6�   �� 5#      $��1��6(   $��2��65   $��11(�6I   $
��Wrap=�6W   Yearly returned stock6�   5%      5&      5'      �� 5*      $��0,0,0,0q�6   $��80��6*   $��85��66   ._�5+      	� -   5        $$��rbStockReturnByDateRangeReport��5+   "   $ StockReturnReportMenu��6�   #��[  6�   ��6H   �� *%#StockReturnByDateRangeReportCommand+.��5-      � $��Stretch=�6   $��Stretch=�6=     5.      �� 5/   "   $
��auto �60   �� 50   "   $
��auto �60   �� 51   "   $��* �60    53      �� 54   "   �� 55   "   .+�59      �� $��0��6(   $��2��65   $��18(�6I   $
��Bold"�6W   $
��Left=�6i   $
��Wrap=�6�   Stock6�   �� 5:      $��1��6(   $��2��65   $��11(�6I   $
��Wrap=�6W   Returned stock by date range6�   5<      5=      5>      5G      5H      �� 5J   
   $��1��6   $��2,5,0,0q�6   ._�5K      �� !  Prism.Regions.RegionManager   
RegionName$ ReturnedStockReportRegion��6   5L      5N      5O      