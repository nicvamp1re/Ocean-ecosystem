   M S B A M L   `   `   `  ����K  GWPfOceanFirstTry, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WPfOceanFirstTryWPfOceanFirstTry  5   	   "    WPfOceanFirstTry.OceanWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:WPfOceanFirstTry     5   	     � Title$  Ocean��5   	   $	��450��6   $	��800��6$   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��3* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��0.5* �6   �� 5      $��* �6   .+�5      �� -   5         ��Name$ IterationsTextBox��5      $	��100��61   $��1��6<   $��Stretch=�6L   $
��auto��6j   $
��auto��6x   $��30��6�   $	��150��6�   $��
0, 0, 0, 0q�6�   �� 5      -   5        $ TimeTextBox��5      $��1��6+   $	��100��6;   $��2��6F   $��Stretch=�6S   $
��auto��6q   $
��auto��6   $��30��6�   $	��150��6�   $��
0, 0, 0, 0q�6�   �� 5   
   -   5        $��IterationLabel��5      $&�� Enter Amount of iterations here!��6&   $��1��6R   $��0��6b   $��Stretch=�6o   $��Stretch=�6�   $��Center=�6�   $��Center=�6�   $��0, 50, 0, 0 q�6�   �� 5   
   -   5        $��	TimeLabel��5      $*��$Enter Time needed for one iteration!��6!   $��1��6Q   $��2��6a   $��Stretch=�6n   $��Stretch=�6�   $��Center=�6�   $��Center=�6�   $��0, 50, 0, 0 q�6�   �� 5   
   -   5        $��	RunButton��5      $��
Run Ocean!��6"   $��1��67   $��1��6G   6U   (� 5   
   -   5        $��OceanViewbox��5       (� Stretch$ Uniform=�6&   $��0��68   $��3��6H   .��5      �� -   5        $��OceanCanvas��5      $��0��6(   $��3��68   $��Center=�6I   $��Center=�6f   6�   5      5      5      