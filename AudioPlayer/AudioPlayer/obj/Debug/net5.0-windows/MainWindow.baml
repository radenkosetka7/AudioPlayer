   M S B A M L   `   `   `  ����F  BAudioPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:AudioPlayerAudioPlayer  5   	       AudioPlayer.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:AudioPlayer     5   	   _ [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  61     � Title$  
MainWindow��5   	   $	��650��6   $	��400��6)    � WindowStartupLocation$ CenterScreen=�65    � WindowStyle$
 None=�6Z    � 
ResizeMode$ NoResize=�6m    � AllowsTransparency$
 True��6�   ��6�   Z� .��5	      � .+�5
   
   r� -   5        $��mePlayer��5
      $��1��6'    r� LoadedBehavior$ Manual=�64    r� Stretch$
 None=�6L   #  MaterialDesignThemes.Wpf.Card  5   
   $��10q�6      UniformCornerRadius$ 20Q�6*   ��6C   Z� .��5      �� ��5      �� 5       �� 
StartPoint$ 0.1,0&�6*   	 �� EndPoint$	 0.3,1&�6=   .��5      � 
 � Color$
 #121212��6'    � Offset$ 1Q�67   � 5      $
 #292929��6'   $ 0Q�67   5      .+�5      � $��70��6   .+�5      �� -   5         ��Name$ btnFile��5   �    $   MaterialDesignFlatAccentBgButton#��[  6   $
��Left=�6W   $
��20 0q�6r    � ToolTip$ 	Open File��6�   .��5      �� $��-5q�6%   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Plus=�66   $��20��6B   $��20��6M   5      5      �� 5      -   5        $ btnClose��5   �   #��[  6   $��Right=�6W   $
��20 0q�6s   $ Close��6�   .��5      �� $��-5q�6%   .+�5        $ Close=�66   $��20��6C   $��20��6N   5      5      5      �� 5      -   5         ��Name$ Image��5   1   $��10q�6   $	��200��6$   $��Uniform=�6@   $H��BD:\\BAZE_PODATAKA\\AudioPlayer\\AudioPlayer\\assets\\MusicIcon.png��6R   �� 5       -   5         ��Name$ lblSongname��5    �   $��10q�6   $��19(�6(   $��	Song name��66   
������� �� TextAlignment$ Center=�6Z   $  ��6q   $��SemiBold"�6�   6�   � 5!      $��0 30 0 0q�6   .+�5"      �� -   5         ��Name$ lblCurrenttime��5"   �   $��11(�6   $
��20 0q�6+   
�������$��
ExtraLight"�6L   $
��Left=�6e   6�   �� 5#      -   5        $ lblMusiclength��5#      $��11(�6   $
��20 0q�6*   
�������$��
ExtraLight"�6K   $��Right=�6c   6   5$      �� 5%      -   5         ��Name$ TimerSlider��5%   l    �� TickPlacement$
 Both=�6    � Minimum$ 1Q�6.    � Maximum$ 50Q�6:   $
��20 0q�6G   ���	#FF7311016�   � 5&      $��Center=�6   $
��0 30q�69   .+�5'      �� -	   5        $ btnStop��5'   �   ${�False��6   #��[  6/   $
��Left=�6i   $
��10 0q�6�   $ 	Stop Song��6�   .��5(      �� $��-5q�6%   .+�5)        $
 Stop=�66   $��20��6B   $��20��6M   5*      5+      �� 5,      -
   5        $ 
btnPRewind��5,   �   ${�False��6   #��[  6/   $��Right=�6i   $
��10 0q�6�   $ Play Previous��6�   .��5-      �� $��-5q�6%   .+�5.        $ SkipPrevious=�66   $��20��6J   $��20��6U   5/      50      �� 51      -   5        $ btnPlay��51   �   ${�False��6   #��[  6/   $��Right=�6i   $
��10 0q�6�   $
 Play��6�   .��52      �� $��-5q�6%   .+�53        $
 Play=�66   $��20��6B   $��20��6M   54      55      �� 56      -   5        $ btnPause��56   �   ${�False��6   #��[  6/   $
��Left=�6i   $��-52 0q�6�   $ Pause��6�   .��57      �� $��-5q�6%   .+�58        $ Pause=�66   $��20��6C   $��20��6N   59      5:      �� 5;      -   5        $ btnPNext��5;   �   ${�False��6   #��[  6/   $��Right=�6i   $
��10 0q�6�   $ 	Play Next��6�   .��5<      �� $��-5q�6%   .+�5=        $ SkipNext=�66   $��20��6F   $��20��6Q   5>      5?      �� 5@      -   5        $ 	btnRepeat��5@   �   ${�False��6   #��[  6/   $��Right=�6i   $
��10 0q�6�   $ Repeat Turn On��6�   .��5A      �� $��-5q�6%   .+�5B        $ Repeat=�66   $��20��6D   $��20��6O   5C      5D      5E      �� 5F      -   5         ��Name$ Songs��5F      $��Bottom=�6)   $	��100��6D   $��5q�6Q   
����İ�5H      5I      5J      5K      5M      