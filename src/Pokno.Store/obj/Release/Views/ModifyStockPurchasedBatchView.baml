   M S B A M L   `   `   `  ���� O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.InfrastructurePokno.Infrastructure.Converters   Pokno.Store5   /Pokno.Store.Views.ModifyStockPurchasedBatchView   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  P LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8)prismhttp://www.codeplex.com/prism  WlocalKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.Infrastructure  X	 TXceed.Wpf.Toolkit, Version=2.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit 	   � 	Resources  3   -Pokno.Infrastructure.Converters.DateConverter   DateConverter;   5Pokno.Infrastructure.Converters.CheckToolTipConverter  CheckToolTipConverter;   5Pokno.Infrastructure.Converters.DateToSelectConverter  DateToSelectConverter4   .Pokno.Infrastructure.Converters.MoneyConverter  MoneyConverter��%<   &	        &	      &	 
     &	              .��� -    �Name$ 
LayoutRoot��$��5q����	#E7FBF9F9 � ColumnDefinitions �� ��  � RowDefinitions �� $
��Auto ��� $
��auto �.+��� $��15,10,20,10q�$��0��$��0��$��2�� �� CornerRadius$ 20��
�������$��0,0,1,1q�
������� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ DimGray��._�� $��5q� �� $	��175 ��� $��* �.+��� $��	0,10,5,10q�$��Center=�$��0��$��Right=�$
��Bold"�
�������Purchased Batch:�� $��0,5,30,5q�$��Center=� �� SelectedValuePath$ Id��$��1��$��0������ *StockPurchaseBatches+ �� Mode$ TwoWay=�	 �� SelectedValue	 �� *Id+���� .R��� 
 �� Orientation$
 
Horizontal=�.+��� $��0,0,7,0q�$��Verdana)����	#FF413E3E���� *
Buyer.Name+�� $��Verdana)�$
��Bold"����	#FF413E3E���� *DatePurchased+ �� 	Converter# [ � $��0,5,0,10q�$��0��$��1�� �� $
��Auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $��	15,0,15,5q�$��1��$ 25,0,0,0��
�������$��1,1,0,1q�
���iii�   $ DimGray��._��� $��
25,5,25,10q�$ 	15,0,0,15��$��0q�
�������._��� .+��� 
�������$��0,0,0,0q�$��
10,10,10,5q�
�������$��Stretch=�._��� $
��15,5q�$��Center=�$��13(�
�������$
��Bold"�BATCH� $��
20,5,10,10q� �� $	��150 ���  �� $
��Auto ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $
��Bold"�$��0��$��0��	Supplier:�� $ Id��$
��Left=�$��1��$��0��$	��200��$��0,3,0,0q�$��23������ *	Suppliers+$ TwoWay=�	 �� *Id+���� .R��� $
 
Horizontal=�.+��� $��Verdana)����	#FF413E3E���� *
FullName+�� $
��Bold"�$��0��$��1��$��0,3,0,0q�Buyer:�� $ Id��$
��Left=�$��1��$��1��$	��200��$��0,3,0,0q�$��23������ *Buyers+$ TwoWay=�	 �� *Id+���� .R��� $
 
Horizontal=�.+��� $��Verdana)����	#FF413E3E���� *
FullName+�� $
��Bold"�$��0��$��2��$��0,3,0,0q�Date Purchased:(  "System.Windows.Controls.DatePicker  $��1��$��2��$��23��$
��Left=�$��0,3,0,0q�$	��Top=�$	��200��   SelectedDate �� *" StockPurchaseBatch.DatePurchased+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� $
��Bold"�$��0��$��3��Amount Payable:% 	 Xceed.Wpf.Toolkit.IntegerUpDown  $��0,3,0,0q�$��1��$��3��$	��200��$
��Left=�� 	 �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value �� **(StockPurchaseBatch.Payment.AmountPayable+$ TwoWay=��� $
��Bold"�$��0��$��4��$��0,3,0,0q�Misc. Expenses:%	 	 Xceed.Wpf.Toolkit.DecimalUpDown	  $��0,3,0,0q�$��1��$��4��$	��200��$
��Left=��
 	 �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]] 
  Maximum$ 99999999999999X� 
  Value �� *!StockPurchaseBatch.MiscExpenses+$ TwoWay=��� $
��Bold"�$��0��$��5��$��0,3,0,0q�Invoice Number:�� $��0,3,0,0q�$��1��$��5��$	��200��$
��Left=����� *" StockPurchaseBatch.InvoiceNumber+$ TwoWay=�� $��2��$��0��$��	15,5,15,0q� �� �� .+��� 
�������$ 0,0,0,25��
���iii�$��1q�   $ DimGray��._��� $��
25,5,25,10q�$ 
0,15,15,15��$��2��$��0q�
�������._��� .+��� 
�������$��0,0,0,0q�$��
10,10,10,5q�
�������$��Stretch=�._��� $
��15,5q�$��Center=�$��13(�
�������$
��Bold"�PAYMENT DETAILS� $
��20,5q� �� $	��150 ���  �� $
��Auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+�	  $��0,3,0,0q�$��1��$��1��$	��200��$��22��$
��Left=�$	��Top=�$ 99999999999999X� �� *TargetModel.AmountPaid+$ TwoWay=��� $
��Bold"�$��0��$��1��$��0,3,0,0q�Amount Paid:�� $
��Bold"�$��0��$��2��$��0,3,0,0q�
Date Paid:  $��1��$��2��$��23��$
��Left=�$��0,3,0,0q�$	��Top=�$	��200�� �� *TargetModel.PaymentDate+$ TwoWay=�$ PropertyChanged=��� $
��Bold"�$��0��$��3��$��0,3,0,0q�Payment Type:�� $ Id��$��10(�$
��Left=�$��1��$��3��$	��200��$��0,3,0,0q�$��23������ *PaymentTypes+$ TwoWay=�	 �� *Id+���� .R��� $
 
Horizontal=�.+��� $��Verdana)����	#FF413E3E���� *Name+�� $��4��$��1��$
��Left=�$��0,8,0,0q�$
 
Horizontal=�.+��� $��0,0,2,0q�$��9(�$��
Add Detail������ *
AddCommand+� $��	10,0,10,0q�.+��� 
�������
�������$��0,0,0,0q�._��� .+��� $��0,2,0,2q�
�������$��0,2,0,0q����#EFEFEF$��Stretch=�._��� $��3q�$��Center=�PAYMENT DETAILS TRAY&   System.Windows.Controls.DataGrid     AreRowDetailsFrozen .    AutoGenerateColumns .     GridLinesVisibility$
 None=�   HeadersVisibility$ Column=�$��0,0,0,4q�$	��100������ *TargetCollection+   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Amount Paid��   CellTemplate �� .R��� $	��5,0q�$��12(�$
��Wrap=����� *
AmountPaid+# [  ^� ToolTip �� $
��5,10q�
�������y��� *Check+# [ .+�� $
��5,10q� �� ��  �� �� �� �� .+��� $��0,0,0,5q�$��0��$��0��$��2��
���   �$��0,0,0,1q�._��� $
��Bold"�$��Center=�$��Expanded&�CHECK DETAILS�� $��0,0,5,0q�$��0��$��1��$
��Bold"�$��Right=�
�������Bank:�� $��1��$��11(�$��Italic$�$��1��
���  ������ *Check.Bank.Name+�� $��0,0,5,0q�$��0��$��2��$
��Bold"�$��Right=�
�������	Check No:�� $��1��$��11(�$��Italic$�$��2��
���  ������ *Check.CheckNumber+�� $��0,0,5,0q�$��0��$��3��$
��Bold"�$��Right=�
�������Account No:�� $��1��$��11(�$��Italic$�$��3��
���  ������ *Check.AccountNumber+  $ 	Date Paid�� �� .R��� $	��5,0q�$��12(�$
��Wrap=����� *PaymentDate+# [    $ Payment Type�� �� .R��� $	��5,0q�$��12(�$
��Wrap=����� *PaymentType.Name+�� $��	10,0,10,5q�$
 
Horizontal=�$��Right=�.+��� $��9(�$��Clear��$��0,0,2,0q����� *ClearCommand+�� $��9(�$��Delete������ *RemoveCommand+�� $��3��$��	0,10,10,0q�$��Right=�$
 
Horizontal=�.+��� $��15(�$
��Save��$��Right=����� *SaveCommand+�� $��1��$��1��$��
15,5,20,10q�$	��Top=�
�������$ 	0,20,20,0��
�������$��1q�   $ DimGray��._��� .+��� .+��� $��
25,15,25,0q�$ 0,10,0,0��
�������$��Stretch=�._��� $	��0,8q�$��Center=�
�������$��13(�$
��Bold"�CHOOSE PRODUCT�� $
��25,2q� �� Padding$
 10,5q�
�������$��1q�._�� $��	20,0,20,5q� �� $��68 ��� $	��180 � �� $
��Auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $
��Bold"�$��0��$��0��$��0,3,0,0q�Stock:�� $ Id��$��0��$��1��$��0,3,0,0q����� *Stocks+$ TwoWay=�	 �� *Id+���� .R��� $
 
Horizontal=�.+��� $��Verdana)����	#FF413E3E���� *Name+�� $
��Bold"�$��0��$��1��$��0,3,0,0q�
Package:�� $
��Bold"�$��0��$��2��$��0,3,0,0q�
Unit Cost:	  � 	 �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   FormatString$ #,0.00��{�.  $��0,3,0,0q�$��22��$��1��$��2��$ 99999999999999X� 
  Minimum$ 0X�� 	 �Xceed.Wpf.Toolkit.CommonNumericUpDown`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   ParsingNumberStyle$ AllowThousands=� �� *TargetModel.UnitCost+$ TwoWay=��� $
