   M S B A M L   `   `   `  ����I  EFeeder Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Feeder_ManagerFeeder_Manager  5   	       Feeder_Manager.Users   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Feeder_Manager     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Users��5	   	   $��588.467��6   $��495.698��6(    � Topmost .  � WindowStartupLocation$ CenterScreen=�6G    � 
ResizeMode$ NoResize=�6l   .��5
      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FFC1BFD1��6    � Offset$ 0Q�61   � 5      $ White��6   $ 1Q�6-   5      .+�5   
   �� -   5         ��Name$ MainGrid��5      	 �� Orientation$	 Vertical=�6'   $y�Visible=�6>   .+�5      &   System.Windows.Controls.DataGrid  -   5        
  Name$
 EmpGrid��5      $��Center=�6(      
IsReadOnly . $	��244��6W   $��0,10,0,0q�6d   $	��Top=�6v   $	��460��6�      SelectionUnit$ FullRow=�6�      AutoGenerateColumns .  $��14(�6�   
�������   CanUserAddRows .  $��0q�63     	RowHeight$ 37Q�6G     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ UserID��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *UserID+6T     5      $
 Name��6)   $
 Auto 6T    67   �� *
UserName+6T     5      $ Password��6)   $
 Auto 6X    6;   �� *
Password+6X     5      $
 Role��6)   $ * 6P    67   �� *Role+6P   5      �� 5      $��0,10,0,0q�6   $	 
Horizontal=�6+   $
��Auto��6D   .+�5      �� $	 Vertical=�6   .+�5      �� -   5         ��Name$ NameTxt��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$
 Name��6/    %  !MaterialDesignFloatingHintTextBox#��[  6U   $��Center=�6�   $��10,0,0,0q�6�   $��52��6�   $	��200��6�   $��16(�6�   �� 5      -   5        $ WNTxt��5      $ Work Number��6-   #��[  6z   $��Center=�6�   $��10,0,0,0q�6�   $��52��6�   $	��200��6�   $��16(�6�   �� 5      -   5        $ PassTxt��5      $ Password��6/   #��[  6Y   $��Center=�6�   $��10,0,0,0q�6�   $��52��6�   $	��200��6�   $��16(�6�   �� 5      -   5         ��Name$ RoleCB��5      $
 Role��6/    & "MaterialDesignFloatingHintComboBox#��[ 6�   $��Center=�6�   $��10,0,0,0q�6�   $��52��6�   $	��200��6  $��16(�6  ��6U   �� *#!LongListToTestComboVirtualization+6  5       �� 5!      -   5         ��Name$ 
ProfileImg��5!      $
��Left=�6,   $	��155��6G   $��	70,30,0,0q�6T   $	��Top=�6g   $	��149��6   $y�Visible=�6�   5"      �� 5#      $	 
Horizontal=�6   $��0,30,0,0q�62   .+�5$      �� -   5         ��Name$ AddBtn��5$      $	��Add��6)   $
��Left=�67   $��25,0,0,0q�6d   $	��Top=�6v   $��86��6�   $��30��6�    J� RenderTransformOrigin$ 1.526,0.538&�6�   ���	#FFC1BFD1���	#FFC1BFD1
���   �6�   �� 5%      -	   5        $ delBtn��5%      $��Delete��6)   $
��Left=�6;   $��5,0,0,0q�6k   $	��Top=�6|   $��86��6�   $��30��6�   $ 
1.74,0.696&�6�   ���	#FFC1BFD1���	#FF040404���	#FFC1BFD16�   �� 5&      -
   5        $ 	UpdateBtn��5&      $��Update��6,   $
��Left=�6>   $��5,0,0,0q�6n   $	��Top=�6   $��86��6�   $��30��6�   $ 
1.74,0.696&�6�   
���   ����	#FFC1BFD1���	#FFC1BFD16�   �� 5'      -   5        $ clrBtn��5'      $��Clear��6)   $
��Left=�69   $��5,0,0,0q�6h   $	��Top=�6y   $��86��6�   $��30��6�   $ 
1.74,0.696&�6�   
���   ����	#FFC1BFD1���	#FFC1BFD16�   �� 5(      -   5        $ CloseBtn��5(      $��Close��6+   $
��Left=�6;   $��5,0,0,0q�6j   $	��Top=�6{   $��75��6�   $��30��6�   $ 
1.74,0.696&�6�   ���	#FFC1BFD1���	#FFC1BFD1
���   �6�   5)      5*      5+      5,      