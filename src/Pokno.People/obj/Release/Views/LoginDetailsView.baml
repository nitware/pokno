   M S B A M L   `   `   `  ����   Pokno.People)    #Pokno.People.Views.LoginDetailsView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Msdk=http://schemas.microsoft.com/winfx/2006/xaml/presentation/sdk     .��� -     �Name$  
LayoutRoot��$��5q�.+��  � RowDefinitions �� $
��Auto ��� $��* ��� $��* �.+��� 
�������$��10,0,0,2q�
�������$��0��._�� $	��5,5q� � ColumnDefinitions �� $	��120 ��� $
��auto ��� $��* � �� $
��Auto ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $
��Bold"�$��0��$��0��$��0,3,0,0q�Lock:�� $��0,3,0,0q�$��1��$��0�� d� 	IsChecked �� *LoginDetail.IsLocked+ �� Mode$ TwoWay=��� $
��Bold"�$��0��$��1��$��0,3,0,0q�	Activate:�� $��0,3,0,0q�$��1��$��1�� �� *LoginDetail.IsActivated+$ TwoWay=��� $��0,3,0,0q�$
��Bold"�$��0��$��2��Name:�� $��0,3,0,0q�{�.  $��1��$��2��$
��Left=�$	��250������ *LoginDetail.Person.FullName+�� $
��Bold"�$��0��$��3��$��0,3,0,0q�	Username:�� $��1��$��3��$
��Left=�$��0,3,0,0q� �� TextWrapping$
 Wrap=�$	��250������ *LoginDetail.Username+$ TwoWay=��� $��0,3,0,0q�$��4��$��1��$��Stretch=�._��� $��2�� �� Orientation$ 
Horizontal=�.+��� $��Clear��$��28��$��Right=�$��0,0,2,0q�$	��Top=����� *ClearCommand+�� $��Reset��$��28��$��Right=�$��0,0,2,0q�$	��Top=����� *ResetCommand+�� $
��Save��$��28��$��Right=�$	��Top=����� *SaveCommand+� $��1��$��Stretch=�$��0,2,0,0q�.+��� $��0,0,0,0q�$ Vertical=�.+��� 
�������._��� $��Right=�
�������$��Italic$�$��12(�$	��5,2q����� *RecordCount+$ TwoWay=��� 
�������$��0,1,0,0q�._�&   System.Windows.Controls.DataGrid     AreRowDetailsFrozen .    AutoGenerateColumns .  	   HeadersVisibility$	 Column=�$	��450������ *LoginDetails+$ TwoWay=�
   Columns
 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��   CellTemplate �� .R��� $	��5,0q�$��12(�$
��Wrap=����� *Person.Name+  $ Username�� �� .R��� $	��5,0q�$��12(�$
��Wrap=����� *
Username+  $ 	Is Locked�� �� .R��� $	��5,1q�{�.  $��Center=� �� *
IsLocked+  $ Is Activated�� �� .R��� $	��5,1q�{�.  $��Center=� �� *IsActivated+