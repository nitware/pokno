   M S B A M L   `   `   `  ����   Pokno.Payment)    #Pokno.Payment.Views.PaymentTypeView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     X TXceed.Wpf.Toolkit, Version=2.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  .���� $��Stretch=�{��� *IsLoggedInUserHasRight+  �� Mode$  TwoWay=�.��� -    �Name$ 
LayoutRoot��$��5,5,5,0q�.+��  � RowDefinitions �� $
��Auto ��� $��* ��� $��* �.+��� 
�������$��10,0,0,2q�
�������$��0��._�� $	��5,5q� � ColumnDefinitions �� $��80 ��� $	��250 ��� $��* � �� $
��Auto ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $
��Bold"�$��0��$��0���� $�Name:���� $��1��$��0������ *
Model.Name+$  TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� $��0,2,0,0q�$��3��$��1��$��Stretch=�._��� $��2�� �� Orientation$ 
Horizontal=�.+��� $��Clear��$��0,0,2,0q����� *ClearCommand+�� $��Remove��$��0,0,2,0q����� *RemoveCommand+�� $
��Save������ *SaveCommand+� $��1��$��Stretch=�$��0,2,0,0q�.+��� $ Vertical=�.+��� 
�������._��� $��Right=�
�������$��Italic$�$��12(�$	��5,3q����� *RecordCount+$  TwoWay=��� 
�������._�&   System.Windows.Controls.DataGrid     AreRowDetailsFrozen .    AutoGenerateColumns .     HeadersVisibility$ Column=�$	��100������ *Models+$  TwoWay=�	   Columns	 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn
   Header$

 Name��   CellTemplate �� .R��� $	��5,0q�$��12(�$
��Wrap=����� *Name+