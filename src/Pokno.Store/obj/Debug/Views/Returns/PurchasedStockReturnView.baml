   M S B A M L   `   `   `  ����O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.InfrastructurePokno.Infrastructure.Converters  5       Pokno.Store0   *Pokno.Store.Views.PurchasedStockReturnView   5      U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      a	converterKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.Infrastructure     5      X TXceed.Wpf.Toolkit, Version=2.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      Z VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI  5        � 	Resources  5      3   -Pokno.Infrastructure.Converters.DateConverter   DateConverter;   5Pokno.Infrastructure.Converters.CheckToolTipConverter  CheckToolTipConverter;   5Pokno.Infrastructure.Converters.DateToSelectConverter  DateToSelectConverter4   .Pokno.Infrastructure.Converters.MoneyConverter  MoneyConverter8   2Pokno.Infrastructure.Converters.EnabilityConverter  EnabilityConverter��%�   &	        &	      &	 &     &	 9     &	 L       5   
   6"     5   
   6*     5   
   6*     5   
   6#     5   
   6'   5      .��5      �� $��Stretch=�6R   {�6   �� *PurchasedStockCanBeEdited+ �� Mode$ TwoWay=�.��5   
   � $��5q�6   ���	#E7FFFFFF � ColumnDefinitions 5      �� 5      $��6* �6#   �� 5      $��4* �6#   .+�5      �  � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5       $
��auto �6$   �� 5!      $
��auto �6$   .+�5$      �� $��
15,10,17,5q�6   $��0��6-    �� CornerRadius$ 20,0,0,0��6=   
�������$��1q�6h   
������� J� Effect 5%      3  -System.Windows.Media.Effects.DropShadowEffect  5&         Color$ DimGray��6'   ._�5)      � $��12,10,12,15q�6    5*      �� 5+       5-      �� 5.      $
��Auto �6(   �� 5/      $
��Auto �6(   �� 50      $
��Auto �6(   .+�53      �� $��	10,0,10,0q�6    $��15(�63   $��Center=�6A   $��0��6\   Purchase Transaction6   �� 54      $��	10,2,10,0q�6#   $��1��66   $��1��6F   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6�   $��Center=�6�   ��6S   �� *PurchaseStockBatches+$ TwoWay=� �� SelectedItem 6�   �� *PurchaseStockBatch+$ TwoWay=���55      �� 56   "   .R�57   &   �� 	 �� Orientation$	 
Horizontal=�61   .+�58   *   �� $��0,0,7,0q�64   $
��Bold"�6E   ���	#FF413E3E��6n   �� *DatePurchased+
 �� 	Converter#
 [ �� 5;   *   ���	#FF413E3E��6K   �� *
Buyer.Name+5<   '   5=   #   5?      5A      5B      � 5D      $��0,5,0,10q�6   $��0��6%   $��1��65    5E      �� 5F      $
��Auto �6$   �� 5G      $
��auto �6$   �� 5H      $
��auto �6$   �� 5I      $
��auto �6$   .+�5L      �� $��
15,0,15,10q�6   $��0��6/   $��15(�6<   $��Choose Product��6J   .��5M      �� $��0,10,0,0q�6!   .+�5N      � $��	20,0,20,5q�6#    5O   "   �� 5P   &   $��68 �67   �� 5Q   &   $	��180 �67    5S   "   �� 5T   &   $
��Auto �64   �� 5U   &   $
��auto �64   �� 5V   &   $
��auto �64   �� 5W   &   $
��auto �64   �� 5X   &   $
��auto �64   �� 5Y   &   $
��auto �64   .+�5\   "   �� $��12(�6,   $
��Bold"�6:   $��0��6L   $��0��6\   $��0,3,0,0q�6i   Stock:6�   �� 5]      $
 TrueY�6S   $��0��6�   $��1��6�   $��0,3,0,0q�6�   ��6'   �� *Stocks+$ TwoWay=� 6x   �� *Stock+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=���5^   &   �� 5_   *   .R�5`   .   �� $	 
