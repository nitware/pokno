   M S B A M L   `   `   `  ����   Pokno.Report.    (Pokno.Report.Views.Stock.StockReportView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     P LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8+regionshttp://www.codeplex.com/prism  .��� -     �Name$  
LayoutRoot��$��5,0,0,5q� � RowDefinitions �� $
��auto ��� $��* �.+���  �� Padding$ 0,0,0,2q����	#FF6F8CB9$��0,0,0,2q�._�� $��0��.+��� $��0,0,0,0q�$��80��$��85��._�	� -   $��rbStockListByTypeReport�� d� 	IsChecked$
 TrueY� 	� 	GroupName$ PaymentReportMenu��   ReportButtonStyle#��[  ���� *StockListByTypeReportCommand+.��� $��Stretch=�$��Stretch=� �� $
��auto ��� $
��auto ��� $��* � � ColumnDefinitions �� �� .+��� $��0��$��2��$��18(�$
��Bold"�$
��Left=�$
��Wrap=�Stock�� $��1��$��2��$��11(�$
��Wrap=�List of stock by type�� $��0,0,0,0q�$��80��$��85��._�	� -   $��rbStockListReport��$ PaymentReportMenu��#��[  ���� *StockListReportCommand+.��� $��Stretch=�$��Stretch=� �� $
��auto ��� $
��auto ��� $��* � �� �� .+��� $��0��$��2��$��18(�$
��Bold"�$
��Left=�$
��Wrap=�Stock�� $��1��$��2��$��11(�$
��Wrap=�List of stock�� $��0,0,0,0q�$��80��$��85��._�	� -   $��rbStockPackagesReport��$ PaymentReportMenu��#��[  ���� *StockPackagesReportCommand+.��� $��Stretch=�$��Stretch=� �� $
��auto ��� $
��auto ��� $��* � �� �� .+��� $��0��$��2��$��18(�$
��Bold"�$
��Left=�$
��Wrap=�Stock�� $��1��$��2��$��11(�$
��Wrap=�All Package�� $��0,0,0,0q�$��80��$��85��._�	� -   $��rbPackageQuantityReport��$ PaymentReportMenu��#��[  ���� *PackageQuantityReportCommand+.��� $��Stretch=�$��Stretch=� �� $
��auto ��� $
��auto ��� $��* � �� �� .+��� $��0��$��2��$��18(�$
��Bold"�$
��Left=�$
��Wrap=�	Package�� $��1��$��2��$��11(�$
��Wrap=�Relationship�� $��0,0,0,0q�$��80��$��85��._�	� -   $��rbStockPriceReport��$ PaymentReportMenu��#��[  ���� *StockPriceReportCommand+.��� $��Stretch=�$��Stretch=� �� $
��auto ��� $
��auto ��� $��* � �� �� .+��� $��0��$��2��$��18(�$
��Bold"�$
��Left=�$
��Wrap=�Stock�� $��1��$��2��$��11(�$
��Wrap=�Price�� $��0,0,0,0q�$��80��$��85��._�	� -   $��rbStockPriceHistoryReport��$ PaymentReportMenu��#��[  ���� * StockPriceHistoryReportCommand+.��� $��Stretch=�$��Stretch=� �� $
��auto ��� $
��auto ��� $��* � �� �� .+��� $��0��$��2��$��18(�$
��Bold"�$
��Left=�$
��Wrap=�Stock�� $��1��$��2��$��11(�$
��Wrap=�Price history�� $��0,0,0,0q�$��80��$��85��._�	� -   $&�� rbStockPriceHistoryByStockReport��$ PaymentReportMenu��#��[  ���� *'%StockPriceHistoryByStockReportCommand+.��� $��Stretch=�$��Stretch=� �� $
��auto ��� $
��auto ��� $��* � �� �� .+��� $��0��$��2��$��18(�$
��Bold"�$
��Left=�$
��Wrap=�Stock�� $��1��$��2��$��11(�$
��Wrap=�Price history by stock�� $��0,0,0,0q�$��80��$��85��._�	� -	   $��rbStockOnShelfReport��$ PaymentReportMenu��#��[  ���� *StockOnShelfReportCommand+.��� $��Stretch=�$��Stretch=� �� $
��auto ��� $
��auto ��� $��* � �� �� .+��� $��0��$��2��$��18(�$
��Bold"�$
��Left=�$
��Wrap=�Stock�� $��1��$��2��$��11(�$
��Wrap=�Available on shelf�� $��0,0,0,0q�$��80��$��85��._�	� -
   $��rbStocksInStoreReport��$ PaymentReportMenu��#��[  ���� *StocksInStoreReportCommand+.��� $��Stretch=�$��Stretch=� �� $
��auto ��� $
��auto ��� $��* � �� �� .+��� $��0��$��2��$��18(�$
��Bold"�$
��Left=�$
��Wrap=�Stock�� $��1��$��2��$��11(�$
��Wrap=�Available in store�� $��1��$��2,5,0,0q�._��� !  Prism.Regions.RegionManager   
RegionName$ StockReportRegion��