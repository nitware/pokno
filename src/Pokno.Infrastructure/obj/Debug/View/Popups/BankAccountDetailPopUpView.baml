   M S B A M L   `   `   `  ����O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:Pokno.Infrastructure.ViewModel.Popups%Pokno.Infrastructure.ViewModel.Popups  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   	   A    ;Pokno.Infrastructure.View.Popups.BankAccountDetailPopUpView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Bvm3clr-namespace:Pokno.Infrastructure.ViewModel.Popups     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   -   5          �Name$  childWindow��5	   	   $	��290��5   	   $	��400��5   	    � 
ResizeMode$ NoResize=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	   $��3,25,3,3q�5   	   
���  �� � DataContext 5      K   EPokno.Infrastructure.ViewModel.Popups.BankAccountDetailPopUpViewModel  5   
   .��5      � $��10q�6   .  (System.Windows.Interactivity.Interaction   Triggers 5   
   /  )System.Windows.Interactivity.EventTrigger  5      .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6(   �� *SetPopUpCommand+   CommandParameter 6L   �� 	 �� ElementName$	 childWindow��
 �� Mode$
 OneWay=�5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5    
   �� $��0��6   $��0,10,0,0q�6   
�������$��1q�6C   
���iii� �� CornerRadius$ 
15,15,0,15��6m   ._�5!      �� $��20q�6   
������� �� Padding$ 10q�69   $��0q�6F   $ 8��6Z   
�������._�5"      �� .+�5#      �� 
�������$��0,0,0,0q�60   $��5,5,5,0q�6J   
�������$��Stretch=�6o   ._�5$      �� $
��15,5q�6$   $��Center=�62   $��13(�6O   $
��Bold"�6]   CHEQUE6w   5%      � 5'      $
��5,10q�6    � ColumnDefinitions 5(      �� 5)      $	��120 �6/   �� 5*       5-      �� 5.      $
��Auto �6,   �� 5/      $
��auto �6,   �� 50      $
��auto �6,   .+�52      �� $
��Bold"�6$   $��0��66   $��0��6F   Bank:6Z   �� 53       �� SelectedValuePath$ Id��6N   $
��Left=�6�   $��1��6�   $��0��6�   $	��170��6�   $��0,3,0,0q�6�   $��23��6�   ��6#   �� *Banks+$
 TwoWay=� �� SelectedValue 6e   �� *Id+��54      �� 55   "   .R�56   &   ��  �� Orientation$ 
Horizontal=�61   .+�57   *   �� $��Verdana)�64   ���	#FF413E3E��6`   �� *Name+6x   58   '   59   #   5;      �� 5=      $
��Bold"�6$   $��0��66   $��1��6F   $��0,3,0,0q�6S   Cheque No.:6q   �� 5>      $��0,3,0,0q�6"   $��1��63   $��1��6C   $	��170��6�   $
��Left=�6�   ��6P   �� *Cheque.ChequeNumber+$
 TwoWay=�6�   �� 5?      $
��Bold"�6$   $��0��66   $��2��6F   $��0,3,0,0q�6S   Account No.:6r   �� 5@      $��0,3,0,0q�6"   $��1��63   $��2��6C   $	��170��6�   $
��Left=�6�   ��6P   �� *Cheque.AccountNumber+$
 TwoWay=�6�   �� 5B      $��Bottom=�6N   $��Right=�6i   
�������$��Italic$�6�   $��12(�6�   $
��Bold"�6�   $��2��6�   $��2��6�   ��6$   �� *RecordCount+$
 TwoWay=�6�   5C      5D      5E      5F      �� 5H   
   $��0,3,79,0q�6   $��1��6#   $��Cancel��6R   $��75��6c   $��Right=�6n   ��60   �� *CancelCommand+6n   �� 5I   
   $��0,2,0,0q�6   $��1��6"   $��OK��6M   $��75��6Z   $��Right=�6e   ��6/   �� *	OkCommand+6e   5K      5L      