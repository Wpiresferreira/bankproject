   M S B A M L   `   `   `  ����F  BBankProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:BankProjectBankProject  5   	   C&clr-namespace:BankProject.UserControlsBankProject.UserControls  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5	   	       BankProject.WindowFrame   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:BankProject     5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5   	   /uc&clr-namespace:BankProject.UserControls  5   	   >lvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf  5	   	   -   5        $	��850��5
      $
��1250��6'     � WindowStartupLocation$  CenterScreen=�64    � WindowStyle$
 None=�5   	    � AllowsTransparency$
 True��6   
������  � Title$ Our Bank - Main Screen��5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��250 �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��1��6.   $��Right=�6>   $	��Top=�6Z    K� ZIndex$ 1��6r   $��0 0 10 0q�6�   .+�5      �� -   5        $ ��../Images/IconMinimize.png��5      $��20��68      iconWindowTopRight#��[  6C   6o   �� 5      -   5        $��../Images/IconClose.png��5      $��20��65   #��[  6@   6l   5      �� 5   
    �� CornerRadius$ 	10 0 0 10��6   ��5      �� 5       �� 
StartPoint$ 0.5,0&�6&   	 �� EndPoint$	 0.5,1&�69   .��5      � 
 � Color$
 #223266��6#    � Offset$ 0Q�63   � 5      $
 #27396b��6#   $ 1Q�63   5       5#      �� 5%   
   -   5         ��Name$ buttonsList��5%      .+�5'      �� $ 
Horizontal=�6   $��Center=�62   $��0 35 0 0q�6O   .+�5(      �� $ 10��6   $��40��6+   $��40��66   ��5)      �� 5*      $	 0,0&�6.   $		 0,2&�6?   .��5+      � $
 #7f7cf1��6+   $ 0Q�6;   � 5,      $
 #d3b7ff��6+   $ 1Q�6;   5-      ._�5/      �� -   5         ��Name$ initialsMenu��5/       $��JD��66   ���#ffffff$��22(�6U   $��SemiBold"�6c    �� TextAlignment$ Center=�6y   $��Center=�6�   $��3 0 0 2q�6�   50      �� 51      $��10 0 0 0q�6   $��Center=�6/   .+�52      �� -   5        $ nameMenu��52       $��John Doe��62   $��15(�6B   $��0 0 0 5q�6P   ���#c2cfff6a   �� 53      -   5        $ lowerTextMenu��53       $��Beta 1.3��67   $��11(�6G   ���#7788bf6U   54      55      �� 57      $	��0.8��6   $��20 30q�6%   ���#46558a64   �� 5F      -   5          menuButton_Frame#��[ 5F      .��5G      �� $ 
Horizontal=�6   .+�5H      "  FontAwesome.WPF.ImageAwesome     Icon$
 BanK=�6&     menuButtonIcon_Frame#��[ 62   �� 5I      $��Create New Branch��6      menuButtonText_Frame#��[ 69   5J      5K      �� 5L      -	   5        #��[ 5L      .��5M      �� $ 
Horizontal=�6   .+�5N        $
 List=�6&   #��[ 62   �� 5O      $��List Branches��6    #��[ 65   5P      5Q      �� 5R      -
   5        #��[ 5R      .��5S      �� $ 
Horizontal=�6   .+�5T        $ ListAlt=�6&   #��[ 65   �� 5U      $#��List Customers From My Branch��6    #��[ 6E   5V      5W      �� 5X      -   5        #��[ 5X      .��5Y      �� $ 
Horizontal=�6   .+�5Z        $ UserPlus=�6&   #��[ 66   �� 5[      $��Create New Employee��6    #��[ 6;   5\      5]      �� 5^      -   5        #��[ 5^      .��5_      �� $ 
Horizontal=�6   .+�5`        $ AddressCardOutline=�6'   #��[ 6A   �� 5a      $��Customer Search��6    #��[ 67   5b      5c      �� 5g      -   5        #��[ 5g      .��5h      �� $ 
Horizontal=�6   .+�5i        $ Money=�6&   #��[ 63   �� 5j      $��Manage Accounts��6    #��[ 67   5k      5l      �� 5m      -   5        #��[ 5m      .��5n      �� $ 
Horizontal=�6   .+�5o        $ ArrowCircleDown=�6&   #��[ 6=   �� 5p      $��Make Deposit��6    #��[ 64   5q      5r      �� 5s      -   5        #��[ 5s      .��5t      �� $ 
Horizontal=�6   .+�5u        $ ArrowCircleUp=�6&   #��[ 6;   �� 5v      $��Make Withdraw��6    #��[ 65   5w      5x      �� 5y      -   5        #��[ 5y      .��5z      �� $ 
Horizontal=�6   .+�5{        $ ArrowsH=�6&   #��[ 65   �� 5|      $��Make Transfer��6    #��[ 65   5}      5~      �� 5�      ���#e0e0e0 J� Opacity$	 0.8Q�6-   $��40 15 40 15q�6;   �� 5�      -   5        #��[ 5�      .��5�      �� $ 
Horizontal=�6   .+�5�        $ PowerOff=�6&   #��[ 66   �� 5�      $��Logout��6    #��[ 6.   5�      5�      5�      �� 5�   
   -   5        $��1��5�      $ 	0 10 10 0��6!   ��5�      �� 5�      $	 1,0&�6&   $		 0,1&�67   .��5�      � $
 #41518f��6#   $ 0Q�63   � 5�      $
 #2c386c��6#   $ 1Q�63   5�      ._�5�      �� -   5         ��Name$ tabControl_Frame��5�      $��	0 50 5 20q�63   $��0q�6F   
������ 6Z   5�      5�      5�      