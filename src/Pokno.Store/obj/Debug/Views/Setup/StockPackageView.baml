   M S B A M L   `   `   `  ����O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.InfrastructurePokno.Infrastructure.Converters  5       Pokno.Store(   "Pokno.Store.Views.StockPackageView   5      U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      UtoolkitAhttp://schemas.microsoft.com/winfx/2006/xaml/presentation/toolkit     5      a	converterKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.Infrastructure     5      X TXceed.Wpf.Toolkit, Version=2.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5        � 	Resources  5      9   3Pokno.Infrastructure.Converters.VisibilityConverter   VisibilityConverter6   0Pokno.Infrastructure.Converters.IsExistConverter  PackageExistConverterC   =Pokno.Infrastructure.Converters.MakeComboBoxItemBoldConverter  MakeComboBoxItemBold��%W   &	        &	      &	 &       5   
   6(     5   
   6%     5   
   62   5      .��5      � $��3q�6   .+�5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��auto �6    �� 5      $��* �6    .+�5      �� 
�������$��	7,7,10,10q�6'    �� CornerRadius$ 3��6:    �� Padding$	 0,3q�6K   $��1q�6Y   
�������$��0��6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ DimGray��6'   ._�5       � $��15,10q�6    � ColumnDefinitions 5!      �� 5"      $	��117 �6+   �� 5#      $	��220 �6+   �� 5$      $��* �6+    5&      �� 5'      $
��Auto �6(   �� 5(      $
��auto �6(   .+�5+      �� $
��Bold"�6    
�������$��Center=�6E   $��0��6`   $��0��6p   Stock:6�   �� 5-      $ �� IsSynchronizedWithCurrentItem$
 TrueY�5/      $��Center=�50      $��0��51      $��1��52      ��5-      �� *Stocks+ �� Mode$ TwoWay=�	 �� SelectedItem	 5.      �� *Stock+$ TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=���53      �� 54      .R�55   "   ��  �� Orientation$ 
Horizontal=�6-   .+�56   &   �� ��60   �� *Name+��6F   �� *
HasPackage+ �� 	Converter# [ ��6�   �� *
HasPackage+# [ 57   #   58      5:      5<      5=      �� 5?      
�������$��	7,3,10,10q�6(   $ 3��6;   $��0,0,1,1q�6L   
�������$��1��6y    5@        5A      $ DimGray��6'   ._�5D      �� $��8q�6   
�������$ 2��69   $��3q�6J   ._�5E      � $	��4,7q�6    5F      �� 5G      $	��120 �6/   �� 5H      $	��220 �6/   �� 5I      $��* �6/    5K      �� 5L      $
��Auto �6,   �� 5M      $
��auto �6,   �� 5N      $
��auto �6,   �� 5O      $
��auto �6,   �� 5P      $
��auto �6,   .+�5S      �� $
��Bold"�6$   $��0��66   $��0��6F   �� 6T   $�Package:��6X   6k   �� 5T      $
 TrueY�5V   #   $��0��5W   #   $��1��5X   #   $��0,3,0,0q�5Y   #   ��5T   #   �� *
Packages+$ TwoWay=�	 5U   #   �� *	Package+$ TwoWay=�$
 PropertyChanged=���5Z      �� 5[   "   .R�5\   &   �� $ 
Horizontal=�61   .+�5]   *   �� $��Verdana)�64   ���	#FF413E3E��6`   �� *Name+5^   '   5_   #   5a      �� 5c      $
��Bold"�6$   $��0��66   $��1��6F   $��0,3,0,0q�6S   �� 6e   $�Re-Order Level:��6i   6�   %  Xceed.Wpf.Toolkit.IntegerUpDown  5d      $��0,3,0,0q�6e   $��1��6v   $��1��6�   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Maximum$ 1000000X�6�      Value 6-   �� *TargetModel.ReOrderLevel+$ TwoWay=�6�   �� 5f      $
��Bold"�6$   $��0��66   $��2��6F   $��0,3,0,0q�6S   �� 6e   $�Expiry Days Alert:��6i   6�     5g      $��0,3,0,0q�6h   $��1��6y   $��2��6�   $ 1000000X�6�    6-   �� *TargetModel.ExpiryDaysAlert+$ TwoWay=�6�   �� 5i      $
��Bold"�6$   $��0��66   $��3��6F   $��0,3,0,0q�6S   �� 6e   $�Description:��6i   6�   �� 5j      $��1��6"   $��3��62   $��0,3,0,0q�6?   $��50��6�    �� TextWrapping$
 Wrap=�6�   ��6P   �� *TargetModel.Description+$ TwoWay=�6�   �� 5l      $��1��6@   $
