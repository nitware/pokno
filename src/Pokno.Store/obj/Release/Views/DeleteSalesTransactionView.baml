   M S B A M L   `   `   `  ���� O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.InfrastructurePokno.Infrastructure.Converters   Pokno.Store2   ,Pokno.Store.Views.DeleteSalesTransactionView   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     a	converterKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.Infrastructure       � 	Resources  ;   5Pokno.Infrastructure.Converters.DateToSelectConverter   DateToSelectConverter4   .Pokno.Infrastructure.Converters.MoneyConverter  MoneyConverter8   2Pokno.Infrastructure.Converters.EnabilityConverter  EnabilityConverter;   5Pokno.Infrastructure.Converters.CheckToolTipConverter  CheckToolTipConverter��%<   &	        &	      &	 
     &	              .���� $��Stretch=�{��� *IsLoggedInUserHasRight+ �� Mode$ TwoWay=�.��� -    �Name$ 
LayoutRoot��.+�� $��7q�
������� � ColumnDefinitions �� $��* ��� $��* �.+���  �� CornerRadius$ 20,0,0,0��$��7,0,0,7q�$��0��._��  � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� 
�������$��
10,15,30,3q�$ 5��$��1,1,1,1q�
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
�������$��Center=�$��0��$��1��Sales Batch:�� $��Center=�$��1��$��1��$��0,7,0,0q����� *OutgoingStockBatches+$ TwoWay=� �� SelectedItem �� *OutgoingStockBatch+$ TwoWay=����� .R��� 	 �� Orientation$	 
Horizontal=�.+��� $��0,0,5,0q�$
��Bold"�$��Verdana)����	#FF413E3E���� *
DateSold+
 �� 	Converter#
 [  �� $��Verdana)����� *Customer.Name+�� $��0,3,4,0q�$
��Bold"�
�������$��Center=�$��0��$��2��Receipt No.:�� $��0,3,0,0q�$��1��$��2��$
��Bold"�$��11(�$��20������ *ReceiptNumber+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� -    ��Name$ 	btnSearch��$��0,3,0,0q� �� 	IsDefault . $��3��$��1��$��10(�$��Search��$
��Left=����� *SearchCommand+�� $ 0,0,0,0��$��1��$��	10,7,30,7q�$	��Top=�
�������._��� .+�� $��0,10,0,0q�
������� �� $
��auto ��� $��* ��� $��1��$��0,0,0,4q�$ 10��
�������   $ DimGray��._��� $��	0,15,0,10q�.+��� 
���iii�$��0,0,0,1q�$��	15,2,15,0q�$��Stretch=�._��� PAYMENT TRAY� $��
15,2,15,10q� �� $��85 ���  �� �� .+��� $��0,5,0,5q�$��0��$��0���� $�	Customer:���� $��0,0,0,0q�$��0��$��1��Total Amount:�� $��5,5,0,0q�$��5��$��0��{�.  $
��Bold"����� *Customer.Name+$ TwoWay=��� $��5��$��1��{�.  $
��Bold"�$��5,0,0,0q����� *TargetModel.AmountPaid+#
 [ �� $��0,10,0,0q�$��2��.+��� $
��Bold"�Delete Reason��  �� TextWrapping$
 Wrap=�$��70�� �� 	IsEnabled . ���� *DeleteReason+$ TwoWay=�$ PropertyChanged=��� $��0,3,0,5q�$��3��$��Right=�$	 
Horizontal=�.+��� $��16(�$��Delete������ *DeleteCommand+�� $��1��$��1��$ 0,20,0,0��._��� $��	0,10,15,0q�$	 Vertical=�$��Stretch=�.+�� $��Stretch=� �� �� �� �� �� .+��� $	��Top=�$��0,4,0,2q�
�������$��1��._��  �� �� ��  �� $
��auto ��� $
��auto �.+��� $��0��$��0��$��3��$ 5,5,0,0��
�������._��� $��	15,5,15,0q�.+��� 
���iii�$��0,0,0,1q�$��0,10,0,0q�$��Stretch=�._��� TRANSACTION SUMMARY� $��0,2,0,10q� �� $
��auto ��� �� $
��auto ��� �� $
��auto ���  �� �� �� �� �� �� .+��� $��0,5,0,5q�$��11(�$��0��$��0���� $�Total Price:���� $��11(�$��5,5,0,0q�$��1��$��0��{�.  $
��Bold"����� *TotalSellingPrice+#
 [ �� $��0,0,0,0q�$��0��$��1��$��11(�Receipt No.:�� $��5,0,0,0q�$��1��$��1��$��11(�$
��Bold"����� *ReceiptNumberDisplay+�� $��0,5,5,0q�$��Right=�$��2��$��0��$��11(��� $�Amount Payable:���� $
��Bold"�$��11(�$��5,5,0,0q�$��3��$��0��{�.  ���� *AmountPayable+#
 [ �� $��0,5,0,0q�$��11(�$��0��$��4��$��Right=��� $�Amount Paid:���� $��5,5,0,0q�$��11(�$��5��$��0��{�.  $
��Bold"����� *TotalAmount+$ TwoWay=�#
 [ �� $��10,0,5,0q�$��Right=�$��11(�$��1��$��2��	Discount:�� $��11(�$��3��$��1��{�.  $
��Bold"�$��5,0,0,0q����� *" OutgoingStockBatch.TotalDiscount+#
 [ �� $��11(�$��1��$��4��$��Right=��� $�Balance:���� $��11(�$��5��$��1��{�.  $
��Bold"�$��5,0,0,0q����� *	Balance+#
 [ �� $��2��$��0,0,0,0q����#9EBADF.+��� $��0,2,2,1q�$��Stretch=�._�� $��Center=� �� $��* ��� $��* �&   System.Windows.Controls.DataGrid  -   $��dgModifyPos��{�.     AreRowDetailsFrozen .    AutoGenerateColumns .     HeadersVisibility$ Column=�$��Stretch=�$	��330������ *OutgoingStocks+$ TwoWay=�   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Select��   CellTemplate �� .R��� $	��3,0q�$��18(�$��Center=� d� 	IsChecked �� *
Returned+$ TwoWay=�$ PropertyChanged=�  $ ID�� �� .R��� $	��3,0q�$��12(�$
��Wrap=����� *Id+  $ Package�� �� .R��� $	��3,0q�$��12(�$
��Wrap=����� *&$ShelfStock.StockPackage.Package.Name+  $ Stock�� �� .R��� $	��3,0q�$��12(�$
��Wrap=����� *$"ShelfStock.StockPackage.Stock.Name+  $ Selling Price�� �� .R��� $	��3,0q�$��12(�$��Right=�$
��Wrap=����� *Price.SellingPrice+#
 [   $ Quantity�� �� .R��� $	��3,0q�$��12(�$��Center=�$
��Wrap=����� *
Quantity+