   M S B A M L   `   `   `  ����O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.InfrastructurePokno.Infrastructure.Converters  5       Pokno.Store,   &Pokno.Store.Views.Setup.StockPriceView   5      U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      UtoolkitAhttp://schemas.microsoft.com/winfx/2006/xaml/presentation/toolkit     5      a	converterKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.Infrastructure     5      X TXceed.Wpf.Toolkit, Version=2.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5        � 	Resources  5      4   .Pokno.Infrastructure.Converters.MoneyConverter   MoneyConverter6   0Pokno.Infrastructure.Converters.IsExistConverter  PriceExistConverterC   =Pokno.Infrastructure.Converters.MakeComboBoxItemBoldConverter  MakeComboBoxItemBold��%W   &	        &	      &	 &       5   
   6#     5   
   6%     5   
   62   5      .��5      � $��3q�6   .+�5   
   � $��0,0,0,0q�6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��auto �6    �� 5      $��* �6    .+�5      �� 
�������$��	7,7,10,10q�6'   $��1q�6:   
�������$��0��6b    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ DimGray��6'   ._�5      � $��15,10q�6    � ColumnDefinitions 5       �� 5!      $	��117 �6+   �� 5"      $	��220 �6+   �� 5#      $��* �6+    5%      �� 5&      $
��Auto �6(   �� 5'      $
��auto �6(   .+�5*      �� $
��Bold"�6    
�������$��Center=�6E   $��0��6`   $��0��6p   �� 6~   $�Stock:��6�   6�   �� 5,      $ �� IsSynchronizedWithCurrentItem$
 TrueY�6K   $��Center=�6�   $��0��6�   $��1��6�   $��0,3,0,0q�6�   ��6   �� *Stocks+ �� Mode$ TwoWay=� �� SelectedItem 6p   �� *Stock+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=���5-      �� 5.      .R�50   "   �� 	 �� Orientation$	 
