   M S B A M L   `   `   `  ����S  OWhoWantsToBeAMillionaire, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:WhoWantsToBeAMillionaire.ViewsWhoWantsToBeAMillionaire.Views  5   	   4    .WhoWantsToBeAMillionaire.Views.AskAudienceView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:WhoWantsToBeAMillionaire.Views     5   	   $	��400��5   	   $	��400��6     � WindowStartupLocation$  CenterScreen=�5	   	    � 
ResizeMode$ NoResize=�5
   	    � Icon$% pack://application:,,,/icon.ico��5   	   .��5      � ��5   
   �� 5       �� ImageSource$^ Xpack://application:,,,/WhoWantsToBeAMillionaire;component/Resources/Media/audiencebg.jpg��6    j� Stretch$ UniformToFill=�6�    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      $��7* �6   �� 5      .+�5(   
   �� -   5        $��
rectangle1��5(   ^   $��0��6   $��0��6!      AskAudienceGraphBar#��[  61    � Triggers 5)      :� 5*       :� RoutedEvent$ Rectangle.Loaded��6   .[�5+      �� .��5,      �� .��5-      W� 	 �� 
TargetName$	 
rectangle1��5.   !   
 �� TargetProperty$
 Height�5/   !    W� From 050   !    g� Duration$ 0:0:2D�6G    g� AutoReverse$
 True��6X   	 W� To 6*   �� *MaximumHeight+6X   W� 52       g� 	BeginTime	 0:0:753   !   $	 
rectangle1��54   !   $
 Height�55   !    056   !   $ 0:0:2D�6J   $ False��6[    6*   �� *RectangleAHeight+6[   57      58      59      5;      �� 5=   
   -   5        $��
rectangle2��5=   ^   $��0��6   $��1��6!   #��[  61    5>      :� 5?      $ Rectangle.Loaded��6   .[�5@      �� .��5A      �� .��5B      W�  0:0:0.55C   !   $	 
rectangle2��5D   !   $
 Height�5E   !    05F   !   $ 0:0:2D�6G   $
 True��6X    6*   �� *MaximumHeight+6X   W� 5H       0:0:6.55I   !   $	 
rectangle2��5J   !   $
 Height�5K   !    05L   !   $ 0:0:2D�6J   $ False��6[    6*   �� *RectangleBHeight+6[   5M      5N      5O      5Q      �� 5S   
   -   5        $��
rectangle3��5S   ^   $��0��6   $��2��6!   #��[  61    5T      :� 5U      $ Rectangle.Loaded��6   .[�5V      �� .��5W      �� .��5X      W� 	 0:0:15Y   !   $	 
rectangle3��5Z   !   $
 Height�5[   !    05\   !   $ 0:0:2D�6G   $
 True��6X    6*   �� *MaximumHeight+6X   W� 5^      	 0:0:65_   !   $	 
rectangle3��5`   !   $
 Height�5a   !    05b   !   $ 0:0:2D�6J   $ False��6[    6*   �� *RectangleCHeight+6[   5c      5d      5e      5g      �� 5i   
   -   5        $��
rectangle4��5i   i   $��0��6   $��3��6!   #��[  61   $��0��6^    5j      :� 5k      $ Rectangle.Loaded��6   .[�5l      �� .��5m      �� .��5n      W�  0:0:1.55o   !   $	 
rectangle4��5p   !   $
 Height�5q   !    05r   !   $ 0:0:2D�6G   $
 True��6X    6*   �� *MaximumHeight+6X   W� 5t       0:0:5.55u   !   $	 
rectangle4��5v   !   $
 Height�5w   !    05x   !   $ 0:0:2D�6J   $ False��6[    6*   �� *RectangleDHeight+6[   5y      5z      5{      5}      �� 5   
   $��1��6   $��0��6     AskAudienceLabel#��[ 6-   $��A��6W   �� 5�   
   $��1��6   $��1��6   #��[ 6-   $��B��6W   �� 5�   
   $��1��6   $��2��6   #��[ 6-   $��C��6W   �� 5�   
   $��1��6   $��3��6   #��[ 6-   $��D��6W   5�      5�      