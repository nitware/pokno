   M S B A M L   `   `   `  ����O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.InfrastructurePokno.Infrastructure.Converters  5      p lSystem.Windows.Controls.Input.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35pTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.ToolkitSystem.Windows.Controls 5       Pokno.Store+   %Pokno.Store.Views.StockPriceCheckView   5      U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      a	converterKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.Infrastructure     5      iControlsTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.Toolkit     5      X TXceed.Wpf.Toolkit, Version=2.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5        � 	Resources  5      3   -Pokno.Infrastructure.Converters.DateConverter   DateConverter;   5Pokno.Infrastructure.Converters.CheckToolTipConverter  CheckToolTipConverter;   5Pokno.Infrastructure.Converters.DateToSelectConverter  DateToSelectConverter4   .Pokno.Infrastructure.Converters.MoneyConverter  MoneyConverter8   2Pokno.Infrastructure.Converters.EnabilityConverter  EnabilityConverter  AutoCompleteBoxItemTemplate �� Orientation��%H  &	        &	      &	 &     &	 9     &	 L     &	 _       5   
   6"     5   
   6*     5   
   6*     5   
   6#     5   
   6'   �� 5   
   .R�5      �� $ 
Horizontal=�6   .+�5      �� $	��5,2q�6   $	��100��6>   $
��Bold"�6N   
���������6%   �� *Name+6`   5      5      5      .��5      �� $��Stretch=�6R   {�6   �� *PurchasedStockCanBeEdited+ �� Mode$ TwoWay=�.��5   
   � -   5         �Name$ 
LayoutRoot��5      $��5q�6#   ���	#E7FFFFFF � ColumnDefinitions 5      �� 5      $��6* �6#   �� 5       $��5* �6#   .+�5*      �� $��10,10,15,10q�6   $��1��6*    �� CornerRadius$ 0,20,0,0��6:   
�������
�������$��1q�6x    J� Effect 5+      3  -System.Windows.Media.Effects.DropShadowEffect  5,         Color$ DimGray��6'   ._�5/      � $��0,5,0,5q�6    � RowDefinitions 50      �� 51      $
��Auto �6$   �� 52      $
��auto �6$   �� 53      $
��auto �6$   �� 54      $
��auto �6$   .+�5r      � $��1��6   $��0��6$   $��2,5,2,5q�64    5s      �� 5t      �� 5u      .+�5x      �� $��0q�6   $��2��6(   ._�5z      �� .+�5{   "   �� $	��2,0q�6)   $��0��66   $��0��6C   $��2��6S   $ 2,2,0,0��6g   ._�5|   &   �� $��0,0,0,0q�61   .+�5}   *   �� $��Stretch=�61   ._�5~   .   �� $
��Bold"�68   $��15(�6J   
�������STOCK PRICE LIST6|   5   +   5�   #   5�      &   System.Windows.Controls.DataGrid  5�   "   	   AreRowDetailsFrozen	 . 
   AutoGenerateColumns
 .     GridLinesVisibility$ 
Horizontal=�5�   #      HeadersVisibility$ Column=�5�   #   $��0q�5�   #   
�������   AlternatingRowBackground
 �����$	��466��5�   #   ��5�   +   �� *StockPrices+ �� GroupStyleSelector 5�   #   Z�  �� 
GroupStyle 5�   &   (  "System.Windows.Controls.GroupStyle  5�   *      ContainerStyle 5�   .   �� 5�   2    �� 
TargetType" ��68   .�5�   6   ��  �� Property � �� �� Value 5�   :   �� 5�   >    �� 
TargetType" ��6N   .R�5�   B   9� $	��0,1q�6K   
�������
�������$	��0,1q�6�   ��5�   F   �� 5�   J   $	��0,3q�6Q   ._�5�   N   �� $ 
Horizontal=�6Y   .+�5�   R   �� $
��Bold"�6w   ��6\   ��  �� Path$
 Name�6w   �� 5�   R   $��10,0,0,0q�6\   $��(��6n   $
��Bold"�6w   �� 5�   R   $
��Bold"�6|   ��6\   �� $ 	ItemCount�6|   �� 5�   R   $��5,0,0,0q�6\   $��Items��6m   $
��Bold"�6z   �� 5�   R   $��)��6\   $
��Bold"�6e   5�   O   5�   K   .��5�   F   �� 5�   C   5�   ?   5�   7   5�   3   5�   +      Columns 5�   &   4	  .System.Windows.Controls.DataGridTemplateColumn	  5�   &   ,
  &System.Windows.Controls.DataGridColumn 
  Header$ Package��6=    	  CellTemplate 5�   *   �� 5�   .   .R�5�   2   �� $��5,0,3,0q�6<   $��11(�6M   $��Center=�6x   $
��Wrap=�6�   ��6[   �� *PackageName+6�   5�   /   5�   '   	  5�   &   $ 
Cost Price��6=    5�   *   �� 5�   .   .R�5�   6   �� $��5,0,3,0q�6@   $��11(�6Q   $��Right=�6�   $��Center=�6�   $
��Wrap=�6�   ��6_   �� *	CostPrice+ �� 	Converter# [ 6�   5�   /   5�   '   	  5�   &   $ Selling Price��6=    5�   *   �� 5�   .   .R�5�   6   �� $��5,0,0,0q�6@   $��11(�6Q   $��Right=�6�   $��Center=�6�   $
��Wrap=�6�   ��6_   �� *SellingPrice+# [ 6�   5�   /   5�   '   	  5�   *   $ Profit��6A    5�   .   �� 5�   2   .R�5�   6   �� $��5,0,0,0q�6@   $��11(�6Q   $��Right=�6�   $��Center=�6�   $
��Wrap=�6�   ��6_   �� *Profit+# [ 6�   5�   3   5  +   5     5
     5     5     5     5     �� 5     $��0��6   $��10,10,10,15q�6)   $	��Top=�6>   .+�5     �� 
�������$ 20,0,0,0��6,   
�������$��1,1,1,1q�6W    5       5     $ DimGray��6+   ._�5     �� $ Vertical=�6)   $��10,10,10,10q�6@   .+�5   "   �� $��0,0,0,0q�6)   $ 5,5,0,5��6C   ._�5"  &   �� $��0,0,0,0q�61   .+�5?  "   �� $��0��6)   $��2,10,2,2q�69    �� Padding$ 2q�6K   $ 2��6W   
�������$��1q�6�   
�������._�5@  &   � $��0,0,0,0q�6+    5A  *   �� 5B  .   $
��auto �6?   �� 5C  .   $��* �6?   �� 5D  .   $
��auto �6?   .+�5G  *   �� $��1q�60   $��25��6;   $��25��6G   $��UniformToFill=�6R   ��6j   �� *
SearchIcon+-  'System.Windows.Controls.AutoCompleteBox  5H  *   $��1��6C   
�������$��1q�5J  9      ValueMemberPath$
 Name��5L  9      ItemTemplate# [ 5M  9      IsTextCompletionEnabled .    ItemsSource 5H  S   �� *Stocks+   SelectedItem 5K  9   �� *Stock+$ TwoWay=�  �� UpdateSourceTrigger$  PropertyChanged=�5P  +   5S  #   5T  #   �� 5s  "   $��2,0,2,0q�6)   ���#e0eaf6$��1��6O   $��2��6_   $��0��6s   ._�5t  .   �  5u  2   �� 5v  6   �� 5w  6   �� 5x  6    5{  2   �� 5|  6   $
��auto �6D   �� 5}  6   $
��auto �6D   5�  /   5�  +     5�  "   {�.  $��0q�5�  +   
�������
�������	 . 
 .  
 �����$ Column=�5�     $	��200��5�     ��5�  +   �� *SearchedStockPrices+ 5�  .   	  5�  *   $ Package��6A    5�  .   �� 5�  2   .R�5�  6   �� $��5,0,3,0q�6@   $��12(�6Q   $��Center=�6|   $
��Wrap=�6�   ��6_   �� *PackageName+6�   5�  3   5�  +   	  5�  *   $ Stock��6A    5�  .   �� 5�  2   .R�5�  6   �� $��3,0,3,0q�6@   $��12(�6Q   $��Center=�6z   $
��Wrap=�6�   ��6_   �� *	StockName+6�   5�  3   5�  +   	  5�  *   $ 
Cost Price��6A    5�  .   �� 5�  2   .R�5�  6   �� $��5,0,3,0q�6@   $��12(�6Q   $��Right=�6�   $��Center=�6�   $
��Wrap=�6�   ��6_   �� *	CostPrice+# [ 6�   5�  3   5�  +   	  5�  *   $ Selling Price��6A    5�  .   �� 5�  2   .R�5�  6   �� $��5,0,0,0q�6@   $��12(�6Q   $��Right=�6�   $��Center=�6�   $
��Wrap=�6�   ��6_   �� *SellingPrice+# [ 6�   5�  3   5�  +   	  5�  *   $ Profit��6A    5�  .   �� 5�  2   .R�5�  6   �� $��5,0,0,0q�6@   $��12(�6Q   $��Right=�6�   $��Center=�6�   $
��Wrap=�6�   ��6_   �� *Profit+# [ 6�   5�  3   5�  +   5�  +   5�  '   5�  #   5�     5�     5�     5�     5�     5�     