   M S B A M L   `   `   `  ����F  BBankProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:BankProject.UserControlsBankProject.UserControls  5      :    4BankProject.UserControls.UcListCustomersFromMyBranch   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:BankProject.UserControls     5      
������ $	��700��5   9   $
��1000��6F   $
|�True��5      .��5      ��   �� CornerRadius$  0��6   $��0q�6   ��5   
   �� 5       �� 
StartPoint$	 1,0&�6"    �� EndPoint$	 0,1&�63   .��5      �  � Color$ #41518f��6    � Offset$ 0Q�6/   � 5      $ #2c386c��6   $ 1Q�6/   5      ._�5   
   �  � ColumnDefinitions 5      �� 5      $��50 �6#   �� 5      $��* �6#   �� 5      $��50 �6#    � RowDefinitions 5      �� 5      $��50 �6    �� 5      $��* �6    �� 5      $��50 �6    .+�5       � $��1��6   $��1��6#   .+�5#      �� $��10q�6      border_Wallet#��[  6%   $	��580��6L   ._�5$      �� $��10q�6!   .+�5&      �� -   5         ��Name$ Title��5&   $   $#��List Customers From My Branch��63   $��26(�6X   ���#ccd7ff$
��Left=�6{   $��
50 25 0 10q�6�   �� 5)      -   5        $ textBlockBranchId��5)   $   $��Current Branch: ��6?   $��20(�6W   ���#ccd7ff$
��Left=�6z   $��
50 25 0 10q�6�   �� 5+      $  25��6!   ���	#FF653BBD$
��1000��6J   ._�5,      �� -   5        $'��!listViewListCustomersFromMyBranch��5,   3   $��10q�6'   $	��350��6\    �� View 5-   "   �� 5.   &   .P�5/   *   �� $��
CustomerId��69   	 �� Width$	 70��6M   
 �� DisplayMemberBinding
 6X   �� *
CustomerId+�� 50   *   $��	FirstName��69   $		 100��6L   
 6X   �� *	FirstName+�� 51   *   $��LastName��69   $		 100��6K   
 6W   �� *
LastName+�� 52   *   $��Email��69   $		 100��6H   
 6T   �� *Email+�� 53   *   $��Phone��69   $		 100��6H   
 6T   �� *Phone+�� 54   *   $��dateOfBirth��69   $		 100��6N   
 6Z   �� *DateOfBirth+57   '   59      5:      5;      5<      5=      5>      5?      5@      