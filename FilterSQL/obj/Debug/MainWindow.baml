   M S B A M L   `   `   `  ����D  @FilterSQL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:FilterSQL	FilterSQL  5   	       FilterSQL.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:FilterSQL     5   	     � Title$  	FilterSQL��5   	   $	��350��6   $��736.2��6(   .��5	      � .+�5
   
   �� $��File handling��6   $
��Left=�6*   $��94��6E   $��	17,10,0,0q�6Q   $	��Top=�6d   $	��132��6|   .��5      � .+�5      �� -   5        $��CVS to database��5      $
��Left=�63   $��8,10,0,0q�6N   $	��Top=�6`   $	��101��6x   $��25��6�    � ToolTip$> 8Select folder with CVS files and convert it into SQL DB.��6�   �� 5      -   5        $��Load database��5      $
��Left=�61   $��8,40,0,0q�6L   $	��Top=�6^   $��99��6v   $��25��6�   6�   5      5      �� 5   
   -   5        $��MainList��5      $
��Left=�6#   $	��217��6>   $��
154,10,0,0q�6K   $	��Top=�6_   $	��566��6w    �� View 5      �� 5      .P�5      �� $��ID��6%    �� DisplayMemberBinding 6>   �� *ItemID+�� 5      $
��Cat.��6%    6>   �� *ItemCategory+�� 5      $
��Data��6%    6>   �� *
ItemDate+�� 5      $��Cashless saldo��6%    6>   �� *ItemCashlessSaldo+�� 5      $��Money saldo��6%    6>   �� *ItemMoneySaldo+�� 5      $��Purhcase��6%    6>   �� *ItemPurchase+�� 5      $��	Cash rld.��6%    6>   �� *ItemCashReload+�� 5      $��	Auto rld.��6%    6>   �� *ItemAutoReload+5      5      �� 5   
   -   5        $��textBoxSelectedID��5      $
��Left=�6+   $��23��6F   $��
34,131,0,0q�6R    �� TextWrapping$
 Wrap=�6f   $	��Top=�6z   $��94��6�   �� 5    
   $
��Left=�6   $��
34,115,0,0q�6/   $
��Wrap=�6C   $��Select card ID��6W   $	��Top=�6m   5"      5#      