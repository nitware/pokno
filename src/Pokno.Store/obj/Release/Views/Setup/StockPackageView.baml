   M S B A M L   `   `   `  ���� O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.InfrastructurePokno.Infrastructure.Converters   Pokno.Store(   "Pokno.Store.Views.StockPackageView   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     UtoolkitAhttp://schemas.microsoft.com/winfx/2006/xaml/presentation/toolkit     a	converterKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.Infrastructure     X TXceed.Wpf.Toolkit, Version=2.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit    � 	Resources  9   3Pokno.Infrastructure.Converters.VisibilityConverter   VisibilityConverter6   0Pokno.Infrastructure.Converters.IsExistConverter  PackageExistConverterC   =Pokno.Infrastructure.Converters.MakeComboBoxItemBoldConverter  MakeComboBoxItemBold��%-   &	        &	      &	 
           .��� $��3q�.+��  � RowDefinitions �� $
��Auto ��� $
��auto ��� $��* �.+��� 
�������$��	7,7,10,10q� �� CornerRadius$ 3�� �� Padding$	 0,3q�$��1q�
�������$��0�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ DimGray��._�� $��15,10q� � ColumnDefinitions �� $	��117 ��� $	��220 ��� $��* � �� $
��Auto ��� $
��auto �.+��� $
��Bold"�
�������$��Center=�$��0��$��0��Stock:�� $ �� IsSynchronizedWithCurrentItem$
 TrueY�$��Center=�$��0��$��1������ *Stocks+ �� Mode$ TwoWay=�	 �� SelectedItem	 �� *Stock+$ TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=����� .R���  �� Orientation$ 
Horizontal=�.+��� ���� *Name+���� *
HasPackage+ �� 	Converter# [ ���� *
HasPackage+# [ �� 
�������$��	7,3,10,10q�$ 3��$��0,0,1,1q�
�������$��1��   $ DimGray��._��� $��8q�
�������$ 2��$��3q�._�� $	��4,7q� �� $	��120 ��� $	��220 ��� $��* � �� $
��Auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $
��Bold"�$��0��$��0���� $�Package:���� $
 TrueY�$��0��$��1��$��0,3,0,0q����� *
Packages+$ TwoWay=�	 �� *	Package+$ TwoWay=�$
 PropertyChanged=����� .R��� $ 
Horizontal=�.+��� $��Verdana)����	#FF413E3E���� *Name+�� $
��Bold"�$��0��$��1��$��0,3,0,0q��� $�Re-Order Level:��%  Xceed.Wpf.Toolkit.IntegerUpDown  $��0,3,0,0q�$��1��$��1���  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Maximum$ 1000000X�   Value �� *TargetModel.ReOrderLevel+$ TwoWay=��� $
��Bold"�$��0��$��2��$��0,3,0,0q��� $�Expiry Days Alert:��  $��0,3,0,0q�$��1��$��2��$ 1000000X� �� *TargetModel.ExpiryDaysAlert+$ TwoWay=��� $
��Bold"�$��0��$��3��$��0,3,0,0q��� $�Description:���� $��1��$��3��$��0,3,0,0q�$��50�� �� TextWrapping$
 Wrap=����� *TargetModel.Description+$ TwoWay=��� $��1��$
��Left=�$��4��$	��Add��$��0,4,0,0q����� *
AddCommand+�� $��Bottom=�$��Right=�
�������$��Italic$�$��12(�$
��Bold"�$��2��$��4������ *RecordCount+$ TwoWay=��� $��2��$��	7,3,10,10q�$ 3��
�������   $ DimGray��._��� $��10q�$ Vertical=�$��Stretch=�.+��� 
�������$��Stretch=�._�� $��2,0,2,3q� �� �� .+��� $��Bottom=� PACKAGES ASSOCIATED WITH STOCK�� $��1��$��Center=�$��Right=�$ 
Horizontal=�.+��� $��0,0,2,0q�$��Center=�Record Count�� 
���   �$��20��$ 15��$��Center=�._��� 
�������$��Center=�$��Center=�$
��Bold"����� *	ItemCount+$ TwoWay=�� $��Stretch=�.+��� 
�������$��0,0,0,0q�._�&   System.Windows.Controls.DataGrid     AreRowDetailsFrozen .    AutoGenerateColumns .     HeadersVisibility$ Column=�$��Stretch=�$	��175������ *TargetCollection+$ TwoWay=�   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,	  &System.Windows.Controls.DataGridColumn 	  Header$ Package��   CellTemplate �� .R��� $	��5,0q�$��12(�$
��Wrap=����� *Package.Name+  $ Stock�� �� .R��� $	��5,0q�$��12(�$
��Wrap=����� *
Stock.Name+  $ Re-Order Level�� �� .R��� $	��5,0q�$��12(�$��Center=�$
��Wrap=����� *ReOrderLevel+  $ Expiry Days Alert�� �� .R��� $	��5,0q�$��12(�$��Center=�$
��Wrap=����� *ExpiryDaysAlert+  $ Description�� �� .R��� $	��5,0q�$��12(�$
��Wrap=����� *Description+�� $��0,0,0,4q�
�������$��Stretch=�._��� $��2��$��3q�$��Right=�$ 
Horizontal=�.+��� $��0,0,2,0q�$��Clear������ *ClearCommand+�� $��0,0,2,0q�$��Remove Selected Item������ *RemoveCommand+�� $��0,0,2,0q�$��Delete������ *DeleteCommand+�� $
��Save������ *SaveCommand+