   M S B A M L   `   `   `  ����O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.InfrastructurePokno.Infrastructure.Converters  5       Pokno.Store-   'Pokno.Store.Views.EnteredShelfStockView   5      U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      ]localKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.Infrastructure     5        � 	Resources  5
      3   -Pokno.Infrastructure.Converters.DateConverter   DateConverter��%   &	          5   
   6   5      .��5      � -   5         �Name$ 
LayoutRoot��5      $��5q�6   
������� � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��7,7,10,5q�6   
�������$��1q�68   $	��Top=�6L   
������� J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ DimGray��6#   65   ._�5      �� $
��10,7q�6    �� Orientation$ 
Horizontal=�6'   .+�5      �� $��0,0,5,0q�6   $��Center=�6-   $
��Bold"�6H   From:6b   (  "System.Windows.Controls.DatePicker  5      $��1��6L   $��8��6\   $	��150��6i   $
��Left=�6u   $��0,0,10,0q�6�      SelectedDate 6   �� *
FromDate+ �� Mode$ TwoWay=�6�   �� 5      $��0,0,5,0q�6   $��Center=�6-   $
��Bold"�6H   To:6`     5       $��1��6J   $��8��6Z   $	��150��6g   $
��Left=�6s   $��0,0,5,0q�6�    6   �� *ToDate+$ TwoWay=�6�   �� 5"      $��Search��6;   ��6   �� *SearchCommand+6;   5#      5$      �� 5'   
   $��1��6   $��5,8,6,3q�6   ._�5(      �� .+�5)      �� $��2,0,2,0q�6   
�������._�5*      �� $��5q�6    $��Right=�6V   
�������$��Italic$�6�   $��12(�6�   ��6,   �� *RecordCount+$ TwoWay=�6�   5+      &   System.Windows.Controls.DataGrid  5-         AreRowDetailsFrozen . 	   AutoGenerateColumns	 .  
   HeadersVisibility$
 Column=�50      $��0q�51      
�������   GridLinesVisibility$ 
Horizontal=�55         AlternatingRowBackground
 �����$	��438��57      ��5-      �� *ShelfStocks+$ TwoWay=� �� 
GroupStyle 59      (  "System.Windows.Controls.GroupStyle  5:         ContainerStyle 5C      �� 5D   "    �� 
TargetType" ��6(   .�5E   &   ��  �� Property � �� �� Value 5F   *   �� 5G   .    �� 
TargetType" ��6>   .R�5H   2   9� $	��0,1q�6;   
�������
�������$	��0,1q�6u   ��5I   6   �� 5J   :   $	��0,3q�6A   ._�5K   >   �� $ 
Horizontal=�6I   .+�5L   B   �� $
��Bold"�6�   ��6L   �� *Name+ �� StringFormat$ {0:dd/MM/yyyy}��6�   �� 5M   B   $��10,0,0,0q�6L   $��(��6^   $
��Bold"�6g   �� 5N   B   $
��Bold"�6l   ��6L   ��  �� Path$ 	ItemCount�6l   �� 5O   B   $��5,0,0,0q�6L   $��Items��6]   $
��Bold"�6j   �� 5P   B   $��)��6L   $
��Bold"�6U   5Q   ?   5R   ;   .��5T   6   �� 5U   3   5V   /   5X   '   5Y   #   5[         Columns 5^      4  .System.Windows.Controls.DataGridTemplateColumn  5_      ,  &System.Windows.Controls.DataGridColumn   Header$ Stock��61      CellTemplate 5`      �� 5a   "   .R�5b   &   �� $	��5,0q�60   $��12(�6f   $
��Wrap=�6t   ��6=   �� *StockPackage.Stock.Name+6t   5c   #   5e        5g      $ Package��61    5h      �� 5i   "   .R�5j   &   �� $	��5,0q�60   $��12(�6h   $
��Wrap=�6v   ��6=   �� *StockPackage.Package.Name+6v   5k   #   5m        5o      $ Quantity��61    5p      �� 5q   "   .R�5r   &   �� $	��5,0q�60   $��Center=�6=   $��12(�6t   $
��Wrap=�6�   ��6Z   �� *
Quantity+6�   5s   #   5u        5w      $ Expiry Date��61    5x      �� 5y   "   .R�5z   &   �� $	��5,0q�60   $��12(�6�   $
��Wrap=�6�   ��6=   �� *
ExpiryDate+ �� 	Converter# [  6�   5{   #   5}      5�      5�      5�      5�      5�      