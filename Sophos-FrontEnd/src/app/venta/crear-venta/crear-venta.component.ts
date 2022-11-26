import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ClienteModel } from 'src/model/cliente.model';
import { ProductoModel } from 'src/model/producto.model';
import { VentaModel } from 'src/model/venta.model';
import { ClienteService } from 'src/services/cliente.service';
import { ProductoService } from 'src/services/producto.service';
import { VentaService } from 'src/services/venta.service';

@Component({
  selector: 'app-crear-venta',
  templateUrl: './crear-venta.component.html',
  styleUrls: ['./crear-venta.component.scss']
})
export class CrearVentaComponent {

  productos: ProductoModel[] = [];
  clientes: ClienteModel[] = [];

  constructor(private productoService: ProductoService, private clienteService: ClienteService,
    private ventaService:VentaService) {}

  profileForm = new FormGroup({
    producto: new FormControl(''),
    cliente: new FormControl(''),
    cantidad: new FormControl('')
  });
  
  ngOnInit() {
    this.ObtenerProductos();
    this.ObtenerClientes();
  }

  ObtenerProductos() {
    this.productoService.ObtenerProductos().subscribe((response) => {
      this.productos = response
    })
  }

  ObtenerClientes() {
    this.clienteService.ObtenerClientes().subscribe((response) => {
      this.clientes = response
    })
  }

  venta() {
    let venta = {
      idCliente: +(this.profileForm.controls["cliente"].value || ""),
      idProducto: +(this.profileForm.controls["producto"].value || "") ,
      Cantidad: +(this.profileForm.controls["cantidad"].value || "")
    } as VentaModel
    
    this.ventaService.Venta(venta).subscribe((response) => {
      alert("se creo satisfactoriamente la venta")
      window.location.reload();
    });;
  }

}
