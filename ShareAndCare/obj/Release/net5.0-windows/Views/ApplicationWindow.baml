   M S B A M L   `   `   `  ���� G  CShareAndCare, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:ShareAndCare.ViewsShareAndCare.Views  +clr-namespace:ShareAndCareShareAndCare  *    $ShareAndCare.Views.ApplicationWindow   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     2local clr-namespace:ShareAndCare.Views     -local1clr-namespace:ShareAndCare       � Title$  Chat and Files share��$��512.8��$��819.2�� � 	Resources    roundbutton �� 
TargetType A�Name �� Triggers P� Property P� Value �� 
TargetName �� Property	 �� Value��%�   &	        �� " ��.R�� .+�A� $ backgroundElement��#��z��#��z���� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 true��. ��� $ backgroundElement�� � ��
	 �����
 J� InputBindings
 ��  �� Gesture$ Enter�� �� Command �� *SendCommand+.��� ���#1687a7 � RowDefinitions �� $��50 ��� $��* �.+��� $��0,5,0,0q� �� Orientation$ 
Horizontal=�$��Right=�.+��� $
��Left=�$��Bottom=�$��18(�
�������  Labs#��[ ���� *
Username+�� $
��Left=�$��45��$��45��#��[  ���� *LogOffCommand+����  �� RelativeSource �� *FindAncestor+ �� AncestorType
 Window.��	Log off�� $��1��$��Center=�$��
0,10,0,-10q�.@��� $��Files��.��� ���	#FFE5E5E5 � ColumnDefinitions �� $	��51* ��� $
��353* ��� $
��403* � �� $��50 ��� $��* ��� $	��100 �.+��� $��Your files:��$��18(�$��2��$��0,0,0,265.2q�$��2��#��[ �� $��1��$��0,0.4,20,0.2q�$��2������ *Files+ �� View �� .P��� $��	File name�� �� DisplayMemberBinding �� *
FileName+�� $��	File path�� �� *
FilePath+�� $��Remove�� �� CellTemplate �� .R��� $��Delete������ *DataContext.DeleCommand+ ��  ListView���� �� $	��Top=�$��2��$ 
Horizontal=�$��	0,9.8,0,0q�$��2��.+��� $	��100��$��5,0,0,0q����� *
FilePath+ �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors$
 True���� $	��5,0q����� *ChooseCommand+.��	Choose...�� $	��5,0q����� *
AddCommand+.��Add�� $��2��$��Files from other people:��$��18(�$��0,0,0.2,265.2q�$��2��#��[ �� $��2��$��1��$��0,0.4,0.2,0.2q����� *	Friends+ �� .P��� $��File's name�� �� *
FileName+�� $��File's path�� �� *
FilePath+�� $
��Chat��.��� ���	#FFE5E5E5 �� $	��270 ��� $��* �.+�� $��1�� �� $��* ��� $��60 �.+��� ���� *Msg+�� $��1��$ 
Horizontal=�$��Center=�$��20q�.+��� $	��400������ *	Message+$ PropertyChanged=�$
 True���� $��5,0,0,0q����� *SendCommand+.��Send�� ���� *People+ �� .P��� $��Friend�� �� *
Username+�� $	��Add�� �� .R��� $	��Add������ *DataContext.AddFriendCommand+ ��  ListView���� 