   M S B A M L   `   `   `  ���� O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.InfrastructurePokno.Infrastructure.Converters  qLclr-namespace:Pokno.Infrastructure.View.Popups;assembly=Pokno.Infrastructure Pokno.Infrastructure.View.Popups   Pokno.Store0   *Pokno.Store.Views.ModifyPurchasedStockView   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     a	converterKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.Infrastructure     X TXceed.Wpf.Toolkit, Version=2.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  P LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8)prismhttp://www.codeplex.com/prism  XviewsLclr-namespace:Pokno.Infrastructure.View.Popups;assembly=Pokno.Infrastructure  c	 _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity 	 Z
 VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI 
   � 	Resources  3   -Pokno.Infrastructure.Converters.DateConverter   DateConverter;   5Pokno.Infrastructure.Converters.CheckToolTipConverter  CheckToolTipConverter;   5Pokno.Infrastructure.Converters.DateToSelectConverter  DateToSelectConverter6   0Pokno.Infrastructure.Converters.IntegerConverter  IntegerConverter4   .Pokno.Infrastructure.Converters.MoneyConverter  MoneyConverter��%K   &	        &	      &	 
     &	      &	                .���� $��Stretch=�{��� *PurchasedStockCanBeEdited+ �� Mode$ TwoWay=�.��� -    �Name$ 
LayoutRoot��$��5q����	#E7FBF9F9 � ColumnDefinitions �� ��  � RowDefinitions �� $
��Auto ��� $
��auto �.+��� $��15,10,15,10q�$��0��$��0�� �� CornerRadius$ 20��
�������$��0,0,1,1q�
������� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ DimGray��._�� $��5q� �� $	��160 ��� $��* �.+��� $��	0,10,5,10q�$��Center=�$��0��$��Right=�$
��Bold"�
�������Purchased Batch:�� $��0,5,30,5q�$��1��$��0��$ �� IsSynchronizedWithCurrentItem$
 TrueY�$��Center=����� *PurchaseStockBatches+$ TwoWay=�	 �� SelectedItem	 �� *PurchaseStockBatch+$ TwoWay=����� .R��� 
 �� Orientation$
 
Horizontal=�.+��� $��0,0,7,0q����	#FF413E3E���� *
Buyer.Name+�� $
��Bold"����	#FF413E3E���� *DatePurchased+ �� 	Converter# [ � $��0,5,0,10q�$��0��$��1�� �� $
��Auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $��
15,0,15,10q�$��1��$ 25,0,0,0��
�������$��1,1,0,1q�
���iii�   $ DimGray��._��� $��
25,5,25,10q�$ 	15,0,0,15��$��0q�
�������._��� .+��� 
�������$ 10,0,0,0��$��0,0,0,0q�$��
10,10,10,5q�
�������$��Stretch=�._��� $
��15,5q�$��Center=�$��13(�
�������$
��Bold"�PURCHASE INFORMATION� $��
20,5,10,10q� �� $	��120 ��� $	��200 � �� $
��Auto ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $
��Bold"�$��0��$��0��	Supplier:�� $
 TrueY�$��1��$��0��$��0,3,0,0q����� *" PurchaseBatchViewModel.Suppliers+$ TwoWay=�	 �� *!PurchaseBatchViewModel.Supplier+$ TwoWay=����� .R��� $
 
Horizontal=�.+��� ���	#FF413E3E���� *
FullName+�� $
��Bold"�$��0��$��1��$��0,3,0,0q�
Initiator:�� $
 TrueY�$��1��$��1��$��0,3,0,0q����� *PurchaseBatchViewModel.Buyers+$ TwoWay=�	 �� *PurchaseBatchViewModel.Buyer+$ TwoWay=����� .R��� $
 
Horizontal=�.+��� ���	#FF413E3E���� *
FullName+�� $
��Bold"�$��0��$��2��$��0,3,0,0q�Date Purchased:(  "System.Windows.Controls.DatePicker  $��1��$��2��$��0,3,0,0q�   SelectedDate �� *97PurchaseBatchViewModel.StockPurchaseBatch.DatePurchased+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� $
��Bold"�$��0��$��3��Amount Payable:%  Xceed.Wpf.Toolkit.DecimalUpDown  �	  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]] 	  FormatString$ #,0.00��{�.  $��0,3,0,0q�$��1��$��3���
  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]] 
  Value �� *.,PurchaseBatchViewModel.Payment.AmountPayable+$ TwoWay=��� $
��Bold"�$��0��$��4��$��0,3,0,0q�Supplier Expenses:  $ #,0.00��$��0,3,0,0q�$��1��$��4�� 
  Maximum$ 99999999999999X� �� *SupplierExpenses+$ TwoWay=�$ PropertyChanged=�# [ �� $
��Bold"�$��0��$��5��$��0,3,0,0q�Invoice No.:�� $��0,3,0,0q�$��1��$��5������ *97PurchaseBatchViewModel.StockPurchaseBatch.InvoiceNumber+$ TwoWay=�� $��2��$��0��$��	15,5,15,0q� �� �� .+��� 
�������$ 0,0,0,25��
���iii�$��1q�   $ DimGray��._��� $��
25,5,25,10q�$ 
0,15,15,15��$��2��$��0q�
�������._��� .+��� 
�������$��0,0,0,0q�$��
10,10,10,5q�
�������$��Stretch=�._��� $
��15,5q�$��Center=�$��13(�
�������$
��Bold"�PAYMENT DETAILS� $
��20,5q� �� $	��120 ��� $	��200 � �� $
��Auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+�  $��0,3,0,0q�$��1��$��1��$ 99999999999999X� �� */-PurchaseBatchViewModel.TargetModel.AmountPaid+$ TwoWay=�# [ �� $
��Bold"�$��0��$��1��$��0,3,0,0q�Amount Paid:�� $
��Bold"�$��0��$��2��$��0,3,0,0q�
Date Paid:  $��1��$��2��$��0,3,0,0q� �� *0.PurchaseBatchViewModel.TargetModel.PaymentDate+$ TwoWay=�$ PropertyChanged=��� $
��Bold"�$��0��$��3��$��0,3,0,0q�Payment Mode:�� $
 TrueY�$��1��$��3��$��0,3,0,0q����� *%#PurchaseBatchViewModel.PaymentTypes+$ TwoWay=�	 �� *$"PurchaseBatchViewModel.PaymentType+$ TwoWay=����� .R��� $
 
Horizontal=�.+��� ���	#FF413E3E���� *Name+�� $��4��$��1��$
��Left=�$��0,3,0,0q�$
 
Horizontal=�.+��� $��0,0,2,0q�$��9(�$��
Add Detail������ *AddPaymentCommand+� $
��10,0q�.+��� 
�������
�������$��0,0,0,0q�._��� .+��� ���#EFEFEF$��Stretch=�._��  �� �� .+��� $��5q�PAYMENT DETAILS TRAY�� $��5q�$��1��$
 
Horizontal=�$��Right=�.+��� $��0,0,3,0q�$��Center=�
Balance:�� $��Center=����� * PurchaseBatchViewModel.Balance+# [ &   System.Windows.Controls.DataGrid     AreRowDetailsFrozen .    AutoGenerateColumns .     GridLinesVisibility$
 None=�   HeadersVisibility$ Column=�$��0,0,0,4q�$	��100������ *)'PurchaseBatchViewModel.TargetCollection+   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Amount Paid��   CellTemplate �� .R��� $	��5,0q�$��12(�$
��Wrap=����� *
AmountPaid+# [  ^� ToolTip �� $
��5,10q�
�������y��� *Check+# [ .+�� $
��5,10q� �� ��  �� �� �� �� .+��� $��0,0,0,5q�$��0��$��0��$��2��
���   �$��0,0,0,1q�._��� $
��Bold"�$��Center=�$��Expanded&�CHEQUE DETAIL�� $��0,0,5,0q�$��0��$��1��$
��Bold"�$��Right=�
�������Bank:�� $��1��$��11(�$��1��
���  ������ *Cheque.Bank.Name+�� $��0,0,5,0q�$��0��$��2��$
��Bold"�$��Right=�
�������
Cheque No:�� $��1��$��11(�$��2��
���  ������ *Cheque.ChequeNumber+�� $��0,0,5,0q�$��0��$��3��$
��Bold"�$��Right=�
�������Account No:�� $��1��$��11(�$��3��
���  ������ *Cheque.AccountNumber+  $ 	Date Paid�� �� .R��� $	��5,0q�$��12(�$
��Wrap=����� *PaymentDate+# [    $
 Mode�� �� .R��� $	��5,0q�$��12(�$
��Wrap=����� *PaymentType.Name+�� $��	10,0,10,5q�$
 
Horizontal=�$��Right=�.+��� $��9(�$��Clear������ *RemovePaymentCommand+�� $��0��$��1��$��2��$��15,10,20,10q�$	��Top=�.+��� 
�������$ 	0,20,20,0��
�������$��1q�   $ DimGray��._��� .+��� .+��� $��
25,15,25,0q�$ 0,10,0,0��
�������$��Stretch=�._��� $	��0,5q�$��Center=�
�������$��13(�$
��Bold"�CHOOSE PRODUCT�� $
��25,2q� �� Padding$
 10,5q�
�������$��1q�._�� $��	20,0,20,5q� �� $��68 ��� $	��180 ��� $��* � �� $
��Auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $
��Bold"�$��0��$��0��$��0,3,0,0q�Stock:�� $
 TrueY�$��0��$��1��$��0,3,0,0q����� *Stocks+$ TwoWay=�	 �� *Stock+$ TwoWay=�$ PropertyChanged=����� .R��� $
 
Horizontal=�.+��� ���	#FF413E3E���� *Name+�� $
��Bold"�$��0��$��1��$��0,3,0,0q�
Package:�� $
��Bold"�$��0��$��2��$��0,3,0,0q�
Unit Cost:  $ #,0.00��{�.  $��0,3,0,0q�$��22��$��1��$��2��$ 99999999999999X� 
  Minimum$ 0X��  �Xceed.Wpf.Toolkit.CommonNumericUpDown`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   ParsingNumberStyle$ AllowThousands=� �� *TargetModel.UnitCost+$ TwoWay=��� $��2,3,0,0q�$��2��$��2��$��9(�$��0q�$
��Left=�$��25�� � ToolTip$ Change Stock Price��$��22��$	��...������ *ChangePriceCommand+�� $
��Bold"�$��3��$��0,3,0,0q�$��22��$	��Top=�	Quantity:%  Xceed.Wpf.Toolkit.IntegerUpDown  �  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   FormatString$	 #,0��$��0,3,0,0q�$��22��$��1��$��3���  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value �� *TargetModel.Quantity+$ TwoWay=�# [ �� $
��Bold"�$��0��$��4��$��0,3,0,0q�Cost:  $ #,0.00��$��0,3,0,0q�$��22��$��1��$��4��$ 99999999999999X� �� *TargetModel.Cost+$ TwoWay=�# [ �� $
 TrueY�$��1��$��1��$��0,3,0,0q����� *StockPackages+$ TwoWay=�	 �� *StockPackage+$ TwoWay=�$ PropertyChanged=����� .R��� $
 
Horizontal=�.+��� ���	#FF413E3E���� *Package.Name+�� $��5��$��1��$
��Left=�$��0,3,0,0q�$
 
Horizontal=�.+��� $��9(�$	��Add������ *
AddCommand+�� $��2��.+��� $
 Vertical=�$��25,10, 25,15q�.+��� $��0,0,0,0q�$ 5,5,0,5��._��� .+��� 
�������$��Stretch=�._��� $	��0,5q�$��Center=�
�������$��13(�$
��Bold"�PURCHASED PRODUCT TRAY�� $	��0,1q����#e0eaf6$��1��$��2��$��0��._��  �� �� ��  �� $
��auto �.+��� $	��0,0q�$��0��$��0��$��3��$��1q�._��� .+�� $��5,2,5,2q� �� $
��auto ��� �� $
��auto ��� �� $
��auto ���  �� �� �� �� �� �� .+��� $��0,0,2,0q�$��10(�$��0��$��0��$��Center=�Total Quantity:�� $��0,0,10,0q�$��1��$��0������ *TotalQuantity+�� $��0,0,2,0q�$��2��$��0��$��10(�$��Center=�Total Unit Cost:�� $��0,0,10,0q�$��3��$��0������ *TotalUnitCost+# [ �� $��10,0,2,0q�$��10(�$��0��$��4��$��Center=�$
��Left=�Total Cost:�� $��0,0,0,0q�$��5��$��0������ *	TotalCost+# [    .  .  $ Column=�$	��260������ *TargetCollection+   $ Stock�� �� .R��� $��3,0,3,0q�$��12(�$
��Wrap=����� *
Stock.Name+  $ Package�� �� .R��� $��5,0,3,0q�$��12(�$
��Wrap=����� *StockPackage.Package.Name+  $ Quantity�� �� .R��� $��5,0,3,0q�$��12(�$��Center=�$
��Wrap=����� *
Quantity+  $ 	Unit Cost�� �� .R��� $��5,0,3,0q�$��12(�$��Right=�$
��Wrap=����� *
UnitCost+# [   $
 Cost�� �� .R��� $��5,0,0,0q�$��12(�$��Right=�$
��Wrap=����� *Cost+# [ �� $��Right=�$��0,3,0,2q�$
 
Horizontal=�.+��� $��9(�$��Clear��$��0,0,2,0q����� *ClearPurchasedStocksCommand+�� $��9(�$��Remove��$��0,0,2,0q����� *RemoveCommand+�� $��1��$��3��$��	0,10,15,0q�$
��Left=�$
 
Horizontal=�.+��� $��15(�$��Clear��$��0,0,2,0q����� *ClearCommand+�� $��15(�$
��Save��$��Right=����� *SaveCommand+= 
 7FirstFloor.ModernUI.Windows.Controls.ModernProgressRing  $��15,0,0,0q�$��40��$��40��   IsActive �� *IsBusy+���� *SelectedItem.Tag+  �� ElementName$  CmbRingStyle��