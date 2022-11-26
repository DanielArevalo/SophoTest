import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { VentaModel, VentaQuerymodel } from 'src/model/venta.model';

@Injectable({
  providedIn: 'root'
})
export class VentaService {

  constructor(private http: HttpClient) { }

  baseUrl = "https://localhost:44390/api";
  ventaServices = "venta";


  ObtenerVentas(): Observable<VentaQuerymodel[]> {
    return this.http.get<VentaQuerymodel[]>(`${this.baseUrl}/${this.ventaServices}`);
  }

  Venta(model: VentaModel): Observable<number> {
    return this.http.post<number>(`${this.baseUrl}/${this.ventaServices}`, model);
  }
}
