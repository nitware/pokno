   M S B A M L   `   `   `  ����O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.InfrastructurePokno.Infrastructure.Converters  5       Pokno.Store2   ,Pokno.Store.Views.RegisterPurchasedStockView   5      U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      a	converterKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.Infrastructure     5      X TXceed.Wpf.Toolkit, Version=2.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      Z VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI  5        � 	Resources  5      ;   5Pokno.Infrastructure.Converters.DateToSelectConverter   DateToSelectConverter3   -Pokno.Infrastructure.Converters.DateConverter  DateConverter4   .Pokno.Infrastructure.Converters.MoneyConverter  MoneyConverter6   0Pokno.Infrastructure.Converters.IntegerConverter  IntegerConverter9   3Pokno.Infrastructure.Converters.VisibilityConverter  VisibilityConverter;   5Pokno.Infrastructure.Converters.CheckToolTipConverter  CheckToolTipConverter  DecimalUpDownStyle1 �� 
TargetType%  Xceed.Wpf.Toolkit.DecimalUpDown �� Property �� Value �� 
TargetType%  Xceed.Wpf.Toolkit.ButtonSpinner  Name   	AllowSpin �� RelativeSource   ButtonSpinnerLocation	   ShowButtonSpinner
   Content(	  "Xceed.Wpf.Toolkit.WatermarkTextBox 	 Name �� AcceptsReturn � ContextMenu �� IsUndoEnabled �� TextWrapping �� UpdateSourceTrigger)
  #Xceed.Wpf.Toolkit.AutoSelectTextBox 
  AutoMoveFocus 
  AutoSelectBehavior 	  SelectAllOnGotFocus �� TextAlignment 	  WatermarkTemplate 	  	Watermark��%-  &	        &	      &	 &     &	 9     &	 L     &	 _     &	 r       5   
   6*     5   
   6"     5   
   6#     5   
   6%     5   
   6(     5   
   6*   �� 5   
   "  6,   .�5      ��  � �� 5      �� 5      "  6&   .R�5        $ PART_Spinner��6-   #��z��6�   #��z��6�   #��z��6]  $��Stretch=�6�  ��.  $��Stretch=�6   6C   �� *	AllowSpin+ �� *TemplatedParent+ 6�   �� *ButtonSpinnerLocation+ �� *TemplatedParent+	 6�  �� *ShowButtonSpinner+ �� *TemplatedParent+.
 5      	  $ PART_TextBox��64    .  $��0q�6�  
������ # z 6�  #��z��6�  #��z��6  #��z��65  #��z��6]  #��z��6�  #��z��6�  #��z��6�  #��z��6#   . $��20��6`  #��z��6n  $ NoWrap=�6P  #��z��6f  #��z��6�  ��6J   �� *Text+ �� *TemplatedParent+$ PropertyChanged=� 6�   �� *AutoMoveFocus+ �� *TemplatedParent+ 6  �� *AutoSelectBehavior+ �� *TemplatedParent+ 6�  �� *SelectAllOnGotFocus+ �� *TemplatedParent+ 6�  �� *TextAlignment+ �� *TemplatedParent+ 6�  �� *WatermarkTemplate+ �� *TemplatedParent+ 63  �� *	Watermark+ �� *TemplatedParent+5      5      5      5      5       .��5"      � -   5         �Name$ 
LayoutRoot��5"      ���	#E7FDFDFD$��5q�66   .+�5$   
   �  � ColumnDefinitions 5%      �� 5&      �� 5'      .+�5,      �  � RowDefinitions 5-      �� 5.      $
