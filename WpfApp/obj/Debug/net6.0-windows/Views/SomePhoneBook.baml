   M S B A M L   `   `   `  ????A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WpfApp.ViewsWpfApp.Views  5   	        WpfApp.Views.SomePhoneBook   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:WpfApp.Views     5   	     ? Title$  OpenPhoneBook??5   	   $	??450??6   $	??500??6,   .??5	      ?  ? ColumnDefinitions 5
   
   ?? 5      $??* ?6   ?? 5      $??* ?6   ?? 5      $??* ?6    ? RowDefinitions 5   
   ?? 5      $	??10* ?6   ?? 5      $	??80* ?6   ?? 5      $	??10* ?6   .+?5   
   ?? -   5        $??toolbar??5   O   $??0??6   $??3??6"    ?? Orientation$ 
Horizontal=?66   .+?5      ?? -   5        $??login??5      $??	324,6,6,6q?5      $??70??5      $??20??5      $??Right=?5      $??Center=?5      .??6,   Login5      ?? 5       -   5        $??registration??5#      $??6,6,6,6q?5       $??70??5!      $??20??5"      $??Right=?5$      $??Center=?5%      .??6,   Registration5'      5)      &   System.Windows.Controls.DataGrid  5+   
   -   5          Name$ SomePb??5+      $??1??6#   $??3??60      AutoGenerateColumns$ False??6D   $ ?? IsSynchronizedWithCurrentItem$
 TrueY?5,         SelectionMode$ Single=?68      CanUserResizeColumns$ False??6O   	   Columns	 5/      0  *System.Windows.Controls.DataGridTextColumn  50      ,  &System.Windows.Controls.DataGridColumn
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 40 6%      Header$ Id??6N   1  +System.Windows.Controls.DataGridBoundColumn   Binding 60   ?? *	ContactID+6N     51      $	
 150 6%   $ фамилия??6M    61   ?? *	Surname+6M     52      $	
 150 6%   $ Имя??6J    61   ?? *Name+6J     53      $	
 150 6%   $ Отчество??6P    61   ?? *
MiddleName+6P   55      ?? 57   
   $??2??6   $??0??6   $??20??6.   $??70??6:   $??Посмотреть??6E   ?? 59   
   $??2??6   $??1??6   $??20??6.   $??70??6:   $??Добавить??6E   ?? 5;   
   $??2??6   $??2??6   $??20??6.   $??70??6:   $??Удалить??6E   5<      5=      