   M S B A M L   `   `   `  ���� O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.InfrastructurePokno.Infrastructure.Converters   Pokno.Account+   %Pokno.Account.Views.DailyExpensesView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     a	converterKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.Infrastructure     X TXceed.Wpf.Toolkit, Version=2.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  Z VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI    � 	Resources  4   .Pokno.Infrastructure.Converters.MoneyConverter   MoneyConverter>   8Pokno.Infrastructure.Converters.FinancialStatusConverter  FinancialStatusConverter8   2Pokno.Infrastructure.Converters.EnabilityConverter  EnabilityConverter��%-   &	        &	      &	 
           .���� $��Stretch=�{��� *IsLoggedInUserHasRight+ �� Mode$ TwoWay=�.��� $��5q����	#E7FFFFFF.+�� $��
10,5,10,10q� � RowDefinitions �� $
��Auto ��� $
��auto ��� $
��auto �.+��� 
�������$��5,5,5,8q� �� CornerRadius$ 20,0,0,0��
�������$��1q�$��0�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ DimGray��._�� $��60,10,20,15q� � ColumnDefinitions �� $	��115 ��� $	��220 ��� $
��auto ��� $
��auto � �� $
��Auto ��� $
��auto �.+��� $��0,0,10,2q�$��12(�
���iii�$
��Bold"�$��Center=�$��1��$��0���� $�Expenses Date��(  "System.Windows.Controls.DatePicker  $��1��$��1��$��25��   SelectedDate �� *ExpensesDate+$ TwoWay=��� $��1��$��2��$��1,0,0,0q�$��9(�$��Search��$
��Left=����� *SearchCommand+=  7FirstFloor.ModernUI.Windows.Controls.ModernProgressRing  $��20,0,0,0q�$��3��$��2��$��45��$��45��   IsActive �� *IsBusy+���� *SelectedItem.Tag+	 �� ElementName$	 CmbRingStyle���� $��5,0,5,5q�$��1��
�������$��1q�$��15(�$��Expenses��.��� $��	20,3,20,5q� �� $	��150 ��� $	��283 ��� $��* � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��12(�$
��Bold"�$��0��$��0��$��Center=�Collected By:�� $��0��$��1��$��0,3,0,0q�$��12(�
 �� TextWrapping$

 Wrap=����� *TargetModel.CollectedBy+$ TwoWay=��� $��0��$��1��$��0,3,0,0q�$��12(�$
��Bold"��� $�Expenses Category:���� $��12(�$��1��$��1��$��0,3,0,0q�$��23������ *ExpensesCategories+$ TwoWay=� �� SelectedValue �� *ExpensesCategory+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�{��� *	CanEdit+ �� 	Converter# [ ���� .R���  �� Orientation$ 
Horizontal=�.+��� ���	#FF413E3E���� *Name+�� $��0��$��2��$��0,3,0,0q�$��12(�$
��Bold"��� $�Payment Type:���� $��12(�$��1��$��2��$��0,3,0,0q�$��23������ *PaymentTypes+$ TwoWay=� �� *PaymentType+$ TwoWay=�$ PropertyChanged=�{��� *	CanEdit+# [ ���� .R��� $ 
Horizontal=�.+��� ���	#FF413E3E���� *Name+�� $��12(�$
��Bold"�$��0��$��3��$��Center=�$��0,3,0,0q��� $�Amount:��%  Xceed.Wpf.Toolkit.DecimalUpDown  $��0,3,0,0q�$��22��$��1��$��3���  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Maximum$ 99999999999999X�$��12(�$	��Top=��	  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]] 	  FormatString$ #,0.00��   Value �� *TargetModel.Amount+$ TwoWay=��� $��12(�$
��Bold"�$��0��$��4��$��0,3,0,0q�
Purpose:�� $��1��$��4��$��0,3,0,0q�$��40��$��12(� �� 	IsEnabled . $

 Wrap=����� *TargetModel.Purpose+$ TwoWay=��� $��1��$��5��$	��Add��$��12(�$
��Left=�$��0,3,0,0q����� *
AddCommand+� $��2��$��5q� �� .+��� ._��� .+�� .+��� 
�������._��� .+��� $��0,1,0,0q�$��0,1,0,0q�$��Bottom=�$��Stretch=�._�� $	��5,1q�$��Bottom=� �� �� .+��� 
���iii�$��Bottom=�$��14(�EXPENSES TRAY�� $��1��$��Right=�$ 
Horizontal=�.+��� $��10,0,2,0q�
���iii�Item Count:�� 
���   �$��20��$ 15��._��� 
�������$��Center=�$��Center=�$
��Bold"����� *RecordCount+$ TwoWay=�&
   System.Windows.Controls.DataGrid
   
  AreRowDetailsFrozen .  
  AutoGenerateColumns .   
  GridLinesVisibility$ Vertical=� 
  HeadersVisibility$ Column=�
�������$	��130������ *TargetCollection+{��� *	CanEdit+# [  
  Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Collected By��   CellTemplate �� .R��� $	��5,0q�$��12(�$
��Wrap=����� *CollectedBy+  $ Category�� �� .R��� $	��5,0q�$��12(�$
��Wrap=����� *Category.Name+  $ Amount�� �� .R��� $	��5,0q�$��12(�$��Right=�$
��Wrap=����� *Amount+# [    $
 Mode�� �� .R��� $	��5,0q�$��12(�$
��Wrap=����� *PaymentMode.Name+  $ Purpose�� �� .R��� $	��5,0q�$��12(�$
��Wrap=����� *	Purpose+�� $��2��$��0,0,15,0q�$ 
Horizontal=�.+��� $��9(�$��Clear��$��3,1,1,2q����� *ClearCommand+�� $��9(�$��Delete��$��0,1,2,2q����� *RemoveCommand+�� $ 
Horizontal=�$��Right=�.+�  $��0,3,15,0q�$��40��$��40�� �� *
IsSaving+���� *SelectedItem.Tag+$	 CmbRingStyle���� $
��Save��$��16(�$��0,3,0,0q����� *SaveCommand+