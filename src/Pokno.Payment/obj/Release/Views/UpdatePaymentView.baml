   M S B A M L   `   `   `  ���� O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.InfrastructurePokno.Infrastructure.Converters   Pokno.Payment+   %Pokno.Payment.Views.UpdatePaymentView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ]localKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.Infrastructure     Hi:http://schemas.microsoft.com/expression/2010/interactivity     X TXceed.Wpf.Toolkit, Version=2.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  Z VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI    � 	Resources  ;   5Pokno.Infrastructure.Converters.CheckToolTipConverter   CheckToolTipConverter3   -Pokno.Infrastructure.Converters.DateConverter  DateConverter4   .Pokno.Infrastructure.Converters.MoneyConverter  MoneyConverter9   3Pokno.Infrastructure.Converters.DateSelectConverter  DateSelectConverter@   :Pokno.Infrastructure.Converters.IfZeroReturnEmptyConverter  IfZeroReturnEmptyConverter��%K   &	        &	      &	 
     &	      &	                .���� $��Stretch=�{��� *IsLoggedInUserHasRight+ �� Mode$ TwoWay=�.��� .+�� $��5,0,0,0q�����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FFf2fafd�� � Offset$
 0.85Q�� $ 	#FFe4f6fa��$ 1Q�� $ 	#FFe7f4fc��$	 0.3Q�� $ 	#FFa9cde7��$ 0Q� � RowDefinitions �� $
��Auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto � � ColumnDefinitions �� �� .+��� $��1�� �� CornerRadius$ 30��$��2��$��1,1,0,1q�
�������
�������$��Stretch=�$��10,10,15,10q�$	��Top=�	 J� Effect	 3  -System.Windows.Media.Effects.DropShadowEffect  
   Color$
 DimGray��._�� $��30,10,10,10q� �� $	��120 ��� $��* � �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $
��Bold"�$��0��$��Center=�$��1���� $�Person:���� $ �� IsSynchronizedWithCurrentItem$
 TrueY�$��1��$��1��$
��Left=�$��Center=�$	��170������ *People+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem �� *Person+$ TwoWay=�$ PropertyChanged=����� .R���  �� Orientation$ 
Horizontal=�.+��� $��0,0,4,0q����	#FF413E3E���� *Name+�� $��5,0,0,0q����	#FF413E3E$��(���� ���	#FF413E3E���� *	Type.Name+�� ���	#FF413E3E$��)���� $��0,3,0,0q�$
��Bold"�$��0��$��Center=�$��2���� $�Payment:���� $��1��$��2��$��0,3,0,0q�$
��Left=�$��Center=�$	��170��$��23������ *
Payments+$ TwoWay=� �� *	Payment+$ TwoWay=����� .R��� $ 
Horizontal=�.+��� $��0,0,10,0q�$
��Bold"����	#FF413E3E���� *TransactionDate+ �� 	Converter# [ �� $��0,0,10,0q�
���  ������ *AmountPayable+# [ �� ���	#FF413E3E���� *
AmountPaid+# [ �� $��2��$��10,10,20,10q�$	��Top=�
�������$ 40��
�������$��0,0,1,1q�	   $
 DimGray��._�� $��30,20q� �� $	��120 ��� $	��170 ��� $��* � �� $
��Auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� 
���   �$��3��$��	0,0,0,0.5q�$��0,0,0,5q�
�������$��Stretch=�._��� $��5q�$��11(�NEW PAYMENT DETAIL�� $
��Bold"�$��0��$��2��$��0,3,0,0q��� $�Amount To Pay:��%  Xceed.Wpf.Toolkit.DecimalUpDown  $��0,3,0,0q�$��1��$��2��$��22��$	��Top=��  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Maximum$ 99999999999999X�   Value �� *TargetModel.AmountPaid+$ TwoWay=��� $
��Bold"�$��0��$��3��$��0,3,0,0q��� $�
Date Paid:��(	  "System.Windows.Controls.DatePicker	  $��1��$��3��$��23��$��0,3,0,0q�$	��Top=� 	  SelectedDate �� *TargetModel.PaymentDate+$ TwoWay=��� $
��Bold"�$��0��$��4��$��0,3,0,0q��� $�Payment Mode:���� $��10(�$��1��$��4��$��0,3,0,0q�$��23������ *PaymentTypes+$ TwoWay=� �� *PaymentType+���� .R��� $ 
Horizontal=�.+��� ���	#FF413E3E���� *Name+�� $��5��$��1��$
��Left=�$��0,3,0,0q�$ 
Horizontal=�.+��� $��9(�$��
Add Detail������ *
AddCommand+=
  7FirstFloor.ModernUI.Windows.Controls.ModernProgressRing
  $��5,0,0,0q�$��2��$��1��$��4��$��60��$��60�� 
  IsActive �� *IsBusy+���� *SelectedItem.Tag+ �� ElementName$ CmbRingStyle���� $��0��$��5��$��1��$��25,10,15,15q�$��Stretch=�
�������$��0,1,1,1q�
�������	   $
 DimGray��._��� $��15,15,15,15q�._��� .+��� $��2,0,2,0q�
�������._��� $��10q�.+��� 
���iii�$��0,0,0,1q�$��0,2,0,0q�$��Stretch=�._��� PAYMENT HISTORY� $��0,2,0,0q� �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto � �� �� �� �� �� �� .+��� $��0,0,2,0q�$��11(�$��0��$��0��$��Center=�Amt Payable:�� $
��Bold"�$��11(�$��0,0,10,0q�$��1��$��0������ *TotalAmountPayable+# [ �� $��0,0,2,0q�$��2��$��11(�$��0��$��Center=�	Amt Paid:�� $
��Bold"�$��11(�$��0,0,10,0q�$��3��$��0������ *TotalAmountPaid+# [ �� $��10,0,2,0q�$��0��$��4��$��Center=�$��11(�$
��Left=�
Balance:�� $
��Bold"�$��11(�$��0,0,0,0q�$��5��$��0������ *TotalBalance+# [ &   System.Windows.Controls.DataGrid  -   $��cartDataGrid��   AreRowDetailsFrozen .    AutoGenerateColumns .     GridLinesVisibility$ 
Horizontal=�   HeadersVisibility$ Column=�$��0q�
�������
�������   AlternatingRowBackground
 �����$	��450������ *SupplierPaymentHistory+ �� GroupStyleSelector Z�  �� 
GroupStyle (  "System.Windows.Controls.GroupStyle     ContainerStyle ��  �� 
TargetType" ��.���  �� Property � �� �� Value ��   �� 
TargetType"  ��.R�9� $	��0,1q�
�������
�������$	��0,1q����� $	��0,3q�._��� $ 
Horizontal=�.+��� $
��Bold"����� *Name+�� $��10,0,0,0q�$��(��$
��Bold"��� $
��Bold"����� ! �� Path$! 	ItemCount��� $��5,0,0,0q�$��Items��$
��Bold"��� $��)��$
��Bold"�.���� "   Columns" 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn#   Header$# Amt Payable��$   CellTemplate$ �� .R��� $	��5,0q�$��12(�$��Right=�$
��Wrap=����� *AmountPayable+# [   $# Amt Paid��$ �� .R��� $	��5,0q�$��12(�$��Right=�$
��Wrap=����� *
AmountPaid+# [   $# Balance��$ �� .R��� $	��5,0q�$��12(�$��Right=�$
��Wrap=����� *	Balance+# [   $
# Mode��$ �� .R��� $	��5,0q�$��12(�$
��Wrap=����� *PaymentType+�� $��3��$��
10,5,20,15q�$ 40��
�������$��0,0,1,1q�
�������	   $
 DimGray��._��� $��15,10q�.+�� $
��15,0q�$��Stretch=�.+��� 
�������$��0,0,0,0q�._��� .+��� $��0,2,0,3q�
���   �$��	0,0,0,0.5q�$��0��$��0��$��3��._��� .+��� 
���   �$��	0,0,0,0.5q�$��0,2,0,2q�
�������$��Stretch=�._��� $	��5,4q�$��11(�PAYMENT TRAY�� % �� Padding$% 5q�
�������$��1q�._��  �� $
��auto ��� �� $
��auto ���  �� �� .+��� $��0,0,3,0q�$��10(�$��0��$��0��$��Center=��� $�Amount Payable:���� $
��Bold"�$��10(�$��1��$��0��$��Center=����� *Payment.AmountPayable+# [ �� $��9(�$��1��$��0��{�.  $
��Bold"����� *TotalQuantity+�� $��0,0,3,0q�$��2��$��1��$��10(�$��Center=��� $�Balance:���� $��0,0,0,0q�$
��Bold"�$��10(�$��3��$��1��$��Center=����� *Payment.Balance+# [ �� $
��Bold"�$��9(�$��3��$��1��{�.  ���� *TotalUnitCost+# [ �� $��0,0,0,0q�$��10(�$��1��$��0��$��Center=�$
��Left=��� $�Amount Paid:���� $
��Bold"�$��10(�$��1��$��1��$��Center=����� *Payment.AmountPaid+# [ �� $��9(�$��1��$��1��{�.  $
��Bold"����� *	TotalCost+# [    .  .  $ Column=�$	��130������ *TargetCollection+"   $# Amount Paid��$ �� .R��� $��12(�$��0,0,5,0q�$��Right=�$
��Wrap=����� *
AmountPaid+# [ & ^� ToolTip& �� $
��5,10q�
�������y��� *Check+# [  .+�� $
��5,10q� �� ��  �� �� �� �� .+��� $��0,0,0,5q�$��0��$��0��$��2��
���   �$��0,0,0,1q�._��� $
��Bold"�$��Center=�$��Expanded&��� $�CHEQUE DETAIL���� $��0,0,5,0q�$��0��$��1��$
��Bold"�$��Right=�
��������� $�Bank:���� $��1��$��11(�$��1��
���  ������ *Cheque.Bank.Name+�� $��0,0,5,0q�$��0��$��2��$
��Bold"�$��Right=�
��������� $�
Cheque No:���� $��1��$��11(�$��2��
���  ������ *Cheque.ChequeNumber+�� $��0,0,5,0q�$��0��$��3��$
��Bold"�$��Right=�
��������� $�Account No:���� $��1��$��11(�$��3��
���  ������ *Cheque.AccountNumber+  $# 	Date Paid��$ �� .R��� $��12(�$��3,0,3,0q�$
��Wrap=����� *PaymentDate+# [   $
# Mode��$ �� .R��� $��12(�$��3,0,3,0q�$
��Wrap=����� *PaymentType.Name+�� $
��15,0q�$��Stretch=�._��  �� $
��auto ��� $��* �.+��� $��1��$��Right=�$��0,3,0,5q�$ 
Horizontal=�.+��� $��Clear��$��0,0,2,0q����� *ClearCommand+�� $��Remove��$��0,0,2,0q����� *RemoveCommand+�� $
��Save������ *SaveCommand+