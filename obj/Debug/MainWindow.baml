   M S B A M L   `   `   `  ����K  GWPfOceanFirstTry, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WPfOceanFirstTryWPfOceanFirstTry  5   	   !    WPfOceanFirstTry.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:WPfOceanFirstTry     5   	     � Title$  
MainWindow��5   	   $	��600��5	   	   $	��800��5
   	   .��5      � -   5         �Name$ MainRoot��5       � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� -   5        $��ColumnTextBox��5      $��20��6)   $
��auto��65   $	��180��6B   $��1��6R   $��0��6b    �� TextWrapping$
 Wrap=�5      $��30��6'    �� TextAlignment$ Center=�61   $��Center=�6H   $��Stretch=�6c   �� 5   
   -   5        $��ColumnLabel��5      $&�� Enter the amount of columns here��6%   $��Center=�6P   $��Center=�6k   $��0, 40, 0, 0q�6�   $��1��6�   �� 5   
   -   5        $��
RowTextBox��5      $��20��6%   $ Center=�6/   $��20��6F   $	��180��6S   $��2��6`   $��0��6p   $
 Wrap=�5      $��Center=�6(   $��Center=�6C   �� 5   
   -   5        $��RowLabel��5      $#��Enter the amount of rows here��6"   $��Center=�6J   $��Center=�6e   $��0, 40, 0, 0q�6�   $��2��6�   $��0��6�   �� 5   
   -   5        $��PreyTextBox��5      $��20��6'   $	��180��63   $��0��6@   $��1��6P   $
 Wrap=�5       $	��100��6'   $ Center=�62   $��Center=�6I   $��Center=�6d   �� 5!   
   -   5        $��	PreyLabel��5!      $#��Enter the amount of prey here��6#   $��Center=�6K   $��Center=�6f   $��0, 40, 0, 0q�6�   $��0��6�   $��1��6�   �� 5"   
   -   5        $��PredatorTextBox��5"      $��20��6+   $	��180��67   $��1��6D   $��1��6T   $
 Wrap=�5#      $��8��6'   $ Center=�60   $��Center=�6G   $��Center=�6b   �� 5$   
   -	   5        $��PredatorLabel��5$      $(��"Enter the amount of predators here��6'   $��Center=�6T   $��Center=�6o   $��0, 40, 0, 0q�6�   $��1��6�   $��1��6�   �� 5%   
   -
   5        $��ObstacleTextBox��5%      $��20��6+   $	��180��67   $��2��6D   $��1��6T   $
 Wrap=�5&      $��30��6'   $ Center=�61   $��Center=�6H   $��Center=�6c   �� 5'   
   -   5        $��ObstacleLabel��5'      $(��"Enter the amount of obstacles here��6'   $��Center=�6T   $��Center=�6o   $��0, 40, 0, 0q�6�   $��2��6�   $��1��6�   �� 5*   
   -   5        $��GenerateOceanbutton��5*      $��GENERATE��6,   $��3��6?   $��1��6O   6\   �� 5,   
   -   5        $��Postcriptum��5,      $��2��6$   $��1��61   $��2��6A   $����P.S: For some reason this only works if you run it in Visual Studio
 and won't work if ran as an EXE file. I never managed to figure out why,
 but that's the case, so don't blame me pls, I've never touched WPF before��6U   5-      5.      