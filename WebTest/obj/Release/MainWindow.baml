   M S B A M L   `   `   `  ����   WebCheck    WebTest.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  Webmaster Dashboard��$	��350��$	��525�� � WindowStartupLocation$ CenterScreen=� � WindowState$ 	Maximized=� � Icon$' !Images/1382978170_web_refresh.png�� � 	Resources  �� 
TargetType �� Property �� Value �� Triggers	 P� Property
 P� Value �� CenterX �� CenterY �� ScaleX��%  '��       '�� (     '�� P     '�� �     '�� �     '��     '�� X    �� " ��.���  � ��$ 0,5,0,0q��� " ��.���  � ��$ 0,0,0,0q��� " ��.���  � ��$ 23����  � ��$ 2q��� # �@��VerticalScrollBarVisibility$
 Auto=��� " ��.���  � ��$ 2q���  � ��$ 23���� " ��.���  � ��$ Center=��� " ��.���  � y�$ Hidden=���  � ��$ 10���� " �� P� 	 � ��
 . . ���  �@J�Opacity$	 0.5Q�.���  � z� �� $	 120Q�$ 30Q�$ 1Q�.��]� ��. .+�]� -   $��MenuDockPanel��$	��Top=�.+�o� $	��Top=�.@�m� $��_File��.@�m� -   $��E_xit��{�. m� $��_Edit��.@�m� $
��Undo�� m� Command$ ApplicationCommands.Undo��m� $
��Redo��$ ApplicationCommands.Redo���� m� $	��Cut��$ ApplicationCommands.Cut��m� $
��Copy��$ ApplicationCommands.Copy��m� $��Paste��$ ApplicationCommands.Paste��m� $��_Help��.@�m� $��_Help��{�.  m� $��	_Contents��{�.  m� $��	_Glossary��{�.  �� m� $��_About��{�.  �� -   $��
MainBorder��
�������$
��Auto��$
��Auto��$��Stretch=�$��Stretch=�$��0q�$	��Top=�._��� -   $��
tabControl��.@��� -   $��SiteStatusTab��$��Site Monitor�� �� 
IsSelected . .���� $
��Auto=�.����  �� Orientation$ Vertical=�.+��� &   System.Windows.Controls.DataGrid  -   $��	dataGrid1��   AutoGenerateColumns .     AlternatingRowBackground
 �����   SelectionMode$ Extended=�   CanUserAddRows .    CanUserReorderColumns .     CanUserResizeRows .  ����    Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToCells    
IsReadOnly .    CellTemplate �� .R��� $��16��$��16������  �� Path$ Image�0  *System.Windows.Controls.DataGridTextColumn     Header$
 Site��$
 Auto  .  1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Site+  $ Status��$ 50  .  �� *Status+  $ Error��$ *  .  �� *	Details+ � ContextMenu �� .@�m� -   $��Delete���� �� -	   $��Monitor_RefreshButton��$��50��$��75��.���� $'��!Images/1382978244_arrow_cycle.png���� -
   $��
ChangesTab��$��Change Detection��.���� $
��Auto=�.���� $ Vertical=�.+���   -   $��	dataGrid2�� .  
 �����$ Extended=� .  .   .  ����    $ SizeToCells  .  �� .R��� $��16��$��16������ *Image+  $
 Page��$
 Auto  .   �� *Url+  $ Original Date��$
 Auto  .  �� *
LastUpdate+  $ Percent Changed��$
 Auto  .  �� *PercentChanged+  $ 	Threshold��$
 Auto  .   �� *	Threshold+ �� .@�m� -   $��Reset��m� -   $��Delete��{�.  �� �� -   $��Changes_RefreshButton��$��50��$��75��.���� $'��!Images/1382978244_arrow_cycle.png��