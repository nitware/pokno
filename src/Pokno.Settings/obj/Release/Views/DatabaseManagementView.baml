   M S B A M L   `   `   `  ����   Pokno.Settings1    +Pokno.Settings.Views.DatabaseManagementView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .��� ���	#FF93AACF.+��   � ColumnDefinitions  �� ��  � RowDefinitions �� $
��auto ��� $
��auto �.+��� $��0��$��0�� �� CornerRadius$ 25��._��� .+��� $��
15,15,10,0q�$ 25��._��� $��	0,15,0,10q�.+��� $��0,0,0,8q�
�������$��0,0,0,1q�._��� $
��Wrap=�$
��Bold"�
�������$��20(�DATABASE MAINTENANCE�� 
�������$
��Wrap=���You can effectively manage your store database from here. You are advised to periodically backup your store database, and keep it safely outside the store or shop. The following can be done here:�� $��20,5,0,0q�
�������$
��Wrap=�1. Backup Database�� $��20,0,0,0q�
�������$
��Wrap=�2. Restore Database�� $��20,0,0,0q�
�������$
��Wrap=�3. Compact or Shrink database�� $��	0,10,0,10q�$��1��$��0��$ 25��._��� .+��� $��Stretch=�{��� *CanBackupDb+ �� Mode$ TwoWay=�.���� $
��15,0q�$��Backup��
�������$��16(�.���� $��15q�.+��� $��0,0,0,10q�$��Normal"�$
��Wrap=�$��13(�" Select backup destination folder�   �� $��* ��� $
��auto �.+��� {�.   �� TextWrapping$
 Wrap=�$��Normal"�$��13(����� *BackupFolderPath+ �� UpdateSourceTrigger$ PropertyChanged=��� $��1��$��Normal"�$��13(����� *SelectBackupFileCommand+.��...�� $��0,1,0,0q�$��Normal"�$��13(�$
��Left=����� *BackupDatabaseCommand+.��Backup Database�� $��0��$��1��._��� .+��� $��Stretch=�{��� *CanCompactDb+$ TwoWay=�.���� $��15q�$��Compact or Shrink��
�������$��16(�.���� $��15q�.+��� .+���  �� Orientation$ 
Horizontal=�.+��� $��Normal"�$��13(�$
��Left=�Original File Size:�� $��10,0,0,0q�$��13(�$
��Bold"����� *DatabaseFileSize+�� $ 
Horizontal=�.+��� $��Normal"�$��13(�$
��Left=�Shrinked File Size:�� $��10,0,0,0q�$��13(�$
��Bold"����� *ShrinkedFileSize+�� $ 
Horizontal=�.+��� $��Normal"�$��13(�$
��Left=�Recorvered File Size:�� $��10,0,0,0q�$��13(�$
��Bold"����� *RecorveredFileSize+�� $��0,15,0,0q�$��Normal"�$��13(�$
��Left=����� *ShrinkDatabaseCommand+.��Shrink Database�� $��	0,10,0,10q�$��1��$��1��._��� .+��� $��Stretch=�{��� *CanRestoreDb+$ TwoWay=�.���� $
��15,0q�$��Restore��
�������$��16(�.���� $��15q�.+��� $��0,0,0,10q�$��Normal"�$
��Wrap=�$��13(�-+Select the backed up file from its location�   �� $��* ��� $
��auto �.+��� {�.  $
 Wrap=�$��Normal"�$��13(����� *BackedUpFilePath+$ PropertyChanged=��� $��1��$��Normal"�$��13(����� *SelectBackedUpFileCommand+.��...�� $��0,1,0,0q�$��Normal"�$��13(�$
��Left=����� *RestoreDatabaseCommand+.��Restore Database