   M S B A M L   `   `   `  ���� O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.InfrastructurePokno.Infrastructure.Converters   Pokno.Store,   &Pokno.Store.Views.Setup.StockPriceView   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     UtoolkitAhttp://schemas.microsoft.com/winfx/2006/xaml/presentation/toolkit     a	converterKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.Infrastructure     X TXceed.Wpf.Toolkit, Version=2.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit    � 	Resources  4   .Pokno.Infrastructure.Converters.MoneyConverter   MoneyConverter6   0Pokno.Infrastructure.Converters.IsExistConverter  PriceExistConverterC   =Pokno.Infrastructure.Converters.MakeComboBoxItemBoldConverter  MakeComboBoxItemBold��%-   &	        &	      &	 
           .��� $��3q�.+�� $��0,0,0,0q� � RowDefinitions �� $
��Auto ��� $
��auto ��� $��* �.+��� 
�������$��	7,7,10,10q�$��1q�
�������$��0�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ DimGray��._�� $��15,10q� � ColumnDefinitions �� $	��117 ��� $	��220 ��� $��* � �� $
��Auto ��� $
��auto �.+��� $
��Bold"�
�������$��Center=�$��0��$��0���� $�Stock:���� $ �� IsSynchronizedWithCurrentItem$
 TrueY�$��Center=�$��0��$��1��$��0,3,0,0q����� *Stocks+ �� Mode$ TwoWay=� �� SelectedItem �� *Stock+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=����� .R��� 	 �� Orientation$	 
Horizontal=�.+��� ���� *
HasPrice+
 �� 	Converter#
 [ ���� *
HasPrice+#
 [ ���� *Name+�� 
�������$��	7,3,10,10q�$��0,0,1,1q�
�������$��1��   $ DimGray��._��� $��8q�
�������$��3q�._�� $	��5,5q� �� $	��120 ��� $	��220 ��� $��* � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $
��Bold"�$��0��$��0���� $�Package:���� $
 TrueY�$��0��$��1��$��0,3,0,0q����� *
Packages+$ TwoWay=� �� *	Package+$ TwoWay=�$ PropertyChanged=����� .R��� $	 
Horizontal=�.+��� ���	#FF413E3E���� *Package.Name+�� $
��Bold"�$��0��$��3��$��0,3,0,0q��� $�Cost Price:��%  Xceed.Wpf.Toolkit.DecimalUpDown  $��0,3,0,0q�$��1��$��3���  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Maximum$ 99999999999999X�   Value �� *TargetModel.CostPrice+$ TwoWay=��� $
��Bold"�$��0��$��4��$��0,3,0,0q��� $�Selling Price:��  $��0,3,0,0q�$��22��$��1��$��4��$ 99999999999999X� �� *TargetModel.SellingPrice+$ TwoWay=��� $��1��$��5��$	��Add��$
��Left=�$��0,3,2,0q����� *
AddCommand+�� $��Bottom=�$��Right=�
�������$��Italic$�$��12(�$
��Bold"�$��2��$��4������ *RecordCount+$ TwoWay=��� $��2��$��	7,5,10,10q�
�������   $ DimGray��._��� $��15q�$	 Vertical=�$��Stretch=�.+�� $��2,0,2,3q� �� �� .+��� $��Bottom=�STOCK PRICE�� $��1��$��Center=�$��Right=�$	 
Horizontal=�.+��� $��0,0,2,0q�$��Center=�Record Count�� 
���   �$��20�� �� CornerRadius$ 15��$��Center=�._��� 
�������$��Center=�$��Center=�$
��Bold"����� *	ItemCount+$ TwoWay=�� $��Stretch=�.+��� 
�������$��0,0,0,0q�._�&   System.Windows.Controls.DataGrid     AreRowDetailsFrozen .    AutoGenerateColumns .     HeadersVisibility$ Column=�$	��175������ *TargetCollection+$ TwoWay=�   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,	  &System.Windows.Controls.DataGridColumn 	  Header$ Stock��   CellTemplate �� .R��� $	��5,0q�$��12(�$
��Wrap=����� *StockPackage.Stock.Name+  $ Package�� �� .R��� $	��5,0q�$��12(�$
��Wrap=����� *StockPackage.Package.Name+  $ 
Cost Price�� �� .R��� $	��5,0q�$��12(�$��Right=�$
��Wrap=����� *	CostPrice+#
 [    $ Selling Price�� �� .R��� $	��5,0q�$��12(�$��Right=�$
��Wrap=����� *SellingPrice+#
 [  �� $��0,3,0,4q�$��Stretch=�._��� $��2��$��Right=�$	 
Horizontal=�.+��� $��Clear��$��0,0,2,0q����� *ClearCommand+�� $��0,0,2,0q�$��Remove Selected Item������ *RemoveCommand+�� $��0,0,2,0q�$��Delete������ *DeleteCommand+�� $
��Save������ *SaveCommand+