   M S B A M L   `   `   `  ���� O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.InfrastructurePokno.Infrastructure.Converters   Pokno.Store/   )Pokno.Store.Views.ManageReplacedStockView   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     X TXceed.Wpf.Toolkit, Version=2.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  [	converterKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.Infrastructure  Z VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI    � 	Resources  8   2Pokno.Infrastructure.Converters.EnabilityConverter   EnabilityConverter4   .Pokno.Infrastructure.Converters.MoneyConverter  MoneyConverter��%   &	        &	          .��� $��7q� � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto �.+�� $��0�� �� $
��auto ��� $
��auto �.+��� $��7q� �� Padding$ 15q� �� CornerRadius$ 10��
�������
������� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ DimGray��._��� .+��� $��0,0,0,4q�$ 0q�._��  � ColumnDefinitions �� �� .+��� %#CHOOSE ITEMS TO TREAT FROM THE LIST�� $��1��$��Right=� �� Orientation$ 
Horizontal=�.+��� $��0,0,2,0q�Selected Item Count:�� 
���   �$��20��$ 15��._��� 
�������$��Center=�$��Center=�$
��Bold"����� *SelectedItemCount+ �� Mode$ TwoWay=��� $��10,0,2,0q�Total Item:�� 
���   �$��20��$ 15��._��� 
�������$��Center=�$��Center=�$
��Bold"����� *RecordCount+$ TwoWay=�&   System.Windows.Controls.DataGrid  	   AreRowDetailsFrozen	 . 
   AutoGenerateColumns
 .     GridLinesVisibility$ Vertical=�   HeadersVisibility$ Column=�
�������$	��400������ *UntreatedReplacedStocks+ �� SelectedItem �� *UntreatedReplacedStock+ �� SelectedIndex �� *SalesItemSelectedIndex+$ TwoWay=�   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Select��   CellTemplate �� .R��� $	��3,0q�$��18(�$��Center=� d� 	IsChecked �� *
IsSelected+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�  $ ID�� �� .R��� $	��3,0q�$��Center=�
���   �$
��Wrap=����� *Id+  $ Package�� �� .R��� $	��3,0q�$��Center=�
���   �$
��Wrap=����� *?=ReturnedDetail.SoldStock.ShelfStock.StockPackage.Package.Name+  $
 Item�� �� .R��� $	��3,0q�$��Center=�
���   �$
��Wrap=����� *=;ReturnedDetail.SoldStock.ShelfStock.StockPackage.Stock.Name+  $	 Qty�� �� .R��� $	��3,0q�$��Center=�$��Center=����� *#!ReturnedDetail.SoldStock.Quantity+  $ Price�� �� .R��� $	��3,0q�$��Center=�$��Right=�
���   �$
��Wrap=����� *-+ReturnedDetail.SoldStock.Price.SellingPrice+ �� 	Converter# [   $ State�� �� .R��� $	��3,0q�$��Center=�
���   �$
��Wrap=����� * ReturnedDetail.StockState.Name+  $ Action�� �� .R��� $	��1,0q�$��Normal"�$��Center=����� *	Actions+$ TwoWay=�$ PropertyChanged=� �� SelectedValue �� *Action+$ TwoWay=�$ PropertyChanged=�{��� *CanEnterActionReason+# [  ���� .R��� $ 
Horizontal=�.+��� $��Arial)����	#FF413E3E���� *Name+  $ Reason�� �� .R��� $	��1,0q�$��Center=�$��Center=�
���   � �� TextWrapping$
 Wrap=� �� 	IsEnabled . $	��400������ *ActionReason+$ TwoWay=�$ PropertyChanged=�{��� *CanEnterActionReason+# [  �� $��0,3,0,0q�$��2��$��1��$
��Left=�$ 
Horizontal=�.+��� $��Return��$��16(����� *ReturnCommand+=  7FirstFloor.ModernUI.Windows.Controls.ModernProgressRing  $��15,0,0,0q�$��26��$��26��   IsActive �� *IsBusy+���� *SelectedItem.Tag+ �� ElementName$ CmbRingStyle��