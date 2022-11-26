import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ProductoModel } from 'src/model/producto.model';

@Injectable({
  providedIn: 'root'
})
export class ProductoService {

  constructor(private http: HttpClient) { }

  baseUrl = "https://localhost:44390/api";
  productoServices = "producto";

  ObtenerProductos(): Observable<ProductoModel[]> {
    return this.http.get<ProductoModel[]>(`${this.baseUrl}/${this.productoServices}`);
  }

  CrearProducto(model: ProductoModel): Observable<number> {
    return this.http.post<number>(`${this.baseUrl}/${this.productoServices}`, model)
  }

}
