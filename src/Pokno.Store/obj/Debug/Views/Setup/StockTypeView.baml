   M S B A M L   `   `   `  ����  Pokno.Store%    Pokno.Store.Views.StockTypeView   5      U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      .��5	      � -   5          �Name$  
LayoutRoot��5	      $��5q�6   .+�5
   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $��* �6    �� 5      $��* �6    .+�5      �� 
�������$��10,0,0,2q�6(   
�������$��0��6X   ._�5      � $	��5,5q�6    � ColumnDefinitions 5      �� 5      $	��120 �6+   �� 5      $	��250 �6+   �� 5       5      �� 5      $
��Auto �6(   �� 5      $��* �6(   �� 5      $��* �6(   �� 5      $��* �6(   �� 5      $��* �6(   .+�5      �� $
��Bold"�6    $��0��62   $��0��6B   Name:6V   �� 5       $��1��6   $��0��6.   ��6;   �� *
Model.Name+ �� Mode$ TwoWay=��� 5!      $
��Bold"�6    $��0��62   $��1��6B   $��0,3,0,0q�6O   Stock Category:6q   �� 5#      $ �� IsSynchronizedWithCurrentItem$
 TrueY�6T   $��1��6�   $��1��6�   $��0,3,0,0q�6�   $��23��6   ��6   �� *StockCategories+$ TwoWay=� �� SelectedItem 6y   �� *StockCategory+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=���5$      �� 5%      .R�5&   "   ��  �� Orientation$ 
Horizontal=�6-   .+�5'   &   �� $��Arial)�60   ���	#FF413E3E��6Z   �� *Name+6r   5(   #   5)      5+      �� 5-      $
��Bold"�6    $��0��62   $��2��6B   $��0,3,0,0q�6O   Description:6n   �� 5.      $��1��6   $��2��6.   $��0,3,0,0q�6;   $��70��6|    �� TextWrapping$
 Wrap=�6�   ��6L   �� *Model.Description+$ TwoWay=�6�   �� 50      $��0,2,0,0q�6   $��3��6.   $��1��6;   $��2��6K   $��Stretch=�6_   ._�51      �� $��2��6%   $	��0,3q�62   $ 
Horizontal=�6?   .+�52      �� $��Clear��6F   $��0,0,2,0q�6V   ��6%   �� *ClearCommand+6V   �� 53      $��Remove��6G   $��0,0,2,0q�6X   ��6%   �� *RemoveCommand+6X   �� 54      $
��Save��6E   ��6%   �� *SaveCommand+6E   55      56      58      59      � 5:      $��1��6   $��Stretch=�6    $��0,1,0,0q�6>   .+�5;      �� .+�5<      �� 
�������._�5=      �� $��Right=�6J   
�������$��Italic$�6~   $��12(�6�   $	��5,2q�6�   ��6    �� *RecordCount+$ TwoWay=�6�   5>      �� 5?      
�������$��0,1,0,0q�6-   ._�5@      &   System.Windows.Controls.DataGrid  	   AreRowDetailsFrozen	 . 
   AutoGenerateColumns
 .     HeadersVisibility$ Column=�5E      $	��346��5G   #   ��5A      �� *Models+$ TwoWay=�   Columns 5H      4  .System.Windows.Controls.DataGridTemplateColumn  5I      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��65      CellTemplate 5J   "   �� 5K   &   .R�5L   .   �� $	��5,0q�68   $��12(�6E   $
��Wrap=�6i   ��6S   �� *Name+6i   5M   '   5O        5P      $ Stock Category��65    5Q   "   �� 5R   &   .R�5S   .   �� $	��5,0q�68   $��12(�6E   $
��Wrap=�6r   ��6S   �� *Category.Name+6r   5T   '   5V        5W      $ Description��65    5X   "   �� 5Y   &   .R�5Z   .   �� $	��5,0q�68   $��12(�6E   $
��Wrap=�6p   ��6S   �� *Description+6p   5[   '   5]      5`      5a      5b      5c      5e      5g      5h      