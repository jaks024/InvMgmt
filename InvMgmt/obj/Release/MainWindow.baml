   M S B A M L   `   `   `  ���� B  >InvMgmt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:InvMgmtInvMgmt  !clr-namespace:InvMgmtInvMgmt      InvMgmt.MainWindow    custnsclr-namespace:InvMgmt  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:InvMgmt       � Title$  InvMngt��$	��720��$
��1280�� � 
ResizeMode$ CanMinimize=� � 	Resources    BoolToVisibility  cbCategoryTemplate �� StringFormat �� Path  styleCalendar �� 
TargetType&   System.Windows.Controls.Calendar �� Property �� Value �� 
TargetType5  /System.Windows.Controls.Primitives.CalendarItem	  Name��%�   &	        &	      &	 K     �� �� .R��� ��`� $ {0}: {1}��.1��� $ Id��� $
 Name��� "  .���  � �� �� "  .R�(� $	��250��$	��250��.��  $	 PART_CalendarItem��#��z��#��z��#��z��.��� 
 � RowDefinitions
 �� $��* �.+��� -   $��mainTabControl��$��1��$
��Left=�$	��Top=�$	��690��$
��1272�� �� TabStripPlacement$
 Left=�.@��� $	��Add��$��35��$	��100��$��0��.��� ���	#FFE5E5E5 +� IsFocusScope .  � ColumnDefinitions �� $
��auto ��� $
��auto ��� $
��auto �.+�� -   $��
gridNewCat��
������� �� $	��110 ��� $	��210 �
 �� $��30 ��� $��30 ��� $��35 ��� $��30 ��� $��35 ��� $��35 ��� $��* �.+��� $��Add New Category���� $��1��$
��ID *��$��Center=�$
��Left=�$��5 0 0 0q��� $��2��$��5q�$	��100������ *Id+ �� UpdateSourceTrigger$ PropertyChanged=��� $��1��$��1��$��Category Name *��$��Center=�$
��Left=�$��5 0 0 0q��� -   $��tbNewCatName��$��2��$��1��$��5q�$	��200������ *Name+$ PropertyChanged=��� $��3��$��Description *��$��Center=�$
��Left=�$��5 0 0 0q��� -   $��tbNewCatDesc��$��4��$��2��$��5q�$	��310������ *Description+$ PropertyChanged=��� -   $��btnClearNewCat��$��5��$��1��$��95��$
��Left=�$��Clear��$��5q��� -   $��btnSubmitNewCat��$��5��$��1��$��95��$��Right=�$��Submit��$��5q�� -   $��gridExistingCat��$��7��$��2��$��0 0 0 5q�
 �� $��30 ��� $��* ��� $��35 � �� .+��� $��Existing Categories��$��Center=�$
��Left=�$��5 0 0 0q�&   System.Windows.Controls.DataGrid  -   $��dgExistingCat��$��1��$��5q�   SelectionMode$ Single=�   AutoGenerateColumns .     CanUserAddRows .     RowDetailsVisibilityMode$ VisibleWhenSelected=����� *
Categories+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Id��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id+ �� Mode$ OneWay=�  $
 Name�� �� *Name+$ TwoWay=�$ 	LostFocus=�  $ 
Item Count�� �� *Items.Count+$ OneWay=�  $ Description�� �� *Description+$ TwoWay=�$ 	LostFocus=��� -	   $��
tbCatCount��$��2��$��Center=�$��5 0 0 0q�$	��100��$
��Left=����� *CategoryCount+$ Categories: {0}��$ OneWay=��� -
   $��btnRemoveExistingCat��$��2��$��95��$��Right=�$��Delete��$��5q��� $��1��$��1��$��Stretch=�
�����w�� -   $��gridNewItem��$��2��
������� �� $��* ��� $��* ��� $��* ��� $��* �
 �� $��30 ��� $��30 ��� $��35 ��� $��35 ��� $��30 ��� $��30 ��� $��35 ��� $��30 ��� $��30 ��� $��35 ��� $��30 ��� $��35 ��� $��35 �.+��� $��Add New Item��$��5 0 0 0q��� $��1��$
��ID *��$��Bottom=�$
��Left=�$��5 0 0 0q�$��Bottom=��� $��2��$��5q�$	��100������ *Id+$ PropertyChanged=�$ TwoWay=��� $��1��$��1��$��Name *��$��Bottom=�$
��Left=�$��5 0 0 0q�$��Bottom=��� $��2��$��1��$��5q�$	��100������ *Name+$ PropertyChanged=�$ TwoWay=��� $��1��$��2��$��
Category *��$��Bottom=�$
��Left=�$��5 0 0 0q�$��Bottom=��� -   $��cbNewItemCategory��$��2��$��2��$��5q�$	��100�� �� SelectedIndex$ 0��#��[ ���� *
Categories+�� $��1��$��3��$��Description *��$��Bottom=�$
��Left=�$��5 0 0 0q�$��Bottom=��� $��2��$��2��$��3��$��5q�$	��200�� �� AcceptsReturn . " �� VerticalScrollBarVisibility$
 Auto=� �� TextWrapping$
 Wrap=����� *Description+$ PropertyChanged=�$ TwoWay=��� $��4��$��Quantity Info��$��5 0 0 0q�$��Bottom=��� $��5��$��Total In Stock��$��5 0 0 0q�$��Bottom=��� -   $��6��$��5q�$	��100�� �� 	MaxLength$ 7������ *Quantity.Total+$ 	LostFocus=�$ TwoWay=��� $��4��$��1��$��
Price Info��$��5 0 0 0q�$��Bottom=��� $��5��$��1��$��Regular Price��$��5 0 0 0q�$��Bottom=��� -   $��6��$��1��$��5q�$	��100��$ 9������ *Price.RegularPrice+$ 	LostFocus=�$ TwoWay=��� $��5��$��2��$��
Sale Price��$��5 0 0 0q�$��Bottom=��� -   $��6��$��2��$��5q�$	��100��$ 9������ *Price.SalePrice+$ 	LostFocus=�$ TwoWay=��� $��5��$��3�� �� Orientation$ 
Horizontal=�.+��� $��Current Price��$	��100��$��5 0 0 0q�$��Bottom=��� $��
Is On Sale��$��5 0 0 0q�$��Bottom=��� $��6��$��3��$ 
Horizontal=�.+��� -   $��5q�$	��100��$
��Left=�$ 9������ *Price.CurrentPrice+$ 	LostFocus=�$ TwoWay=��� $��5q�$��20��$��Right=� d� 	IsChecked �� *Price.IsOnSale+$ PropertyChanged=�$ TwoWay=��� $��7��$��
Other Info��$��5 0 0 0q�$��Bottom=��� $��8��$��Company��$��5 0 0 0q�$��Bottom=��� $��9��$��5q�$	��100������ *Detail.Company+$ PropertyChanged=�$ TwoWay=��� $��8��$��1��$��Phone��$��5 0 0 0q�$��Bottom=��� $��9��$��1��$��5q�$	��100������ *Detail.Phone+$ PropertyChanged=�$ TwoWay=��� $��8��$��2��$
��Date��$��5 0 0 0q�$��Bottom=�(  "System.Windows.Controls.DatePicker  $��9��$��2��$��2��$��5q�$
��Left=�|�.     Text �� *Detail.Date+$ PropertyChanged=�$ TwoWay=��� $��8��$��3��$��Email��$��5 0 0 0q�$��Bottom=��� $��9��$��3��$��5q� . $	��200��$
 Auto=����� *Detail.Email+$ PropertyChanged=�$ TwoWay=��� $��10��$��Address��$��5 0 0 0q�$��Bottom=��� $��11��$��3��$��5q�$	��320�� . $
 Auto=����� *Detail.Address+$ PropertyChanged=�$ TwoWay=��� -   $��btnClearNewItem��$��11��$��3��$��95��$
��Left=�$��Clear��$��5q��� -   $��btnSubmitNewItem��$��11��$��3��$��95��$��Right=�$��Submit��$��5q��� -   $��tabInventory��$��	Inventory��$��35��$	��100��$��1��.��� 
�������
 �� $��35 ��� $��* �.+�� 
 �� $��35 � �� $��* ��� $��* ��� $��* ��� $��* �.+��� $��5q�$ 
Horizontal=�$
��Left=�.+��� -   $��cbSortByCategory��$	��200��#��[ ���� *
Categories+ �� *CurrentCategoryIndex+�� $��5q�$ 
Horizontal=�$
��Left=�$��1��.+��� -   $��tbItemSearch��$��1��$	��170���� -   $��	btnSearch��$��Search��$��5 0 0 0q�$��50���� -   $��btnClear��$��Clear��$��5 0 0 0q�$��50���� $��5q�$ 
Horizontal=�$��Right=�$��2��.+��� $��Change Category��$	��100��$��Center=��� -   $��cmbChangeItemCategory��$	��175��#��[ ���� *
Categories+�� -   $��btnTotalAllItems��$��3��$
��Left=�$��Total Values��$��80��$��15 5 5 5q��� $��5q�$ 
Horizontal=�$��Right=�$��3��.+��� -   $��tbInventoryItemCount��$��Center=�$	��100������ *SelectedCategoryItems.Count+$ Item Count: {0}��$ OneWay=��� -    ��Name$ btnInventoryDelete��$��Delete��$	��5 0q�$��50��  -   $��
dgItemList��$��1��$��1�� .   .  $ VisibleWhenSelected=�    CanUserSortColumns  . $ Single=����� *SelectedCategoryItems+!   RowStyle! �� )  #System.Windows.Controls.DataGridRow"  .���  � y� �� *	Visible+" �� 	Converter#" [     $ Id�� �� *Id+$ OneWay=�  $
 Name�� �� *Name+$ 	LostFocus=�$ TwoWay=�  $ Description�� �� *Description+$ 	LostFocus=�$ TwoWay=�  $ Category�� �� *
Category+$ OneWay=�4	  .System.Windows.Controls.DataGridTemplateColumn	  $ Total Avaliable��# 	  CellTemplate# �� .R��� -   $ 7������ *Quantity.Total+$ TwoWay=�$ Explicit=�	  $ 
Sold Today��# �� .R��� -   $ 7������ *Quantity.Today+$ TwoWay=�$ Explicit=�	  $ Sold Weekly��# �� .R��� -   $ 7������ *Quantity.Weekly+$ TwoWay=�$ Explicit=�	  $ Sold Monthly��# �� .R��� -    $ 7������ *Quantity.Monthly+$ TwoWay=�$ Explicit=�	  $ Sold Annually��# �� .R��� -!   $ 7������ *Quantity.Annually+$ TwoWay=�$ Explicit=�	  $ 
Sold Total��# �� .R��� -"   $ 7������ *Quantity.UsedTotal+$ TwoWay=�$ Explicit=�	  $ Current Price��# �� .R��� -#   $ 9������ *Price.CurrentPrice+$ TwoWay=�$ Explicit=�	  $ Regular Price��# �� .R��� -$   $ 9������ *Price.RegularPrice+$ TwoWay=�$ Explicit=�	  $ 
Sale Price��# �� .R��� -%   $ 9������ *Price.SalePrice+$ TwoWay=�$ Explicit=�4
  .System.Windows.Controls.DataGridCheckBoxColumn
  $ On Sale�� �� *Price.IsOnSale+$ PropertyChanged=�$ TwoWay=�$   RowDetailsTemplate$ �� .R��  �� $��75 ��� $
��auto �$	��100���� $��75 ��� $
��auto �$	��100���� $��75 ��� $
��auto �$	��100��
 �� $��20 ��� $��20 �.+��� $��	Company: ��$	��5 0q��� -&   $	��5 0q�$��1������ *Detail.Company+$ 	LostFocus=�$ TwoWay=��� $��	Address: ��$��1��$	��5 0q��� -'   $	��5 0q�$��1��$��1������ *Detail.Address+$ 	LostFocus=�$ TwoWay=��� $��Phone: ��$��2��$	��5 0q��� -(   $	��5 0q�$��3������ *Detail.Phone+$ 	LostFocus=�$ TwoWay=��� $��Date: ��$��1��$��2��$	��5 0q�(� $	��5 0q�$��1��$��3��.��  -)   |�.  $��14(�%   CalendarStyle#% [  �� *Detail.Date+$ 	LostFocus=�$ TwoWay=��� $��Email: ��$��4��$	��5 0q��� -*   $	��5 0q�$��5������ *Detail.Email+$ 	LostFocus=�$ TwoWay=��� -+   $��
tabHistory��$��History��$��35��$	��100��$��-1,0,1,0q�$��Bottom=�$��2��.��� 
������� .  �� $	��800 ��� $
��auto �
 �� $��30 ��� $��* �.+��� $��Recent History��  -,   $��dgRecentHistory��$��1�� .  $ VisibleWhenSelected=�  . &   
IsReadOnly& .  .  ���� *	Histories+   $ Id�� �� *Id+$ OneWay=�  $
 Time�� �� *Time+$ 	LostFocus=�$ OneWay=�  $ Action�� �� *Name+$ 	LostFocus=�$ OneWay=�  $
 Path�� �� *Path+$ 	LostFocus=�$ OneWay=�$ �� .R�� 
 �� $��* � �� $	��795 �.+��� $	��5 0q�$
��Wrap=����� *Detail+$ OneWay=��� $��1��$��Options��$	��5 0q�� $��1��$��1�� �� $��* ��� $��* �
 �� $��30 ��� $��35 ��� $��35 �.+��� $��Save Directory��$	��5 0q��� --   $��tbHistorySavePath��$��1��' �� 
IsReadOnly' . $��5q�$	��250������ *HistorySaveFolderPath+$ OneWay=�$ PropertyChanged=��� -.   $��1��$	��5 5q�$��1��$��Change��$��80���� -/   $��2��$��5q�$��80��$
��Left=�$��Open Folder���� -0   $��2��$��1��$��5q�$��Save to PDF���� $��Settings��$��35��$	��100��{�.  .��� 
������� �� $	��500 ��� $��* �
 �� $��30 ��� $��35 �.+��� $��Save Folder Path��$	��5 0q�$��Bottom=�]� $��1��.+��� -1   $��tbSaveFolderPath��' . $��5q�$	��420��$
��Left=�$
 Wrap=����� *SaveFolderPath+$ OneWay=�$ PropertyChanged=��� -2   $��btnChangeFolder��$��Select��$��5q�$��Right=