create database Los_Monos

use Los_Monos

create table Usuario
(
Nombre_usu nvarchar(50) primary key,
Nombre_empleado nvarchar(50) not null,
Contraseña nvarchar(50) not null,
DNI bigint not null,
Telefono bigint,
Correo nvarchar(100) not null,
Estado nvarchar(10) default 'ACTIVO',
Cargo nvarchar(20) not null
)

create table tLocal
(
Nombre_local nvarchar(50) not null,
Telefono_local bigint not null,
Correo_local nvarchar(50) not null,
Direccion_local nvarchar(100) not null,
Primary key(Nombre_local)
)

create table producto
(
Cod_producto nvarchar(50)primary key,
Nombre_producto nvarchar (100) not null,
Marca nvarchar(50) not null,
Existencia bigint not null,
Tipo nvarchar (50) not null,
Bodega nvarchar (50) not null,
Pasillo nvarchar(50) not null
)
alter table producto add precio bigint not null


create table Pedido
(
Codigo_pedido Nvarchar (50) primary key,
Nombre_usu nvarchar(50) foreign key references Usuario (Nombre_usu),
Fecha_pedido date default getdate(),
hora nvarchar (30) not null
)
alter table pedido add hora nvarchar(30) not null

create table Entrega
(
Codigo_entrega bigint identity (1,1) primary key,
Nombre_usu nvarchar(50) foreign key references Usuario (Nombre_usu),
Nombre_local nvarchar(50) foreign key references tlocal (Nombre_local),
Fecha_entrega date default getdate(),
Codigo as ('ENT_'+Convert(nvarchar(50),Codigo_entrega))
)
alter table entrega add hora nvarchar(30) not null
alter table entrega add total bigint not null

-----------------------------Terceras tablas-----------------------------------------------------------------
create table Detalle_Pedido
(
Codigo_pedido nvarchar(50) foreign key references Pedido (Codigo_pedido),
Codigo_producto nvarchar(50) foreign key references Producto (Cod_producto),
Cantidad_producto bigint not null
)


create table Detalle_entrega
(
Codigo_entrega bigint foreign key references Entrega (Codigo_entrega),
Codigo_producto nvarchar(50) foreign key references Producto (Cod_producto),
Cantidad_producto bigint not null
)
alter table Detalle_entrega add subtotal bigint not null
alter table Detalle_entrega add verificado nvarchar (3) not null default 'NO'

select * from detalle_entrega
---------------------------------Procedimientos almacenados----------------------------------------------------
go
---------------------------------Iniciar sesión/Usuarios-----------------------------------------------------------
create procedure loggin
@nombre nvarchar (30),
@contraseña nvarchar(30),
@logg int output,
@mensaje nvarchar(50)output
as
Select @logg=count(h.Nombre_usu) from Usuario h
where Nombre_usu = @nombre and Contraseña = @contraseña
if (@logg > 0) 
select @mensaje = 'Bienvenido '+h.Cargo +' '+h.Nombre_empleado from Usuario h
where Nombre_usu = @nombre and Contraseña = @contraseña 
go
grant execute on loggin to monos
go

create procedure loggin_locales
@local nvarchar (50),
@correo nvarchar(50),
@logg int output,
@mensaje nvarchar(50)output
as
Select @logg=count(l.Nombre_local) from tLocal l
where Nombre_local = @local and Correo_local = @correo
if (@logg > 0) 
select @mensaje = 'Bienvenido '+l.Nombre_local from tLocal l
where Nombre_local = @local and Correo_local = @correo
go
grant execute on loggin_locales to monos
go

