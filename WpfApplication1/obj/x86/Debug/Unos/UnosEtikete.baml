   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  5   
   !    WpfApplication1.UnosEtikete   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   X TXceed.Wpf.Toolkit, Version=2.7.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   %lclr-namespace:WpfApplication1  5   
     � Title$  UnosEtikete��5   	   $	��300��6   $	��500��6*    � WindowStartupLocation$ CenterScreen=�66    � Icon$0 */WpfApplication1;component/Images/2p4i.png��6[    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ ApplicationCommands.Help��5      6<     5	   
   -   5        $ l:UnosEtikete.Escape��5	      6b    � 	Resources 5         fancyButtonStyle �� 
TargetType �� Property �� Value	 �� 
TargetType
 �� CornerRadius F�Name �� Stretch ��Name �� Triggers P� Property P� Value �� 
TargetName��%�  &	        �� 5   
   " ��6)   .�5      ��  � �� �#3737376+   �� 5       � ��
 ��ح�6+   �� 5       � ��$ 20(�6)   �� 5       �@J�SnapsToDevicePixels . 64   �� 5       � �� 5      �� 5      "	 ��6&   .R�5      �� $
 4��6!   #��z��62   ._�5      � .+�5   "   F� $ PathIcon��6'   $��15��69   $��25��6D   $
 Fill=�6P   ���#4C87B3$
��Left=�6n   $��17,0,0,0q�6�   4�������<R���=�x�O���Tn5����<R6�   �� 5   "   $ MyContentPresenter��63   #��z��6O   $��Center=�6s   $��Center=�6�   $��0,0,0,0q�6�   5      5       5      P� 5       �@J�IsMouseOver . . �5   "   ��  � �� �#E594006?   �� 5   "    � ��
 �����6?   �� 5    "   $ PathIcon��6)    � ��
 �   �6O   5!      P� 5#       � �� . . �5$   "   ��  � ��
 � E��6?   �� 5%   "    � ��
 �����6?   5&      5(      5*      5+      5,      .��5-      � $��LeftToRight=�6#    � DataContext 6   ��  � RowDefinitions 5.   
   �� 5/      $	��45* �6   �� 50      $	��46* �6   �� 51      $	��62* �6   �� 52      $	��57* �6   �� 53      $	��50* �6    � ColumnDefinitions 56   
   �� 57      �� 58      .+�5:   
   �� $��Center=�6   $��Center=�6/   $��15(�6L   $��
52,12,60,1q�6Z   $	��127��6n   $��32��6z   Unesite ID etikete:6�   �� 5;   
   -   5        $��	idEtikete��5;   /   "   WpfApplication1.HelpProvider   HelpKey$	 IDE��6   $��1��6@   $��Center=�6P   $��0,12,110,12q�6k   $��1��6�   6�   �� 5=   
   $��1��6   $��Center=�6"   $��Center=�6=   $��15(�6Z   $��33��6h   $��
52,11,54,2q�6t   Unesite opis etikete:6�   �� 5>   
   -   5        $��opisEtikete��5>   E    �� TextWrapping$
 Wrap=�6   $ OpisE��6&   $��1��6X   $��1��6e   $��Center=�6u   $��
0,12,30,46q�6�   $��2��6�   $��51��6�   $��2��6�   6�   �� 5@   
   $��2��6   $��Center=�6!   $��Center=�6<   $��15(�6Y   $��28��6g   $��
52,34,52,0q�6s   Unesite boju etikete:6�   #  Xceed.Wpf.Toolkit.ColorPicker  5A   
   -   5        $��bojaEtikete��5A      $	��Top=�6/    J� RenderTransformOrigin$ 2.587,2.691&�6G   $��
0,33,110,0q�6k   $��1��6   $��2��6�   $��3��6�   �� 5C   
   -   5        $��3��5C      $��2��6   $��151,46,159,12q�62   $��2��6^   #��[  6o   $��4��6�   .��6�   	Potvrdi6�   �� 5D   
   -   5        $��
textBlock1��5D   _   $��1��6   $��21��6$   $
��Left=�60   $��
136,13,0,0q�6K   
���  ��$	��Top=�6�   $	��104��6�   ��6q   �� *
GreskaID+6�   �� 5E   
   -   5        $��
textBlock2��5E   l   $��1��6   $��2��6$   $��23��61   $
��Left=�6=   $��
136,31,0,0q�6X   
���  ��$	��Top=�6�   $	��103��6�   ��6~   �� *
GreskaBoja+6�   5G      5H      