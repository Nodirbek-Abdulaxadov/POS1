   M S B A M L   `   `   `  ���� E  ASeller.App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Seller.App.PagesSeller.App.Pages  =#clr-namespace:Seller.App.ViewModelsSeller.App.ViewModels      Seller.App.Pages.Selling   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:Seller.App.Pages     2vm#clr-namespace:Seller.App.ViewModels     _ [MaterialDesignThemes.Wpf, Version=4.7.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -     � Title$  Selling��$	��768��$
��1366�� � WindowState$ 	Maximized=� � WindowStyle$
 None=� � DataContext 0   *Seller.App.ViewModels.TransactionViewModel  .��� ���#bac8dc � ColumnDefinitions �� $
��2.5* ��� $��* �.+�� $��0��$��10q� � RowDefinitions �� $��* ��� $��8* ��� $��* �.+�#  MaterialDesignThemes.Wpf.Card  $��0��
������ .���  �� $��* ��� $��* ��� $��* ��� $��* �.+�� $��0��$
��10,0q�.+��� $��Center=�.+��� $��Naqd pul��$��18(�$��Center=�  ���#ffffff$��3q�$	��0,5q�.���� -    ��Name$
 naqd��
���   �$��18(�
 J� Uid$ 1��$��0��� $��1��$
��10,0q�.+��� $��Center=�.+��� $��Plastik karta��$��18(�$��Center=�  ���#ffffff$��3q�$	��0,5q�.���� -   $ plastik��
���   �$��18(�$ 2��$��0��� $��2��$
��10,0q�.+��� $��Center=�.+��� $��Chegirma��$��18(�$��Center=�  ���#ffffff$��3q�$	��0,5q�.���� -   $ chegirma��
���   �$��18(�$ 3��$��0��� $��3��$
��10,0q�.+��� $��Center=�.+��� $
��Jami��$��18(�$��Center=�  ���#ffffff$��3q�$	��0,5q�.���� -   $ total��
���   �$��18(�$��0�� �� 
IsReadOnly$
 True��  $��1��$
��0,10q�.��&   System.Windows.Controls.DataGrid  -   	  Name$	 transactions_table�����#ffffff
   AutoGenerateColumns$
 False��   CanUserAddRows$ false��   CanUserDeleteRows$ False��   
IsReadOnly$
 True��   Columns 1  +MaterialDesignThemes.Wpf.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Barcode��0  *System.Windows.Controls.DataGridTextColumn   FontSize$ 15Q�   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	Barcode+  $
 Nomi��$ 15Q�$ *  �� *Name+  $ Rangi��$ 15Q�$ 0.45*  �� *Color+  $ O'lchami��$ 15Q�$
 0.6*  �� *Size+  $ Narxi��$ 15Q�$
 0.6*  �� *Price+4	  .System.Windows.Controls.DataGridTemplateColumn	  $ Miqdor��$ *  	  CellTemplate �� .R���  �� Orientation$ 
Horizontal=�$��Center=�.+���  ��Name$ 	minus_btn��-   $��2q�$��35��$��35��
������ $��0q�
������ .���� $��/assets/minus.png��+
  %MaterialDesignThemes.Wpf.ShadowAssist 
  Darken$
 True���� $��18(�$
��15,0q����� *
Quantity+�� $ plus_btn��-   $��2q�$��35��$��35��
������ $��0q�
������ .���� $��/assets/plus.png��$
 True��  $ 
Jami narxi��$
 0.8* $ 15Q� �� *
TotalPrice+	  $ 	O'chirish��$
 0.6*  �� .R��� $ remove��-	   $��2q�$��15(�$��35��$��35��
������ $��0q�
������ .���� $��/assets/trash.png��$
 True���� $��2��$��0,10,5,5q�$ 
Horizontal=�.+��� -
   $ 
logout_btn��$
��8,10q�$��50�����#b51800���#b51800.���� $ 
Horizontal=�.+��� $��/assets/logout_left.png���� $��Chiqish��$
��10,0q�$��Center=��� -   $ setings��$
��8,10q�$��50��$
��30,0q�.���� $ 
Horizontal=�.+��� $��/assets/settings.png���� $��
Sozlamalar��$
��10,0q�$��Center=�� $��1��
������ .+��� $ Vertical=�.+��� $ 
Horizontal=�$��60��$��0,0,0,10q�
�������.+��� $��/assets/user.png��$��5,5,15,5q��� $	��250��$��Center=�.+��� $��Nodirbek Abdulaxadov��$��18(�$
��Bold"��� $��Sotuvchi��$��14(��� -   $ 	close_btn��
������ $��0q�$��46��$��46��
������ .���� $��46��$��46�� �� CornerRadius$ 23�����#cf0018 �� Padding$ 5q����#cf0018._��� $��/assets/close.png��� $	��597��$��
10,10,10,0q� �� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $
��1.2* ��� $
��1.2* �.+�� $��0��.+�  $
��5,10q�.���� -   $ barcode_input��$
��10,2q�$��40(�$
��Bold"�$ 4��.��� $��1�� �� $��* ��� $��* ��� $��* �.+��� -   $��0��$��36(�$��65��$	��5,0q�$��7���� -   $��1��$��36(�$��65��$	��5,0q�$��8���� -   $��2��$��36(�$��65��$	��5,0q�$��9��� $��2�� �� $��* ��� $��* ��� $��* �.+��� -   $��0��$��36(�$��65��$	��5,0q�$��4���� -   $��1��$��36(�$��65��$	��5,0q�$��5���� -   $��2��$��36(�$��65��$	��5,0q�$��6��� $��3�� �� $��* ��� $��* ��� $��* �.+��� -   $��0��$��36(�$��65��$	��5,0q�$��1���� -   $��1��$��36(�$��65��$	��5,0q�$��2���� -   $��2��$��36(�$��65��$	��5,0q�$��3��� $��4�� �� $��* ��� $��* ��� $��* �.+��� -   $��0��$��36(�$��65��$	��5,0q�$��0���� -   $��1��$��36(�$��65��$	��5,0q�$	��000���� -   $ removetb��$��2��$��36(�$��65��$	��5,0q����#cf0018���#cf0018.���� $��/assets/left.png��� $��5�� �� $��* ��� $��* ��� $��* �.+��� -   $ 
scanerlash��$��0��$��80��$	��5,0q�.���� .+��� $��50��$��/assets/barcode.png���� $��
Scanerlash���� -   $ print��$��1��$��80��$	��5,0q�.���� .+��� $��50��$��/assets/receipt.png���� $��Sotish��$��Center=��� -   $ refresh��$��2��$��80��$	��5,0q�.���� .+��� $��50��$��/assets/refresh.png���� $��	Yangilash��� $��6�� �� $��* ��� $��* ��� $��* �.+��� $��0��$��80��$	��5,0q�.���� .+��� $��50��$��/assets/search.png���� $��Qidirish���� $��1��$��80��$	��5,0q�.���� .+��� $��50��$��/assets/debt.png���� $��Nasiya���� $��2��$��80��$	��5,0q�.���� .+��� $��50��$��/assets/rbox.png���� $��	Qaytarish��  $��Right=�$��Bottom=�$	��360��$��	5,0,15,10q�
�������.���� $ 
Horizontal=�$��Center=�.+��� $
��10,0q�$ Vertical=�.+��� -    ��Name$ clock��$��14:13��$��30(�$
��Bold"�$
��Left=��� -   $
 date��$��3-mart, 2023-yil��$��18(�$��SemiBold"�$
��Left=