create procedure Registrar_Usu
@Nombre_usu nvarchar (30),
@Nombre_Empleado nvarchar (50),
@ID bigint,
@Telefono bigint,
@Correo nvarchar (50),
@Estado nvarchar (50),
@Cargo nvarchar (20),
@mensaje nvarchar (50) output,
@Contador int output
as
Select @Contador = count (Nombre_usu) from Usuario where Nombre_usu = @Nombre_usu
if (@Contador > 0)
select @mensaje = 'El usuario ha sido registrado anteriormente'
else
insert into Usuario values (@Nombre_usu, @Nombre_Empleado, @ID, @ID, @Telefono, @Correo, @Estado, @Cargo)
go
grant execute on Registrar_Usu to monos
go
--------------------------------------------Producto-------------------------------------------------------------
create procedure Insertar_Producto_administrador
@Cod_producto nvarchar(50),
@Nombre_producto nvarchar (100),
@Marca nvarchar(50),
@Existencia bigint,
@Tipo nvarchar (50),
@Bodega nvarchar (50),
@pasillo nvarchar (50)
as
insert into producto values(@Cod_producto,@Nombre_producto,@Marca,@Existencia,@Tipo, @Bodega, @pasillo,0)
go
grant execute on Insertar_Producto_administrador to monos
go

create procedure Insertar_Producto_su
@Cod_producto nvarchar(50),
@Nombre_producto nvarchar (100),
@Marca nvarchar(50),
@Existencia bigint,
@Tipo nvarchar (50),
@Bodega nvarchar (50),
@pasillo nvarchar (50),
@precio bigint
as
insert into producto values(@Cod_producto,@Nombre_producto,@Marca,@Existencia,@Tipo, @Bodega, @pasillo,@precio)
go
grant execute on Insertar_Producto_su to monos
go

select * from producto

create proc Actualizar_Producto_administrador
@C_producto nvarchar(50),
@Nombre_producto nvarchar (50),
@Existencia_producto bigint,
@Marca nvarchar(50),
@Tipo nvarchar(50),
@Bodega nvarchar (50),
@pasillo nvarchar (50)
as 
begin
update producto set 
Nombre_Producto = @Nombre_producto, 
Existencia = @Existencia_producto, 
Marca = @Marca,
Bodega = @Bodega,
pasillo = @pasillo,
Tipo = @Tipo where Cod_producto = @C_producto 
Select*from producto
end
go
grant execute on Actualizar_Producto to monos
go

create proc Actualizar_Producto_su
@C_producto nvarchar(50),
@Nombre_producto nvarchar (50),
@Existencia_producto bigint,
@Marca nvarchar(50),
@Tipo nvarchar(50),
@Bodega nvarchar (50),
@pasillo nvarchar (50), 
@precio bigint
as 
begin
update producto set 
Nombre_Producto = @Nombre_producto, 
Existencia = @Existencia_producto, 
Marca = @Marca,
Bodega = @Bodega,
pasillo = @pasillo,
Precio = @Precio,
Tipo = @Tipo where Cod_producto = @C_producto 
Select*from producto
end
go
grant execute on Actualizar_Producto to monos
go

-----------------------------------------------Local-----------------------------------------------------------

create procedure Registrar_loc
@Nombre_local nvarchar (50),
@Correo_local nvarchar (50),
@Telefono_local bigint,
@Direccion_local nvarchar (50),
@mensaje nvarchar (50) output,
@Contador int output
as
Select @Contador = count (Nombre_local) from tLocal where Nombre_local = @Nombre_local
if (@Contador > 0)
select @mensaje = 'El local ha sido registrado anteriormente'
else
insert into tLocal values (@Nombre_local, @Telefono_local, @Correo_local, @Direccion_local)
go
grant execute on Registrar_loc to monos
go

create proc Actualizar_loc
@Nombre_local nvarchar (50),
@Correo_local nvarchar (50),
@Telefono_local bigint,
@Direccion_local nvarchar (50)
as
begin
update tLocal set 
Nombre_local = @Nombre_local, 
Correo_local = @Correo_local, 
Telefono_local = @Telefono_local, 
Direccion_local = @Direccion_local
where Nombre_local = @Nombre_local
End
go
grant execute on Actualizar_loc to monos
go

--------------------------------------------------Pedidos-------------------------------------------------------
select * from producto

create proc Registrar_Pedido
@Nombre_usu nvarchar (30),
@hora nvarchar (30),
@Codigo nvarchar (50)
as 
insert into Pedido(Nombre_usu, hora, Codigo_pedido) values(@Nombre_usu,@hora,@codigo)
go
grant execute on Registrar_pedido to monos
go

