   M S B A M L   `   `   `  ����I  EFeeder Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Feeder_ManagerFeeder_Manager  5   	       Feeder_Manager.Export   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Feeder_Manager     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Excel Export��5	   	   $��549.244��6   $��452.729��6/    � Topmost .  � 
ResizeMode$ NoResize=�6N    � WindowStartupLocation$ CenterScreen=�6d   $��Segoe UI Emoji)�6�   .��5
      � .+�5   
   �� ���	#FF33288B$��2q�6)   6?   �� 5   
   $	��365��6   $	��Top=�6!   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FFC8CBCF��6#   � 5      $ 	#FFC1BFD1��6#    � Offset$ 1Q�65   � 5      $ White��6#   $ 0.546Q�61   5      5      '  !MaterialDesignThemes.Wpf.PackIcon  5   
      Kind$ MicrosoftExcel=�6"   $��60��68   $��60��6C   $	��Top=�6O   $��Center=�6g   $��0,10,0,0q�6�   
�������6�   �� 5   
   $	��367��6   $��Bottom=�6!   $��
35,0,35,76q�6<   	 �� RadiusY$	 10��6P   
 �� RadiusX$
 10��6]   
������� J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 15Q�6#      	Direction$ 0Q�63      RenderingBias$ Quality=�6A      ShadowDepth$ 1Q�6Y      Color$ 	#FFBBBBBB��6i   5      �� 5   
    �� Orientation$ Vertical=�6   $��35,77,35,76q�6,   .+�5      �� $��Choose File��6   $��Center=�6*   $	��Top=�6G   $��0,10,0,0q�6_   $��36(�6q   $
��Bold"�6   ���	#DD0000006�   �� 5      $ 
Horizontal=�6   $��0,20,0,0q�62   .+�5      �� $
��From��6   $
��Left=�6'   $	��Top=�6B   $��90,0,0,0q�6Z   $
��Bold"�6l   $��16(�6~   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ dp��5      $
��Left=�6)   $��10,0,0,0q�6D   $	��Top=�6V   $	��139��6n   $��16(�6z   $��1q�6�   5       �� 5!      $ 
Horizontal=�6   $��0,20,0,0q�62   .+�5"      �� $��To��6   $
��Left=�6%   $	��Top=�6@   $��90,0,0,0q�6X   $
��Bold"�6j   $��16(�6|     5#      -   5        $	 dp2��5#      $
��Left=�6*   $��30,0,0,0q�6E   $	��Top=�6W   $	��139��6o   $��16(�6{   $��1q�6�   5$      �� 5%      -   5         ��Name$ 
AllFedders��5%      $��All Feeders��6+   $
��Left=�6A   $	��Top=�6\   $��	90,20,0,0q�6t   $
��Bold"�6�   $��14(�6�   �� 5&      -   5        $ 	AllTables��5&      $��
All Tables��6*   $
��Left=�6?   $	��Top=�6Z   $��	90,20,0,0q�6r   $
��Bold"�6�   $��14(�6�   �� 5'      -   5        $ FeedersMalfunctions��5'      $��Feeders Malfunctions��64   $
��Left=�6S   $	��Top=�6n   $��	90,20,0,0q�6�   $
��Bold"�6�   $��14(�6�   �� 5(      -   5        $ TablesMalfunctions��5(      $��Tables Malfunctions��64   $
��Left=�6R   $	��Top=�6m   $��	90,20,0,0q�6�   $
��Bold"�6�   $��14(�6�   $y�Visible=�6�   5)      �� 5*   
   $ 
Horizontal=�6   $��	0,450,0,0q�6.   .+�5+      �� -   5        $��OK��5+      $
��Left=�6"   $��	135,0,0,0q�6T   $��Center=�6g   $��80��6�   $��30��6�   ���	#FFC1BFD1���	#FFC1BFD1$��16(�6�   �� 5,      -   5         ��Name$ CloseBtn��5,      $��Cancel��6'   $
��Left=�68    �� IsCancel . $��25,0,0,0q�6c   $��Center=�6u   $��80��6�   $��30��6�   ���	#FFC1BFD1���	#FFC1BFD1$��16(�6�   5-      5.      5/      