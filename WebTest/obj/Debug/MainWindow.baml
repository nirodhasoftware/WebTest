   M S B A M L   `   `   `  ����  WebCheck    WebTest.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Webmaster Dashboard��5   	   $	��350��6%   $	��525��62    � WindowStartupLocation$ CenterScreen=�6>    � WindowState$ 	Maximized=�6c    � Icon$' !Images/1382978170_web_refresh.png��6�    � 	Resources 5       �� 
TargetType �� Property �� Value �� Triggers	 P� Property
 P� Value �� CenterX �� CenterY �� ScaleX��%�  '��       '�� M     '�� �     '�� G    '�� �    '�� �    '�� n    �� 5   
   " ��6   .�5      ��  � ��$ 0,5,0,0q�6'   5      �� 5	   
   " ��6   .�5
      ��  � ��$ 0,0,0,0q�6'   5      �� 5   
   " ��6   .�5      ��  � ��$ 23��6'   �� 5       � ��$ 2q�6'   �� 5      # �@��VerticalScrollBarVisibility$
 Auto=�6<   5      �� 5   
   " ��6   .�5      ��  � ��$ 2q�6'   �� 5       � ��$ 23��6'   5      �� 5   
   " ��6   .�5      ��  � ��$ Center=�69   5      �� 5   
   " ��6   .�5      ��  � y�$ Hidden=�6+   �� 5       � ��$ 10��6'   5      �� 5   
   " ��6    5      P� 5      	 � ��
 . . �5      ��  �@J�Opacity$	 0.5Q�60   5       .�5"      ��  � z� 5#      �� 5$      $	 120Q�6%   $ 30Q�63   $ 1Q�6@   5&      5'      5(      .��5)      ]� ��. .+�5*   
   ]� -   5        $��MenuDockPanel��5*      $	��Top=�6)   .+�5+      o� $	��Top=�6   .@�5,      m� $��_File��6   .@�5-      m� -   5        $��E_xit��5-      {�. 6?   5.      m� 5/      $��_Edit��6   .@�50      m� $
��Undo��6    m� Command$ ApplicationCommands.Undo��6-   m� 51      $
��Redo��6   $ ApplicationCommands.Redo��6-   �� 52      m� 53      $	��Cut��6   $ ApplicationCommands.Cut��6,   m� 54      $
��Copy��6   $ ApplicationCommands.Copy��6-   m� 55      $��Paste��6   $ ApplicationCommands.Paste��6.   56      m� 57      $��_Help��6   .@�58      m� $��_Help��6   {�.  6.   m� 59      $��	_Contents��6   {�.  62   m� 5:      $��	_Glossary��6   {�.  62   �� 5;      m� 5<      $��_About��6   {�.  6/   5=      5>      5?      �� 5@   
   -   5        $��
MainBorder��5@      
�������$
��Auto��6:   $
��Auto��6G   $��Stretch=�6U   $��Stretch=�5A      $��0q�6-   $	��Top=�6A   ._�5B      �� -   5        $��
tabControl��5B      .@�5C      �� -   5        $��SiteStatusTab��5C      $��Site Monitor��6/    �� 
IsSelected . .��5D      �� $
��Auto=�6#   .��5E      ��  �� Orientation$ Vertical=�6%   .+�5F      �� &   System.Windows.Controls.DataGrid  5G      -   5        $��	dataGrid1��5G   '      AutoGenerateColumns .     AlternatingRowBackground
 �����   SelectionMode$ Extended=�6�      CanUserAddRows .    CanUserReorderColumns .     CanUserResizeRows .  ��68   ��    Columns 5H   "   4  .System.Windows.Controls.DataGridTemplateColumn  5I   &   ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToCells 6=      
IsReadOnly .    CellTemplate 5J   *   �� 5K   .   .R�5L   2   �� $��16��68   $��16��6C   ��6O   ��  �� Path$ Image�5M   /   5O   '   0  *System.Windows.Controls.DataGridTextColumn  5P   &      Header$
 Site��69   $
 Auto 6G    .  1  +System.Windows.Controls.DataGridBoundColumn   Binding 6g   �� *Site+6�     5Q   &   $ Status��69   $ 50 6I    .  6f   �� *Status+6�     5R   &   $ Error��69   $ * 6H    .  6d   �� *	Details+6�    � ContextMenu 5T   "   �� 5U   &   .@�5V   *   m� -   5        $��Delete��5V   3   6C   5W   '   5Y      �� 5Z      6*   �� 5[      -	   5        $��Monitor_RefreshButton��5[   <   $��50��6%   $��75��61   .��5\   "   �� $'��!Images/1382978244_arrow_cycle.png��6(   6V   5]      5^      5_      5`      �� 5a      -
   5        $��
ChangesTab��5a      $��Change Detection��6,   .��5b      �� $
��Auto=�6#   .��5c      �� $ Vertical=�6%   .+�5d      ��   5e      -   5        $��	dataGrid2��5e   '    .  
 �����$ Extended=�6�    .  .   .  ��68   ��  5f   "     5g   &   $ SizeToCells 6=    .  5h   *   �� 5i   .   .R�5j   2   �� $��16��68   $��16��6C   ��6O   �� *Image+5k   /   5m   '     5n   &   $
 Page��69   $
 Auto 6G    .   6g   �� *Url+6�     5o   &   $ Original Date��69   $
 Auto 6P    .  6o   �� *
LastUpdate+6�     5p   &   $ Percent Changed��69   $
 Auto 6R    .  6q   �� *PercentChanged+6�     5q   &   $ 	Threshold��69   $
 Auto 6L    .   6l   �� *	Threshold+6�    5s   "   �� 5t   &   .@�5u   *   m� -   5        $��Reset��5u   3   6B   m� 5v   *   -   5        $��Delete��5v   3   {�.  6U   5w   '   5y      �� 5z      6*   �� 5{      -   5        $��Changes_RefreshButton��5{   <   $��50��6%   $��75��61   .��5|   "   �� $'��!Images/1382978244_arrow_cycle.png��6(   6V   5}      5~      5      5�      5�      5�      5�      5�      