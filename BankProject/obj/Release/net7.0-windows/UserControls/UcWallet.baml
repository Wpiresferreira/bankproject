   M S B A M L   `   `   `  ����   BankProject'    !BankProject.UserControls.UcWallet   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  
������ $	��700��$
��1000��.����   �� CornerRadius$  0��$��0q�����  �� 
StartPoint$	 1,0&� �� EndPoint$	 0,1&�.���  � Color$ #41518f�� � Offset$ 0Q�� $ #2c386c��$ 1Q�._��  � ColumnDefinitions �� $��* ��� $��* �.+�� $��0��.+��� $��20 120 20 20q�   border_Wallet#��[  ._��� $��10 88 10 20q�.+��� $��Transfer�����#fcfcfc �� TextAlignment$ Center=�$��34(�$��SemiBold"�� $��	0 12 0 22q� �� $��* ��� $��* �.+��� $
��Send��  activeTabButton_Wallet#��[ �� $��	Apply for��$��1��  tabButton_Wallet#��[ �� $��Pay to��  textLabel_Wallet#��[ �� $��0 10 0 5q� �� TextAlignment$ Center=�$,��&fh897623fg82bfi2g89724bg42gf29n42ht947��  textBoxMain_Wallet#��[ �� $��9(����#e0e0e0$ Center=� J� Opacity$	 0.5Q�$��0 0 0 20q�$2��,Please enter the wallet or destination email���  �� $��* ��� $��* �	 � RowDefinitions	 �� $
��auto ��� $��* ��� $��* �.+��� $��Amount��#��[ �� $��1��$��	0 10 5 20q�$��$300.00��#��[ �� $��Reason��$��1��#��[ �� $��1��$��1��$��	5 10 0 20q�$��Pay for games��#��[ �� $��Comission: $3��$��2��$��0 4 0 3q�#��[ �� $��Total: $300.00��$��2��$��0 4 0 3q�$��1��#��[ ��   sendButton_Wallet#��[ .���� 
 �� Orientation$
 
Horizontal=�.+�"  FontAwesome.WPF.ImageAwesome     Icon$ SendOutline=�$��Center=�  WhiteIcon_Wallet#��[ �� $
��Send��$��10 0 0 0q�$��SemiBold"��� $��
90 40 90 0q�  cardBorder_Wallet#��[ ���� $	 0,0&�$	 1,1&�.��� $ #d489ff��$
 -0.2Q�� $ #7985ff��$	 0.5Q�� $ #6ad8fd��$ 1Q�._�� .+�  $ Exchange=�$
��Left=�$	��Top=�   
Foreground
 �����$	 0.9Q�$��25��$��15 8 0 0q��� $
 
Horizontal=�$	��Top=�$��Right=�.+�  $ CheckCircle=�$��Right=�$	��Top=�
 �����$��25��$��0 5 10 0q��� -    ��Name$ nameCard��$��John Doe��$
��Bold"�$��12(�
�������$��Right=�$	��Top=�$��0 8 10 0q��� $
 
Horizontal=�$��Center=�$��Center=�.+��� $
��1234��  bankCardNumber_Wallet#��[ �� $
��5678��#��[ �� $
��9012��#��[ �� $
��3456��#��[ �� $��
$ 8,520.00��#��[ $��20(�$��SemiBold"�$��Bottom=�$��13 0 0 5q��� $��1��$��0 0 20 0q�.+��� $
 
Horizontal=�$��Right=�$��
20 40 20 0q�.+���  	 topMenuButton_Wallet#��[	 $��10 0 0 0q�$	��300��$��50��.���� $
 
Horizontal=�.+�  $ Sliders=� 
 topMenuIcon_Wallet#��[
 �� $��Add Filters��$��Center=�$��14(�$��8 0 0 0q��� #��[	 $��10 0 0 0q�.��  $ BellOutline=�#��[
 �� #��[	 $��10 0 0 0q�.��  $ Search=�#��[
 �� #��[ $��
20 31 20 0q����� $	 0,0&�$	 1,1&�.��� $ #9085fa��$ 0Q�� $ #c77aff��$ 1Q�._�� .+��� $��Balance��#��[ $	��Top=�$��15 8 0 0q�$��14(�$��SemiBold"��� $��
$ 8,520.00��#��[ $��Center=�$��	15 8 0 10q�$��24(�$��SemiBold"��� $	��Top=�$��Right=�$��0 8 10 0q�.+���   fillButton_Wallet#��[ .��  $ Dollar=�#��[ $��10��$��10���� #��[ $��0 5 0 0q�.��  $ Percent=�#��[ $��10��$��10���� $
 
Horizontal=�$��Bottom=�$��15 0 0 5q�.+��� #��[ .��  $ ArrowUp=�#��[ $��10��$��10���� $��
+ $ 620.12��#��[ $��	10 0 20 0q�$��SemiBold"�$��Center=��� #��[ .��  $ 	ArrowDown=�#��[ $��10��$��10���� $��
+ $ 920.12��#��[ $��10 0 0 0q�$��SemiBold"�$��Center=��� #��[  $��20q�._�� $��15 13q� �� $
��auto ��� $
��auto ��� $��* �	 �� $��* ��� $��* ��� $��* �.+��� $��Information�����#fcfcfc$��16(�$��SemiBold"�$��0 0 0 18q�$��3����   button_Wallet#��[ $��Right=�$	��Top=�$��3��.��  $
 Edit=�#��[ $��14��$��12��  $ 	MapMarker=�#��[ $��1��$	��Top=�  $ Folder=�#��[ $��2��$	��Top=��� $��	Address: ��#��[ $��1��$��1��$��
10 0 10 18q��� $��Wallet ID: ��#��[ $��2��$��1��$��	10 0 10 0q��� $
��Peru��#��[ $��1��$��2���� $'��!901hbr9137bhgf9123btg912t7tgb13bt��#��[ $��2��$��2���� #��[  $��	20 0 20 0q�._�� $��15 10q� �� $
��auto ��� $
��auto ��� $��* �	 �� $��* ��� $��* ��� $��* ��� $��* �.+��� $��Security�����#fcfcfc$��16(�$��SemiBold"�$��3��$��0 0 0 15q��� #��[ $��Right=�$	��Top=�$��3��.��  $ 	EllipsisH=�#��[ $��14��$��12��  $ Shield=�#��[ $��1��$��Center=�  $	 Key=�#��[ $��2��$��Center=�  $
 Lock=�#��[ $��3��$��Center=��� $��2FA Enabled��#��[ $��1��$��1��$��10 0 0 0q�$��Center=��� $	��Key��#��[ $��2��$��1��$��10 0 0 0q�$��Center=��� $��Password��#��[ $��3��$��1��$��10 0 0 0q�$��Center=��� #��[ $��Right=�$��Center=�$��2��$��1��$��Change��$	��0 5q��� #��[ $��Right=�$��Center=�$��2��$��2��$��Change��$	��0 5q��� #��[ $��Right=�$��Center=�$��2��$��3��$��Change��$	��0 5q