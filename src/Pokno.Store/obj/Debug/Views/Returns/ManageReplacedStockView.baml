   M S B A M L   `   `   `  ����O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.InfrastructurePokno.Infrastructure.Converters  5       Pokno.Store/   )Pokno.Store.Views.ManageReplacedStockView   5      U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TXceed.Wpf.Toolkit, Version=2.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      [	converterKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.Infrastructure  5      Z VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI  5        � 	Resources  5      8   2Pokno.Infrastructure.Converters.EnabilityConverter   EnabilityConverter4   .Pokno.Infrastructure.Converters.MoneyConverter  MoneyConverter��%:   &	        &	        5   
   6'     5   
   6#   5      .��5      � $��7q�6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   � $��0��6    5      �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5      �� $��7q�6    �� Padding$ 15q�6     �� CornerRadius$ 10��6-   
�������
������� J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5          Color$ DimGray��6'   ._�5#      �� .+�5$      �� $��0,0,0,4q�6   $ 0q�6.   ._�5%      �  � ColumnDefinitions 5&      �� 5'   "   �� 5(   "   .+�5+      �� %#CHOOSE ITEMS TO TREAT FROM THE LIST6M   �� 5,      $��1��6)   $��Right=�69    �� Orientation$ 
Horizontal=�6U   .+�5-   "   �� $��0,0,2,0q�6,   Selected Item Count:6T   �� 5.   "   
���   �$��20��6<   $ 15��6J   ._�5/   &   �� 
�������$��Center=�6s   $��Center=�6�   $
��Bold"�6�   ��60   �� *SelectedItemCount+ �� Mode$ TwoWay=�6�   50   #   �� 52   "   $��10,0,2,0q�6,   Total Item:6L   �� 53   "   
���   �$��20��6<   $ 15��6J   ._�54   &   �� 
�������$��Center=�6m   $��Center=�6�   $
��Bold"�6�   ��60   �� *RecordCount+$ TwoWay=�6�   55   #   56      57      59      &   System.Windows.Controls.DataGrid  5:      	   AreRowDetailsFrozen	 . 
   AutoGenerateColumns
 .     GridLinesVisibility$ Vertical=�5=   
      HeadersVisibility$ Column=�5>   
   
�������$	��400��5B   
   ��5:      �� *UntreatedReplacedStocks+ �� SelectedItem 5@   
   �� *UntreatedReplacedStock+ �� SelectedIndex 5A   
   �� *SalesItemSelectedIndex+$ TwoWay=�   Columns 5C      4  .System.Windows.Controls.DataGridTemplateColumn  5E      ,  &System.Windows.Controls.DataGridColumn   Header$ Select��66      CellTemplate 5F   "   �� 5G   &   .R�5H   *   �� $	��3,0q�63   $��18(�6@   $��Center=�6�    d� 	IsChecked 6N   �� *
IsSelected+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   5I   '   5K        5M      $ ID��65    5N   "   �� 5O   &   .R�5P   *   �� $	��3,0q�64   $��Center=�6U   
���   �$
��Wrap=�6�   ��6A   �� *Id+6�   5Q   '   5S        5U      $ Package��65    5V   "   �� 5W   &   .R�5X   *   �� $	��3,0q�64   $��Center=�6�   
���   �$
��Wrap=�6�   ��6A   �� *?=ReturnedDetail.SoldStock.ShelfStock.StockPackage.Package.Name+6�   5Y   '   5[        5]      $
 Item��65    5^   "   �� 5_   &   .R�5`   *   �� $	��3,0q�64   $��Center=�6�   
���   �$
��Wrap=�6�   ��6A   �� *=;ReturnedDetail.SoldStock.ShelfStock.StockPackage.Stock.Name+6�   5a   '   5c        5e      $	 Qty��65    5f   "   �� 5g   &   .R�5h   *   �� $	��3,0q�64   $��Center=�6t   $��Center=�6�   ��6A   �� *#!ReturnedDetail.SoldStock.Quantity+6�   5i   '   5k        5m      $ Price��65    5n   "   �� 5o   &   .R�5p   *   �� $	��3,0q�64   $��Center=�6�   $��Right=�6�   
���   �$
��Wrap=�6�   ��6A   �� *-+ReturnedDetail.SoldStock.Price.SellingPrice+ �� 	Converter# [ 6�   5q   '   5s        5u      $ State��65    5v   "   �� 5w   &   .R�5x   *   �� $	��3,0q�64   $��Center=�6q   
���   �$
��Wrap=�6�   ��6A   �� * ReturnedDetail.StockState.Name+6�   5y   '   5{        5}      $ Action��65    5~   "   �� 5   &   .R�5�   *   �� $	��1,0q�63   $��Normal"�6?  $��Center=�6T  ��6@   �� *	Actions+$ TwoWay=�$ PropertyChanged=� �� SelectedValue 6�   �� *Action+$ TwoWay=�$ PropertyChanged=�{�6�   �� *CanEnterActionReason+# [  ��5�   .   �� 5�   2   .R�5�   6   �� $ 
Horizontal=�6A   .+�5�   :   �� $��Arial)�6D   ���	#FF413E3E��6n   �� *Name+6�   5�   7   5�   3   5�   +   5�   '   5�        5�      $ Reason��65    5�   "   �� 5�   &   .R�5�   *   �� $	��1,0q�62   $��Center=�6�   $��Center=�6  
���   � �� TextWrapping$
 Wrap=�64   �� 	IsEnabled . $	��400��6d  ��6?   �� *ActionReason+$ TwoWay=�$ PropertyChanged=�{�6�   �� *CanEnterActionReason+# [  6d  5�   '   5�      5�      �� 5�      $��0,3,0,0q�6!   $��2��62   $��1��6?   $
��Left=�6O   $ 
Horizontal=�6j   .+�5�      �� $��Return��6C   $��16(�6T   ��6!   �� *ReturnCommand+6T   =  7FirstFloor.ModernUI.Windows.Controls.ModernProgressRing  5�      $��15,0,0,0q�61   $��26��6_   $��26��6j      IsActive 6C   �� *IsBusy+��6v   �� *SelectedItem.Tag+ �� ElementName$ CmbRingStyle��5�      5�      5�      5�      5�      5�      