   M S B A M L   `   `   `  ����I  EFeeder Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Feeder_ManagerFeeder_Manager  5   	   "    Feeder_Manager.ChangeMalType   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Feeder_Manager     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        � Title$  Change Malfunction Type��5	   	   $	��232��6)   $	��453��66    � Topmost .  � 
ResizeMode$ NoResize=�6Q    � WindowStartupLocation$ CenterScreen=�6g   $��Segoe UI Emoji)�6�   .��5
      � .+�5   
   �� ���	#FFC1BFD1$��2q�6)   6?   �� 5   
   $	��202��6   $	��Top=�6!   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FFC8CBCF��6#   � 5      $ 	#FFC3C2CB��6#    � Offset$ 1Q�65   � 5      $ White��6#   $ 0.546Q�61   5      5      �� 5   
   $	��113��6   $��Bottom=�6!   $��
35,0,35,62q�6<    �� RadiusY$ 10��6P   	 �� RadiusX$	 10��6]   
�������
 J� Effect
 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 15Q�6#      	Direction$ 0Q�63      RenderingBias$ Quality=�6A      ShadowDepth$ 1Q�6Y      Color$ 	#FFBBBBBB��6i   5      �� 5   
    �� Orientation$ Vertical=�6   $��0,0,0,0q�6,   .+�5      �� $ Vertical=�6   $��0,45,0,0q�60   .+�5      �� $��Choose Type��6   $��Center=�6.   $	��Top=�6K   $��0,0,0,0q�6c   $��16(�6t   $
��Bold"�6�   �� 5      -   5         ��Name$ Mal_Type��5      $��Center=�6-   $��Center=�6J   $��31��6n   $��0,5,0,0q�6z   $	��Top=�6�   $	��191��6�   $��14(�6�   $
��Bold"�6�   $��1q�6�   ���	#FFD4D2D26�   5      �� 5      $ 
Horizontal=�6   $��0,40,0,0q�62   $��42��6D   .+�5       �� -   5        $��Ok��5       $
��Left=�6&   $��	135,0,0,0q�6S   $��Center=�6f   $��80��6�   $��30��6�   
����������	#FFC1BFD1
���   �$
��Bold"�6�   �� 5!      -   5         ��Name$ CloseBtn��5!      $��Cancel��6+   $
��Left=�6<    �� IsCancel . $��25,0,0,0q�6g   $��Center=�6y   $��80��6�   $��30��6�   
����������	#FFC1BFD1
���   �$
��Bold"�6�   5"      5#      5%      5&      