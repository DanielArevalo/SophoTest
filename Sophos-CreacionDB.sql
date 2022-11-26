CREATE DATABASE SophosTecnicalTes;

USE SophosTecnicalTes;

CREATE TABLE [dbo].[Cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Numero_Documento] [varchar](250) NULL,
	[Nombre] [varchar](250) NULL,
	[Apellido] [varchar](250) NULL,
	[Telefono] [int] NULL
);

CREATE TABLE [dbo].[Producto](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Nombre] [varchar](500) NULL,
	[Valor_Unitario] [float] NULL
);

CREATE TABLE [dbo].[Ventas](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[IdCliente] [int] NULL,
	[IdProducto] [int] NULL,
	[Cantidad] [int] NULL,
	[Valor_Unitario] [float] NULL,
	[Valor_Total] [float] NULL
);


ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([Id])
GO

ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([Id])
GO


CREATE OR ALTER PROCEDURE dbo.RealizarVenta @IdCliente INT,	@IdProducto INT,@cantidad INT
AS
BEGIN
	SET NOCOUNT ON; 

	DECLARE @Validador INT;
	DECLARE	@Valor_Unitario FLOAT;

	--Valido si el cliente existe 
	SELECT @Validador = COUNT(Id) FROM Cliente WHERE Id = @IdCliente;
	IF (@Validador <= 0) 
		BEGIN
			PRINT 'El cliente no existe';  
		END;

	--Valido si el producto existe
	SELECT @Validador = COUNT(Id) FROM Producto WHERE Id = @IdProducto;
	IF (@Validador <= 0)
		BEGIN
			PRINT 'El producto no existe';  
		END;
	SELECT @Valor_Unitario = Valor_Unitario FROM Producto WHERE Id = @IdProducto;
	
	DECLARE @Valor_Total FLOAT = @Valor_Unitario * @cantidad;

	INSERT INTO Ventas VALUES(@IdCliente, @IdProducto,@cantidad, @Valor_Unitario, @Valor_Total);

END