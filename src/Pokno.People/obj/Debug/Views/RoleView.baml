   M S B A M L   `   `   `  ����  Pokno.People!    Pokno.People.Views.RoleView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      Msdk=http://schemas.microsoft.com/winfx/2006/xaml/presentation/sdk     5   /   .��5	      � -   5          �Name$  
LayoutRoot��5	      $��5q�6   .+�5
   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $��* �6    .+�5      �� 
�������$��10,0,0,2q�6(   
�������$��0��6X   ._�5      � $��5q�6    � ColumnDefinitions 5      �� 5      $	��120 �6+   �� 5      $	��250 �6+   �� 5      $��* �6+    5      �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   .+�5      �� $
��Bold"�6    $��0��62   $��0��6B   Role:6V   �� 5      $��1��6   $��0��6.   ��6;   �� *
Model.Name+ �� Mode$ TwoWay=��� 5!      $
��Bold"�6    $��0��62   $��2��6B   $��0,3,0,0q�6O   Description:6n   �� 5"      $��70��6N   $��1��6Z   $��2��6j   $��0,3,0,0q�6w    �� TextWrapping$
 Wrap=�6�   ��6   �� *Model.Description+$ TwoWay=�6�   �� 5&      $��0,3,0,0q�6   $��3��6.   $��1��6;   ._�5'      �� $��2��6%    �� Orientation$ 
Horizontal=�63   .+�5(      �� $��Clear��6F   $��Right=�6V   $��0,0,2,0q�6r   ��6%   �� *ClearCommand+6r   �� 5)      $��Remove��6G   $��Right=�6X   $��0,0,2,0q�6t   ��6%   �� *RemoveCommand+6t   �� 5*      $
��Save��6E   $��Right=�6T   ��6%   �� *SaveCommand+6T   5+      5,      5-      5.      � 5/      $��1��6   $��Stretch=�6    $��0,0,0,0q�6>   .+�50      �� $��0,3,0,0q�6   $ Vertical=�6.   .+�51      �� 
�������._�52      �� $��Right=�6J   
�������$��Italic$�6~   $��12(�6�   $	��5,2q�6�   ��6    �� *RecordCount+$ TwoWay=�6�   53      &   System.Windows.Controls.DataGrid  55      $��0,1,0,0q�6      HeadersVisibility$ Column=�56   !      AutoGenerateColumns .     AreRowDetailsFrozen . $��Stretch=�5;   !   $	��350��5<   !   ��58   !   �� *Models+$ TwoWay=�	   Columns	 5=      4  .System.Windows.Controls.DataGridTemplateColumn  5>      ,  &System.Windows.Controls.DataGridColumn
   Header$

 Role��66      CellTemplate 5?   "   �� 5@   &   .R�5A   *   �� $	��5,0q�64   $
��Wrap=�6A   $��12(�6U   ��6c   �� *Name+5B   '   5D        5F      $
 Description��65    5G   "   �� 5H   &   .R�5I   *   �� $	��5,0q�64   $
��Wrap=�6A   $��12(�6U   ��6c   �� *Description+5J   '   5L      5P      5S      5T      5V      5X      5Y      