--CREADORES:
--          Ignacio Pereira
--          Cristofer González

--Verificacion en SysDataBases
use Master
go
if exists(Select * FROM SysDataBases WHERE name='ProyectoFinal')
BEGIN
	DROP DATABASE ProyectoFinal
END
go
-----------------------------------------------------------------------------------
--Creacion de la base de datos 
create database ProyectoFinal
on(
	Name = 'ProyectoFinal',
	FileName = 'C:\M1\ProyectoFinal.mdf'
)
go
-----
--Usamos el PF
USE ProyectoFinal
go
---------------------------------------------------------------------------------
------------------------Creacion de las tablas-----------------------------------
create Table Administradores
(
	usuario varchar(30) not null primary key,
	contraseña varchar(30) not null,
	nom_completo varchar(70) not null
)
go

-----------------------------------------------------------------------------
Create Table Categorias
(
	codigo varchar(4) not null primary key,
	nombre varchar (20) not null
)
go
-----------------------------------------------------------------------------
Create Table Juegos
(
	codigo int IDENTITY(1,1) not null primary key,
	fecha Datetime not null,
	dificultad Varchar (10) not null,
	creador varchar(30) not null foreign key references Administradores(usuario),
)
go
-----------------------------------------------------------------------------
create Table Preguntas
(
	codigo varchar(5) not null primary key,
	texto varchar(200) not null,
	valor int not null ,
	correcta int not null,
	respuesta1 varchar (200)not null,
	respuesta2 varchar (200)not null,
	respuesta3 varchar (200)not null,
	categoria varchar(4) not null foreign key references Categorias(codigo),
	juego int not null foreign key references Juegos(codigo)
	
)
go
-----------------------------------------------------------------------------
Create Table Jugadas
(
	fecha DateTime not null primary key,
	nombre_jugador varchar (50) not null,
	puntaje int not null,
	juego int not null foreign key references Juegos(codigo)
)
go

-----------------------------------------------------------------------------
--------------------------------Procedimientos almacenados-------------------
create proc GrillaInicial
-- Imprime las jugadas en orden decreciente
as
begin
	Select fecha, nombre_jugador,puntaje,juego
	from Jugadas
	order by fecha desc
end
go
-------------------------------------------------
create proc ListarJugadasJuego
-- Imprime las jugadas de un juego
@juego int
as
begin
	Select fecha, nombre_jugador,puntaje,juego
	from Jugadas
	where Jugadas.juego= @juego
end
go
----------------------------------------------------
create proc JuegosConPreguntas
as
begin
	Select distinct Juegos.codigo,fecha,dificultad,creador
	from Juegos inner join Preguntas
	on Juegos.codigo=Preguntas.juego
	where Preguntas.juego = Juegos.codigo and Juegos.codigo != 1
end
go
----------------------------------------------------
create proc Buscarjuego
@juego int
as
begin
	select * from Juegos where codigo=@juego
end
go
---------------------------------------------------
create proc ListarTodosLosJuegos
as
begin
	select * from Juegos
	where Juegos.codigo != 1
end
go
----------------------------------------------------
create proc CodigoDePreguntasDeJuego
@juego int
as
begin
	Select Preguntas.codigo
	from Preguntas inner join Juegos
	on Juegos.codigo=Preguntas.juego
	where Preguntas.juego = @juego
end
go
-----------------------------------------------------
create proc CantidadDePreguntas
@juego int
as
begin
	return(
	Select COUNT(codigo)
	from Preguntas
	where Preguntas.juego = @juego)
end
go
-----------------------------------------------------
create proc PreguntasYRespuestas
@codigo varchar(5)
as
begin
	select texto, valor, respuesta1,respuesta2,respuesta3,correcta
	from Preguntas
	where Preguntas.codigo=@codigo
end
go
-----------------------------------------------------
create proc AlmacenarJugadas
@juego int,
@Usuario varchar (50),
@Puntaje int
as
begin
	insert Jugadas Values (getdate(),@Usuario,@Puntaje,@juego)
end
go
-----------------------------------------------------
Create proc  Logueo 
@Usuario varchar(30),
@Contraseña varchar(30) 
AS
Begin
	Select *
	From Administradores A
	Where a.usuario = @Usuario AND A.contraseña = @Contraseña
End
go
-----------------------------------------------------
Create proc AltaUsuario
@Usuario varchar(30), 
@Contraseña varchar(30),
@Nom_Completo varchar(70)
AS
Begin
	if (EXISTS(Select * From Administradores Where usuario = @Usuario))
		return -1--ya existe en la base
		
	--si llego aca puedo agregar
	INSERT Administradores VALUES(@Usuario, @Contraseña, @Nom_Completo) 
	
	IF(@@Error=0)
		RETURN 1
	else
		RETURN -2
