   M S B A M L   `   `   `  ���� O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.InfrastructurePokno.Infrastructure.Converters   Pokno.Store-   'Pokno.Store.Views.EnteredShelfStockView   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ]localKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.Infrastructure       � 	Resources  3   -Pokno.Infrastructure.Converters.DateConverter   DateConverter��%   &	          .��� -    �Name$ 
LayoutRoot��$��5q�
������� � RowDefinitions �� $
��Auto ��� $
��Auto �.+��� $��7,7,10,5q�
�������$��1q�$	��Top=�
������� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ DimGray��._��� $
��10,7q� �� Orientation$ 
Horizontal=�.+��� $��0,0,5,0q�$��Center=�$
��Bold"�From:(  "System.Windows.Controls.DatePicker  $��1��$��8��$	��150��$
��Left=�$��0,0,10,0q�   SelectedDate �� *
FromDate+ �� Mode$ TwoWay=��� $��0,0,5,0q�$��Center=�$
��Bold"�To:  $��1��$��8��$	��150��$
��Left=�$��0,0,5,0q� �� *ToDate+$ TwoWay=��� $��Search������ *SearchCommand+�� $��1��$��5,8,6,3q�._��� .+��� $��2,0,2,0q�
�������._��� $��5q�$��Right=�
�������$��Italic$�$��12(����� *RecordCount+$ TwoWay=�&   System.Windows.Controls.DataGrid     AreRowDetailsFrozen . 	   AutoGenerateColumns	 .  
   HeadersVisibility$
 Column=�$��0q�
�������   GridLinesVisibility$ 
Horizontal=�   AlternatingRowBackground
 �����$	��438������ *ShelfStocks+$ TwoWay=� �� 
GroupStyle (  "System.Windows.Controls.GroupStyle     ContainerStyle ��  �� 
TargetType" ��.���  �� Property � �� �� Value ��  �� 
TargetType" ��.R�9� $	��0,1q�
�������
�������$	��0,1q����� $	��0,3q�._��� $ 
Horizontal=�.+��� $
��Bold"����� *Name+ �� StringFormat$ {0:dd/MM/yyyy}���� $��10,0,0,0q�$��(��$
��Bold"��� $
��Bold"�����  �� Path$ 	ItemCount��� $��5,0,0,0q�$��Items��$
��Bold"��� $��)��$
��Bold"�.����    Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Stock��   CellTemplate �� .R��� $	��5,0q�$��12(�$
��Wrap=����� *StockPackage.Stock.Name+  $ Package�� �� .R��� $	��5,0q�$��12(�$
��Wrap=����� *StockPackage.Package.Name+  $ Quantity�� �� .R��� $	��5,0q�$��Center=�$��12(�$
��Wrap=����� *
Quantity+  $ Expiry Date�� �� .R��� $	��5,0q�$��12(�$
��Wrap=����� *
ExpiryDate+ �� 	Converter# [  