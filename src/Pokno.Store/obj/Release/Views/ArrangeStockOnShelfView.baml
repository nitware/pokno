   M S B A M L   `   `   `  ���� O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.InfrastructurePokno.Infrastructure.Converters  p lSystem.Windows.Controls.Input.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35pTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.ToolkitSystem.Windows.Controls  Pokno.Store/   )Pokno.Store.Views.ArrangeStockOnShelfView   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     UtoolkitAhttp://schemas.microsoft.com/winfx/2006/xaml/presentation/toolkit     a	converterKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.Infrastructure     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  X	 TXceed.Wpf.Toolkit, Version=2.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit 	 cControlsTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.Toolkit 	 Z
 VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI 
   � 	Resources  3   -Pokno.Infrastructure.Converters.DateConverter   DateConverter6   0Pokno.Infrastructure.Converters.IntegerConverter  IntegerConverter   PurchasedStockAtHandTemplate �� Orientation & "StockPurchasedTreeViewItemTemplate �� ItemTemplate �� ItemsSource  AutoCompleteBoxItemTemplate��%�  &	        &	      &	 
     &	 �     7  &	 J        �� .R��� $ 
Horizontal=�.+��� $��0,0,5,0q�$��Normal"�$��10(�$��Center=����� *
Quantity+�� $��0,0,5,0q�
���iii�$��11(�$��Center=����� *StockPackage.Package.Name+�� 8    �� *StockPurchases+.R��� $ 
Horizontal=�.+��� $��0,0,5,0q�$
��Bold"����� *
Stock.Name+�� .R��� $ 
Horizontal=�.+��� $	��5,2q�$	��100��$
��Bold"�
����������� *Name+.��� -    �Name$ 
LayoutRoot��$��0q�.+��  � RowDefinitions �� $
��Auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto � � ColumnDefinitions �� $��3* ��� $��5* �.+��� $��0�� �� CornerRadius$ 5��$��1��$��5,5,10,5q�
�������
�������$��1q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect  	   Color$	 DimGray��._��� .+�� $
��10,3q� �� $	��115 ��� $	��150 ��� $��* � �� $
��Auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $��5,10,5,0q�$��3��$��0��$��0��
�������$��Stretch=�._��� $��10q�$��Bottom=�$��century Gothic)�SELECTED STORE STOCK�� $��0��$��1��$��5,5,0,0q�Stock:�� $
��Bold"�{�.  $��1��$��1��$��0,5,0,0q�$��25������ *SelectedStock.Name+�� $��2,5,0,0q�$��2��$��1��$��9(�$��0q�$
��Left=�$��25��
 � ToolTip$
 Change Stock Price��$	��...������ *ChangePriceCommand+�� $��0��$��2��$��5,3,0,0q�
Package:�� $��3��$��5,3,0,0q�$��22��$	��Top=�	Quantity:% 	 Xceed.Wpf.Toolkit.IntegerUpDown  $��0,3,0,0q�$��22��$��1��$��3��� 	 �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Minimum$ 0X�   Maximum$ 
1000000000X�   Value �� *Shelf.Quantity+ �� Mode$ TwoWay=� �� 	Converter# [ �� $��4��$��5,3,0,0q�$��22��$	��Top=�Expiry Date:(  "System.Windows.Controls.DatePicker  $��4��$��1��$��23��$��0,3,0,0q�$	��Top=�   SelectedDate �� *Shelf.ExpiryDate+$ TwoWay=��� $ �� IsSynchronizedWithCurrentItem$
 TrueY�$��1��$��2��$��0,3,0,0q�$��23������ *StockPackages+$ TwoWay=� �� SelectedItem �� *StockPackage+���� .R��� $ 
Horizontal=�.+��� ���	#FF413E3E���� *Package.Name+�� $��5��$��1��$
��Left=�$��0,3,0,10q�$ 
Horizontal=�.+��� $��Add To Shelf������ *AddToShelfCommand+= 
 7FirstFloor.ModernUI.Windows.Controls.ModernProgressRing  $��1��$��4��$��2��$��5,0,0,0q�$��80��$��80��   IsActive �� *IsBusy+���� *SelectedItem.Tag+ �� ElementName$ CmbRingStyle��� $��1��$��1��$��	5,10,10,8q�$��Stretch=�.+��� ���#9FC0DB$ 10��$��0,0,0,0q�._��� .+��� $��	10,10,7,5q�$��Stretch=�._��� $
��Bold"�
�������$��century Gothic)�STOCKS ON SHELF&   System.Windows.Controls.DataGrid     AreRowDetailsFrozen .    AutoGenerateColumns .  
�������   GridLinesVisibility$
 None=�   HeadersVisibility$
 None=�$	��290������ *RemainingStocksOnShelf+   Columns 4	  .System.Windows.Controls.DataGridTemplateColumn	  ,
  &System.Windows.Controls.DataGridColumn 
  Header$ Quantity�� 	  CellTemplate �� .R��� $��3,0,3,0q�$��12(�
���   �$��Right=�$
��Wrap=����� *
Quantity+	  $ Package�� �� .R��� $��3,0,3,0q�$��12(�
���   �$
��Wrap=����� *PackageName+	  $ Stock�� �� .R��� $��3,0,3,0q�$��12(�
���   �$
��Wrap=����� *	StockName+�� $��	7,5,10,10q�$��0��$��0��$��6��
���iii�$��1,1,2,2q�$ 5��
�������   $	 DimGray��._��� .+��� $��0��$��
10,10,10,3q� �� Padding$ 2q�$ 2��
�������$��1q�
�������._�� $��0,0,0,0q� �� $
��auto ��� $��* ��� $
��auto �.+��� $��1q�$��25��$��25��$��UniformToFill=����� *
SearchIcon+-  'System.Windows.Controls.AutoCompleteBox  $��1��
�������$��1q�   ValueMemberPath$
 Name��   ItemTemplate# [    IsTextCompletionEnabled .     ItemsSource  �� *Stocks+!   SelectedItem! �� *Stock+$ TwoWay=�" �� UpdateSourceTrigger$" PropertyChanged=��� $��1,0,0,0q�$��1��$��9(�$	��...��$
 Re-load stocks at hand��$��Right=����� *ReloadCommand+�� 
�������
�������$��	10,0,10,0q�$��0,0,0,0q�$��Stretch=�._��� $��10,7,0,7q�$��13(�
�������$
��Bold"�STOCKS IN STORER� -   # R�Name$# treeView��$��	10,0,10,5q�
���iii�$��0q�$	��460��$
��Auto=�#��[ ���� *StockPurchasesAtHand+.  (System.Windows.Interactivity.Interaction$   Triggers$ /  )System.Windows.Interactivity.EventTrigger  %   	EventName$% SelectedItemChanged��.  (System.Windows.Interactivity.TriggerBase&   Actions.& 6  0System.Windows.Interactivity.InvokeCommandAction  '   Command' �� *SelectedItemChangedCommand+(   CommandParameter( �� *SelectedItem+$ treeView��$ OneWay=