   M S B A M L   `   `   `  ����   Pokno.People!    Pokno.People.Views.RoleView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Msdk=http://schemas.microsoft.com/winfx/2006/xaml/presentation/sdk     .��� -     �Name$  
LayoutRoot��$��5q�.+��  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��* �.+��� 
�������$��10,0,0,2q�
�������$��0��._�� $��5q� � ColumnDefinitions �� $	��120 ��� $	��250 ��� $��* � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $
��Bold"�$��0��$��0��Role:�� $��1��$��0������ *
Model.Name+ �� Mode$ TwoWay=��� $
��Bold"�$��0��$��2��$��0,3,0,0q�Description:�� $��70��$��1��$��2��$��0,3,0,0q� �� TextWrapping$
 Wrap=����� *Model.Description+$ TwoWay=��� $��0,3,0,0q�$��3��$��1��._��� $��2�� �� Orientation$ 
Horizontal=�.+��� $��Clear��$��Right=�$��0,0,2,0q����� *ClearCommand+�� $��Remove��$��Right=�$��0,0,2,0q����� *RemoveCommand+�� $
��Save��$��Right=����� *SaveCommand+� $��1��$��Stretch=�$��0,0,0,0q�.+��� $��0,3,0,0q�$ Vertical=�.+��� 
�������._��� $��Right=�
�������$��Italic$�$��12(�$	��5,2q����� *RecordCount+$ TwoWay=�&   System.Windows.Controls.DataGrid  $��0,1,0,0q�   HeadersVisibility$ Column=�   AutoGenerateColumns .     AreRowDetailsFrozen . $��Stretch=�$	��350������ *Models+$ TwoWay=�	   Columns	 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn
   Header$

 Role��   CellTemplate �� .R��� $	��5,0q�$
��Wrap=�$��12(����� *Name+  $
 Description�� �� .R��� $	��5,0q�$
��Wrap=�$��12(����� *Description+