   M S B A M L   `   `   `  ����   Pokno.People"    Pokno.People.Views.RightView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Msdk=http://schemas.microsoft.com/winfx/2006/xaml/presentation/sdk     .��� -     �Name$  
LayoutRoot��$��5q�.+��  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��* �.+��� 
�������$��10,0,0,2q�
�������$��0��._�� $��5,0,0,5q� � ColumnDefinitions �� $	��120 ��� $	��220 ��� $��* � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $
��Bold"�$��0��$��0��Right:�� $��1��$��0������ *
Model.Name+ �� Mode$ TwoWay=��� $
��Bold"�$��0��$��2��$��0,3,0,0q�Description:�� $��70��$��1��$��2��$��0,3,0,0q� �� TextWrapping$
 Wrap=����� *Model.Description+$ TwoWay=��� $��1��$��3��$	��0,6q� �� Orientation$ 
Horizontal=�.+��� $��Clear��$��0,0,2,0q����� *ClearCommand+�� $��Remove��$��0,0,2,0q����� *RemoveCommand+�� $
��Save������ *SaveCommand+� $��1��$��Stretch=�$��0,2,0,0q�.+��� .+��� 
�������._��� $��Right=�
�������$��Italic$�$��12(�$	��5,2q����� *RecordCount+$ TwoWay=��� 
�������$��0,1,0,0q�._�&   System.Windows.Controls.DataGrid     HeadersVisibility$ Column=�   AutoGenerateColumns .     AreRowDetailsFrozen . $	��400������ *Models+$ TwoWay=�	   Columns	 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn
   Header$
 Right��   CellTemplate �� .R��� $
��Wrap=�$��12(����� *Name+  $
 Description�� �� .R��� $
��Wrap=�$��12(����� *Description+