   M S B A M L   `   `   `  ����G  CShareAndCare, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ShareAndCareShareAndCare  5   	   A%clr-namespace:ShareAndCare.ComponentsShareAndCare.Components  62       ShareAndCare.MainWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:ShareAndCare     5   	   <
components%clr-namespace:ShareAndCare.Components     62     � 
ResizeMode$  CanMinimize=�5   	    � Title$ Share and Care��5	   	   $	��300��6    $	��300��6-   .��5
      � ���#1687a7.+�5   
   �� 
�������$��Center=�6#   $��	0,20,0,-1q�6@   $
��Bold"�6S   $��24(�6e   .��6s   Chat and Files share6�   �� 5   
   $��	0,60,0,20q�6   .+�5      �� 
�������$��Center=�6=   $��Center=�6Z      Labs#��[  6u   ��6'   Z� .��6�   	Username:6�   �� 5      -   5         ��Name$ UsernameText��5      $	��200��6,   $��Center=�68   $��5,0,0,0q�6U   ��6f   �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors$
 True��6�   �� 5      
�������$��Center=�6=   $��Center=�6Z   #��[  6u   ��6'   Z� .��6�   	Password:6�   *   $ShareAndCare.Components.BindablePass  5      $	��200��6&   $��Center=�62   $��5,0,0,0q�6O      Password 6`   �� *Pass+$ PropertyChanged=� �� Mode$ TwoWay=�$
 True���� 5       �� Orientation$ 
Horizontal=�6   $��0,20,0,0q�62   $��Center=�6D   $��Center=�6a   .+�5      �� -   5         ��Name$ LoginButton��5      $��50��6.   
�������$��Center=�6L   $
��Left=�6g   ��6�   �� *LoginCommand+��6�   �� 	 �� RelativeSource	 �� *FindAncestor+
 �� AncestorType

 Window.��6  Login6	  5      5      5      5      