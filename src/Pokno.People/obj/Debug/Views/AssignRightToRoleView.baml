   M S B A M L   `   `   `  ����  Pokno.People.    (Pokno.People.Views.AssignRightToRoleView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      Msdk=http://schemas.microsoft.com/winfx/2006/xaml/presentation/sdk     5      .��5      � -   5          �Name$  
LayoutRoot��5      $��5q�6   .+�5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5      �� $��0,0,5,10q�6   
���   �$��0,0,1,1q�6;   $��0��6U   
������� J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ DimGray��6'   69   ._�5      � $
��5,10q�6    5      �� 5      $
��auto �6(   �� 5      $
��auto �6(    � ColumnDefinitions 5      �� 5      $��55 �6+   �� 5      $	��250 �6+   �� 5       $��* �6+   .+�5#      �� $
��Wrap=�6    $��12(�64   $��Center=�6B   $
��Bold"�6]   $��Verdana)�6o   Role:6�   �� 5%      
�������$��0��65   $��1��6B   ._�5&      ��  �� Orientation$ Vertical=�6%   .+�5'      �� $��0,3,0,3q�6'   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6c   ��68   �� *Roles+ �� Mode$ TwoWay=� �� SelectedItem 6�   �� *Role+$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=���5(   "   �� 5)   &   .R�5*   *   �� $ 
Horizontal=�65   .+�5+   .   �� ���	#FF413E3E$��13(�6O   $
��Wrap=�6]   $	��300��6q   ��6}   �� *Name+6�   5,   +   5-   '   5/      50      51      53      54      � 56      $��1��6   $��0,5,0,0q�6    .+�57      �� $��0,0,0,0q�6   
�������._�58      �� $ Vertical=�6!   .+�5:      �� 
�������._�5;      � .+�5<   "   �� $��0,2,5,2q�6[   $
��Left=�6l   $��Center=�6�   
���  ��$��Verdana)�6�   $��12(�6�   $��Italic$�6�   ��6,   �� *SelectedRoleName+$ TwoWay=�6�   �� 5=   "   $��0,3,3,3q�6I   $
��Save��6Z   $��Right=�6i   ��6)   �� *SaveCommand+6i   5>      5?      &   System.Windows.Controls.DataGrid  5A      $��0,1,0,0q�6#   
   HeadersVisibility$
 Column=�5C   !      AutoGenerateColumns .     AreRowDetailsFrozen . $��Stretch=�5H   !   $	��420��5J   !   ��5E   !   �� *Role.PersonRight.View+$ TwoWay=�   Columns 5K      4  .System.Windows.Controls.DataGridTemplateColumn  5L   "   ,  &System.Windows.Controls.DataGridColumn   Header$ Select��6:      CellTemplate 5M   &   �� 5N   *   .R�5O   .   �� $��5,1,0,1q�67   $��18(�6H   $��Center=�6�    d� 	IsChecked 6V   �� *
IsInRole+$ TwoWay=�$	 PropertyChanged=�6�   5P   +   5R   #     5T   "   $ Right��69    5U   &   �� 5V   *   .R�5W   .   �� $
��Wrap=�68   $��13(�6L   $��5,1,0,1q�6p   ��6Z   �� *Name+6p   5X   +   5Z   #   5^      5_      5`      5a      5b      5c      5e      