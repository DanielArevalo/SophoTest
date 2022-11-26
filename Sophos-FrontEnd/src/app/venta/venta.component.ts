import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { VentaQuerymodel } from 'src/model/venta.model';
import { VentaService } from 'src/services/venta.service';

@Component({
  selector: 'app-venta',
  templateUrl: './venta.component.html',
  styleUrls: ['./venta.component.scss']
})
export class VentaComponent {

  ventas: VentaQuerymodel[] = [];

  constructor(private ventaService: VentaService) { }

  profileForm = new FormGroup({
    producto: new FormControl(''),
    cliente: new FormControl(''),
    cantidad: new FormControl('')
  });

  ngOnInit() {
    this.ObtenerVentas()
  }

  ObtenerVentas() {
    this.ventaService.ObtenerVentas().subscribe((response) => {
      this.ventas = response
    })
  }

}
