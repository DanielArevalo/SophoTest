import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ClienteModel } from 'src/model/cliente.model';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  constructor(private http: HttpClient) { }

  baseUrl = "https://localhost:44390/api";
  clienteServices = "cliente";

  ObtenerClientes(): Observable<ClienteModel[]> {
    return this.http.get<ClienteModel[]>(`${this.baseUrl}/${this.clienteServices}`);
  }

  CrearCliente(model: ClienteModel): Observable<number> {
    return this.http.post<number>(`${this.baseUrl}/${this.clienteServices}`, model)
  }

}
