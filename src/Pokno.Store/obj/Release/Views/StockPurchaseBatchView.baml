   M S B A M L   `   `   `  ���� O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.InfrastructurePokno.Infrastructure.Converters   Pokno.Store.   (Pokno.Store.Views.StockPurchaseBatchView   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  P LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8)prismhttp://www.codeplex.com/prism  WlocalKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.Infrastructure  OtoolkitAhttp://schemas.microsoft.com/winfx/2006/xaml/presentation/toolkit  X	 TXceed.Wpf.Toolkit, Version=2.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit 	   � 	Resources  3   -Pokno.Infrastructure.Converters.DateConverter   DateConverter;   5Pokno.Infrastructure.Converters.CheckToolTipConverter  CheckToolTipConverter4   .Pokno.Infrastructure.Converters.MoneyConverter  MoneyConverter��%-   &	        &	      &	 
           .���� $��Stretch=�{��� *IsLoggedInUserHasRight+ �� Mode$ TwoWay=�.��� -    �Name$ 
LayoutRoot��$��5q����	#E7FDFDFD.+�� $��7,2,0,10q� � RowDefinitions �� $
��Auto ��� $
��auto ��� $
��auto ��� $
��auto � � ColumnDefinitions �� �� .+��� $��0,10,0,0q�
�������
�������$��1q� �� CornerRadius$ 5��$��0��$��0�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ DimGray��._��� $	��0,5q�$��Center=�$��Center=� �� Orientation$ 
Horizontal=�.+��� $
��10,0q�$
��Bold"�$��Center=�$��15(��� $�Balance:���� $
��Bold"�$��Center=�$��15(�
���  ������ *	Balance+�� $��1��$��0,10,0,0q�
�������$��1q�$ 9��
���iii�._��� $��5q�
�������$��0q�$ 8��
�������._��� .+��� 
�������$ 5��$��0,0,0,0q�$��5,5,5,0q�
�������$��Stretch=�._��� $
��15,0q�$��Center=�$��13(�$
��Bold"��� $�BATCH��� $��5,5,5,10q� �� $	��110 ��� $	��150 � �� $
��Auto ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $
��Bold"�$��0��$��0���� $�	Supplier:���� $��1��$��0��$��0,3,0,0q�$��23������ *	Suppliers+$ TwoWay=�	 �� SelectedItem	 �� *
Supplier+$ TwoWay=����� .R��� $ 
Horizontal=�.+��� $��Verdana)����	#FF413E3E���� *
FullName+�� $
��Bold"�$��0��$��1��$��0,3,0,0q��� $�Buyer:���� $��1��$��1��$��0,3,0,0q�$��23������ *Buyers+$ TwoWay=�	 �� *Buyer+$ TwoWay=����� .R��� $ 
Horizontal=�.+��� $��Verdana)����	#FF413E3E���� *
FullName+�� $
��Bold"�$��0��$��2��$��0,3,0,0q��� $�Date Purchased:��(  "System.Windows.Controls.DatePicker  $��1��$��2��$��23��$��0,3,0,0q�
   SelectedDate
 �� *" StockPurchaseBatch.DatePurchased+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� $
��Bold"�$��0��$��3���� $�Amount Payable:��% 	 Xceed.Wpf.Toolkit.DecimalUpDown  $��0,3,0,0q�$��1��$��3��$��22��$	��Top=�� 	 �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Maximum$ 99999999999999X�   Value �� *Payment.AmountPayable+$ TwoWay=��� $
��Bold"�$��0��$��4��$��0,3,0,0q��� $�Misc. Expenses:��  $��0,3,0,0q�$��1��$��4��$��22��$	��Top=�$ 99999999999999X� �� *!StockPurchaseBatch.MiscExpenses+$ TwoWay=��� $
��Bold"�$��0��$��5��$��0,3,0,0q��� $�Invoice Number:���� $��0,3,0,0q�$��1��$��5������ *" StockPurchaseBatch.InvoiceNumber+$ TwoWay=��� $��2��$��0,10,0,0q�
�������
���iii�$��1q�$ 9��._��� $��2��$��5q�
�������$��0q�$ 8��
�������._��� .+��� 
�������$ 5��$��0,0,0,0q�$��5,5,5,0q�
�������$��Stretch=�._��� $
��15,0q�$��Center=�$��13(�$
��Bold"��� $�PAYMENT DETAILS��� $
��5,10q� �� $	��110 ��� $	��150 � �� $
��Auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $
��Bold"�$��0��$��1��$��0,3,0,0q��� $�Amount Paid:��  $��0,3,0,0q�$��1��$��1��$��22��$	��Top=�$ 99999999999999X� �� *TargetModel.AmountPaid+$ TwoWay=��� $
��Bold"�$��0��$��2��$��0,3,0,0q��� $�
Date Paid:��  $��1��$��2��$��23��$��0,3,0,0q�
 �� *TargetModel.PaymentDate+$ TwoWay=�$ PropertyChanged=��� $
��Bold"�$��0��$��3��$��0,3,0,0q��� $�Payment Type:���� $��10(�$��1��$��3��$��0,3,0,0q�$��23������ *PaymentTypes+$ TwoWay=�	 �� *PaymentType+$ TwoWay=����� .R��� $ 
Horizontal=�.+��� $��Verdana)����	#FF413E3E���� *Name+�� $��4��$��1��$
��Left=�$��0,3,0,0q�$ 
Horizontal=�.+��� $��0,0,2,0q�$��9(�$��
Add Detail��$��Right=����� *
AddCommand+� $��0,0,0,0q�.+��� 
�������
�������$��0,0,0,0q�._��� .+��� $��0,2,0,0q�
�������$��0,2,0,0q����#EFEFEF$��Stretch=�._��� $	��0,0q�$��Center=��� $�PAYMENT DETAILS TRAY��&   System.Windows.Controls.DataGrid     AreRowDetailsFrozen .    AutoGenerateColumns .     GridLinesVisibility$
 None=�   HeadersVisibility$ Column=�$��0,1,0,4q�$��80������ *TargetCollection+   Columns 4	  .System.Windows.Controls.DataGridTemplateColumn	  ,
  &System.Windows.Controls.DataGridColumn 
  Header$ Amount Paid�� 	  CellTemplate �� .R��� $��12(�$
��Wrap=����� *
AmountPaid+ �� 	Converter# [  ^� ToolTip �� $
��5,10q�
�������y��� *Check+# [ .+�� $
��5,10q� �� ��  �� �� �� �� .+��� $��0,0,0,5q�$��0��$��0��$��2��
���   �$��0,0,0,1q�._��� $
��Bold"�$��Center=�$��Expanded&��� $�CHECK DETAILS���� $��0,0,5,0q�$��0��$��1��$
��Bold"�$��Right=�
��������� $�Bank:���� $��1��$��11(�$��Italic$�$��1��
���  ������ *Check.Bank.Name+�� $��0,0,5,0q�$��0��$��2��$
��Bold"�$��Right=�
��������� $�	Check No:���� $��1��$��11(�$��Italic$�$��2��
���  ������ *Check.CheckNumber+�� $��0,0,5,0q�$��0��$��3��$
��Bold"�$��Right=�
��������� $�Account No:���� $��1��$��11(�$��Italic$�$��3��
���  ������ *Check.AccountNumber+	  $ 	Date Paid�� �� .R��� $��12(�$
��Wrap=����� *PaymentDate+# [  	  $ Payment Type�� �� .R��� $��12(�$
��Wrap=����� *PaymentType.Name+�� $��9(�$��0,3,5,7q�$��Delete��$��20��$��Right=����� *RemoveCommand+�� $��	15,10,7,0q�$��0��$��1��$��4��$��0,0,2,2q�$ 14��
�������   $ DimGray��._��� .+��� 
�������$��7,5,7,0q�$��0,0,0,0q�
�������$��Stretch=�._��� $
��15,0q�$��Center=�$��13(�$
��Bold"��� $�SUPPLIER PAYMENT HISTORY��� $��Stretch=�$��0,0,0,0q�.+��� 
�������._�   .  .     RowDetailsVisibilityMode$ 	Collapsed=�$ Column=�$��7,0,7,0q�$	��520������ *SupplierPaymentHistory+ 	  $ Amt Payable�� �� .R��� $��12(�$
��Wrap=����� *TransactionDate+# [  	  $ Amt Paid�� �� .R��� $��12(�$
��Wrap=����� *
AmountPaid+# [ 	  $
 Type�� �� .R��� $��12(�$
��Wrap=����� *PaymentType+�� $��3��$��Right=�$��0,4,0,0q�$ 
Horizontal=�.+��� $��Clear��$��28��$��Right=�$��0,0,2,0q�$	��Top=�$��68������ *ClearCommand+�� $
��Save��$��28��$��Right=�$	��Top=�$��68������ *SaveCommand+