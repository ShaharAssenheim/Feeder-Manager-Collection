   M S B A M L   `   `   `  ����I  EFeeder Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Feeder_ManagerFeeder_Manager  5   	       Feeder_Manager.EditFeeder   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Feeder_Manager     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        � Title$  Add New Feeder��5   	   $��529.622��6    $��452.729��61    � Topmost .  � 
ResizeMode$ NoResize=�6P    � WindowStartupLocation$ CenterScreen=�6f   $��Segoe UI Emoji)�6�   .��5	      � .+�5
   
   �� ���	#FFC1BFD1$��2q�6)   6?   �� 5   
   $	��365��6   $	��Top=�6!   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FFC8CBCF��6#   � 5      $ 	#FFC1BFD1��6#    � Offset$ 1Q�65   � 5      $ White��6#   $ 0.546Q�61   5      5      �� 5   
   $��Edit Feeder��6   $��Center=�6&   $	��Top=�6C   $��0,10,0,0q�6[   $��36(�6m   $
��Bold"�6{   ���	#DD0000006�   �� 5   
   $	��332��6   $��Bottom=�6!   $��
35,0,35,81q�6<    �� RadiusY$ 10��6P   	 �� RadiusX$	 10��6]   
�������
 J� Effect
 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 15Q�6#      	Direction$ 0Q�63      RenderingBias$ Quality=�6A      ShadowDepth$ 1Q�6Y      Color$ 	#FFBBBBBB��6i   5      �� 5   
    �� Orientation$ Vertical=�6   $��52,77,35,76q�6,   .+�5      �� $ 
Horizontal=�6   $��0,30,0,0q�62   .+�5      �� $��Feeder ID: ��6   $
��Left=�6.   $	��Top=�6I   $��10,0,0,0q�6a   $��16(�6s   $
��Bold"�6�   �� 5      -   5         ��Name$ 	Feeder_ID��5      $
��Left=�6-    �� TextAlignment$ Center=�6H   $	��Top=�6`   $	��191��6x   $��52,0,0,0q�6�   $��16(�6�   $
��Bold"�6�   $��1q�6�   ���	#FFD4D2D26�   5      �� 5      $ 
Horizontal=�6   $��0,20,0,0q�62   .+�5       �� $��	User ID: ��6   $
��Left=�6,   $	��Top=�6G   $��10,0,0,0q�6_   $��16(�6q   $
��Bold"�6   �� 5!      -   5        $ User_ID��5!      $
��Left=�6+   $ Center=�6F   $	��Top=�6]   $	��191��6u   $��69,0,0,0q�6�   $��16(�6�   $
��Bold"�6�   $��1q�6�   ���	#FFD4D2D26�   5"      �� 5#      $ 
Horizontal=�6   $��0,20,0,0q�62   .+�5$      �� $��Feeder Type: ��6   $
��Left=�60   $	��Top=�6K   $��10,0,0,0q�6c   $��16(�6u   $
��Bold"�6�   �� 5%      -   5        $ Feeder_Type��5%      $
��Left=�6/   $��Center=�6J   $��31��6n   $��33,0,0,0q�6z   $	��Top=�6�   $	��191��6�   $��18(�6�   $
��Bold"�6�   $��1q�6�   ���	#FFD4D2D26�   5&      �� 5'      $ 
Horizontal=�6   $��0,20,0,0q�62   .+�5(      �� $��Feeder Sensor: ��6   $
��Left=�62   $	��Top=�6M   $��10,0,0,0q�6e   $��16(�6w   $
��Bold"�6�   �� 5)      -   5         ��Name$ Feeder_Sensor��5)      $
��Left=�62   $��Center=�6M   $��31��6q   $��19,0,0,0q�6}   $	��Top=�6�   $	��191��6�   $��18(�6�   $
��Bold"�6�   $��1q�6�   ���	#FFD4D2D2.@�5*      �� $	��Yes��6#   $��Center=�61   �� 5+      $��No��6#   $��Center=�61   5,      5-      �� 5.      $ 
Horizontal=�6   $��0,20,0,0q�62   .+�5/      �� $��Feeder Status: ��6   $
��Left=�62   $	��Top=�6M   $��10,0,0,0q�6e   $��16(�6w   $
��Bold"�6�   �� 50      -   5        $ Fedder_Status��50       �� 
IsReadOnly . $ Center=�6C   $
��Left=�6Z   $	��Top=�6u   $	��191��6�   $��23,0,0,0q�6�   $��16(�6�   $
��Bold"�6�   $��1q�6�   ���	#FFD4D2D26�   51      �� 52      $ 
Horizontal=�6   $��0,20,0,0q�62   .+�53      �� $��Calibration Date: ��6   $
��Left=�65   $	��Top=�6P   $��10,0,0,0q�6h   $��16(�6z   $
��Bold"�6�   �� 54      -   5        $ Calibration_Date��54       . $ Center=�6F   $
��Left=�6]   $	��Top=�6x   $	��191��6�   $��5,0,0,0q�6�   $��16(�6�   $
��Bold"�6�   $��1q�6�   ���	#FFD4D2D26�   55      56      �� 57   
   $ 
Horizontal=�6   $��	0,436,0,0q�6.   .+�58      �� -   5         ��Name$ OKBtn��58      $
��Save��6$   $
��Left=�63   $��	145,0,0,0q�6_   $��Center=�6r   $��80��6�   $��30��6�   ���	#FFC1BFD1���	#FFC1BFD1
���   �$
��Bold"�6�   �� 59      -   5        $ CloseBtn��59      $��Cancel��6'   $
��Left=�68    �� IsCancel . $��25,0,0,0q�6c   $��Center=�6u   $��80��6�   $��30��6�   ���	#FFC1BFD1���	#FFC1BFD1
���   �$
��Bold"�6�   5:      5;      5<      