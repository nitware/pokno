   M S B A M L   `   `   `  ����O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.InfrastructurePokno.Infrastructure.Converters  5       Pokno.Store5   /Pokno.Store.Views.Setup.PackageRelationshipView   5      U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      UtoolkitAhttp://schemas.microsoft.com/winfx/2006/xaml/presentation/toolkit     5      a	converterKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.Infrastructure     5      X TXceed.Wpf.Toolkit, Version=2.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5        � 	Resources  5      8   2Pokno.Infrastructure.Converters.EnabilityConverter   EnabilityConverter6   0Pokno.Infrastructure.Converters.IsExistConverter  PackageRelationshipExistC   =Pokno.Infrastructure.Converters.MakeComboBoxItemBoldConverter  MakeComboBoxItemBold��%W   &	        &	      &	 &       5   
   6'     5   
   6%     5   
   62   5      .��5      � $��3q�6   .+�5   
   �  � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5      �� $��7,7,7,5q�6    �� CornerRadius$ 3��6&   $��0��67   
������� �� Padding$ 5q�6V   ._�5      �� $��7q�6   $ 2��6$   
�������$��1q�6J   $	��Top=�6^   
������� J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ DimGray��6+   6=   ._�5!      �� $��5q�6!    �� Orientation$ 
Horizontal=�6,   .+�5"      �� $��	5,0,105,0q�6$   $
��Bold"�67   $��Center=�6I   $��0��6d   $��0��6t   Stock:6�   �� 5$      $��0,3,0,0q�6#   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6`   $��Center=�6�   $��0��6�   $��1��6�   $��24��6  $	��220��6  ��64   �� *Stocks+ �� Mode$ TwoWay=�	 �� SelectedItem	 6�   �� *Stock+$ TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=���5%      �� 5&   "   .R�5'   &   �� $ 
Horizontal=�61   .+�5(   *   �� ��64   �� *HasPackageRelationship+ �� 	Converter# [ ��6�   �� *HasPackageRelationship+# [ ��6�   �� *Name+5)   '   5*   #   5,      5.      5/      50      �� 5N      
�������$��	7,5,10,10q�6(   $ 3��6;   
�������$��1��6_    5O        5P      $ DimGray��6'   ._�5S      �� $��12q�6   $ 2��6%   
�������$��3q�6K   ._�5T      � $��10q�6    � ColumnDefinitions 5U      �� 5V      $	��140 �6+   �� 5W      $	��220 �6+   �� 5X      $��* �6+    5Z      �� 5[      $
��Auto �6(   �� 5\      $
��auto �6(   �� 5]      $
��auto �6(   �� 5^      $
��auto �6(   .+�5a      �� $
��Bold"�6    $��0��62   $��0��6B   �� 6P   $�Package:��6T   6g   �� 5c      $
 TrueY�6M   $��0��6�   $��1��6�   $��0,3,0,0q�6�   ��6   �� *
Packages+$ TwoWay=�	 6r   �� *	Package+$ TwoWay=�$
 PropertyChanged=���5d      �� 5e      .R�5f   "   �� $ 
Horizontal=�6-   .+�5g   &   �� ���	#FF413E3E��6G   �� *Package.Name+5h   #   5i      5k      �� 5m      $
��Bold"�6    $��0��62   $��1��6B   $��0,3,0,0q�6O   �� 6a   $�Sub Package:��6e   6|   �� 5n      $
 TrueY�6P   $��1��6�   $��1��6�   $��0,3,0,0q�6�   ��6   �� *SubPackages+$ TwoWay=�	 6u   �� *
SubPackage+$ TwoWay=�$
 PropertyChanged=���5o      �� 5p      .R�5q   "   �� $ 
Horizontal=�6-   .+�5r   &   �� ���	#FF413E3E��6G   �� *Package.Name+5s   #   5t      5v      �� 5x      $
��Bold"�6    $��0��62   $��2��6B   $��0,3,0,0q�6O   �� 6a   $�Quantity In Package:��6e   6�   %  Xceed.Wpf.Toolkit.DecimalUpDown  5y      $��0,3,0,0q�6�   $��1��6�   $��2��6�   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value 6)   �� *TargetModel.Quantity+$ TwoWay=�{�6]   �� *IsQuantityEnabled+# [  6�   �� 5{      $��1��6<   $��3��6L   $	��Add��6Y   $
��Left=�6g   $��0,3,2,0q�6�   ��6   �� *
AddCommand+6�   �� 5}      $��Bottom=�6J   $��Right=�6e   
�������$��Italic$�6�   $��12(�6�   $
��Bold"�6�   $��2��6�   $��3��6�   ��6    �� *RecordCount+$ TwoWay=�6�   5~      5      5�      �� 5�      $��2��6   $��	7,4,10,10q�6"   $ 3��65   
������� 5�        5�      $ DimGray��6'   ._�5�      � $��15q�6   $��Stretch=�6    5�      �� 5�      $
��auto �6'   �� 5�      $��* �6'   �� 5�      $
��auto �6'    5�      �� 5�      $
��auto �6,   �� 5�      $
��auto �6,   .+�5�      � $��1��6   $��0��6/   $��2,0,2,3q�6<    5�      �� 5�   "   �� 5�   "   .+�5�      �� $��Bottom=�6(   PACKAGES RELATIONSHIP6Z   �� 5�      $��1��6)   $��Center=�69   $��Right=�6T   $ 
Horizontal=�6p   .+�5�   "   �� $��0,0,2,0q�6,   $��Center=�6=   Record Count6g   �� 5�   "   
���   �$��20��6<   $ 15��6J   $��Center=�6\   ._�5�   &   �� 
�������$��Center=�6k   $��Center=�6�   $
��Bold"�6�   ��60   �� *	ItemCount+$ TwoWay=�6�   5�   #   5�      5�      �� 5�      $��0,0,3,0q�6%   $��1��66   $��0��6C   $ Vertical=�6S   .+�5�      �� $	��5,0q�6    $��Center=�6-   $��Courier New)�6J   $��12(�6c   �� 6r   $	�Max��6v   6�   �� 5�      $	��150��6    $��Center=�6-   
���   �$��1��6W   $��20��6k   ��5�      �� 5�       �� EndPoint$ 0.5,1&�62    �� 
StartPoint$ 0.5,0&�6C   .��5�   "   �  � Color$ Black��6/    � Offset$ 0Q�6=   � 5�   "   $ White��6/   $ 1Q�6=   5�      5�      �� 5�      $	��5,0q�6    $��Center=�6-   $��Courier New)�6J   $��12(�6c   �� 6r   $	�Min��6v   6�   5�      �� 5�      $��1��6%   $��1��65   $��Stretch=�6B   .+�5�      � $��Stretch=�6   .+�5�      �� 
�������$��0,1,0,0q�66   ._�5�      &   System.Windows.Controls.DataGrid     AreRowDetailsFrozen .    AutoGenerateColumns .     HeadersVisibility$ Column=�5�   	   $	��175��5�   	   ��5�   	   �� *TargetCollection+$ TwoWay=�   Columns 5�   "   4  .System.Windows.Controls.DataGridTemplateColumn  5�   &   ,	  &System.Windows.Controls.DataGridColumn 	  Header$
 Rank��6=      CellTemplate 5�   *   �� 5�   .   .R�5�   2   �� $	��5,0q�6<   $��12(�6I   $��Center=�6W   $
��Wrap=�6�   ��6u   �� *Rank+6�   5�   /   5�   '     5�   &   $ Package��6=    5�   *   �� 5�   .   .R�5�   2   �� $	��5,0q�6<   $��12(�6I   $
��Wrap=�6}   ��6W   �� *Package.Package.Name+6}   5�   /   5�   '     5�   &   $ Sub Package��6=    5�   *   �� 5�   .   .R�5�   2   �� $	��5,0q�6<   $��12(�6I   $
��Wrap=�6�   ��6W   �� *SubPackage.Package.Name+6�   5�   /   5�   '     5�   &   $ Qty in Package��6=    5�   *   �� 5�   .   .R�5�   2   �� $	��5,0q�6<   $��12(�6I   $��Center=�6q   $
��Wrap=�6�   ��6W   �� *
Quantity+6�   5�   /   5�   '   5�      5�      5�      �� 5�      $��0,0,0,4q�6!   $��Stretch=�62   ._�5�      �� $��2��6%   $��3q�62   $��Right=�6=   $ 
Horizontal=�6Y   .+�5�      �� $��Clear��6F   $��0,0,2,0q�6V   ��6%   �� *ClearCommand+6V   �� 5�   "   $��0,0,2,0q�6)   $��Remove Selected Item��6\   ��6:   �� *RemoveCommand+6\   �� 5�   "   $��Delete��6K   $��0,0,2,0q�6\   ��6)   �� *DeleteCommand+6\   �� 5�      $
��Save��6E   ��6%   �� *SaveCommand+6E   5�      5�      5�      �� 5�      $��2��6%   $��1��65   $
��5,35q�6B   $ Vertical=�6P   $	��Top=�6g   .+�5�      �� $��Up��6;   $��44��6H   $��Right=�6T   $��0q�6p   $��Bottom=�6{   $��80��6�   ��6   �� *	UpCommand+6�   �� 5�      $
��Down��6=   $��44��6L   $��Right=�6X   $��0,3,0,0q�6t   $��Bottom=�6�   $��80��6�   ��6   �� *DownCommand+6�   5�      5�      5�      5�      5�      5�      