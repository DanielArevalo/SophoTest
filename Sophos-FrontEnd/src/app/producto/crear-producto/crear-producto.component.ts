import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ProductoModel } from 'src/model/producto.model';
import { ProductoService } from 'src/services/producto.service';

@Component({
  selector: 'app-crear-producto',
  templateUrl: './crear-producto.component.html',
  styleUrls: ['./crear-producto.component.scss']
})
export class CrearProductoComponent {

  constructor(private productoService: ProductoService) { }

  profileForm = new FormGroup({
    nombre: new FormControl(''),
    valor_Unitario: new FormControl('')
  });

  CrearProducto() {
    let producto = {
      nombre: this.profileForm.controls["nombre"].value,
      valor_Unitario: +(this.profileForm.controls["valor_Unitario"].value || ""),
    } as ProductoModel
    this.productoService.CrearProducto(producto).subscribe((cliente) => {
      alert("se creo satisfactoriamente el producto")
      window.location.reload();
    });
  }

}
