   M S B A M L   `   `   `  ����F  BBankProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:BankProject.UserControlsBankProject.UserControls  5      C&clr-namespace:BankProject.UserControlsBankProject.UserControls  5      /    )BankProject.UserControls.UcCustomerSearch   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5      /uc&clr-namespace:BankProject.UserControls  5      2local&clr-namespace:BankProject.UserControls  5      
������ $	��700��5	   9   $
��1000��6F   $
|�True��5
      .��5      ��   �� CornerRadius$  0��6   $��0q�6   ��5   
   �� 5       �� 
StartPoint$	 1,0&�6"    �� EndPoint$	 0,1&�63   .��5      �  � Color$ #41518f��6    � Offset$ 0Q�6/   � 5      $ #2c386c��6   $ 1Q�6/   5      ._�5   
   �  � ColumnDefinitions 5      �� 5      $��50 �6#   �� 5      $��* �6#   �� 5      $��50 �6#   .+�5      � $��1��6   .+�5      �� $��20 50 20 50q�6      border_Wallet#��[  6.   ._�5       �� $��10 10 10 10q�6!   .+�5"      �� -   5         ��Name$ Title��5"   $   $��Customer Search��63   $��26(�6J   ���#ccd7ff$
��Left=�6m   $��
50 25 0 10q�6�   � 5$      $��Center=�6   $��Center=�6<   $��10 10 10 10q�6W    5%      �� 5&   "   $	��150 �63   �� 5'   "   $	��200 �63    � RowDefinitions 5)      �� 5*   "   $
��auto �60   �� 5+   "   $
��auto �60   �� 5,   "   $
��auto �60   �� 5-   "   $
��auto �60   �� 5.   "   $
��auto �60   �� 5/   "   $
��auto �60   �� 50   "   $
��auto �60   �� 51   "   $
��auto �60   .+�54      �� $��0��6(   $��Customer ID��65     text_Register#��[ 6H   
�������6o   �� 55      $��1��6(   $��2��65   $��-- or --��6I   #��[ 6Y   
�������6�   �� 56      $��2��6(   $
|�True��65   $��
First Name��6F   #��[ 6X   
�������6�   �� 57      $��3��6(   $
|�True��65   $��	Last Name��6F   #��[ 6W   
�������6   �� 58      $��4��6(   $
|�True��65   $��Date of Birth��6F   #��[ 6[   
�������6�   0   *BankProject.UserControls.UcTextBoxRegister  5:      -   5          Name$ myTextBoxCustomerID��5:   3   0   *BankProject.UserControls.UcTextBoxRegister	   KeyDown$!	 myTextBoxCustomerID_KeyDown��6P   $��1��6v   $��0��6�     5;      -   5        $ myTextBoxFirstName��5;   3   $ 	 myTextBoxFirstName_KeyDown��6O   $��1��6t   $��2��6�     5<      -   5        $ myTextBoxLastName��5<   3   $	 myTextBoxLastName_KeyDown��6N   $��1��6r   $��3��6�   (  "System.Windows.Controls.DatePicker  5=      -   5        
  Name$
 myTextBoxDataOfBirth��5=   )   $��1��6n   $��4��6~   � 5@      $��1��6#   $��7��63   $��10 40 10 10q�6@    5A   "   �� 5B   &   $��* �67   �� 5C   &   $��* �67   .+�5F   "   �� -   5        $��Search��5F   )   $��0 0 10 0q�6:   $��0��6L     buttonMain_Register#��[ 6\   6�   �� 5G   "   -   5        $	��New��5G   )   $��10 0 0 0q�67   $��1��6I     buttonMainGreen_Register#��[ 6Y   6�   5H      5I      5J      5K      5L      5M      5N      5O      