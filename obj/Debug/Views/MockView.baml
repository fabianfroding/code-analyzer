   M S B A M L   `   `   `  ����G  CCodeAnalyzer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:CodeAnalyzer.ViewsCodeAnalyzer.Views  5      !    CodeAnalyzer.Views.MockView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:CodeAnalyzer.Views     5      .��5	      � -   5          �Name$  
GridLayout��5	      ���#002c3A � ColumnDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      �� 5       � RowDefinitions 5   
   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ TextBoxName��5      $��0��6)   $��0��69   $
��Left=�6F   $	��Top=�6a    �� Padding$ 10q�6y   $	��100��6�   
�������
������ $��	Underline{�6�   Name5      �� 5   
   -   5        $ 
TextBoxLOC��5      $��0��6(   $
��Left=�68   $	��Top=�6S   $��	10,31,0,0q�6k   $	��100��6~   
�������
������ $��	Underline{�6�   LOC5      �� 5   
   -   5        $ TextBoxAssociations��5      $��0��61   $
��Left=�6A   $	��Top=�6\   $��	10,52,0,0q�6t   $	��100��6�   
�������
������ $��	Underline{�6�   Associations5      �� 5   
   -   5         ��Name$ AssociationsList��5      $��1��6,   $��2��6<   $
��Left=�5      $	��Top=�6-   $
��Auto��6E   ���	#DDFFFFFF6R   (  "System.Windows.Controls.WebBrowser  5   
   -   5        $��
webBrowser��5      $��2��6'   $��2��67   $
��Auto��6H   5      5       