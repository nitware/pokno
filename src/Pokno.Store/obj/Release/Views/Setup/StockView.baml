   M S B A M L   `   `   `  ����   Pokno.Store!    Pokno.Store.Views.StockView   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .��� -     �Name$  
LayoutRoot��$��5q�.+��  � RowDefinitions �� $
��Auto ��� $��* ��� $��* �.+��� 
�������$��10,0,0,2q�
�������$��0��._�� $	��5,5q� � ColumnDefinitions �� $	��120 ��� $	��250 ��� $��* � �� $
��Auto ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $
��Bold"�$��0��$��0��Name:�� $��1��$��0������ *
Model.Name+ �� Mode$ TwoWay=��� $
��Bold"�$��0��$��1��$��0,3,0,0q�Stock Type:�� $ �� IsSynchronizedWithCurrentItem$
 TrueY�$��1��$��1��$��0,3,0,0q�$��23������ *
StockTypes+$ TwoWay=� �� SelectedItem �� *	StockType+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=����� .R���  �� Orientation$ 
Horizontal=�.+��� $��Verdana)����	#FF413E3E���� *Name+�� $
��Bold"�$��0��$��2��$��0,3,0,0q�Description:�� $��1��$��2��$��0,3,0,0q�$��70�� �� TextWrapping$
 Wrap=����� *Model.Description+$ TwoWay=��� $��3��$��3��$	��100��$
��Left=�$��	10,10,0,0q�$��UniformToFill=�$	��120���� $��0,2,0,0q�$��3��$��1��._��� $��2��$	��0,2q�$ 
Horizontal=�.+��� $��Clear��$��0,0,2,0q����� *ClearCommand+�� $��Remove��$��0,0,2,0q����� *RemoveCommand+�� $
��Save������ *SaveCommand+� $��1��$��Stretch=�$��0,1,0,0q�.+��� .+��� 
�������._��� $��Right=�
�������$��Italic$�$��12(�$	��5,2q����� *RecordCount+$ TwoWay=��� 
�������$��0,1,0,0q�._�&   System.Windows.Controls.DataGrid  	   AreRowDetailsFrozen	 . 
   AutoGenerateColumns
 .     HeadersVisibility$ Column=�$	��346������ *Models+$ TwoWay=�   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��   CellTemplate �� .R��� $	��5,0q�$��12(�$
��Wrap=����� *Name+  $ 
Stock Type�� �� .R��� $	��5,0q�$��12(�$
��Wrap=����� *	Type.Name+  $ Description��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 300  �� .R��� $	��5,0q�$��12(�$
��Wrap=����� *Description+