select * from Pedido

Create proc registrar_3pedido
@Codigo_pedido nvarchar (50),
@Codigo_producto nvarchar(50),
@Cantidad_producto int
as
insert into Detalle_pedido values(@codigo_pedido,@Codigo_producto,@Cantidad_producto)
update producto set Existencia += @Cantidad_producto where Cod_producto = @Codigo_producto
go
grant execute on registrar_3pedido to monos
go
-------------------------------------------------Entregas-------------------------------------------------------

create proc Registrar_entrega
@Nombre_u nvarchar (50),
@Nombre_local nvarchar(50),
@hora nvarchar (30),
@total bigint
as 
insert into Entrega(Nombre_usu, Nombre_local, hora, total) values(@Nombre_u,@Nombre_local, @hora, @total)
go
grant execute on Registrar_entrega to monos
go

select * from entrega
select * from detalle_entrega


Create proc registrar_3entrega
@Codigo_en bigint,
@cod_pro nvarchar(50),
@C_producto bigint,
@subtotal bigint
as
insert into Detalle_entrega values(@codigo_en,@cod_pro,@C_producto,@subtotal)
update producto set Existencia -= @C_producto where Cod_producto = @cod_pro
go
grant execute on registrar_3entrega to monos
go
-------------------------------------------------Busquedas------------------------------------------------------
create proc busca_producto
@Nombre nvarchar (100)
as
select Nombre_producto, Marca, Precio, Existencia
from producto where Existencia > 0 and (Nombre_producto like '%'+@Nombre+'%' or Cod_producto like '%'+@Nombre+'%')
go
grant execute on busca_producto to monos
go	



create proc busca_producto_1
@Nombre nvarchar (100)
as
select Nombre_producto, Marca, Existencia
from producto where (Nombre_producto like '%'+@Nombre+'%' or Cod_producto like '%'+@Nombre+'%')
go
grant execute on busca_producto to monos
go

busca_producto_1 'para'

select * from producto


create proc buscar_marca
@marca nvarchar(100)
as
select * from producto where Marca like '%'+@Marca+'%'
go

create proc buscar_tipo
@tipo nvarchar(100)
as
select * from producto where Tipo like '%'+@Tipo+'%'
go

buscar_tipo 'aceites'
go 

create proc buscar_Mercancia_administrador
@Nombre nvarchar (100)
as
select Cod_producto as Codigo, Nombre_producto as Nombre, Bodega, Pasillo, Marca, Existencia, Tipo from producto
where Nombre_producto like '%'+@Nombre+'%' or Cod_producto like '%'+@Nombre+'%'
go
grant execute on buscar_Mercancia_administrador to monos
go

create proc buscar_Mercancia_su
@Nombre nvarchar (100)
as
select Cod_producto as Codigo, Nombre_producto as Nombre, Bodega, Pasillo, Marca, Existencia, Tipo, Precio from producto
where Nombre_producto like '%'+@Nombre+'%' or Cod_producto like '%'+@Nombre+'%'
go
grant execute on buscar_Mercancia_su to monos
go

create proc buscar_3entregas
@local nvarchar (50),
@fecha nvarchar(30),
@codigo bigint
as
select 
producto.nombre_producto as Nombre, 
Detalle_entrega.Cantidad_producto as "Cantidad" 
from Detalle_entrega 
inner join producto on Detalle_entrega.Codigo_producto = producto.Cod_producto 
inner join Entrega on Entrega.Codigo_entrega = Detalle_entrega.Codigo_entrega
where 
Entrega.Fecha_entrega = @fecha and 
Entrega.Nombre_local = @local and 
Entrega.Codigo_entrega = @codigo
go
grant execute on buscar_3entregas to monos
go

