   M S B A M L   `   `   `  ���� D  @LuxDimmer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:LuxDimmer	LuxDimmer      LuxDimmer.Manager   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:LuxDimmer     -     � Title$  
MainWindow�� � SizeToContent$ WidthAndHeight=�$
��Auto��$
��Auto�� � Icon$! Content/BrightnessLight.png�� � ShowInTaskbar . $y�Hidden=� � WindowStyle$
 None=� � Topmost . .��� .+��� -    ��Name$ lstMonitorManagers��$
��Auto��$
��Auto������ .R�� .+��� ���� *MonitorLabel+.���  � RowDefinitions ��  � ColumnDefinitions �� �� �� .+��� $��0��$��0��$��Center=�$��Center=�$	��250��	 � Minimum$
	 -100Q�
 � Maximum$	
 100Q� � Value �� *
Brightness+�� $��0��$��1��$��20��$��20��$��1q����� *ToggleVisibilityCommand+.���� ���� *PowerButtonImageSource+�� $��0��$��2��$��20��$��20��$��1q����� *ResetVisibilityCommand+.���� $��Content/reset.png��