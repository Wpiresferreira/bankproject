   M S B A M L   `   `   `  ����F  BBankProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:BankProject.UserControlsBankProject.UserControls  5      C&clr-namespace:BankProject.UserControlsBankProject.UserControls  5      -    'BankProject.UserControls.UcMakeTransfer   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5      /uc&clr-namespace:BankProject.UserControls  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      2local&clr-namespace:BankProject.UserControls  5      
������ $	��700��5	   9   $
��1000��6F   $
|�True��5
      .��5      ��   �� CornerRadius$  0��6   $��0q�6   ��5   
   �� 5       �� 
StartPoint$	 1,0&�6"    �� EndPoint$	 0,1&�63   .��5      �  � Color$ #41518f��6    � Offset$ 0Q�6/   � 5      $ #2c386c��6   $ 1Q�6/   5      ._�5   
   �  � ColumnDefinitions 5      �� 5      $��50 �6#   �� 5      $��* �6#   �� 5      $��50 �6#    � RowDefinitions 5      �� 5      $��50 �6    �� 5      $��* �6    �� 5      $��50 �6    .+�5"      � $��1��6   $��1��6#   .+�5%      �� $��10q�6      border_Wallet#��[  6%   ._�5&      �� $��10q�6!   .+�5(      �� -   5         ��Name$ Title��5(   $   $��Make Transfer��63   $��26(�6H   ���#ccd7ff$
��Left=�6k   $��
50 25 0 10q�6�   �� 5*      $  25��6!   $	��500��63   ���	#FF653BBD._�5+      � $��Center=�6#   $��Center=�6@   $��10 30 10 10q�6[    5,   "   �� 5-   &   $	��250 �67   �� 5.   &   $	��200 �67    50   "   �� 51   &   $
��auto �64   �� 52   &   $
��auto �64   �� 53   &   $
��auto �64   �� 54   &   $
��auto �64   .+�57   "   �� $��0��6,   $��0��69   $
|�True��6I   $��Account Id Origin:��6Z     text_Register#��[ 6t   
�������6�   �� 58   "   $��1��6,   $��0��69   $
|�True��6I   $��Account Id Destination:��6Z   #��[ 6y   
�������6�   �� 59   "   $��2��6,   $��0��69   $
|�True��6I   $��Amount To Transfer (CAD):��6Z   #��[ 6{   
�������6�   0   *BankProject.UserControls.UcTextBoxRegister  5<   "   -   5          Name$ myTextBoxAccountId��5<   7   $��1��6S   $��0��6c   	   Hint$	 12345��6p     5=   "   -   5        $ myTextBoxOtherAccountId��5=   7   $��1��6X   $��1��6h   $	 67890��6u     5>   "   -   5        $ myTextBoxAmountToTransfer��5>   7   $��1��6Z   $��2��6j   $	 100.00��6w   � 5A   "   $��1��6'   $��3��67   $��10 40 10 10q�6D    5B   &   �� 5C   *   $��* �6;   .+�5F   &   �� -   5        $��Make Transfer��5F   -   $	��150��6E   $��0q�6Q   $��1��6\     buttonMainGreen_Register#��[ 6l   6�   5G   #   5H      5J      5K      5L      5M      5N      5O      5P      