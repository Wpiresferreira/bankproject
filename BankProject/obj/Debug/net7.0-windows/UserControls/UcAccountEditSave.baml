   M S B A M L   `   `   `  ����F  BBankProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:BankProject.UserControlsBankProject.UserControls  5      C&clr-namespace:BankProject.UserControlsBankProject.UserControls  5      0    *BankProject.UserControls.UcAccountEditSave   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5      /uc&clr-namespace:BankProject.UserControls  5      2local&clr-namespace:BankProject.UserControls  5      
������ $	��700��5	   9   $
��1000��6F   $
|�True��5
      .��5      ��   �� CornerRadius$  0��6   $��0q�6   ��5   
   �� 5       �� 
StartPoint$	 1,0&�6"    �� EndPoint$	 0,1&�63   .��5      �  � Color$ #41518f��6    � Offset$ 0Q�6/   � 5      $ #2c386c��6   $ 1Q�6/   5      ._�5   
   �  � ColumnDefinitions 5      �� 5      $��50 �6#   �� 5      $��* �6#   �� 5      $��50 �6#   .+�5      � $��1��6   .+�5      �� $��20 50 20 50q�6      border_Wallet#��[  6.   ._�5       �� $��10 10 10 10q�6!   .+�5"      �� -   5         ��Name$ Title��5"   $   $��Manage Accounts��63   $��26(�6J   ���#ccd7ff$
��Left=�6m   $��
50 25 0 10q�6�   � 5$      $��Center=�6   $��Center=�6<   $��10 10 10 10q�6W    5%      �� 5&   "   $	��150 �63   �� 5'   "   $	��200 �63   �� 5(   "   $	��200 �63    � RowDefinitions 5+      �� 5,   "   $
��auto �60   �� 5-   "   $
��auto �60   �� 5.   "   $
��auto �60   �� 5/   "   $
��auto �60   �� 50   "   $
��auto �60   �� 51   "   $
��auto �60   �� 52   "   $
��auto �60   �� 53   "   $
��auto �60   .+�56      �� $��0��6(   $��
Account ID��65     text_Register#��[ 6G   
�������6n   �� 57      $��1��6(   $��Customer ID��65   #��[ 6H   
�������6o   �� 58      -   5        $ MyTextBlockCustomerName��58   (   $��	 10 0 0 0q�6I   $��1��6\   $��Customer Name��6i   $��2��6~   #��[ 6�   
�������6�   �� 59      $��2��6(   $��Account Type��65   #��[ 6I   
�������6p   �� 5:      $��3��6(   $��Monthly Fee��65   #��[ 6H   
�������6o   �� 5;      $��4��6(   $��Interest Rate��65   #��[ 6J   
�������6q   �� 5<      $��5��6(   $��Balance��65   #��[ 6D   
�������6k   0   *BankProject.UserControls.UcTextBoxRegister  5>      -   5          Name$ myTextBoxAccountId��5>   3   $��1��6O   $��0��6_     5?      -   5        $ myTextBoxCustomerId��5?   3   0   *BankProject.UserControls.UcTextBoxRegister	   	LostFocus$#	 myTextBoxCustomerId_LostFocus��6m   $��1��6P   $��1��6`   6m   �� 5@      -   5        
 ��Name$
 myTextBoxAccountType��5@   '   $��1��6E   $��2��6U   $��35��6b   $��
 0 10 0 10q�6n   .@�5A   "   �� .��6/   
CHEQUING69   �� 5B   "   .��6/   	SAVINGS68   5C        5D      -   5        $ myTextBoxMonthlyFee��5D   3   $��1��6P   $��3��6`     5E      -   5        $ myTextBoxInterestRate��5E   3   $��1��6R   $��4��6b     5F      -   5        $ myTextBoxBalance��5F   3   $��1��6M   $��5��6]   � 5J      $��1��6#   $��7��63   $��2��6@   $��10 40 10 10q�6T    5K   "   �� 5L   &   $��* �67   �� 5M   &   $��* �67   �� 5N   &   $��* �67   .+�5Q   "   �� -	   5        $��Cancel��5Q   )   $��0 0 10 0q�6:   $��0��6L     buttonMain_Register#��[ 6\   6�   �� 5R   "   -
   5        $
��Save��5R   )   $��	10 0 10 0q�68   $��1��6K     buttonMainGreen_Register#��[ 6[   6�   �� 5S   "   -   5         ��Name$ ButtonStatment��5S   )   $��Statment��6A   $��10 0 0 0q�6T   $��2��6f   #��[ 6v   6�   5T      5U      5V      5W      5X      5Y      5Z      5[      