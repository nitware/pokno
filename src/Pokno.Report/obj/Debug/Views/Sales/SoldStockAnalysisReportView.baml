   M S B A M L   `   `   `  ����  Pokno.Report:    4Pokno.Report.Views.Sales.SoldStockAnalysisReportView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Z VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI  5      .��5      �� $��Stretch=�6O   {�6   �� *IsLoggedInUserHasRight+  �� Mode$  TwoWay=�.��5   
   �  � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $��* �6    .+�5      �� 
������� �� Padding$ 5q�6'   $��0��63   ._�5      �� $��10q�6   
�������$��1q�6:   $	��Top=�6N   
������� J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ DimGray��6+   6=   ._�5      �� $
��10,7q�6!    �� Orientation$ 
Horizontal=�6/   .+�5      �� $��0,0,5,0q�6$   $��Center=�65   $
��Bold"�6P   From:6j   (  "System.Windows.Controls.DatePicker  5      $��1��6y   $��8��6�   $	��150��6�   $
��Left=�6�   $��0,0,10,0q�6�      SelectedDate 6%   �� *
FromDate+$  TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5      $��0,0,5,0q�6$   $��Center=�65   $
��Bold"�6P   To:6h     5      $��1��6w   $��8��6�   $	��150��6�   $
��Left=�6�   $��0,0,5,0q�6�    6%   �� *ToDate+$  TwoWay=�$ PropertyChanged=�6�   �� 5!      $��Display��6D   ��6!   �� *DisplayCommand+6D   5"      5#      5$      � 5&      $��0,5,0,0q�6   $��1��6$   .+�5'      =  7FirstFloor.ModernUI.Windows.Controls.ModernProgressRing  $��80��6E   $��80��6P      IsActive 6)   �� *IsBusy+��6\   �� *SelectedItem.Tag+	 �� ElementName$	 CmbRingStyle���� 5(      $��Century Gothic)�6:   $��20(�6V   
���  ����6   �� *ErrorMessage+6d   �� 5)      -   5        $��cp��5)   #   $��1��6-   ��6:   �� *
ReportHost+5*      5-      5.      5/      