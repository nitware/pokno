   M S B A M L   `   `   `  ����  Pokno.Report.    (Pokno.Report.Views.Stock.StockReportView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      P LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8+regionshttp://www.codeplex.com/prism  5      .��5      � -   5          �Name$  
LayoutRoot��5      $��5,0,0,5q�6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5    
   ��  �� Padding$ 0,0,0,2q�6   ���	#FF6F8CB9$��0,0,0,2q�6;   ._�5!      � $��0��6   .+�5"      �� $��0,0,0,0q�6   $��80��6*   $��85��66   ._�5#      	� -   5        $��rbStockListByTypeReport��5#   "    d� 	IsChecked$
 TrueY�6r    	� 	GroupName$ PaymentReportMenu��6�      ReportButtonStyle#��[  6�   ��6A   �� *StockListByTypeReportCommand+.��5%      � $��Stretch=�6   $��Stretch=�6=    5&      �� 5'   "   $
��auto �60   �� 5(   "   $
��auto �60   �� 5)   "   $��* �60    � ColumnDefinitions 5-      �� 5.   "   �� 5/   "   .+�53      �� $��0��6(   $��2��65   $��18(�6I   $
��Bold"�6W   $
��Left=�6i   $
��Wrap=�6�   Stock6�   �� 54      $��1��6(   $��2��65   $��11(�6I   $
��Wrap=�6W   List of stock by type6�   56      58      5:      �� 5=      $��0,0,0,0q�6   $��80��6*   $��85��66   ._�5@      	� -   5        $��rbStockListReport��5@   "   $ PaymentReportMenu��6f   #��[  6�   ��6;   �� *StockListReportCommand+.��5B      � $��Stretch=�6   $��Stretch=�6=    5C      �� 5D   "   $
��auto �60   �� 5E   &   $
��auto �64   �� 5F   &   $��* �64    5J   "   �� 5K   &   �� 5L   &   .+�5P      �� $��0��6(   $��2��65   $��18(�6I   $
��Bold"�6W   $
��Left=�6i   $
��Wrap=�6�   Stock6�   �� 5Q   "   $��1��6,   $��2��69   $��11(�6M   $
��Wrap=�6[   List of stock6   5S      5U      5W      �� 5Y      $��0,0,0,0q�6   $��80��6*   $��85��66   ._�5\      	� -   5        $��rbStockPackagesReport��5\   "   $ PaymentReportMenu��6n   #��[  6�   ��6?   �� *StockPackagesReportCommand+.��5^      � $��Stretch=�6   $��Stretch=�6=    5_      �� 5`   "   $
��auto �60   �� 5a   "   $
��auto �60   �� 5b   "   $��* �60    5f      �� 5g   "   �� 5h   "   .+�5l      �� $��0��6(   $��2��65   $��18(�6I   $
��Bold"�6W   $
��Left=�6i   $
��Wrap=�6�   Stock6�   �� 5m      $��1��6(   $��2��65   $��11(�6I   $
��Wrap=�6W   All Package6y   5o      5q      5s      �� 5u      $��0,0,0,0q�6   $��80��6*   $��85��66   ._�5w      	� -   5        $��rbPackageQuantityReport��5w   "   $ PaymentReportMenu��6r   #��[  6�   ��6A   �� *PackageQuantityReportCommand+.��5y      � $��Stretch=�6   $��Stretch=�6=    5z      �� 5{   "   $
��auto �60   �� 5|   "   $
��auto �60   �� 5}   "   $��* �60    5�      �� 5�   "   �� 5�   "   .+�5�      �� $��0��6(   $��2��65   $��18(�6I   $
��Bold"�6W   $
��Left=�6i   $
��Wrap=�6�   	Package6�   �� 5�      $��1��6(   $��2��65   $��11(�6I   $
��Wrap=�6W   Relationship6z   5�      5�      5�      �� 5�      $��0,0,0,0q�6   $��80��6*   $��85��66   ._�5�      	� -   5        $��rbStockPriceReport��5�   "   $ PaymentReportMenu��6h   #��[  6�   ��6<   �� *StockPriceReportCommand+.��5�      � $��Stretch=�6   $��Stretch=�6=    5�      �� 5�   "   $
��auto �60   �� 5�   "   $
��auto �60   �� 5�   "   $��* �60    5�      �� 5�   "   �� 5�   "   .+�5�      �� $��0��6(   $��2��65   $��18(�6I   $
��Bold"�6W   $
��Left=�6i   $
��Wrap=�6�   Stock6�   �� 5�      $��1��6(   $��2��65   $��11(�6I   $
��Wrap=�6W   Price6s   5�      5�      5�      �� 5�      $��0,0,0,0q�6   $��80��6*   $��85��66   ._�5�      	� -   5        $��rbStockPriceHistoryReport��5�   "   $ PaymentReportMenu��6v   #��[  6�   ��6C   �� * StockPriceHistoryReportCommand+.��5�      � $��Stretch=�6   $��Stretch=�6=    5�      �� 5�   "   $
��auto �60   �� 5�   "   $
��auto �60   �� 5�   "   $��* �60    5�      �� 5�   "   �� 5�   "   .+�5�      �� $��0��6(   $��2��65   $��18(�6I   $
��Bold"�6W   $
��Left=�6i   $
��Wrap=�6�   Stock6�   �� 5�      $��1��6(   $��2��65   $��11(�6I   $
��Wrap=�6W   Price history6{   5�      5�      5�      �� 5�      $��0,0,0,0q�6   $��80��6*   $��85��66   ._�5�      	� -   5        $&�� rbStockPriceHistoryByStockReport��5�   "   $ PaymentReportMenu��6�   #��[  6�   ��6J   �� *'%StockPriceHistoryByStockReportCommand+.��5�      � $��Stretch=�6   $��Stretch=�6=    5�      �� 5�   "   $
��auto �60   �� 5�   "   $
��auto �60   �� 5�   "   $��* �60    5�      �� 5�   "   �� 5�   "   .+�5�      �� $��0��6(   $��2��65   $��18(�6I   $
��Bold"�6W   $
��Left=�6i   $
��Wrap=�6�   Stock6�   �� 5�      $��1��6(   $��2��65   $��11(�6I   $
��Wrap=�6W   Price history by stock6�   5�      5�      5�      �� 5�      $��0,0,0,0q�6   $��80��6*   $��85��66   ._�5�      	� -	   5        $��rbStockOnShelfReport��5�   "   $ PaymentReportMenu��6l   #��[  6�   ��6>   �� *StockOnShelfReportCommand+.��5�      � $��Stretch=�6   $��Stretch=�6=    5�      �� 5�   "   $
��auto �60   �� 5�   "   $
��auto �60   �� 5�   "   $��* �60    5�      �� 5�   "   �� 5�   "   .+�5�      �� $��0��6(   $��2��65   $��18(�6I   $
��Bold"�6W   $
��Left=�6i   $
��Wrap=�6�   Stock6�   �� 5�      $��1��6(   $��2��65   $��11(�6I   $
��Wrap=�6W   Available on shelf6�   5�      5�      5�      �� 5�      $��0,0,0,0q�6   $��80��6*   $��85��66   ._�5�      	� -
   5        $��rbStocksInStoreReport��5�   "   $ PaymentReportMenu��6n   #��[  6�   ��6?   �� *StocksInStoreReportCommand+.��5�      � $��Stretch=�6   $��Stretch=�6=    5�      �� 5�   "   $
��auto �60   �� 5�   "   $
��auto �60   �� 5�   "   $��* �60    5�      �� 5�   "   �� 5�   "   .+�5     �� $��0��6(   $��2��65   $��18(�6I   $
��Bold"�6W   $
��Left=�6i   $
��Wrap=�6�   Stock6�   �� 5     $��1��6(   $��2��65   $��11(�6I   $
��Wrap=�6W   Available in store6�   5     5     5	     5     5     �� 5  
   $��1��6   $��2,5,0,0q�6   ._�5     �� !  Prism.Regions.RegionManager   
RegionName$ StockReportRegion��6   5     5     5     