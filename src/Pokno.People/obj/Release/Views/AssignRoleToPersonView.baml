   M S B A M L   `   `   `  ���� O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.InfrastructurePokno.Infrastructure.Converters   Pokno.People/   )Pokno.People.Views.AssignRoleToPersonView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     a	converterKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.Infrastructure       � 	Resources  8   2Pokno.Infrastructure.Converters.EnabilityConverter   EnabilityConverter��%   &	          .��� -    �Name$ 
LayoutRoot��$��5q�.+��  � RowDefinitions �� $
��Auto ��� $
��auto ��� $
��auto �.+��� $��0,0,5,10q�
���   �$��0,0,1,1q�$��0��
������� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ DimGray��._�� $
��5,10q� �� $
��auto ��� $
��auto � � ColumnDefinitions �� $��55 ��� $	��250 ��� $��* �.+��� $
��Wrap=�$��12(�$��Center=�$
��Bold"�$��Verdana)�User:�� 
�������$��0��$��1��._���  �� Orientation$ Vertical=�.+��� $��0,3,0,3q�$ �� IsSynchronizedWithCurrentItem$
 TrueY����� *Users+ �� Mode$ TwoWay=�	 �� SelectedItem	 �� *User+$ TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=����� .R��� $ 
Horizontal=�.+��� $��0,0,5,0q����	#FF413E3E$��13(�$
��Wrap=����� *
FullName+�� $��0��$��2��$��Center=�$ 
Horizontal=�.+��� $��10,0,2,0q�Role:�� $��2,0,0,0q�$��Center=�
���  ��$
��Wrap=�$��12(�$��Verdana)�$
��Bold"����� *SelectedUserRole.Name+� $��1��$��0,5,0,0q�.+��� $��0,0,0,0q�
�������._��� $ Vertical=�.+��� 
�������._�� .+��� $��0,2,5,2q�$
��Left=�$��Center=�
���  ��$��Verdana)�$��12(�$��Italic$����� *SelectedRoleName+$ TwoWay=��� $��2��$��0,3,3,3q�$
��Save��$��Right=����� *SaveCommand+&   System.Windows.Controls.DataGrid  $��0,1,0,0q�   ColumnHeaderHeight$ 30Q�   HeadersVisibility$ Column=�   AutoGenerateColumns .     AreRowDetailsFrozen . $	��420������ *Roles+$ TwoWay=�   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Select��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 60    CellTemplate �� .R�	� $��Center=� 	� 	GroupName$ 	SelectOne��$��18(� d� 	IsChecked �� *	HasUser+$ TwoWay=� �� 	Converter# [    $
 Role��$	 450  �� .R��� $
��Wrap=�$��13(�$��5,0,0,0q����� *Name+