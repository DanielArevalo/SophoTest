import { Component } from '@angular/core';
import { ProductoModel } from 'src/model/producto.model';
import { ProductoService } from 'src/services/producto.service';

@Component({
  selector: 'app-producto',
  templateUrl: './producto.component.html',
  styleUrls: ['./producto.component.scss']
})
export class ProductoComponent {

  constructor(private productoService: ProductoService) { }

  prodcutos: ProductoModel[] = [];

  ngOnInit() {
    this.ObtenerProductos();
  }

  ObtenerProductos() {
    this.productoService.ObtenerProductos().subscribe((response) => {
      this.prodcutos = response
    })
  }
}
