   M S B A M L   `   `   `  ����   Pokno.People.    (Pokno.People.Views.AssignRightToRoleView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Msdk=http://schemas.microsoft.com/winfx/2006/xaml/presentation/sdk     .��� -     �Name$  
LayoutRoot��$��5q�.+��  � RowDefinitions �� $
��Auto ��� $
��auto ��� $
��auto �.+��� $��0,0,5,10q�
���   �$��0,0,1,1q�$��0��
������� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ DimGray��._�� $
��5,10q� �� $
��auto ��� $
��auto � � ColumnDefinitions �� $��55 ��� $	��250 ��� $��* �.+��� $
��Wrap=�$��12(�$��Center=�$
��Bold"�$��Verdana)�Role:�� 
�������$��0��$��1��._���  �� Orientation$ Vertical=�.+��� $��0,3,0,3q�$ �� IsSynchronizedWithCurrentItem$
 TrueY����� *Roles+ �� Mode$ TwoWay=� �� SelectedItem �� *Role+$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=����� .R��� $ 
Horizontal=�.+��� ���	#FF413E3E$��13(�$
��Wrap=�$	��300������ *Name+� $��1��$��0,5,0,0q�.+��� $��0,0,0,0q�
�������._��� $ Vertical=�.+��� 
�������._�� .+��� $��0,2,5,2q�$
��Left=�$��Center=�
���  ��$��Verdana)�$��12(�$��Italic$����� *SelectedRoleName+$ TwoWay=��� $��0,3,3,3q�$
��Save��$��Right=����� *SaveCommand+&   System.Windows.Controls.DataGrid  $��0,1,0,0q�
   HeadersVisibility$
 Column=�   AutoGenerateColumns .     AreRowDetailsFrozen . $��Stretch=�$	��420������ *Role.PersonRight.View+$ TwoWay=�   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Select��   CellTemplate �� .R��� $��5,1,0,1q�$��18(�$��Center=� d� 	IsChecked �� *
IsInRole+$ TwoWay=�$	 PropertyChanged=�  $ Right�� �� .R��� $
��Wrap=�$��13(�$��5,1,0,1q����� *Name+