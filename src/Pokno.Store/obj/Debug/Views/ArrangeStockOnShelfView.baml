   M S B A M L   `   `   `  ����O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.InfrastructurePokno.Infrastructure.Converters  5      p lSystem.Windows.Controls.Input.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35pTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.ToolkitSystem.Windows.Controls 5
       Pokno.Store/   )Pokno.Store.Views.ArrangeStockOnShelfView   5      U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      UtoolkitAhttp://schemas.microsoft.com/winfx/2006/xaml/presentation/toolkit     5      a	converterKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.Infrastructure     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      X	 TXceed.Wpf.Toolkit, Version=2.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit 	 5	      cControlsTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.Toolkit 	 5
      Z
 VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI 
 5        � 	Resources  5      3   -Pokno.Infrastructure.Converters.DateConverter   DateConverter6   0Pokno.Infrastructure.Converters.IntegerConverter  IntegerConverter   PurchasedStockAtHandTemplate �� Orientation & "StockPurchasedTreeViewItemTemplate �� ItemTemplate �� ItemsSource  AutoCompleteBoxItemTemplate��%  &	        &	      &	 &     &	 `    7  &	 "      5   
   6"     5   
   6%   �� 5   
   .R�5      �� $ 
Horizontal=�6   .+�5      �� $��0,0,5,0q�6   $��Normal"�6G   $��10(�6[   $��Center=�6i   ��6-   �� *
Quantity+6i   �� 5      $��0,0,5,0q�6   
���iii�$��11(�6m   $��Center=�6{   ��6-   �� *StockPackage.Package.Name+6{   5      5      �� 5   
   8    5   '   �� *StockPurchases+.R�5      �� $ 
Horizontal=�6   .+�5       �� $��0,0,5,0q�6   $
��Bold"�6-   ��6?   �� *
Stock.Name+5!      5"      �� 5%   
   .R�5&      �� $ 
Horizontal=�6   .+�5'      �� $	��5,2q�6   $	��100��6>   $
��Bold"�6N   
���������6%   �� *Name+6`   5)      5*      5+      .��5-      � -   5         �Name$ 
LayoutRoot��5-      $��0q�6   .+�5.   
   �  � RowDefinitions 5/      �� 50      $
��Auto �6    �� 51      $
��auto �6    �� 52      $
��auto �6    �� 53      $
��auto �6    �� 54      $
��auto �6    �� 55      $
��auto �6    �� 56      $
��auto �6     � ColumnDefinitions 58      �� 59      $��3* �6#   �� 5:      $��5* �6#   .+�5=      �� $��0��6    �� CornerRadius$ 5��6"   $��1��63   $��5,5,10,5q�6C   
�������
�������$��1q�6{    J� Effect 5>      3  -System.Windows.Media.Effects.DropShadowEffect  5?      	   Color$	 DimGray��6'   ._�5B      �� .+�5C      � $
��10,3q�6    5D      �� 5E      $	��115 �6/   �� 5F      $	��150 �6/   �� 5G      $��* �6/    5I      �� 5J      $
��Auto �6,   �� 5K      $
��auto �6,   �� 5L      $
��auto �6,   �� 5M      $
��auto �6,   �� 5N      $
��auto �6,   �� 5O      $
��auto �6,   .+�5R      �� $��5,10,5,0q�6"   $��3��64   $��0��6H   $��0��6X   
�������$��Stretch=�6}   ._�5S      �� $��10q�6(   $��Bottom=�64   $��century Gothic)�6O   SELECTED STORE STOCK6�   5U      �� 5W      $��0��6$   $��1��64   $��5,5,0,0q�6A   Stock:6Z   �� 5X      $
��Bold"�6F   {�.  $��1��6j   $��1��6w   $��0,5,0,0q�6�   $��25��6�   ��6"   �� *SelectedStock.Name+6�   �� 5Y      $��2,5,0,0q�6"   $��2��64   $��1��6D   $��9(�6x   $��0q�6�   $
��Left=�6�   $��25��6�   
 � ToolTip$
 Change Stock Price��6�   $	��...��6�   ��6Q   �� *ChangePriceCommand+6�   �� 5]      $��0��6$   $��2��64   $��5,3,0,0q�6A   
Package:6\   �� 5_      $��3��6$   $��5,3,0,0q�61   $��22��6B   $	��Top=�6N   	Quantity:6q   % 	 Xceed.Wpf.Toolkit.IntegerUpDown  5`      $��0,3,0,0q�6�   $��22��6�   $��1��6�   $��3��6�   � 	 �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Minimum$ 0X�6�      Maximum$ 
1000000000X�6�      Value 6-   �� *Shelf.Quantity+ �� Mode$ TwoWay=� �� 	Converter# [ 6�   �� 5b      $��4��6$   $��5,3,0,0q�61   $��22��6B   $	��Top=�6N   Expiry Date:6t   (  "System.Windows.Controls.DatePicker  5c      $��4��6\   $��1��6i   $��23��6y   $��0,3,0,0q�6�   $	��Top=�6�      SelectedDate 6%   �� *Shelf.ExpiryDate+$ TwoWay=�6�   �� 5e      $ �� IsSynchronizedWithCurrentItem$
 TrueY�6|   $��1��6�   $��2��6�   $��0,3,0,0q�6�   $��23��6�   ��6#   �� *StockPackages+$ TwoWay=� �� SelectedItem 6V   �� *StockPackage+��5f      �� 5g   "   .R�5h   &   �� $ 
Horizontal=�61   .+�5i   *   �� ���	#FF413E3E��6K   �� *Package.Name+5j   '   5k   #   5m      �� 5o      $��5��6%   $��1��62   $
��Left=�6B   $��0,3,0,10q�6]   $ 
Horizontal=�6o   .+�5p      �� $��Add To Shelf��6K   ��6%   �� *AddToShelfCommand+6K   5q      = 
 7FirstFloor.ModernUI.Windows.Controls.ModernProgressRing  5s      $��1��61   $��4��6>   $��2��6O   $��5,0,0,0q�6_   $��80��6�   $��80��6�      IsActive 6p   �� *IsBusy+��6�   �� *SelectedItem.Tag+ �� ElementName$ CmbRingStyle��5u      5v      5w      � 5y      $��1��6   $��1��6    $��	5,10,10,8q�60   $��Stretch=�6C   .+�5z      �� ���#9FC0DB$ 10��6.   $��0,0,0,0q�6@   ._�5{      �� .+�5|      �� $��	10,10,7,5q�6!   $��Stretch=�64   ._�5}      �� $
��Bold"�6(   
�������$��century Gothic)�6R   STOCKS ON SHELF6�   5~      &   System.Windows.Controls.DataGrid  5         AreRowDetailsFrozen .    AutoGenerateColumns .  
�������   GridLinesVisibility$
 None=�5�         HeadersVisibility$
 None=�5�      $	��290��5�      ��5   #   �� *RemainingStocksOnShelf+   Columns 5�      4	  .System.Windows.Controls.DataGridTemplateColumn	  5�   "   ,
  &System.Windows.Controls.DataGridColumn 
  Header$ Quantity��69    	  CellTemplate 5�   &   �� 5�   *   .R�5�   .   �� $��3,0,3,0q�68   $��12(�6I   
���   �$��Right=�6�   $
��Wrap=�6�   ��6W   �� *
Quantity+6�   5�   +   5�   #   	  5�   "   $ Package��69    5�   &   �� 5�   *   .R�5�   .   �� $��3,0,3,0q�68   $��12(�6I   
���   �$
��Wrap=�6�   ��6W   �� *PackageName+6�   5�   +   5�   #   	  5�   "   $ Stock��69    5�   &   �� 5�   *   .R�5�   .   �� $��3,0,3,0q�68   $��12(�6I   
���   �$
��Wrap=�6�   ��6W   �� *	StockName+6�   5�   +   5�   #   5�      5�      5�      5�      �� 5�      $��	7,5,10,10q�6   $��0��6)   $��0��66   $��6��6F   
���iii�$��1,1,2,2q�6m   $ 5��6�   
������� 5�        5�      $	 DimGray��6'   ._�5�      �� .+�5�      �� $��0��6   $��
10,10,10,3q�6-    �� Padding$ 2q�6A   $ 2��6M   
�������$��1q�6v   
�������._�5�      � $��0,0,0,0q�6    5�      �� 5�   "   $
��auto �63   �� 5�   "   $��* �63   �� 5�   "   $
��auto �63   .+�5�      �� $��1q�6$   $��25��6/   $��25��6;   $��UniformToFill=�6F   ��6^   �� *
SearchIcon+-  'System.Windows.Controls.AutoCompleteBox  5�      $��1��67   
�������$��1q�5�   9      ValueMemberPath$
 Name��5�   9      ItemTemplate# [ 5�   9      IsTextCompletionEnabled .     ItemsSource  5�   G   �� *Stocks+!   SelectedItem! 5�   9   �� *Stock+$ TwoWay=�" �� UpdateSourceTrigger$" PropertyChanged=�5�      �� 5�      $��1,0,0,0q�6%   $��1��66   $��9(�6h   $	��...��6u   $
 Re-load stocks at hand��6�   $��Right=�6�   ��6F   �� *ReloadCommand+6�   5�      5�      �� 5�      
�������
�������$��	10,0,10,0q�6B   $��0,0,0,0q�6U   $��Stretch=�6o   ._�5�      �� $��10,7,0,7q�6$   $��13(�66   
�������$
��Bold"�6\   STOCKS IN STORE6   5�      R� 5�      -   5        # R�Name$# treeView��5�      $��	10,0,10,5q�5�      
���iii�$��0q�5�      $	��460��5�      $
��Auto=�5�      #��[ 5�      ��5�      �� *StockPurchasesAtHand+.  (System.Windows.Interactivity.Interaction$   Triggers$ 5�      /  )System.Windows.Interactivity.EventTrigger  5�      %   	EventName$% SelectedItemChanged��6-   .  (System.Windows.Interactivity.TriggerBase&   Actions.& 5�   "   6  0System.Windows.Interactivity.InvokeCommandAction  '   Command' 68   �� *SelectedItemChangedCommand+(   CommandParameter( 6g   �� *SelectedItem+$ treeView��$ OneWay=�5�      5     5     5     5     5	     5
     