   M S B A M L   `   `   `  ���� O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.InfrastructurePokno.Infrastructure.Converters  p lSystem.Windows.Controls.Input.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35pTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.ToolkitSystem.Windows.Controls  Pokno.Store+   %Pokno.Store.Views.StockPriceCheckView   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     a	converterKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.Infrastructure     iControlsTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.Toolkit     X TXceed.Wpf.Toolkit, Version=2.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit    � 	Resources  3   -Pokno.Infrastructure.Converters.DateConverter   DateConverter;   5Pokno.Infrastructure.Converters.CheckToolTipConverter  CheckToolTipConverter;   5Pokno.Infrastructure.Converters.DateToSelectConverter  DateToSelectConverter4   .Pokno.Infrastructure.Converters.MoneyConverter  MoneyConverter8   2Pokno.Infrastructure.Converters.EnabilityConverter  EnabilityConverter  AutoCompleteBoxItemTemplate �� Orientation��%�   &	        &	      &	 
     &	      &	      &	                �� .R��� $ 
Horizontal=�.+��� $	��5,2q�$	��100��$
��Bold"�
����������� *Name+.���� $��Stretch=�{��� *PurchasedStockCanBeEdited+ �� Mode$ TwoWay=�.��� -    �Name$ 
LayoutRoot��$��5q����	#E7FFFFFF � ColumnDefinitions �� $��6* ��� $��5* �.+��� $��10,10,15,10q�$��1�� �� CornerRadius$ 0,20,0,0��
�������
�������$��1q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ DimGray��._�� $��0,5,0,5q� � RowDefinitions �� $
��Auto ��� $
��auto ��� $
��auto ��� $
��auto �.+�� $��1��$��0��$��2,5,2,5q� �� �� .+��� $��0q�$��2��._��� .+��� $	��2,0q�$��0��$��0��$��2��$ 2,2,0,0��._��� $��0,0,0,0q�.+��� $��Stretch=�._��� $
��Bold"�$��15(�
�������STOCK PRICE LIST&   System.Windows.Controls.DataGrid  	   AreRowDetailsFrozen	 . 
   AutoGenerateColumns
 .     GridLinesVisibility$ 
Horizontal=�   HeadersVisibility$ Column=�$��0q�
�������   AlternatingRowBackground
 �����$	��466������ *StockPrices+ �� GroupStyleSelector Z�  �� 
GroupStyle (  "System.Windows.Controls.GroupStyle     ContainerStyle ��  �� 
TargetType" ��.���  �� Property � �� �� Value ��  �� 
TargetType" ��.R�9� $	��0,1q�
�������
�������$	��0,1q����� $	��0,3q�._��� $ 
Horizontal=�.+��� $
��Bold"�����  �� Path$
 Name��� $��10,0,0,0q�$��(��$
��Bold"��� $
��Bold"����� $ 	ItemCount��� $��5,0,0,0q�$��Items��$
��Bold"��� $��)��$
��Bold"�.����    Columns 4	  .System.Windows.Controls.DataGridTemplateColumn	  ,
  &System.Windows.Controls.DataGridColumn 
  Header$ Package�� 	  CellTemplate �� .R��� $��5,0,3,0q�$��11(�$��Center=�$
��Wrap=����� *PackageName+	  $ 
Cost Price�� �� .R��� $��5,0,3,0q�$��11(�$��Right=�$��Center=�$
��Wrap=����� *	CostPrice+ �� 	Converter# [ 	  $ Selling Price�� �� .R��� $��5,0,0,0q�$��11(�$��Right=�$��Center=�$
��Wrap=����� *SellingPrice+# [ 	  $ Profit�� �� .R��� $��5,0,0,0q�$��11(�$��Right=�$��Center=�$
��Wrap=����� *Profit+# [ �� $��0��$��10,10,10,15q�$	��Top=�.+��� 
�������$ 20,0,0,0��
�������$��1,1,1,1q�   $ DimGray��._��� $ Vertical=�$��10,10,10,10q�.+��� $��0,0,0,0q�$ 5,5,0,5��._��� $��0,0,0,0q�.+��� $��0��$��2,10,2,2q� �� Padding$ 2q�$ 2��
�������$��1q�
�������._�� $��0,0,0,0q� �� $
��auto ��� $��* ��� $
��auto �.+��� $��1q�$��25��$��25��$��UniformToFill=����� *
SearchIcon+-  'System.Windows.Controls.AutoCompleteBox  $��1��
�������$��1q�   ValueMemberPath$
 Name��   ItemTemplate# [    IsTextCompletionEnabled .    ItemsSource �� *Stocks+   SelectedItem �� *Stock+$ TwoWay=�  �� UpdateSourceTrigger$  PropertyChanged=��� $��2,0,2,0q����#e0eaf6$��1��$��2��$��0��._��  �� �� ��  �� $
��auto ��� $
��auto �  {�.  $��0q�
�������
�������	 . 
 .  
 �����$ Column=�$	��200������ *SearchedStockPrices+ 	  $ Package�� �� .R��� $��5,0,3,0q�$��12(�$��Center=�$
��Wrap=����� *PackageName+	  $ Stock�� �� .R��� $��3,0,3,0q�$��12(�$��Center=�$
��Wrap=����� *	StockName+	  $ 
Cost Price�� �� .R��� $��5,0,3,0q�$��12(�$��Right=�$��Center=�$
��Wrap=����� *	CostPrice+# [ 	  $ Selling Price�� �� .R��� $��5,0,0,0q�$��12(�$��Right=�$��Center=�$
��Wrap=����� *SellingPrice+# [ 	  $ Profit�� �� .R��� $��5,0,0,0q�$��12(�$��Right=�$��Center=�$
��Wrap=����� *Profit+# [ 