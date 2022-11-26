import { Component } from '@angular/core';
import { ClienteModel } from 'src/model/cliente.model';
import { ClienteService } from 'src/services/cliente.service';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.scss']
})
export class ClienteComponent {

  constructor(private clienteService: ClienteService) { }

  clientes: ClienteModel[] = [];

  ngOnInit() {
    this.ObtenerClientes();
  }

  ObtenerClientes() {
    this.clienteService.ObtenerClientes().subscribe((response) => {
      this.clientes = response
    })
  }

}
