   M S B A M L   `   `   `  ����?  ;CRUD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:CRUD.View	CRUD.View  5      /clr-namespace:CRUD.ViewModelCRUD.ViewModel  5      %clr-namespace:CRUD.View	CRUD.View  5          CRUD.View.ProizvodiView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:CRUD.View     5      2	viewModelclr-namespace:CRUD.ViewModel     5      )viewsclr-namespace:CRUD.View     5      $	��550��5
      $	��750��6     � DataContext  5      '   !CRUD.ViewModel.ProizvodiViewModel  5   
   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid     
IsReadOnly . $��10,10,10,375q�6I      AutoGenerateColumns .  ��6   �� *proizvodnje+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6%      Header$ Id proizvodne masine��6/   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6M   �� *ProizvodjacIDMasina+  5      $ * 6%   $ Id proizvoda��6/    6E   �� *ProizvodIdProizvoda1+5      � 5   
   $
��Left=�6   $	��Top=�6*   $��
25,198,0,0q�6B    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      �� $��Id proizvodne masine:��6   $��0��64   $
��Left=�6D   $��3q�6_   $��0��6j   $��Center=�6w   �� 5      $��1��6   $
��Left=�6(   $��23��6C   $��3q�6O   $��0��6Z   $��Center=�6�   $	��120��6�   	 �� SelectedItem	 6g   �� *AddIdMasine+��6�   �� *sveMasineProizvodjaci+
 �� SelectedValue
 6�   �� *AddIdMasine+6�   �� 5       $��Id proizvoda:��6   $��0��6,   $
��Left=�6<   $��3q�6W   $��1��6b   $��Center=�6o   �� 5!      $��1��6   $
��Left=�6(   $��23��6C   $��3q�6O   $��1��6Z   $��Center=�6�   $	��120��6�   	 6g   �� *AddIdProizvoda+��6�   �� *sviProizvodi+
 6�   �� *AddIdProizvoda+6�   �� 5"      $��Dodaj��6   $��2��6F   $��56,58,70,-58q�6Z   $��1��6p   ��6%   �� *DodajCommand+6p   5#      � 5%   
   $
��Left=�6   $	��Top=�6*   $��310,197,0,0q�6B    5&      �� 5'      $
��Auto �6#   �� 5(      $
��Auto �6#    5*      �� 5+      $
��Auto �6    �� 5,      $
��Auto �6    .+�5.      �� $��
Id masine:��6   $��0��6)   $
��Left=�69   $��	-16,4,0,2q�6T   $��0��6g   $��Center=�6t   �� 5/      $��1��6   $
��Left=�6&   $��23��6A   $��3,4,0,5q�6M   $��0��6^   $��Center=�6�   $	��120��6�   ��6k   �� *DeleteIdMasine+6�   �� 50      $��Id proizvoda:��6   $��0��6,   $
��Left=�6<   $��	-16,4,0,2q�6W   $��1��6j   $��Center=�6w   �� 51      $��1��6   $
��Left=�6&   $��23��6A   $��3q�6M   $��1��6X   $��Center=�6�   $	��120��6�   ��6e   �� *DeleteIdProizvoda+6�   �� 53      $��Obrisi��6   $��31,55,30,-63q�6I   $��1��6_   $��2��6l   ��6&   �� *IzbrisiCommand+6l   54      55      56      