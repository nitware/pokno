   M S B A M L   `   `   `  ����   Pokno.People'    !Pokno.People.Views.CompanyRepView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Msdk=http://schemas.microsoft.com/winfx/2006/xaml/presentation/sdk     .��� -     �Name$  
LayoutRoot��$��5q�.+��  � RowDefinitions �� $
��Auto ��� $��* ��� $��* �.+��� 
�������$��10,0,0,2q�
�������$��0��._�� $	��5,5q� � ColumnDefinitions �� $	��120 ��� $
��auto ��� $��* � �� $
��Auto ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $
��Bold"�$��0��$��0��
Company:�� $ �� IsSynchronizedWithCurrentItem$
 TrueY�$��0��$��1��$��0,3,0,0q�$��23������ *	Companies+ �� Mode$ TwoWay=� �� SelectedItem �� *	Company+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=����� .R���  �� Orientation$ 
Horizontal=�.+��� ���	#FF413E3E���� *Name+�� $
��Bold"�$��0��$��1��$��0,3,0,0q�	Person:�� $
 TrueY�$��1��$��1��$��0,3,0,0q�$��23������ *People+$ TwoWay=� �� *Person+$ TwoWay=�$ PropertyChanged=����� .R��� $ 
Horizontal=�.+��� ���	#FF413E3E���� *
FullName+�� $
��Bold"�$��0��$��2��$��0,3,0,0q�
Remarks:�� $��1��$��2��$
��Left=�$��0,3,0,0q�$��40�� �� TextWrapping$
 Wrap=�$	��250������ *Model.Description+$ TwoWay=��� $��0,3,0,0q�$��7��$��1��$��Stretch=�._��� $��2��$��0,0,3,6q�$ 
Horizontal=�.+��� $��Clear��$��28��$��Right=�$��0,0,2,0q�$	��Top=����� *ClearCommand+�� $��Remove��$��28��$��Right=�$��0,0,2,0q�$	��Top=����� *RemoveCommand+�� $
��Save��$��28��$��Right=�$	��Top=����� *SaveCommand+� $��1��$��Stretch=�$��0,2,0,0q�.+��� $��0,0,0,0q�$ Vertical=�.+��� 
�������._��� $��Right=�
�������$��Italic$�$��12(�$	��5,2q����� *RecordCount+$ TwoWay=��� 
�������$��0,1,0,0q�._�&   System.Windows.Controls.DataGrid  	   AreRowDetailsFrozen	 . 
   AutoGenerateColumns
 .     HeadersVisibility$ Column=�$	��350������ *Models+$ TwoWay=�   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Company��   CellTemplate �� .R��� $��3,0,3,0q�$��12(�$
��Wrap=����� *Company.Name+  $ Representative�� �� .R��� $��3,0,3,0q�$��12(�$
��Wrap=����� *Person.Name+  $ Remarks�� �� .R��� $��3,0,3,0q�$��12(�$
��Wrap=����� *	Remarks+