   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  5   	   $    WpfApplication1.PregledEtiketa   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   X TXceed.Wpf.Toolkit, Version=2.7.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   &ccclr-namespace:WpfApplication1  5   	     � 
ResizeMode$  NoResize=�5   	    � Title$ PregledEtiketa��5   	   $	��363��6    $	��636��6-    � WindowStartupLocation$ CenterScreen=�69    � Icon$0 */WpfApplication1;component/Images/2p4i.png��6^   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��148* �6   �� 5      $
��176* �6    � ColumnDefinitions 5   
   �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgrMain��5         
IsReadOnly .    AutoGenerateColumns .  $��0,0,0,11q�6}   ��6$   �� 	 �� Path$	 listaEtiketa�
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$	 ID:��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 62   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *id+6W     5      $ Opis:��6&   $	 100 65    6A   �� *opis+6\   5      � 5   
   $��1��6   $��0,6,0,0q�6[    � DataContext 6   ��  �� ElementName$ dgrMain��$	 SelectedItem� 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5       $
��Auto �6    �� 5!      $��4 �6    �� 5"      $��2 �6    �� 5#      $
��156* �6     5%      �� 5&      $
��Auto �6#   �� 5'      .+�5)      �� $��
0,6,-1,140q�6   $��7��6,   ID:6B   �� 5*      $��6��6   $��	0,34,0,84q�6%   Opis:6?   �� 5+      $��6��6   $��0,88,0,6q�6%   Boja:6>   �� 5.      -   5        $��idOdSelektovanog��5.      $��1��6.   $��37,6,492,134q�6W   $��6��6m   ��6>   �� $	 id�6|   �� 5/      $��1��6   $��6��6&   $��36,34,451,96q�6N   ��63   �� $
	 opis�6f   �� 51      -   5        $��border1��51   �   $��1q�6   $��1��6*   $��6��6Y   $��35��6f   $
��Left=�6r   $��	38,88,0,0q�6�   $	��Top=�6�   $��58��6�   ��6:   �� *	imeBoje+6�   �� 52      -   5        $��border2��52   R   $��1q�6   $	��140��6*   $
��Left=�67   $	��Top=�6a   $	��200��6y   $��6��6�   $��2��6�   �� 53      -   5        $��button1��53      $��Izmeni��6   $��1��6'   $��6��67   $��28��6D   $
��Left=�6P   $��
307,82,0,0q�6k   $	��Top=�6�   $��57��6�   6�   �� 54      -   5        $��button2��54   n   $��Obrisi��6   $��6��6&   $��28��63   $
��Left=�6?   $��
218,82,0,0q�6Z   $	��Top=�6}   $��57��6�   $��1��6�   6�   �� 55      -   5        $��button3��55   t   $��Nova etiketa��6   $��6��6,   $��28��69   $
��Left=�6E   $��
393,82,0,0q�6`   $	��Top=�6�   $��90��6�   $��1��6�   6�   56      57      58      