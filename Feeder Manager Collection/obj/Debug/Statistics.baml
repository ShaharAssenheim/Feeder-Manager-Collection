   M S B A M L   `   `   `  ����I  EFeeder Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Feeder_ManagerFeeder_Manager  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5   P       Feeder_Manager.Statistics   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Feeder_Manager     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      >Wpf4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf  6P   -   5        
�������  � WindowStartupLocation$  CenterScreen=�5	   .    � WindowState$ 	Maximized=�6S   ��6k   ��  �� Source# Z����6�   �� # Z��.��5
      (�  (� Stretch$
 Fill=�6    (� StretchDirection$
 Both=�6   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ FeedersGrid��5       �� Orientation$ Vertical=�6*   $y�Visible=�6A   $��1��6V   $��1��6c   .+�5      �� -   5        $ 	FeederSP1��5      $
��1600��6,   $	��480��69   $��0,0,0,0q�6F   .+�5      �� -   5        	 ��Name$	 FeederHeader1��5      $��Center=�63   
 �� TextAlignment$
 Center=�6P   $"��Feeder Mulfunctions By Weeks��6g   $��0,20,0,0q�6�   $��30(�6�   $
��Bold"�6�   $��WS Simple Gallifreyan)�6�   ���	#DD0000006�   �� 5      -   5         ��Name$ BtnFeederOpen��5         MaterialDesignRaisedButton#���   60   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth3=�6e   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 50��6�   $	��400��6�   $
��1500��6�   $��0,10,0,0q�6�   
���������6  Z� .��5      #  LiveCharts.Wpf.CartesianChart  -   5          Name$ FeederOpenChart��5   )   
���   �&   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$	 Top=�6y   $	��399��6�   $
��1480��6�      Series 6B   �� *FeederOpenSeries+   AxisX 5        LiveCharts.Wpf.Axis  -   5          Name$ FeederOpenAxisX��5   '      Title$  ��6@      FontSize$ 18Q�6I      
Foreground
 �   �   Labels 6W   �� *FeederOpenLabels+6�      AxisY 5        -   5        $ FeederOpenAxisY��5   '   $  ��6@   $ 18Q�6J   
 �   �   LabelFormatter 6X   �� *FeederOpenFormatter+6�   5      5       5!      �� 5"      -	   5        $ 	FeederSP2��5"      $
��1600��6,   $	��480��69   $ Vertical=�6F   
�������$��0,30,0,0q�6p   .+�5#      �� $ 
Horizontal=�6!   .+�5$      �� -
   5        $ BtnLeft��5$   !    / +MaterialDesignFloatingActionMiniLightButton#��[ 6I    � ToolTip$ Previous Week��6�   $��	500,0,0,0q�6�   $
��Auto��6�   $
��Auto��6�   ��6�   Z� ��6�   Z� .��5%      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ChevronLeft=�66   $��40��6I   $��40��6U   5&      �� 5'      -   5        $	 FeederHeader2��5'   $   $��Bottom=�6;   $��Center=�6V   $
 Center=�6s   $(��"Feeder Mulfunctions Reason Week-21��6�   $��0,0,0,0q�6�   $��30(�6�   $
��Bold"�6�   $��WS Simple Gallifreyan)�6�   ���	#DD0000006  �� 5)      -   5        $ BtnRight��5)   !   #��[ 6K   $ 	Next Week��6�   $��0,0,0,0q�6�   $
��Auto��6�   $
��Auto��6�   ��6�   Z� ��6�   Z� .��5*        $ ChevronRight=�66   $��40��6J   $��40��6V   5+      5,      �� 5-      -   5        $ BtnFeederClose��5-      #���   61   $ Depth3=�6f   $ 50��6�   $	��400��6�   $
��1500��6�   $��0,10,0,0q�6�   
���������6  Z� .��5.        -   5        $ FeederReasonChart��5.   .   
���   �$	 Top=�6�   $	��399��6�   $
��1480��6�    6I   �� *FeederReasonSeries+ 50   "     -   5        $ FeederReasonAxisX��50   +   $  ��6F   $ 18Q�6O   
 �   � 6]   �� *FeederReasonLabels+6�    53   "     -   5        $ FeederReasonAxisY��53   +   $  ��6F   $ 18Q�6P   
 �   � 6^   �� *FeederReasonFormatter+6�   55      56      57      58      �� 59   
   -   5        $ 
TablesGrid��59      $y�Hidden=�6)   $ Vertical=�6=   $��1��6T   $��1��6a   .+�5:      �� -   5        $ TableSP1��5:      $
��1600��6+   $	��480��68   $ Vertical=�6E   $��0,0,0,0q�6\   .+�5;      �� -   5        $	 TableHeader1��5;      $��Center=�62   $
 Center=�6O   $!��Table Mulfunctions By Weeks��6f   $��0,20,0,0q�6�   $��30(�6�   $
��Bold"�6�   $��WS Simple Gallifreyan)�6�   ���	#DD0000006�   �� 5<      -   5        $ BtnTableOpen��5<      #���   6/   $ Depth3=�6d   $ 50��6�   $	��400��6�   $
��1500��6�   $��0,10,0,0q�6�   
���������6  Z� .��5=        -   5        $ TableOpenChart��5=   )   
���   �$	 Top=�6w   $	��375��6�   $
��1474��6�    6A   �� *TableOpenSeries+ 5?        -   5        $ TableOpenAxisX��5?   '   $  ��6?   $ 18Q�6H   
 �   � 6V   �� *TableOpenLabels+6�    5B        -   5        $ TableOpenAxisY��5B   '   $  ��6?   $ 18Q�6I   
 �   � 6W   �� *TableOpenFormatter+6�   5D      5E      5F      �� 5G      -   5        $ TableSP2��5G      $
��1600��6+   $	��480��68   $ Vertical=�6E   
�������$��0,20,0,0q�6o   .+�5H      �� $ 
Horizontal=�6!   .+�5I      �� -   5        $ TableBtnLeft��5I   !   #��[ 6S   $ Previous Week��6�   $��	500,0,0,0q�6�   $
��Auto��6�   $
��Auto��6�   ��6�   Z� ��6�   Z� .��5J        $ ChevronLeft=�66   $��40��6I   $��40��6U   5K      �� 5L      -   5        $	 TableHeader2��5L   $   $��Bottom=�6:   $��Center=�6U   $
 Center=�6r   $'��!Table Mulfunctions Reason Week-21��6�   $��0,0,0,0q�6�   $��30(�6�   $
��Bold"�6�   $��WS Simple Gallifreyan)�6�   ���	#DD0000006  �� 5N      -   5        $ TableBtnRight��5N   !   #��[ 6U   $ 	Next Week��6�   $��0,0,0,0q�6�   $
��Auto��6�   $
��Auto��6�   ��6�   Z� ��6�   Z� .��5O        $ ChevronRight=�66   $��40��6J   $��40��6V   5P      5Q      �� 5R      -   5        $ BtnTableClose��5R      #���   64   $ Depth3=�6i   $ 50��6�   $	��400��6�   $
��1500��6�   $��0,10,0,0q�6�   
���������6  Z� .��5S        -   5        $ TableReasonChart��5S   )   
���   �$	 Top=�6z   $	��375��6�   $
��1470��6�    6C   �� *TableCloseSeries+ 5U        -   5        $ TableCloseAxisX��5U   '   $  ��6@   $ 18Q�6I   
 �   � 6W   �� *TableCloseLabels+6�    5X        -   5        $ TableCloseAxisY��5X   '   $  ��6@   $ 18Q�6J   
 �   � 6X   �� *TableCloseFormatter+6�   5Z      5[      5\      5]      � 5_   
   $��1��6   ���	#FFBFBFBF 5`      �� 5a      $	��150 �6    �� 5b       J� Effect 5d      3  -System.Windows.Media.Effects.DropShadowEffect  5e         