��Bold"�$��3��$��0,3,0,0q�$��22��$	��Top=�	Quantity:  � 	 �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   FormatString$	 #,0��$��0,3,0,0q�$��22��$��1��$��3�� �� *TargetModel.Quantity+$ TwoWay=��� $
��Bold"�$��0��$��4��$��0,3,0,0q�Cost:	  $ #,0.00��$��0,3,0,0q�$��22��$��1��$��4��$ 99999999999999X� �� *TargetModel.Cost+$ TwoWay=��� $ Id��$��1��$��1��$��0,3,0,0q����� *StockPackages+$ TwoWay=�	 �� *Id+���� .R��� $
 
Horizontal=�.+��� $��Verdana)����	#FF413E3E���� *Package.Name+�� $��5��$��1��$
��Left=�$��0,5,0,0q�$
 
Horizontal=�.+��� $��9(�$	��Add������ *
AddCommand+�� $��2��.+��� $
 Vertical=�$��25,10, 25,15q�.+��� $��0,0,0,0q�$ 5,5,0,5��._��� .+��� 
�������$��Stretch=�._��� $	��0,7q�$��Center=�
�������$��13(�$
��Bold"�PURCHASED PRODUCT TRAY�� $	��0,1q����#e0eaf6$��1��$��2��$��0��._��  �� �� ��  �� $
��auto �.+��� $	��0,0q�$��0��$��0��$��3��$��1q�._��� .+�� $��5,2,5,2q� �� $
��auto ��� �� $
��auto ��� �� $
��auto ���  �� �� �� �� �� �� .+��� $��0,0,2,0q�$��10(�$��0��$��0��$��Center=�Total Quantity:�� $��0,0,10,0q�$��1��$��0������ *TotalQuantity+�� $��0,0,2,0q�$��2��$��0��$��10(�$��Center=�Total Unit Cost:�� $��0,0,10,0q�$��3��$��0������ *TotalUnitCost+# [ �� $��10,0,2,0q�$��10(�$��0��$��4��$��Center=�$
��Left=�Total Cost:�� $��0,0,0,0q�$��5��$��0������ *	TotalCost+# [    .  .  $ Column=�$	��290������ *TargetCollection+   $ Stock�� �� .R��� $��3,0,3,0q�$��12(�$
��Wrap=����� *
Stock.Name+  $ Package�� �� .R��� $��5,0,3,0q�$��12(�$
��Wrap=����� *StockPackage.Package.Name+  $ Quantity�� �� .R��� $��5,0,3,0q�$��12(�$��Center=�$
��Wrap=����� *
Quantity+  $ 	Unit Cost�� �� .R��� $��5,0,3,0q�$��12(�$��Right=�$
��Wrap=����� *
UnitCost+# [   $
 Cost�� �� .R��� $��5,0,0,0q�$��12(�$��Right=�$
��Wrap=����� *Cost+# [ �� $
��Left=�$��0,3,5,2q�$
 
Horizontal=�.+��� $��9(�$��Clear��$��0,0,2,0q����� *ClearPurchasedStocksCommand+�� $��9(�$��Remove��$��0,0,2,0q����� *RemoveCommand+