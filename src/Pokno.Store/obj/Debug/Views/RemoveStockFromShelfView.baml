   M S B A M L   `   `   `  ����p  lSystem.Windows.Controls.Input.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35pTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.ToolkitSystem.Windows.Controls  5      O KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.InfrastructurePokno.Infrastructure.Converters 5	       Pokno.Store0   *Pokno.Store.Views.RemoveStockFromShelfView   5      U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      P LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8)prismhttp://www.codeplex.com/prism  5      cControlsTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.Toolkit  5      c	 _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity 	 5      [	converterKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.Infrastructure 	 5	      X
 TXceed.Wpf.Toolkit, Version=2.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit 
 5
      Z VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI  5        � 	Resources  5      8  2Pokno.Infrastructure.Converters.EnabilityConverter   EnabilityConverter;  5Pokno.Infrastructure.Converters.CheckToolTipConverter  CheckToolTipConverter;  5Pokno.Infrastructure.Converters.ReorderLevelConverter  ReorderLevelConverterE  ?Pokno.Infrastructure.Converters.ReorderLevelFontWeightConverter # ReorderLevelFontWeightConverter % !UnsoldStockPackagesAtHandTemplate �� Orientation �� Mode �� 	Converter  UnsoldStockPackagesTemplate �� ItemTemplate �� ItemsSource & "StockPurchasedTreeViewItemTemplate  AutoCompleteBoxItemTemplate��%  &	        &	      &	 &     &	 9     &	 L     7  7  7  7  &	 6    7  &	     7  &	 �      5   
   6'     5   
   6*     5   
   6*     5   
   64   �� 5   
   .R�5      �� $ 
Horizontal=�6   .+�5      �� $��0,0,5,0q�6   $��11(�5      $��Center=�5      ��5      �� *
Quantity+$ TwoWay=���5      �� *ReorderLevel+8   ��5      �� *ReorderLevel+8  5      �� 5      $��0,0,0,0q�6   $��11(�5"      $��Center=�5#      ��5      �� *StockPackage.Package.Name+��5       �� *ReorderLevel+8  ��5!      �� *ReorderLevel+8  5#      5$      5%      �� 5'   
   8    5)   #   �� *Shelfs+$ TwoWay=�.R�5*      �� $ 
Horizontal=�6   .+�5+      �� $��0,0,5,0q�6   $
��Bold"�6-   
�������$
��Wrap=�6o   ��6S   �� *
Stock.Name+6o   5,      5-      �� 5/   
   8    51   #   �� *UnsoldStockPackages+.R�52      �� $ 
Horizontal=�6   .+�53      �� $��0,0,5,0q�6   $
��Bold"�6-   $
��Wrap=�6_   ��6?   �� *StockType.Name+6_   54      55      �� 59   
   .R�5:      �� $ 
Horizontal=�6   .+�5;      �� $	��5,2q�6   $	��100��6>   $
��Bold"�6N   
���������6%   �� *Name+6`   5<      5=      5>      .��5@      � -   5         �Name$ 
LayoutRoot��5@      $��1q�6   .+�5A   
   �  � ColumnDefinitions 5B      �� 5C      $��3* �6#   �� 5D      $��5* �6#   .+�5G      � $��1��6    � RowDefinitions 5H      �� 5I      $
