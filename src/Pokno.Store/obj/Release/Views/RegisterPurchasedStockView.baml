   M S B A M L   `   `   `  ���� O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.InfrastructurePokno.Infrastructure.Converters   Pokno.Store2   ,Pokno.Store.Views.RegisterPurchasedStockView   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     a	converterKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.Infrastructure     X TXceed.Wpf.Toolkit, Version=2.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  Z VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI    � 	Resources  ;   5Pokno.Infrastructure.Converters.DateToSelectConverter   DateToSelectConverter3   -Pokno.Infrastructure.Converters.DateConverter  DateConverter4   .Pokno.Infrastructure.Converters.MoneyConverter  MoneyConverter6   0Pokno.Infrastructure.Converters.IntegerConverter  IntegerConverter9   3Pokno.Infrastructure.Converters.VisibilityConverter  VisibilityConverter;   5Pokno.Infrastructure.Converters.CheckToolTipConverter  CheckToolTipConverter  DecimalUpDownStyle1 �� 
TargetType%  Xceed.Wpf.Toolkit.DecimalUpDown �� Property �� Value �� 
TargetType%  Xceed.Wpf.Toolkit.ButtonSpinner  Name   	AllowSpin �� RelativeSource   ButtonSpinnerLocation	   ShowButtonSpinner
   Content(	  "Xceed.Wpf.Toolkit.WatermarkTextBox 	 Name �� AcceptsReturn � ContextMenu �� IsUndoEnabled �� TextWrapping �� UpdateSourceTrigger)
  #Xceed.Wpf.Toolkit.AutoSelectTextBox 
  AutoMoveFocus 
  AutoSelectBehavior 	  SelectAllOnGotFocus �� TextAlignment 	  WatermarkTemplate 	  	Watermark��%�  &	        &	      &	 
     &	      &	      &	      &	                  �� "  .���  � �� �� "  .R�  $ PART_Spinner��#��z��#��z��#��z��$��Stretch=���.  $��Stretch=� �� *	AllowSpin+ �� *TemplatedParent+ �� *ButtonSpinnerLocation+ �� *TemplatedParent+	 �� *ShowButtonSpinner+ �� *TemplatedParent+.
 	  $ PART_TextBox�� .  $��0q�
������ # z #��z��#��z��#��z��#��z��#��z��#��z��#��z��#��z�� . $��20��#��z��$ NoWrap=�#��z��#��z������ *Text+ �� *TemplatedParent+$ PropertyChanged=� �� *AutoMoveFocus+ �� *TemplatedParent+ �� *AutoSelectBehavior+ �� *TemplatedParent+ �� *SelectAllOnGotFocus+ �� *TemplatedParent+ �� *TextAlignment+ �� *TemplatedParent+ �� *WatermarkTemplate+ �� *TemplatedParent+ �� *	Watermark+ �� *TemplatedParent+.��� -    �Name$ 
LayoutRoot�����	#E7FDFDFD$��5q�.+��  � ColumnDefinitions �� �� .+��  � RowDefinitions �� $
��Auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $��0��$��15,10,12,10q�
������� �� CornerRadius$ 
20,20,0,20��
�������$��1q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ DimGray��._��� .+��� .+��� $��
20,15,20,0q�$ 	10,10,0,0��
�������$��Stretch=�._��� $	��0,8q�$��Center=�
�������$��13(�$
��Bold"�CHOOSE PRODUCT�� $
��20,2q� �� Padding$
 10,5q�
�������$��1q�._�� $��	20,0,20,5q� �� $��68 ��� $	��180 ��� $��* � �� $
��Auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $
��Bold"�$��0��$��0��$��0,3,0,0q�Stock:�� $ �� IsSynchronizedWithCurrentItem$
 TrueY�$��0��$��1��$��0,3,0,0q����� *Stocks+ �� Mode$ TwoWay=�  �� SelectedItem  �� *Stock+$ TwoWay=�$ PropertyChanged=����� .R��� ! �� Orientation$! 
Horizontal=�.+��� ���	#FF413E3E���� *Name+�� $
��Bold"�$��0��$��1��$��0,3,0,0q�
Package:�� $
��Bold"�$��0��$��2��$��0,3,0,0q�
Unit Cost:  �  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]"   FormatString$" #,0.00��{�.  $��0,3,0,0q�$��22��$��1��$��2���  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]#   Maximum$# 99999999999999X�$   Minimum$$ 0X��  �Xceed.Wpf.Toolkit.CommonNumericUpDown`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]%   ParsingNumberStyle$% AllowThousands=�&   Value& �� *TargetModel.UnitCost+$ TwoWay=��� $��2,3,0,0q�$��2��$��2��$��9(�$��0q�$
��Left=�$��25��' � ToolTip$' Change Stock Price��$��22��$	��...������ *ChangePriceCommand+�� $
��Bold"�$��3��$��0,3,0,0q�$��22��$	��Top=�	Quantity:%  Xceed.Wpf.Toolkit.IntegerUpDown  �  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]](   FormatString$	( #,0��$��0,3,0,0q�$��22��$��1��$��3���  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]])   Value) �� *TargetModel.Quantity+$ TwoWay=�* �� 	Converter#* [ �� $
��Bold"�$��0��$��4��$��0,3,0,0q�Cost:  $" #,0.00��$��0,3,0,0q�$��22��$��1��$��4��$# 99999999999999X�& �� *TargetModel.Cost+$ TwoWay=�#* [ �� $
 TrueY�$��1��$��1��$��0,3,0,0q����� *StockPackages+$ TwoWay=�  �� *StockPackage+$ TwoWay=�$ PropertyChanged=����� .R��� $! 
Horizontal=�.+��� ���	#FF413E3E���� *Package.Name+�� $��5��$��1��$
��Left=�$��0,3,0,0q�$! 
Horizontal=�.+��� $��9(�$	��Add������ *
AddCommand+�� $��2��.+��� $! Vertical=�$��20,10, 20,15q�.+��� $��0,0,0,0q�$ 5,5,0,5��._��� .+��� 
�������$��Stretch=�._��� $	��0,7q�$��Center=�
�������$��13(�$
��Bold"�PURCHASED PRODUCT TRAY�� $	��0,1q����#e0eaf6$��1��$��2��$��0��._��  �� �� ��  �� $
��auto �.+��� $	��0,0q�$��0��$��0��$��3��$��1q�._��� .+�� $��5,2,5,2q� �� $
��auto ��� �� $
��auto ��� �� $
��auto ���  �� �� �� �� �� �� .+��� $��0,0,2,0q�$��10(�$��0��$��0��$��Center=�Total Quantity:�� $��0,0,10,0q�$��1��$��0������ *TotalQuantity+�� $��0,0,2,0q�$��2��$��0��$��10(�$��Center=�Total Unit Cost:�� $��0,0,10,0q�$��3��$��0������ *TotalUnitCost+#* [ �� $��10,0,2,0q�$��10(�$��0��$��4��$��Center=�$
��Left=�Total Cost:�� $��0,0,0,0q�$��5��$��0������ *	TotalCost+#* [ &   System.Windows.Controls.DataGrid  +   AreRowDetailsFrozen+ . ,   AutoGenerateColumns, .  -   HeadersVisibility$- Column=�$	��290������ *TargetCollection+.   Columns. 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn/   Header$/ Stock��0   CellTemplate0 �� .R��� $��3,0,3,0q�$��12(�$
��Wrap=����� *
Stock.Name+  $/ Package��0 �� .R��� $��5,0,3,0q�$��12(�$
��Wrap=����� *StockPackage.Package.Name+  $/ Quantity��0 �� .R��� $��5,0,3,0q�$��12(�$��Center=�$
��Wrap=����� *
Quantity+  $/ 	Unit Cost��0 �� .R��� $��5,0,3,0q�$��12(�$��Right=�$
��Wrap=����� *
UnitCost+#* [   $
/ Cost��0 �� .R��� $��5,0,0,0q�$��12(�$��Right=�$
��Wrap=����� *Cost+#* [ �� $
��Left=�$��0,2,5,2q�$! 
Horizontal=�.+��� $��9(�$��Clear��$��0,0,2,0q����� *ClearPurchasedStocksCommand+�� $��9(�$��Remove��$��0,0,2,0q����� *RemoveCommand+� $��1��$��
10,5,10,10q� �� $
��Auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $��1��$��	10,5,10,0q�
�������$��1q�$ 20��
���iii�   $ DimGray��._��� $��20,15,20,10q�._��� .+��� $��0,0,0,5q�$ 	10,10,0,0��
�������$��Stretch=�._��� $	��0,8q�$��Center=�
�������$��13(�$
��Bold"�PURCHASE BATCH�� $��5,0,5,5q�._�� $��5,2,5,0q� �� $	��120 ��� $	��180 � �� $
��Auto ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $
��Bold"�$��0��$��0���� $�	Supplier:���� $
 TrueY�$��1��$��0��$��0,3,0,0q�$��23������ *" PurchaseBatchViewModel.Suppliers+$ TwoWay=�  �� *!PurchaseBatchViewModel.Supplier+$ TwoWay=����� .R��� $! 
Horizontal=�.+��� ���	#FF413E3E���� *
FullName+�� $
��Bold"�$��0��$��1��$��0,3,0,0q�
Initiator:�� $
 TrueY�$��1��$��1��$��0,3,0,0q�$��23������ *PurchaseBatchViewModel.Buyers+$ TwoWay=�  �� *PurchaseBatchViewModel.Buyer+$ TwoWay=����� .R��� $! 
Horizontal=�.+��� ���	#FF413E3E���� *
FullName+�� $
��Bold"�$��0��$��2��$��0,3,0,0q��� $�Date Purchased:��(  "System.Windows.Controls.DatePicker  $��1��$��2��$��23��$��0,3,0,0q�1   FirstDayOfWeek$1 Monday=�2   SelectedDate2 �� *97PurchaseBatchViewModel.StockPurchaseBatch.DatePurchased+$ TwoWay=�$ PropertyChanged=��� $
��Bold"�$��0��$��3���� $�Amount Payable:��  {�.  $" #,0.00��$��0,3,0,0q�$��1��$��3��$��22��$	��Top=�$# 99999999999999X�& �� *.,PurchaseBatchViewModel.Payment.AmountPayable+$ TwoWay=��� $
��Bold"�$��0��$��4��$��0,3,0,0q�Supplier Expenses:  $��0,3,0,0q�$" #,0.00��$��1��$��4��$��22��$# 99999999999999X�$$ 0X�& �� *SupplierExpenses+$ TwoWay=�$ PropertyChanged=�#* [ �� $
��Bold"�$��0��$��5��$��0,3,0,0q��� $�Invoice No.:���� $��0,3,0,0q�$��1��$��5������ *97PurchaseBatchViewModel.StockPurchaseBatch.InvoiceNumber+$ TwoWay=��� $��2��$��
10,15,10,0q�
�������
���iii�$��1q�$ 
20,20,20,0��   $ DimGray��._��� $��2��$ 	0,10,0,10q�$
��20,5q�$��0q�$ 8��
�������._��� .+��� $ 	10,10,0,0��
�������$��Stretch=�._��� $	��0,8q�$��Center=�
�������$��13(�$
��Bold"��� $�PAYMENT DETAILS���� $	��0,2q�
�������$��1q�._�� $��	20,5,20,7q� �� $	��110 ��� $	��180 � �� $
��Auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $
��Bold"�$��0��$��1��$��0,3,0,0q��� $�Amount Paid:��  $" #,0.00��$��0,3,0,0q�$��1��$��1��$��22��$	��Top=�$# 99999999999999X�& �� */-PurchaseBatchViewModel.TargetModel.AmountPaid+$ TwoWay=�#* [ �� $
��Bold"�$��0��$��2��$��0,3,0,0q��� $�
Date Paid:��  $��1��$��2��$��23��$��0,3,0,0q�2 �� *0.PurchaseBatchViewModel.TargetModel.PaymentDate+$ TwoWay=�$ PropertyChanged=��� $
��Bold"�$��0��$��3��$��0,3,0,0q��� $�Payment Mode:���� $
 TrueY�$��1��$��3��$��0,3,0,0q�$��23������ *%#PurchaseBatchViewModel.PaymentTypes+$ TwoWay=�  �� *$"PurchaseBatchViewModel.PaymentType+$ TwoWay=����� .R��� $! 
Horizontal=�.+��� ���	#FF413E3E���� *Name+�� $��4��$��1��$
��Left=�$��0,3,0,0q�$! 
Horizontal=�.+��� $��0,0,2,0q�$��9(�$��
Add Detail��$��Right=����� *AddPaymentCommand+� $��0,0,0,0q�.+��� ._��� ���#EFEFEF$��0,3,0,0q�.+��� ���#EFEFEF$��Stretch=�._��  �� �� .+��� $��5q�PAYMENT DETAILS TRAY�� $��5q�$��1��$! 
Horizontal=�$��Right=�.+��� $��0,0,3,0q�$��Center=�
Balance:�� $��Center=����� * PurchaseBatchViewModel.Balance+#* [   + . , .  3   GridLinesVisibility$
3 None=�$- Column=�$��0,1,0,0q�$	��100������ *)'PurchaseBatchViewModel.TargetCollection+.   $/ Amount Paid��0 �� .R��� $��12(�$
��Wrap=����� *
AmountPaid+#* [ 4 ^� ToolTip4 �� $
��5,10q�
�������y��� *Check+#* [ .+�� $
��5,10q� �� ��  �� �� �� �� .+��� $��0,0,0,5q�$��0��$��0��$��2��
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
���  ������ *Cheque.AccountNumber+  $/ 	Date Paid��0 �� .R��� $��12(�$
��Wrap=����� *PaymentDate+#* [   $
/ Mode��0 �� .R��� $��12(�$
��Wrap=����� *PaymentType.Name+�� $��0,3,0,0q�$��9(�$��Delete��$��Right=����� *RemovePaymentCommand+�� $��4��$
��Left=�$��	10,8,10,5q�$! 
Horizontal=�.+��� $��0,0,2,0q�$��15(�$
��Save��$��Right=����� *SaveCommand+�� $��15(�$��Clear��$��Right=����� *ClearCommand+=  7FirstFloor.ModernUI.Windows.Controls.ModernProgressRing  $��15,0,0,0q�$��30��$��30��5   IsActive5 �� *IsBusy+���� *SelectedItem.Tag+6 �� ElementName$6 CmbRingStyle��