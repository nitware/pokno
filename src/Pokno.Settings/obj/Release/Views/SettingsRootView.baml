   M S B A M L   `   `   `  ���� O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.InfrastructurePokno.Infrastructure.Converters  c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity I EPokno.Settings, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Pokno.Settings.ViewModelsPokno.Settings.ViewModels +   %Pokno.Settings.Views.SettingsRootView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     P LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8+regionshttp://www.codeplex.com/prism  [	converterKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.Infrastructure  XiPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity  0vm'clr-namespace:Pokno.Settings.ViewModels  -     �Name$  childWindow�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=�$��2,30,2,2q����	#FF93AACF$	��620��$	��700��|�.   � Topmost . ��.   � DataContext 5  /Pokno.Settings.ViewModels.SettingsRootViewModel  .��� -    �Name$ 
LayoutRoot��$��5,0,5,5q�.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger  .  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction  	   Command	 �� *SetPopUpCommand+
   CommandParameter
 ��  �� ElementName$ childWindow�� �� Mode$ OneWay=� � RowDefinitions �� $
��auto ��� $
��auto ��� $��* �.+��� $��0,5,0,0q�._��� $
��Left=�$��18(�
SETTINGS�� $��-2,0,0,0q�$��1�� �� Padding$ 0,0,0,2q����	#FF6F8CB9$��0,0,0,1q�._�� $��0��.+��� $��70��$��75��._�	� -   $��rbBasicSettings�� d� 	IsChecked$
 TrueY� 	� 	GroupName$ PaymentReportMenu��   ReportButtonStyle#��[  ���� *BasicSettingsCommand+.��� $��Stretch=�$��Stretch=� �� $
��auto ��� $
��auto ��� $��* � � ColumnDefinitions �� �� .+��� $��0��$��2��$��15(�$
��Bold"�$
��Left=�$
��Wrap=�Basic Setting�� $��70��$��75��._�	� -   $��rbSetDb��$ PaymentReportMenu��#��[  ���� *SetDbCommand+.��� $��Stretch=�$��Stretch=� �� $
��auto ��� $
��auto ��� $��* � �� �� .+��� $��0��$��2��$��15(�$
��Bold"�$
��Left=�$
��Wrap=�Set DB�� $��70��$��75��._�	� -   $��rbSetupShopDetail��$ PaymentReportMenu��#��[  ���� *ShopDetailCommand+.��� $��Stretch=�$��Stretch=� �� $
��auto ��� $
��auto ��� $��* � �� �� .+��� $��0��$��2��$��15(�$
��Bold"�$
��Left=�$
��Wrap=�Setup Store Detail�� $��70��$��75��._�	� -   $��rbUploadStoreLogo��$ PaymentReportMenu��#��[  ���� *StoreLogoCommand+.��� $��Stretch=�$��Stretch=� �� $
��auto ��� $
��auto ��� $��* � �� �� .+��� $��0��$��2��$��16(�$
��Bold"�$
��Left=�$
��Wrap=�Upload Store Logo�� $��70��$��75��._�	� -   $��rbSetupCustomerLoyalty��$ PaymentReportMenu��#��[  ���� *CustomerLoyaltyCommand+.��� $��Stretch=�$��Stretch=� �� $
��auto ��� $
��auto ��� $��* � �� �� .+��� $��0��$��2��$��15(�$
��Bold"�$
��Left=�$
��Wrap=�Customer Loyalty�� $��70��$��85��._�	� -   $��rbMaintainDb��$ PaymentReportMenu��#��[  ���� *DbMaintenanceCommand+.��� $��Stretch=�$��Stretch=� �� $
��auto ��� $
��auto ��� $��* � �� �� .+��� $��0��$��2��$��15(�$
��Bold"�$
��Left=�$
��Wrap=�DB Maintenance�� $��2��$��1,3,0,0q�._��  �� $��* ��� $
��auto �.+��� $��0��._��� -	    ��Name$ ccSettingsRegion��!  Prism.Regions.RegionManager   
RegionName$ SettingsRegion������  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FFf2fafd�� � Offset$
 0.85Q�� $ 	#FFe4f6fa��$ 1Q�� $ 	#FFe7f4fc��$	 0.3Q�� $ 	#FFa9cde7��$ 0Q��� $��0,3,0,5q�$��1��$��16(�$��Right=����� *	OkCommand+.��Close