   M S B A M L   `   `   `  ����   Pokno.Payment"    Pokno.Payment.Views.BankView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .���� $��Stretch=�{��� *IsLoggedInUserHasRight+  �� Mode$  TwoWay=�.��� -    �Name$ 
LayoutRoot��$��5,5,5,0q�����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FFf2fafd�� � Offset$
 0.85Q�� $ 	#FFe4f6fa��$ 1Q�� $ 	#FFe7f4fc��$	 0.3Q�� $ 	#FFa9cde7��$ 0Q�.+��  � RowDefinitions �� $
��Auto ��� $��* ��� $��* �.+��� 
�������$��10,0,0,2q�
�������$��0��._�� $	��5,5q� � ColumnDefinitions �� $	��120 ��� $	��250 ��� $��* � �� $
��Auto ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $
��Bold"�$��0��$��0��Name:�� $��1��$��0��$
��Left=�$	��250������ *
Model.Name+$  TwoWay=��� $
��Bold"�$��0��$��1��$��0,3,0,0q�Description:�� $��1��$��1��$��0,3,0,0q� �� TextWrapping$
 Wrap=�$��50������ *Model.Description+$  TwoWay=��� $��0,3,0,0q�$��3��$��1��$��Stretch=�._��� $��2��	 �� Orientation$	 
Horizontal=�.+��� $��Clear��$��0,0,2,0q����� *ClearCommand+�� $��Remove��$��0,0,2,0q����� *RemoveCommand+�� $
��Save������ *SaveCommand+� $��1��$��Stretch=�$��0,2,0,0q�.+��� $��0,0,0,0q�$	 Vertical=�.+��� 
�������._��� $��Right=�
�������$��Italic$�$��12(�$	��5,3q����� *RecordCount+$  TwoWay=�&   System.Windows.Controls.DataGrid  
   AreRowDetailsFrozen
 .    AutoGenerateColumns .     GridLinesVisibility$ Vertical=�   HeadersVisibility$ Column=�$	��200������ *Models+$  TwoWay=�   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��   CellTemplate �� .R��� $	��5,0q�$��12(�$
��Wrap=����� *Name+  $ Description�� �� .R��� $	��5,0q�$��12(�$
��Wrap=����� *Description+