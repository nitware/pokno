   M S B A M L   `   `   `  ���� O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.InfrastructurePokno.Infrastructure.Converters   Pokno.Shell   Pokno.Shell.Shell   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Z VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI  P LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8+regionshttp://www.codeplex.com/prism  [	converterKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.Infrastructure  c	 _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity 	 :d2http://schemas.microsoft.com/expression/blend/2008 	   � Title$   ��7  1FirstFloor.ModernUI.Windows.Controls.ModernWindow   LogoData �	   BlankWindow#��[   � WindowStartupLocation$ CenterScreen=� � WindowState$ 	Maximized=� � 	Resources 9   3Pokno.Infrastructure.Converters.VisibilityConverter  VisibilityConverter  Link �� 
TargetType �� Property �� Value �� 
TargetType	 �� Triggers
 P� Property P� Value  RoundCorner �Name ��Name �� CornerRadius 
� GradientOrigin �� RelativeTransform �� CenterX �� CenterY �� ScaleX �� ScaleY T� X T� Y � Offset � Color �� 
TargetName  ButtonStyle1'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup  Name   States   System.Windows.VisualState  Name   
Storyboard g� 	BeginTime  �� 
TargetName! �� TargetProperty9  3System.Windows.Media.Animation.EasingDoubleKeyFrame" O� KeyTime# O� Value$ R� KeyTime% R� Value& g� Duration	' W� To( � RowDefinitions) � ColumnDefinitions* A�Name+ �� EndPoint, �� 
StartPoint- ��Name  HelpButtonStyle. J� Opacity/ ��Name0 J� IsHitTestVisible1 �� RadiusY2 �� RadiusX��%�  &	       &	      &	 �    &	 �    &	       �� " ��.���  � ��$ Center=���  � ��$ Center=���  �@�Cursor$
 Hand����  � ��$ Verdana)���  � ��
 �������  � ��$ 14(���  � ��
 ���� ��  � �� �� " ��.R��� $��	Underline{�#��z��#��z��	 P� 
 � �� . . ���  � ��
 �  ��P� 
 �@J�IsMouseOver . . ���  � ��
 �������  � ��$
 Bold"�P� 
 � {� .  . ���  � ��
 �������  �@�Cursor$ Arrow���� " ��.���  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��.R�� $
 grid��.+��� $ border��$ 55��
�������$��2q���
� $ 0.496,1.052&� V� .~��� $	 0.5Q�$	 0.5Q�$	 1.5Q�$	 1.5Q�T� $
 0.02Q�$	 0.3Q�.��� $ 1Q�$ 	#00000000��� $	 0.3Q�$ 	#FFFFFFFF��._��� $��Center=�$��Center=�$��Century Gothic)�$��14(�$
��Bold"�	 P� 
 � �� . . ��� $ border�� � �� 
� $ 0.496,1.052&� V� .~��� $	 0.5Q�$	 0.5Q�$	 1.5Q�$	 1.5Q�T� $
 0.02Q�$	 0.3Q�.��� $ 	#00000000��$ 1Q�� $ 	#FF303030��$	 0.3Q�P� 
 �@J�IsMouseOver . . ��� $ border�� � ��
 �  ��P� 
 � {� .  . ��� $
 grid�� �@J�Opacity$
 0.25Q��� " ��.���  � �� �� " ��.R�� $ grid1��   $ CommonStates��.   $ Normal��  $ 	MouseOver��. �� .��U� $ 00:00:00X�$  ellipse1��$! (UIElement.Opacity)�.\�  $" 00:00:00.2000000��$	# 0.1Q�  $ Pressed��. �� .��U� $ 00:00:00X�$  ellipse��$! (Shape.StrokeThickness)�.\�  $" 00:00:00.1000000��$# 6Q�T� $ 00:00:00X�$  ellipse1��$! (FrameworkElement.Margin)�..�i� $$ 00:00:00.1000000��% u�2,2,3,4q�U� $ 00:00:00X�$  ellipse1��$! (UIElement.Opacity)�.\�  $" 00:00:00.1000000��$	# 0.1Q�  $ Disabled��. �� .��W� $& 0D�$' 35X�$! (Shape.StrokeThickness)�$  ellipse��W� $& 0D�$	' 0.5X�$! (UIElement.Opacity)�$  contentPresenter��W� $& 0D�$	' 0.7X�$! (UIElement.Opacity)�$
  grid��W� $& 0D�$	' 0.7X�$! (UIElement.Opacity)�$  ellipse2��W� $& 0D�$	' 0.7X�$! (UIElement.Opacity)�$  grid1��  $ FocusStates��.   $ Focused��  $ 	Unfocused��( �� $��0.08* ��� $��0.84* ��� $��0.08* �) �� $��0.08* ��� $��0.84* ��� $��0.08* �.+�A� $* ellipse2��$��3��$��3��$��1,1,1,1q����	#FF8C8C8C���� $+ 0.5,1&�$, 0.5,0&�.��� $ 	#FF343434��$
 0.63Q�� $ 	#FFFFFFFF��$ 0.158Q�� $ 	#FFB3B3B3��$ 1Q�� $ 	#FFE0E0E0��$ 0Q�� $
 grid��$��1��$��1��$��1��$��1��( �� $��0.033* ��� $
��0.6* ��� $��0.367* �) �� $��0.114* ��� $��0.772* ��� $��0.114* �.+�A� $* ellipse��$��2��$��Stretch=�$��3��$��3��#��z������ $+ 0.5,1&�$, 0.5,0&�.��� $ 	#FF6A6A6A��$ 0Q�� $ 	#FFFFFFFF��$ 0.482Q�� $ 	#FF515151��$ 1Q��� $- contentPresenter��$��Center=�$��Center=�$��3��$��3��A� $* ellipse1�����	#FF000000$��0��$��Stretch=�$��0,0,0,0q�$��Stretch=�$
��Auto��$
��Auto��$��1��$��1������ $+ 0.5,1&�$, 0.5,0&�.��� $ 	#D8FFFFFF��$ 0Q�� $ 	#15FFFFFF��$ 0.845Q���  � ��$ 11(���  � ��$
 Bold"���  �@�Cursor$
 Hand���� " d�.���  � �� Z� ��  � ��
 �������  � ��$	 5,0q���  � ��$ 11(���  � ��$ Arial)���  � ��$
 Bold"���  �@�Cursor$
 Hand����  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " d�.R��    $ CommonStates��.   $ Normal��  $ 	MouseOver��. �� .��W� $& 0D�$' 1X�$! (UIElement.Opacity)�$  MouseOverBackground��  $ Pressed��. �� .��W� $& 0D�$' 1X�$! (UIElement.Opacity)�$  PressedBackground��  $ Disabled��. �� .��W� $& 0D�$	' .55X�$! Opacity�$  DisabledVisualElement��  $ FocusStates��.   $ Focused��. �� .��W� $& 0D�$' 1X�$! Opacity�$  FocusVisualElement��  $ 	Unfocused��  $ CheckStates��.   $ Indeterminate��  $ Checked��. �� .��W� $& 0D�$' 1X�$! (UIElement.Opacity)�$  CheckedBackground��  $ 	Unchecked��.+��� $ BaseBackground��
�������$��0,0,1,0q�$ 0���� $ MouseOverBackground�����	#FFC7E3FB$ 0��$. 0Q��� $ PressedBackground��$ 0��$. 0Q��� $ CheckedBackground��
������ #��z��$ 0��$. 0Q�� #��z��.+��� $- ContentPresenter��#��z��#��z��$��Center=�#��z��#��z���� $/ DisabledVisualElement�����	#FFFFFFFF0 .  $. 0Q�$1 3��$2 3���� $/ FocusVisualElement��0 .  $��1q�$. 0Q�$1 2��$2 2��$��1����Z� .���� $��Century Gothic)�.��� ( �� $
��auto ��� $��50 ��� $��* ��� $
��auto �.+��� $��0��$��15,0,0,3q�$��Bottom=�._�� $��Bottom=�) �� $��* ��� $
��auto �.+��� $��0��3 �� Orientation$3 
Horizontal=�$��Bottom=�.+��� $��0,0,2,0q�$��70��$
��Left=����� *	StoreLogo+�� $��Bottom=�$
��Wrap=�$��38(����� *	StoreName+�� $��1��$3 
Horizontal=�$��Bottom=�.+��� $��Right=�$��Bottom=�{��� *IsEsnecilValid+.+��� $��0,0,10,3q�$��Right=�$��25(�$��Bottom=����� *ActivationStatus+���� *Colour+�� $��0,0,10,0q�$3 
Horizontal=�.+�	� -   $��rbHelp��$��Bottom=�4 	� 	GroupName$4 MainNavigation��#��[ 4  .System.Windows.Automation.AutomationProperties5   AutomationId$5 HelpRadioButton������ *HelpCommand+.��Help	� $��Bottom=�$4 MainNavigation��#��[ $5 HelpRadioButton������ *SettingsCommand+.��
Settings	� -   $��
rbPurchase��$��Bottom=�$4 MainNavigation��#��[ $5 HelpRadioButton������ *PurchaseCommand+.��
Purchase	� $��Bottom=�$4 MainNavigation��#��[ $5 HelpRadioButton������ *ActivateCommand+.��	License	� -   $��
rbHomePage��$��Bottom=�$4 MainNavigation��#��[ $5 HelpRadioButton������ *HomePageCommand+.��	Home Page	� -   $��	rbSupport��$��Bottom=�$4 MainNavigation��#��[ $5 HelpRadioButton������ *SupportCommand+.��	Support	� $��Bottom=�$4 MainNavigation��#��[ $5 HelpRadioButton������ *AboutCommand+.��About�� -   $��imgProductLogo��$��0,0,15,0q�$	��120��$��Right=��� $��1��$��0,0,0,10q�._�� ) �� $��* ��� $
��auto �.+��� $��0��$��2��$ 20������ $+ 0.5,1&�$, 0.5,0&�.��� $ 	#FFC3BCAE��$ 0Q�� $ 	#FF13B5F7��$ 0.046Q�� $
 Gray��$ 0.452Q�� $
 Gray��$ 0.461Q�� $
 Gray��$ 0.724Q�� $ 	#FFA1DFF9��$ 1Q��� $��20,0,0,0q�$��0��$
��Left=�$��Center=�.+��� !  Prism.Regions.RegionManager6   
RegionName$6 SubMenuRegion��$��Center=��� $��1��$��0,0,15,7q�$3 
Horizontal=�$��Right=�.+��� $��0,1,3,1q�$��Center=�$
��Bold"�$��Century Gothic)�$��17(�
�������
Welcome,�� $��0,1,5,1q�$��Center=�$��Verdana)�$��14(�
����������� *LoggedInUser.Name+�� $��0,1,1,1q�$��Italic$�$��Center=�$��Verdana)�$��14(�
�������(�� $��0,1,1,1q�$��Center=�$��Italic$�$��Verdana)�$��14(�
����������� *LoggedInUser.Role.Name+�� $��0,1,0,1q�$��Center=�$��Verdana)�$��14(�$��Italic$�
�������)�� $��30,0,0,0q�#��[ {��� *IsValidEsnecil+���� *LogOutLinkButtonCommand+���� *LoginStatus+� $��2��) �� $	��150 ��� $��* �.+��� $��0��$��0,0,5,0q�$ 5��
�������
�������$��1q�7 J� Effect7 3	  -System.Windows.Media.Effects.DropShadowEffect	  8 	  Color$8 DimGray��._�� $��10q�$��Center=�.+��� $��1��$3 Vertical=�.+��� $��0,10,0,0q�$��Century Gothic)�
���  ��$��0��$��Center=�$��Center=�$��	ExtraBold"�$��16(����� *
YouAreHere+�� $��	0,5,0,0.5q�$��Center=�$��90��#��[ $��Right=�$��90������ *StockCommand+��
� $ 0.5,0.5&� V� .~��� $	 0.5Q�$	 0.5Q�$ 0.865Q�$ 0.805Q��� 9 �� AngleX$9 0Q�: �� AngleY$: 0Q�; �� CenterX$	; 0.5Q�< �� CenterY$	< 0.5Q��� = �� Angle$= 135.194Q�> �� CenterX$	> 0.5Q�? �� CenterY$	? 0.5Q�T� $ 0.006Q�$ 0.124Q�.��� $ 	#FF6E6E6E��$ 1Q�� $ White��.���� $3 Vertical=�.+�� ( �� .+��� -   $��imgStock��$��0��$��55���� $��	0,5,0,0.5q�$��Center=�$��90��#��[ $��Right=�$��90������ *PaymentCommand+��
� $ 0.5,0.5&� V� .~��� $	 0.5Q�$	 0.5Q�$ 0.865Q�$ 0.805Q��� $9 0Q�$: 0Q�$	; 0.5Q�$	< 0.5Q��� $= 135.194Q�$	> 0.5Q�$	? 0.5Q�T� $ 0.006Q�$ 0.124Q�.��� $ 	#FF6E6E6E��$ 1Q�� $ White��.���� $3 Vertical=�.+�� ( �� .+��� -   $��
imgPayment��$��0��$��57���� $��0��$��14(�
�������$
��Bold"�$��Center=�$��Center=�	Payment�� $��	0,5,0,0.5q�$��Center=�$��90��#��[ $��Right=�$��90������ *PeopleCommand+��
� $ 0.5,0.5&� V� .~��� $	 0.5Q�$	 0.5Q�$ 0.865Q�$ 0.805Q��� $9 0Q�$: 0Q�$	; 0.5Q�$	< 0.5Q��� $= 135.194Q�$	> 0.5Q�$	? 0.5Q�T� $ 0.006Q�$ 0.124Q�.��� $ 	#FF6E6E6E��$ 1Q�� $ White��.���� $3 Vertical=�.+�� ( �� .+��� -   $��	imgPeople��$��0��$��65���� $��0��$��14(�
�������$
��Bold"�$��Center=�$��Center=�People�� $��	0,5,0,0.5q�$��Center=�$��90��#��[ $��Right=�$��90������ *AccountCommand+��
� $ 0.5,0.5&� V� .~��� $	 0.5Q�$	 0.5Q�$ 0.865Q�$ 0.805Q��� $9 0Q�$: 0Q�$	; 0.5Q�$	< 0.5Q��� $= 135.194Q�$	> 0.5Q�$	? 0.5Q�T� $ 0.006Q�$ 0.124Q�.��� $ 	#FF6E6E6E��$ 1Q�� $ White��.���� $3 Vertical=�.+�� ( �� .+��� -	   $��
imgAccount��$��0��$��65���� $��0��$��14(�
�������$
��Bold"�$��Center=�$��Center=�	Account�� $��0,5,0,5q�$��Center=�$��90��#��[ $��Right=�$��90������ *ReportCommand+��
� $ 0.5,0.5&� V� .~��� $	 0.5Q�$	 0.5Q�$ 0.865Q�$ 0.805Q��� $9 0Q�$: 0Q�$	; 0.5Q�$	< 0.5Q��� $= 135.194Q�$	> 0.5Q�$	? 0.5Q�T� $ 0.006Q�$ 0.124Q�.��� $ 	#FF6E6E6E��$ 1Q�� $ White��.���� $3 Vertical=�.+�� ( �� .+��� -
   $��	imgReport��$��0��$��60���� $��0��$��14(�$
��Bold"�$��Center=�$��Center=�Report�� $��	0,-1,-5,0q�$��0��
�������y��� *HideMainMenu+@ �� 	Converter#@ [ 7 	  $8 White���� $��1��._��� $��5,0,0,0q�$��Stretch=�$��Stretch=�$6 ContentRegion��