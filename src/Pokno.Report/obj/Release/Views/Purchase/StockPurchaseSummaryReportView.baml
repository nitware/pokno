   M S B A M L   `   `   `  ����   Pokno.Report@    :Pokno.Report.Views.Purchase.StockPurchaseSummaryReportView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Z VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI  .���   � RowDefinitions  �� $
��auto ��� $��* �.+��� 
������� �� Padding$ 5q�$��0��._��� $��10q�
�������$��1q�$	��Top=�
������� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ DimGray��._��� $
��10,7q� �� Orientation$ 
Horizontal=�.+��� $��0,0,5,0q�$��Center=�$
��Bold"�From:(  "System.Windows.Controls.DatePicker  $��1��$��8��$	��150��$
��Left=�$��0,0,10,0q�   SelectedDate �� *
FromDate+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� $��0,0,5,0q�$��Center=�$
��Bold"�To:  $��1��$��8��$	��150��$
��Left=�$��0,0,5,0q� �� *ToDate+$ TwoWay=�$ PropertyChanged=��� $��Display������ *DisplayCommand+� $��0,5,0,0q�$��1��.+�=  7FirstFloor.ModernUI.Windows.Controls.ModernProgressRing  $��80��$��80��   IsActive �� *IsBusy+���� *SelectedItem.Tag+	 �� ElementName$	 CmbRingStyle���� $��Century Gothic)�$��20(�
���  ������ *ErrorMessage+�� -   $��cp��$��1������ *
ReportHost+