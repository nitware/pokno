   M S B A M L   `   `   `  ���� O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.InfrastructurePokno.Infrastructure.Converters   Pokno.Store0   *Pokno.Store.Views.PurchasedStockReturnView   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     a	converterKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.Infrastructure     X TXceed.Wpf.Toolkit, Version=2.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  Z VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI    � 	Resources  3   -Pokno.Infrastructure.Converters.DateConverter   DateConverter;   5Pokno.Infrastructure.Converters.CheckToolTipConverter  CheckToolTipConverter;   5Pokno.Infrastructure.Converters.DateToSelectConverter  DateToSelectConverter4   .Pokno.Infrastructure.Converters.MoneyConverter  MoneyConverter8   2Pokno.Infrastructure.Converters.EnabilityConverter  EnabilityConverter��%K   &	        &	      &	 
     &	      &	                .���� $��Stretch=�{��� *PurchasedStockCanBeEdited+ �� Mode$ TwoWay=�.��� $��5q����	#E7FFFFFF � ColumnDefinitions �� $��6* ��� $��4* �.+��  � RowDefinitions �� $
��Auto ��� $
��auto ��� $
��auto �.+��� $��
15,10,17,5q�$��0�� �� CornerRadius$ 20,0,0,0��
�������$��1q�
������� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ DimGray��._�� $��12,10,12,15q� ��  �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��	10,0,10,0q�$��15(�$��Center=�$��0��Purchase Transaction�� $��	10,2,10,0q�$��1��$��1��$ �� IsSynchronizedWithCurrentItem$
 TrueY�$��Center=����� *PurchaseStockBatches+$ TwoWay=� �� SelectedItem �� *PurchaseStockBatch+$ TwoWay=����� .R��� 	 �� Orientation$	 
Horizontal=�.+��� $��0,0,7,0q�$
��Bold"����	#FF413E3E���� *DatePurchased+
 �� 	Converter#
 [ �� ���	#FF413E3E���� *
Buyer.Name+� $��0,5,0,10q�$��0��$��1�� �� $
��Auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $��
15,0,15,10q�$��0��$��15(�$��Choose Product��.���� $��0,10,0,0q�.+�� $��	20,0,20,5q� �� $��68 ��� $	��180 � �� $
��Auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $��12(�$
��Bold"�$��0��$��0��$��0,3,0,0q�Stock:�� $
 TrueY�$��0��$��1��$��0,3,0,0q����� *Stocks+$ TwoWay=� �� *Stock+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=����� .R��� $	 
Horizontal=�.+��� $��12(����	#FF413E3E���� *Name+�� $��12(�$
��Bold"�$��0��$��1��$��0,3,0,0q�
Package:�� $��12(�$
��Bold"�$��0��$��2��$��0,3,0,0q�
Unit Cost:%  Xceed.Wpf.Toolkit.DecimalUpDown  $��12(��  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   FormatString$ #,0.00��{�.  $��0,3,0,0q�$��22��$��1��$��2���	  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]] 	  Maximum$ 99999999999999X� 	  Minimum$ 0X��
  �Xceed.Wpf.Toolkit.CommonNumericUpDown`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]] 
  ParsingNumberStyle$ AllowThousands=� 	  Value �� *TargetModel.UnitCost+$ TwoWay=��� $��12(�$
��Bold"�$��3��$��0,3,0,0q�$��22��$	��Top=�	Quantity:%  Xceed.Wpf.Toolkit.IntegerUpDown  $��12(��  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   FormatString$	 #,0��$��0,3,0,0q�$��22��$��1��$��3���  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value �� *TargetModel.Quantity+$ TwoWay=��� $��12(�$
��Bold"�$��0��$��4��$��0,3,0,0q�Cost:  $��12(�$ #,0.00��$��0,3,0,0q�$��22��$��1��$��4��$ 99999999999999X� �� *TargetModel.Cost+$ TwoWay=��� $
 TrueY�$��1��$��1��$��0,3,0,0q����� *StockPackages+$ TwoWay=� �� *StockPackage+$ TwoWay=�$ PropertyChanged=����� .R��� $	 
Horizontal=�.+��� $��12(����	#FF413E3E���� *Package.Name+�� $��5��$��1��$
��Left=�$��0,3,0,0q�$	 
Horizontal=�.+��� $��9(�$	��Add������ *
AddCommand+� $��1��$��0��$��	15,0,15,0q� �� �� .+��� $��0,0,0,4q�$ 0,10,0,0��$��2��$��0q�
����������#e0eaf6._��� $��0,0,0,0q�.+��� $��0��$��0��$��3��
�������._��� $��10q�.+��� 
���iii�$��0,0,0,1q�$��0,2,0,0q�$��Stretch=�._��� STOCKS TO RETURN� $��0,0,0,0q� �� $
��auto ��� $��* ��� $
��auto ��� $��* ��� $
��auto ��� $��* � �� �� �� �� �� �� .+��� $��0,0,2,0q�$��11(�$��0��$��0��$��Center=�Total Quantity:�� $
��Bold"�$��11(�$��0,0,10,0q�$��1��$��0������ *TotalQuantity+�� $��0,0,2,0q�$��2��$��0��$��11(�$��Center=�Total Unit Cost:�� $
��Bold"�$��11(�$��0,0,10,0q�$��3��$��0������ *TotalUnitCost+#
 [ �� $��10,0,2,0q�$��0��$��4��$��Center=�$��11(�$
��Left=�Total Cost:�� $
��Bold"�$��11(�$��0,0,0,0q�$��5��$��0������ *	TotalCost+#
 [ &   System.Windows.Controls.DataGrid     AreRowDetailsFrozen .    AutoGenerateColumns .     HeadersVisibility$ Column=�$	��130������ *TargetCollection+   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Stock��   CellTemplate �� .R��� $��3,0,3,0q�$
��Wrap=����� *StockPackage.Stock.Name+  $ Package�� �� .R��� $��5,0,3,0q�$
��Wrap=����� *StockPackage.Package.Name+  $	 Qty�� �� .R��� $��5,0,3,0q�$��Center=�$
��Wrap=����� *
Quantity+  $
 Cost�� �� .R��� $��5,0,0,0q�$��12(�$��Right=�$
��Wrap=����� *Cost+#
 [   $ Stock State�� �� .R��� $	��1,0q�$
 TrueY�$��Normal"����� *StockStates+$ TwoWay=� �� SelectedValue �� *
StockState+$ TwoWay=�$ PropertyChanged=�{��� *	CanReturn+#
 [ ���� .R��� $	 
Horizontal=�.+��� $��12(����	#FF413E3E���� *Name+  $ Reason�� �� .R��� $	��1,0q�$��Center=�$��Center=�
���   � �� TextWrapping$
 Wrap=� �� 	IsEnabled . $	��228������ *ReturnReason+$ TwoWay=�$ PropertyChanged=�{��� *CanEnterActionReason+#
 [ �� $
��Left=�$��3,2,0,3q�$	 
Horizontal=�.+��� $��9(�$��Clear��$��0,0,1,0q����� *%#ClearPurchasedStocksToReturnCommand+�� $��9(�$��Remove������ *RemoveCommand+�� $��	15,0,15,5q�$��2��$��Right=�$	 
Horizontal=�.+�=  7FirstFloor.ModernUI.Windows.Controls.ModernProgressRing  $��0,0,10,0q�$��20��$��20��   IsActive �� *IsBusy+���� *SelectedItem.Tag+ �� ElementName$ CmbRingStyle���� $��0,0,1,0q�$��15(�$��Clear������ *ClearCommand+�� $��15(�$
��Save������ *SaveCommand+�� $��0��$��1��$��3��$��	5,10,20,0q�$��Stretch=�.+��� 
�������$ 	0,20,20,0��
�������$��1,1,1,1q�$��Stretch=�   $ DimGray��._��� ._��� $��2��.+��� $	 Vertical=�$��10,10,10,10q�.+��� $��0,0,0,0q�$ 5,5,0,5��._��� $��0,5,0,0q�.+��� $��2,0,2,0q�$ 0,5,0,0�����#e0eaf6$��1��$��2��$��0��._��  �� �� ��  �� $
��auto �.+��� $��0��$��0��$��3��$ 5,5,0,0��._��� $��10q�.+��� 
���iii�$��0,0,0,1q�$��0,2,0,0q�$��Stretch=�._��� PURCHASED STOCK(S)� $��0,2,0,0q� �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto � �� �� �� �� �� �� .+��� $��0,0,2,0q�$��11(�$��0��$��0��$��Center=�Item Count:�� $
��Bold"�$��11(�$��0,0,10,0q�$��1��$��0������ *PurchasedStockItemCount+�� $��0,0,2,0q�$��2��$��11(�$��0��$��Center=�
Total Qty:�� $
��Bold"�$��11(�$��0,0,10,0q�$��3��$��0������ *PurchasedStockTotalQuantity+�� $��0,0,2,0q�$��0��$��4��$��Center=�$��11(�$
��Left=�Total Cost:�� $��5��$��0��$
��Bold"�$��11(����� *PurchasedStockTotalCost+#
 [   $��0q�
������� .  .     AlternatingRowBackground
 �����$ Column=�$	��457������ *PurchasedStocks+   $ Stock�� �� .R��� $��0,0,5,0q�$��12(�$
��Wrap=����� *
Stock.Name+  $ Package�� �� .R��� $	��5,0q�$��12(�$
��Wrap=����� *StockPackage.Package.Name+  $	 Qty�� �� .R��� $	��5,0q�$��12(�$��Center=�$
��Wrap=����� *
Quantity+  $
 Cost�� �� .R��� $	��5,0q�$��12(�$��Right=�$
��Wrap=����� *Cost+#
 [ 