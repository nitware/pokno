   M S B A M L   `   `   `  ����  Pokno.Store+    %Pokno.Store.Views.StockReturnTypeView   5      U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      .��5	      � -   5          �Name$  
LayoutRoot��5	      $��5q�6   .+�5
   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $��* �6    �� 5      $��* �6    .+�5      �� 
�������$��10,0,0,2q�6(   
�������$��0��6X   ._�5      � $	��5,5q�6    � ColumnDefinitions 5      �� 5      $	��120 �6+   �� 5      $	��230 �6+   �� 5      $��* �6+    5      �� 5      $
��Auto �6(   �� 5      $��* �6(   �� 5      $��* �6(   �� 5      $��* �6(   �� 5      $��* �6(   .+�5       �� $
��Bold"�6    $��0��62   $��0��6B   Name:6V   �� 5!      $��1��6   $��0��6.   ��6;   �� *
Model.Name+ �� Mode$ TwoWay=��� 5#      $
��Bold"�6    $��0��62   $��1��6B   $��0,3,0,0q�6O   Description:6n   �� 5$      $��1��6   $��1��6.   $��0,3,0,0q�6;    �� TextWrapping$
 Wrap=�6|   $��60��6�   ��6L   �� *Model.Description+$ TwoWay=�6�   �� 5&      $��0,3,0,0q�6   $��2��6.   $��1��6;   $��Stretch=�6K   ._�5'      �� $��2��6%    �� Orientation$ 
Horizontal=�63   .+�5(      �� $��Clear��6F   $��0,0,2,0q�6V   ��6%   �� *ClearCommand+6V   �� 5*      $
��Save��6E   ��6%   �� *SaveCommand+6E   5+      5,      5.      5/      � 50      $��1��6   $��Stretch=�6    $��0,2,0,0q�6>   .+�51      �� $��0,0,0,0q�6   $ Vertical=�6.   .+�52      �� 
�������._�53      �� $��Right=�6N   
�������$��Italic$�6�   $��12(�6�   $	��5,2q�6�   ��6$   �� *RecordCount+$ TwoWay=�6�   54      �� 56      
�������$��0,1,0,0q�61   ._�57      &   System.Windows.Controls.DataGrid     AreRowDetailsFrozen .    AutoGenerateColumns .     HeadersVisibility$ Column=�5<      $	��330��5>      ��58      �� *Models+$ TwoWay=�	   Columns	 5?      4  .System.Windows.Controls.DataGridTemplateColumn  5@   "   ,  &System.Windows.Controls.DataGridColumn
   Header$

 Name��69      CellTemplate 5A   &   �� 5B   *   .R�5C   .   �� $	��5,0q�68   $��12(�6E   $
��Wrap=�6i   ��6S   �� *Name+6i   5D   +   5F   #     5G   "   $
 Description��69    5H   &   �� 5I   *   .R�5J   .   �� $	��5,0q�68   $��12(�6E   $
��Wrap=�6p   ��6S   �� *Description+6p   5K   +   5M   #   5P      5Q      5R      5S      5U      5V      5W      