   M S B A M L   `   `   `  ����  Avituallamiento@    :Avituallamiento.gui.Avituallamiento.DialogoAvituallamiento   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  DialogoAvituallamiento��5   	   $	��445��6(   $	��300��65   .��5      � .+�5   
   �� $
��Left=�60   $��	45,22,0,0q�6K   $	��Top=�6^   $	��202��6v   $��37��6�   ��6   ��  �� Path$ Nombre�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ datagridAvituallamiento��5      $
��Left=�6f   $��	26,64,0,0q�6�   $	��Top=�6�   $	��195��6�   $	��256��6�      AutoGenerateColumns .  ��64   �� $ ListaAvituallamiento�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5	      ,  &System.Windows.Controls.DataGridColumn   Header$ KM��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� $ KM�  5
      $ Nombre��6%    65   �� $ Persona�5      �� 5   
   -   5         ��Name$ buttonAniadir��5      $��Añadir��6(   $
��Left=�69   $��
26,295,0,0q�6T   $	��Top=�6h   $��75��6�   6�   �� 5   
   -   5        $ buttonEliminar��5      $��Eliminar��6)   $
��Left=�6<   $��116,295,0,0q�6W   $	��Top=�6l   $��75��6�   6�   �� 5   
   -   5        $ buttonModificar��5      $��	Modificar��6*   $
��Left=�6>   $��207,295,0,0q�6Y   $	��Top=�6n   $��75��6�    J� RenderTransformOrigin$ 	0.24,0.45&�6�   6�   5      5      