   M S B A M L   `   `   `  ����O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY@clr-namespace:Pokno.Infrastructure;assembly=Pokno.InfrastructurePokno.Infrastructure  5       Pokno.Report2   ,Pokno.Report.Views.Payment.PaymentReportView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      Sregion@clr-namespace:Pokno.Infrastructure;assembly=Pokno.Infrastructure     5      P LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8+regionshttp://www.codeplex.com/prism  5      .��5      � -   5          �Name$  
LayoutRoot��5      $��5,0,0,5q�6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   ��  �� Padding$ 0,0,0,2q�6   ���	#FF6F8CB9$��0,0,0,2q�6;   ._�5      � $��0��6   .+�5u      �� $��0,0,0,0q�6   $��80��6*   $��85��66   ._�5v      	� -   5        $��rbPaymentHistoryReport��5v   "    d� 	IsChecked$
 TrueY�6p    	� 	GroupName$ PaymentReportMenu��6�      ReportButtonStyle#��[  6�   ��6@   �� *PaymentHistoryReportCommand+.��5w      � $��Stretch=�6   $��Stretch=�6=    5x      �� 5y   "   $
��auto �60   �� 5z   "   $
��auto �60   �� 5{   "   $��* �60    � ColumnDefinitions 5~      �� 5   "   �� 5�   "   .+�5�      �� $��0��6(   $��2��65   $��18(�6I   $
��Bold"�6W   $
��Left=�6i   $
��Wrap=�6�   	History6�   �� 5�      $��1��6(   $��2��65   $��11(�6I   $
��Wrap=�6W   list6r   5�      5�      5�      �� 5�      $��0,0,0,0q�6   $��80��6*   $��85��66   ._�5�      	� -   5        $"��rbCompanyCreditorsListReport��5�   "   $ PaymentReportMenu��6|   #��[  6�   ��6F   �� *#!CompanyCreditorsListReportCommand+.��5�      � $��Stretch=�6   $��Stretch=�6=    5�      �� 5�   "   $
��auto �60   �� 5�   "   $
��auto �60   �� 5�   "   $��* �60    5�      �� 5�   "   �� 5�   "   .+�5�      �� $��0��6(   $��2��65   $��18(�6I   $
��Bold"�6W   $
��Left=�6i   $
��Wrap=�6�   	Company6�   �� 5�      $��1��6(   $��2��65   $��11(�6I   $
��Wrap=�6W   Creditors list6|   5�      5�      5�      �� 5�      $��0,0,0,0q�6   $��80��6*   $��85��66   ._�5�      	� -   5        $ ��rbCompanyDebtorsListReport��5�   "   $ PaymentReportMenu��6x   #��[  6�   ��6D   �� *!CompanyDebtorsListReportCommand+.��5�      � $��Stretch=�6   $��Stretch=�6=    5�      �� 5�   "   $
��auto �60   �� 5�   "   $
��auto �60   �� 5�   "   $��* �60    5�      �� 5�   "   �� 5�   "   .+�5�      �� $��0��6(   $��2��65   $��18(�6I   $
��Bold"�6W   $
��Left=�6i   $
��Wrap=�6�   	Company6�   �� 5�      $��1��6(   $��2��65   $��11(�6I   $
��Wrap=�6W   Debtors list6z   5�      5�      5�      �� 5�      $��0,0,0,0q�6   $��80��6*   $��85��66   ._�5�      	� -   5        $#��rbSupplierCreditorsListReport��5�   "   $ PaymentReportMenu��6~   #��[  6�   ��6G   �� *$"SupplierCreditorsListReportCommand+.��5�      � $��Stretch=�6   $��Stretch=�6=    5�      �� 5�   "   $
��auto �60   �� 5�   "   $
��auto �60   �� 5�   "   $��* �60    5�      �� 5�   "   �� 5�   "   .+�5�      �� $��0��6(   $��2��65   $��18(�6I   $
��Bold"�6W   $
��Left=�6i   $
��Wrap=�6�   
Supplier6�   �� 5�      $��1��6(   $��2��65   $��11(�6I   $
��Wrap=�6W   Creditors list6|   5�      5�      5�      �� 5�      $��0,0,0,0q�6   $��80��6*   $��85��66   ._�5�      	� -   5        $!��rbSupplierDebtorsListReport��5�   "   $ PaymentReportMenu��6z   #��[  6�   ��6E   �� *" SupplierDebtorsListReportCommand+.��5�      � $��Stretch=�6   $��Stretch=�6=    5�      �� 5�   "   $
��auto �60   �� 5�   "   $
��auto �60   �� 5�   "   $��* �60    5�      �� 5�   "   �� 5�   "   .+�5�      �� $��0��6(   $��2��65   $��18(�6I   $
��Bold"�6W   $
��Left=�6i   $
��Wrap=�6�   
Supplier6�   �� 5�      $��1��6(   $��2��65   $��11(�6I   $
��Wrap=�6W   Debtors list6z   5�      5�      5�      �� 5�      $��0,0,0,0q�6   $��80��6*   $��85��66   ._�5�      	� -   5        $$��rbPaymentHistoryByPersonReport��5�   "   $ PaymentReportMenu��6�   #��[  6�   ��6H   �� *%#PaymentHistoryByPersonReportCommand+.��5�      � $��Stretch=�6   $��Stretch=�6=    5�      �� 5�   "   $
��auto �60   �� 5�   "   $
��auto �60   �� 5�   "   $��* �60    5�      �� 5�   "   �� 5�   "   .+�5�      �� $��0��6(   $��2��65   $��18(�6I   $
��Bold"�6W   $
��Left=�6i   $
��Wrap=�6�   	History6�   �� 5�      $��1��6(   $��2��65   $��11(�6I   $
��Wrap=�6W   	by person6w   5�      5�      5�      5      5     �� 5  
   $��1��6   $��2,5,0,0q�6   ._�5     �� *   $Pokno.Infrastructure.RegionContainer   PaymentReportRegion!  Prism.Regions.RegionManager   
RegionName# Z 6   5     5     5     