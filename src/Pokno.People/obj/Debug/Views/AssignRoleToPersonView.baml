   M S B A M L   `   `   `  ����O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.InfrastructurePokno.Infrastructure.Converters  5       Pokno.People/   )Pokno.People.Views.AssignRoleToPersonView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      a	converterKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.Infrastructure     5        � 	Resources  5      8   2Pokno.Infrastructure.Converters.EnabilityConverter   EnabilityConverter��%   &	          5   
   6'   5      .��5      � -   5         �Name$ 
LayoutRoot��5      $��5q�6   .+�5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5      �� $��0,0,5,10q�6   
���   �$��0,0,1,1q�6;   $��0��6U   
������� J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ DimGray��6'   69   ._�5      � $
��5,10q�6    5      �� 5      $
��auto �6(   �� 5      $
��auto �6(    � ColumnDefinitions 5!      �� 5"      $��55 �6+   �� 5#      $	��250 �6+   �� 5$      $��* �6+   .+�5'      �� $
��Wrap=�6    $��12(�64   $��Center=�6B   $
��Bold"�6]   $��Verdana)�6o   User:6�   �� 5)      
�������$��0��65   $��1��6B   ._�5*      ��  �� Orientation$ Vertical=�6%   .+�5,      �� $��0,3,0,3q�6'   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6c   ��68   �� *Users+ �� Mode$ TwoWay=�	 �� SelectedItem	 6�   �� *User+$ TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=���5-      �� 5/   "   .R�50   &   �� $ 
Horizontal=�61   .+�51   *   �� $��0,0,5,0q�64   ���	#FF413E3E$��13(�6\   $
��Wrap=�6j   ��6~   �� *
FullName+6�   52   '   53   #   55      56      57      �� 59      $��0��6!   $��2��6.   $��Center=�6>   $ 
Horizontal=�6Y   .+�5:      �� $��10,0,2,0q�6$   Role:6>   �� 5;      $��2,0,0,0q�6K   $��Center=�6\   
���  ��$
��Wrap=�6�   $��12(�6�   $��Verdana)�6�   $
��Bold"�6�   ��6$   �� *SelectedUserRole.Name+6�   5<      5=      5>      � 5@      $��1��6   $��0,5,0,0q�6    .+�5A      �� $��0,0,0,0q�6   
�������._�5B      �� $ Vertical=�6!   .+�5D      �� 
�������._�5E      � .+�5F   "   �� $��0,2,5,2q�6[   $
��Left=�6l   $��Center=�6�   
���  ��$��Verdana)�6�   $��12(�6�   $��Italic$�6�   ��6,   �� *SelectedRoleName+$ TwoWay=�6�   �� 5G   "   $��2��6J   $��0,3,3,3q�6W   $
��Save��6h   $��Right=�6w   ��6)   �� *SaveCommand+6w   5H      5I      &   System.Windows.Controls.DataGrid  5K      $��0,1,0,0q�5L   !      ColumnHeaderHeight$ 30Q�5M   !      HeadersVisibility$ Column=�5N   !      AutoGenerateColumns .     AreRowDetailsFrozen . $	��420��5S   !   ��5P   !   �� *Roles+$ TwoWay=�   Columns 5T      4  .System.Windows.Controls.DataGridTemplateColumn  5U   "   ,  &System.Windows.Controls.DataGridColumn   Header$ Select��69      Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 6I      CellTemplate 5V   &   �� 5W   *   .R�5X   .   	� $��Center=�6�    	� 	GroupName$ 	SelectOne��6�   $��18(�6�    d� 	IsChecked 6:   �� *	HasUser+$ TwoWay=� �� 	Converter# [  6�   5Y   +   5[   #     5]   "   $
 Role��69   $	 450 6G    5^   &   �� 5_   *   .R�5`   .   �� $
��Wrap=�68   $��13(�6L   $��5,0,0,0q�6p   ��6Z   �� *Name+6p   5a   +   5c   #   5f      5g      5h      5i      5l      5m      5n      