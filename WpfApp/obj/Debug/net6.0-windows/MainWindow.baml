   M S B A M L   `   `   `  ????A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfAppWpfApp  5   	       WpfApp.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WpfApp     5   	   Gwpf9http://schemas.microsoft.com/netfx/2009/xaml/presentation    6,   -   5        $??
PhoneBooks??5   ~     ? Title$4  .Реестр телефонных книжек??6	   $	??600??6*   $	??450??67    ? WindowStartupLocation$ CenterScreen=?6C    ? 
ResizeMode$ NoResize=?6h   .??5	      ?  ? ColumnDefinitions 5
   
   ?? 5      $??* ?6   ?? 5      $??* ?6    ? RowDefinitions 5   
   ?? 5      $	??10* ?6   ?? 5      $	??70* ?6   ?? 5      $??8* ?6   ?? 5      $??4* ?6   ?? 5      $??8* ?6   .+?5   
   ?? -   5        $??toolbar??5   O   $??0??6   $??2??6"    ?? Orientation$ 
Horizontal=?66   .+?5      ?? -   5        $??login??5      $??	275,6,6,6q?5      $??70??5      $??20??5      $??Right=?5      $??Center=?5      .??6,   Login5      ?? 5!      -   5        $??registration??5$      $??6,6,6,6q?5!      $??70??5"      $??20??5#      $??Right=?5%      $??Center=?5&      .??6,   Registration5(      5*      &   System.Windows.Controls.DataGrid  5,   
   -   5          Name$ Phbooks??5,      $??1??6$   $??2??61      AutoGenerateColumns$ False??6E   $ ?? IsSynchronizedWithCurrentItem$
 TrueY?5-      	   SelectionMode$	 Single=?68   
   CanUserResizeColumns$
 False??6O      Columns 5.      0  *System.Windows.Controls.DataGridTextColumn  5/      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 40 6%      Header$ Id??6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 60   ?? *PhoneBookID+6P     50      $	 295 6%   $8 2Владелец телефонной книжки??6T    61   ?? *OwnerPhoneBook+6T   52      ?? 54   
   $??2??6   $??2??6   $??20??62   $??70??6>   $??Посмотреть??6I   ??55      ?? *
OpenSomePb+??60   ??  ?? ElementName$ Phbooks?? ?? Path$ SelectedItem??? 59   
   $??3??6   $??0??6!   $??6??61   $:??4Добавление телефонной книги??6E   
????? ? ?? TextAlignment$ Center=?5:      $??16(?6+   $
??Bold"?69   $??Italic$?6K   $??	Underline{?6^   ?? 5<   
   -   5        $??AddPhonebook??5<   O   $??4??6   $??2??6"   $ 
Horizontal=?66   $??Center=?6c   
????? ?.+?5>      ?? $;??5Введите ФИО владельца книжки??6   $
??Bold"?6=   $??Italic$?6O   $??Center=?6b   $??5q?5?      ?? 5@      -   5        $??Owner??5@      
???   ?$??Center=?67   $	??150??6R    ? ToolTip$. (Введите ФИО владельца??6^   $??5q?5A      ?? 5D      -   5        $??btnAddPb??5D      $??20??6%   $??70??61   $??Добавить??6<   $??5q?6O   5E      5G      5H      