   M S B A M L   `   `   `  ����  Pokno.People"    Pokno.People.Views.RightView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      Msdk=http://schemas.microsoft.com/winfx/2006/xaml/presentation/sdk     5   /   .��5	      � -   5          �Name$  
LayoutRoot��5	      $��5q�6   .+�5
   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $��* �6    .+�5      �� 
�������$��10,0,0,2q�6(   
�������$��0��6X   ._�5      � $��5,0,0,5q�6    � ColumnDefinitions 5      �� 5      $	��120 �6+   �� 5      $	��220 �6+   �� 5      $��* �6+    5      �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   .+�5      �� $
��Bold"�6    $��0��62   $��0��6B   Right:6W   �� 5       $��1��6   $��0��6.   ��6;   �� *
Model.Name+ �� Mode$ TwoWay=��� 5#      $
��Bold"�6    $��0��62   $��2��6B   $��0,3,0,0q�6O   Description:6n   �� 5$      $��70��6N   $��1��6Z   $��2��6j   $��0,3,0,0q�6w    �� TextWrapping$
 Wrap=�6�   ��6   �� *Model.Description+$ TwoWay=�6�   �� 5&      $��1��6!   $��3��61   $	��0,6q�6>    �� Orientation$ 
Horizontal=�6K   .+�5'      �� $��Clear��6B   $��0,0,2,0q�6R   ��6!   �� *ClearCommand+6R   �� 5(      $��Remove��6C   $��0,0,2,0q�6T   ��6!   �� *RemoveCommand+6T   �� 5)      $
��Save��6A   ��6!   �� *SaveCommand+6A   5*      5,      5-      � 5.      $��1��6   $��Stretch=�6    $��0,2,0,0q�6>   .+�5/      �� .+�50      �� 
�������._�51      �� $��Right=�6J   
�������$��Italic$�6y   $��12(�6�   $	��5,2q�6�   ��6    �� *RecordCount+$ TwoWay=�6�   52      �� 53      
�������$��0,1,0,0q�6-   ._�54      &   System.Windows.Controls.DataGrid     HeadersVisibility$ Column=�6      AutoGenerateColumns .     AreRowDetailsFrozen . $	��400��59   !   ��56   !   �� *Models+$ TwoWay=�	   Columns	 5:      4  .System.Windows.Controls.DataGridTemplateColumn  5;      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Right��66      CellTemplate 5<   "   �� 5=   &   .R�5>   *   �� $
��Wrap=�64   $��12(�6H   ��6V   �� *Name+5?   '   5A        5C      $
 Description��65    5D   "   �� 5E   &   .R�5F   *   �� $
��Wrap=�64   $��12(�6H   ��6V   �� *Description+5G   '   5I      5L      5N      5O      5P      5R      5T      5U      