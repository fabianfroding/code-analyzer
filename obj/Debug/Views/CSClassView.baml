   M S B A M L   `   `   `  ����G  CCodeAnalyzer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:CodeAnalyzerCodeAnalyzer  5          CodeAnalyzer.CSClassView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:CodeAnalyzer     5      .��5	      � -   5          �Name$  
GridLayout��5	      ���#002c3A � ColumnDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5       � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ TextBoxName��5      $��0��6)   $��0��69   $
��Left=�6F   $	��Top=�6a   $��	10,10,0,0q�6y   $
��Auto��6�   
�������
������ $��	Underline{�6�   Name5      �� 5   
   -   5        $ 
TextBoxLOC��5      $��0��6(   $
��Left=�68   $	��Top=�6S   $��	10,30,0,0q�6k   $
��Auto��6~   
�������
������ $��	Underline{�6�   LOC5      �� 5   
   -   5        $ TextBoxAssociations��5      $��0��61   $
��Left=�6A   $	��Top=�6\   $��	10,50,0,0q�6t   $	��100��6�   
�������
������ $��	Underline{�6�   Associations5      �� 5   
   -   5         ��Name$ AssociationsList��5      $��0��6,   $��1��6<   $��3��6I   $
��Left=�5      $	��Top=�6-   $
��Auto��6E   ���	#DDFFFFFF6R   (  "System.Windows.Controls.WebBrowser  5   
   -   5        $��
webBrowser��5      $��2��6'   $��3��67   5       5!      