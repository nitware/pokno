   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5      G CPokno.People, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Pokno.People.ViewModelPokno.People.ViewModel 5      7   1Pokno.People.Views.Popups.ChangePasswordPopUpView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      3vm$clr-namespace:Pokno.People.ViewModel     5      -   5          �Name$  childWindow��5
      $	��400��5      $	��210��5   	    � Title$ Change Password��5	       � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	   $��4q�5   	   ���	#FF1B1B8F � DataContext 5      9  3Pokno.People.ViewModel.ChangePasswordPopUpViewModel  5   
   .��5!      � -   5         �Name$ 
LayoutRoot��5!      $��20q�6   .   (System.Windows.Interactivity.Interaction   Triggers 5"   
   /   )System.Windows.Interactivity.EventTrigger  5#      .   (System.Windows.Interactivity.TriggerBase   Actions. 5$      6   0System.Windows.Interactivity.InvokeCommandAction  	   Command	 6(   �� *SetPopUpCommand+
   CommandParameter
 6L   ��  �� ElementName$ childWindow�� �� Mode$ OneWay=�5%       � RowDefinitions 5(   
   �� 5)      $
��auto �6   �� 5*      $
��auto �6   .+�5.   
   �� $��0��6   $��Change Password��6    $��16(�69   .��5/      �� $��10q�6    �� Padding$ 5q�6!   
�������$��0q�6E    �� CornerRadius$ 3��6Y   
�������._�50      �� .+�55      � $
��5,10q�6    � ColumnDefinitions 56      �� 57      $	��110 �6/   �� 58       5;      �� 5<      $
��Auto �6,   �� 5=      $
��auto �6,   �� 5>      $
��auto �6,   .+�5A      �� $��1��6$   $��12(�61   $��0,3,0,0q�6?   $��24��6P   $	��Top=�6\   New Password:6�   G� 5B      -   5        $��pbNewPassKey��5B   &   $��12(�6:   $��0,3,0,0q�6H   $��1��6Y   $��1��6i   6�   �� 5D      $��0,3,0,0q�6$   $��0��65   $��2��6E   $��12(�6R   $
��Wrap=�6`   Confirm Password:6�   G� 5E      -   5        $��pbConfirmPassKey��5E   &   $��0,3,0,0q�6>   $��1��6O   $��2��6_   $��12(�6l   6�   5F      5G      5H      5I      �� 5L   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   .+�5P   
   �� $��Cancel��63   $��Right=�6D   $��0,3,3,0q�6`   ��6   �� *CancelCommand+6`   �� 5Q   
    �� 	IsDefault . $��OK��6@   $��Right=�6M   $��0,3,0,0q�6i   ��6   �� *	OkCommand+6i   5R      5S      5T      