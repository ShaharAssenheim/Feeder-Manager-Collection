   M S B A M L   `   `   `  ����I  EFeeder Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Feeder_ManagerFeeder_Manager  5   	       Feeder_Manager.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Feeder_Manager     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        � Title$  Feeder Manager Collection��5      
������� � WindowStartupLocation$ CenterScreen=�6O    � WindowState$ 	Maximized=�6t   ��6�   ��  �� Source# Z����6�   �� # Z�� � 	Resources 5	         OpenMenu �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  	CloseMenu=  7System.Windows.Controls.Primitives.DataGridColumnHeader	 �� 
TargetType
 �� Property �� Value*  $System.Windows.Controls.DataGridCell��%X  &	        &	 �     '  �    '  �    �� 5
   
   .��5      U� $ (FrameworkElement.Width)�6,   $ GridMenu��6a   .\�5        $ 0��6'   $ 70Q�63     5      $ 0:0:0.5��6'   $	 200Q�69   5      5      �� 5   
   .��5      U� $ (FrameworkElement.Width)�6,   $ GridMenu��6a   .\�5        $ 0��6'   $	 200Q�63     5      $ 0:0:0.5��6'   $ 70Q�69   5      5      �� 5      "	  6   .�5      �� 
 � ��$ Center=�6;   5      �� 5   
   "	  6   .�5      �� 
 �@��TextAlignment$ Center=�68   5      5       � Triggers 5      :� 5   
    :� RoutedEvent$ ButtonBase.Click��6    :� 
SourceName$ ButtonOpenMenu��66   .[�5      �� #��[  6   5       :� 5!   
   $ ButtonBase.Click��6   $ ButtonCloseMenu��66   .[�5"      �� #��[ 6   5#      .��5%      (�  (� Stretch$
 Fill=�6    (� StretchDirection$
 Both=�6   .��5&   
   � $��0,0,0,0q�6   $	��Top=�6!   $
��1050��69   ���	#FFEAEAEA.+�5'      � -   5         �Name$ GridMain��5'      $��Right=�6%   $��Bottom=�6A   $
��1050��6\   $
��1845��6j    � RowDefinitions 5(      �� 5)      $	��400 �6$   �� 5*      .+�5,      �� -   5         ��Name$ FeederHeader��5,      $y�Hidden=�61     MaterialDesignCardGroupBox#���  6E   $��0��6z   $��202,10,143,0q�6�   $
��1500��6�   $	��380��6�   $��Center=�6�   $	��Top=�6�   .  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$ Custom=�6�      
Foreground
 �����.��5-      ��  �� Orientation$ Vertical=�6!   $��	0,-14,0,0q�68   $
��1490��6K   .+�5.      �� ���	#FFBFBFBF$��60��6<   $ 
Horizontal=�6H   $��0,0,10,0q�6a   .+�5/      �� $ 
Horizontal=�6)   $	��300��6B   .+�50   "   A� $��40��6*   $��40��65   $��10,0,0,0q�6A   ��51   &   �� 52   *   -   5        ProfileImage�� �� ImageSource$ /Resources/exit.png��52   K   54   #   �� 55   "   -   5         ��Name$ ProfileName��55   *    �� 
IsReadOnly . $�� ��6Q   $��5,0,0,0q�6Y   $
��Auto��6j   $��40��6w   $��Center=�6�   $��0q�6�   
���   �$��16(�6�   $
��Bold"�6�   56      �� 57      -   5         ��Name$ 	HeaderTxt��57   (   $��
300,10,0,0q�6<   $��Center=�6P   $��Center=�6k    $  MaterialDesignSubtitle1TextBlock#��[ 6�   $��Feeder Manager��6�   $��RightToLeft=�6�   $��30(�6�   $
��Bold"�6  
���   �6  58      �� 59      $ 
Horizontal=�6%   $��0,20,0,0q�6>   .+�5:      �� $ 
Horizontal=�6)   $	��800��6B   .+�5;   "   �� $ Vertical=�6-   $	��400��6D   .+�5<   &   �� $ 
Horizontal=�61   .+�5=   *   �� $��Enter Feeder ID��60   $��0,0,0,0q�6J   $��Center=�6[   $��14(�6}   �� 5>   *   -   5        $ FeederID_txt��5>   2    �� TextAlignment$ Center=�6H   $	��192��6_   $��60,0,0,0q�6k   $��1q�6}   
���   �$��14(�6�   �� 5?   *   -   5        $��10,0,0,0q�5?   1    � Cursor$
 Hand��6u   ��6^   Z� ��5@   .   �� 5A   2   $ Resources/search.png��6=    j� Stretch$
 Fill=�6`   5C   +   5D   '   �� 5E   &   $ 
