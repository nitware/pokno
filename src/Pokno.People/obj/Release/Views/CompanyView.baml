   M S B A M L   `   `   `  ����   Pokno.People$    Pokno.People.Views.CompanyView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Msdk=http://schemas.microsoft.com/winfx/2006/xaml/presentation/sdk     .���� $��Stretch=�{��� *IsLoggedInUserHasRight+  �� Mode$  TwoWay=�.��� -    �Name$ 
LayoutRoot��$��5q�.+��  � RowDefinitions �� $
��Auto ��� $��* ��� $��* �.+��� 
�������$��10,0,0,2q�
�������$��0��._�� $	��5,5q� � ColumnDefinitions �� $	��120 ��� $
��auto ��� $��* � �� $
��Auto ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $
��Bold"�$��0��$��0��Name:�� $��1��$��0��$
��Left=�$	��250������ *
Model.Name+$  TwoWay=��� $
��Bold"�$��0��$��1��$��0,3,0,0q�
Address:�� $��1��$��1��$
��Left=�$��0,3,0,0q�$��40�� �� TextWrapping$
 Wrap=�$	��250������ *Model.Address+$  TwoWay=��� $
��Bold"�$��0��$��2��$��0,3,0,0q�Description:�� $��1��$��2��$
��Left=�$��0,3,0,0q�$��40��$
 Wrap=�$	��250������ *Model.Description+$  TwoWay=��� $
��Bold"�$��0��$��3��$��0,3,0,0q�
Website:�� $��1��$��3��$
��Left=�$��0,3,0,0q�$
 Wrap=�$	��250������ *Model.Website+$  TwoWay=��� $
��Bold"�$��0��$��4��$��0,3,0,0q�Email:�� $��1��$��4��$
��Left=�$��0,3,0,0q�$
 Wrap=�$	��250������ *Model.Email+$  TwoWay=��� $
��Bold"�$��0��$��5��$��0,3,0,0q�Phone:�� $��1��$��5��$
��Left=�$��0,3,0,0q�$
 Wrap=�$	��250������ *Model.Phone+$  TwoWay=��� $
��Bold"�$��0��$��6��$��0,3,0,0q�Disclaimer:�� $��1��$��6��$
��Left=�$��0,3,0,0q�$��40��$
 Wrap=�$	��250������ *Model.Disclaimer+$  TwoWay=��� $��0,2,0,0q�$��7��$��1��$��Stretch=�._��� $��2��$��0,0,3,0q� �� Orientation$ 
Horizontal=�.+��� $��Clear��$��28��$��Right=�$��0,0,2,0q�$	��Top=����� *ClearCommand+�� $��Remove��$��28��$��Right=�$��0,0,2,0q�$	��Top=����� *RemoveCommand+�� $
��Save��$��28��$��Right=�$	��Top=����� *SaveCommand+� $��1��$��Stretch=�$��0,5,0,0q�.+��� $ Vertical=�.+��� 
�������._��� $��Right=�
�������$��Italic$�$��12(�$	��5,2q����� *RecordCount+$  TwoWay=��� 
�������$��0,1,0,0q�._�&   System.Windows.Controls.DataGrid     AreRowDetailsFrozen .    AutoGenerateColumns .     HeadersVisibility$ Column=�$	��215������ *Models+$  TwoWay=�	   Columns	 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn
   Header$

 Name��   CellTemplate �� .R��� $��3,0,3,0q�$��12(�$
��Wrap=����� *Name+  $
 Address�� �� .R��� $��3,0,3,0q�$��12(�$
��Wrap=����� *	Address+  $
 Website�� �� .R��� $��3,0,3,0q�$��12(�$
��Wrap=����� *	Website+  $
 Email�� �� .R��� $��3,0,3,0q�$��12(�$
��Wrap=����� *Email+  $
 Phone�� �� .R��� $��3,0,3,0q�$��12(�$
��Wrap=����� *Phone+