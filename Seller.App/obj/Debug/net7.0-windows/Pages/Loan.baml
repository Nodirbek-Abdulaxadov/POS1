   M S B A M L   `   `   `  ����E  ASeller.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Seller.App.PagesSeller.App.Pages  5   	   =#clr-namespace:Seller.App.ViewModelsSeller.App.ViewModels  5   	       Seller.App.Pages.Loan   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   _ [MaterialDesignThemes.Wpf, Version=4.7.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   *localclr-namespace:Seller.App.Pages  5   	   ,vm#clr-namespace:Seller.App.ViewModels  5   	     � Title$  Haridor tanlash��5
   	   $	��650��6!   $
��1000��6.    � WindowStartupLocation$ CenterScreen=�5   	   $
��1000��5   	    � DataContext 5      -   'Seller.App.ViewModels.CustomerViewModel  5   
   .��5      ��  �� Orientation$ Vertical=�6   .+�5   
   � $��0,5,0,10q�6   .+�5      �� $��Haridorlar ro'yxati��6   $��22(�5      $��20,10q�5      �� 5      -   5         ��Name$ search_input��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Qidirish��5       %  !MaterialDesignFloatingHintTextBox#��[  5      $	��300��6Q   $��10q�6]   $��16(�5      5      �� 5      -   5         ��Name$ new_customer��5       $��+ Yangi qo'shish��5      
������ $��0q�5      ���#22c55e$��Right=�5#      $��20,10q�5$      5%      #  MaterialDesignThemes.Wpf.Card  5&   
   $��1��6   $��10,10q�5'   "   .��5)      &   System.Windows.Controls.DataGrid  -   5          Name$ customers_table��5)         AutoGenerateColumns$ False��5*      	   CanUserAddRows$	 false��5+      ���#fff
   CanUserDeleteRows$
 False��5-      $	��530��5.         
IsReadOnly$
 True��5/      $
��True��50      $
��Auto=�51      $
��Auto=�52         Columns 53      1  +MaterialDesignThemes.Wpf.DataGridTextColumn  54      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��68   0  *System.Windows.Controls.DataGridTextColumn   FontSize$ 16Q�55   <      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.6* 56   <   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 57   <   �� *Id+  58      $ Ism Familiya��68   $ 16Q�5:   <   $
 1.3* 5;   <    59   <   �� *
FullName+5;   <     5<      $ 	Tel raqam��68   $ 16Q�5=   <   $
 0.7* 5>   <    5?   <   �� *PhoneNumber+4
  .System.Windows.Controls.DataGridTemplateColumn
  5@      $ Tanlash��6-   $ * 6>    
  CellTemplate 5A      �� 5B      .R�5C   "   �� $ 
Horizontal=�6-   .+�5D   &   �� $ select��5J   -   -   5        $��	10, 5,2,5q�5D   -   $��15(�5E   -   $
��10,0q�5F   -   
������ $��0q�5H   -   ���#66b032.��5L   *   �� $ 
Horizontal=�65   .+�5M   .   �� $��/assets/pay_loan.png��64   �� 5N   .   $��Tanlash��68   $
��10,0q�5O   <   $��Center=�5P   <   5Q   +   5R   '   5S   #   5T      5V      5Z      5[      5\      5]      