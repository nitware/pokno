   M S B A M L   `   `   `  ���� O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.InfrastructurePokno.Infrastructure.Converters   Pokno.Store'   !Pokno.Store.Views.StockReturnView   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     X TXceed.Wpf.Toolkit, Version=2.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  [	converterKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.Infrastructure  Z VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI    � 	Resources  8   2Pokno.Infrastructure.Converters.EnabilityConverter   EnabilityConverter9   3Pokno.Infrastructure.Converters.VisibilityConverter  VisibilityConverter;   5Pokno.Infrastructure.Converters.DateToSelectConverter  DateToSelectConverter3   -Pokno.Infrastructure.Converters.DateConverter  DateConverter4   .Pokno.Infrastructure.Converters.MoneyConverter  MoneyConverter��%K   &	        &	      &	 
     &	      &	                .���� $��Stretch=�{��� *IsLoggedInUserHasRight+ �� Mode$ TwoWay=�.��� $��2,2,5,2q� � RowDefinitions �� $
��auto ��� $��* �.+��  �� $
��auto ��� $��* �.+��� $��5,5,5,0q� �� Padding$
 15,5q� �� CornerRadius$ 10��
������� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ DimGray��._��� $��0,2,0,10q�.+���  �� Orientation$ Vertical=�.+��� $��Find Transaction��
�������$
��10,5q�$��0��$
��Bold"�$��16(�$��Stretch=�.���� .+��� $��0,0,0,5q�$ 
Horizontal=�.+��� $��Center=�$��Normal"�$	��170��$��12(�Get Sales Transaction By:	� $��0,0,10,0q�$��Normal"�$��12(� 	� 	GroupName$ FindBy��	 d� 	IsChecked	 �� *FindByReceiptNumber+.��Invoice Number	� $
��10,0q�$��Normal"�$��12(�$ FindBy��	 �� *FindByDateRange+.��
Date Range=  7FirstFloor.ModernUI.Windows.Controls.ModernProgressRing  $��15,0,0,0q�$��20��$��20��
   IsActive
 �� *IsBusy+���� *SelectedItem.Tag+ �� ElementName$ CmbRingStyle���� $ 
Horizontal=�.+��� $��0,0,1,0q�$ 
Horizontal=�y��� *FindByReceiptNumber+ �� 	Converter# [ .+��� $��Center=�$	��170��$��Normal"�$��12(�Invoice Number:�� $	��323��$��12(����� *InvoiceNumber+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� $��0,0,1,0q�$ 
Horizontal=�y��� *FindByDateRange+# [ .+��� $ 
Horizontal=�.+��� $��Center=�$��Normal"�$��12(�$	��170��From:(  "System.Windows.Controls.DatePicker  $��0,0,60,0q�$��12(�$��Normal"�$
��Left=�   SelectedDate �� *
FromDate+$ TwoWay=�$ PropertyChanged=��� $ 
Horizontal=�.+��� $��0,0,5,0q�$��Center=�$��Normal"�$��12(�To:  $��12(�$��Normal"�$
��Left=�$��0,0,0,0q� �� *ToDate+$ TwoWay=�$ PropertyChanged=��� $ 
Horizontal=�.+��� -    ��Name$ btnFind��$��0q�$��0q�$��1,0,0,0q�$��2�� �� 	IsDefault .  � Cursor$
 Hand��$��9(� � ToolTip$" Search for sales transaction��$��Right=����� *FindCommand+.���� $��25��$��25��$��UniformToFill=����� *
SearchIcon+�� $��0,5,0,0q�$ 
Horizontal=�.+��� $	��170��$��Normal"�$��12(�Sales Transactions�� $��12(�$��Normal"�$��Center=�$	��350��$��28������ *SoldStockBatches+$ TwoWay=� �� SelectedItem �� *SoldStockBatch+$ TwoWay=�$ PropertyChanged=����� .R��� $ 
Horizontal=�.+��� $��0,0,10,0q�$��12(����	#FF413E3E���� *
DateSold+# [ �� $��12(����	#FF413E3E���� *Customer.Name+� $��1��$��0,10,0,0q� �� $
��auto ��� $
��auto �.+��� $	��5,5q�$ 15q�$ 10��
�������$��1q�
�������   $ DimGray��._��� .+��� $��0,0,0,4q�$ 0q�._��  � ColumnDefinitions �� �� .+��� &$CHOOSE ITEMS TO RETURN FROM THE LIST�� $��1��$��Right=�$ 
Horizontal=�.+��� $��0,0,2,0q�Selected Item Count:�� 
���   �$��20��$ 15��._��� 
�������$��Center=�$��Center=�$
��Bold"����� *SelectedItemCount+$ TwoWay=��� $��10,0,2,0q�Total Item:�� 
���   �$��20��$ 15��._��� 
�������$��Center=�$��Center=�$
��Bold"����� *RecordCount+$ TwoWay=�&	   System.Windows.Controls.DataGrid	   	  AreRowDetailsFrozen .  	  AutoGenerateColumns .   	  GridLinesVisibility$ Vertical=� 	  HeadersVisibility$ Column=�
�������$	��155������ *
SoldStocks+ �� *	SoldStock+ �� SelectedIndex �� *SalesItemSelectedIndex+$ TwoWay=� 	  Columns 4
  .System.Windows.Controls.DataGridTemplateColumn
  ,  &System.Windows.Controls.DataGridColumn   Header$ Select�� 
  CellTemplate �� .R��� $	��3,0q�$��18(�$��Center=�	 �� *
IsSelected+$ TwoWay=�$ PropertyChanged=�
  $ Stock State�� �� .R��� $	��1,0q�$��Normal"����� *StockStates+$ TwoWay=� �� SelectedValue �� *
StockState+$ TwoWay=�$ PropertyChanged=�{��� *	CanReturn+# [  ���� .R��� $ 
Horizontal=�.+��� $��Arial)����	#FF413E3E���� *Name+
  $ Action�� �� .R��� $	��1,0q�$��Normal"����� *	Actions+$ TwoWay=�$ PropertyChanged=� �� *Action+$ TwoWay=�$ PropertyChanged=�{��� *	CanReturn+# [  ���� .R��� $ 
Horizontal=�.+��� $��Arial)����	#FF413E3E���� *Name+
  $ Return Amount�� �� .R�%  Xceed.Wpf.Toolkit.DecimalUpDown  $	��1,0q�$��Center=�$��Center=��  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value �� *ReturnAmount+$ TwoWay=�$ PropertyChanged=�   Maximum �� *Price.SellingPrice+{��� *CanEditReturnAmount+# [  
  $ ID�� �� .R��� $	��3,0q�$��Center=�
���   �$
��Wrap=����� *Id+
  $ Package�� �� .R��� $	��3,0q�$��Center=�
���   �$
��Wrap=����� *&$ShelfStock.StockPackage.Package.Name+
  $
 Item�� �� .R��� $	��3,0q�$��Center=�
���   �$
��Wrap=����� *$"ShelfStock.StockPackage.Stock.Name+
  $	 Qty�� �� .R��� $	��3,0q�$��Center=�$��Center=����� *
Quantity+
  $ Selling Price�� �� .R��� $	��3,0q�$��Center=�$��Right=�
���   �$
��Wrap=����� *Price.SellingPrice+# [ �� $��0,7,0,0q�$��Other Return Information��$��16(�$��
10,10,10,2q�$
��Bold"�.���  �� $
��auto ��� $��* � �� �� �� .+��� $��0��$��0��$��Normal"�$��12(�Date Returned:  $��5,0,0,2q�$��0��$��1��$��12(�$
��Left=�$��Normal"� �� *DateReturned+$ TwoWay=�$ PropertyChanged=��� $��1��$��0��$��Normal"�$��12(�Return Reason:�� $��5,0,0,5q�$��1��$��1��$��Normal"�$��12(�  �� TextWrapping$
  Wrap=�$��35��! �� 	IsEnabled! . ���� *ReturnReason+$ TwoWay=�$ PropertyChanged=��� $��3��$��1��$
��Left=�$ 
Horizontal=�.+��� $��0,2,0,0q�$��Return��$��16(����� *ReturnCommand+  $��10,0,0,0q�$��20��$��20��
 �� *IsBusy+���� *SelectedItem.Tag+$ CmbRingStyle��