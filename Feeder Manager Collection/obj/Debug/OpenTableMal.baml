   M S B A M L   `   `   `  ����I  EFeeder Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Feeder_ManagerFeeder_Manager  5   	   !    Feeder_Manager.OpenTableMal   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Feeder_Manager     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Open Malfunction��5	   	   $	��530��6"   $��490.5��6/    � Topmost .  � 
ResizeMode$ NoResize=�6L    � WindowStartupLocation$ CenterScreen=�6b   $��Segoe UI Emoji)�6�   .��5
      � .+�5   
   �� ���	#FFC1BFD1$��2q�6)   6?   �� 5   
   $	��365��6   $	��Top=�6!   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FFC8CBCF��6#   � 5      $ 	#FFC1BFD1��6#    � Offset$ 1Q�65   � 5      $ White��6#   $ 0.546Q�61   5      5      �� 5   
   $��Open Malfunction��6   $��Center=�6+   $	��Top=�6H   $��0,10,0,0q�6`   $��36(�6r   $
��Bold"�6�   ���	#DD0000006�   �� 5   
   $	��332��6   $��Bottom=�6!   $��
35,0,35,81q�6<    �� RadiusY$ 10��6P   	 �� RadiusX$	 10��6]   
�������
 J� Effect
 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 15Q�6#      	Direction$ 0Q�63      RenderingBias$ Quality=�6A      ShadowDepth$ 1Q�6Y      Color$ 	#FFBBBBBB��6i   5      �� 5   
    �� Orientation$ Vertical=�6   $��35,77,35,76q�6,   .+�5      �� $ 
Horizontal=�6   $��0,30,0,0q�62   .+�5      �� $��Enter Table ID: ��6   $
��Left=�63   $	��Top=�6N   $��10,0,0,0q�6f   $��16(�6x   $
��Bold"�6�   �� 5      -   5         ��Name$ Table_ID��5      $�� ��6,   $
��Left=�64    �� TextAlignment$ Center=�6O   $	��Top=�6g   $	��150��6   $��70,0,0,0q�6�   $��16(�6�   $
��Bold"�6�   $��1q�6�   ���	#FFD4D2D26�   �� 5      -   5        $��10,0,0,0q�5       � Cursor$
 Hand��6\   ��6E   Z� ��5       �� 5!       �� ImageSource$ Resources/search.png��6%    j� Stretch$
 Fill=�6H   5#      5$      �� 5%      $ 
Horizontal=�6   $��0,10,0,0q�62   .+�5&      �� $��Table Type: ��6   $
��Left=�6/   $	��Top=�6J   $��10,0,0,0q�6b   $��16(�6t   $
��Bold"�6�   �� 5'      -   5        $ 
Table_Type��5'       �� 
IsReadOnly . $
��Left=�6@   $��Center=�6[   $��31��6   $��93,0,0,0q�6�   $	��Top=�6�   $	��191��6�   $��18(�6�   $
��Bold"�6�   $��1q�6�   ���	#FFD4D2D26�   5(      �� 5)      $ 
Horizontal=�6   $��0,10,0,0q�62   .+�5*      �� $��Table Status: ��6   $
��Left=�61   $	��Top=�6L   $��10,0,0,0q�6d   $��16(�6v   $
��Bold"�6�   �� 5+      -   5        $ Table_Status��5+       . $ Center=�6B   $
��Left=�6Y   $	��Top=�6t   $	��191��6�   $��83,0,0,0q�6�   $��16(�6�   $
��Bold"�6�   $��1q�6�   ���	#FFD4D2D26�   5,      �� 5-      $ 
Horizontal=�6   $��0,10,0,0q�62   .+�5.      �� $��Malfunction Count: ��6   $
��Left=�66   $	��Top=�6Q   $��10,0,0,0q�6i   $��16(�6{   $
��Bold"�6�   �� 5/      -   5        $ MalCount��5/       . $ Center=�6>   $
��Left=�6U   $	��Top=�6p   $	��191��6�   $��36,0,0,0q�6�   $��16(�6�   $
��Bold"�6�   $��1q�6�   ���	#FFD4D2D26�   50      �� 51      $ 
Horizontal=�6   $��0,10,0,0q�62   .+�52      �� $��Operator ID: ��6   $
��Left=�60   $	��Top=�6K   $��10,0,0,0q�6c   $��16(�6u   $
��Bold"�6�   �� 53      -   5        $ 
OperatorID��53      $ Center=�6/   $
��Left=�6F   $	��Top=�6a   $	��191��6y   $��86,0,0,0q�6�   $��16(�6�   $
��Bold"�6�   $��1q�6�   ���	#FFD4D2D26�   54      �� 55      $ 
Horizontal=�6   $��0,10,0,0q�62   .+�56      �� $��Malfunction Type: ��6   $
��Left=�65   $	��Top=�6P   $��10,0,0,0q�6h   $��16(�6z   $
��Bold"�6�   �� 57      -   5         ��Name$ Mal_Type��57      $
��Left=�6-   $��Center=�6H   $��31��6l   $��45,0,0,0q�6x   $	��Top=�6�   $	��191��6�   $��14(�6�   $
��Bold"�6�   $��1q�6�   ���	#FFD4D2D26�   58      59      �� 5:   
   $ 
Horizontal=�6   $��	0,436,0,0q�6.   .+�5;      �� -   5        $��OK��5;      $
��Left=�6"   $��	145,0,0,0q�6N   $��Center=�6a   $��80��6|   $��30��6�   ���	#FFC1BFD1���	#FFC1BFD1
���   �$
��Bold"�6�   �� 5<      -	   5         ��Name$ CloseBtn��5<      $��Cancel��6'   $
��Left=�68    �� IsCancel . $��25,0,0,0q�6c   $��Center=�6u   $��80��6�   $��30��6�   ���	#FFC1BFD1���	#FFC1BFD1
���   �$
��Bold"�6�   5=      5>      5?      