BlurRadius$ 20Q�6#      Color$ 	#FFDEDEDE��63      RenderingBias$ Quality=�6E      ShadowDepth$ 1Q�6]   .+�5g      � ���	#FFBFBFBF.+�5h        $ GoogleAnalytics=�6*   $��Center=�6A   $��38��6\   $��6,0,0,35q�6h   $��49��6z   �� 5i      $��
Statistics��6   $��Center=�6.   $��Center=�6K   $��WS Simple Gallifreyan)�6f   
�������$��36(�6�   $��
52,0,10,30q�6�   �� 5j      -    5        $��72,87,81,21q�5j       + 'MaterialDesignFloatingActionLightButton#��[ 6.   $ Light/Dark Mode��6o   
����������	#FFACA8B2
���   �$
��Auto��6�   $
��Auto��6�   .��5k        $ ThemeLightDark=�6.   $��24��6D   $��24��6P   5l      5m      �� 5o      $��1��6   .+�5p      �� -!   5        $ 	FeederBtn��5p      $��	10,0,10,0q�6,   
����������	#FFACA8B2$ Depth4=�6j   
���   �.��5q      � $	��150��6   .+�5r        $ GoogleAnalytics=�62   $��Center=�6I   $��0,0,0,1q�6d   �� 5s      $��Center=�6$   $��Feeders��6A   $��Champagne & Limousines)�6P   $��	47,0,16,0q�6x   $��16(�6�   $��87��6�   5t      5u      �� 5v      -"   5        $ TableBtn��5v      $��
10,20,10,0q�6+   
����������	#FFACA8B2$ Depth4=�6j   
���   �.��5w      � $	��150��6   .+�5x        $ GoogleAnalytics=�62   $��Center=�6I   $��0,0,0,1q�6d   �� 5y      $��Center=�6$   $��Tables��6A   $��Champagne & Limousines)�6O   $��	47,0,16,0q�6w   $��16(�6�   $��87��6�   5z      5{      �� 5|      -#   5        $��
10,20,10,0q�5|      
����������	#FFACA8B2$ Depth4=�6X   
���   �.��5}      � $	��150��6   .+�5~        $ 	ExitToApp=�62   $��Center=�6C   �� 5      $��Center=�6$   $
��Exit��6A   $��Champagne & Limousines)�6M   $��16(�6u   5�      5�      5�      5�      � 5�   
   $��2��6   ���	#FFBFBFBF.+�5�      �� $ 
Horizontal=�6   $��Right=�62   $
��10,0q�6N   5�      5�      5�      5�      5�      