   M S B A M L   `   `   `  ����  Pokno.ReportF    @Pokno.Report.Views.Purchase.StockPurchaseDetailByStockReportView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Z VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI  5      .��5      �   � RowDefinitions  5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� 
������� �� Padding$ 5q�6#   $��0��6/   ._�5      �� $��10q�6   
�������$��1q�66   $	��Top=�6J   
������� J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ DimGray��6'   69   ._�5      �� $
��10,7q�6    �� Orientation$ 
Horizontal=�6+   .+�5      �� $��0,0,5,0q�6    $��Center=�61   $
��Bold"�6L   From:6f   (  "System.Windows.Controls.DatePicker  5      $��1��6u   $��8��6�   $	��150��6�   $
��Left=�6�   $��0,0,10,0q�6�      SelectedDate 6!   �� *
FromDate+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5      $��0,0,5,0q�6    $��Center=�61   $
��Bold"�6L   To:6d     5      $��1��6s   $��8��6�   $	��150��6�   $
��Left=�6�   $��0,0,5,0q�6�    6!   �� *ToDate+$ TwoWay=�$ PropertyChanged=�6�   �� 5       $��0,0,5,0q�6    $
��Bold"�61   $��Center=�6C   $��0��6^   $��0��6n   Stock:6�   �� 5$      $	��250��6w   $��24��6�   $��Center=�6�   $��0��6�   $��1��6�   ��6   �� *Stocks+$ TwoWay=� �� SelectedItem 6K   �� *Stock+$ TwoWay=���5%      �� 5&      .R�5'   "   �� $ 
Horizontal=�6-   .+�5(   &   �� $��12(�60   ���	#FF413E3E��6U   �� *Name+6m   5)   #   5*      5,      �� 5/      $��24��6@   $��Display��6L   ��6   �� *DisplayCommand+6L   50      51      52      � 54   
   $��0,5,0,0q�6   $��1��6    .+�55      =  7FirstFloor.ModernUI.Windows.Controls.ModernProgressRing  $��80��6A   $��80��6L   	   IsActive	 6%   �� *IsBusy+��6X   �� *SelectedItem.Tag+
 �� ElementName$
 CmbRingStyle���� 56      $��Century Gothic)�66   $��20(�6R   
���  ����6   �� *ErrorMessage+6`   �� 57      -   5        $��cp��57      $��1��6)   ��66   �� *
ReportHost+58      5;      5<      