   M S B A M L   `   `   `  ����?  ;CRUD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:CRUD.View	CRUD.View  5      /clr-namespace:CRUD.ViewModelCRUD.ViewModel  5      %clr-namespace:CRUD.View	CRUD.View  5          CRUD.View.ProizvodView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:CRUD.View     5      2	viewModelclr-namespace:CRUD.ViewModel     5      )viewsclr-namespace:CRUD.View     5      $	��550��5
      $	��750��6     � DataContext  5      &    CRUD.ViewModel.ProizvodViewModel  5   
   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid     
IsReadOnly . $��10,10,10,375q�6G      AutoGenerateColumns .  ��6   �� *	proizvodi+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6%      Header$ Id proizvoda��6/   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   �� *IdProizvoda+  5      $ * 6%   $ Naziv��6/    6>   �� *Naziv+  5      $ * 6%   $ Vrsta��6/    6>   �� *Vrsta+  5      $ * 6%   $ Paket id��6/    6A   �� *PaketIdPaketa+5      � 5   
   $
��Left=�6   $	��Top=�6*   $��
10,180,0,0q�6B    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5       $
��Auto �6    �� 5!      $
��Auto �6    �� 5"      $
��Auto �6    �� 5#      $
��Auto �6    �� 5$      $
��Auto �6    �� 5%      $
��Auto �6    .+�5'      �� $��Id proizvoda:��6   $��0��6,   $
��Left=�6<   $��3q�6W   $��0��6b   $��Center=�6o   �� 5(      $��1��6   $
��Left=�6&   $��23��6A   $��3q�6M   $��0��6X   $��Center=�6|   $	��120��6�   ��6e   �� *AddId+6�   �� 5)      $��Naziv:��6   $��0��6%   $
��Left=�65   $��3q�6P   $��1��6[   $��Center=�6h   �� 5*      $��1��6   $
��Left=�6&   $��23��6A   $��3q�6M   $��1��6X   $��Center=�6   $	��120��6�   ��6e   �� *
AddNaziv+6�   �� 5+      $��Vrsta:��6   $��0��6%   $
��Left=�65   $��3q�6P   $��2��6[   $��Center=�6h   �� 5,      $��1��6   $
��Left=�6&   $��23��6A   $��3q�6M   $��2��6X   $��Center=�6   $	��120��6�   ��6e   �� *
AddVrsta+6�   �� 5-      $��
Id paketa:��6   $��0��6)   $
��Left=�69   $��3q�6T   $��3��6_   $��Center=�6l   �� 5.      $��1��6   $
��Left=�6(   $��23��6C   $��3q�6O   $��3��6Z   $��Center=�6�   $	��120��6�   	 �� SelectedItem	 6g   �� *AddIdPaketa+��6�   �� *	sviPaketi+
 �� SelectedValue
 6�   �� *AddIdPaketa+6�   �� 5/      $��Dodaj��6   $��2��6F   $��56,75,70,-75q�6Z   $��4��6p   ��6%   �� *DodajCommand+6p   50      � 51   
   $
��Left=�6   $	��Top=�6*   $��271,180,0,0q�6B    52      �� 53      $
��Auto �6#   �� 54      $
��Auto �6#    56      �� 57      $
��Auto �6    �� 58      $
��Auto �6    �� 59      $
��Auto �6    �� 5:      $
��Auto �6    �� 5;      $
��Auto �6    �� 5<      $
��Auto �6    �� 5=      $
��Auto �6    .+�5?      �� $��Id proizvoda:��6   $��0��6,   $
��Left=�6<   $��3q�6W   $��0��6b   $��Center=�6o   �� 5@      $��1��6   $
��Left=�6&   $��23��6A   $��3q�6M   $��0��6X   $��Center=�6   $	��120��6�   ��6e   �� *
UpdateId+6�   �� 5A      $��Naziv:��6   $��0��6%   $
��Left=�65   $��3q�6P   $��1��6[   $��Center=�6h   �� 5B      $��1��6   $
��Left=�6&   $��23��6A   $��3q�6M   $��1��6X   $��Center=�6�   $	��120��6�   ��6e   �� *UpdateNaziv+6�   �� 5C      $��Vrsta:��6   $��0��6%   $
��Left=�65   $��3q�6P   $��2��6[   $��Center=�6h   �� 5D      $��1��6   $
��Left=�6&   $��23��6A   $��3q�6M   $��2��6X   $��Center=�6�   $	��120��6�   ��6e   �� *UpdateVrsta+6�   �� 5E      $��
Id paketa:��6   $��0��6)   $
��Left=�69   $��3q�6T   $��3��6_   $��Center=�6l   �� 5F      $��1��6   $
��Left=�6(   $��23��6C   $��3q�6O   $��3��6Z   $��Center=�6�   $	��120��6�   	 6g   �� *UpdateIdPaketa+��6�   �� *	sviPaketi+
 6�   �� *UpdateIdPaketa+6�   �� 5G      $��Izmeni��6   $��2��6J   $��50,37,64,-69q�6^   $��6��6t   ��6&   �� *AzurirajCommand+6t   5H      � 5I   
   $
��Left=�6   $	��Top=�6*   $��552,262,0,0q�6B    5J      �� 5K      $
��Auto �6#   �� 5L      $
��Auto �6#    5N      �� 5O      $
��Auto �6    �� 5P      $
��Auto �6    .+�5R      �� $��
Id paketa:��6   $��0��6)   $
��Left=�69   $��	-16,4,0,2q�6T   $��0��6g   $��Center=�6t   �� 5S      $��1��6   $
��Left=�6&   $��23��6A   $��3q�6M   $��0��6X   $��Center=�6   $	��120��6�   ��6e   �� *
DeleteId+6�   �� 5U      $��Obrisi��6   $��24,10,37,-43q�6I   $��1��6_   $��2��6l   ��6&   �� *IzbrisiCommand+6l   5V      5W      5X      