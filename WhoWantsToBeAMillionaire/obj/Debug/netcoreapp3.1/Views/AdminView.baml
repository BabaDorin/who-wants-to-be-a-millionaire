   M S B A M L   `   `   `  ����S  OWhoWantsToBeAMillionaire, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:WhoWantsToBeAMillionaire.ViewsWhoWantsToBeAMillionaire.Views  5   	   .    (WhoWantsToBeAMillionaire.Views.AdminView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:WhoWantsToBeAMillionaire.Views     5   	   -   5          � Title$  Panoul de administrare��5   	   $	��600��6(   $
��1100��65    � WindowStartupLocation$ CenterScreen=�5	   	    � Icon$% pack://application:,,,/icon.ico��5
   "   .��5      � .+�5   
   � -   5        $��	LoginPage��5      y�6    �� *LoginPageVisibility+.+�5      �� $��Center=�6   $��Center=�66   .+�5      ��    	LargeText#��[  6   $��Center=�6?   
���   �%#Introduceti parola de administrator5      G� 5      -   5        $��passwordBox��5      $��20(�61   $��10q�6?   $��Center=�6K   �� 5      -   5         ��Name$ btLogin��5      $��Login��6@   $��20(�6P    �� 	IsDefault$
 True��6^   5      5      � 5   
   -   5        $��
AdminPanel��5      y�6!   �� *AdminPanelVisibility+ � RowDefinitions 5      �� 5      $��3* �6    �� 5      $	��10* �6    �� 5      $��2* �6    .+�5      �� $��0��6   $-��'Adauga, modifica sau elimina intrebari.��6!   $��Center=�6S   $��Center=�6w   $��20(�5       &   System.Windows.Controls.DataGrid  5#      -   5        $��QuestionsDataGrid��5$   	   $��1��5#         AutoGenerateColumns$ False��6$   $��Center=�6@   $��15q�6]      	RowHeight$ 30Q�5$   "      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 100 61   	   GridLinesVisibility$	 Vertical=�6�   
   HeadersVisibility$	
 All=�6�   $��Center=�6�   
�������   RowBackground
 �����   AlternatingRowBackground
 ��ح���6C   �� *QuestionsList+   Columns 5%      0  *System.Windows.Controls.DataGridTextColumn  5&      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6)      
IsReadOnly$
 True��6p   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *
QuestionId+ �� ValidatesOnExceptions$
 True��6p     5'      $ Textul intrebarii��6)    6D   �� *QuestionText+$
 True��4  .System.Windows.Controls.DataGridComboBoxColumn  5(      $ Nivel de dificultate��6-   -   5        DifficultyDropDown��   SelectedItemBinding 5)   )   �� *DifficultyLevel+  5*      $ Optiunea ID:0��6)    6@   �� *
Options[0]+$
 True��  5+      $ Optiunea ID:1��6)    6@   �� *
Options[1]+$
 True��  5,      $ Optiunea ID:2��6)    6@   �� *
Options[2]+$
 True��  5-      $ Optiunea ID:3��6)    6@   �� *
Options[3]+$
 True��  5.      $ ID optiune corecta��6)    6E   �� *CorrectOptionIndex+$
 True��  5/      $ 
Explicatii��6)    6=   �� *Explanations+$
 True��51      � 53      $��2��6    � ColumnDefinitions 54      �� 55      �� 56      .+�59      �� -   5        $��btSave��59      $��0��6'   $��Salveaza��67   $��10q�6J   ${�False��6k   �� 5:      -	   5        $��btDelete��5:      $��1��6)   $��Elimina��69   $��10q�6K   6W   5;      5<      5=      5>      