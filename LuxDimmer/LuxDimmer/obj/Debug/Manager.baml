   M S B A M L   `   `   `  ����D  @LuxDimmer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:LuxDimmer	LuxDimmer  5   	       LuxDimmer.Manager   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:LuxDimmer     5   	   -   5          � Title$  
MainWindow��5   	    � SizeToContent$ WidthAndHeight=�6   $
��Auto��6;   $
��Auto��6H    � Icon$! Content/BrightnessLight.png��6V    � ShowInTaskbar . $y�Hidden=�6�    � WindowStyle$
 None=�6�    � Topmost . .��5	      � .+�5
   
   �� -   5         ��Name$ lstMonitorManagers��5
      $
��Auto��6.   $
��Auto��6;   ��5      �� 5      .R�5      � .+�5      �� ��6#   �� *MonitorLabel+.��5      �  � RowDefinitions 5   "   �� 5   &   66    � ColumnDefinitions 5   "   �� 5   &   69   �� 5   &   69   �� 5   &   69   .+�5   "   �� $��0��6)   $��0��66   $��Center=�6F   $��Center=�6a   $	��250��6~   	 � Minimum$
	 -100Q�6�   
 � Maximum$	
 100Q�6�    � Value 6�   �� *
Brightness+6�   �� 5   "   $��0��6)   $��1��66   $��20��6r   $��20��6}   $��1q�6�   ��6F   �� *ToggleVisibilityCommand+.��5   &   �� ��6,   �� *PowerButtonImageSource+6X   5   #   �� 5   "   $��0��6)   $��2��66   $��20��6q   $��20��6|   $��1q�6�   ��6F   �� *ResetVisibilityCommand+.��5   &   �� $��Content/reset.png��6,   6I   5   #   5      5       5!      5"      5$      5%      5&      