Horizontal=�69   .+�5a   2   �� $��12(�6<   ���	#FF413E3E��6a   �� *Name+5b   /   5c   +   5e   #   �� 5g   "   $��12(�6,   $
��Bold"�6:   $��0��6L   $��1��6\   $��0,3,0,0q�6i   
Package:6�   �� 5i   "   $��12(�6,   $
��Bold"�6:   $��0��6L   $��2��6\   $��0,3,0,0q�6i   
Unit Cost:6�   %  Xceed.Wpf.Toolkit.DecimalUpDown  5j   "   $��12(�6i   �  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   FormatString$ #,0.00��6w   {�.  $��0,3,0,0q�6�   $��22��6�   $��1��6�   $��2��6�   �	  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]] 	  Maximum$ 99999999999999X�6�    	  Minimum$ 0X�6�   �
  �Xceed.Wpf.Toolkit.CommonNumericUpDown`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]] 
  ParsingNumberStyle$ AllowThousands=�6�    	  Value 65   �� *TargetModel.UnitCost+$ TwoWay=�6�   �� 5l   "   $��12(�6,   $
��Bold"�6:   $��3��6L   $��0,3,0,0q�6Y   $��22��6j   $	��Top=�6v   	Quantity:6�   %  Xceed.Wpf.Toolkit.IntegerUpDown  5m   "   $��12(�6i   �  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   FormatString$	 #,0��6w   $��0,3,0,0q�6�   $��22��6�   $��1��6�   $��3��6�   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value 65   �� *TargetModel.Quantity+$ TwoWay=�6�   �� 5o   "   $��12(�6,   $
��Bold"�6:   $��0��6L   $��4��6\   $��0,3,0,0q�6i   Cost:6�     5p   "   $��12(�6e   $ #,0.00��6s   $��0,3,0,0q�6�   $��22��6�   $��1��6�   $��4��6�   $ 99999999999999X�6�    65   �� *TargetModel.Cost+$ TwoWay=�6�   �� 5s      $
 TrueY�6Z   $��1��6�   $��1��6�   $��0,3,0,0q�6�   ��6'   �� *StockPackages+$ TwoWay=� 6   �� *StockPackage+$ TwoWay=�$ PropertyChanged=���5t   &   �� 5u   *   .R�5v   .   �� $	 
Horizontal=�69   .+�5w   2   �� $��12(�6<   ���	#FF413E3E��6a   �� *Package.Name+5x   /   5y   +   5{   #   �� 5}   "   $��5��6-   $��1��6:   $
��Left=�6J   $��0,3,0,0q�6e   $	 
Horizontal=�6v   .+�5~   &   �� $��9(�6L   $	��Add��6Y   ��6-   �� *
AddCommand+6Y   5   #   5�      5�      5�      � 5�      $��1��6   $��0��6$   $��	15,0,15,0q�64    5�      �� 5�      �� 5�      .+�5�      �� $��0,0,0,4q�6   $ 0,10,0,0��6.   $��2��6F   $��0q�6S   
����������#e0eaf6._�5�      �� $��0,0,0,0q�6%   .+�5�      �� $��0��6%   $��0��62   $��3��6B   
�������._�5�   "   �� $��10q�6-   .+�5�   &   �� 
���iii�$��0,0,0,1q�6C   $��0,2,0,0q�6]   $��Stretch=�6o   ._�5�   *   �� STOCKS TO RETURN6G   5�   '   � 5�   &   $��0,0,0,0q�6+    5�   *   �� 5�   .   $
��auto �6?   �� 5�   .   $��* �6?   �� 5�   .   $
��auto �6?   �� 5�   .   $��* �6?   �� 5�   .   $
��auto �6?   �� 5�   .   $��* �6?    5�   *   �� 5�   .   �� 5�   .   �� 5�   .   �� 5�   .   �� 5�   .   �� 5�   .   .+�5�   *   �� $��0,0,2,0q�64   $��11(�6E   $��0��6T   $��0��6d   $��Center=�6q   Total Quantity:6�   �� 5�   *   $
��Bold"�6S   $��11(�6e   $��0,0,10,0q�6s   $��1��6�   $��0��6�   ��64   �� *TotalQuantity+6�   �� 5�   *   $��0,0,2,0q�64   $��2��6E   $��0��6U   $��11(�6b   $��Center=�6p   Total Unit Cost:6�   �� 5�   *   $
��Bold"�6~   $��11(�6�   $��0,0,10,0q�6�   $��3��6�   $��0��6�   ��64   �� *TotalUnitCost+#
 [ 6�   �� 5�   *   $��10,0,2,0q�64   $��0��6F   $��4��6S   $��Center=�6c   $��11(�6~   $
��Left=�6�   Total Cost:6�   �� 5�   *   $
��Bold"�6z   $��11(�6�   $��0,0,0,0q�6�   $��5��6�   $��0��6�   ��64   �� *	TotalCost+#
 [ 6�   5�   '   5�   #   5�      &   System.Windows.Controls.DataGrid  5�         AreRowDetailsFrozen .    AutoGenerateColumns .     HeadersVisibility$ Column=�5�      $	��130��5�      ��5�   '   �� *TargetCollection+   Columns 5�   "   4  .System.Windows.Controls.DataGridTemplateColumn  5�   &   ,  &System.Windows.Controls.DataGridColumn   Header$ Stock��6=      CellTemplate 5�   *   �� 5�   .   .R�5�   2   �� $��3,0,3,0q�6<   $
��Wrap=�6v   ��6M   �� *StockPackage.Stock.Name+6v   5�   /   5�   '     5�   &   $ Package��6=    5�   *   �� 5�   .   .R�5�   2   �� $��5,0,3,0q�6<   $
��Wrap=�6x   ��6M   �� *StockPackage.Package.Name+6x   5�   /   5�   '     5�   &   $	 Qty��6=    5�   *   �� 5�   .   .R�5�   2   �� $��5,0,3,0q�6<   $��Center=�6g   $
��Wrap=�6�   ��6M   �� *
Quantity+6�   5�   /   5�   '     5�   &   $
 Cost��6=    5�   *   �� 5�   .   .R�5�   2   �� $��5,0,0,0q�6<   $��12(�6M   $��Right=�6�   $
��Wrap=�6�   ��6[   �� *Cost+#
 [ 6�   5�   /   5�   '     5�   &   $ Stock State��6=    5�   *   �� 5�   .   .R�5�   2   �� $	��1,0q�6;   $
 TrueY�6y   $��Normal"�6D  ��6H   �� *StockStates+$ TwoWay=� �� SelectedValue 6�   �� *
StockState+$ TwoWay=�$ PropertyChanged=�{�6�   �� *	CanReturn+#
 [ ��5�   6   �� 5�   :   .R�5�   >   �� $	 
Horizontal=�6I   .+�5�   B   �� $��12(�6L   ���	#FF413E3E��6q   �� *Name+6�   5�   ?   5�   ;   5�   3   5�   /   5�   '     5�   &   $ Reason��6=    5�   *   �� 5�   .   .R�5�   2   �� $	��1,0q�6:   $��Center=�6�   $��Center=�6  
���   � �� TextWrapping$
 Wrap=�6<   �� 	IsEnabled . $	��228��6l  ��6G   �� *ReturnReason+$ TwoWay=�$ PropertyChanged=�{�6�   �� *CanEnterActionReason+#
 [ 6l  5�   /   5�   '   5�      �� 5�      $
��Left=�6)   $��3,2,0,3q�6D   $	 
Horizontal=�6U   .+�5�   "   �� $��9(�6a   $��Clear��6n   $��0,0,1,0q�6~   ��6)   �� *%#ClearPurchasedStocksToReturnCommand+6~   �� 5�   "   $��9(�6K   $��Remove��6X   ��6)   �� *RemoveCommand+6X   5�      5      5     5     �� 5     $��	15,0,15,5q�6   $��2��60   $��Right=�6=   $	 
Horizontal=�6Y   .+�5     =  7FirstFloor.ModernUI.Windows.Controls.ModernProgressRing  $��0,0,10,0q�6-   $��20��6[   $��20��6f      IsActive 6?   �� *IsBusy+��6r   �� *SelectedItem.Tag+ �� ElementName$ CmbRingStyle���� 5     $��0,0,1,0q�6   $��15(�6O   $��Clear��6]   ��6.   �� *ClearCommand+6]   �� 5     $��15(�6=   $
��Save��6K   ��6   �� *SaveCommand+6K   5     5	     5
     �� 5     $��0��6   $��1��6&   $��3��66   $��	5,10,20,0q�6G   $��Stretch=�6Z   .+�5     �� 
�������$ 	0,20,20,0��6,   
�������$��1,1,1,1q�6X   $��Stretch=�6r    5       5     $ DimGray��6+   ._�5     �� ._�5     �� $��2��6%   .+�5     �� $	 Vertical=�6)   $��10,10,10,10q�6@   .+�5  "   �� $��0,0,0,0q�6)   $ 5,5,0,5��6C   ._�5  &   �� $��0,5,0,0q�61   .+�5  *   �� $��2,0,2,0q�61   $ 0,5,0,0��6B   ���#e0eaf6$��1��6n   $��2��6~   $��0��6�   ._�5  .   �  5  2   �� 5  6   �� 5  6   �� 5  6    5"  2   �� 5#  6   $
��auto �6D   .+�5(  2   �� $��0��69   $��0��6F   $��3��6V   $ 5,5,0,0��6j   ._�5)  6   �� $��10q�6A   .+�5*  :   �� 
���iii�$��0,0,0,1q�6W   $��0,2,0,0q�6q   $��Stretch=�6�   ._�5+  >   �� PURCHASED STOCK(S)6]   5,  ;   � 5.  :   $��0,2,0,0q�6?    5/  >   �� 50  B   $
��auto �6S   �� 51  B   $
��auto �6S   �� 52  B   $
��auto �6S   �� 53  B   $
��auto �6S   �� 54  B   $
��auto �6S   �� 55  B   $
��auto �6S    57  >   �� 58  B   �� 59  B   �� 5:  B   �� 5;  B   �� 5<  B   �� 5=  B   .+�5@  >   �� $��0,0,2,0q�6H   $��11(�6Y   $��0��6h   $��0��6x   $��Center=�6�   Item Count:6�   �� 5A  >   $
��Bold"�6q   $��11(�6�   $��0,0,10,0q�6�   $��1��6�   $��0��6�   ��6H   �� *PurchasedStockItemCount+6�   �� 5C  >   $��0,0,2,0q�6H   $��2��6Y   $��11(�6i   $��0��6x   $��Center=�6�   
Total Qty:6�   �� 5D  >   $
��Bold"�6u   $��11(�6�   $��0,0,10,0q�6�   $��3��6�   $��0��6�   ��6H   �� *PurchasedStockTotalQuantity+6�   �� 5F  >   $��0,0,2,0q�6H   $��0��6Y   $��4��6f   $��Center=�6v   $��11(�6�   $
��Left=�6�   Total Cost:6�   �� 5G  >   $��5��6H   $��0��6X   $
��Bold"�6�   $��11(�6�   ��6e   �� *PurchasedStockTotalCost+#
 [ 6�   5H  ;   5I  7   5J  3   5L  /   5M  +     5O  *   $��0q�5P  1   
������� .  .     AlternatingRowBackground
 �����$ Column=�5V     $	��457��5W     ��5O  3   �� *PurchasedStocks+ 5Y  .     5Z  2   $ Stock��6I    5[  6   �� 5\  :   .R�5]  >   �� $��0,0,5,0q�6H   $��12(�6Y   $
��Wrap=�6�   ��6g   �� *
Stock.Name+6�   5^  ;   5`  3     5b  2   $ Package��6I    5c  6   �� 5d  :   .R�5e  >   �� $	��5,0q�6H   $��12(�6U   $
��Wrap=�6�   ��6c   �� *StockPackage.Package.Name+6�   5f  ;   5h  3     5j  2   $	 Qty��6I    5k  6   �� 5l  :   .R�5m  >   �� $	��5,0q�6H   $��12(�6U   $��Center=�6}   $
��Wrap=�6�   ��6c   �� *
Quantity+6�   5n  ;   5p  3     5z  2   $
 Cost��6I    5{  6   �� 5|  :   .R�5}  >   �� $	��5,0q�6H   $��12(�6U   $��Right=�6�   $
��Wrap=�6�   ��6c   �� *Cost+#
 [ 6�   5~  ;   5�  3   5�  +   5�  '   5�  #   5�     5�     5�     5�     5�     5�     5�     5�     