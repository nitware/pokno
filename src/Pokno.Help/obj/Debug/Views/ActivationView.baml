   M S B A M L   `   `   `  ����O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.InfrastructurePokno.Infrastructure.Converters  5       
Pokno.Help%   Pokno.Help.Views.ActivationView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      a	converterKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.Infrastructure     5        � 	Resources  5      9   3Pokno.Infrastructure.Converters.VisibilityConverter   VisibilityConverter��%   &	          5   
   6(   5      .��5      �� $��Century Gothic)�6   .��5   
   � $
��10,0q�6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��2* �6#   .+�5      �� $��0,0,10,0q�6   ��5      �� 5       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5      �  � Color$ 	#FFf2fafd��6'    � Offset$
 0.85Q�69   � 5      $ 	#FFe4f6fa��6'   $ 1Q�69   � 5      $ 	#FFe7f4fc��6'   $	 0.3Q�69   � 5      $ 	#FFa9cde7��6'   $ 0Q�69   5      ._�5!      �� $��
20,20,20,0q�6   y�61   �� *IsEvaluationCopy+ �� 	Converter# [  .+�5"      �� .+�5#      �� $��0,0,0,3q�6$   $
��Bold"�6W   
�������$��15(�6|   $
��Wrap=�6�   ��65   �� *EvaluationStatus+6�   5$      �� 5&      
�������$��1q�61   ._�5'      � $��25��5)   "   ���	#FFE21B48���	#FFFDFCFC���	#FFFDFCFC � Maximum 5'   &   �� *MaxUsageDays+ � Value 5(   "   �� *RemainingUsageDays+5,      5-      5.      5/      � 51      $��1��6   $��2��6#   	 � RowDefinitions	 52      �� 53      $
��auto �6$   �� 54      $
��auto �6$   �� 55      $
��auto �6$   �� 56      $
��auto �6$   �� 57      $
��auto �6$   �� 58      $
��auto �6$   .+�5;      �� $��0,0,0,10q�6   $��0��6+   $��1��68   
�������$��0,0,0,1q�6[   ._�5<      �� 
 �� Orientation$
 
Horizontal=�6!   .+�5=      �� $��32(�6$   
�������store6K   �� 5>      $��0,0,10,0q�6$   $��32(�66   
���  ��pro6Z   �� 5?      
�������$��32(�66   	License6M   5@      5A      �� 5C      $��0,0,0,15q�6   $��1��6.   $��1��6;   $
��Bold"�6K   $��16(�6]   $
��Wrap=�6k   !Thank you for choosing storepro6�   �� 5E      $��0,0,0,30q�6   $��3��6-   $��Enter License��6:   $
��Bold"�6Q   $��14(�6c   .��5F      �� $��10q�6!   .+�5G      �� $
��Wrap=�6$   $��Normal"�68   $��12(�6L   vtIf you have your Activation Key for storepro, click the 'Activate' button below to enter it and unlock your software6�   �� 5H      $��0,10,5,0q�6$   $��0��66   $��Normal"�6F   $��12(�6Z   
User Key6r   � 5J      $��0,0,0,5q�6   $��1��60    5K      �� 5L   "   $��* �63   �� 5M   "   $
��auto �63   .+�5P      �� $��0,0,1,0q�6&   $��0��67    �� 
IsReadOnly . $��Stretch=�6n    �� TextWrapping$
 Wrap=�6�   $��Normal"�6�   $��12(�6�   ��6G   �� *Key+6�   �� 5Q      $��1��6%    � ToolTip$
 Copy��6U   $��Normal"�6d   $
��Left=�6x   $��12(�6�   ��65   �� *CopyCommand+.��5R   "   �� $��0��6(   $��15��6R   ��65   �� *	CopyImage+6R   5S      5U      �� 5W      $��1��6$   $��Normal"�61   $��12(�6E   Product Key6`   �� 5X      $��1��6"   $��1��6/   $��40��6�   $
 Wrap=�6�   $��Normal"�6�   $��12(�6�   ��6?   �� *	License+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5Z      $��0,3,0,0q�6!   $��2��6V   $��1��6c   $��Activate��6s   $	��180��6�   $��Normal"�6�   $
��Left=�6�   $��12(�6�   ��62   �� *ActivateCommand+6�   5[      5\      �� 5^      $��0,0,0,30q�6   $��2��6/   .+�5_      �� $��0,0,0,5q�6O   $
��Wrap=�6�   ��6    �� *ContinueEvaluationDescription+��6`   �� *%#ContinueEvaluationDescriptionColour+6�   �� 5`      $��Continue Evaluation��6K   $	��180��6i   $
��Left=�6u   ��6   �� *ContinueEvaluationCommand+6u   5a      �� 5c      $��0,0,0,30q�6   $��4��6/   .+�5d      �� $��0,0,0,5q�6    $
��Wrap=�61   97To purchase storepro, click the 'Purchase' button below6~   �� 5e      $��Purchase��6A   $	��180��6T   $
��Left=�6`   ��6   �� *PurchaseCommand+6`   5f      �� 5h      $��0,0,0,30q�6   $��5��6/   .+�5i      �� $��0,0,0,5q�6    $
��Wrap=�61   1/To exit storepro, click the 'Exit' button below6v   �� 5j      $
��Exit��6H   $	��180��6W   $
��Left=�6c   ��6   �� *ExitApplicationCommand+6c   5k      5m      5o      5p      5q      