   M S B A M L   `   `   `  ����  Pokno.Report9    3Pokno.Report.Views.Purchase.StockPurchaseReportView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      P LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8+regionshttp://www.codeplex.com/prism  5      .��5      � $��5,0,0,5q�6     � RowDefinitions  5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   ��  �� Padding$ 0,0,0,2q�6   ���	#FF6F8CB9$��0,0,0,2q�6;   ._�5      � $��0��6   .+�5      �� $��0,0,0,0q�6   $��80��6*   $��85��66   ._�5      	� -   5        $��rbPurchasedStockReport��5   "    	� 	GroupName$ PaymentReportMenu��6p      ReportButtonStyle#��[  6�   ��6@   �� *PurchasedStockReportCommand+.��5      � $��Stretch=�6   $��Stretch=�6=     5      �� 5   "   $
��auto �60   �� 5   "   $
��auto �60   �� 5   "   $��* �60    � ColumnDefinitions 5      �� 5    "   �� 5!   "   .+�5%      �� $��0��6(   $��2��65   $��18(�6I   $
��Bold"�6W   $
��Left=�6i   $
��Wrap=�6�   	Product6�   �� 5&      $��1��6(   $��2��65   $��11(�6I   $
��Wrap=�6W   Purchase detail6}   5(      5)      5+      �� 5-      $��0,0,0,0q�6   $��80��6*   $��85��66   ._�50      	� -   5        $)��#rbPurchasedStockDetailByStockReport��50   "   $ PaymentReportMenu��6�   #��[  6�   ��6M   �� **(PurchasedStockDetailByStockReportCommand+.��52      � $��Stretch=�6   $��Stretch=�6=     53      �� 54   "   $
��auto �60   �� 55   "   $
��auto �60   �� 56   "   $��* �60    58      �� 59   "   �� 5:   "   .+�5>      �� $��0��6(   $��2��65   $��18(�6I   $
��Bold"�6W   $
��Left=�6i   $
��Wrap=�6�   	Product6�   �� 5?      $��1��6(   $��2��65   $��11(�6I   $
��Wrap=�6W   Purchase detail by stock6�   5A      5B      5D      �� 5F      $��0,0,0,0q�6   $��80��6*   $��85��66   ._�5H      	� -   5        $#��rbPurchasedStockSummaryReport��5H   "   $ PaymentReportMenu��6~   #��[  6�   ��6G   �� *$"PurchasedStockSummaryReportCommand+.��5J      � $��Stretch=�6   $��Stretch=�6=     5K      �� 5L   "   $
��auto �60   �� 5M   "   $
��auto �60   �� 5N   "   $��* �60    5P      �� 5Q   "   �� 5R   "   .+�5V      �� $��0��6(   $��2��65   $��18(�6I   $
��Bold"�6W   $
��Left=�6i   $
��Wrap=�6�   	Product6�   �� 5W      $��1��6(   $��2��65   $��11(�6I   $
��Wrap=�6W   Purchase summary6~   5Y      5Z      5\      5`      5a      �� 5c   
   $��1��6   $��2,5,0,0q�6   ._�5d      �� !  Prism.Regions.RegionManager   
RegionName$ PurchaseReportRegion��6   5e      5g      5i      