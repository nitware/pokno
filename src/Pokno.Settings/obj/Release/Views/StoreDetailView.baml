   M S B A M L   `   `   `  ����   Pokno.Settings*    $Pokno.Settings.Views.StoreDetailView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .��� ���	#FF93AACF.+��   � RowDefinitions  �� $
��Auto ��� $��* ��� $��* �.+��� 
�������$��0��._��� $
��25,3q�._��� $��Store Details��
�������$��22(�.���  � ColumnDefinitions �� $��* ��� $
��auto �.+�� $��12q� �� $	��100 ��� $��* �  �� $
��Auto ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $
��Bold"�$��14(�$��0��$��0��Name:�� $��1��$��0��$��14(����� *
Store.Name+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� $
��Bold"�$��0��$��14(�$��1��$��0,3,0,0q�
Address:�� $��1��$��1��$��14(�$��0,3,0,0q�$��40�� �� TextWrapping$
 Wrap=� �� 	IsEnabled . ���� *Store.Address+$ TwoWay=�$ PropertyChanged=��� $
��Bold"�$��14(�$��0��$��2��$��0,3,0,0q�Description:�� $��1��$��2��$��14(�$��0,3,0,0q�$��40��$
 Wrap=� . ���� *Store.Description+$ TwoWay=�$ PropertyChanged=��� $
��Bold"�$��14(�$��0��$��3��$��0,3,0,0q�
Website:�� $��1��$��3��$��14(�$��0,3,0,0q�$
 Wrap=����� *Store.Website+$ TwoWay=�$ PropertyChanged=��� $
��Bold"�$��14(�$��0��$��4��$��0,3,0,0q�Email:�� $��1��$��4��$��14(�$��0,3,0,0q�$
 Wrap=����� *Store.Email+$ TwoWay=�$ PropertyChanged=��� $
��Bold"�$��14(�$��0��$��5��$��0,3,0,0q�Phone:�� $��1��$��5��$��14(�$��0,3,0,0q�$
 Wrap=����� *Store.Phone+$ TwoWay=�$ PropertyChanged=��� $
��Bold"�$��14(�$��0��$��7��$��0,3,0,0q�Disclaimer:�� $��1��$��7��$��14(�$��0,3,0,0q�$��70��$
 Wrap=� . ���� *Store.Disclaimer+$ TwoWay=�$ PropertyChanged=��� $��0,2,0,0q�$��8��$��1��$��Stretch=�._��� $��2��$��0,2,3,2q� �� Orientation$ 
Horizontal=�.+��� $
��Save������ *SaveCommand+