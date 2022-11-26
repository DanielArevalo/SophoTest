export interface VentaModel {
    idCliente: number,
    idProducto: number,
    Cantidad: number
}

export interface VentaQuerymodel {
    id: number,
    nombre_Cliente: string,
    nombre_Producto: string,
    valor_Unitario: number,
    valor_Total: number
}