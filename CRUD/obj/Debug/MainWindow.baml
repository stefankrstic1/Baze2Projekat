   M S B A M L   `   `   `  ����?  ;CRUD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:CRUDCRUD  5   	   /clr-namespace:CRUD.ViewModelCRUD.ViewModel  5   	   %clr-namespace:CRUD.View	CRUD.View  5	   	       CRUD.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:CRUD     5   	   2	viewModelclr-namespace:CRUD.ViewModel     5   	   )viewsclr-namespace:CRUD.View     5	   	     � Title$  
MainWindow��5
   	   $	��600��6   $	��800��6)    � DataContext 5      (   "CRUD.ViewModel.MainWindowViewModel  5   
    � 	Resources 5       �� DataType$   CRUD.ViewModel.RadnikViewModel   CRUD.View.RadnikView%   CRUD.ViewModel.MagacinViewModel   CRUD.View.MagacinView$   CRUD.ViewModel.MasinaViewModel   CRUD.View.MasinaView#   CRUD.ViewModel.PaketViewModel	   CRUD.View.PaketView'
   !CRUD.ViewModel.ProizvodiViewModel   CRUD.View.ProizvodiView&    CRUD.ViewModel.ProizvodViewModel   CRUD.View.ProizvodView��%�  (��       5      *, +)(�� 2     5      *, +)(�� d     5      *, +)(�� �     5      *, +)(�� �     5      *,
 +)(�� �     5      *, +)�� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5      	  5      �� 5   
   " 
 6   .R�5        5      �� 5   
   "  6   .R�5        5       5!      .��5"      �  � RowDefinitions 5#   
   �� 5$      $
��Auto �6   �� 5%      $
��Auto �6   .+�5'   
   ]� $��0��6   $��2q�6!   .+�5(      o� $	��Top=�6   $��25��6(   .@�5)      m� $��Radnici��6   $
��Auto��6,   $��14(�69    m� CommandParameter$ Radnici��5*       m� Command 5)   G   �� *KarteCommand+5*      m� 5+      $��Masine��6   $
��Auto��6+   $��14(�68   $ Masine��5,       5+   F   �� *KarteCommand+5,      m� 5-      $��	Proizvodi��6   $
��Auto��6.   $��14(�6;   $ 	Proizvodi��5.       5-   I   �� *KarteCommand+5.      m� 5/      $��Proizvodnja masine��6   $
��Auto��67   $��14(�6D   $ Proizvodnja masine��50       5/   R   �� *KarteCommand+50      m� 51      $��Paketi��6   $
��Auto��6+   $��14(�68   $ Paketi��52       51   F   �� *KarteCommand+52      m� 53      $��Magacini��6   $
��Auto��6-   $��14(�6:   $ Magacini��54       53   H   �� *KarteCommand+54      55      56      � 57   
   $��1��6   $
��Auto��6   .+�58      �� ��6   �� *CurrentViewModel+59      5:      5;      