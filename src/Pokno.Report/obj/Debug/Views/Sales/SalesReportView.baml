   M S B A M L   `   `   `  ����W  SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]@clr-namespace:System.Windows.Documents;assembly=PresentationCoreSystem.Windows.Documents  5       Pokno.Report.   (Pokno.Report.Views.Sales.SalesReportView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml      5      @d2http://schemas.microsoft.com/expression/blend/2008      5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006      5      P LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8+regionshttp://www.codeplex.com/prism  5      Ihl@clr-namespace:System.Windows.Documents;assembly=PresentationCore  5      .��5      � -   5          �Name$  
LayoutRoot��5      $��5,0,0,5q�6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   ��  �� Padding$ 0,0,0,2q�6   ���	#FF6F8CB9$��0,0,0,2q�6;   ._�5      � $��0��6   .+�5      �� $��0,0,0,0q�6   $��80��6*   $��85��66   ._�5      	� -   5        $ ��rbStockSalesAnalysisReport��5   "    	� 	GroupName$ PaymentReportMenu��6x    d� 	IsChecked$
 TrueY�6�      ReportButtonStyle#��[  6�   ��6D   �� *!StockSalesAnalysisReportCommand+.��5      � $��Stretch=�6   $��Stretch=�6=    5      �� 5   "   $
��auto �60   �� 5   "   $
��auto �60   �� 5   "   $��* �60    � ColumnDefinitions 5      �� 5    "   �� 5!   "   .+�5%      �� $��0��6(   $��2��65   $��18(�6I   $
��Bold"�6W   $
��Left=�6i   $
��Wrap=�6�   Stock6�   �� 5&      $��1��6(   $��2��65   $��11(�6I   $
��Wrap=�6W   Sales analysis6|   5(      5)      5*      �� 5,      $��0,0,0,0q�6   $��80��6*   $��85��66   ._�5/      	� -   5        $&�� rbStockSalesDetailAnalysisReport��5/   "   $ PaymentReportMenu��6�   #��[  6�   ��6J   �� *'%StockSalesDetailAnalysisReportCommand+.��50      � $��Stretch=�6   $��Stretch=�6=    51      �� 52   "   $
��auto �60   �� 53   "   $
��auto �60   �� 54   "   $��* �60    56      �� 57   "   �� 58   "   .+�5<      �� $��0��6(   $��2��65   $��18(�6I   $
��Bold"�6W   $
��Left=�6i   $
��Wrap=�6�   Stock6�   �� 5=      $��1��6(   $��2��65   $��11(�6I   $
��Wrap=�6W   Sales detail analysis6�   5?      5A      5C      �� 5E      $��0,0,0,0q�6   $��80��6*   $��85��66   ._�5H      	� -   5        $-��'rbStockSalesDetailAnalysisByStockReport��5H   "   $ PaymentReportMenu��6�   #��[  6�   ��6Q   �� *.,StockSalesDetailAnalysisByStockReportCommand+.��5J      � $��Stretch=�6   $��Stretch=�6=    5K      �� 5L   "   $
��auto �60   �� 5M   "   $
��auto �60   �� 5N   "   $��* �60    5R      �� 5S   "   �� 5T   "   .+�5X      �� $��0��6(   $��2��65   $��18(�6I   $
��Bold"�6W   $
��Left=�6i   $
��Wrap=�6�   Stock6�   �� 5Y      $��1��6(   $��2��65   $��11(�6I   $
��Wrap=�6W    Sales detail analysis by stock6�   5[      5]      5_      5c      5d      �� 5f   
   $��1��6   $��2,5,0,0q�6   ._�5g      �� !  Prism.Regions.RegionManager   
RegionName$ SalesReportRegion��6   5h      5j      5o      