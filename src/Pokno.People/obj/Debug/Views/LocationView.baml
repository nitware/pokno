   M S B A M L   `   `   `  ����  Pokno.People%    Pokno.People.Views.LocationView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      Msdk=http://schemas.microsoft.com/winfx/2006/xaml/presentation/sdk     5   /   .��5	      �� $��Stretch=�6O   {�6   �� *IsLoggedInUserHasRight+  �� Mode$  TwoWay=�.��5   
   � -   5         �Name$ 
LayoutRoot��5      $��5q�6#   .+�5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $��* �6    .+�5      �� 
�������$��10,0,0,2q�6(   
�������$��0��6X   ._�5      � $	��5,5q�6    � ColumnDefinitions 5      �� 5      $	��120 �6+   �� 5      $	��250 �6+   �� 5       5      �� 5      $
��Auto �6(   �� 5      $��* �6(   �� 5      $��* �6(   �� 5      $��* �6(   �� 5      $��* �6(   .+�5!      �� $
��Bold"�6    $��0��62   $��0��6B   Name:6V   �� 5"      $��1��6   $��0��6.   ��6;   �� *
Model.Name+$  TwoWay=��� 5#      $
��Bold"�6    $��0��62   $��1��6B   $��0,3,0,0q�6O   
Address:6j   �� 5$      $��1��6   $��1��6.   $��0,3,0,0q�6;   $��60��6x    �� TextWrapping$
 Wrap=�6�   ��6L   �� *Model.Address+$  TwoWay=�6�   �� 5&      $��0,5,0,0q�6   $��2��6.   $��1��6;   ._�5'      �� $��2��6)    �� Orientation$ 
Horizontal=�66   .+�5(   "   �� $��Clear��6J   $��0,0,2,0q�6Z   ��6)   �� *ClearCommand+6Z   �� 5)   "   $��Remove��6K   $��0,0,2,0q�6\   ��6)   �� *RemoveCommand+6\   �� 5*   "   $
��Save��6I   ��6)   �� *SaveCommand+6I   5+      5,      5-      5.      � 5/      $��1��6   $��Stretch=�6    $��0,2,0,0q�6>   .+�50      �� .+�51      �� 
�������._�52      �� $��Right=�6R   
�������$��Italic$�6�   $��12(�6�   $	��5,2q�6�   ��6(   �� *RecordCount+$  TwoWay=�6�   53      �� 54      
�������$��0,1,0,0q�65   ._�55      &   System.Windows.Controls.DataGrid     AreRowDetailsFrozen .    AutoGenerateColumns .     HeadersVisibility$ Column=�58   #   $��0,2,0,0q�59   #   $	��365��5:   #   ��55      �� *Models+$  TwoWay=�	   Columns	 5=      4  .System.Windows.Controls.DataGridTemplateColumn  5>      ,  &System.Windows.Controls.DataGridColumn
   Header$

 Name��65      CellTemplate 5?   "   �� 5@   &   .R�5A   *   �� $��5,0,0,0q�64   $��12(�6E   $
��Wrap=�6i   ��6S   �� *Name+6i   5B   '   5D        5E      $
 Address��65    5F   "   �� 5G   &   .R�5H   .   �� $��5,0,0,0q�68   $��12(�6I   $
��Wrap=�6p   ��6W   �� *	Address+6p   5I   '   5K      5N      5O      5P      5Q      5U      5X      5Y      5Z      