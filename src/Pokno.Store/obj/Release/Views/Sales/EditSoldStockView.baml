   M S B A M L   `   `   `  ���� O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.InfrastructurePokno.Infrastructure.Converters   Pokno.Store)   #Pokno.Store.Views.EditSoldStockView   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ]localKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.Infrastructure     X TXceed.Wpf.Toolkit, Version=2.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  Z VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI    � 	Resources  ;   5Pokno.Infrastructure.Converters.DateToSelectConverter   DateToSelectConverter4   .Pokno.Infrastructure.Converters.MoneyConverter  MoneyConverter8   2Pokno.Infrastructure.Converters.EnabilityConverter  EnabilityConverter;   5Pokno.Infrastructure.Converters.CheckToolTipConverter  CheckToolTipConverter��%<   &	        &	      &	 
     &	              .���� $��Stretch=�{��� *IsLoggedInUserHasRight+ �� Mode$ TwoWay=�.��� -    �Name$ 
LayoutRoot��.+�� ���	#E7FBF9F9 � ColumnDefinitions �� $��* ��� $��* �.+���  �� CornerRadius$ 	20, 0,0,0��$��7,7,0,7q�$��0��
�������._��  � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� 
�������$��
15,15,30,3q�$ 5��$��1,1,1,1q�
���iii�$��0�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ DimGray��._�� $��15q� �� $
��auto ��� $	��250 ��� $��* � �� $
��Auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $��3��$��0��$��0��
�������._��� $��	10,7,10,7q�$��11(�$��Century Gothic)�$
��Wrap=�
�������$��Center=�fdPlease select a sales batch or enter Receipt No. then press the enter key or click the Search button�� $��0,3,4,0q�$
��Bold"�
�������$��Center=�$��0��$��1��Sales Batch:�� $ �� IsSynchronizedWithCurrentItem$
 TrueY�$��Center=�$��1��$��1��$��0,7,0,0q����� *OutgoingStockBatches+$ TwoWay=�	 �� SelectedItem	 �� *OutgoingStockBatch+$ TwoWay=����� .R��� 
 �� Orientation$
 
Horizontal=�.+��� $��0,0,5,0q�$
��Bold"�$��Verdana)����	#FF413E3E���� *
DateSold+ �� 	Converter# [  �� $��Verdana)����� *Customer.Name+�� $��0,3,4,0q�$
��Bold"�
�������$��Center=�$��0��$��2��Invoice No.:�� $��1��$��2��$��0,3,0,0q�$ 2��._�� $��0,0,0,0q� �� $
��auto ��� $��* ��� $
��auto �.+��� $��1��$��14(�$
��Bold"�$
��Left=�$	��224������ *	InvoiceNo+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� -    ��Name$ 	btnSearch��$��0q�$��0q�$��1,0,0,0q�$��2�� �� 	IsDefault . $��9(� � ToolTip$" Search for sales transaction��$��Right=����� *SearchCommand+.���� $��25��$��25��$��UniformToFill=����� *
SearchIcon+�� $��1��$��15,10,30,15q�$
 Vertical=�$��Stretch=�.+�� $��Stretch=� �� �� �� �� �� .+��� $	��Top=�$��0,4,0,2q�
�������$��1��._��  �� �� ��  �� $
��auto ��� $
��auto �.+��� $��0��$��0��$��3��$ 5,5,0,0��
�������._��� $��	15,5,15,0q�.+��� 
���iii�$��0,0,0,1q�$��0,2,0,0q�$��Stretch=�._��� $��13(�TRANSACTION SUMMARY� $��0,2,0,5q� �� $
��auto ��� �� $
��auto ��� �� $
��auto ���  �� �� �� �� �� �� .+��� $��0,0,0,0q�$��10(�$��0��$��0���� $�Total Price:���� $��10(�$��5,0,0,0q�$��1��$��0��{�.  $
��Bold"����� *TotalSellingPrice+# [ �� $��Right=�$��0��$��1��$��10(��� $�Amt Payable:���� $
��Bold"�$��10(�$��5,0,0,0q�$��1��$��1��{�.  ���� *AmountPayable+# [ �� $��5,0,0,0q�$��10(�$��0��$��2��$��Right=��� $�	Amt Paid:���� $��5,0,0,0q�$��10(�$��3��$��0��{�.  $
��Bold"����� *TotalAmount+$ TwoWay=�# [ �� $��5,0,0,0q�$��Right=�$��10(�$��1��$��2��	Discount:�� $��10(�$��3��$��1��{�.  $
��Bold"�$��5,0,0,0q����� *" OutgoingStockBatch.TotalDiscount+# [ �� $��10(�$��1��$��4��$��Right=��� $�Balance:���� $��10(�$��5��$��1��{�.  $
��Bold"����� *	Balance+# [ �� $��2��$��0,0,0,0q����#9EBADF.+��� $��0,2,2,1q�$��Stretch=�._�� $��Center=� �� $��* ��� $��* �.+��� $��1��$
 
Horizontal=�$��Right=�.+��� $��Remove��$��10(�$��Right=�$��2,0,0,0q����� *RemoveSoldItemCommand+&   System.Windows.Controls.DataGrid  -   $��dgModifyPos��   AreRowDetailsFrozen .    AutoGenerateColumns .     HeadersVisibility$ Column=�$��Stretch=�$	��250������ *OutgoingStocks+$ TwoWay=�   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Select��   CellTemplate �� .R��� $	��3,0q�$��18(�$��Center=� d� 	IsChecked �� *
Returned+$ TwoWay=�$ PropertyChanged=�  $ ID�� �� .R��� $	��3,0q�$��12(�$
��Wrap=����� *Id+  $ Package�� �� .R��� $	��3,0q�$��12(�$
��Wrap=����� *&$ShelfStock.StockPackage.Package.Name+  $ Stock�� �� .R��� $	��3,0q�$��12(�$
��Wrap=����� *$"ShelfStock.StockPackage.Stock.Name+  $ Selling Price�� �� .R��� $	��3,0q�$��12(�$��Right=�$
��Wrap=����� *Price.SellingPrice+# [   $	 Qty�� �� .R��� $	��3,0q�$��12(�$��Center=�$
��Wrap=����� *
Quantity+�� $ 	0,15,15,0��$��1��$��0,7,7,7q�$	��Top=�
�������._��� .+�� $��	0,10,15,0q�
������� �� $
��auto ��� $��* �.+��� $��0,0,0,10q�$��Customer��
�������$��1��.���� $��15,15q�$��11(�$��23������ *	Customers+$ TwoWay=�	 �� *
Customer+$ TwoWay=�{��� *IsItemInCart+# [ ���� .R��� $
 
Horizontal=�.+��� $��Verdana)����	#FF413E3E���� *
FullName+� $��	0,5,15,10q� ��  �� �� .+��� $��0��$ 5��
�������$��1q�
�������   $ DimGray��._�� .+��� .+��� 
�������
�������$��0,0,0,0q�$��
20,10,20,0q�$��Stretch=�._��� $
��7,10q�ADD PAYMENT� $��
20,5,20,15q� �� $	��100 ���  �� $
��Auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $��0��$��1��$��0,3,0,0q��� $�Payment Mode:���� $��10(�$��1��$��1��$��0,3,0,0q�$��23������ *PaymentTypes+$ TwoWay=�	 �� *PaymentType+{��� *IsItemInCart+# [ ���� .R��� $
 
Horizontal=�.+��� $��Verdana)����	#FF413E3E���� *Name+�� $��0��$��2��$��0,3,0,0q��� $�Amount:��%	  Xceed.Wpf.Toolkit.DecimalUpDown	  $��0,3,0,0q�$��1��$��2��$��22���
  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]] 
  Maximum$ 99999999999999X� 
  Value �� *TargetModel.AmountPaid+$ TwoWay=�# [ {��� *IsItemInCart+# [ �� $��1��$��3��$
��Left=�$��0,5,0,0q�$��9(�$��Add Payment������ *
AddCommand+�� $��1��$��0,7,15,4q�$ 10��
�������._��� $��0,5,0,0q�.+��� $	��5,0q�$��Stretch=�._��  �� $
��Auto ��� $��* �.+��� $
 
Horizontal=�.+��� $��Bottom=��� $�PAYMENT TRAY���� $��2q�$��1��$
 
Horizontal=�$��Right=�.+��� $��10,0,2,0q�$��9(�$��Clear��$��Right=�$��20������ *ClearCommand+�� $��9(�$��Remove Detail��$��Right=�$��20������ *RemoveCommand+   .  .  
�������   GridLinesVisibility$
 None=�$ Column=�$	��120������ *TargetCollection+   $ Amount Paid�� �� .R��� $	��3,0q�$��12(�$
��Wrap=����� *
AmountPaid+# [  ^� ToolTip �� $
��5,10q�
�������y��� *Check+# [ .+�� $
��5,10q� �� ��  �� �� �� �� .+��� $��0,0,0,5q�$��0��$��0��$��2��
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
���  ������ *Cheque.AccountNumber+  $
 Mode�� �� .R��� $	��3,0q�$��12(�$
��Wrap=����� *PaymentType.Name+�� $��0,0,0,15q�$��2��$
��Left=�$
 
Horizontal=�.+��� $��16(�$��Clear������ *ClearUiCommand+�� $��2,0,0,0q�$��16(�$
��Save������ *SaveCommand+=  7FirstFloor.ModernUI.Windows.Controls.ModernProgressRing  $��15,0,0,0q�$��30��$��30��   IsActive �� *IsBusy+���� *SelectedItem.Tag+ �� ElementName$ CmbRingStyle��