create proc buscar_3pedidos
@fecha nvarchar (50),
@codigo nvarchar (50)
as
select
producto.Nombre_producto as Nombre,
Detalle_Pedido.Cantidad_producto as Cantidad
from Detalle_Pedido
inner join producto on Detalle_Pedido.Codigo_producto = producto.Cod_producto
inner join Pedido on Pedido.Codigo_pedido = Detalle_Pedido.Codigo_pedido
where
Pedido.Codigo_pedido = @codigo and
Pedido.Fecha_pedido = @fecha
go
grant execute on buscar_3pedidos to monos
go

create view Consulta_Entregas
as
select 
e.Codigo as Código,
l.Nombre_local as Nombre,  
u.Nombre_empleado as Empleado, 
e.Fecha_entrega as Fecha,
e.Total as Total
from Entrega as e inner join tLocal as l on e.Nombre_local = l.Nombre_local
inner join Usuario as u on e.Nombre_usu = u.Nombre_usu
go
grant select on Consulta_Entregas to monos
go

create view Consulta_Pedidos
as
select
p.Codigo_pedido as Código,
u.Nombre_empleado as Nombre,
p.fecha_pedido as Fecha
from Pedido p inner join Usuario u on p.Nombre_usu = u.Nombre_usu
go
grant select on Consulta_Pedidos to monos
go



create view Consulta_Mercancia_administrador
as
select Cod_producto as Codigo, Nombre_producto as Nombre, Bodega, pasillo, Marca, Existencia, Tipo from producto
go
grant select on Consulta_Mercancia_administrador to monos
go

create view Consulta_Mercancia_su
as
select Cod_producto as Codigo, Nombre_producto as Nombre, Bodega, pasillo, Marca, Existencia, Tipo, Precio from producto
go
grant select on Consulta_Mercancia_su to monos
go

create view Consulta_Locales
as
Select 
Nombre_local as Nombre,
Telefono_local as Teléfono,
Correo_local as correo,
Direccion_local as Dirección
from tLocal
go
grant select on Consulta_Locales to monos
go

create procedure Registrar_Usu
@Nombre_usu nvarchar (30),
@Nombre_Empleado nvarchar (50),
@Contraseña_usu nvarchar (50),
@ID_usu bigint,
@Telefono_usu bigint,
@Correo_usu nvarchar (50),
@Estado_usu nvarchar (50),
@Cargo_usu nvarchar (20),
@mensaje nvarchar (50) output,
@Contador int output
as
Select @Contador = count (Nombre_usu) from Usuario where Nombre_usu = @Nombre_usu
if (@Contador > 0)
select @mensaje = 'El usuario ya ha sido registrado'
else
insert into Usuario values (@Nombre_usu, @Nombre_Empleado, @Contraseña_usu, @ID_usu, @Telefono_usu, @Correo_usu, @Estado_usu, @Cargo_usu)
select * from Usuario
go


---------BUSQUEDAS POR FECHAS
create proc resumen_dia
@fecha nvarchar(30),
@local nvarchar(50)
as
select e.Codigo as Código, p.Cod_producto as 'Código Producto', p.Nombre_producto as 'Nombre Producto', d.Cantidad_producto as Cantidad,
d.verificado as 'Verificado?', e.Fecha_entrega as Fecha, e.Hora, l.Nombre_Local as 'Local', p.Marca, p.Precio, d.Subtotal as Subtotal from tLocal l
inner join Entrega e on l.Nombre_local = e.Nombre_local 
inner join Detalle_entrega d on e.Codigo_entrega = d.Codigo_entrega
inner join Producto p on d.Codigo_producto = p.Cod_producto where e.fecha_entrega = @fecha and l.Nombre_local = @local



create proc resumen_fechas
@fecha1 nvarchar(30),
@fecha2 nvarchar(30),
@local nvarchar(50)
as
select e.Codigo as Código, p.Cod_producto as 'Código Producto', p.Nombre_producto as 'Nombre Producto', d.Cantidad_producto as Cantidad,
d.verificado as 'Verificado?', e.Fecha_entrega as Fecha, e.Hora, l.Nombre_Local as 'Local', p.Marca, p.Precio, d.Subtotal as Subtotal from tLocal l
inner join Entrega e on l.Nombre_local = e.Nombre_local 
inner join Detalle_entrega d on e.Codigo_entrega = d.Codigo_entrega
inner join Producto p on d.Codigo_producto = p.Cod_producto where e.fecha_entrega >= @fecha1 and e.Fecha_entrega <= @fecha2 and l.Nombre_local = @local
order by p.Cod_producto asc


