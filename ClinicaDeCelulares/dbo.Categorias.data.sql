use BdClinicaDeCelulares;


SET IDENTITY_INSERT [dbo].[Categorias] ON
INSERT INTO [dbo].[Categorias] ([IdCategoria], [NombreCategoria], [Descripcion]) VALUES (1, N'categoria 1', NULL)
INSERT INTO [dbo].[Categorias] ([IdCategoria], [NombreCategoria], [Descripcion]) VALUES (2, N'categoria 2', NULL)
SET IDENTITY_INSERT [dbo].[Categorias] OFF

SET IDENTITY_INSERT [dbo].[Clientes] ON
INSERT INTO [dbo].[Clientes] ([IdCliente], [NombreCliente], [Direccion], [TelefonoCliente], [Fax]) VALUES (1, N'Norma', N'Santa Cruz', N'25588', N'852222')
INSERT INTO [dbo].[Clientes] ([IdCliente], [NombreCliente], [Direccion], [TelefonoCliente], [Fax]) VALUES (2, N'Frank', N'Nicoya', N'1258', N'12588')
SET IDENTITY_INSERT [dbo].[Clientes] OFF

SET IDENTITY_INSERT [dbo].[Proveedores] ON
INSERT INTO [dbo].[Proveedores] ([idProveedor], [compania], [nombreRepresentante], [telefonoProveedor]) VALUES (1, N'provedor1', N'proveedor1', N'1')
INSERT INTO [dbo].[Proveedores] ([idProveedor], [compania], [nombreRepresentante], [telefonoProveedor]) VALUES (2, N'proveedor2', N'proveedor2', N'2')
SET IDENTITY_INSERT [dbo].[Proveedores] OFF

SET IDENTITY_INSERT [dbo].[Productos] ON
INSERT INTO [dbo].[Productos] ([IdProducto], [nombreProducto], [precioUnidad], [unidadesEnExistencia], [idProveedor], [idCategoria]) VALUES (1, N'Teclado', CAST(25000.00 AS Decimal(18, 2)), 20, 1, 1)
INSERT INTO [dbo].[Productos] ([IdProducto], [nombreProducto], [precioUnidad], [unidadesEnExistencia], [idProveedor], [idCategoria]) VALUES (2, N'Mouse', CAST(12500.00 AS Decimal(18, 2)), 100, 2, 2)
INSERT INTO [dbo].[Productos] ([IdProducto], [nombreProducto], [precioUnidad], [unidadesEnExistencia], [idProveedor], [idCategoria]) VALUES (3, N'Monitor LCD', CAST(125000.00 AS Decimal(18, 2)), 45, 1, 1)
SET IDENTITY_INSERT [dbo].[Productos] OFF

SET IDENTITY_INSERT [dbo].[Vendedor] ON
INSERT INTO [dbo].[Vendedor] ([IdVendedor], [NombreVendedor], [Cedula], [Telefono]) VALUES (1, N'vendedor', N'12345', N'123456')
SET IDENTITY_INSERT [dbo].[Vendedor] OFF
