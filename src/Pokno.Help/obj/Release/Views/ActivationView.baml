   M S B A M L   `   `   `  ���� O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.InfrastructurePokno.Infrastructure.Converters   
Pokno.Help%   Pokno.Help.Views.ActivationView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     a	converterKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.Infrastructure       � 	Resources  9   3Pokno.Infrastructure.Converters.VisibilityConverter   VisibilityConverter��%   &	          .���� $��Century Gothic)�.��� $
��10,0q� � ColumnDefinitions �� $��* ��� $��2* �.+��� $��0,0,10,0q�����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FFf2fafd�� � Offset$
 0.85Q�� $ 	#FFe4f6fa��$ 1Q�� $ 	#FFe7f4fc��$	 0.3Q�� $ 	#FFa9cde7��$ 0Q�._��� $��
20,20,20,0q�y��� *IsEvaluationCopy+ �� 	Converter# [  .+��� .+��� $��0,0,0,3q�$
��Bold"�
�������$��15(�$
��Wrap=����� *EvaluationStatus+�� 
�������$��1q�._�� $��25�����	#FFE21B48���	#FFFDFCFC���	#FFFDFCFC � Maximum �� *MaxUsageDays+ � Value �� *RemainingUsageDays+� $��1��$��2��	 � RowDefinitions	 �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $��0,0,0,10q�$��0��$��1��
�������$��0,0,0,1q�._��� 
 �� Orientation$
 
Horizontal=�.+��� $��32(�
�������store�� $��0,0,10,0q�$��32(�
���  ��pro�� 
�������$��32(�	License�� $��0,0,0,15q�$��1��$��1��$
��Bold"�$��16(�$
��Wrap=�!Thank you for choosing storepro�� $��0,0,0,30q�$��3��$��Enter License��$
��Bold"�$��14(�.���� $��10q�.+��� $
��Wrap=�$��Normal"�$��12(�vtIf you have your Activation Key for storepro, click the 'Activate' button below to enter it and unlock your software�� $��0,10,5,0q�$��0��$��Normal"�$��12(�
User Key� $��0,0,0,5q�$��1�� �� $��* ��� $
��auto �.+��� $��0,0,1,0q�$��0�� �� 
IsReadOnly . $��Stretch=� �� TextWrapping$
 Wrap=�$��Normal"�$��12(����� *Key+�� $��1�� � ToolTip$
 Copy��$��Normal"�$
��Left=�$��12(����� *CopyCommand+.���� $��0��$��15������ *	CopyImage+�� $��1��$��Normal"�$��12(�Product Key�� $��1��$��1��$��40��$
 Wrap=�$��Normal"�$��12(����� *	License+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� $��0,3,0,0q�$��2��$��1��$��Activate��$	��180��$��Normal"�$
��Left=�$��12(����� *ActivateCommand+�� $��0,0,0,30q�$��2��.+��� $��0,0,0,5q�$
��Wrap=����� *ContinueEvaluationDescription+���� *%#ContinueEvaluationDescriptionColour+�� $��Continue Evaluation��$	��180��$
��Left=����� *ContinueEvaluationCommand+�� $��0,0,0,30q�$��4��.+��� $��0,0,0,5q�$
��Wrap=�97To purchase storepro, click the 'Purchase' button below�� $��Purchase��$	��180��$
��Left=����� *PurchaseCommand+�� $��0,0,0,30q�$��5��.+��� $��0,0,0,5q�$
��Wrap=�1/To exit storepro, click the 'Exit' button below�� $
��Exit��$	��180��$
��Left=����� *ExitApplicationCommand+