��Auto �6$   �� 5/      $
��auto �6$   �� 50      $
��auto �6$   �� 51      $
��auto �6$   �� 52      $
��auto �6$   .+�5V      �� $��0��6   $��15,10,12,10q�6&   
������� �� CornerRadius$ 
20,20,0,20��6N   
�������$��1q�6{    J� Effect 5W      3  -System.Windows.Media.Effects.DropShadowEffect  5X         Color$ DimGray��6+   ._�5[      �� .+�5\      �� .+�5]      �� $��
20,15,20,0q�6&   $ 	10,10,0,0��6:   
�������$��Stretch=�6e   ._�5^   "   �� $	��0,8q�6,   $��Center=�69   
�������$��13(�6n   $
��Bold"�6|   CHOOSE PRODUCT6�   5_      �� 5a      $
��20,2q�6%    �� Padding$
 10,5q�63   
�������$��1q�6Z   ._�5b   "   � $��	20,0,20,5q�6'    5d   &   �� 5e   *   $��68 �6;   �� 5f   *   $	��180 �6;   �� 5g   *   $��* �6;    5i   &   �� 5j   *   $
��Auto �68   �� 5k   *   $
��auto �68   �� 5l   *   $
��auto �68   �� 5m   *   $
��auto �68   �� 5n   *   $
��auto �68   �� 5o   *   $
��auto �68   .+�5r   &   �� $
��Bold"�60   $��0��6B   $��0��6R   $��0,3,0,0q�6_   Stock:6x   �� 5s   &   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6[   $��0��6�   $��1��6�   $��0,3,0,0q�6�   ��6/   �� *Stocks+ �� Mode$ TwoWay=�  �� SelectedItem  6�   �� *Stock+$ TwoWay=�$ PropertyChanged=���5t   *   �� 5u   .   .R�5v   2   �� ! �� Orientation$! 
Horizontal=�6=   .+�5w   6   �� ���	#FF413E3E��6W   �� *Name+5x   3   5y   /   5{   '   �� 5}   &   $
��Bold"�60   $��0��6B   $��1��6R   $��0,3,0,0q�6_   
Package:6z   �� 5   &   $
��Bold"�60   $��0��6B   $��2��6R   $��0,3,0,0q�6_   
Unit Cost:6|     5�   &   �  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]"   FormatString$" #,0.00��6m   {�.  $��0,3,0,0q�6�   $��22��6�   $��1��6�   $��2��6�   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]#   Maximum$# 99999999999999X�6�   $   Minimum$$ 0X�6�   �  �Xceed.Wpf.Toolkit.CommonNumericUpDown`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]%   ParsingNumberStyle$% AllowThousands=�6�   &   Value& 69   �� *TargetModel.UnitCost+$ TwoWay=�6�   �� 5�   &   $��2,3,0,0q�6.   $��2��6@   $��2��6P   $��9(�6�   $��0q�6�   $
��Left=�6�   $��25��6�   ' � ToolTip$' Change Stock Price��6�   $��22��6�   $	��...��6�   ��6]   �� *ChangePriceCommand+6�   �� 5�   &   $
��Bold"�60   $��3��6B   $��0,3,0,0q�6O   $��22��6`   $	��Top=�6l   	Quantity:6�   %  Xceed.Wpf.Toolkit.IntegerUpDown  5�   &   �  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]](   FormatString$	( #,0��6�   $��0,3,0,0q�6�   $��22��6�   $��1��6�   $��3��6�   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]])   Value) 69   �� *TargetModel.Quantity+$ TwoWay=�* �� 	Converter#* [ 6�   �� 5�   &   $
��Bold"�60   $��0��6B   $��4��6R   $��0,3,0,0q�6_   Cost:6w     5�   &   $" #,0.00��6�   $��0,3,0,0q�6�   $��22��6�   $��1��6�   $��4��6�   $# 99999999999999X�6�   & 69   �� *TargetModel.Cost+$ TwoWay=�#* [ 6�   �� 5�   &   $
 TrueY�6b   $��1��6�   $��1��6�   $��0,3,0,0q�6�   ��6/   �� *StockPackages+$ TwoWay=�  6�   �� *StockPackage+$ TwoWay=�$ PropertyChanged=���5�   *   �� 5�   .   .R�5�   2   �� $! 
