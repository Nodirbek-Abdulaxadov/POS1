   M S B A M L   `   `   `  ����E  ASeller.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Seller.App.PagesSeller.App.Pages  5   	   =#clr-namespace:Seller.App.ViewModelsSeller.App.ViewModels  5   	        Seller.App.Pages.Customers   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   _ [MaterialDesignThemes.Wpf, Version=4.7.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   *localclr-namespace:Seller.App.Pages  5   	   ,vm#clr-namespace:Seller.App.ViewModels  5   	     � Title$  
Haridorlar��5
   	   $	��650��6   $
��1000��6)    � WindowStartupLocation$ CenterScreen=�5   	   $
��1000��5   	    � DataContext 5      -   'Seller.App.ViewModels.CustomerViewModel  5   
   .��5      ��  �� Orientation$ Vertical=�6   .+�5   
   � $��0,5,0,10q�6   .+�5      �� $��Haridorlar ro'yxati��6   $��22(�5      $��20,10q�5      �� 5      -   5         ��Name$ search_input��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Qidirish��5       %  !MaterialDesignFloatingHintTextBox#��[  5      $	��300��6Q   $��10q�6]   $��16(�5      5      5      #  MaterialDesignThemes.Wpf.Card  5   
   $��1��6   $��10,10q�5   "   .��5!      &   System.Windows.Controls.DataGrid  -   5          Name$ customers_table��5!         AutoGenerateColumns$ False��5"         CanUserAddRows$ false��5#      ���#fff	   CanUserDeleteRows$	 False��5%      $	��530��5&      
   
IsReadOnly$

 True��5'      $
��True��5(      $
��Auto=�5)      $
��Auto=�5*         Columns 5+      1  +MaterialDesignThemes.Wpf.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��68   0  *System.Windows.Controls.DataGridTextColumn   FontSize$ 16Q�5-   <      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.5* 5.   <   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 5/   <   �� *Id+  50      $ Ism Familiya��68   $ 16Q�52   <   $
 1.4* 53   <    51   <   �� *
FullName+53   <     54      $ 	Tel raqam��68   $ 16Q�55   <   $
 0.7* 56   <    57   <   �� *PhoneNumber+4
  .System.Windows.Controls.DataGridTemplateColumn
  58      $ 
Harakatlar��6-   $
 0.7* 6A    
  CellTemplate 59      �� 5:      .R�5;   "   �� $ 
Horizontal=�6-   .+�5<   &   ��  ��Name$	 pay��5B   -   $��	10, 5,2,5q�5<   -   $��15(�5=   -   $
��10,0q�5>   -   
������ $��0q�5@   -   ���#3b82f6.��5C   *   �� $ 
Horizontal=�65   .+�5D   .   �� $��/assets/pay_loan.png��64   �� 5E   .   $��To'lov qilish��68   $
��10,0q�5F   <   $��Center=�5G   <   5H   +   5I   '   5J   #   5K      5M      5Q      5R      5S      5T      