   M S B A M L   `   `   `  ���� O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.InfrastructurePokno.Infrastructure.Converters   Pokno.Store%   Pokno.Store.Views.TakeStockView   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ]localKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.Infrastructure     Z VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI    � 	Resources  4   .Pokno.Infrastructure.Converters.MoneyConverter   MoneyConverter  GroupHeaderStyle �� 
TargetType �� Property �� Value �� 
TargetType��%m   &	        &	        �� " ��.���  � �� �� " ��.R��� .+��� ���� *	MonthName+�� .��� -    �Name$ 
LayoutRoot��$��5q�
�������.+��  � RowDefinitions �� $
��Auto ��� $��* �.+��� $��7,7,7,4q�
������� �� Padding$ 5q�$��0��._��� $��5q�
�������$��1q�$	��Top=�
������� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect  	   Color$	 DimGray��._��� $
��10,2q�
 �� Orientation$
 
Horizontal=�$��Center=�.+��� $��0,0,5,0q�$
��Bold"�$��Center=�$��0��$��0��Year:�� $ �� IsSynchronizedWithCurrentItem$
 TrueY�$��24��$��Center=�$	��250��$��0��$��1������ *Years+ �� Mode$ TwoWay=� �� SelectedItem �� *Year+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=����� .R��� $��12(����	#FF413E3E$��Center=����� *Name+�� $��1,0,0,0q�$��2��$��24��$��11(�$��
Take Stock��$
��Left=����� *TakeStockCommand+=  7FirstFloor.ModernUI.Windows.Controls.ModernProgressRing  $��15,0,0,0q�$��45��$��45��   IsActive �� *IsBusy+���� *SelectedItem.Tag+ �� ElementName$ CmbRingStyle���� $��2��$��5,0,5,5q�$
 Vertical=�$��Stretch=�.+��� $��2,0,2,0q�
�������._��� $��5q�$��Right=�
�������$��12(����� *RecordCount+$ TwoWay=�� $��Stretch=�.+��� 
�������
�������._�&   System.Windows.Controls.DataGrid  -   $��cartDataGrid��   AreRowDetailsFrozen .    AutoGenerateColumns .     GridLinesVisibility$ 
Horizontal=�   HeadersVisibility$ Column=�$��0q�
�������   AlternatingRowBackground
 �����$	��446������ *StockReviewDetails+ �� GroupStyleSelector Z�  �� 
GroupStyle (  "System.Windows.Controls.GroupStyle     ContainerStyle �� " ��.���  � �� �� " ��.R�9� $	��0,1q�
�������
�������$	��0,1q����� $	��0,3q�._��� $
 
Horizontal=�.+��� $
��Bold"�����  �� Path$
 Name��� $��10,0,0,0q�$��(��$
��Bold"��� $
��Bold"����� $ 	ItemCount��� $��5,0,0,0q�$��Items��$
��Bold"��� $��)��$
��Bold"�.����    Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Stock��   CellTemplate �� .R��� $	��5,0q�$��Center=�$��Verdana)�$��11(�
���   �$
��Wrap=����� *	StockName+  $ Stock Start Balance�� �� .R��� $	��5,0q�$��Center=�$��Verdana)�$��11(�
���   �$
��Wrap=����� *InitialStockBalance+  $ Stock Start Balance Value�� �� .R��� $	��5,0q�$��Center=�$��Right=�$��Verdana)�$��11(�
���   �$
��Wrap=����� *InitialStockBalanceValue+ �� 	Converter# [    $ Qty Purchased�� �� .R��� $	��5,0q�$��Center=�$��Verdana)�$��11(�
���   �$
��Wrap=����� *QuantityPackagePurchased+  $ Qty Sold�� �� .R��� $	��5,0q�$��Center=�$��Verdana)�$��11(�
���   �$
��Wrap=����� *QuantityPackageSold+  $ Stock Balance�� �� .R��� $	��5,0q�$��Center=�$��Verdana)�$��11(�
���   �$
��Wrap=����� *StockPackageBalance+  $ Stock Balance Value�� �� .R��� $	��5,0q�$��Center=�$��Right=�$��Verdana)�$��11(�
���   �$
��Wrap=����� *StockBalanceValue+# [    $ Total Sales�� �� .R��� $	��5,0q�$��Center=�$��Right=�$��Verdana)�$��11(�
���   �$
��Wrap=����� *SellingPrice+# [    $ Total Discount�� �� .R��� $	��5,0q�$��Right=�$��Center=�$��Verdana)�$��11(�
���   �$
��Wrap=����� *
Discount+# [  