Horizontal=�6=   .+�5�   6   �� ���	#FF413E3E��6W   �� *Package.Name+5�   3   5�   /   5�   '   �� 5�   &   $��5��61   $��1��6>   $
��Left=�6N   $��0,3,0,0q�6i   $! 
Horizontal=�6z   .+�5�   *   �� $��9(�6P   $	��Add��6]   ��61   �� *
AddCommand+6]   5�   '   5�   #   5�      5�      �� 5�      $��2��6%   .+�5�      �� $! Vertical=�6)   $��20,10, 20,15q�6@   .+�5�   "   �� $��0,0,0,0q�6)   $ 5,5,0,5��6C   ._�5�   &   �� .+�5�   *   �� 
�������$��Stretch=�6C   ._�5�   .   �� $	��0,7q�68   $��Center=�6E   
�������$��13(�6z   $
��Bold"�6�   PURCHASED PRODUCT TRAY6�   5�   +   �� 5�   *   $	��0,1q�61   ���#e0eaf6$��1��6S   $��2��6c   $��0��6w   ._�5�   .   �  5�   2   �� 5�   6   �� 5�   6   �� 5�   6    5�   2   �� 5�   6   $
��auto �6D   .+�5�   2   �� $	��0,0q�69   $��0��6F   $��0��6S   $��3��6c   $��1q�6w   ._�5�   6   �� .+�5�   :   � $��5,2,5,2q�6?    5�   >   �� 5�   B   $
��auto �6S   �� 5�   B   �� 5�   B   $
��auto �6S   �� 5�   B   �� 5�   B   $
��auto �6T   �� 5�   B    5�   >   �� 5�   B   �� 5�   B   �� 5�   B   �� 5�   B   �� 5�   B   �� 5�   B   .+�5�   >   �� $��0,0,2,0q�6H   $��10(�6Z   $��0��6h   $��0��6x   $��Center=�6�   Total Quantity:6�   �� 5�   >   $��0,0,10,0q�6g   $��1��6y   $��0��6�   ��6H   �� *TotalQuantity+6�   �� 5�   >   $��0,0,2,0q�6H   $��2��6Y   $��0��6i   $��10(�6v   $��Center=�6�   Total Unit Cost:6�   �� 5�   >   $��0,0,10,0q�6�   $��3��6�   $��0��6�   ��6H   �� *TotalUnitCost+#* [ 6�   �� 5�   >   $��10,0,2,0q�6H   $��10(�6Z   $��0��6h   $��4��6u   $��Center=�6�   $
��Left=�6�   Total Cost:6�   �� 5�   >   $��0,0,0,0q�6�   $��5��6�   $��0��6�   ��6H   �� *	TotalCost+#* [ 6�   5�   ;   5�   7   5�   3   5�   /   5�   +   &   System.Windows.Controls.DataGrid  5�   *   +   AreRowDetailsFrozen+ . ,   AutoGenerateColumns, .  -   HeadersVisibility$- Column=�5�      $	��290��5�      ��5�   3   �� *TargetCollection+.   Columns. 5�   .   4  .System.Windows.Controls.DataGridTemplateColumn  5�   2   ,  &System.Windows.Controls.DataGridColumn/   Header$/ Stock��6I   0   CellTemplate0 5�   6   �� 5�   :   .R�5�   >   �� $��3,0,3,0q�6H   $��12(�6Y   $
��Wrap=�6�   ��6g   �� *
Stock.Name+6�   5�   ;   5�   3     5�   2   $/ Package��6I   0 5�   6   �� 5�   :   .R�5�   >   �� $��5,0,3,0q�6H   $��12(�6Y   $
��Wrap=�6�   ��6g   �� *StockPackage.Package.Name+6�   5�   ;   5�   3     5�   2   $/ Quantity��6I   0 5�   6   �� 5�   :   .R�5�   >   �� $��5,0,3,0q�6H   $��12(�6Y   $��Center=�6�   $
��Wrap=�6�   ��6g   �� *
Quantity+6�   5�   ;   5�   3     5�   2   $/ 	Unit Cost��6I   0 5�   6   �� 5�   :   .R�5�   >   �� $��5,0,3,0q�6H   $��12(�6Y   $��Right=�6�   $
��Wrap=�6�   ��6g   �� *
UnitCost+#* [ 6�   5�   ;   5   3     5  2   $
/ Cost��6I   0 5  6   �� 5  :   .R�5  >   �� $��5,0,0,0q�6H   $��12(�6Y   $��Right=�6�   $
��Wrap=�6�   ��6g   �� *Cost+#* [ 6�   5  ;   5  3   5  +   �� 5  *   $
��Left=�65   $��0,2,5,2q�6P   $! 
Horizontal=�6a   .+�5  .   �� $��9(�6e   $��Clear��6r   $��0,0,2,0q�6�   ��65   �� *ClearPurchasedStocksCommand+6�   �� 5  .   $��9(�6W   $��Remove��6d   $��0,0,2,0q�6u   ��65   �� *RemoveCommand+6u   5  +   5  '   5  #   5     5     5     5     5     � 5     $��1��6   $��
10,5,10,10q�6#    5     �� 5     $
��Auto �6$   �� 5     $
��auto �6$   �� 5      $
��auto �6$   �� 5!     $
��auto �6$   .+�5$     �� $��1��6   $��	10,5,10,0q�6&   
�������$��1q�6L   $ 20��6`   
���iii� 5%       5&     $ DimGray��6+   ._�5)     �� $��20,15,20,10q�6   ._�5*     �� .+�5+     �� $��0,0,0,5q�6%   $ 	10,10,0,0��66   
�������$��Stretch=�6a   ._�5,  "   �� $	��0,8q�6,   $��Center=�69   
�������$��13(�6n   $
��Bold"�6|   PURCHASE BATCH6�   5-     �� 5/     $��5,0,5,5q�6%   ._�50  "   � $��5,2,5,0q�6'    51  &   �� 52  *   $	��120 �6;   �� 53  *   $	��180 �6;    56  &   �� 57  *   $
��Auto �68   �� 58  *   $��* �68   �� 59  *   $��* �68   �� 5:  *   $��* �68   �� 5;  *   $��* �68   �� 5<  *   $��* �68   .+�5?  &   �� $
��Bold"�60   $��0��6B   $��0��6R   �� 6`   $�	Supplier:��6d   6x   �� 5@  &   $
 TrueY�6u   $��1��6�   $��0��6�   $��0,3,0,0q�6�   $��23��6  ��6/   �� *" PurchaseBatchViewModel.Suppliers+$ TwoWay=�  6�   �� *!PurchaseBatchViewModel.Supplier+$ TwoWay=���5A  *   �� 5B  .   .R�5C  2   �� $! 
Horizontal=�6=   .+�5D  6   �� ���	#FF413E3E��6W   �� *
FullName+5E  3   5F  /   5H  '   �� 5J  &   $
��Bold"�60   $��0��6B   $��1��6R   $��0,3,0,0q�6_   
Initiator:6|   �� 5L  &   $
 TrueY�6r   $��1��6�   $��1��6�   $��0,3,0,0q�6�   $��23��6  ��6/   �� *PurchaseBatchViewModel.Buyers+$ TwoWay=�  6�   �� *PurchaseBatchViewModel.Buyer+$ TwoWay=���5M  *   �� 5N  .   .R�5O  2   �� $! 
Horizontal=�6=   .+�5P  6   �� ���	#FF413E3E��6W   �� *
FullName+5Q  3   5R  /   5T  '   �� 5V  &   $
��Bold"�60   $��0��6B   $��2��6R   $��0,3,0,0q�6_   �� 6q   $�Date Purchased:��6u   6�   (  "System.Windows.Controls.DatePicker  5W  &   $��1��6�   $��2��6�   $��23��6�   $��0,3,0,0q�6�   1   FirstDayOfWeek$1 Monday=�6�   2   SelectedDate2 61   �� *97PurchaseBatchViewModel.StockPurchaseBatch.DatePurchased+$ TwoWay=�$ PropertyChanged=�6�   �� 5Y  &   $
��Bold"�60   $��0��6B   $��3��6R   �� 6`   $�Amount Payable:��6d   6~     5Z  &   {�.  $" #,0.00��6�   $��0,3,0,0q�6�   $��1��6�   $��3��6�   $��22��6�   $	��Top=�6�   $# 99999999999999X�6�   & 69   �� *.,PurchaseBatchViewModel.Payment.AmountPayable+$ TwoWay=�6�   �� 5\  &   $
��Bold"�60   $��0��6B   $��4��6R   $��0,3,0,0q�6_   Supplier Expenses:6�     5_  &   $��0,3,0,0q�6�   $" #,0.00��6�   $��1��6�   $��4��6�   $��22��6�   $# 99999999999999X�6	  $$ 0X�6"  & 69   �� *SupplierExpenses+$ TwoWay=�$ PropertyChanged=�#* [ 6"  �� 5b  &   $
��Bold"�60   $��0��6B   $��5��6R   $��0,3,0,0q�6_   �� 6q   $�Invoice No.:��6u   6�   �� 5c  &   $��0,3,0,0q�6�   $��1��6�   $��5��6�   ��6.   �� *97PurchaseBatchViewModel.StockPurchaseBatch.InvoiceNumber+$ TwoWay=�6�   5e  #   5f     5g     5h     5i     �� 5k     $��2��6   $��
10,15,10,0q�6&   
�������
���iii�$��1q�6d   $ 
20,20,20,0��6x    5l       5m     $ DimGray��6+   ._�5p     �� $��2��6   $ 	0,10,0,10q�6*   $
��20,5q�6>   $��0q�6L   $ 8��6`   
�������._�5q     �� .+�5r     �� $ 	10,10,0,0��6%   
�������$��Stretch=�6P   ._�5s  "   �� $	��0,8q�6,   $��Center=�69   
�������$��13(�6n   $
��Bold"�6|   �� 6�   $�PAYMENT DETAILS��6�   6�   5t     �� 5u     $	��0,2q�6%   
�������$��1q�6G   ._�5v  "   � $��	20,5,20,7q�6'    5w  &   �� 5x  *   $	��110 �6;   �� 5y  *   $	��180 �6;    5{  &   �� 5|  *   $
��Auto �68   �� 5}  *   $
��auto �68   �� 5~  *   $
��auto �68   �� 5  *   $
��auto �68   �� 5�  *   $
��auto �68   �� 5�  *   $
��auto �68   .+�5�  &   �� $
��Bold"�60   $��0��6B   $��1��6R   $��0,3,0,0q�6_   �� 6q   $�Amount Paid:��6u   6�     5�  &   $" #,0.00��6�   $��0,3,0,0q�6�   $��1��6�   $��1��6�   $��22��6�   $	��Top=�6  $# 99999999999999X�6  & 69   �� */-PurchaseBatchViewModel.TargetModel.AmountPaid+$ TwoWay=�#* [ 6  �� 5�  &   $
��Bold"�60   $��0��6B   $��2��6R   $��0,3,0,0q�6_   �� 6q   $�
Date Paid:��6u   6�     5�  &   $��1��6�   $��2��6�   $��23��6�   $��0,3,0,0q�6�   2 61   �� *0.PurchaseBatchViewModel.TargetModel.PaymentDate+$ TwoWay=�$ PropertyChanged=�6�   �� 5�  &   $
��Bold"�60   $��0��6B   $��3��6R   $��0,3,0,0q�6_   �� 6q   $�Payment Mode:��6u   6�   �� 5�  &   $
 TrueY�6x   $��1��6�   $��3��6�   $��0,3,0,0q�6  $��23��6  ��6/   �� *%#PurchaseBatchViewModel.PaymentTypes+$ TwoWay=�  6�   �� *$"PurchaseBatchViewModel.PaymentType+$ TwoWay=���5�  *   �� 5�  .   .R�5�  2   �� $! 
Horizontal=�6=   .+�5�  6   �� ���	#FF413E3E��6W   �� *Name+5�  3   5�  /   5�  '   �� 5�  &   $��4��61   $��1��6>   $
��Left=�6N   $��0,3,0,0q�6i   $! 
Horizontal=�6z   .+�5�  *   �� $��0,0,2,0q�6W   $��9(�6h   $��
Add Detail��6u   $��Right=�6�   ��61   �� *AddPaymentCommand+6�   5�  '   5�  #   5�     � 5�     $��0,0,0,0q�6#   .+�5�  "   �� ._�5�  &   �� ���#EFEFEF$��0,3,0,0q�6F   .+�5�  *   �� ���#EFEFEF$��Stretch=�6F   ._�5�  .   �  5�  2   �� 5�  6   �� 5�  6   .+�5�  2   �� $��5q�6<   PAYMENT DETAILS TRAY6^   �� 5�  2   $��5q�6=   $��1��6H   $! 
Horizontal=�6X   $��Right=�6q   .+�5�  6   �� $��0,0,3,0q�6@   $��Center=�6Q   
Balance:6w   �� 5�  6   $��Center=�6�   ��6@   �� * PurchaseBatchViewModel.Balance+#* [ 6�   5�  3   5�  /   5�  +     5�  *   + . , .  3   GridLinesVisibility$
3 None=�5�     $- Column=�5�     $��0,1,0,0q�5�     $	��100��5�     ��5�  3   �� *)'PurchaseBatchViewModel.TargetCollection+. 5�  .     5�  2   $/ Amount Paid��6I   0 5�  6   �� 5�  :   .R�5�  >   �� $��12(�6H   $
��Wrap=�6�   ��6V   �� *
AmountPaid+#* [ 4 ^� ToolTip4 5�     �� 5�     $
��5,10q�6   
�������y�6,   �� *Check+#* [ .+�5�     � $
��5,10q�6    5�     �� 5�     �� 5�      5�     �� 5�     �� 5�     �� 5�     �� 5�     .+�5�     �� $��0,0,0,5q�6   $��0��6-   $��0��6:   $��2��6J   
���   �$��0,0,0,1q�6s   ._�5�     �� $
��Bold"�6    $��Center=�62   $��Expanded&�6O   �� 6h   $�CHEQUE DETAIL��6l   6�   5�     �� 5�     $��0,0,5,0q�6   $��0��60   $��1��6@   $
��Bold"�6M   $��Right=�6_   
��������� 6�   $�Bank:��6�   6�   �� 5�     $��1��6   $��11(�6/   $��1��6=   
���  ����6[   �� *Cheque.Bank.Name+�� 5�     $��0,0,5,0q�6   $��0��60   $��2��6@   $
��Bold"�6M   $��Right=�6_   
��������� 6�   $�
Cheque No:��6�   6�   �� 5�     $��1��6   $��11(�6/   $��2��6=   
���  ����6[   �� *Cheque.ChequeNumber+�� 5�     $��0,0,5,0q�6   $��0��60   $��3��6@   $
��Bold"�6M   $��Right=�6_   
��������� 6�   $�Account No:��6�   6�   �� 5�     $��1��6   $��11(�6/   $��3��6=   
���  ����6[   �� *Cheque.AccountNumber+5�     5�     5�     5�  ;   5�  3     5�  2   $/ 	Date Paid��6I   0 5�  6   �� 5�  :   .R�5�  >   �� $��12(�6H   $
��Wrap=�6�   ��6V   �� *PaymentDate+#* [ 6�   5�  ;   5�  3     5�  2   $
/ Mode��6I   0 5�  6   �� 5�  :   .R�5�  >   �� $��12(�6H   $
��Wrap=�6x   ��6V   �� *PaymentType.Name+6x   5�  ;   5�  3   5�  +   5�  '   5�  #   5�     �� 5�     $��0,3,0,0q�6%   $��9(�6_   $��Delete��6l   $��Right=�6}   ��66   �� *RemovePaymentCommand+6}   5�     5�     5�     �� 5�     $��4��6   $
��Left=�6*   $��	10,8,10,5q�6E   $! 
Horizontal=�6X   .+�5�     �� $��0,0,2,0q�6   $��15(�6N   $
��Save��6\   $��Right=�6k   ��6.   �� *SaveCommand+6k   �� 5�     $��15(�6?   $��Clear��6M   $��Right=�6]   ��6   �� *ClearCommand+6]   =  7FirstFloor.ModernUI.Windows.Controls.ModernProgressRing  5�     $��15,0,0,0q�6-   $��30��6[   $��30��6f   5   IsActive5 6?   �� *IsBusy+��6r   �� *SelectedItem.Tag+6 �� ElementName$6 CmbRingStyle��5     5     5	     5
     5     