Horizontal=�6-   .+�51   &   �� ��60   �� *
HasPrice+
 �� 	Converter#
 [ ��6�   �� *
HasPrice+#
 [ ��6�   �� *Name+52   #   53      55      57      58      �� 5:      
�������$��	7,3,10,10q�6(   $��0,0,1,1q�6;   
�������$��1��6h    5;        5<      $ DimGray��6'   ._�5?      �� $��8q�6   
�������$��3q�69   ._�5@      � $	��5,5q�6    5A      �� 5B      $	��120 �6/   �� 5C      $	��220 �6/   �� 5D      $��* �6/    5F      �� 5G      $
��Auto �6,   �� 5H      $
��Auto �6,   �� 5I      $
��Auto �6,   �� 5J      $
��Auto �6,   �� 5K      $
��Auto �6,   �� 5L      $
��Auto �6,   .+�5N      �� $
��Bold"�6$   $��0��66   $��0��6F   �� 6T   $�Package:��6X   6k   �� 5P      $
 TrueY�6Q   $��0��6�   $��1��6�   $��0,3,0,0q�6�   ��6#   �� *
Packages+$ TwoWay=� 6v   �� *	Package+$ TwoWay=�$ PropertyChanged=���5Q      �� 5R   "   .R�5S   &   �� $	 
Horizontal=�61   .+�5T   *   �� ���	#FF413E3E��6K   �� *Package.Name+5U   '   5V   #   5X      �� 5Z      $
��Bold"�6$   $��0��66   $��3��6F   $��0,3,0,0q�6S   �� 6e   $�Cost Price:��6i   6   %  Xceed.Wpf.Toolkit.DecimalUpDown  5[      $��0,3,0,0q�6b   $��1��6s   $��3��6�   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Maximum$ 99999999999999X�6�      Value 6-   �� *TargetModel.CostPrice+$ TwoWay=�6�   �� 5]      $
��Bold"�6$   $��0��66   $��4��6F   $��0,3,0,0q�6S   �� 6e   $�Selling Price:��6i   6�     5^      $��0,3,0,0q�6e   $��22��6v   $��1��6�   $��4��6�   $ 99999999999999X�6�    6-   �� *TargetModel.SellingPrice+$ TwoWay=�6�   �� 5`      $��1��6@   $��5��6P   $	��Add��6]   $
��Left=�6k   $��0,3,2,0q�6�   ��6!   �� *
AddCommand+6�   �� 5b      $��Bottom=�6N   $��Right=�6i   
�������$��Italic$�6�   $��12(�6�   $
��Bold"�6�   $��2��6�   $��4��6�   ��6$   �� *RecordCount+$ TwoWay=�6�   5c      5d      5f      �� 5g      $��2��6   $��	7,5,10,10q�6"   
������� 5h        5i      $ DimGray��6'   ._�5l      �� $��15q�6   $	 Vertical=�6*   $��Stretch=�6A   .+�5m      � $��2,0,2,3q�6    5n      �� 5o      �� 5p      .+�5s      �� $��Bottom=�6$   STOCK PRICE6L   �� 5t      $��1��6%   $��Center=�65   $��Right=�6P   $	 
Horizontal=�6l   .+�5u      �� $��0,0,2,0q�6(   $��Center=�69   Record Count6c   �� 5v      
���   �$��20��68    �� CornerRadius$ 15��6F   $��Center=�6X   ._�5w   "   �� 
�������$��Center=�6g   $��Center=�6�   $
��Bold"�6�   ��6,   �� *	ItemCount+$ TwoWay=�6�   5x      5z      5{      � 5}      $��Stretch=�6   .+�5~      �� 
�������$��0,0,0,0q�60   ._�5      &   System.Windows.Controls.DataGrid     AreRowDetailsFrozen .    AutoGenerateColumns .     HeadersVisibility$ Column=�5�      $	��175��5�      ��5�      �� *TargetCollection+$ TwoWay=�   Columns 5�      4  .System.Windows.Controls.DataGridTemplateColumn  5�   "   ,	  &System.Windows.Controls.DataGridColumn 	  Header$ Stock��69      CellTemplate 5�   &   �� 5�   *   .R�5�   .   �� $	��5,0q�68   $��12(�6E   $
��Wrap=�6|   ��6S   �� *StockPackage.Stock.Name+6|   5�   +   5�   #     5�   "   $ Package��69    5�   &   �� 5�   *   .R�5�   .   �� $	��5,0q�68   $��12(�6E   $
��Wrap=�6~   ��6S   �� *StockPackage.Package.Name+6~   5�   +   5�   #     5�   "   $ 
Cost Price��69    5�   &   �� 5�   *   .R�5�   .   �� $	��5,0q�68   $��12(�6E   $��Right=�6�   $
��Wrap=�6�   ��6S   �� *	CostPrice+#
 [  6�   5�   +   5�   #     5�   "   $ Selling Price��69    5�   &   �� 5�   *   .R�5�   .   �� $	��5,0q�68   $��12(�6E   $��Right=�6�   $
��Wrap=�6�   ��6S   �� *SellingPrice+#
 [  6�   5�   +   5�   #   5�      5�      5�      �� 5�      $��0,3,0,4q�6   $��Stretch=�6.   ._�5�      �� $��2��6!   $��Right=�6.   $	 
Horizontal=�6J   .+�5�      �� $��Clear��6B   $��0,0,2,0q�6R   ��6!   �� *ClearCommand+6R   �� 5�      $��0,0,2,0q�6%   $��Remove Selected Item��6X   ��66   �� *RemoveCommand+6X   �� 5�      $��0,0,2,0q�6%   $��Delete��6X   ��66   �� *DeleteCommand+6X   �� 5�      $
��Save��6E   ��6%   �� *SaveCommand+6E   5�      5�      5�      5�      5�      5�      5�      