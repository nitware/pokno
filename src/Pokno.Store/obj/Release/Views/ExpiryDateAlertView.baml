   M S B A M L   `   `   `  ���� O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.InfrastructurePokno.Infrastructure.Converters   Pokno.Store+   %Pokno.Store.Views.ExpiryDateAlertView   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     a	converterKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.Infrastructure       � 	Resources  G   APokno.Infrastructure.Converters.AboutToExpireStocksLabelConverter %  !AboutToExpireStocksLabelConverterC   =Pokno.Infrastructure.Converters.AboutToExpireStocksLabelColor ! AboutToExpireStocksLabelColor��%   &	        &	          .��� -    �Name$ 
LayoutRoot��$��10q�.+��� 
������� �� CornerRadius$ 5�� �� Padding$ 10q�
�������$��0,0,0,0q�._��� .+�� $��2,0,2,2q� � ColumnDefinitions �� �� .+��� $��Bottom=�STOCKS ABOUT TO EXPIRE�� $��1��$��Center=�$��Right=� �� Orientation$ 
Horizontal=�.+��� $��0,0,2,0q�$��Center=�Record Count�� 
���   �$��20��$ 15��$��Center=�._��� 
�������$��Center=�$��Center=�$
��Bold"����� *	ItemCount+ �� Mode$ TwoWay=�&   System.Windows.Controls.DataGrid     AreRowDetailsFrozen .    AutoGenerateColumns .  	   HeadersVisibility$	 Column=�
�������$	��460������ *AboutToExpiredStocks+
   Columns
 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Quantity Remaining��   CellTemplate �� .R��� $	��5,0q�$��13(�$��Right=�$
��Wrap=����� *QuantityRemaining+���� *RemainingAlertDays+ �� 	Converter# [   $ Package�� �� .R��� $	��5,0q�$��13(�$
��Wrap=����� *PackageName+���� *RemainingAlertDays+# [   $ Stock�� �� .R��� $	��5,0q�$��13(�$
��Wrap=����� *	StockName+���� *RemainingAlertDays+# [   $ Quantity on Shelf�� �� .R��� $	��5,0q�$��Right=�$��13(�$
��Wrap=����� *QuantityOnShelf+���� *RemainingAlertDays+# [   $ Remaining Days�� �� .R��� $	��5,0q�$��13(�$
��Left=�$
��Wrap=����� *RemainingAlertDays+# [  ���� *RemainingAlertDays+# [ 