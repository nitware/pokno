   M S B A M L   `   `   `  ����O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.InfrastructurePokno.Infrastructure.Converters  5       Pokno.Store%   Pokno.Store.Views.TakeStockView   5      U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      ]localKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.Infrastructure     5      Z VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI  5        � 	Resources  5      4   .Pokno.Infrastructure.Converters.MoneyConverter   MoneyConverter  GroupHeaderStyle �� 
TargetType �� Property �� Value �� 
TargetType��%�   &	        &	        5   
   6   �� 5   
   " ��6)   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� .+�5      �� ��6(   �� *	MonthName+�� 5      5      5      5      5      5      .��5      � -   5         �Name$ 
LayoutRoot��5      $��5q�6   
�������.+�5   
   �  � RowDefinitions 5      �� 5       $
��Auto �6    �� 5!      $��* �6    .+�5$      �� $��7,7,7,4q�6   
������� �� Padding$ 5q�68   $��0��6D   ._�5'      �� $��5q�6   
�������$��1q�6<   $	��Top=�6P   
������� J� Effect 5(      3  -System.Windows.Media.Effects.DropShadowEffect  5)      	   Color$	 DimGray��6+   6=   ._�5,      �� $
��10,2q�6!   
 �� Orientation$
 
Horizontal=�6/   $��Center=�6H   .+�5-      �� $��0,0,5,0q�6$   $
��Bold"�65   $��Center=�6G   $��0��6b   $��0��6r   Year:6�   �� 5/      $ �� IsSynchronizedWithCurrentItem$
 TrueY�6N   $��24��6�   $��Center=�6�   $	��250��6�   $��0��6�   $��1��6  ��6#   �� *Years+ �� Mode$ TwoWay=� �� SelectedItem 6s   �� *Year+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=���50      �� 51   "   .R�52   *   �� $��12(�64   ���	#FF413E3E$��Center=�6Y   ��6t   �� *Name+6�   53   #   55      �� 59      $��1,0,0,0q�6!   $��2��6W   $��24��6g   $��11(�6s   $��
Take Stock��6�   $
��Left=�6�   ��62   �� *TakeStockCommand+6�   =  7FirstFloor.ModernUI.Windows.Controls.ModernProgressRing  5:      $��15,0,0,0q�61   $��45��6_   $��45��6j      IsActive 6C   �� *IsBusy+��6v   �� *SelectedItem.Tag+ �� ElementName$ CmbRingStyle��5<      5=      5>      �� 5Z      $��2��6   $��5,0,5,5q�6&   $
 Vertical=�67   $��Stretch=�6N   .+�5[      �� $��2,0,2,0q�6   
�������._�5\      �� $��5q�6    $��Right=�6V   
�������$��12(�6�   ��6,   �� *RecordCount+$ TwoWay=�6�   5]      � 5`      $��Stretch=�6   .+�5a      �� 
�������
�������._�5b      &   System.Windows.Controls.DataGrid  -   5        $��cartDataGrid��5b   #      AreRowDetailsFrozen .    AutoGenerateColumns .     GridLinesVisibility$ 
Horizontal=�5g   #      HeadersVisibility$ Column=�5h   #   $��0q�5i   #   
�������   AlternatingRowBackground
 �����$	��446��5m   #   ��5c   #   �� *StockReviewDetails+ �� GroupStyleSelector 5f   #   Z�  �� 
GroupStyle 5u      (  "System.Windows.Controls.GroupStyle  5v   "      ContainerStyle 5�   &   �� 5�   *   " ��60   .�5�   .   ��  � �� 5�   2   �� 5�   6   " ��6F   .R�5�   :   9� $	��0,1q�6C   
�������
�������$	��0,1q�6}   ��5�   >   �� 5�   B   $	��0,3q�6I   ._�5�   F   �� $
 
Horizontal=�6Q   .+�5�   J   �� $
��Bold"�6o   ��6T   ��  �� Path$
 Name�6o   �� 5�   J   $��10,0,0,0q�6T   $��(��6f   $
��Bold"�6o   �� 5�   J   $
��Bold"�6t   ��6T   �� $ 	ItemCount�6t   �� 5�   J   $��5,0,0,0q�6T   $��Items��6e   $
��Bold"�6r   �� 5�   J   $��)��6T   $
��Bold"�6]   5�   G   5�   C   .��5�   >   �� 5�   ;   5�   7   5�   /   5�   +   5�   #      Columns 5�      4  .System.Windows.Controls.DataGridTemplateColumn  5�   "   ,  &System.Windows.Controls.DataGridColumn   Header$ Stock��69      CellTemplate 5�   &   �� 5�   *   .R�5�   .   �� $	��5,0q�68   $��Center=�6`   $��Verdana)�6{   $��11(�6�   
���   �$
��Wrap=�6�   ��6E   �� *	StockName+6�   5�   +   5�   #     5�   "   $ Stock Start Balance��69    5�   &   �� 5�   *   .R�5�   .   �� $	��5,0q�68   $��Center=�6j   $��Verdana)�6�   $��11(�6�   
���   �$
��Wrap=�6�   ��6E   �� *InitialStockBalance+6�   5�   +   5�   #     5�   "   $ Stock Start Balance Value��69    5�   &   �� 5�   *   .R�5�   .   �� $	��5,0q�68   $��Center=�6�   $��Right=�6�   $��Verdana)�6�   $��11(�6�   
���   �$
��Wrap=�6  ��6E   �� *InitialStockBalanceValue+ �� 	Converter# [  6  5�   +   5�   #     5�   "   $ Qty Purchased��69    5�   &   �� 5�   *   .R�5�   .   �� $	��5,0q�68   $��Center=�6o   $��Verdana)�6�   $��11(�6�   
���   �$
��Wrap=�6�   ��6E   �� *QuantityPackagePurchased+6�   5�   +   5�   #     5�   "   $ Qty Sold��69    5�   &   �� 5�   *   .R�5�   .   �� $	��5,0q�68   $��Center=�6j   $��Verdana)�6�   $��11(�6�   
���   �$
��Wrap=�6�   ��6E   �� *QuantityPackageSold+6�   5�   +   5�   #     5�   "   $ Stock Balance��69    5�   &   �� 5�   *   .R�5�   .   �� $	��5,0q�68   $��Center=�6j   $��Verdana)�6�   $��11(�6�   
���   �$
��Wrap=�6�   ��6E   �� *StockPackageBalance+6�   5�   +   5�   #     5�   "   $ Stock Balance Value��69    5�   &   �� 5�   *   .R�5�   .   �� $	��5,0q�68   $��Center=�6�   $��Right=�6�   $��Verdana)�6�   $��11(�6�   
���   �$
��Wrap=�6   ��6E   �� *StockBalanceValue+# [  6   5�   +   5�   #     5�   "   $ Total Sales��69    5�   &   �� 5�   *   .R�5�   .   �� $	��5,0q�68   $��Center=�6�   $��Right=�6�   $��Verdana)�6�   $��11(�6�   
���   �$
��Wrap=�6�   ��6E   �� *SellingPrice+# [  6�   5�   +   5�   #     5�   "   $ Total Discount��69    5�   &   �� 5�   *   .R�5�   .   �� $	��5,0q�68   $��Right=�6�   $��Center=�6�   $��Verdana)�6�   $��11(�6�   
���   �$
��Wrap=�6�   ��6E   �� *
Discount+# [  6�   5�   +   5�   #   5�      5�      5�      5     5     5     5
     