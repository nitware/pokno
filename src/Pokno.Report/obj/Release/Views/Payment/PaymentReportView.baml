   M S B A M L   `   `   `  ���� O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY@clr-namespace:Pokno.Infrastructure;assembly=Pokno.InfrastructurePokno.Infrastructure   Pokno.Report2   ,Pokno.Report.Views.Payment.PaymentReportView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Sregion@clr-namespace:Pokno.Infrastructure;assembly=Pokno.Infrastructure     P LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8+regionshttp://www.codeplex.com/prism  .��� -     �Name$  
LayoutRoot��$��5,0,0,5q� � RowDefinitions �� $
��auto ��� $��* �.+���  �� Padding$ 0,0,0,2q����	#FF6F8CB9$��0,0,0,2q�._�� $��0��.+��� $��0,0,0,0q�$��80��$��85��._�	� -   $��rbPaymentHistoryReport�� d� 	IsChecked$
 TrueY� 	� 	GroupName$ PaymentReportMenu��   ReportButtonStyle#��[  ���� *PaymentHistoryReportCommand+.��� $��Stretch=�$��Stretch=� �� $
��auto ��� $
��auto ��� $��* � � ColumnDefinitions �� �� .+��� $��0��$��2��$��18(�$
��Bold"�$
��Left=�$
��Wrap=�	History�� $��1��$��2��$��11(�$
��Wrap=�list�� $��0,0,0,0q�$��80��$��85��._�	� -   $"��rbCompanyCreditorsListReport��$ PaymentReportMenu��#��[  ���� *#!CompanyCreditorsListReportCommand+.��� $��Stretch=�$��Stretch=� �� $
��auto ��� $
��auto ��� $��* � �� �� .+��� $��0��$��2��$��18(�$
��Bold"�$
��Left=�$
��Wrap=�	Company�� $��1��$��2��$��11(�$
��Wrap=�Creditors list�� $��0,0,0,0q�$��80��$��85��._�	� -   $ ��rbCompanyDebtorsListReport��$ PaymentReportMenu��#��[  ���� *!CompanyDebtorsListReportCommand+.��� $��Stretch=�$��Stretch=� �� $
��auto ��� $
��auto ��� $��* � �� �� .+��� $��0��$��2��$��18(�$
��Bold"�$
��Left=�$
��Wrap=�	Company�� $��1��$��2��$��11(�$
��Wrap=�Debtors list�� $��0,0,0,0q�$��80��$��85��._�	� -   $#��rbSupplierCreditorsListReport��$ PaymentReportMenu��#��[  ���� *$"SupplierCreditorsListReportCommand+.��� $��Stretch=�$��Stretch=� �� $
��auto ��� $
��auto ��� $��* � �� �� .+��� $��0��$��2��$��18(�$
��Bold"�$
��Left=�$
��Wrap=�
Supplier�� $��1��$��2��$��11(�$
��Wrap=�Creditors list�� $��0,0,0,0q�$��80��$��85��._�	� -   $!��rbSupplierDebtorsListReport��$ PaymentReportMenu��#��[  ���� *" SupplierDebtorsListReportCommand+.��� $��Stretch=�$��Stretch=� �� $
��auto ��� $
��auto ��� $��* � �� �� .+��� $��0��$��2��$��18(�$
��Bold"�$
��Left=�$
��Wrap=�
Supplier�� $��1��$��2��$��11(�$
��Wrap=�Debtors list�� $��0,0,0,0q�$��80��$��85��._�	� -   $$��rbPaymentHistoryByPersonReport��$ PaymentReportMenu��#��[  ���� *%#PaymentHistoryByPersonReportCommand+.��� $��Stretch=�$��Stretch=� �� $
��auto ��� $
��auto ��� $��* � �� �� .+��� $��0��$��2��$��18(�$
��Bold"�$
��Left=�$
��Wrap=�	History�� $��1��$��2��$��11(�$
��Wrap=�	by person�� $��1��$��2,5,0,0q�._��� *   $Pokno.Infrastructure.RegionContainer   PaymentReportRegion!  Prism.Regions.RegionManager   
RegionName# Z 