resumen_fechas '" + fecha + "','" + fecha2 + "','" + local + "'

resumen_fechas '2021-02-08','2021-02-28','Local 137'

codigo_entrega
nombre_producto
bodega
cantidad
fecha
hora
nombre local
marca
precio
subtotal

select * from Entrega
resumen_dia '2021-02-05'
----------------------------------------------------------------------------------------------------------------
delete from usuario where nombre_usu = 'admin'
insert into Usuario values('admin','Nombre','password',123,7231234,'a@a.a','activo','Empleado')
insert into usuario values('usuario','Juan','1234',321654987,1212121212,'b@b.b','activo','Empleado')
insert into usuario values('user','Nicolas','12345',32987,1212,'ba@ba.ba','activo','Empleado')
insert into Usuario values('administrador','Alfred Duque','12345',123,123456789,'q@q.q','activo','administrador')
---------------------------------------------------Vistas-------------------------------------------------------
go
create view vista_usuarios
as
Select Nombre_usu as Usuario, 
Nombre_empleado as Nombres, 
DNI as "Doc. Identidad",
Telefono as Teléfono,
Correo,
Estado,
Cargo from Usuario
go

select * from vista_usuarios
go
create view vista_locales
as
Select 
Nombre_local as Nombre,
Telefono_local as Teléfono,
Correo_local as correo,
Direccion_local as Dirección
from tLocal
go
grant select on vista_locales to monos
go

insert into producto values('cod_1','nombre prod','marca prod',50,'liquido')

insert into Pedido(Nombre_usu) values ('admin')


select * from Pedido
select * from Usuario

select * from producto

grant select on Usuario to monos
grant select on producto to monos
grant select on tLocal to monos
grant select on Pedido to monos
grant select on vista_productos to monos
grant select on vista_usuarios to monos
grant select on Entrega to monos
grant select on Detalle_entrega to monos


select * from producto
select * from vista_productos
select * from vista_usuarios
select * from Entrega

Select * from Usuario where Nombre_usu = 'admin' and Contraseña = 'password' 

update producto set Existencia = 200

delete from pedido

select * from producto

select * from Entrega
select * from Detalle_entrega

select * from Pedido
select * from Detalle_Pedido

select * from Detalle_entrega where Codigo_entrega = 1


go
create proc detalle
@codigo nvarchar(30)
as
select Producto.Nombre_producto as Nombre, Detalle_entrega.Cantidad_producto as Cantidad, Detalle_entrega.Subtotal as Subtotal from 
producto inner join Detalle_entrega on producto.Cod_producto = Detalle_entrega.Codigo_producto
inner join Entrega on Detalle_entrega.Codigo_entrega = entrega.Codigo_entrega where Entrega.Codigo = @codigo
go

create proc detalle_p
@codigo nvarchar(30)
as
select Producto.Nombre_producto as Nombre, Detalle_pedido.Cantidad_producto as Cantidad from 
producto inner join Detalle_pedido on producto.Cod_producto = Detalle_pedido.Codigo_producto
inner join Pedido on Detalle_pedido.Codigo_pedido = Pedido.Codigo_pedido where Pedido.Codigo_pedido = @codigo
go

detalle_p 'cod_1'

create database test
use test


create table prueba
(
a nvarchar (10), 
b nvarchar (50)
)

insert into prueba values ('ABC_001','s')
insert into prueba values ('ABC_002','s')
insert into prueba values ('ABC_003','s')
insert into prueba values ('ABC_004','s')
insert into prueba values ('ABC_005','s')
insert into prueba values ('ABC_006','s')
insert into prueba values ('ABC_007','s')
insert into prueba values ('ABC_008','s')
insert into prueba values ('ABC_009','s')
insert into prueba values ('ABC_010','s')

