   M S B A M L   `   `   `  ����  Pokno.Payment)    #Pokno.Payment.Views.PaymentTypeView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      X TXceed.Wpf.Toolkit, Version=2.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      .��5      �� $��Stretch=�6O   {�6   �� *IsLoggedInUserHasRight+  �� Mode$  TwoWay=�.��5   
   � -   5         �Name$ 
LayoutRoot��5      $��5,5,5,0q�6#   .+�5      �  � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $��* �6$   �� 5      $��* �6$   .+�5      �� 
�������$��10,0,0,2q�6,   
�������$��0��6\   ._�5      � $	��5,5q�6    � ColumnDefinitions 5      �� 5       $��80 �6/   �� 5!      $	��250 �6/   �� 5"      $��* �6/    5$      �� 5%      $
��Auto �6,   �� 5&      $��* �6,   �� 5'      $��* �6,   �� 5(      $��* �6,   �� 5)      $��* �6,   .+�5,      �� $
��Bold"�6$   $��0��66   $��0��6F   �� 6T   $�Name:��6X   6h   �� 5-      $��1��6"   $��0��62   ��6?   �� *
Model.Name+$  TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 52      $��0,2,0,0q�6!   $��3��62   $��1��6?   $��Stretch=�6O   ._�53      �� $��2��6)    �� Orientation$ 
Horizontal=�66   .+�54   "   �� $��Clear��6J   $��0,0,2,0q�6Z   ��6)   �� *ClearCommand+6Z   �� 55   "   $��Remove��6K   $��0,0,2,0q�6\   ��6)   �� *RemoveCommand+6\   �� 56   "   $
��Save��6I   ��6)   �� *SaveCommand+6I   57      58      5=      5>      � 5?      $��1��6   $��Stretch=�6$   $��0,2,0,0q�6B   .+�5@      �� $ Vertical=�6!   .+�5A      �� 
�������._�5B      �� $��Right=�6R   
�������$��Italic$�6�   $��12(�6�   $	��5,3q�6�   ��6(   �� *RecordCount+$  TwoWay=�6�   5C      �� 5E      
�������._�5F      &   System.Windows.Controls.DataGrid     AreRowDetailsFrozen .    AutoGenerateColumns .     HeadersVisibility$ Column=�5J   	   $	��100��5K   	   ��5G   	   �� *Models+$  TwoWay=�	   Columns	 5L   "   4  .System.Windows.Controls.DataGridTemplateColumn  5M   &   ,  &System.Windows.Controls.DataGridColumn
   Header$

 Name��6=      CellTemplate 5N   *   �� 5O   .   .R�5P   2   �� $	��5,0q�6<   $��12(�6I   $
��Wrap=�6m   ��6W   �� *Name+6m   5Q   /   5S   '   5^      5_      5`      5a      5c      5d      5e      5f      