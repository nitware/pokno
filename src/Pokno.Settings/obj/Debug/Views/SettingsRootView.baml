   M S B A M L   `   `   `  ����O  KPokno.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulloKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.InfrastructurePokno.Infrastructure.Converters  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   	   I EPokno.Settings, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Pokno.Settings.ViewModelsPokno.Settings.ViewModels 5	   	   +   %Pokno.Settings.Views.SettingsRootView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   P LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8+regionshttp://www.codeplex.com/prism  5   	   [	converterKclr-namespace:Pokno.Infrastructure.Converters;assembly=Pokno.Infrastructure  5   	   XiPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity  5   	   0vm'clr-namespace:Pokno.Settings.ViewModels  5	   	   -   5          �Name$  childWindow��5   	    � 
ResizeMode$ NoResize=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	   $��2,30,2,2q�5   	   ���	#FF93AACF$	��620��5   	   $	��700��5   	   |�.   � Topmost . ��.   � DataContext 5      5  /Pokno.Settings.ViewModels.SettingsRootViewModel  5   
   .��5/      � -   5         �Name$ 
LayoutRoot��5/      $��5,0,5,5q�6   .  (System.Windows.Interactivity.Interaction   Triggers 50   
   /  )System.Windows.Interactivity.EventTrigger  51      .  (System.Windows.Interactivity.TriggerBase   Actions. 52      6  0System.Windows.Interactivity.InvokeCommandAction  	   Command	 6(   �� *SetPopUpCommand+
   CommandParameter
 6L   ��  �� ElementName$ childWindow�� �� Mode$ OneWay=�53       � RowDefinitions 56   
   �� 57      $
��auto �6   �� 58      $
��auto �6   �� 59      $��* �6   .+�5@   
   �� $��0,5,0,0q�6   ._�5A      �� $
��Left=�6   $��18(�63   
SETTINGS6K   5B      �� 5D   
   $��-2,0,0,0q�6   $��1��6#    �� Padding$ 0,0,0,2q�60   ���	#FF6F8CB9$��0,0,0,1q�6Z   ._�5E      � $��0��6   .+�5F      �� $��70��6   $��75��6%   ._�5G      	� -   5        $��rbBasicSettings��5G   "    d� 	IsChecked$
 TrueY�6b    	� 	GroupName$ PaymentReportMenu��6s      ReportButtonStyle#��[  6�   ��69   �� *BasicSettingsCommand+.��5H      � $��Stretch=�6   $��Stretch=�6=    5I      �� 5J   "   $
��auto �60   �� 5K   "   $
��auto �60   �� 5L   "   $��* �60    � ColumnDefinitions 5N      �� 5O   "   �� 5P   "   .+�5S      �� $��0��6(   $��2��65   $��15(�6I   $
��Bold"�6W   $
��Left=�6i   $
��Wrap=�6�   Basic Setting6�   5U      5V      5W      �� 5Y      $��70��6   $��75��6%   ._�5Z      	� -   5        $��rbSetDb��5Z   "   $ PaymentReportMenu��6R   #��[  6p   ��61   �� *SetDbCommand+.��5[      � $��Stretch=�6   $��Stretch=�6=    5\      �� 5]   "   $
��auto �60   �� 5^   "   $
��auto �60   �� 5_   "   $��* �60    5a      �� 5b   "   �� 5c   "   .+�5f      �� $��0��6(   $��2��65   $��15(�6I   $
��Bold"�6W   $
��Left=�6i   $
��Wrap=�6�   Set DB6�   5h      5i      5j      �� 5m      $��70��6   $��75��6%   ._�5n      	� -   5        $��rbSetupShopDetail��5n   "   $ PaymentReportMenu��6a   #��[  6   ��6;   �� *ShopDetailCommand+.��5o      � $��Stretch=�6   $��Stretch=�6=    5p      �� 5q   "   $
��auto �60   �� 5r   "   $
��auto �60   �� 5s   "   $��* �60    5u      �� 5v   "   �� 5w   "   .+�5z      �� $��0��6(   $��2��65   $��15(�6I   $
��Bold"�6W   $
��Left=�6i   $
��Wrap=�6�   Setup Store Detail6�   5|      5}      5~      �� 5�      $��70��6   $��75��6%   ._�5�      	� -   5        $��rbUploadStoreLogo��5�   "   $ PaymentReportMenu��6`   #��[  6~   ��6;   �� *StoreLogoCommand+.��5�      � $��Stretch=�6   $��Stretch=�6=    5�      �� 5�   "   $
��auto �60   �� 5�   "   $
��auto �60   �� 5�   "   $��* �60    5�      �� 5�   "   �� 5�   "   .+�5�      �� $��0��6(   $��2��65   $��16(�6I   $
��Bold"�6W   $
��Left=�6i   $
��Wrap=�6�   Upload Store Logo6�   5�      5�      5�      �� 5�      $��70��6   $��75��6%   ._�5�      	� -   5        $��rbSetupCustomerLoyalty��5�   "   $ PaymentReportMenu��6k   #��[  6�   ��6@   �� *CustomerLoyaltyCommand+.��5�      � $��Stretch=�6   $��Stretch=�6=    5�      �� 5�   "   $
��auto �60   �� 5�   "   $
��auto �60   �� 5�   "   $��* �60    5�      �� 5�   "   �� 5�   "   .+�5�      �� $��0��6(   $��2��65   $��15(�6I   $
��Bold"�6W   $
��Left=�6i   $
��Wrap=�6�   Customer Loyalty6�   5�      5�      5�      �� 5�      $��70��6   $��85��6%   ._�5�      	� -   5        $��rbMaintainDb��5�   "   $ PaymentReportMenu��6_   #��[  6}   ��66   �� *DbMaintenanceCommand+.��5�      � $��Stretch=�6   $��Stretch=�6=    5�      �� 5�   "   $
��auto �60   �� 5�   "   $
��auto �60   �� 5�   "   $��* �60    5�      �� 5�   "   �� 5�   "   .+�5�      �� $��0��6(   $��2��65   $��15(�6I   $
��Bold"�6W   $
��Left=�6i   $
��Wrap=�6�   DB Maintenance6�   5�      5�      5�      5�      5�      �� 5�   
   $��2��6   $��1,3,0,0q�6   ._�5�      �  5�      �� 5�      $��* �6$   �� 5�      $
��auto �6$   .+�5�      �� $��0��6   ._�5�      �� -	   5         ��Name$ ccSettingsRegion��5�   %   !  Prism.Regions.RegionManager   
RegionName$ SettingsRegion��6?   ��5�      �� 5�       �� EndPoint$ 0.5,1&�6.    �� 
StartPoint$ 0.5,0&�6?   .��5�      �  � Color$ 	#FFf2fafd��6+    � Offset$
 0.85Q�6=   � 5�      $ 	#FFe4f6fa��6+   $ 1Q�6=   � 5�      $ 	#FFe7f4fc��6+   $	 0.3Q�6=   � 5�      $ 	#FFa9cde7��6+   $ 0Q�6=   5�      5�      5�      �� 5�      $��0,3,0,5q�6   $��1��6*   $��16(�6U   $��Right=�6c   ��67   �� *	OkCommand+.��6   Close6�   5�      5�      5�      5�      