   M S B A M L   `   `   `  ���� p  lSystem.Windows.Controls.Input.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35pTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.ToolkitSystem.Windows.Controls  O KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.InfrastructurePokno.Infrastructure.Converters  Pokno.Store0   *Pokno.Store.Views.RemoveStockFromShelfView   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     P LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8)prismhttp://www.codeplex.com/prism  cControlsTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.Toolkit  c	 _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity 	 [	converterKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.Infrastructure 	 X
 TXceed.Wpf.Toolkit, Version=2.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit 
 Z VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI    � 	Resources  8  2Pokno.Infrastructure.Converters.EnabilityConverter   EnabilityConverter;  5Pokno.Infrastructure.Converters.CheckToolTipConverter  CheckToolTipConverter;  5Pokno.Infrastructure.Converters.ReorderLevelConverter  ReorderLevelConverterE  ?Pokno.Infrastructure.Converters.ReorderLevelFontWeightConverter # ReorderLevelFontWeightConverter % !UnsoldStockPackagesAtHandTemplate �� Orientation �� Mode �� 	Converter  UnsoldStockPackagesTemplate �� ItemTemplate �� ItemsSource & "StockPurchasedTreeViewItemTemplate  AutoCompleteBoxItemTemplate��%6  &	        &	      &	 
     &	      &	      7  7  7  7  &	 M    7  &	 �    7  &	 l            �� .R��� $ 
Horizontal=�.+��� $��0,0,5,0q�$��11(�$��Center=����� *
Quantity+$ TwoWay=����� *ReorderLevel+8   ���� *ReorderLevel+8  �� $��0,0,0,0q�$��11(�$��Center=����� *StockPackage.Package.Name+���� *ReorderLevel+8  ���� *ReorderLevel+8  �� 8    �� *Shelfs+$ TwoWay=�.R��� $ 
Horizontal=�.+��� $��0,0,5,0q�$
��Bold"�
�������$
��Wrap=����� *
Stock.Name+�� 8    �� *UnsoldStockPackages+.R��� $ 
Horizontal=�.+��� $��0,0,5,0q�$
��Bold"�$
��Wrap=����� *StockType.Name+�� .R��� $ 
Horizontal=�.+��� $	��5,2q�$	��100��$
��Bold"�
����������� *Name+.��� -    �Name$ 
LayoutRoot��$��1q�.+��  � ColumnDefinitions �� $��3* ��� $��5* �.+�� $��1�� � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto � �� .+��� $��1��$��1��$��5,5,5,2q�
�������$��0,0,0,0q�._��� $��0,0,0,0q�._��� .+�� $��0,2,0,2q� �� $
��Auto ��� $��* �.+��� $	��3,0q�$ 
Horizontal=�.+��� $��0,0,3,0q�
�������$
��Bold"�$��Bottom=�Item Count:�� 
�������$
��Bold"�$��0,0,7,0q�$��Bottom=����� *CartItemCount+�� $	��2,0q�$��1��$ 
Horizontal=�$��Right=�.+��� $��0,0,3,0q�$��9(�$��Remove Selected Item��$��20������ *RemoveItemCommand+�� $��9(�$��Clear All Item��$��20������ *ClearCommand+&   System.Windows.Controls.DataGrid  -   	  Name$	 cartDataGrid��
   AreRowDetailsFrozen
 .    AutoGenerateColumns .     HeadersVisibility$ Column=�
�������$	��465������ *StocksForSale+ �� SelectedItem �� *StockForSale+ �� SelectedIndex �� *CartDataGridSelectedIndex+$ TwoWay=�. 	 (System.Windows.Interactivity.Interaction   Triggers / 	 )System.Windows.Interactivity.EventTrigger     	EventName$ SelectionChanged��. 	 (System.Windows.Interactivity.TriggerBase   Actions. 6	 	 0System.Windows.Interactivity.InvokeCommandAction	   	  Command �� *SelectionChangedCommand+ 	  CommandParameter �� *SelectedItem+ �� ElementName$ cartDataGrid��$ OneWay=�   Columns 4
  .System.Windows.Controls.DataGridTemplateColumn
  ,  &System.Windows.Controls.DataGridColumn   Header$
 Item�� 
  CellTemplate �� .R��� $	��5,0q�$��Center=�$��Verdana)�$��11(�
���   �$
��Wrap=����� *StockPackage.Stock.Name+
  $ Package�� �� .R��� $	��5,0q�$��Center=�$��Verdana)�$��11(�
���   �$
��Wrap=����� *StockPackage.Package.Name+
  $ Quantity�� �� .R�% 
 Xceed.Wpf.Toolkit.IntegerUpDown  $��Center=�$��Verdana)�$��12(�
���   �� 
 �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Minimum$ 1X�   Value �� *
Quantity+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� $	��5,0q�$��2��$��1��._��� $ 
Horizontal=�$
��Left=�.+��� $��18(�$��Remove������ *SaveCommand+=  7FirstFloor.ModernUI.Windows.Controls.ModernProgressRing  $��15,0,0,0q�$��40��$��40��   IsActive �� *IsBusy+���� *SelectedItem.Tag+$ CmbRingStyle���� $��	5,5,10,10q�
�������$��1q�
���iii�$��0��$��3��$��0�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ DimGray��._��� $��7q�.+��� $��0��$��0,0,0,3q� �� Padding$ 2q� �� CornerRadius$ 2��
�������$��1q�
�������._�� $��0,0,0,0q� �� $
��auto ��� $��* ��� $
��auto �.+��� $��1q�$��25��$��25��$��UniformToFill=����� *
SearchIcon+-   'System.Windows.Controls.AutoCompleteBox  $��1��
�������$��1q�    ValueMemberPath$
  Name��!   ItemTemplate#! [ "   IsTextCompletionEnabled" . #   ItemsSource# �� *Stocks+$   SelectedItem$ �� *Stock+$ TwoWay=�$ PropertyChanged=��� $��1,0,0,0q�$��1��$��9(�$	��...��% � ToolTip$% Re-load stocks on shelf��$��Right=����� *ReloadCommand+�� $��Stretch=�
���iii�._��� $��10,5,0,5q�$
��Bold"�
�������$��13(��� $�STOCK ON SHELF��R� -   & R�Name$& treeView��$��2,0,0,0q�
�������
�������$��0q�$	��445��$
��Auto=�#��[ ���� *StocksOnShelfAtHand+$ TwoWay=�   $ SelectedItemChanged��. 	   �� *$"TreeViewSelectedItemChangedCommand+ �� *SelectedItem+$ treeView��$ OneWay=