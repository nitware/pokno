   M S B A M L   `   `   `  ����O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.InfrastructurePokno.Infrastructure.Converters  5       Pokno.Account+   %Pokno.Account.Views.DailyExpensesView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      a	converterKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.Infrastructure     5      X TXceed.Wpf.Toolkit, Version=2.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      Z VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI  5        � 	Resources  5      4   .Pokno.Infrastructure.Converters.MoneyConverter   MoneyConverter>   8Pokno.Infrastructure.Converters.FinancialStatusConverter  FinancialStatusConverter8   2Pokno.Infrastructure.Converters.EnabilityConverter  EnabilityConverter��%W   &	        &	      &	 &       5   
   6#     5   
   6-     5   
   6'   5      .��5      �� $��Stretch=�6O   {�6   �� *IsLoggedInUserHasRight+ �� Mode$ TwoWay=�.��5   
   � $��5q�6   ���	#E7FFFFFF.+�5      � $��
10,5,10,10q�6    � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $
��auto �6$   �� 5      $
��auto �6$   .+�5      �� 
�������$��5,5,5,8q�6,    �� CornerRadius$ 20,0,0,0��6=   
�������$��1q�6h   $��0��6|    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ DimGray��6+   ._�5"      � $��60,10,20,15q�6    � ColumnDefinitions 5#      �� 5$      $	��115 �6/   �� 5%      $	��220 �6/   �� 5&      $
��auto �6/   �� 5'      $
��auto �6/    5)      �� 5*      $
��Auto �6,   �� 5+      $
��auto �6,   .+�5.      �� $��0,0,10,2q�6$   $��12(�66   
���iii�$
��Bold"�6Y   $��Center=�6k   $��1��6�   $��0��6�   �� 6�   $�Expenses Date��6�   6�   (  "System.Windows.Controls.DatePicker  50      $��1��6%   $��1��65   $��25��6u      SelectedDate 6B   �� *ExpensesDate+$ TwoWay=�6u   �� 51      $��1��6C   $��2��6P   $��1,0,0,0q�6`   $��9(�6q   $��Search��6~   $
��Left=�6�   ��6!   �� *SearchCommand+6�   =  7FirstFloor.ModernUI.Windows.Controls.ModernProgressRing  53      $��20,0,0,0q�61   $��3��6C   $��2��6S   $��45��6�   $��45��6�      IsActive 6d   �� *IsBusy+��6�   �� *SelectedItem.Tag+	 �� ElementName$	 CmbRingStyle��55      56      �� 5:      $��5,0,5,5q�6   $��1��6,   
�������$��1q�6Q   $��15(�6e   $��Expenses��6s   .��5;      � $��	20,3,20,5q�6    5<      �� 5=      $	��150 �6/   �� 5>      $	��283 �6/   �� 5?      $��* �6/    5A      �� 5B      $
��Auto �6,   �� 5C      $
��Auto �6,   �� 5D      $
��Auto �6,   �� 5E      $
��Auto �6,   �� 5F      $
��Auto �6,   �� 5G      $
��Auto �6,   .+�5J      �� $��12(�6$   $
��Bold"�62   $��0��6D   $��0��6T   $��Center=�6a   Collected By:6�   �� 5K      $��0��6"   $��1��6/   $��0,3,0,0q�6?   $��12(�6�   
 �� TextWrapping$

 Wrap=�6�   ��6P   �� *TargetModel.CollectedBy+$ TwoWay=�6�   �� 5M      $��0��6$   $��1��64   $��0,3,0,0q�6A   $��12(�6R   $
��Bold"�6`   �� 6t   $�Expenses Category:��6x   6�   �� 5N      $��12(�5Q   3   $��1��5R   3   $��1��5S   3   $��0,3,0,0q�5T   3   $��23��5U   3   ��5N   #   �� *ExpensesCategories+$ TwoWay=� �� SelectedValue 5O   3   �� *ExpensesCategory+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�{�5P   3   �� *	CanEdit+ �� 	Converter# [ ��5V      �� 5W   "   .R�5X   &   ��  �� Orientation$ 
Horizontal=�61   .+�5Y   *   �� ���	#FF413E3E��6K   �� *Name+5Z   '   5[   #   5]      �� 5_      $��0��6$   $��2��64   $��0,3,0,0q�6A   $��12(�6R   $
��Bold"�6`   �� 6t   $�Payment Type:��6x   6�   �� 5`      $��12(�5c   3   $��1��5d   3   $��2��5e   3   $��0,3,0,0q�5f   3   $��23��5g   3   ��5`   #   �� *PaymentTypes+$ TwoWay=� 5a   3   �� *PaymentType+$ TwoWay=�$ PropertyChanged=�{�5b   3   �� *	CanEdit+# [ ��5h      �� 5i   "   .R�5j   &   �� $ 
Horizontal=�61   .+�5k   *   �� ���	#FF413E3E��6K   �� *Name+5l   '   5m   #   5o      �� 5q      $��12(�6$   $
��Bold"�62   $��0��6D   $��3��6T   $��Center=�6a   $��0,3,0,0q�6|   �� 6�   $�Amount:��6�   6�   %  Xceed.Wpf.Toolkit.DecimalUpDown  5r      $��0,3,0,0q�6_   $��22��6p   $��1��6|   $��3��6�   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Maximum$ 99999999999999X�6�   $��12(�6�   $	��Top=�6�   �	  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]] 	  FormatString$ #,0.00��6�      Value 6-   �� *TargetModel.Amount+$ TwoWay=�6�   �� 5t      $��12(�6$   $
��Bold"�62   $��0��6D   $��4��6T   $��0,3,0,0q�6a   
Purpose:6|   �� 5u      $��1��6"   $��4��62   $��0,3,0,0q�6?   $��40��6�   $��12(�6�    �� 	IsEnabled . $

 Wrap=�6�   ��6P   �� *TargetModel.Purpose+$ TwoWay=�6�   �� 5w      $��1��6@   $��5��6P   $	��Add��6]   $��12(�6k   $
��Left=�6y   $��0,3,0,0q�6�   ��6!   �� *
AddCommand+6�   5x      5y      � 5~      $��2��6   $��5q�6$    5      �� 5�      .+�5�      �� ._�5�      �� .+�5�   "   � .+�5�   "   �� 
�������._�5�   &   �� .+�5�   .   �� $��0,1,0,0q�65   $��0,1,0,0q�6F   $��Bottom=�6`   $��Stretch=�6{   ._�5�   .   � $	��5,1q�63   $��Bottom=�6@    5�   2   �� 5�   6   �� 5�   6   .+�5�   2   �� 
���iii�$��Bottom=�6Q   $��14(�6l   EXPENSES TRAY6�   �� 5�   2   $��1��6=   $��Right=�6M   $ 
Horizontal=�6i   .+�5�   6   �� $��10,0,2,0q�6@   
���iii�Item Count:6u   �� 5�   6   
���   �$��20��6P   $ 15��6^   ._�5�   :   �� 
�������$��Center=�6�   $��Center=�6�   $
��Bold"�6�   ��6D   �� *RecordCount+$ TwoWay=�6�   5�   7   5�   3   5�   /   5�   +   &
   System.Windows.Controls.DataGrid
  5�   .    
  AreRowDetailsFrozen .  
  AutoGenerateColumns .   
  GridLinesVisibility$ Vertical=�5�       
  HeadersVisibility$ Column=�5�      
�������$	��130��5�      ��5�   7   �� *TargetCollection+{�5�   1   �� *	CanEdit+# [  
  Columns 5�   2   4  .System.Windows.Controls.DataGridTemplateColumn  5�   6   ,  &System.Windows.Controls.DataGridColumn   Header$ Collected By��6M      CellTemplate 5�   :   �� 5�   >   .R�5�   B   �� $	��5,0q�6L   $��12(�6Y   $
��Wrap=�6�   ��6g   �� *CollectedBy+6�   5�   ?   5�   7     5�   6   $ Category��6M    5�   :   �� 5�   >   .R�5�   B   �� $	��5,0q�6L   $��12(�6Y   $
��Wrap=�6�   ��6g   �� *Category.Name+6�   5�   ?   5�   7     5�   6   $ Amount��6M    5�   :   �� 5�   >   .R�5�   B   �� $	��5,0q�6L   $��12(�6Y   $��Right=�6g   $
��Wrap=�6�   ��6�   �� *Amount+# [  6�   5�   ?   5�   7     5�   6   $
 Mode��6M    5�   :   �� 5�   >   .R�5�   B   �� $	��5,0q�6L   $��12(�6Y   $
��Wrap=�6�   ��6g   �� *PaymentMode.Name+6�   5�   ?   5�   7     5�   6   $ Purpose��6M    5�   :   �� 5�   >   .R�5�   B   �� $	��5,0q�6L   $��12(�6Y   $
��Wrap=�6�   ��6g   �� *	Purpose+6�   5�   ?   5�   7   5�   /   �� 5�   .   $��2��69   $��0,0,15,0q�6F   $ 
Horizontal=�6X   .+�5�   2   �� $��9(�6[   $��Clear��6h   $��3,1,1,2q�6x   ��69   �� *ClearCommand+6x   �� 5�   2   $��9(�6[   $��Delete��6h   $��0,1,2,2q�6y   ��69   �� *RemoveCommand+6y   5�   /   5�   +   5�   '   5�   #   �� 5�      $ 
Horizontal=�6)   $��Right=�6B   .+�5�   "     $��0,3,15,0q�69   $��40��6i   $��40��6t    6K   �� *
IsSaving+��6�   �� *SelectedItem.Tag+$	 CmbRingStyle���� 5�   "   $
��Save��6I   $��16(�6X   $��0,3,0,0q�6f   ��6)   �� *SaveCommand+6f   5�      5�      5�      5�      5�      5�      5�      5     