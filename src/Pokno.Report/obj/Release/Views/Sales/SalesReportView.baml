   M S B A M L   `   `   `  ���� W  SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]@clr-namespace:System.Windows.Documents;assembly=PresentationCoreSystem.Windows.Documents   Pokno.Report.   (Pokno.Report.Views.Sales.SalesReportView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml      @d2http://schemas.microsoft.com/expression/blend/2008      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006      P LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8+regionshttp://www.codeplex.com/prism  Ihl@clr-namespace:System.Windows.Documents;assembly=PresentationCore  .��� -     �Name$  
LayoutRoot��$��5,0,0,5q� � RowDefinitions �� $
��auto ��� $��* �.+���  �� Padding$ 0,0,0,2q����	#FF6F8CB9$��0,0,0,2q�._�� $��0��.+��� $��0,0,0,0q�$��80��$��85��._�	� -   $ ��rbStockSalesAnalysisReport�� 	� 	GroupName$ PaymentReportMenu�� d� 	IsChecked$
 TrueY�   ReportButtonStyle#��[  ���� *!StockSalesAnalysisReportCommand+.��� $��Stretch=�$��Stretch=� �� $
��auto ��� $
��auto ��� $��* � � ColumnDefinitions �� �� .+��� $��0��$��2��$��18(�$
��Bold"�$
��Left=�$
��Wrap=�Stock�� $��1��$��2��$��11(�$
��Wrap=�Sales analysis�� $��0,0,0,0q�$��80��$��85��._�	� -   $&�� rbStockSalesDetailAnalysisReport��$ PaymentReportMenu��#��[  ���� *'%StockSalesDetailAnalysisReportCommand+.��� $��Stretch=�$��Stretch=� �� $
��auto ��� $
��auto ��� $��* � �� �� .+��� $��0��$��2��$��18(�$
��Bold"�$
��Left=�$
��Wrap=�Stock�� $��1��$��2��$��11(�$
��Wrap=�Sales detail analysis�� $��0,0,0,0q�$��80��$��85��._�	� -   $-��'rbStockSalesDetailAnalysisByStockReport��$ PaymentReportMenu��#��[  ���� *.,StockSalesDetailAnalysisByStockReportCommand+.��� $��Stretch=�$��Stretch=� �� $
��auto ��� $
��auto ��� $��* � �� �� .+��� $��0��$��2��$��18(�$
��Bold"�$
��Left=�$
��Wrap=�Stock�� $��1��$��2��$��11(�$
��Wrap=� Sales detail analysis by stock�� $��1��$��2,5,0,0q�._��� !  Prism.Regions.RegionManager   
RegionName$ SalesReportRegion��