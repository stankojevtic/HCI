   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  5   	        WpfApplication1.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   +lclr-namespace:WpfApplication1     5   	     � Title$  Manifestacije grada��5   	   "   WpfApplication1.HelpProvider   HelpKey$ Dragg��6%   $	��500��6D   $	��700��6Q    � WindowStartupLocation$ CenterScreen=�6^    � Icon$0 */WpfApplication1;component/Images/2p4i.png��6�    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ ApplicationCommands.Help��5      6<     5	   
   -   5        $ l:MainWindow.OpenManifest��5	      6d     5
   
   -   5        $ l:MainWindow.OpenEtikete��5
      6e     5   
   -   5        $ l:MainWindow.OpenTipa��5      6b     5   
   -   5        $ l:MainWindow.OpenPregledM��5      6f     5   
   -   5        $ l:MainWindow.OpenPregledE��5      6f     5   
   -   5        $ l:MainWindow.OpenPregledT��5      6f   .��5      ]� .+�5   
   o� $	��Top=�6   ��5      �� 5      .R�5      ]� $��Stretch=�6    
�������6V   5      .@�5      m� $
��Unos��6   $��13(�6%   
�������.@�5      m� -   5        $��Nova manifestacija��5       m� InputGestureText$ CTRL + M��67   
���   ���5      �� 5      5       m� 5"      -	   5        $��Nova etiketa��5"      $ CTRL + E��61   
���   ���5#      �� 5$      5&      m� 5'      -
   5        $��Novi tip manifestacije��5'      $ CTRL + T��6;   
���   ���5(      �� 5)      5+      5-      m� 50      $��Pregled��6   $��13(�6(   
�������.@�51      m� -   5        $��Manifestacije��51      $ Alt + M��62   
���   ���52      �� 53      55      m� 57      -   5        $��Etikete��57      
���   �$ Alt + E��6?   ��58      �� 59      5;      m� 5<      -   5        $��Tipovi��5<      $ Alt + T��6+   
���   ���5=      �� 5>      5@      5B      m� 5D      -   5        $��Pomoć��5D      $��13(�6&   
���������5E      �� 5F      5I      m� 5K      $��	Tutorijal��6   $��13(�6*   $��Right=�68   
�������.@�5L      m� -   5        $��	Unos tipa��5L      
���   ���5M      �� 5N      5Q      5R      5T      � 5V   
   
���   � � ColumnDefinitions 5W      �� 5X      $
��122* �6#   �� 5Z      $
��556* �6#   .+�5\      �� -   5        $��listVju��5\      
�������$��0,20,0,0q�6K  ��6?   ��  �� Path$ manifestacijeZaDrag�	 �� SelectedItem	 6q   �� $ SelektovanaManifestacija���5]      �� 5^      .R�5_      � .+�5`      �� $��16��6A   $��16��6P   $��1q�6^   ��6$   �� *	ikonicaMa+6^   �� 5b      ��6(   �� *ID+
 � ToolTip
 6=   �� *Datum+5e      5f      5h      �� 5i      $��Visible=�6   $��0��6C   $��1��6P   .��5j      �� -   5        $��c��5j       J� 	AllowDrop . $
��1252��6�   $	��800��6�   .+�5k      �� $��images/ns.jpg��6   $
��1252��63   $
��Fill=�6@   $	��800��6O   6^   5l      5m      �� 5n      -   5        $��
textBlock1��5n   R   
���   �$��14��6+   $
��Left=�67   $��Manifestacije��6d    �� TextAlignment$ Center=�6y   
�������$	��Top=�6�   $	��122��6�   5o      5p      5r      