Horizontal=�61   $��0,5,0,0q�6J   .+�5F   *   �� $��User ID��60   $��0,0,0,0q�6B   $��Center=�6S   $��14(�6u   �� 5G   *   -   5        $ 
UserId_txt��5G   2   $	��235��6F   $�� ��6R   $ Center=�6Z   $��	109,0,0,0q�6q    . $��1q�6�   
���   �$��14(�6�   5H   '   �� 5I   &   $ 
Horizontal=�61   $��0,5,0,0q�6J   .+�5J   *   �� $��Feeder Type��60   $��0,0,0,0q�6F   $��Center=�6W   $��14(�6y   �� 5K   *   -	   5        $ FeederType_txt��5K   2   $	��235��6J   $��79,0,0,0q�6V   $ Center=�6h    . $��1q�6�   
���   �$��14(�6�   5L   '   �� 5M   &   $ 
Horizontal=�61   $��0,5,0,0q�6J   .+�5N   *   �� $��Feeder Status��60   $��0,0,0,0q�6H   $��Center=�6Y   $��14(�6{   �� 5O   *   -
   5         ��Name$ FeederStatus_txt��5O   3   $	��235��6M   $��71,0,0,0q�6Y   $��1q�6k   
���   �$��14(�6�   $��Center=�6�   6�   5P   '   �� 5Q   &   $ 
Horizontal=�61   $��0,5,0,0q�6J   .+�5R   *   �� $��Calibration Date Expired��60   $��0,0,0,0q�6S   $��Center=�6d   $��14(�6�   �� 5S   *   -   5        $ CalibrationExp_txt��5S   2   $	��235��6N   $��5,0,0,0q�6Z   $ Center=�6k    . $��1q�6�   
���   �$��14(�6�   5T   '   �� 5U   &   $ 
Horizontal=�61   $��0,5,0,0q�6J   .+�5V   *   �� $��Malfunction Count��60   $��0,0,0,0q�6L   $��Center=�6]   $��14(�6   �� 5W   *   -   5        $ MalCount_Txt��5W   2   $	��235��6H   $��39,0,0,0q�6T   $ Center=�6f    . $��1q�6�   
���   �$��14(�6�   5X   '   5Z   #   �� 5[   "   $ Vertical=�6-   $��30,0,0,0q�6D   .+�5\   &   �� -   5         ��Name$ MalDateGrid��5\   1   $ 
Horizontal=�6F   $��0,5,0,0q�6_   .+�5]   *   �� $��Malfunction Date��60   $��0,0,0,0q�6K   $��Center=�6\   $��14(�6~   �� 5^   *   -   5        $ MalDate_txt��5^   2   $	��230��6G   $��20,0,0,0q�6S   $ Center=�6e    . $��1q�6�   
���   �$��14(�6�   5_   '   �� 5`   &   -   5        $ MalTypeGrid��5`   2   $ 
Horizontal=�6G   $��0,8,0,0q�6`   .+�5a   *   �� $��Malfunction Type��60   $��0,0,0,0q�6K   $��Center=�6\   $��14(�6~   �� 5b   *   -   5        $ MalType_txt��5b   2   $	��185��6G   $��20,0,0,0q�6S   $ Center=�6e    . $��1q�6�   
���   �$��14(�6�   �� 5c   *   -   5          ��Name$  ChangeMalBtn��5c   1   $��10,0,0,0q�6G   {�.  $
 Hand��6�   ! � ToolTip$! Change Mulfunction Type��6�   ��6�   Z� ��5d   .   �� 5e   2   $ Resources/change.png��6=   $
 Fill=�6`   5g   +   5h   '   �� 5i   &   -   5        $ TechID��5i   1   $ 
Horizontal=�6A   $��0,8,0,0q�6Z   .+�5j   *   �� $��Technician Id��60   $��0,0,0,0q�6H   $
��Left=�6Y   $��Center=�6t   $��14(�6�   $
��Auto��6�   �� 5k   *   -   5        $ 
TechId_txt��5k   2   $	��230��6F   $��47,0,0,0q�6R   $
��Left=�6d   $��Center=�6   $��1q�6�   
���   �$��14(�6�   5l   '   �� 5m   &   $ Vertical=�61   $��0,6,0,0q�6H   .+�5n   *   �� $��Result��60   $��0,0,0,0q�6A   $
��Left=�6R   $��Center=�6m   $��14(�6�   �� 5o   *   -   5        $ 
Result_txt��5o   2   $��1q�6F   $	��365��6Z   $��63��6f   
���   �$��14(�6�   $
��Left=�6�   5p   '   �� 5q   &   $ Vertical=�61   $��0,0,0,0q�6H   .+�5r   *   �� -   5        " ��Name$" CalibrateCheckBox��5r   3   $y�	Collapsed=�6r   $��Calibrate Feeder��6�   
���   �6�   5s   '   �� 5t   &   $ 
Horizontal=�61   $��0,10,0,0q�6J   .+�5u   *   �� -   5        $  CloseMal��5u   1   $	��127��6C   $��     Close
Malfunction��6O   $��Center=�6�   $��50��6�   $��35,0,0,0q�6�   ���	#FFBFBFBF���	#FFBFBFBF
���   �6�   �� 5v   *   -   5        $  DelMal��5v   1   $	��127��6A   $��   Delete
Malfunction��6M   $��50��6�   $��50,0,0,0q�6�   ���	#FFBFBFBF���	#FFBFBFBF
���   �6�   5w   '   5x   #   5y      �� 5z      $ Vertical=�6)   $	��520��6@   $��	160,0,0,0q�6L   .+�5{   "   �� $ 
Horizontal=�6-   $��0,10,0,0q�6F   .+�5|   &   �� -   5        $  ShowAllFeeders��5|   -   $��Show All Feeders��6E   $y�Visible=�6}   $��	100,0,0,0q�6�   $	��160��6�   $��55��6�   
�������
�������
���   �$
��Bold"�6�   $��16(�6  �� 5}   &   -   5        $  
ShowAllMal��5}   -   $��    Show All
Malfunctions��6A   $y�Visible=�6�   $��10,0,0,0q�6�   $	��160��6�   $��55��6�   
�������
�������
���   �$
��Bold"�6  $��16(�6  �� 5~   &   -   5        $  ShowChecklist��5~   -   $��Show CheckList��6D   $y�Hidden=�6]   $��10,0,0,0q�6�   $	��160��6�   $��55��6�   
�������
�������
���   �$
��Bold"�6�   $��16(�6  5   #   5�      5�      5�      5�      �� 5�      -   5        $ TableHeader��5�      $y�Hidden=�60   #���  6D   $��0��6y   $��202,10,143,0q�6�   $
��1500��6�   $	��380��6�   $��Center=�6�   $	��Top=�6�   $ Custom=�6�   
 �����.��5�      �� $ Vertical=�6!   $��	0,-14,0,0q�68   $
��1490��6K   .+�5�      �� $ 
Horizontal=�6%   ���	#FFBFBFBF$��60��6U   $��0,0,10,0q�6a   .+�5�      �� $ 
Horizontal=�6)   $	��300��6B   .+�5�   "   A� $��40��6*   $��40��65   $��10,0,0,0q�6A   ��5�   &   �� 5�   *   -   5        ProfileImage2��$ /Resources/exit.png��5�   L   5�   #   �� 5�   "   -   5        $ ProfileName2��5�   *    . $�� ��6R   $��5,0,0,0q�6Z   $
��Auto��6k   $��40��6x   $��Center=�6�   $��0q�6�   
���   �$��16(�6�   $
��Bold"�6�   5�      �� 5�      -   5        $ TableHeaderTxt��5�   (   $��
300,10,0,0q�6A   $��Center=�6U   $��Center=�6p   #��[ 6�   $��Table Manager��6�   $��RightToLeft=�6�   $��30(�6�   $
��Bold"�6  
���   �6  5�      �� 5�      $ 
Horizontal=�6%   $��0,20,0,0q�6>   .+�5�      �� $ 
Horizontal=�6)   $	��800��6B   .+�5�   "   �� $ Vertical=�6-   $	��380��6D   .+�5�   &   �� $ 
Horizontal=�61   .+�5�   *   �� $��Enter Table ID��60   $��0,0,0,0q�6I   $��Center=�6Z   $��14(�6|   �� 5�   *   -   5        $ TableID_txt��5�   2   $ Center=�6G   $	��140��6^   $��86,0,0,0q�6j   $��1q�6|   
���   �$��14(�6�   �� 5�   *   -    5        $��10,0,0,0q�5�   1   $
 Hand��6t   ��6]   Z� ��5�   .   �� 5�   2   $ Resources/search.png��6=   $
 Fill=�6`   5�   +   5�   '   �� 5�   &   $ 
Horizontal=�61   $��0,5,0,0q�6J   .+�5�   *   �� $��User ID��60   $��0,0,0,0q�6B   $��Center=�6S   $��14(�6u   �� 5�   *   -!   5        $ TableUserId_txt��5�   2   $	��182��6K   $�� ��6W   $ Center=�6_   $��	126,0,0,0q�6v    . $��1q�6�   
���   �$��14(�6�   5�   '   �� 5�   &   $ 
Horizontal=�61   $��0,5,0,0q�6J   .+�5�   *   �� $��
Table Type��60   $��0,0,0,0q�6E   $��Center=�6V   $��14(�6x   �� 5�   *   -"   5        $ TableType_txt��5�   2   $	��182��6I   $��	106,0,0,0q�6U   $ Center=�6h    . $��1q�6�   
���   �$��14(�6�   5�   '   �� 5�   &   $ 
Horizontal=�61   $��0,5,0,0q�6J   .+�5�   *   �� $��Table Status��60   $��0,0,0,0q�6G   $��Center=�6X   $��14(�6z   �� 5�   *   -#   5        $ TableStatus_txt��5�   2   $	��182��6K   $��98,0,0,0q�6W   $ Center=�6i    . $��1q�6�   
���   �$��14(�6�   5�   '   �� 5�   &   $ 
Horizontal=�61   $��0,5,0,0q�6J   .+�5�   *   �� $��Malfunction Count��60   $��0,0,0,0q�6L   $��Center=�6]   $��14(�6   �� 5�   *   -$   5        $ TableMalCount_Txt��5�   2   $	��182��6M   $��56,0,0,0q�6Y   $ Center=�6k    . $��1q�6�   
���   �$��14(�6�   5�   '   �� 5�   &   $ 
Horizontal=�61   $��0,5,0,0q�6J   .+�5�   *   �� $��Malfunction Type��60   $��0,0,0,0q�6K   $��Center=�6\   $��14(�6~   �� 5�   *   -%   5        $ TableMalType_txt��5�   2   $	��182��6L   $��64,0,0,0q�6X   $ Center=�6j    . $��1q�6�   
���   �$��14(�6�   5�   '   �� 5�   &   $ 
Horizontal=�61   $��0,5,0,0q�6J   .+�5�   *   �� $��Malfunction Date Opned��60   $��0,0,0,0q�6Q   $��Center=�6b   $��14(�6�   �� 5�   *   -&   5        $ TableMalDateOpen_txt��5�   2   $	��182��6P   $��18,0,0,0q�6\   $ Center=�6n    . $��1q�6�   
���   �$��14(�6�   5�   '   �� 5�   &   $ 
Horizontal=�61   $��0,5,0,0q�6J   .+�5�   *   �� $��Malfunction Date Closed��60   $��0,0,0,0q�6R   $��Center=�6c   $��14(�6�   �� 5�   *   -'   5        $ TableMalDateClose_txt��5�   2   $	��182��6Q   $��19,0,0,0q�6]   $ Center=�6o    . $��1q�6�   
���   �$��14(�6�   5�   '   5�   #   �� 5�   "   $ Vertical=�6-   $��30,0,0,0q�6D   .+�5�   &   �� $ Vertical=�61   .+�5�   *   �� $��Technician Id��60   $��0,0,0,0q�6H   $
��Left=�6Y   $��Center=�6t   $��14(�6�   $	��168��6�   �� 5�   *   -(   5        $ TableTechId_txt��5�   2   $	��304��6K   $��5,0,0,0q�6W   $
��Left=�6h   $��Center=�6�   $��1q�6�   
���   �$��14(�6�   5�   '   �� 5�   &   $ Vertical=�61   $��0,0,0,0q�6H   .+�5�   *   �� $��Result��60   $��0,0,0,0q�6A   $
��Left=�6R   $��Center=�6m   $��14(�6�   �� 5�   *   -)   5        $ TableResult_txt��5�   2   $��1q�6K   $	��304��6_   $��63��6k   
���   �$��14(�6�   5�   '   �� 5�   &   $ 
Horizontal=�61   $��0,10,0,0q�6J   .+�5�   *   �� -*   5        $  TableCloseMal��5�   1   $	��127��6H   $��     Close
Malfunction��6T   $��Center=�6�   $��50��6�   $��5,0,0,0q�6�   ���	#FFBFBFBF���	#FFBFBFBF
���   �6  �� 5�   *   -+   5        $  TableDelMal��5�   1   $	��127��6F   $��   Delete
Malfunction��6R   $��50��6�   $��50,0,0,0q�6�   ���	#FFBFBFBF���	#FFBFBFBF
���   �6�   5�   '   5�   #   5�      �� 5�      $ Vertical=�6)   $	��350��6@   $��	350,0,0,0q�6L   .+�5�   "   �� $ 
Horizontal=�6-   $��0,10,0,0q�6F   .+�5�   &   �� -,   5        $  ShowAllTables��5�   -   $��Show All Tables��6D   $y�Visible=�6z   $��0,0,0,0q�6�   $	��160��6�   $��55��6�   ���	#FFBFBFBF���	#FFBFBFBF
���   �$
��Bold"�6�   $��16(�6  �� 5�   &   --   5        $  ShowAllTableMal��5�   -   $��    Show All
Malfunctions��6F   $y�Visible=�6�   $��10,0,0,0q�6�   $	��160��6�   $��55��6�   ���	#FFBFBFBF���	#FFBFBFBF
���   �$
��Bold"�6  $��16(�6   5�   #   5�      5�      5�      5�      �� 5�      -.   5        $ SegmentHeader��5�      $y�Hidden=�62   #���  6F   $��0��6{   $��202,10,143,0q�6�   $
��1500��6�   $	��380��6�   $��Center=�6�   $	��Top=�6�   $ Custom=�6�   
 �����.��5�      �� $ Vertical=�6!   $��	0,-14,0,0q�68   $
��1490��6K   .+�5�      �� $ 
Horizontal=�6%   ���	#FFBFBFBF$��60��6U   $��0,0,10,0q�6a   .+�5�      �� $ 
Horizontal=�6)   $	��300��6B   .+�5�   "   A� $��40��6*   $��40��65   $��10,0,0,0q�6A   ��5�   &   �� 5�   *   -/   5        ProfileImage3��$ /Resources/exit.png��5�   L   5�   #   �� 5�   "   -0   5        $ ProfileName3��5�   *    . $�� ��6R   $��5,0,0,0q�6Z   $
��Auto��6k   $��40��6x   $��Center=�6�   $��0q�6�   
���   �$��16(�6�   $
��Bold"�6�   5�      �� 5�      -1   5        $ SegmentHeaderTxt��5�   (   $��
300,10,0,0q�6C   $��Center=�6W   $��Center=�6r   #��[ 6�   $��Segment Manager��6�   $��RightToLeft=�6�   $��30(�6�   $
��Bold"�6
  
���   �6  5�      �� 5�      $ 
Horizontal=�6%   $��0,20,0,0q�6>   .+�5�      �� $ 
Horizontal=�6)   $	��800��6B   .+�5�   "   �� $ Vertical=�6-   $	��380��6D   .+�5�   &   �� $ 
Horizontal=�61   $��0,5,0,0q�6J   .+�5�   *   �� $
��Line��60   $��0,0,0,0q�6?   $��Center=�6P   $��14(�6r   �� 5�   *   -2   5        $ SegmentLine_txt��5�   2   $	��230��6K   $�� ��6W   $ Center=�6_   $��	105,0,0,0q�6v    . $��1q�6�   
���   �$��14(�6�   5�   '   �� 5�   &   $ 
Horizontal=�61   $��0,15,0,0q�6J   .+�5�   *   �� $��Machine��60   $��0,0,0,0q�6B   $��Center=�6S   $��14(�6u   �� 5�   *   -3   5        $ SegmentMachine_txt��5�   2   $	��230��6N   $��77,0,0,0q�6Z   $ Center=�6l    . $��1q�6�   
���   �$��14(�6�   5�   '   �� 5�   &   $ 
Horizontal=�61   $��0,15,0,0q�6J   .+�5�   *   �� $��Segment Number��60   $��0,0,0,0q�6I   $��Center=�6Z   $��14(�6|   �� 5�   *   -4   5        $ SegmentNumber_txt��5�   2   $	��230��6M   $��20,0,0,0q�6Y   $ Center=�6k    . $��1q�6�   
���   �$��14(�6�   5�   '   �� 5�   &   $ 
Horizontal=�61   $��0,15,0,0q�6J   .+�5�   *   �� $��Omit Segment��60   $��0,0,0,0q�6G   $��Center=�6X   $��14(�6z   �� 5�   *   -5   5        $ OmitSegmentCount_Txt��5�   2   $	��230��6P   $��40,0,0,0q�6\   $ Center=�6n    . $��1q�6�   
���   �$��14(�6�   5�   '   �� 5�   &   $ 
Horizontal=�61   $��0,15,0,0q�6J   .+�5�   *   �� $��Setup��60   $��0,0,0,0q�6@   $��Center=�6Q   $��14(�6s   �� 5�   *   -6   5        $ SegmentSetup_txt��5�   2   $	��230��6L   $��94,0,0,0q�6X   $ Center=�6j    . $��1q�6�   
���   �$��14(�6�   5�   '   5�   #   �� 5�   "   $ Vertical=�6-   $��30,0,0,0q�6D   .+�5�   &   �� $ Vertical=�61   .+�5�   *   �� $��Technician Id��60   $��0,0,0,0q�6H   $
��Left=�6Y   $��Center=�6t   $��14(�6�   $	��168��6�   �� 5�   *   -7   5        $ SegmentTechId_txt��5�   2   $	��304��6M   $��5,0,0,0q�6Y   $
��Left=�6j   $��Center=�6�   $��1q�6�   
���   �$��14(�6�   5�   '   �� 5�   &   $ Vertical=�61   $��0,0,0,0q�6H   .+�5�   *   �� $��Result��60   $��0,0,0,0q�6A   $
��Left=�6R   $��Center=�6m   $��14(�6�   �� 5�   *   -8   5        $ SegmentResult_txt��5�   2   $��1q�6M   $	��304��6a   $��63��6m   
���   �$��14(�6�   5�   '   �� 5   &   $ 
Horizontal=�61   $��0,10,0,0q�6J   .+�5  *   �� -9   5        $  SegmentCloseMal��5  1   $	��127��6J   {�.  $��     Close
Malfunction��6h   $��Center=�6�   $��50��6�   $��5,0,0,0q�6�   ���	#FFBFBFBF���	#FFBFBFBF
���   �6  �� 5  *   -:   5        $  SegmentDelMal��5  1   $	��127��6H   {�.  $��   Delete
Malfunction��6f   $��50��6�   $��50,0,0,0q�6�   ���	#FFBFBFBF���	#FFBFBFBF
���   �6�   5  '   5  #   5     5     5     5     �� 5
     -;   5        $ GridBoxFeeder��5
     $y�Hidden=�62   #���  6F   $��1��6{   $��60,0,0,0q�6�   $
��1500��6�   $	��633��6�   $��Center=�6�   $	��Top=�6�   $ Custom=�6�   
 �����.��5     � .+�5     �� -<   5        $ MalfunctionSP��5  %   $y�Visible=�6<   $ Vertical=�6Q   $��	0,-25,0,0q�6h   .+�5     �� $ 
Horizontal=�6)   .+�5  "   �� -=   5        $" ClosedMalCheck��5  +   $��Show Closed Malfunction��6�   ���	#FF020202��6�   Z� �� 5  "   ->   5        $" OpenMalCheck��5  +   $��20,0,0,0q�6B   $��Show Opened Malfunction��6�   ���	#FF020202��6�   Z� �� 5  "   -?   5        # ��Name$# MalFeederHeader��5  (   $	��320��6A   $��Feeder Malfunctions List��6M   $��	290,0,0,0q�6p   $
��Bold"�6�   $��18(�6�   �� 5  "   -@   5        $��	355,0,0,0q�5  *   $��25��6S   $	��170��6_   ���	#FFBFBFBF���	#FFBFBFBF
���   �.��5  &   �� $ 
Horizontal=�61   .+�5  *   '  !MaterialDesignThemes.Wpf.PackIcon  $   Kind$$ PlusBox=�6B   $��21��6Q   �� 5  *   $��Open Mulfunction��64   $��5,0,0,0q�6L   5  '   5  #   5     &   System.Windows.Controls.DataGrid  5     -A   5        %  Name$% MalfunctionDG��5  '   $��0,10,0,0q�6>   $	��580��6P   &   	RowHeight$& 35Q�6]   $
��Auto��6l   '   CanUserAddRows' .  (   AutoGenerateColumns( .  ) %� IsVirtualizing) . * %� VirtualizationMode$* 	Recycling=�6�   ��. $
��Auto=�64  $
��Auto=�6f  $+   HorizontalScrollBarVisibility$+ Visible=�6�  $��18(�6�  ,   VerticalGridLinesBrush
, �����-   GridLinesVisibility$	- All=�6�  .   HorizontalGridLinesBrush
. �����/   SelectionMode$/ Single=�6X  0   SelectionUnit$0 FullRow=�6o  1   Columns1 5  "   0  *System.Windows.Controls.DataGridTextColumn  5  &   ,  &System.Windows.Controls.DataGridColumn2   Header$2 Feeder
    Id��69   3   Width5	  /System.Windows.Controls.DataGridLengthConverter$
3 Auto	 6q   4   
IsReadOnly4 . 1
  +System.Windows.Controls.DataGridBoundColumn5 
  Binding5 6T   �� *
FeederId+6~     5  &   $2 	User
  Id��69   $
3 Auto	 6k   4 . 5 6P   �� *UserId+6x     5  &   $2 Feeder
 Type��69   $
3 Auto	 6r   4 . 5 6S   �� *
FeederType+6     5  &   $2 Feeder
Status��69   $
3 Auto	 6u   4 . 5 6T   �� *FeederStatus+6�     5  &   $$2 Calibration Date
      Expired��69   $
3 Auto	 6�   4 . 5 6e   �� *CalibrationDateExpired+6�     5  &   $2 Malfunction
    Count��69   $
3 Auto	 6�   4 . 5 6\   �� *MalfunctionCount+6�     5   &   $2 Malfunction
     Type��69   $
3 Auto	 6�   4 . 5 6\   �� *MalfunctionType+6�     5!  &   $$2 Malfunction Date
       Opened��69   $
3 Auto	 6�   4 . 5 6e   �� *MalfunctionDateOpened+6�     5"  &   $$2 Malfunction Date
       Closed��69   $
3 Auto	 6�   4 . 5 6e   �� *MalfunctionDateClosed+6�     5#  &   $2 Malfunction
    Result��69   $
3 Auto	 6�   4 . 5 6]   �� *MalfunctionResult+6�     5$  &   $2 Technician
      Id��69   $3 *	 6{   4 . 5 6Z   �� *TechnicianId+6�   5&     5'     �� 5(     -B   5        $ FeederSP��5(  %   $y�Hidden=�67   $ Vertical=�6K   $��	0,-25,0,0q�6b   .+�5)     �� $ 
Horizontal=�6)   .+�5*  "   �� -C   5        $" InWorkFeederCheck��5*  +   $��Show In Work��6F   ���	#FF020202��6�   Z� �� 5+  "   -D   5        $" OpenMalFeederCheck��5+  +   $��20,0,0,0q�6�   $��Show Opened Malfunction��6�   ���	#FF020202��6�   Z� �� 5,  "   -E   5        $# FeederListHeader��5,  (   $	��300��6B   $��Feeders List��6N   $��	385,0,0,0q�6e   $
��Bold"�6x   $��18(�6�   �� 5-  "   -F   5        $  AddNewFeeder��5-  )   $��	340,0,0,0q�6@   $��25��6n   $	��170��6z   ���	#FFBFBFBF���	#FFBFBFBF
���   �.��5.  &   �� $ 
Horizontal=�61   .+�5/  *     $$ PlusBox=�6B   $��21��6Q   �� 50  *   $��Add New Feeder��64   $��5,0,0,0q�6J   51  '   52  #   53       54     -G   5        $% FeederDG��54  '   $��0,10,0,0q�69   $	��580��6K   $
��Auto��6X   ' .  ( .  ) . $* 	Recycling=�6�   ��. $
��Auto=�6   $
��Auto=�6R  $+ Visible=�6�  $��18(�6�  
, �����$	- All=�6�  
. �����1 55  "     56  &   $2 	Feeder Id��69   $	3 150	 6i   4 . 5 6L   �� *
FeederID+6u     57  &   $2 User Id��69   $
3 Auto	 6e   4 . 5 6J   �� *UserID+6r     58  &   $2 Feeder Type��69   $	3 150	 6m   4 . 5 6N   �� *
FeederType+6y     59  &   $2 Feeder
Sensor��69   $
3 Auto	 6u   4 . 5 6T   �� *FeederSensor+6�     5:  &   $2 Feeder Status��69   $
3 Auto	 6q   4 . 5 6P   �� *FeederStatus+6~     5;  &   $2 Calibration Date Expired��69   $
3 Auto	 6�   4 . 5 6[   �� *CalibrationDateExpired+6�     5<  &   $2 Malfunctions Count��69   $
3 Auto	 6z   4 . 5 6U   �� *MalfunctionCount+6�     5=  &   $2 Last Time Checked��69   $	3 250	 6x   4 . 5 6T   �� *LastTimeChecked+6�   4  .System.Windows.Controls.DataGridTemplateColumn  5>  &   $2 Calibrate
  Feeder��6=   $
3 Auto	 6^   4 . 6   CellTemplate6 5?  *   �� 5@  .   .R�5A  2   �� $  CalibrateFeeder��69   -H   5        $��37��5A  �   ��6R   Z� ��6h   Z� ��6   Z� .��5B  6   �� $��/Resources/calibrate.png��6=   $��30��6_   $��32��6k   5C  3   5D  /   5F  '     5G  &   $2 Delete
Feeder��6=   $
3 Auto	 6Y   4 . 6 5H  *   �� 5I  .   .R�5J  2   �� $  	DelFeeder��69   -I   5        $��37��5J  �   ��6L   Z� ��6b   Z� ��6y   Z� .��5K  6   �� $��/Resources/delete.png��6=   $��30��6\   $��32��6h   5L  3   5M  /   5O  '     5P  &   $2   Edit
Feeder��6=   $3 *	 6Y   4 . 6 5Q  *   �� 5R  .   .R�5S  2   �� $  
EditFeeder��69   -J   5        $��37��5S  �   ��6M   Z� ��6c   Z� ��6z   Z� .��5T  6   �� $��/Resources/edit.jpg��6=   $��30��6Z   $��32��6f   5U  3   5V  /   5X  '   5Z     5[     5\     5]     �� 5^     -K   5        $ GridBoxTable��5^     $y�Hidden=�61   #���  6E   $��1��6z   $��60,0,0,0q�6�   $
��1500��6�   $	��633��6�   $��Center=�6�   $	��Top=�6�   $ Custom=�6�   
 �����.��5_     � .+�5`     �� -L   5        $ TableMalfunctionSP��5`  %   $y�Visible=�6A   $ Vertical=�6V   $��	0,-25,0,0q�6m   .+�5a     �� $ 
Horizontal=�6)   .+�5b  "   �� -M   5        $" TableClosedMalCheck��5b  +   $��Show Closed Malfunction��6�   ���	#FF020202��6�   Z� �� 5c  "   -N   5        $" TableOpenMalCheck��5c  +   $��20,0,0,0q�6G   $��Show Opened Malfunction��6�   ���	#FF020202��6�   Z� �� 5d  "   -O   5        $# TableMalHeader��5d  (   $��Table Malfunctions List��6@   $	��270��6b   $��	270,0,0,0q�6n   $
��Bold"�6�   $��18(�6�   �� 5e  "   -P   5        $��	425,0,0,0q�5e  *   $��25��6X   $	��170��6d   ���	#FFBFBFBF���	#FFBFBFBF
���   �.��5f  &   �� $ 
Horizontal=�61   .+�5g  *     $$ PlusBox=�6B   $��21��6Q   �� 5h  *   $��Open Mulfunction��64   $��5,0,0,0q�6L   5i  '   5j  #   5k       5l     -Q   5        $% TableMalfunctionDG��5l  '   $��0,10,0,0q�6C   $	��580��6U   $
��Auto��6b   ' .  ( .  ) . $* 	Recycling=�6�   ��. $
��Auto=�6*  $
��Auto=�6\  $+ Visible=�6�  $��18(�6�  
, �����$	- All=�6�  
. �����$/ Single=�6S  $0 FullRow=�6j  1 5m  "     5n  &   $2 Table
    Id��69   $
3 Auto	 6o   4 . 5 6S   �� *	TableId+6|     5o  &   $2 	User
  Id��69   $
3 Auto	 6k   4 . 5 6P   �� *UserId+6x     5p  &   $2 Table
 Type��69   $
3 Auto	 6p   4 . 5 6R   �� *	TableType+6}     5q  &   $2 Table
Status��69   $
3 Auto	 6s   4 . 5 6S   �� *TableStatus+6�     5r  &   $2 Malfunction
    Count��69   $
3 Auto	 6�   4 . 5 6\   �� *MalfunctionCount+6�     5s  &   $2 Malfunction Type��69   $	3 250	 6w   4 . 5 6S   �� *MalfunctionType+6�     5t  &   $$2 Malfunction Date
       Opened��69   $
3 Auto	 6�   4 . 5 6e   �� *MalfunctionDateOpened+6�     5u  &   $$2 Malfunction Date
       Closed��69   $
3 Auto	 6�   4 . 5 6e   �� *MalfunctionDateClosed+6�     5v  &   $2 Malfunction
    Result��69   $	3 250	 6�   4 . 5 6]   �� *MalfunctionResult+6�     5w  &   $2 Technician
      Id��69   $3 *	 6{   4 . 5 6Z   �� *TechnicianId+6�   5y     5z     �� 5{     -R   5        $ TableSP��5{  %   $y�Hidden=�66   $ Vertical=�6J   $��	0,-25,0,0q�6a   .+�5|     �� $ 
Horizontal=�6)   .+�5}  "   �� -S   5        $" TableInWorkCheck��5}  +   $��Show In Work��6E   ���	#FF020202��6�   Z� �� 5~  "   -T   5        $" TableOpenCheck��5~  +   $��20,0,0,0q�6   $��Show Opened Malfunction��6�   ���	#FF020202��6�   Z� �� 5  "   -U   5        $# TablesListHeader��5  (   $��
Table List��6B   $	��250��6W   $��	385,0,0,0q�6c   $
��Bold"�6v   $��18(�6�   �� 5�  "   -V   5        $  AddNewTable��5�  )   $��	390,0,0,0q�6?   $��25��6l   $	��170��6x   ���	#FFBFBFBF���	#FFBFBFBF
���   �.��5�  &   �� $ 
Horizontal=�61   .+�5�  *     $$ PlusBox=�6B   $��21��6Q   �� 5�  *   $��Add New Table��64   $��5,0,0,0q�6I   5�  '   5�  #   5�       5�     -W   5        $% TableDG��5�  '   $��0,10,0,0q�68   $	��580��6J   $
��Auto��6W   $��18(�6d   ' .  ( .  ) . $* 	Recycling=�6�   ��. $
��Auto=�6-  $
��Auto=�6_  $+ Visible=�6�  
, �����$	- All=�6�  
. �����1 5�  "     5�  &   $2 Table Id��69   $
3 Auto	 6g   4 . 5 6K   �� *	TableID+6t     5�  &   $2 User Id��69   $
3 Auto	 6e   4 . 5 6J   �� *UserID+6r     5�  &   $2 
Table Type��69   $
3 Auto	 6k   4 . 5 6M   �� *	TableType+6x     5�  &   $2 Table Status��69   $
3 Auto	 6o   4 . 5 6O   �� *TableStatus+6|     5�  &   $2 Malfunctions Count��69   $
3 Auto	 6z   4 . 5 6U   �� *MalfunctionCount+6�     5�  &   $2 Creation Date��69   $
3 Auto	 6q   4 . 5 6P   �� *CreationDate+6~     5�  &   $2 Last Time Checked��69   $
3 Auto	 6x   4 . 5 6T   �� *LastTimeChecked+6�     5�  &   $2 Delete Table��6=   $3 *	 6T   4 . 6 5�  *   �� 5�  .   .R�5�  2   �� $  DelTable��69   -X   5        $��37��5�  �   ��6K   Z� ��6a   Z� ��6x   Z� .��5�  6   �� $��/Resources/delete.png��6=   $��30��6\   $��32��6h   5�  3   5�  /   5�  '   5�     5�     5�     5�     �� 5�     -Y   5        $ GridBoxSegment��5�     $y�Hidden=�63   #���  6G   $��1��6|   $��60,0,0,0q�6�   $
��1500��6�   $	��633��6�   $��Center=�6�   $	��Top=�6�   $ Custom=�6�   
 �����.��5�     � .+�5�     �� -Z   5        $ SegmentMalfunctionSP��5�  %   $y�Visible=�6C   $ Vertical=�6X   $��	0,-25,0,0q�6o   .+�5�     �� $ 
Horizontal=�6)   .+�5�  "   �� -[   5        $# SegmentMalHeader��5�  (   $��Segment Malfunctions List��6B   $	��300��6f   $��	620,0,0,0q�6r   $
��Bold"�6�   $��18(�6�   5�       5�     -\   5        $% SegmentMalfunctionDG��5�  '   $��0,10,0,0q�6E   $	��580��6W   $��18(�6d   $
��Auto��6r   ' .  ( .  ) . $* 	Recycling=�6�   ��. $
��Auto=�6:  $
��Auto=�6l  $+ Visible=�6�  
, �����$	- All=�6�  
. �����$/ Single=�6  $0 FullRow=�65  7   RowStyle7 5�  "   �� 5�  &   )  #System.Windows.Controls.DataGridRow"	  6,   .�5�  *   �� 
 � �� 6G   �� *
RowColor+5�  '   1 5�  "     5�  &   $
2 Line��69   $	3 300	 6`   4 . 5 6G   �� *Line+6l     5�  &   $2 Machine��69   $	3 300	 6f   4 . 5 6J   �� *	Station+6r     5�  &   $2 Segment Number��69   $	3 300	 6s   4 . 5 6Q   �� *SegmentNumber+6     5�  &   $2 Omit Segment��69   8   
Visibility$8 Hidden=�6O   $	3 250	 6�   4 . 5 6c   �� *OmitSegment+6�     5�  &   $2 Setup��69   $3 *	 6b   4 . 5 6H   �� *Setup+6l   5�     5�     5�     5�     5�     � 5�     -]   5        $ GridMenu��5�     $��70��6%   $
��Left=�60   ���	#FFBFBFBF9 J� Effect9 5�     3  -System.Windows.Media.Effects.DropShadowEffect  5�     :   
BlurRadius$: 2Q�6'   ;   ShadowDepth$; 1Q�66   <   Color$< 	#FFBFBFBF��6F   .+�5�     �� .+�5�     � $	��150��6   
�������= J� RenderTransformOrigin$= 0.5,0.5&�6;   z�5�     V� 5�     .~�5�  "   �� �� 5�  "   �� 5�  "   T� 5�  "   5�     .+�5�     �� -^   5        $  ButtonOpenMenu��5�  !   $��60��69   $��60��6E   $��5q�6P   $��Right=�6[   $	��Top=�6w    0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 6�   ���	#FF676568��6�   Z� ��6�   Z� .��5�       $
$ Menu=�66   $��50��6B   $��50��6M   5�     �� 5�     -_   5        $  ButtonCloseMenu��5�  !   $y�	Collapsed=�6:   $��60��6Q   $��60��6]   $��5q�6h   $��Right=�6s   $	��Top=�6�   #��[ 6�   ���	#FF676568��6�   Z� ��6  Z� .��5�       $$ 	ArrowLeft=�66   $��50��6G   $��50��6R   5�     �� 5�     -`   5        $  ProfileS��5�  !   $y�Visible=�6G   #��[ 6\   $��0q�6�   $
��Auto��6�   $
��Auto��6�   $��10,78,10,24q�6�   ��6�   Z� ��5�     �� 5�  "   $ Resources/logo.png��6-   $ UniformToFill=�6N   5�     �� 5�     -a   5        $  ProfileL��5�  !   $y�Hidden=�6G   #��[ 6[   $��0q�6�   $
��Auto��6�   $
��Auto��6�   $��10,20,76,28q�6�   ��6�   Z� ��5�     �� 5�  "   $ Resources/logo.png��6-   $ UniformToFill=�6N   5�     5�     �� 5�     -b   5        > ��Name$> ListViewMenu��5�     
�������$��Disabled=�6H   .@�5�     �� -c   5        ? ��Name$? 
ItemFeeder��5�  '   $��90��6;   $
 Hand��6G   $! Feeders Management��6U   .��5�     �� $ 
Horizontal=�6)   .+�5�  "   �� $��/Resources/feeder.png��6)   $��50��6H   $��50��6T   �� 5�  "   $��Feeders
Management��6,   $��Center=�6K   $��20 10q�6f   $��18(�6u   
���   �6�   5�     5�     �� 5�     -d   5        $? 	ItemTable��5�  '   $��90��6:   $
 Hand��6F   $! Tables Management��6T   .��5�     �� $ 
Horizontal=�6)   .+�5�  "   �� $��/Resources/table.png��6)   $��50��6G   $��50��6S   �� 5�  "   $��Tables
Management��6,   $��Center=�6J   $��20 10q�6e   $��18(�6t   
���   �6�   5�     5�     �� 5�     -e   5        $? ItemSegment��5�  '   $��90��6<   $
 Hand��6H   $! Segments Management��6V   .��5�     �� $ 
Horizontal=�6)   .+�5�  "   �� $��/Resources/segment.png��6)   $��50��6I   $��50��6U   �� 5�  "   $��Segments
Management��6,   $��Center=�6L   $��20 10q�6g   $��18(�6v   
���   �6�   5�     5�     �� 5�     -f   5        $? 
ItemExport��5�  '   $��70��6;   $
 Hand��6G   $! Export��6U   .��5�     �� $ 
Horizontal=�6)   .+�5�  "   �� $��/Resources/export.png��6)   $��50��6H   $��50��6T   �� 5�  "   $��Export Excel��6,   $��Center=�6@   $��20 10q�6[   $��18(�6j   
���   �6x   5�     5�     �� 5�     -g   5        $? ItemStatistics��5�  '   $��70��6?   $
 Hand��6K   $! 
Statistics��6Y   .��5�     �� $ 
Horizontal=�6)   .+�5�  "   �� $��/Resources/statistic.png��6)   $��50��6K   $��50��6W   �� 5�  "   $��
Statistics��6,   $��Center=�6>   $��20 10q�6Z   $��18(�6i   
���   �6w   5�     5�     �� 5�     -h   5        $? 	ItemUsers��5�  '   $��70��6:   $
 Hand��6F   $! Users��6T   .��5�     �� $ 
Horizontal=�6)   .+�5�  "   �� $��/Resources/users.jpg��6)   $��50��6G   $��50��6S   �� 5�  "   $��Users��6,   $��Center=�69   $��20 10q�6U   $��18(�6d   
���   �6r   5�     5�     �� 5�     -i   5        $? 	ItemAbout��5�  '   $��70��6:   $
 Hand��6F   $! About��6T   .��5�     �� $ 
Horizontal=�6)   .+�5�  "   �� $��/Resources/about.png��6)   $��50��6G   $��50��6S   �� 5�  "   $��About��6,   $��Center=�69   $��20 10q�6U   $��18(�6d   
���   �6r   5�     5�     �� 5      -j   5        $? ItemExit��5   '   $��70��69   $
 Hand��6E   $
! Exit��6S   .��5     �� $ 
Horizontal=�6)   .+�5  "   �� $��/Resources/exit.png��6)   $��50��6F   $��50��6R   �� 5  "   $
��Exit��6,   $��Center=�68   $��20 10q�6T   $��18(�6c   
���   �6q   5     5     5     �� 5     $��/Resources/flex2.png��6   $��60��6;   $��60��6G   $��	0,380,0,0q�6R   5     5	     �� 5
     -k   5        @ ��Name$@ BigLogo��5
     $��/Resources/flex2.png��6%   $��0,0,0,0q�6C   $	��600��6T   $	��400��6`   5     5     5     