��auto �6$   �� 5J      $
��auto �6$   �� 5K      $
��auto �6$    5N      �� 5O      .+�5R      �� $��1��6   $��1��6&   $��5,5,5,2q�66   
�������$��0,0,0,0q�6Z   ._�5S      �� $��0,0,0,0q�6   ._�5T      �� .+�5U      � $��0,2,0,2q�6#    5V   "   �� 5W   &   $
��Auto �67   �� 5X   &   $��* �67   .+�5[   "   �� $	��3,0q�6-   $ 
Horizontal=�6:   .+�5\   &   �� $��0,0,3,0q�60   
�������$
��Bold"�6T   $��Bottom=�6f   Item Count:6�   �� 5]   &   
�������$
��Bold"�6b   $��0,0,7,0q�6t   $��Bottom=�6�   ��60   �� *CartItemCount+6�   5^   #   �� 5`   "   $	��2,0q�6-   $��1��6:   $ 
Horizontal=�6J   $��Right=�6c   .+�5a   &   �� $��0,0,3,0q�6S   $��9(�6d   $��Remove Selected Item��6q   $��20��6�   ��6-   �� *RemoveItemCommand+6�   �� 5b   &   $��9(�6N   $��Clear All Item��6[   $��20��6t   ��6-   �� *ClearCommand+6t   5c   #   5d      &   System.Windows.Controls.DataGrid  5f      -   5        	  Name$	 cartDataGrid��5f   '   
   AreRowDetailsFrozen
 .    AutoGenerateColumns .     HeadersVisibility$ Column=�5j   	   
�������$	��465��5n   	   ��5g   	   �� *StocksForSale+ �� SelectedItem 5l   !   �� *StockForSale+ �� SelectedIndex 5m   !   �� *CartDataGridSelectedIndex+$ TwoWay=�. 	 (System.Windows.Interactivity.Interaction   Triggers 5p   "   / 	 )System.Windows.Interactivity.EventTrigger  5q   &      	EventName$ SelectionChanged��65   . 	 (System.Windows.Interactivity.TriggerBase   Actions. 5r   *   6	 	 0System.Windows.Interactivity.InvokeCommandAction	   	  Command 6@   �� *SelectionChangedCommand+ 	  CommandParameter 6l   �� *SelectedItem+ �� ElementName$ cartDataGrid��$ OneWay=�5s   '      Columns 5v   "   4
  .System.Windows.Controls.DataGridTemplateColumn
  5w   &   ,  &System.Windows.Controls.DataGridColumn   Header$
 Item��6=    
  CellTemplate 5x   *   �� 5y   .   .R�5z   2   �� $	��5,0q�6<   $��Center=�6r   $��Verdana)�6�   $��11(�6�   
���   �$
��Wrap=�6�   ��6I   �� *StockPackage.Stock.Name+6�   5{   /   5}   '   
  5   &   $ Package��6=    5�   *   �� 5�   .   .R�5�   2   �� $	��5,0q�6<   $��Center=�6t   $��Verdana)�6�   $��11(�6�   
���   �$
��Wrap=�6�   ��6I   �� *StockPackage.Package.Name+6�   5�   /   5�   '   
  5�   &   $ Quantity��6=    5�   *   �� 5�   .   .R�5�   2   % 
 Xceed.Wpf.Toolkit.IntegerUpDown  $��Center=�6�   $��Verdana)�6�   $��12(�6�   
���   �� 
 �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Minimum$ 1X�6�      Value 6E   �� *
Quantity+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   5�   /   5�   '   5�      5�      5�      5�      �� 5�      $	��5,0q�6   $��2��6&   $��1��63   ._�5�      �� $ 
Horizontal=�6!   $
��Left=�6:   .+�5�      �� $��18(�6A   $��Remove��6O   ��6!   �� *SaveCommand+6O   =  7FirstFloor.ModernUI.Windows.Controls.ModernProgressRing  5�      $��15,0,0,0q�61   $��40��6_   $��40��6j      IsActive 6C   �� *IsBusy+��6v   �� *SelectedItem.Tag+$ CmbRingStyle��5�      5�      5�      �� 5�      $��	5,5,10,10q�6   
�������$��1q�6;   
���iii�$��0��6e   $��3��6r   $��0��6�    J� Effect 5�      3  -System.Windows.Media.Effects.DropShadowEffect  5�         Color$ DimGray��6'   ._�5�      �� $��7q�6   .+�5�      �� $��0��6   $��0,0,0,3q�6-    �� Padding$ 2q�6>    �� CornerRadius$ 2��6J   
�������$��1q�6s   
�������._�5�      � $��0,0,0,0q�6    5�      �� 5�   "   $
��auto �63   �� 5�   "   $��* �63   �� 5�   "   $
��auto �63   .+�5�      �� $��1q�6$   $��25��6/   $��25��6;   $��UniformToFill=�6F   ��6^   �� *
SearchIcon+-   'System.Windows.Controls.AutoCompleteBox  5�      $��1��67   
�������$��1q�5�   9       ValueMemberPath$
  Name��5�   9   !   ItemTemplate#! [ 5�   9   "   IsTextCompletionEnabled" . #   ItemsSource# 5�   G   �� *Stocks+$   SelectedItem$ 5�   9   �� *Stock+$ TwoWay=�$ PropertyChanged=�5�      �� 5�      $��1,0,0,0q�6%   $��1��66   $��9(�6h   $	��...��6u   % � ToolTip$% Re-load stocks on shelf��6�   $��Right=�6�   ��6F   �� *ReloadCommand+6�   5�      5�      �� 5�      $��Stretch=�6   
���iii�._�5�      �� $��10,5,0,5q�6$   $
��Bold"�66   
�������$��13(�6`   �� 6p   $�STOCK ON SHELF��6t   6�   5�      R� 5�      -   5        & R�Name$& treeView��5�      $��2,0,0,0q�61   
�������
�������$��0q�5      $	��445��5     $
��Auto=�5     #��[ 5     ��5     �� *StocksOnShelfAtHand+$ TwoWay=� 5       5     $ SelectedItemChanged��6-   . 5	  "   	   68   �� *$"TreeViewSelectedItemChangedCommand+ 6o   �� *SelectedItem+$ treeView��$ OneWay=�5
     5     5     5     5     5     5     