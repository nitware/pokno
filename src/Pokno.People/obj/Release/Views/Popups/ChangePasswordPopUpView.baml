   M S B A M L   `   `   `  ���� c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  G CPokno.People, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Pokno.People.ViewModelPokno.People.ViewModel 7   1Pokno.People.Views.Popups.ChangePasswordPopUpView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     3vm$clr-namespace:Pokno.People.ViewModel     -     �Name$  childWindow��$	��400��$	��210�� � Title$ Change Password�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=�$��4q����	#FF1B1B8F � DataContext 9  3Pokno.People.ViewModel.ChangePasswordPopUpViewModel  .��� -    �Name$ 
LayoutRoot��$��20q�.   (System.Windows.Interactivity.Interaction   Triggers /   )System.Windows.Interactivity.EventTrigger  .   (System.Windows.Interactivity.TriggerBase   Actions. 6   0System.Windows.Interactivity.InvokeCommandAction  	   Command	 �� *SetPopUpCommand+
   CommandParameter
 ��  �� ElementName$ childWindow�� �� Mode$ OneWay=� � RowDefinitions �� $
��auto ��� $
��auto �.+��� $��0��$��Change Password��$��16(�.���� $��10q� �� Padding$ 5q�
�������$��0q� �� CornerRadius$ 3��
�������._��� .+�� $
��5,10q� � ColumnDefinitions �� $	��110 ���  �� $
��Auto ��� $
��auto ��� $
��auto �.+��� $��1��$��12(�$��0,3,0,0q�$��24��$	��Top=�New Password:G� -   $��pbNewPassKey��$��12(�$��0,3,0,0q�$��1��$��1���� $��0,3,0,0q�$��0��$��2��$��12(�$
��Wrap=�Confirm Password:G� -   $��pbConfirmPassKey��$��0,3,0,0q�$��1��$��2��$��12(��� $��1�� �� Orientation$ 
Horizontal=�$��Right=�.+��� $��Cancel��$��Right=�$��0,3,3,0q����� *CancelCommand+��  �� 	IsDefault . $��OK��$��Right=�$��0,3,0,0q����� *	OkCommand+