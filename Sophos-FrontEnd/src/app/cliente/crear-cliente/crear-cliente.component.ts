import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ClienteModel } from 'src/model/cliente.model';
import { ClienteService } from 'src/services/cliente.service';

@Component({
  selector: 'app-crear-cliente',
  templateUrl: './crear-cliente.component.html',
  styleUrls: ['./crear-cliente.component.scss']
})
export class CrearClienteComponent {

  constructor(private clientService: ClienteService) { }

  profileForm = new FormGroup({
    nombre: new FormControl(''),
    apellido: new FormControl(''),
    numero_Documento: new FormControl(''),
    telefono: new FormControl(''),
  });

  CrearCliente() {
    let cliente = {
      nombre: this.profileForm.controls["nombre"].value,
      apellido: this.profileForm.controls["apellido"].value,
      numero_Documento: this.profileForm.controls["numero_Documento"].value,
      telefono: +(this.profileForm.controls["telefono"].value || "")
    } as ClienteModel
    this.clientService.CrearCliente(cliente).subscribe((cliente) => {
      alert("se creo satisfactoriamente el cliente")
      window.location.reload();
    });
  }


}