End
go
-----------------------------------------------------
create proc BuscarAdmin
@usuario varchar(30)
as
begin
	select * from Administradores where usuario=@usuario
end
go
---------------------------------------------------
create proc AgregarCategoria
 @Codigo varchar(4),
 @NombreCategoria varchar(20)
 as
 begin
    if exists (select*from Categorias where codigo=@Codigo)
		return -1;--ya existe la categoria
	else
		begin
			insert Categorias Values (@Codigo,@NombreCategoria)
			return 1;--se Agrego correctamente 
		end
end
go
----------------------------------------------------
create proc BuscarCategoria
@codigo varchar(4)
as
begin
	if not exists(select * from Categorias where codigo=@codigo)
		return -1; --La categoria no existe
	else
		select * from Categorias where codigo=@codigo
end
go
----------------------------------------------------
create proc ModificarCategoria
@codigo varchar(4),
@NombreCodigo varchar(20)
as
begin
	if not exists(select * from Categorias where codigo=@codigo)
		return -1 --La categoria no existe

	declare @error int
	update Categorias set codigo=@codigo, nombre=@NombreCodigo where codigo=@codigo
	set @error=@@ERROR

	IF(@Error=0)
		return 1 --Se modificó correctamente
	else
		return -2 --Ocurrió un error
end
go
----------------------------------------------------
create proc EliminarCategoria
@codigo varchar(4)
as
begin
	IF (NOT EXISTS (SELECT codigo FROM Categorias WHERE codigo =@codigo))
		RETURN -1;-- La categoria no existe en el sistema

	IF (EXISTS (SELECT categoria FROM Preguntas WHERE categoria=@codigo ))
		return -2;--Tiene Preguntas asociadas
	else
		DELETE Categorias WHERE  codigo=@codigo;
		return 1; -- Se eliminó correctamente
end
go
---------------------------------------------------
create proc AgregarPregunta
--Almacenar preguntas en el sistema
 @Codigo varchar(5),
 @texto varchar (200),
 @valor int,
 @correcta int,
 @respuesta1 varchar (200),
 @respuesta2 varchar (200),
 @respuesta3 varchar (200),
 @categoria varchar (4)
 as
 begin
    if exists (select*from Preguntas where codigo=@codigo)
		return -1;--ya existe la Pregunta
	else
		begin
			insert Preguntas Values (@Codigo,@texto,@valor,@correcta,@respuesta1,@respuesta2,@respuesta3,@categoria,1)
			return 1;--se Agrego correctamente 
		end
end
go
--------------------------------------------------
create proc AgregarJuego
@dificultad varchar (10),
@UsuCreador varchar(30)
as
begin
	insert Juegos Values (getdate(),@dificultad,@UsuCreador)
end
go
--------------------------------------------------
create proc listarJuegos
--Lista los juegos con las preguntas asociadas
as
begin
	Select distinct Preguntas.juego
	from Preguntas
	
end
go
---------------------------------------------------
create proc ListarPreguntasJuego 
--imprime todas las preguntas de un juego
@juego int 
AS
Begin
	Select P.codigo,texto,respuesta1,respuesta2,respuesta3,correcta,valor,juego,categoria
	From Preguntas P inner join Juegos J
	     on p.juego = J.codigo
	Where P.juego = @juego
End
go
----------------------------------------------------
create proc ListarPreguntasNoAsociadas
--lista las preguntas que no esten asociadas a un juego
@juego int
as
begin
   Select *
   from Preguntas
   where juego != @juego
end
go
---------------------------------------------------
create proc BuscarPreguntaPorCodigo
@codigo varchar(5)
as
begin
	select * from Preguntas
	where codigo = @codigo
end
go
----------------------------------------------------
create proc AgregarPreguntaJuego
@codigoNuevo varchar(5),
@texto varchar(200),
@valor int,
@correcta int,
@respuesta1 varchar(200),
@respuesta2 varchar(200),
@respuesta3 varchar(200),
@categoria varchar(4),
@juego int
as
begin
	insert Preguntas Values (@codigoNuevo,@texto,@valor,@correcta,@respuesta1,@respuesta2,@respuesta3,@categoria,@juego)
end
go
---------------------------------------------------
Create proc EliminarPreguntaJuego
@codigo varchar(5),
@juego int
as
begin
	DELETE Preguntas WHERE  codigo=@codigo and juego=@juego;
end
go

---------------------------------------------------
--ESTO TIENE QUE ESTAR,UNO ES EL ADMINISTRADOR Y EL OTRO PARA PODER GUARDAR LAS PREGUNTAS!!
insert Administradores values ('admin','admin','admin')
insert Juegos Values (getdate(),'prueba','admin')