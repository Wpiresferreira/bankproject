   M S B A M L   `   `   `  ����   BankProject    BankProject.WindowLogin   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -     �Name$  LoginScreen�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=� � AllowsTransparency$
 True��
������  � Title$ [Login Window]��$	��500��$	��800��.���  � ColumnDefinitions �� $��* ��� $
��1.5* �.+���  �� Orientation$ 
Horizontal=�$��1��$��Right=�$	��Top=� K� ZIndex$ 1��.+��� -   $ ��../Images/IconMinimize.png��$��20��   iconWindowTopRight#��[  �� -   $��../Images/IconClose.png��$��20��#��[  ��  �� CornerRadius$ 	10 0 0 10������ 	 �� 
StartPoint$		 0,0&�
 �� EndPoint$	
 1,1&�.���  � Color$ #3AA9AD�� � Offset$ 0Q�� $ #3AADA1��$ 0Q�._�� .+��� .+��  � Points �    -1��� ;X�����#4EB1B6� ' �    �� �� ���� ��
�����#4EB1B6A� $��250 450 0 0q�$��40��$��40�����#4EB1B6A� $��
50 400 0 0q�$��20��$��20�����#4EB1B6�� $��Center=�.+��� $��Sign Up��  titleText_Login#��[ �� $@��:Enter your personal info and create new account to connect��  normalText_Login#��[  J� Opacity$	 0.8Q�$��20 30q��� -   $��Register��  buttonRegister_Login#��[ �� -   ���#ffffff$��1��$ 	0 10 10 0��._��� $��Center=�.+��� $��Sign in to App��#��[ ���#3AB19B$��0 0 0 40q��� $��1q����#ACB0AF$
��70 7q�$ 5��._�� $	��7 9q� �� $
��auto ��� $��* �.+��� $��../Images/IconEmail.png��$��20���� -    ��Name$ textBlockEmail��$��Email��  textHint_Login#��[ �� -    ��Name$ textBoxEmail��  textBox_Login#��[ �� $��1q����#ACB0AF$
��70 7q�$ 5��._�� $	��7 9q� �� $
��auto ��� $��* �.+��� $��../Images/IconLock.png��$��20���� -   $ textBlockPassword��$��Password��#��[ G� -	    G�Name$ textBoxPassword��#��[ �� -
    ��Name$ ButtonSignIn��$��Sign In��  mainButton_Login#��[ 