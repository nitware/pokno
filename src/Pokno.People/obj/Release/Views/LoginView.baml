   M S B A M L   `   `   `  ���� O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.InfrastructurePokno.Infrastructure.Converters   Pokno.People"   Pokno.People.Views.LoginView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     a	converterKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.Infrastructure     Z VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI    � 	Resources  8   2Pokno.Infrastructure.Converters.EnabilityConverter   EnabilityConverter��%   &	          .���� $��Center=�$��Center=�.��� -    �Name$ 
LayoutRoot��$��Stretch=� � RowDefinitions �� $	��30* ��� $
��auto ��� $
��auto ��� $	��50* � � ColumnDefinitions �� $	��10* ��� $	��50* ��� $	��50* ��� $��* �.+��� $��2��$��0��$��2��$��Center=�.+��� .+��� $��0,0,0,15q�
�������$��0,0,0,2q�._���  �� Orientation$ 
Horizontal=�.+��� $��2,2,2,10q�$��0��$	��120������ *ProductLogo+� $��Center=�.+��� $��2q�$��80������ *Image1+�� $��2q�$��80������ *Image2+�� $��2q�$��80������ *Image3+�� $��2q�$��80������ *Image4+�� $��2q�$��80������ *Image5+�� $��2q�$��80������ *Image6+�� $��2q�$��80������ *Image7+�� $��2q�$��80������ *Image8+�� $��2q�$��80������ *Image9+�� $��2q�$��80������ *	Image10+�� $��2q�$��80������ *	Image11+�� $��2q�$��80������ *	Image12+�� $��2q�$��80������ *	Image13+�� $��2q�$��80������ *	Image14+�� $��2q�$��80������ *	Image15+�� $��2q�$��80������ *	Image16+�� $��2q�$��80������ *	Image17+�� $��2q�$��80������ *	Image18+�� $��2q�$��80������ *	Image19+�� $��2q�$��80������ *	Image20+�� $��0,0,0,0q�$��0��$��2��$��4��$��Stretch=�$
��Left=�._��� $��0,0,0,0q�
�������
�������$��1q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ DimGray��._�� $��10q� �� $
��auto ���  �� $
��auto ��� $
��auto ��� $��* ��� $
��auto �.+��� $��2��.+��� $
��Bold"�$��25(�$��Center=� �� TextAlignment$ Center=�$��Center=�$��5,0,0,10q�Login�� $ Vertical=�$��2��$��2��$��Center=�.+��� $
��Wrap=�$��0,0,0,15q�$��15(�$��Century Gothic)�_]Please enter your Username and Password. In the form FirstName.Surname. For example, Eve.Adam�� $��2q�
�������._�� $��10q�$��Center=� �� $
��auto ���  �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� 
�������$
��Bold"�$��Center=�$��Right=�$��5q�$��0��$��1��	Username:�� 
�������$
��Bold"�$��Center=�$��Right=�$��5q�$��0��$��2��	Password:�� -   $��txtUserName��$��5q�$��1��$��1������ *
UserName+ �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=�G� -   $��
pbPassword��$��5q�$��1��$��2���� -   $��btnLogin��
 �� 	IsDefault
 . $��5,5,0,5q�$��1��$��3��$
��Left=�$��28��$	��Top=� � Cursor$
 Hand������ *LoginCommand+.��Login=  7FirstFloor.ModernUI.Windows.Controls.ModernProgressRing  $	��0,5q�$��60��$��60��   IsActive �� *IsProcessing+���� *SelectedItem.Tag+ �� ElementName$ CmbRingStyle���� $��2��$��3��.+��� $��15(�$
��Bold"�$��Center=�$ Center=�$��Center=�$��5,0,0,10q�" ... track stocks ... track sales