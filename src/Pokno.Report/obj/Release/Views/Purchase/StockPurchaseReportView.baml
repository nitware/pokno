   M S B A M L   `   `   `  ����   Pokno.Report9    3Pokno.Report.Views.Purchase.StockPurchaseReportView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     P LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8+regionshttp://www.codeplex.com/prism  .��� $��5,0,0,5q�  � RowDefinitions  �� $
��auto ��� $��* �.+���  �� Padding$ 0,0,0,2q����	#FF6F8CB9$��0,0,0,2q�._�� $��0��.+��� $��0,0,0,0q�$��80��$��85��._�	� -   $��rbPurchasedStockReport�� 	� 	GroupName$ PaymentReportMenu��   ReportButtonStyle#��[  ���� *PurchasedStockReportCommand+.��� $��Stretch=�$��Stretch=�  �� $
��auto ��� $
��auto ��� $��* � � ColumnDefinitions �� �� .+��� $��0��$��2��$��18(�$
��Bold"�$
��Left=�$
��Wrap=�	Product�� $��1��$��2��$��11(�$
��Wrap=�Purchase detail�� $��0,0,0,0q�$��80��$��85��._�	� -   $)��#rbPurchasedStockDetailByStockReport��$ PaymentReportMenu��#��[  ���� **(PurchasedStockDetailByStockReportCommand+.��� $��Stretch=�$��Stretch=�  �� $
��auto ��� $
��auto ��� $��* � �� �� .+��� $��0��$��2��$��18(�$
��Bold"�$
��Left=�$
��Wrap=�	Product�� $��1��$��2��$��11(�$
��Wrap=�Purchase detail by stock�� $��0,0,0,0q�$��80��$��85��._�	� -   $#��rbPurchasedStockSummaryReport��$ PaymentReportMenu��#��[  ���� *$"PurchasedStockSummaryReportCommand+.��� $��Stretch=�$��Stretch=�  �� $
��auto ��� $
��auto ��� $��* � �� �� .+��� $��0��$��2��$��18(�$
��Bold"�$
��Left=�$
��Wrap=�	Product�� $��1��$��2��$��11(�$
��Wrap=�Purchase summary�� $��1��$��2,5,0,0q�._��� !  Prism.Regions.RegionManager   
RegionName$ PurchaseReportRegion��