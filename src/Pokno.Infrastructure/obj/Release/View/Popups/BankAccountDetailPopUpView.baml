   M S B A M L   `   `   `  ���� O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:Pokno.Infrastructure.ViewModel.Popups%Pokno.Infrastructure.ViewModel.Popups  c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity A    ;Pokno.Infrastructure.View.Popups.BankAccountDetailPopUpView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Bvm3clr-namespace:Pokno.Infrastructure.ViewModel.Popups     ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     -     �Name$  childWindow��$	��290��$	��400�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=�$��3,25,3,3q�
���  �� � DataContext K   EPokno.Infrastructure.ViewModel.Popups.BankAccountDetailPopUpViewModel  .��� $��10q�.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger  .  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *SetPopUpCommand+   CommandParameter �� 	 �� ElementName$	 childWindow��
 �� Mode$
 OneWay=� � RowDefinitions �� $
��Auto ��� $
��Auto �.+��� $��0��$��0,10,0,0q�
�������$��1q�
���iii� �� CornerRadius$ 
15,15,0,15��._��� $��20q�
������� �� Padding$ 10q�$��0q�$ 8��
�������._��� .+��� 
�������$��0,0,0,0q�$��5,5,5,0q�
�������$��Stretch=�._��� $
��15,5q�$��Center=�$��13(�$
��Bold"�CHEQUE� $
��5,10q� � ColumnDefinitions �� $	��120 ���  �� $
��Auto ��� $
��auto ��� $
��auto �.+��� $
��Bold"�$��0��$��0��Bank:��  �� SelectedValuePath$ Id��$
��Left=�$��1��$��0��$	��170��$��0,3,0,0q�$��23������ *Banks+$
 TwoWay=� �� SelectedValue �� *Id+���� .R���  �� Orientation$ 
Horizontal=�.+��� $��Verdana)����	#FF413E3E���� *Name+�� $
��Bold"�$��0��$��1��$��0,3,0,0q�Cheque No.:�� $��0,3,0,0q�$��1��$��1��$	��170��$
��Left=����� *Cheque.ChequeNumber+$
 TwoWay=��� $
��Bold"�$��0��$��2��$��0,3,0,0q�Account No.:�� $��0,3,0,0q�$��1��$��2��$	��170��$
��Left=����� *Cheque.AccountNumber+$
 TwoWay=��� $��Bottom=�$��Right=�
�������$��Italic$�$��12(�$
��Bold"�$��2��$��2������ *RecordCount+$
 TwoWay=��� $��0,3,79,0q�$��1��$��Cancel��$��75��$��Right=����� *CancelCommand+�� $��0,2,0,0q�$��1��$��OK��$��75��$��Right=����� *	OkCommand+