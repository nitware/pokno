   M S B A M L   `   `   `  ����   Pokno.ReportG    APokno.Report.Views.Miscellaneous.MonthlyStockStatisticsReportView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Z VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI  .���   � RowDefinitions  �� $
��auto ��� $��* �.+��� 
������� �� Padding$ 5q�$��0��._��� $��10q�
�������$��1q�$	��Top=�
������� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ DimGray��._��� $
��10,7q� �� Orientation$ 
Horizontal=�.+��� $��0,0,5,0q�$
��Bold"�$��Center=�Year:�� $��24��$��Center=�$	��150������ *Years+ �� Mode$ TwoWay=� �� SelectedItem �� *Year+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=����� .R��� $ 
Horizontal=�.+��� $��12(����	#FF413E3E���� *Name+�� $��5,0,5,0q�$
��Bold"�$��Center=�Month:�� $��24��$��Center=�$	��150������ *Months+$ TwoWay=� �� *Month+$ TwoWay=�$ PropertyChanged=����� .R��� $ 
Horizontal=�.+��� $��12(����	#FF413E3E���� *Name+�� $��2��$��24��$��11(�$��Display��$
��Left=����� *DisplayCommand+� $��0,5,0,0q�$��1��.+�=  7FirstFloor.ModernUI.Windows.Controls.ModernProgressRing  $��80��$��80��   IsActive �� *IsBusy+���� *SelectedItem.Tag+	 �� ElementName$	 CmbRingStyle���� $��Century Gothic)�$��20(�
���  ������ *ErrorMessage+�� -   $��cp��$��1������ *
ReportHost+