��Left=�6P   $��4��6k   $	��Add��6x   $��0,4,0,0q�6�   ��6!   �� *
AddCommand+6�   �� 5m      $��Bottom=�6N   $��Right=�6i   
�������$��Italic$�6�   $��12(�6�   $
��Bold"�6�   $��2��6�   $��4��6�   ��6$   �� *RecordCount+$ TwoWay=�6�   5n      5o      5q      �� 5r      $��2��6   $��	7,3,10,10q�6"   $ 3��65   
������� 5s        5t      $ DimGray��6'   ._�5w      �� $��10q�6   $ Vertical=�6)   $��Stretch=�6@   .+�5y      �� 
�������$��Stretch=�6,   ._�5z      � $��2,0,2,3q�6    5{      �� 5|   "   �� 5}   "   .+�5�      �� $��Bottom=�6(    PACKAGES ASSOCIATED WITH STOCK6c   �� 5�      $��1��6)   $��Center=�69   $��Right=�6T   $ 
Horizontal=�6p   .+�5�   "   �� $��0,0,2,0q�6,   $��Center=�6=   Record Count6g   �� 5�   "   
���   �$��20��6<   $ 15��6J   $��Center=�6\   ._�5�   &   �� 
�������$��Center=�6k   $��Center=�6�   $
��Bold"�6�   ��60   �� *	ItemCount+$ TwoWay=�6�   5�   #   5�      5�      5�      � 5�      $��Stretch=�6   .+�5�      �� 
�������$��0,0,0,0q�60   ._�5�      &   System.Windows.Controls.DataGrid     AreRowDetailsFrozen .    AutoGenerateColumns .     HeadersVisibility$ Column=�5�      $��Stretch=�5�      $	��175��5�      ��5�   #   �� *TargetCollection+$ TwoWay=�   Columns 5�      4  .System.Windows.Controls.DataGridTemplateColumn  5�   "   ,	  &System.Windows.Controls.DataGridColumn 	  Header$ Package��69      CellTemplate 5�   &   �� 5�   *   .R�5�   .   �� $	��5,0q�68   $��12(�6E   $
��Wrap=�6q   ��6S   �� *Package.Name+6q   5�   +   5�   #     5�   "   $ Stock��69    5�   &   �� 5�   *   .R�5�   .   �� $	��5,0q�68   $��12(�6E   $
��Wrap=�6o   ��6S   �� *
Stock.Name+6o   5�   +   5�   #     5�   "   $ Re-Order Level��69    5�   &   �� 5�   *   .R�5�   .   �� $	��5,0q�68   $��12(�6E   $��Center=�6q   $
��Wrap=�6�   ��6S   �� *ReOrderLevel+6�   5�   +   5�   #     5�   "   $ Expiry Days Alert��69    5�   &   �� 5�   *   .R�5�   .   �� $	��5,0q�68   $��12(�6E   $��Center=�6t   $
��Wrap=�6�   ��6S   �� *ExpiryDaysAlert+6�   5�   +   5�   #     5�   "   $ Description��69    5�   &   �� 5�   *   .R�5�   .   �� $	��5,0q�68   $��12(�6E   $
��Wrap=�6p   ��6S   �� *Description+6p   5�   +   5�   #   5�      5�      5�      �� 5�      $��0,0,0,4q�6   
�������$��Stretch=�6A   ._�5�      �� $��2��6%   $��3q�62   $��Right=�6=   $ 
Horizontal=�6Y   .+�5�      �� $��0,0,2,0q�6%   $��Clear��6W   ��66   �� *ClearCommand+6W   �� 5�      $��0,0,2,0q�6%   $��Remove Selected Item��6X   ��66   �� *RemoveCommand+6X   �� 5�      $��0,0,2,0q�6%   $��Delete��6X   ��66   �� *DeleteCommand+6X   �� 5�      $
��Save��6E   ��6%   �� *SaveCommand+6E   5�      5�      5�      5�      5�      5�      5�      