   M S B A M L   `   `   `  ���� O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.InfrastructurePokno.Infrastructure.Converters   Pokno.Store5   /Pokno.Store.Views.Setup.PackageRelationshipView   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     UtoolkitAhttp://schemas.microsoft.com/winfx/2006/xaml/presentation/toolkit     a	converterKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.Infrastructure     X TXceed.Wpf.Toolkit, Version=2.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit    � 	Resources  8   2Pokno.Infrastructure.Converters.EnabilityConverter   EnabilityConverter6   0Pokno.Infrastructure.Converters.IsExistConverter  PackageRelationshipExistC   =Pokno.Infrastructure.Converters.MakeComboBoxItemBoldConverter  MakeComboBoxItemBold��%-   &	        &	      &	 
           .��� $��3q�.+��  � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto �.+��� $��7,7,7,5q� �� CornerRadius$ 3��$��0��
������� �� Padding$ 5q�._��� $��7q�$ 2��
�������$��1q�$	��Top=�
������� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ DimGray��._��� $��5q� �� Orientation$ 
Horizontal=�.+��� $��	5,0,105,0q�$
��Bold"�$��Center=�$��0��$��0��Stock:�� $��0,3,0,0q�$ �� IsSynchronizedWithCurrentItem$
 TrueY�$��Center=�$��0��$��1��$��24��$	��220������ *Stocks+ �� Mode$ TwoWay=�	 �� SelectedItem	 �� *Stock+$ TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=����� .R��� $ 
Horizontal=�.+��� ���� *HasPackageRelationship+ �� 	Converter# [ ���� *HasPackageRelationship+# [ ���� *Name+�� 
�������$��	7,5,10,10q�$ 3��
�������$��1��   $ DimGray��._��� $��12q�$ 2��
�������$��3q�._�� $��10q� � ColumnDefinitions �� $	��140 ��� $	��220 ��� $��* � �� $
��Auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $
��Bold"�$��0��$��0���� $�Package:���� $
 TrueY�$��0��$��1��$��0,3,0,0q����� *
Packages+$ TwoWay=�	 �� *	Package+$ TwoWay=�$
 PropertyChanged=����� .R��� $ 
Horizontal=�.+��� ���	#FF413E3E���� *Package.Name+�� $
��Bold"�$��0��$��1��$��0,3,0,0q��� $�Sub Package:���� $
 TrueY�$��1��$��1��$��0,3,0,0q����� *SubPackages+$ TwoWay=�	 �� *
SubPackage+$ TwoWay=�$
 PropertyChanged=����� .R��� $ 
Horizontal=�.+��� ���	#FF413E3E���� *Package.Name+�� $
��Bold"�$��0��$��2��$��0,3,0,0q��� $�Quantity In Package:��%  Xceed.Wpf.Toolkit.DecimalUpDown  $��0,3,0,0q�$��1��$��2���  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value �� *TargetModel.Quantity+$ TwoWay=�{��� *IsQuantityEnabled+# [  �� $��1��$��3��$	��Add��$
��Left=�$��0,3,2,0q����� *
AddCommand+�� $��Bottom=�$��Right=�
�������$��Italic$�$��12(�$
��Bold"�$��2��$��3������ *RecordCount+$ TwoWay=��� $��2��$��	7,4,10,10q�$ 3��
�������   $ DimGray��._�� $��15q�$��Stretch=� �� $
��auto ��� $��* ��� $
��auto � �� $
��auto ��� $
��auto �.+�� $��1��$��0��$��2,0,2,3q� �� �� .+��� $��Bottom=�PACKAGES RELATIONSHIP�� $��1��$��Center=�$��Right=�$ 
Horizontal=�.+��� $��0,0,2,0q�$��Center=�Record Count�� 
���   �$��20��$ 15��$��Center=�._��� 
�������$��Center=�$��Center=�$
��Bold"����� *	ItemCount+$ TwoWay=��� $��0,0,3,0q�$��1��$��0��$ Vertical=�.+��� $	��5,0q�$��Center=�$��Courier New)�$��12(��� $	�Max���� $	��150��$��Center=�
���   �$��1��$��20������  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ Black�� � Offset$ 0Q�� $ White��$ 1Q��� $	��5,0q�$��Center=�$��Courier New)�$��12(��� $	�Min���� $��1��$��1��$��Stretch=�.+�� $��Stretch=�.+��� 
�������$��0,1,0,0q�._�&   System.Windows.Controls.DataGrid     AreRowDetailsFrozen .    AutoGenerateColumns .     HeadersVisibility$ Column=�$	��175������ *TargetCollection+$ TwoWay=�   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,	  &System.Windows.Controls.DataGridColumn 	  Header$
 Rank��   CellTemplate �� .R��� $	��5,0q�$��12(�$��Center=�$
��Wrap=����� *Rank+  $ Package�� �� .R��� $	��5,0q�$��12(�$
��Wrap=����� *Package.Package.Name+  $ Sub Package�� �� .R��� $	��5,0q�$��12(�$
��Wrap=����� *SubPackage.Package.Name+  $ Qty in Package�� �� .R��� $	��5,0q�$��12(�$��Center=�$
��Wrap=����� *
Quantity+�� $��0,0,0,4q�$��Stretch=�._��� $��2��$��3q�$��Right=�$ 
Horizontal=�.+��� $��Clear��$��0,0,2,0q����� *ClearCommand+�� $��0,0,2,0q�$��Remove Selected Item������ *RemoveCommand+�� $��Delete��$��0,0,2,0q����� *DeleteCommand+�� $
��Save������ *SaveCommand+�� $��2��$��1��$
��5,35q�$ Vertical=�$	��Top=�.+��� $��Up��$��44��$��Right=�$��0q�$��Bottom=�$��80������ *	UpCommand+�� $
��Down��$��44��$��Right=�$��0,3,0,0q�$��Bottom=�$��80������ *DownCommand+