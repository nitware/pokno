   M S B A M L   `   `   `  ����O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.InfrastructurePokno.Infrastructure.Converters  5       Pokno.Store'   !Pokno.Store.Views.StockReturnView   5      U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TXceed.Wpf.Toolkit, Version=2.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      [	converterKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.Infrastructure  5      Z VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI  5        � 	Resources  5      8   2Pokno.Infrastructure.Converters.EnabilityConverter   EnabilityConverter9   3Pokno.Infrastructure.Converters.VisibilityConverter  VisibilityConverter;   5Pokno.Infrastructure.Converters.DateToSelectConverter  DateToSelectConverter3   -Pokno.Infrastructure.Converters.DateConverter  DateConverter4   .Pokno.Infrastructure.Converters.MoneyConverter  MoneyConverter��%�   &	        &	      &	 &     &	 9     &	 L       5   
   6'     5   
   6(     5   
   6*     5   
   6"     5   
   6#   5      .��5      �� $��Stretch=�6O   {�6   �� *IsLoggedInUserHasRight+ �� Mode$ TwoWay=�.��5   
   � $��2,2,5,2q�6    � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $��* �6    .+�5      �  5      �� 5      $
��auto �6$   �� 5      $��* �6$   .+�5"      �� $��5,5,5,0q�6    �� Padding$
 15,5q�6*    �� CornerRadius$ 10��69   
������� J� Effect 5#      3  -System.Windows.Media.Effects.DropShadowEffect  5$         Color$ DimGray��6+   ._�5'      �� $��0,2,0,10q�6!   .+�5(      ��  �� Orientation$ Vertical=�6%   .+�5*      �� $��Find Transaction��6'   
�������$
��10,5q�6T   $��0��6c   $
��Bold"�6p   $��16(�6�   $��Stretch=�6�   .��5+   "   �� .+�5-   &   �� $��0,0,0,5q�61   $ 
Horizontal=�6B   .+�5.   *   �� $��Center=�64   $��Normal"�6O   $	��170��6c   $��12(�6o   Get Sales Transaction By:6�   	� 5/   *   $��0,0,10,0q�66   $��Normal"�6r   $��12(�6�    	� 	GroupName$ FindBy��6�   	 d� 	IsChecked	 6H   �� *FindByReceiptNumber+.��6�   Invoice Number6�   	� 50   *   $
��10,0q�66   $��Normal"�6j   $��12(�6~   $ FindBy��6�   	 6D   �� *FindByDateRange+.��6�   
Date Range6�   =  7FirstFloor.ModernUI.Windows.Controls.ModernProgressRing  52   *   $��15,0,0,0q�6A   $��20��6o   $��20��6z   
   IsActive
 6S   �� *IsBusy+��6�   �� *SelectedItem.Tag+ �� ElementName$ CmbRingStyle��54   '   �� 56   &   $ 
Horizontal=�61   .+�57   *   �� $��0,0,1,0q�65   $ 
Horizontal=�6�   y�6F   �� *FindByReceiptNumber+ �� 	Converter# [ .+�58   .   �� $��Center=�68   $	��170��6S   $��Normal"�6_   $��12(�6s   Invoice Number:6�   �� 59   .   $	��323��6�   $��12(�6�   ��66   �� *InvoiceNumber+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   5:   +   �� 5<   *   $��0,0,1,0q�65   $ 
Horizontal=�6F   y�6_   �� *FindByDateRange+# [ .+�5=   .   �� $ 
Horizontal=�69   .+�5>   2   �� $��Center=�6<   $��Normal"�6W   $��12(�6k   $	��170��6y   From:6�   (  "System.Windows.Controls.DatePicker  5?   2   $��0,0,60,0q�6=   $��12(�6�   $��Normal"�6�   $
��Left=�6�      SelectedDate 6O   �� *
FromDate+$ TwoWay=�$ PropertyChanged=�6�   5@   /   �� 5B   .   $ 
Horizontal=�69   .+�5C   2   �� $��0,0,5,0q�6<   $��Center=�6M   $��Normal"�6h   $��12(�6|   To:6�     5D   2   $��12(�6�   $��Normal"�6�   $
��Left=�6�   $��0,0,0,0q�6�    6=   �� *ToDate+$ TwoWay=�$ PropertyChanged=�6�   5E   /   5F   +   �� 5H   *   $ 
Horizontal=�65   .+�5I   .   �� -   5         ��Name$ btnFind��5I   5   $��0q�6F   $��0q�6R   $��1,0,0,0q�6f   $��2��6w    �� 	IsDefault .  � Cursor$
 Hand��6�   $��9(�6�    � ToolTip$" Search for sales transaction��6�   $��Right=�6�   ��6�   �� *FindCommand+.��5J   2   �� $��25��68   $��25��6D   $��UniformToFill=�6O   ��6g   �� *
SearchIcon+5K   /   5L   +   5M   '   �� 5O   &   $��0,5,0,0q�61   $ 
Horizontal=�6B   .+�5P   *   �� $	��170��64   $��Normal"�6@   $��12(�6T   Sales Transactions6w   �� 5Q   *   $��12(�6�   $��Normal"�6�   $��Center=�6�   $	��350��6  $��28��6  ��63   �� *SoldStockBatches+$ TwoWay=� �� SelectedItem 6i   �� *SoldStockBatch+$ TwoWay=�$ PropertyChanged=���5R   .   �� 5S   2   .R�5T   6   �� $ 
Horizontal=�6A   .+�5U   :   �� $��0,0,10,0q�6D   $��12(�6V   ���	#FF413E3E��6{   �� *
DateSold+# [ 6�   �� 5V   :   $��12(�6D   ���	#FF413E3E��6i   �� *Customer.Name+6�   5W   7   5X   3   5Z   +   5[   '   5]   #   5^      5b      5c      5d      5e      � 5g      $��1��6   $��0,10,0,0q�6     5h      �� 5i      $
��auto �6$   �� 5j      $
��auto �6$   .+�5m      �� $	��5,5q�6   $ 15q�6&   $ 10��63   
�������$��1q�6X   
������� 5n        5o      $ DimGray��6+   ._�5r      �� .+�5t      �� $��0,0,0,4q�6!   $ 0q�62   ._�5x   "   �  � ColumnDefinitions 5y   &   �� 5z   *   �� 5{   *   .+�5~   "   �� &$CHOOSE ITEMS TO RETURN FROM THE LIST6R   �� 5   &   $��1��61   $��Right=�6A   $ 
Horizontal=�6]   .+�5�   *   �� $��0,0,2,0q�64   Selected Item Count:6\   �� 5�   *   
���   �$��20��6D   $ 15��6R   ._�5�   .   �� 
�������$��Center=�6{   $��Center=�6�   $
��Bold"�6�   ��68   �� *SelectedItemCount+$ TwoWay=�6�   5�   +   �� 5�   *   $��10,0,2,0q�64   Total Item:6T   �� 5�   *   
���   �$��20��6D   $ 15��6R   ._�5�   .   �� 
�������$��Center=�6u   $��Center=�6�   $
��Bold"�6�   ��68   �� *RecordCount+$ TwoWay=�6�   5�   +   5�   '   5�   #   5�      &	   System.Windows.Controls.DataGrid	  5�       	  AreRowDetailsFrozen .  	  AutoGenerateColumns .   	  GridLinesVisibility$ Vertical=�5�   
    	  HeadersVisibility$ Column=�5�   
   
�������$	��155��5�   
   ��5�   #   �� *
SoldStocks+ 5�   
   �� *	SoldStock+ �� SelectedIndex 5�   
   �� *SalesItemSelectedIndex+$ TwoWay=� 	  Columns 5�      4
  .System.Windows.Controls.DataGridTemplateColumn
  5�   "   ,  &System.Windows.Controls.DataGridColumn   Header$ Select��6:    
  CellTemplate 5�   &   �� 5�   *   .R�5�   .   �� $	��3,0q�67   $��18(�6D   $��Center=�6�   	 6R   �� *
IsSelected+$ TwoWay=�$ PropertyChanged=�6�   5�   +   5�   #   
  5�   "   $ Stock State��69    5�   &   �� 5�   *   .R�5�   .   �� $	��1,0q�67   $��Normal"�6  ��6D   �� *StockStates+$ TwoWay=� �� SelectedValue 6u   �� *
StockState+$ TwoWay=�$ PropertyChanged=�{�6�   �� *	CanReturn+# [  ��5�   2   �� 5�   6   .R�5�   :   �� $ 
Horizontal=�6E   .+�5�   >   �� $��Arial)�6H   ���	#FF413E3E��6r   �� *Name+6�   5�   ;   5�   7   5�   /   5�   +   5�   #   
  5�   "   $ Action��69    5�   &   �� 5�   *   .R�5�   .   �� $	��1,0q�67   $��Normal"�6�   ��6D   �� *	Actions+$ TwoWay=�$ PropertyChanged=� 6�   �� *Action+$ TwoWay=�$ PropertyChanged=�{�6�   �� *	CanReturn+# [  ��5�   2   �� 5�   6   .R�5�   :   �� $ 
Horizontal=�6E   .+�5�   >   �� $��Arial)�6H   ���	#FF413E3E��6r   �� *Name+6�   5�   ;   5�   7   5�   /   5�   +   5�   #   
  5�   "   $ Return Amount��69    5�   &   �� 5�   *   .R�5�   .   %  Xceed.Wpf.Toolkit.DecimalUpDown  $	��1,0q�6A   $��Center=�6  $��Center=�6C  �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value 6N   �� *ReturnAmount+$ TwoWay=�$ PropertyChanged=�   Maximum 6�   �� *Price.SellingPrice+{�6�   �� *CanEditReturnAmount+# [  6C  5�   +   5�   #   
  5�   "   $ ID��69    5�   &   �� 5�   *   .R�5�   .   �� $	��3,0q�68   $��Center=�6Y   
���   �$
��Wrap=�6�   ��6E   �� *Id+6�   5�   +   5�   #   
  5�   "   $ Package��69    5�   &   �� 5�   *   .R�5�   .   �� $	��3,0q�68   $��Center=�6{   
���   �$
��Wrap=�6�   ��6E   �� *&$ShelfStock.StockPackage.Package.Name+6�   5�   +   5�   #   
  5�   "   $
 Item��69    5�   &   �� 5�   *   .R�5�   .   �� $	��3,0q�68   $��Center=�6y   
���   �$
��Wrap=�6�   ��6E   �� *$"ShelfStock.StockPackage.Stock.Name+6�   5�   +   5�   #   
  5�   "   $	 Qty��69    5�   &   �� 5�   *   .R�5�   .   �� $	��3,0q�68   $��Center=�6_   $��Center=�6z   ��6E   �� *
Quantity+6z   5�   +   5�   #   
  5�   "   $ Selling Price��69    5�   &   �� 5�   *   .R�5�   .   �� $	��3,0q�68   $��Center=�6�   $��Right=�6�   
���   �$
��Wrap=�6�   ��6E   �� *Price.SellingPrice+# [ 6�   5�   +   5�   #   5�      �� 5�      $��0,7,0,0q�6#   $��Other Return Information��64   $��16(�6V   $��
10,10,10,2q�6d   $
��Bold"�6y   .��5�      �  5�   "   �� 5�   &   $
��auto �67   �� 5�   &   $��* �67    5�   "   �� 5�   &   �� 5�   &   �� 5�   &   .+�5�   "   �� $��0��6,   $��0��6<   $��Normal"�6I   $��12(�6]   Date Returned:6|     5   "   $��5,0,0,2q�6-   $��0��6>   $��1��6K   $��12(�6�   $
��Left=�6�   $��Normal"�6�    6[   �� *DateReturned+$ TwoWay=�$ PropertyChanged=�6�   �� 5  "   $��1��6,   $��0��69   $��Normal"�6I   $��12(�6]   Return Reason:6|   �� 5  "   $��5,0,0,5q�6*   $��1��6;   $��1��6H   $��Normal"�6�   $��12(�6�     �� TextWrapping$
  Wrap=�6�   $��35��6�   ! �� 	IsEnabled! . ��6X   �� *ReturnReason+$ TwoWay=�$ PropertyChanged=�6�   5     5     �� 5
     $��3��6%   $��1��62   $
��Left=�6B   $ 
Horizontal=�6]   .+�5     �� $��0,2,0,0q�6%   $��Return��6X   $��16(�6i   ��66   �� *ReturnCommand+6i     5     $��10,0,0,0q�65   $��20��6c   $��20��6n   
 6G   �� *IsBusy+��6z   �� *SelectedItem.Tag+$ CmbRingStyle��5     5     5     5     5     5     5     