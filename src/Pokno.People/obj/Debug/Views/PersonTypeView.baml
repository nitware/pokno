   M S B A M L   `   `   `  ����  Pokno.People'    !Pokno.People.Views.PersonTypeView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      Msdk=http://schemas.microsoft.com/winfx/2006/xaml/presentation/sdk     5      Z VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI  5      .��5      �� $��Stretch=�6O   {�6   �� *IsLoggedInUserHasRight+  �� Mode$  TwoWay=�.��5   
   � -   5         �Name$ 
LayoutRoot��5      $��5q�6#   .+�5      �  � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $��* �6$   �� 5      $��* �6$   .+�5      �� 
�������$��10,0,0,2q�6,   
�������$��0��6\   ._�5      � $��5q�6    � ColumnDefinitions 5      �� 5      $	��120 �6/   �� 5      $
��auto �6/   �� 5      $��* �6/    5      �� 5      $
��Auto �6,   �� 5      $��* �6,   �� 5       $��* �6,   �� 5!      $��* �6,   �� 5"      $��* �6,   .+�5%      �� $
��Bold"�6$   $��0��66   $��0��6F   Name:6Z   �� 5&      $��1��6"   $��0��62   $
��Left=�6?   $	��250��6�   ��6Z   �� *
Model.Name+$  TwoWay=�6�   �� 5(      $
��Bold"�6$   $��0��66   $��1��6F   $��0,3,0,0q�6S   Description:6r   �� 5)      $��1��6"   $��1��62   $
��Left=�6?   $��0,3,0,0q�6Z    �� TextWrapping$
 Wrap=�6�   $��50��6�   $	��250��6�   ��6k   �� *Model.Description+$  TwoWay=�6�   �� 5+      $��0,2,0,0q�6!   $��3��62   $��1��6?   $��Stretch=�6O   ._�5,      �� $��2��6)   $	��0,2q�66    �� Orientation$ 
Horizontal=�6C   .+�5-   "   �� $��Clear��6J   $��0,0,2,0q�6Z   ��6)   �� *ClearCommand+6Z   �� 5.   "   $��Remove��6K   $��0,0,2,0q�6\   ��6)   �� *RemoveCommand+6\   �� 5/   "   $
��Save��6I   ��6)   �� *SaveCommand+6I   50      51      52      53      � 54      $��1��6   $��Stretch=�6$   $��0,2,0,0q�6B   .+�55      �� $��0,0,0,0q�6!   $ Vertical=�62   .+�56      �� 
�������._�57      �� $��Right=�6R   
�������$��Italic$�6�   $��12(�6�   $	��5,2q�6�   ��6(   �� *RecordCount+$  TwoWay=�6�   58      �� 5:      
�������$��0,1,0,0q�65   ._�5J      &   System.Windows.Controls.DataGrid     AreRowDetailsFrozen .    AutoGenerateColumns .     HeadersVisibility$ Column=�5N      $	��380��5P      ��5K      �� *Models+$  TwoWay=�	   Columns	 5Q   "   4  .System.Windows.Controls.DataGridTemplateColumn  5R   &   ,  &System.Windows.Controls.DataGridColumn
   Header$

 Name��6=      CellTemplate 5S   *   �� 5T   .   .R�5U   2   �� $	��5,0q�6<   $��12(�6I   $
��Wrap=�6m   ��6W   �� *Name+6m   5V   /   5X   '     5Y   &   $
 Description��6=    5Z   *   �� 5[   .   .R�5\   2   �� $	��5,0q�6<   $��12(�6I   $
��Wrap=�6t   ��6W   �� *Description+6t   5]   /   5_   '   5b      5c      5d      5e      5g      5h      5i      5j      