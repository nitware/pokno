   M S B A M L   `   `   `  ���� O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.InfrastructurePokno.Infrastructure.Converters   Pokno.Store&    Pokno.Store.Views.DailySalesView   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     a	converterKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.Infrastructure       � 	Resources  4   .Pokno.Infrastructure.Converters.MoneyConverter   MoneyConverter;   5Pokno.Infrastructure.Converters.DateToSelectConverter  DateConverter��%   &	        &	          .���� $��Stretch=�{��� *IsLoggedInUserHasRight+ �� Mode$ TwoWay=�.��� -    �Name$ 
LayoutRoot��.+�� .+���  �� CornerRadius$ 0,0,0,0��$��7q�$��0��
�������._��  � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��7,7,5,0q�$��0��._��  � ColumnDefinitions �� $
��auto ��� $��* �.+��� $��1��$��2��$��0,0,5,7q�
�������$��1q�$	��Top=�
������� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ DimGray��._��� $��12q� �� Orientation$ 
Horizontal=�.+��� $��0,0,5,0q�$��Center=�Select a date to view sales:(  "System.Windows.Controls.DatePicker  	   SelectedDate	 �� *Date+$ TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=��� -    ��Name$ 	btnSearch�� �� 	IsDefault .  � Cursor$
 Hand��$��0q�$��0q�$��1,0,0,0q�$��9(� � ToolTip$ Get for daily sales������ *FindCommand+.���� $��25��$��25��$��UniformToFill=����� *
SearchIcon+�� $��1��$��5,2,5,5q�$ Vertical=�$��Stretch=�.+�� $��Stretch=� �� �� �� �� �� .+��� $	��Top=�$��2,4,2,0q�
�������$��1��._��  �� �� ��  �� $
��auto ��� $
��auto �.+��� $��0��$��0��$��3��$ 0,0,0,0��
�������._��� $��	12,5,12,0q�.+��� 
���iii�$��0,0,0,1q�$��0,0,0,2q�$��Stretch=�._��� $ 
Horizontal=�.+��� $��16(�DAILY SALES FOR�� $��5,0,0,0q�$��16(����� *Date+ �� StringFormat$ d��� $��0,2,0,7q� �� $
��auto ��� �� $
��auto ��� �� $
��auto ��� �� $
��auto ���  �� .+��� $��0,0,5,0q�$��0��$��0��Total Cost Price:�� $��0,0,0,0q�$��1��$��0��$
��Bold"����� *TotalCostPrice+ �� 	Converter# [  �� $��0,0,5,0q�$��2��$��0��Total Selling Price:�� $��3��$��0��$
��Bold"����� *TotalSellingPrice+# [  �� $��0,0,5,0q�$��0��$��4��$��Right=�Total Discount:�� $��5��$��0��$
��Bold"����� *TotalDiscount+# [  �� $��0,0,5,0q�$��0��$��6��$��Right=�Total Profit:�� $��7��$��0��$
��Bold"����� *TotalProfit+# [  �� $��2��$��0,0,0,0q�.+��� $��0,0,0,1q�$��Stretch=�._�� $��Center=� �� $��* ��� $��* �&   System.Windows.Controls.DataGrid     AreRowDetailsFrozen .    AutoGenerateColumns .     GridLinesVisibility$ 
Horizontal=�   HeadersVisibility$ Column=�$��0q�
�������   AlternatingRowBackground
 �����$	��375������ *
DailySales+$ TwoWay=� �� GroupStyleSelector Z�  �� 
GroupStyle (  "System.Windows.Controls.GroupStyle     ContainerStyle ��  �� 
TargetType" ��.���  �� Property � �� �� Value ��  �� 
TargetType" ��.R�9� $	��0,1q�
�������
�������$	��0,1q����� $	��0,3q�._��� $ 
Horizontal=�.+��� $��0,0,5,0q�$
��Bold"�INVOICE NO:�� $
��Bold"�����  �� Path$
 Name��� $��10,0,0,0q�$��(��$
��Bold"��� $
��Bold"����� $ 	ItemCount��� $��5,0,0,0q�$��Items��$
��Bold"��� $��)��$
��Bold"�.����    Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Package��    CellTemplate  �� .R��� $	��3,0q�$��12(�$
��Wrap=����� *PackageName+  $ Stock��  �� .R��� $	��3,0q�$��12(�$
��Wrap=����� *	StockName+  $ Quantity��  �� .R��� $	��3,0q�$��12(�$��Center=�$
��Wrap=����� *
Quantity+  $ 
Cost Price��  �� .R��� $	��3,0q�$��12(�$��Right=�$
��Wrap=����� *	CostPrice+# [    $ Selling Price��  �� .R��� $	��3,0q�$��12(�$��Right=�$
��Wrap=����� *SellingPrice+# [    $ Profit��  �� .R��� $	��3,0q�$��12(�$��Right=�$
��Wrap=����� *Profit+# [  