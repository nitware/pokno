   M S B A M L   `   `   `  ����   Pokno.People#    Pokno.People.Views.PersonView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Msdk=http://schemas.microsoft.com/winfx/2006/xaml/presentation/sdk     Z VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI  .���� $��Stretch=�{��� *IsLoggedInUserHasRight+  �� Mode$  TwoWay=�.��� -    �Name$ 
LayoutRoot��$��5q�.+��  � RowDefinitions �� $
��Auto ��� $��* ��� $��* �.+��� 
�������$��10,0,0,2q�
�������$��0��._�� $	��5,5q� � ColumnDefinitions �� $	��120 ��� $	��230 ���  �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0,3,0,0q�$
��Bold"�$��0��$��0��
Surname:�� $��0,3,0,0q�$��1��$��0������ *Model.LastName+$  TwoWay=��� $��0,3,0,0q�$
��Bold"�$��0��$��1��First Name:�� $��0,3,0,0q�$��1��$��1������ *Model.FirstName+$  TwoWay=��� $��0,3,0,0q�$
��Bold"�$��0��$��2��Other Name:�� $��0,3,0,0q�$��1��$��2������ *Model.OtherName+$  TwoWay=��� $
��Bold"�$��0��$��3��$��0,3,0,0q�Person Type:�� $ �� IsSynchronizedWithCurrentItem$
 TrueY�$��3��$��1��$��0,3,0,0q�$��23������ *PersonTypes+$  TwoWay=� �� SelectedItem �� *
PersonType+$  TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=����� .R���  �� Orientation$ 
Horizontal=�.+��� ���	#FF413E3E���� *Name+�� $
��Bold"�$��0��$��4��$��0,3,0,0q�Mobile Phone:�� $��1��$��4��$��0,3,0,0q� �� TextWrapping$
 Wrap=����� *Model.MobilePhone+$  TwoWay=��� $
��Bold"�$��0��$��5��$��0,3,0,0q�Email:�� $��1��$��5��$��0,3,0,0q�$
 Wrap=����� *Model.Email+$  TwoWay=��� $
��Bold"�$��0��$��6��$��0,3,0,0q�Contact Address:�� $��1��$��6��$��0,3,0,0q�$
 Wrap=����� *Model.ContactAddress+$  TwoWay=��� $
��Bold"�$��0��$��7��$��0,3,0,0q�	Location:�� $
 TrueY�$��7��$��1��$��0,3,0,0q�$��23������ *	Locations+$  TwoWay=�	 �� SelectedValue	 �� *
Location+$  TwoWay=�$ PropertyChanged=����� .R��� $ 
Horizontal=�.+��� ���	#FF413E3E���� *Name+�� $��0,4,0,0q�$��8��$��1��$��Stretch=�._��� $��2��$ 
Horizontal=�.+��� $��Clear��$��28��$��Right=�$��0,0,2,0q�$	��Top=����� *ClearCommand+�� $��Remove��$��28��$��Right=�$��0,0,2,0q�$	��Top=����� *RemoveCommand+�� $
��Save��$��28��$��Right=�$	��Top=����� *SaveCommand+=  7FirstFloor.ModernUI.Windows.Controls.ModernProgressRing  $��1��$��6��$��2��$��5,0,0,0q�$��80��$��80��
   IsActive
 �� *IsBusy+���� *SelectedItem.Tag+ �� ElementName$ CmbRingStyle��� $��1��$��Stretch=�$��0,0,0,0q�.+��� $��0,3,0,0q�$ Vertical=�.+��� 
�������._��� $��Right=�
�������$��Italic$�$��12(�$	��5,2q����� *RecordCount+$  TwoWay=��� 
�������$��0,0,0,0q�._�&   System.Windows.Controls.DataGrid     AreRowDetailsFrozen .    AutoGenerateColumns .     HeadersVisibility$ Column=�$	��250������ *Models+$  TwoWay=�   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��   CellTemplate �� .R��� $��3,0,0,0q�$��12(�$
��Wrap=����� *
FullName+  $ Person Type�� �� .R��� $��5,0,0,0q�$��12(�$
��Wrap=����� *	Type.Name+  $ Mobile Phone�� �� .R��� $��5,0,0,0q�$��12(�$
��Wrap=����� *MobilePhone+  $ Email�� �� .R��� $��5,0,0,0q�$��12(�$
��Wrap=����� *Email+  $ Contact Address�� �� .R��� $��5,0,0,0q�$��12(�$
��Wrap=����� *ContactAddress+