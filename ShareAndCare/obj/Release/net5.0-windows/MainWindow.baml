   M S B A M L   `   `   `  ���� G  CShareAndCare, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ShareAndCareShareAndCare  A%clr-namespace:ShareAndCare.ComponentsShareAndCare.Components      ShareAndCare.MainWindow   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:ShareAndCare     <
components%clr-namespace:ShareAndCare.Components       � 
ResizeMode$  CanMinimize=� � Title$ Chat and Files share��$	��300��$	��300��.��� ���#1687a7.+��� 
�������$��Center=�$��	0,20,0,-1q�$
��Bold"�$��24(�.��Chat and Files share�� $��	0,60,0,20q�.+��� 
�������$��Center=�$��Center=�   Labs#��[  ��Z� .��	Username:�� -    ��Name$ UsernameText��$	��200��$��Center=�$��5,0,0,0q����� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors$
 True��*   $ShareAndCare.Components.BindablePass     Password �� *
Password+$ PropertyChanged=� �� Mode$ TwoWay=���  �� Orientation$ 
Horizontal=�$��0,20,0,0q�$��Center=�$��Center=�.+��� -    ��Name$ LoginButton��$��50��
�������$��Center=�$
��Left=����� *LoginCommand+���� 	 �� RelativeSource	 �� *FindAncestor+
 �� AncestorType

 Window.��Login