   M S B A M L   `   `   `  ����G  CCodeAnalyzer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:CodeAnalyzerCodeAnalyzer  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5   	       CodeAnalyzer.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:CodeAnalyzer     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   >lvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf  5   	     � Title$  Code Analyzer��5   +   $	��600��5	      $
��1024��6'    � 
ResizeMode$ NoResize=�64    � WindowStartupLocation$ CenterScreen=�6J    � WindowStyle$
 None=�6o   .��5
      �  � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      $	��97* �6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $
��541* �6   .+�5   
   � $��1��6   $��1��6   ���#001b29.+�5      �� .��5      �  5      �� 5      $
��200* �6(   �� 5      $
��199* �6(   �� 5      $
��199* �6(    5      �� 5      $��1* �6+   �� 5      $��1* �6+   �� 5      $��1* �6+   .+�5"      �� -   5        $��BTNToggleAssociatonsLOC��5"      $y�Hidden=�6<   $��20 -10q�6P   $
��Left=�6`   $��Bottom=�6{   ���#002537���	#FF000519.��5#      � $	��155��6   .+�5$      �� $��Center=�6(   $��Toggle Associations/LOC��6E   $��Global User Interface)�6d   
�������6�   5%      5&      � 5(      $��1��6   $��2��6(   $��3��69   $��20q�6M    5)      �� 5*      $
��Auto �6,   6<   �� 5+      $��* �6,   69   .+�5-      #  LiveCharts.Wpf.CartesianChart  -   5        $��ScatterPlot1��5-   -   $��1��6A   &   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Right=�6N   
�������   Series 5/   "   "  LiveCharts.Wpf.ScatterSeries  -   5        $��ScatterSeries��5/   4     LiveCharts.Wpf.Series   Title$ Associations over LOC��6I   	   Fill	 �#6df4e9
   Values
 6g   �� *	CSClasses+6�      AxisY 52   "     LiveCharts.Wpf.Axis     Title$ Associations��6+   6B      AxisX 55   "     $	 LOC��6+   69      DataTooltip 57      #   CodeAnalyzer.CSClassesTooltip  58   "   5:        5<      -   5        $��
Histogram1��5<   -   $��1��6c   $ Right=�6p   
�������$y�Hidden=�6�    6?   �� *SeriesCollection+ 5>   "     $	 LOC��6+      LabelFormatter 67   �� *	Formatter+6^    5A   "     $ Classes��6+      Labels 6;   �� *Names+   	Separator 5B   &     LiveCharts.Wpf.Separator  5C   *   {�.     Step$ 1Q�6J   6U   5E   #    5G      #  LiveCharts.Wpf.DefaultTooltip  5H   "   ���	#E4555555   SelectionMode$ SharedYValuesX�6L   6l   5J      5L      5N      5O      (	  "System.Windows.Controls.WebBrowser	  5Q      -   5        $��
webBrowser��5Q   )   $��2��6   $y�Hidden=�6;   5R      � 5T   
   $��1��6   ��5U      �� 5V       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5W      �  � Color$ #002537��6#    � Offset$ 1Q�63   � 5X      $ #004567��6#   5Y       5[      �� 5\      $	��100 �6    �� 5]      $��5* �6     J� Effect 5_      3
  -System.Windows.Media.Effects.DropShadowEffect
  5`       
  
BlurRadius$ 20Q�6#    
  Color$ 	#FFDEDEDE��63    
  RenderingBias$ Quality=�6E    
  ShadowDepth$ 1Q�6]   6o   .+�5b      � ���#004567.+�5c      �� $��CODE ANALYZER��6   $��Center=�61   $��Center=�6N   $��	Agency FB)�6i   ���	#FFA4CBFA$��22(�6�   5d      �� 5e      $��1��6   .+�5f      �� -   5        $��10q�5f      ���#002537���	#FF000519.��5g      � $	��150��6   .+�5h      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Folder=�62   $��Center=�6@   
�������6[   �� 5i      $��Center=�6$   $��LOAD PROJECT��6A   $��Global User Interface)�6U   
�������6x   5j      5k      �� 5m      -   5        $��BTNScatterPlot��5m   R   $��10q�6   ���#002537���	#FF000519{�.  .��5n      � $	��150��6   .+�5o        $ ScatterPlot=�62   $��Center=�6E   
�������6`   �� 5p      $��Center=�6$   $��Scatter��6A   $��Global User Interface)�6P   
�������6s   5q      5r      �� 5t      -   5        $��BTNRowChart��5t   R   $��10q�6   ���#002537���	#FF000519{�.  .��5u      � $	��150��6   .+�5v        $ BarChart=�62   $��Center=�6B   
�������6]   �� 5w      $��Center=�6$   $��Top 25��6A   $��Global User Interface)�6O   
�������6r   5x      5y      �� 5{      -	   5        $��BTNForceDirectedGraph��5{   R   $��10q�6   ���#002537���	#FF000519{�.  .��5|      � $	��150��6   .+�5}        $ Graphql=�62   $��Center=�6A   
�������6\   �� 5~      $��Center=�6$   $��Associations��6A   $��Global User Interface)�6U   
�������6x   5      5�      5�      5�      � 5�   
   -
   5         �Name$ GridBarTitle��5�      $��2��6%   ���#000519.+�5�      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   $
��10,0q�6N   .+�5�      �� -   5         0  ,MaterialDesignFloatingActionMiniAccentButton#��[  5�      $��25��6_   $��25��6j   ���#e2fbff$	��0,2q�6�   ��6v   Z� ��6�   Z� .��5�        $ WindowMinimize=�6.   5�      �� 5�      -   5        #��[  5�      $��25��6_   $��25��6j   ���#e2fbff$	��0,2q�6�   ��6v   Z� ��6�   Z� .��5�        -   5           Name$  BTNFullScreenIcon��5�   .   $ WindowMaximize=�6I   5�      �� 5�      -   5        ! ��Name$! BTNClose��5�      #��[  6+   $��25��6q   $��25��6|   ���#e2fbff$	��0,2q�6�   ��6�   Z� ��6�   Z� .��5�        $ Close=�6.   5�      5�      5�      5�      5�      