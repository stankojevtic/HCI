   M S B A M L   `   `   `  ����  WpfApplication1#    WpfApplication1.PregledTipova   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  PregledTipova��5   	   $	��363��6   $	��636��6,    � WindowStartupLocation$ CenterScreen=�68    � Icon$0 */WpfApplication1;component/Images/2p4i.png��6v   .��5      �  � RowDefinitions 5   
   �� 5	      $
��163* �6   �� 5
      $
��161* �6    � ColumnDefinitions 5   
   �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgrMain��5         
IsReadOnly .    AutoGenerateColumns .  $��0,0,0,27q�6|   ��6$   ��  �� Path$ listaTipova�	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$	
 ID:��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 62   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *id+6W     5      $

 Ime:��6&   $	 100 64    6@   �� *ime+6Z   4  .System.Windows.Controls.DataGridTemplateColumn  5      $
 Ikonica��6)   $
 auto 6:      CellTemplate 5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6)   $��Center=�6B   .+�5   "   �� $
��Fill=�6I   $��40��6X   $��40��6c   ��6)   �� $ ikonica�6q   5      5      5      5      � 5    
   -   5        $��dgrMain1��5       $��0��6   $��1��6/    � DataContext 6<   ��  �� ElementName$ dgrMain��$ SelectedItem� 5!      �� 5"      $
��Auto �6    �� 5#      $
��Auto �6    �� 5$      $
��Auto �6    �� 5%      $
��Auto �6    �� 5&      $
��Auto �6    �� 5'      $��13 �6    �� 5(      $	��83* �6     5*      �� 5+      $��52 �6#   �� 5,      $
��562* �6#   .+�5.      �� $��0��6   $��0��6(   $
�� ID:��65   6C   �� 5/      $��0��6   $��1��6(   $�� Ime:��65   6D   �� 50      $��2��6   $��22��6%   $�� Opis:��61   6A   �� 51      $��6��6   $��	0,0,562,0q�6%   $��2��68   $��	 Ikonica:��6L   6_   �� 55      -   5        $��idOdSelektovanog��55      $��1��6.   $��	0,0,350,0q�6W   ��6>   �� $ id�6l   �� 56      -   5        $��imeOdSelektovanog��56      $��1��6/   $��1��6?   $��	0,0,350,0q�6f   ��6L   �� $	 ime�6{   �� 57      $��1��6   $��2��6'   $��	0,0,350,0q�6O   ��64   �� $
 opis�6d   �� 58      $��1��6   $��6��6$   $��
6,0,504,45q�6L   ��61   �� *	ikonica+6c   �� 59      -   5        $��button1��59   s   $��Obrisi��6   $��1��6(   $��27��68   $
��Left=�6D   $��
270,17,0,0q�6_   $	��Top=�6�   $��57��6�   $��2��6�   6�   �� 5:      -   5        $��button2��5:   t   $��Izmeni��6   $��2��6(   $��27��69   $
��Left=�6E   $��
350,17,0,0q�6`   $	��Top=�6�   $��57��6�   $��1��6�   6�   �� 5;      -   5        $��border1��5;   ^   $��1q�6   $��5��6*   $��57��67   $
��Left=�6C   $	��Top=�6m   $	��170��6�   $��2��6�   $��2��6�   �� 5<      -	   5        $��button3��5<   u   $��Novi tip��6   $��2��6)   $��27��6:   $
��Left=�6F   $��
433,17,0,0q�6a   $	��Top=�6�   $��91��6�   $��1��6�   6�   5=      5>      5?      