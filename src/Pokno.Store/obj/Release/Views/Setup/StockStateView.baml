   M S B A M L   `   `   `  ����   Pokno.Store&     Pokno.Store.Views.StockStateView   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .��� -     �Name$  
LayoutRoot��$��5q�.+��  � RowDefinitions �� $
��Auto ��� $��* ��� $��* �.+��� 
�������$��10,0,0,2q�
�������$��0��._�� $	��5,5q� � ColumnDefinitions �� $	��120 ��� $
��auto ��� $��* � �� $
��Auto ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $
��Bold"�$��0��$��0��Name:�� $��1��$��0��$
��Left=�$	��250������ *
Model.Name+ �� Mode$ TwoWay=��� $
��Bold"�$��0��$��1��$��0,3,0,0q�Description:�� $��1��$��1��$
��Left=�$��0,3,0,0q� �� TextWrapping$
 Wrap=�$��60��$	��250������ *Model.Description+$ TwoWay=��� $��0,2,0,0q�$��3��$��1��$��Stretch=�._��� $��2��$��0,0,0,2q� �� Orientation$ 
Horizontal=�.+��� $��Clear��$��28��$��Right=�$��0,0,2,0q�$	��Top=����� *ClearCommand+�� $
��Save��$��28��$��Right=�$	��Top=����� *SaveCommand+� $��1��$��Stretch=�$��0,2,0,0q�.+��� $��0,0,0,0q�$ Vertical=�.+��� 
�������._��� $��Right=�
�������$��Italic$�$��12(�$	��5,2q����� *RecordCount+$ TwoWay=��� 
�������._�&   System.Windows.Controls.DataGrid     AreRowDetailsFrozen .    AutoGenerateColumns .     GridLinesVisibility$ Vertical=�	   HeadersVisibility$	 Column=�$	��380������ *Models+$ TwoWay=�
   Columns
 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��   CellTemplate �� .R��� $	��5,0q�$��12(�$
��Wrap=����� *Name+  $ Description�� �� .R��� $	��5,0q�$��12(�$
��Wrap=����� *Description+