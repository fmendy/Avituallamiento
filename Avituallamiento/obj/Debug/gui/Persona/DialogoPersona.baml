   M S B A M L   `   `   `  ����  Avituallamiento0    *Avituallamiento.gui.persona.DialogoPersona   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  DialogoPersona��5   	   $	��300��6    $	��300��6-   .��5      � $��2,0,-2,0q�6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DataGridPersonas��5      $��	29,10,0,0q�6X   $	��Top=�6k   $	��184��6�   $
��Left=�6�   $	��230��6�      AutoGenerateColumns .  ��6-   ��  �� Path$ listaPersonas�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ NOMBRE��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� $ Nombre�  5	      $ TELEFONO��6%    67   �� $ Telefono�5      �� 5   
   -   5         ��Name$ jButtonNuevo��5      $��Nuevo��6'   $
��Left=�67   $��
29,214,0,0q�6R   $	��Top=�6f   $��75��6~   6�   �� 5   
   -   5        $ jButtonCancelar��5      $��Cancelar��6*   $
��Left=�6=   $��184,239,0,0q�6X   $	��Top=�6m   $��75��6�   6�   �� 5   
   -   5        $ jButtonModificar��5      $��	Modificar��6+   $
��Left=�6?   $��
29,239,0,0q�6Z   $	��Top=�6n   $��75��6�   6�   �� 5   
   -   5        $ buttonEliminar��5      $��Eliminar��6)   $
��Left=�6<   $��184,214,0,0q�6W   $	��Top=�6l   $��75��6�   6�   5      5      