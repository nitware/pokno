   M S B A M L   `   `   `  ����  Pokno.Settings1    +Pokno.Settings.Views.DatabaseManagementView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      � ���	#FF93AACF.+�5   
   �   � ColumnDefinitions  5      �� 5      �� 5       � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5      �� $��0��6   $��0��6"    �� CornerRadius$ 25��62   ._�5      �� .+�5      �� $��
15,15,10,0q�6   $ 25��61   ._�5      �� $��	0,15,0,10q�6%   .+�5      �� $��0,0,0,8q�6%   
�������$��0,0,0,1q�6O   ._�5   "   �� $
��Wrap=�6,   $
��Bold"�6@   
�������$��20(�6j   DATABASE MAINTENANCE6�   5      �� 5!      
�������$
��Wrap=�6@   ��You can effectively manage your store database from here. You are advised to periodically backup your store database, and keep it safely outside the store or shop. The following can be done here:6  �� 5"      $��20,5,0,0q�6(   
�������$
��Wrap=�6R   1. Backup Database6z   �� 5#      $��20,0,0,0q�6(   
�������$
��Wrap=�6R   2. Restore Database6{   �� 5$      $��20,0,0,0q�6(   
�������$
��Wrap=�6R   3. Compact or Shrink database6�   5%      5'      5=      5>      �� 5A      $��	0,10,0,10q�6   $��1��6(   $��0��65   $ 25��6E   ._�5B      �� .+�5I      �� $��Stretch=�6T   {�6%   �� *CanBackupDb+ �� Mode$ TwoWay=�.��5J      �� $
��15,0q�6   $��Backup��6-   
�������$��16(�6U   .��5K      �� $��15q�6)   .+�5L   "   �� $��0,0,0,10q�6,   $��Normal"�6>   $
��Wrap=�6R   $��13(�6f   " Select backup destination folder6�   � 5N   "     5O   &   �� 5P   *   $��* �6;   �� 5Q   *   $
��auto �6;   .+�5T   &   �� {�.   �� TextWrapping$
 Wrap=�6�   $��Normal"�6�   $��13(�6�   ��6.   �� *BackupFolderPath+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5U   &   $��1��6-   $��Normal"�6i   $��13(�6}   ��6=   �� *SelectBackupFileCommand+.��6�   ...6�   5V   #   �� 5^   "   $��0,1,0,0q�6)   $��Normal"�6d   $��13(�6x   $
��Left=�6�   ��6:   �� *BackupDatabaseCommand+.��6�   Backup Database6�   5_      5`      5a      5e      5f      �� 5j      $��0��6   $��1��6"   ._�5k      �� .+�5q      �� $��Stretch=�6U   {�6%   �� *CanCompactDb+$ TwoWay=�.��5r      �� $��15q�6#   $��Compact or Shrink��6/   
�������$��16(�6b   .��5s      �� $��15q�6)   .+�5t   "   �� .+�5v   &   ��  �� Orientation$ 
Horizontal=�61   .+�5w   *   �� $��Normal"�64   $��13(�6H   $
��Left=�6V   Original File Size:6�   �� 5x   *   $��10,0,0,0q�64   $��13(�6h   $
��Bold"�6v   ��6F   �� *DatabaseFileSize+6v   5y   '   �� 5{   &   $ 
Horizontal=�61   .+�5|   *   �� $��Normal"�64   $��13(�6H   $
��Left=�6V   Shrinked File Size:6�   �� 5}   *   $��10,0,0,0q�64   $��13(�6h   $
��Bold"�6v   ��6F   �� *ShrinkedFileSize+6v   5~   '   �� 5�   &   $ 
Horizontal=�61   .+�5�   *   �� $��Normal"�64   $��13(�6H   $
��Left=�6V   Recorvered File Size:6�   �� 5�   *   $��10,0,0,0q�64   $��13(�6j   $
��Bold"�6x   ��6F   �� *RecorveredFileSize+6x   5�   '   5�   #   �� 5�   "   $��0,15,0,0q�6)   $��Normal"�6e   $��13(�6y   $
��Left=�6�   ��6;   �� *ShrinkDatabaseCommand+.��6�   Shrink Database6�   5�      5�      5�      5�      5�      �� 5�      $��	0,10,0,10q�6   $��1��6(   $��1��65   ._�5�      �� .+�5�      �� $��Stretch=�6U   {�6%   �� *CanRestoreDb+$ TwoWay=�.��5�      �� $
��15,0q�6   $��Restore��6-   
�������$��16(�6V   .��5�      �� $��15q�6)   .+�5�   "   �� $��0,0,0,10q�6,   $��Normal"�6>   $
��Wrap=�6R   $��13(�6f   -+Select the backed up file from its location6�   � 5�   &     5�   *   �� 5�   .   $��* �6?   �� 5�   .   $
��auto �6?   .+�5�   *   �� {�.  $
 Wrap=�6�   $��Normal"�6�   $��13(�6�   ��62   �� *BackedUpFilePath+$ PropertyChanged=�6�   �� 5�   *   $��1��61   $��Normal"�6o   $��13(�6�   ��6A   �� *SelectBackedUpFileCommand+.��6�   ...6�   5�   '   �� 5�   "   $��0,1,0,0q�6)   $��Normal"�6e   $��13(�6y   $
��Left=�6�   ��6:   �� *RestoreDatabaseCommand+.��6�   Restore Database6�   5�      5�      5�      5�      5�      5�      5�      5�      