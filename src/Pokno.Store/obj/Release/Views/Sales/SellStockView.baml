   M S B A M L   `   `   `  ���� O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.InfrastructurePokno.Infrastructure.Converters  p lSystem.Windows.Controls.Input.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35pTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.ToolkitSystem.Windows.Controls  Pokno.Store%   Pokno.Store.Views.SellStockView   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     P LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8)prismhttp://www.codeplex.com/prism  c	 _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity 	 [	converterKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.Infrastructure 	 X
 TXceed.Wpf.Toolkit, Version=2.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit 
 cControlsTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.Toolkit 
 Z VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI    � 	Resources  8   2Pokno.Infrastructure.Converters.EnabilityConverter   EnabilityConverter;   5Pokno.Infrastructure.Converters.ReorderLevelConverter  ReorderLevelConverter;   5Pokno.Infrastructure.Converters.CheckToolTipConverter  CheckToolTipConverter4   .Pokno.Infrastructure.Converters.MoneyConverter  MoneyConverterE   ?Pokno.Infrastructure.Converters.ReorderLevelFontWeightConverter # ReorderLevelFontWeightConverter  AutoCompleteBoxItemTemplate �� Orientation  GotFocusColor �� Color  LostFocusColor % !UnsoldStockPackagesAtHandTemplate �� Mode �� 	Converter ^� ToolTip 	 UnsoldStockPackagesTemplate �� ItemTemplate �� ItemsSource &
 "StockPurchasedTreeViewItemTemplate��%N  &	        &	      &	 
     &	      &	      &	      &	 {     &	 �     &	 �     7  7  7  7  7  7  7  7  7  7  &		 �    7  &	
 &    7 	           �� .R��� $ 
Horizontal=�.+��� $	��5,2q�$	��100��$
��Bold"�
����������� *Name+�� $ Green���� $ Transparent���� .R��� $ 
Horizontal=�.+��� $��0,0,5,0q�$��Center=����� *
Quantity+$ TwoWay=����� *ReorderLevel+8   ���� *ReorderLevel+8  �� $��0,0,0,0q�$��Center=����� *StockPackage.Package.Name+���� *ReorderLevel+8  ���� *ReorderLevel+8   �� $ 
Horizontal=�.+��� $��0,0,4,0q��� $�Re-Order Level:���� ���� *StockPackage.ReOrderLevel+�� $��0,0,5,0q�$��,��$��Center=����� *ReorderLevel+8  ���� *ReorderLevel+8  �� $��0,0,5,0q�$
��ROL:��$��Center=����� *ReorderLevel+8  ���� *ReorderLevel+8  �� $��0,0,5,0q�$��Center=����� *StockPackage.ReOrderLevel+���� *ReorderLevel+8  ���� *ReorderLevel+8 	 �� 8    �� *Shelfs+$ TwoWay=�.R��� $ 
Horizontal=�.+��� $��0,0,5,0q�$��13(�$
��Bold"�
����������� *
Stock.Name+�� 8    �� *UnsoldStockPackages+.R��� $ 
Horizontal=�.+��� $��0,0,5,0q�$
��Bold"�$��12(����� *StockType.Name+.���� $��Stretch=�{��� *IsLoggedInUserHasRight+$ TwoWay=�.��� -    �Name$ 
LayoutRoot��$��3q����� 	 �� EndPoint$	 0.5,1&�
 �� 
StartPoint$
 0.5,0&�.���  � Color$ 	#FFf2fafd�� � Offset$
 0.85Q�� $ 	#FFe4f6fa��$ 1Q�� $ 	#FFe7f4fc��$	 0.3Q�� $ 	#FFa9cde7��$ 0Q� � RowDefinitions �� $��0* ��� .+�� $��2�� � ColumnDefinitions �� $��3* ��� $��5* �.+�� $��1�� �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto � �� .+��� $	��Top=� �� CornerRadius$ 2��$��5,5,7,10q�
�������$��1��$��2��$��0�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ DimGray��._��  �� �� ��  �� $
��auto ��� $
��auto �.+��� $��5q�$��0��$��0��$��3��$ 10��._��� $��Cart Summary��$��13(�.���� .+�� $��5,2,5,5q� �� $
��auto ��� $��* ��� $
��auto ��� $��* ��� $
��auto ��� $��* � �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $��0,3,4,0q�$��0��$��0��$��10(�$��Right=�Total Item:�� $��0,3,10,0q�$��1��$��0��$
��Bold"�$��10(����� *CartItemCount+�� $��0,3,4,0q�$��0��$��1��$��10(�$��Right=��� $�
Sub Total:���� $��0,3,10,0q�$��1��$��1��{�.  $
��Bold"�$��10(����� *
SubTotal+# [ �� $��0,3,4,0q�$��2��$��0��$��10(�$��Right=�Amount Payable:�� $��0,3,10,0q�$��10(�$
��Bold"�$��3��$��0��{�.  ���� *
NetTotal+$ TwoWay=�# [ �� $��10,3,4,0q�$��10(�$��0��$��4��$��Right=�	Discount:�� $��0,3,0,0q�$
��Bold"�$��10(�$��5��$��0������ *
Discount+# [ �� $��10,3,4,0q�$��10(�$��1��$��2��$��Right=�Amount Paid:�� $��0,3,10,0q�$��3��$��1��{�.  $
��Bold"�$��10(����� *PaymentDetail.AmountPaid+# [ �� $��10,3,4,0q�$��10(�$��1��$��4��$��Right=�
Balance:�� $��0,3,10,0q�$
��Bold"�$��10(�$��5��$��1��{�.  ���� *	Balance+# [ �� $��1��$��1��$��5,0,7,5q�._��� $ 2,2,7,7��
�������._��� .+�� $��0,2,0,0q� �� $
��Auto ��� $��* ��� $
��auto �.+��� $��7,3,0,3q�$ 
Horizontal=�.+��� $��0,0,3,0q�$
��Bold"�$��11(�
�������$��Center=�	Discount:% 
 Xceed.Wpf.Toolkit.DecimalUpDown  � 
 �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Maximum$ 99999999999999X�   Minimum$ 0X�$��50��$��Center=�   Value �� *
Discount+$ TwoWay=�{��� *IsItemInCart+# [  �� $��5,3,2,3q�$��2��$ 
Horizontal=�$��Center=�$��Right=�.+��� $��2,0,2,0q�$��9(�$
��15,0q� � ToolTip$ Change Stock Price��$��20��$��Change Stock Price������ *ChangePriceCommand+�� $��0,0,1,0q�$
��15,0q�$��9(�$��Remove Cart Item��$��20������ *RemoveCartItemCommand+�� $��0,0,2,0q�$
��15,0q�$��9(�$��
Clear Cart��$��20������ *ClearCartCommand+&	   System.Windows.Controls.DataGrid	  -    	 Name$ cartDataGrid�� 	  AlternatingRowBackground �	#1BFF0000 	  AreRowDetailsFrozen .  	  AutoGenerateColumns .  $��0,0,0,0q� 	  GridLinesVisibility$
 None=� 	  HeadersVisibility$ Column=�
�������$	��250������ *StocksForSale+ �� SelectedItem �� *StockForSale+ �� SelectedIndex �� *CartDataGridSelectedIndex+$ TwoWay=�.
 	 (System.Windows.Interactivity.Interaction 
  Triggers / 	 )System.Windows.Interactivity.EventTrigger     	EventName$ SelectionChanged��. 	 (System.Windows.Interactivity.TriggerBase    Actions.  6 	 0System.Windows.Interactivity.InvokeCommandAction  !   Command! �� *SelectionChangedCommand+"   CommandParameter" �� *SelectedItem+# �� ElementName$# cartDataGrid��$ OneWay=�$ 	  Columns$ 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn%   Header$
% Item��&   CellTemplate& �� .R��� $	��3,0q�$
��11.5(�$��Center=�
���   �$
��Wrap=����� *StockPackage.Stock.Name+  $% Package��& �� .R��� $	��3,0q�$
��11.5(�$��Center=�
���   �$
��Wrap=����� *StockPackage.Package.Name+  $% Price��& �� .R��� $	��3,0q�$
��11.5(�$��Right=�$��Center=�
���   �$
��Wrap=����� *StockPrice.SellingPrice+$ TwoWay=�# [   $% Quantity��& �� .R�% 
 Xceed.Wpf.Toolkit.IntegerUpDown  $��Center=�
���   �$��1��$��3��� 
 �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]'   Minimum$' 1X�(   Value( �� *
Quantity+$ TwoWay=�) �� UpdateSourceTrigger$) PropertyChanged=�  $% Total Price��& �� .R��� $	��3,0q�$
��11.5(�$��Right=�$��Center=�
���   �$
��Wrap=����� *TotalSellingPrice+$ TwoWay=�# [ �� $��5,3,7,9q�$ 2��
�������$��1��$��2��   $ DimGray��._��� .+��� $��
10,10,10,0q�
�������._�� $��
10,7,10,10q�$��0��$��2�� �� $
��Auto ��� $��* � �� $
��auto ��� $��25 �.+��� $��0,0,2,0q�$��11(�$
��Bold"�
�������$��0��$��0��Transaction Date(  "System.Windows.Controls.DatePicker  $��0,0,2,0q�$��22��$��0q�$��1��*   SelectedDate* �� *
DateSold+$ TwoWay=�{��� *IsDateSoldEnabled+# [  �� $��11(�
�������$
��Bold"�$��1��$��0��
Customer�� $��1��$��1��$��Center=�$+ �� IsSynchronizedWithCurrentItem$
+ TrueY����� *	Customers+$ TwoWay=�{��� *IsItemInCart+# [   �� *
Customer+$ TwoWay=�$) PropertyChanged=����� .R��� ���	#FF413E3E���� *
FullName+� $��
10,5,10,10q� �� ��  �� �� .+��� $��1��$��0��$��0,0,5,0q�$ 0,0,8,8��
�������$��1q�
�������._�� $��0,0,0,0q�.+��� $��0q�$��2��
�������.+��� 
�������$��	0,0,0,1.5q�$��	10,5,10,0q�$��Stretch=�._��� 	PAYMENT� $��	10,2,10,5q� �� $	��100 ���  �� $
��Auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $��0��$��1��$��0,3,0,0q�$��11(��� $�Payment Mode:���� $
+ TrueY�$��Center=�$��10(�$��1��$��1��$��0,3,0,0q�$��23������ *PaymentTypes+$ TwoWay=�{��� *IsItemInCart+# [   �� *PaymentType+$ TwoWay=�$) PropertyChanged=����� .R��� ���	#FF413E3E���� *Name+�� $��0��$��2��$��0,3,0,0q�$��11(��� $�Amount:��  $��0,3,0,0q�$��1��$��2��$��22��$ 99999999999999X� �� *
AmountPaid+$ TwoWay=�{��� *IsItemInCart+# [  �� $��1��$��3��$
��Left=�$��0,3,0,0q�$��9(�$��Add Payment��$��22������ *AddPaymentCommand+�� $ 0,0,7,7��$��1��$��1��
�������._��� .+��� , �� Padding$, 2q�$��Stretch=�._��  �� $
��Auto ��� $��* �.+��� $ 
Horizontal=�$��5,0,0,0q�.+��� $��Bottom=��� $�PAYMENT TRAY���� $��2q�$��1��$ 
Horizontal=�$��Right=�.+��� $��10,0,2,0q�$��9(�$��Clear��$��Right=�$��20������ *ClearCommand+�� $��9(�$��Remove��$��Right=�$��20������ *RemoveCommand+	   .  .  
�������$
 None=�$ Column=�$��80������ *PaymentDetails+$   $% Amount Paid��& �� .R��� $��12(�$��5,0,0,0q�$
��Wrap=����� *
AmountPaid+# [  �� $
��5,10q�
�������y��� *Check+# [ .+�� $
��5,10q� �� ��  �� �� �� �� .+��� $��0,0,0,5q�$��0��$��0��$��2��
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
���  ������ *Cheque.AccountNumber+  $
% Mode��& �� .R��� $��12(�$
��Wrap=����� *PaymentType.Name+�� $��3��$��1��$��5,0,5,10q�$ 
Horizontal=�$
��Left=�.+��� $��0,0,0,0q�$
��Sell��$��Right=�$��18(����� *SaveCommand+=  7FirstFloor.ModernUI.Windows.Controls.ModernProgressRing  $��15,0,0,0q�$��40��$��40��-   IsActive- �� *IsBusy+���� *SelectedItem.Tag+$# CmbRingStyle���� $��	5,5,10,10q�
�������$ 2��$��0��$��4��$��0��   $ DimGray��._��� .+��� $��0��$��8,8,8,3q�$, 2q�$ 2��
�������$��1q�
�������._�� $��0,0,0,0q� �� $
��auto ��� $��* ��� $
��auto �.+��� $��1q�$��25��$��25��$��UniformToFill=����� *
SearchIcon+-  'System.Windows.Controls.AutoCompleteBox  $��1��
�������$��1q�.   ValueMemberPath$
. Name��/   ItemTemplate#/ [ 0   IsTextCompletionEnabled0 . 1   ItemsSource1 �� *Stocks+2   SelectedItem2 �� *Stock+$ TwoWay=�$) PropertyChanged=��� $��1,0,0,0q�$��2��$��9(�$	��...��$ Re-load stocks on shelf��$��Right=����� *ReloadCommand+�� $	��8,0q�$��Stretch=�
�������._��� $��10,5,0,5q�$
��Left=�$
��Bold"�
�������$��15(�STOCK ON SHELF�� $	��8,0q�._�R� -   3 R�Name$3 treeView��$	��530��
����������	#FFF8ACB4$��0q�$��Stretch=�$
��Auto=�#��[
 ���� *StocksOnShelfAtHand+$ TwoWay=�   $ SelectedItemChanged��.    ! �� *$"TreeViewSelectedItemChangedCommand+" �� *SelectedItem+$# treeView��$ OneWay=