insert into prueba values ('xyz_001','q')
insert into prueba values ('xyz_002','q')
insert into prueba values ('xyz_003','q')
insert into prueba values ('xyz_004','q')
insert into prueba values ('xyz_005','q')
insert into prueba values ('xyz_006','q')
insert into prueba values ('xyz_007','q')
insert into prueba values ('xyz_008','q')
insert into prueba values ('xyz_009','q')
insert into prueba values ('xyz_010','q')

select top 1 a from prueba where a like 'ABC_%' order by a desc
go


select * from producto
select * from entrega

go
create proc buscar_historial_entregas
@nomproducto nvarchar(100)
as
select Producto.Nombre_producto, Detalle_entrega.Cantidad_producto, entrega.Codigo, Entrega.Fecha_entrega, Usuario.Nombre_empleado from Producto 
inner join detalle_entrega on Producto.Cod_producto=Detalle_entrega.Codigo_producto
inner join entrega on Detalle_entrega.Codigo_entrega = Entrega.Codigo_entrega
inner join Usuario on Entrega.Nombre_usu = usuario.Nombre_usu
where producto.Nombre_producto like @nomproducto+'%' or producto.Cod_producto like @nomproducto+'%' order by Entrega.Fecha_entrega desc
go



buscar_historial_entregas 'keratina'

go
create proc buscar_historial_pedidos
@nomproducto nvarchar(100)
as
select Producto.Nombre_producto, Detalle_Pedido.Cantidad_producto, Pedido.Codigo_pedido, Pedido.Fecha_pedido, Usuario.Nombre_empleado from Producto 
inner join detalle_pedido on Producto.Cod_producto=Detalle_pedido.Codigo_producto
inner join pedido on Detalle_pedido.Codigo_pedido = pedido.Codigo_pedido
inner join Usuario on Pedido.Nombre_usu = usuario.Nombre_usu
where producto.Nombre_producto like @nomproducto+'%' or producto.Cod_producto like @nomproducto+'%' order by Pedido.Fecha_pedido desc
go

buscar_historial_pedidos '7707271929469'



delete from producto where Cod_producto = '048155903135'
select * from tLocal
select Cod_producto from producto where Cod_producto like 'maq%' order by Cod_Producto desc


update producto set nombre_producto = 'Pestañina definicion verde Bardot', marca = 'BARDOT' where Cod_producto = '7703799346511'



select * from usuario

insert into Usuario values ('vanessa', 'Vanessa','1010222998',1010222998,1111111,'a@a.a','activo','administrador')

update usuario set cargo = 'su' where nombre_usu = 'admin'


select * from producto

update usuario set cargo = 'su' where nombre_usu = 'admin'

delete from usuario where nombre_usu = 'admin'

select * from usuario



create proc eliminar_3entrega
@Codigo_en bigint,
@cod_pro nvarchar(50),
@C_producto bigint
as
delete from Detalle_entrega where Codigo_entrega = @Codigo_en and Codigo_producto = @Cod_pro
update producto set Existencia += @C_producto where Cod_producto = @cod_pro
GO

create proc actualizar_3entrega
@Codigo_en bigint,
@cod_pro nvarchar(50),
@C_producto bigint,
@verificado nvarchar(3)
as
declare @cant bigint
set @cant = (select cantidad_producto from Detalle_entrega 
where Codigo_entrega = @Codigo_en and Codigo_producto = @cod_pro )
update producto set Existencia += @cant where Cod_producto = @cod_pro
declare @precio bigint
set @precio = (select precio from producto where Cod_producto = @cod_pro)
update detalle_entrega set 
Cantidad_producto = @C_producto,
subtotal = (@C_producto * @precio),
verificado = @verificado
where Codigo_entrega = @Codigo_en and Codigo_producto = @cod_pro
update producto set Existencia -= @C_producto where Cod_producto = @cod_pro


ENT_665
ACC_1002368724
select * from detalle_entrega

actualizar_3entrega 3,'MAQ_822593486',20,'si'

select * from producto where Cod_producto = 'MAQ_822593486'

delete from detalle_entrega
delete from detalle_pedido
delete from entrega
delete from pedido