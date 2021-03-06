USE [cedicoop]
GO
/****** Object:  StoredProcedure [dbo].[SP_VOTAR_ACUERDO]    Script Date: 14/02/2020 03:37:59 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_VOTAR_ACUERDO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_VOTAR_ACUERDO]
GO
/****** Object:  StoredProcedure [dbo].[SP_VALIDAR_USUARIO]    Script Date: 14/02/2020 03:37:59 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_VALIDAR_USUARIO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_VALIDAR_USUARIO]
GO
/****** Object:  StoredProcedure [dbo].[SP_VALIDAR_SOCIO_APP]    Script Date: 14/02/2020 03:37:59 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_VALIDAR_SOCIO_APP]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_VALIDAR_SOCIO_APP]
GO
/****** Object:  StoredProcedure [dbo].[SP_REGISTRAR_SOCIO_EN_ASAMBLEA]    Script Date: 14/02/2020 03:37:59 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_REGISTRAR_SOCIO_EN_ASAMBLEA]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_REGISTRAR_SOCIO_EN_ASAMBLEA]
GO
/****** Object:  StoredProcedure [dbo].[SP_REGISTRAR_SOCIO_APP]    Script Date: 14/02/2020 03:37:59 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_REGISTRAR_SOCIO_APP]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_REGISTRAR_SOCIO_APP]
GO
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_SOCIOS]    Script Date: 14/02/2020 03:37:59 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_OBTENER_SOCIOS]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_OBTENER_SOCIOS]
GO
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_EXPEDIENTES]    Script Date: 14/02/2020 03:37:59 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_OBTENER_EXPEDIENTES]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_OBTENER_EXPEDIENTES]
GO
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_ASAMBLEAS]    Script Date: 14/02/2020 03:37:59 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_OBTENER_ASAMBLEAS]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_OBTENER_ASAMBLEAS]
GO
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_ACUERDOS_POR_SOCIO]    Script Date: 14/02/2020 03:37:59 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_OBTENER_ACUERDOS_POR_SOCIO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_OBTENER_ACUERDOS_POR_SOCIO]
GO
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_ACUERDOS]    Script Date: 14/02/2020 03:37:59 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_OBTENER_ACUERDOS]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_OBTENER_ACUERDOS]
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_EXPEDIENTES]    Script Date: 14/02/2020 03:37:59 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_INSERTAR_EXPEDIENTES]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_INSERTAR_EXPEDIENTES]
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_ACUERDO]    Script Date: 14/02/2020 03:37:59 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_INSERTAR_ACUERDO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_INSERTAR_ACUERDO]
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_ACTUALIZA_ASAMBLEA]    Script Date: 14/02/2020 03:37:59 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_INSERTAR_ACTUALIZA_ASAMBLEA]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_INSERTAR_ACTUALIZA_ASAMBLEA]
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTA_ACTUALIZA_SOCIO]    Script Date: 14/02/2020 03:37:59 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_INSERTA_ACTUALIZA_SOCIO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_INSERTA_ACTUALIZA_SOCIO]
GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINAR_EXPEDIENTE]    Script Date: 14/02/2020 03:37:59 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ELIMINAR_EXPEDIENTE]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_ELIMINAR_EXPEDIENTE]
GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINAR_ASAMBLEA]    Script Date: 14/02/2020 03:37:59 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ELIMINAR_ASAMBLEA]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_ELIMINAR_ASAMBLEA]
GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINAR_ACUERDO]    Script Date: 14/02/2020 03:37:59 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ELIMINAR_ACUERDO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_ELIMINAR_ACUERDO]
GO
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZA_ESTATUS_SOCIO]    Script Date: 14/02/2020 03:37:59 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ACTUALIZA_ESTATUS_SOCIO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_ACTUALIZA_ESTATUS_SOCIO]
GO
/****** Object:  StoredProcedure [dbo].[SP_ACTIVAR_ASAMBLEA]    Script Date: 14/02/2020 03:37:59 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ACTIVAR_ASAMBLEA]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_ACTIVAR_ASAMBLEA]
GO
/****** Object:  StoredProcedure [dbo].[SP_ACTIVAR_ACUERDO]    Script Date: 14/02/2020 03:37:59 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ACTIVAR_ACUERDO]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_ACTIVAR_ACUERDO]
GO
/****** Object:  Table [dbo].[Votos]    Script Date: 14/02/2020 03:37:59 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Votos]') AND type in (N'U'))
DROP TABLE [dbo].[Votos]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 14/02/2020 03:37:59 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuarios]') AND type in (N'U'))
DROP TABLE [dbo].[Usuarios]
GO
/****** Object:  Table [dbo].[SociosEnAsamblea]    Script Date: 14/02/2020 03:37:59 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SociosEnAsamblea]') AND type in (N'U'))
DROP TABLE [dbo].[SociosEnAsamblea]
GO
/****** Object:  Table [dbo].[Socios]    Script Date: 14/02/2020 03:37:59 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Socios]') AND type in (N'U'))
DROP TABLE [dbo].[Socios]
GO
/****** Object:  Table [dbo].[Expedientes]    Script Date: 14/02/2020 03:37:59 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Expedientes]') AND type in (N'U'))
DROP TABLE [dbo].[Expedientes]
GO
/****** Object:  Table [dbo].[Cat_Estatus_Asamblea]    Script Date: 14/02/2020 03:37:59 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cat_Estatus_Asamblea]') AND type in (N'U'))
DROP TABLE [dbo].[Cat_Estatus_Asamblea]
GO
/****** Object:  Table [dbo].[Asamblea]    Script Date: 14/02/2020 03:37:59 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Asamblea]') AND type in (N'U'))
DROP TABLE [dbo].[Asamblea]
GO
/****** Object:  Table [dbo].[Acuerdos]    Script Date: 14/02/2020 03:37:59 p. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Acuerdos]') AND type in (N'U'))
DROP TABLE [dbo].[Acuerdos]
GO
/****** Object:  Table [dbo].[Acuerdos]    Script Date: 14/02/2020 03:37:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Acuerdos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Acuerdos](
	[idAcuerdo] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](500) NULL,
	[votosAFavor] [int] NULL,
	[votosEnContra] [int] NULL,
	[votosAnulados] [int] NULL,
	[idAsamblea] [int] NOT NULL,
	[fechaAlta] [datetime] NULL,
	[noAcuerdo] [int] NOT NULL,
	[activo] [int] NULL,
	[activarVotacion] [bit] NULL,
 CONSTRAINT [PK__Acuerdos__20BB054605039170] PRIMARY KEY CLUSTERED 
(
	[idAcuerdo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Asamblea]    Script Date: 14/02/2020 03:37:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Asamblea]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Asamblea](
	[idAsamblea] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](45) NULL,
	[direccion] [varchar](45) NULL,
	[fechaAlta] [datetime] NULL,
	[latitud] [varchar](45) NULL,
	[longitud] [varchar](45) NULL,
	[sociosConvocados] [int] NULL,
	[asistenciaDeSocios] [int] NULL,
	[activo] [bit] NULL,
	[fechaAsamblea] [datetime] NULL,
	[idEstatusAsamblea] [int] NULL,
 CONSTRAINT [PK__Asamblea__38BBBA3C2700CE3C] PRIMARY KEY CLUSTERED 
(
	[idAsamblea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cat_Estatus_Asamblea]    Script Date: 14/02/2020 03:37:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cat_Estatus_Asamblea]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Cat_Estatus_Asamblea](
	[id_estatus_asamblea] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](500) NULL,
 CONSTRAINT [PK_Cat_Estatus_Asamblea] PRIMARY KEY CLUSTERED 
(
	[id_estatus_asamblea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Expedientes]    Script Date: 14/02/2020 03:37:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Expedientes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Expedientes](
	[idExpedientes] [int] IDENTITY(1,1) NOT NULL,
	[nombreDocumento] [varchar](500) NULL,
	[pathExpediente] [varchar](500) NULL,
	[idSocio] [int] NOT NULL,
	[fechaAlta] [datetime] NULL,
	[extencionArchivo] [varchar](50) NULL,
	[pesoByte] [int] NULL,
 CONSTRAINT [PK__Expedien__CBA7018838B60FC8] PRIMARY KEY CLUSTERED 
(
	[idExpedientes] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Socios]    Script Date: 14/02/2020 03:37:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Socios]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Socios](
	[idSocio] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](45) NULL,
	[apellidos] [varchar](45) NULL,
	[mail] [varchar](45) NULL,
	[telefono] [varchar](45) NULL,
	[numeroSocioCMV] [varchar](45) NULL,
	[Token] [varchar](45) NULL,
	[latitudDireccion] [varchar](45) NULL,
	[longitudDireccion] [varchar](45) NULL,
	[direccion] [varchar](45) NULL,
	[fechaAlta] [datetime2](0) NULL,
	[activo] [bit] NULL,
	[contrasena] [varchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[idSocio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SociosEnAsamblea]    Script Date: 14/02/2020 03:37:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SociosEnAsamblea]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SociosEnAsamblea](
	[idSocioAsamblea] [int] IDENTITY(1,1) NOT NULL,
	[fechaAlta] [datetime] NOT NULL,
	[idSocio] [int] NOT NULL,
	[idAsamblea] [int] NOT NULL,
 CONSTRAINT [PK__SociosEn__FB3E692688AF470D] PRIMARY KEY CLUSTERED 
(
	[idSocioAsamblea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 14/02/2020 03:37:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuarios]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Usuarios](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[usuario] [varchar](45) NULL,
	[contrasena] [varchar](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Votos]    Script Date: 14/02/2020 03:37:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Votos]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Votos](
	[idVoto] [int] IDENTITY(1,1) NOT NULL,
	[encontra] [bit] NULL,
	[aFavor] [bit] NULL,
	[anulado] [bit] NULL,
	[fechaAlta] [date] NOT NULL,
	[IdSocio] [bigint] NOT NULL,
	[idAcuerdo] [int] NOT NULL,
	[idAsamblea] [int] NOT NULL,
 CONSTRAINT [PK__Votos__0355859968205909] PRIMARY KEY CLUSTERED 
(
	[idVoto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ACTIVAR_ACUERDO]    Script Date: 14/02/2020 03:37:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ACTIVAR_ACUERDO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ACTIVAR_ACUERDO] AS' 
END
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SP_ACTIVAR_ACUERDO]
@idAcuerdo int,
@idAsamblea int ,
@activarVotacion bit
AS
BEGIN
	declare
		@votosTotalesFavor int,
		@votosTotalesContra int

		Select @votosTotalesFavor =  sum(cast(aFavor as int )), @votosTotalesContra = sum(cast (encontra as int)) 
		from Votos where idAcuerdo = @idAcuerdo and idAsamblea = @idAsamblea


	   update Acuerdos set activarVotacion = @activarVotacion , votosAFavor = @votosTotalesFavor , votosEnContra = @votosTotalesContra
	   where idAcuerdo = @idAcuerdo and idAsamblea = @idAsamblea


	select 200 estatus ,case when  @activarVotacion =1 then 'Acuerdo Activado, Ahora los socios ya pueden votar.' else 'Acuerdo Desactivado, Ahora los socios ya No pueden votar' end as mensaje
END

GO
/****** Object:  StoredProcedure [dbo].[SP_ACTIVAR_ASAMBLEA]    Script Date: 14/02/2020 03:37:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ACTIVAR_ASAMBLEA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ACTIVAR_ASAMBLEA] AS' 
END
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SP_ACTIVAR_ASAMBLEA] 
@idAsamblea int 
AS
BEGIN
	if exists ( select * from Asamblea where idEstatusAsamblea = 2)
	begin
		select -1 as estatus , 'Existe una Asamblea Activa, por favor finalize la Asamblea anterior' as mensaje
		return
	end
	Update Asamblea set idEstatusAsamblea = 2  where idAsamblea = @idAsamblea

	
END

GO
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZA_ESTATUS_SOCIO]    Script Date: 14/02/2020 03:37:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ACTUALIZA_ESTATUS_SOCIO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ACTUALIZA_ESTATUS_SOCIO] AS' 
END
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SP_ACTUALIZA_ESTATUS_SOCIO]
@IdSocio int,
@activo bit
AS
BEGIN
	UPDATE Socios SET activo = @activo where idSocio = @IdSocio
	SELECT 200  as estatus , 'ok' mensaje
END

GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINAR_ACUERDO]    Script Date: 14/02/2020 03:37:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ELIMINAR_ACUERDO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ELIMINAR_ACUERDO] AS' 
END
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SP_ELIMINAR_ACUERDO]
@idAcuerdo int,
@idAsamblea int 
AS
BEGIN

   update  Acuerdos set activo = 0 where idAcuerdo = @idAcuerdo

    UPDATE A
	SET    A.noAcuerdo = B.noAcuerdo
    FROM   Acuerdos A  join 
   (select ROW_NUMBER() OVER (ORDER BY idAcuerdo) noAcuerdo  , idAcuerdo , idAsamblea from  Acuerdos B where idAsamblea = @idAsamblea) b
   on a.idAcuerdo  = b.idAcuerdo
   where a.activo = 1
   select 200 estatus , 'Registro eliminado exitosamente' mensaje

END

GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINAR_ASAMBLEA]    Script Date: 14/02/2020 03:37:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ELIMINAR_ASAMBLEA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ELIMINAR_ASAMBLEA] AS' 
END
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SP_ELIMINAR_ASAMBLEA]
@idAsamblea INT
AS
BEGIN
	 UPDATE [dbo].[Asamblea] SET activo = 0 WHERE idAsamblea =@idAsamblea

	 UPDATE  [dbo].[Acuerdos] SET activo = 0 WHERE idAsamblea =@idAsamblea

	 SELECT 200 estatus , 'Asamblea eliminada exitosamente' mensaje

END

GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINAR_EXPEDIENTE]    Script Date: 14/02/2020 03:37:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_ELIMINAR_EXPEDIENTE]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_ELIMINAR_EXPEDIENTE] AS' 
END
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SP_ELIMINAR_EXPEDIENTE]
	@idSocio int ,
	@idExpediente bigint null
	

AS
BEGIN
	 delete from Expedientes 
	 where idExpedientes = Coalesce(@idExpediente, idExpedientes) and idSocio = @idSocio
	 select 200 estatus , 'Registro eliminado exitosamente' mensaje
END

GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTA_ACTUALIZA_SOCIO]    Script Date: 14/02/2020 03:37:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_INSERTA_ACTUALIZA_SOCIO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_INSERTA_ACTUALIZA_SOCIO] AS' 
END
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SP_INSERTA_ACTUALIZA_SOCIO]
@idSocio	int = null,
@nombre	varchar(255),
@apellidos	varchar(255),
@mail	varchar(255),
@telefono	varchar(255),
@numeroSocioCMV	varchar(255),
@Token	varchar(255) = null,
@latitudDireccion	varchar(255) = null,
@longitudDireccion	varchar(255) = null,
@direccion	varchar(255) = null
AS
BEGIN

declare 
@idSocioAux int 

set @idSocioAux = @idSocio

	IF @idSocio is null
	BEGIN
		INSERT INTO  SOCIOS (nombre,
							apellidos,
							mail,
							telefono,
							numeroSocioCMV,
							Token,
							latitudDireccion,
							longitudDireccion,
							direccion,
							fechaAlta,
							activo)
					VALUES(
					
					@nombre,
					@apellidos,
					@mail,
					@telefono,
					@numeroSocioCMV	,
					@Token,
					@latitudDireccion,
					@longitudDireccion,
					@direccion,
					GETDATE(),
					1
					)
		  select @idSocio = MAX(idSocio) from Socios 
	END
	ELSE
	BEGIN
			UPDATE Socios SET 
							nombre=               @nombre,
							apellidos=			  @apellidos,
							mail=				  @mail,
							telefono=			  @telefono,
							numeroSocioCMV=		  @numeroSocioCMV,
							Token=				  @Token,
							latitudDireccion=	  @latitudDireccion,
							longitudDireccion=	  @longitudDireccion,
							direccion=			  @direccion
			where idSocio = @idSocio
							
	END
	if @@error = 0
		SELECT 200  as estatus ,
		case when @idSocioAux is null then 'Socio agregado exitosamente' else 'Socio actualizado extisamente' end mensaje
		, @idSocio idSocio
	else
		SELECT -1  as estatus ,ERROR_MESSAGE() mensaje
END

GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_ACTUALIZA_ASAMBLEA]    Script Date: 14/02/2020 03:37:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_INSERTAR_ACTUALIZA_ASAMBLEA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_INSERTAR_ACTUALIZA_ASAMBLEA] AS' 
END
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SP_INSERTAR_ACTUALIZA_ASAMBLEA]
@idAsamblea	int,
@nombre	varchar(100),
@direccion	varchar(500),
@idEstatusAsamblea int ,
@latitud	varchar(100) = null,
@longitud	varchar(100)= null,
@sociosConvocados	int = null,
@fechaAsamblea DATETIME = null
--@activo BIT  = null
AS
BEGIN
	IF @idAsamblea   IS NULL
	BEGIN
		INSERT INTO Asamblea (
								nombre,
								direccion,
								fechaAlta,
								latitud,
								longitud,
								sociosConvocados,
								activo,
								fechaAsamblea,
								idEstatusAsamblea
								)
					 VALUES (
					 @nombre	,
					 @direccion	,
					 GETDATE()	,
					 @latitud	,
					 @longitud	,
					 @sociosConvocados,
					 1,
					 @fechaAsamblea,
					 @idEstatusAsamblea)
	END
	ELSE
	BEGIN
			UPDATE Asamblea SET 
			nombre =                   @nombre	,
			direccion=				   @direccion	,
			latitud=     			   @latitud	,
			longitud=				   @longitud	,
			sociosConvocados=		   @sociosConvocados,
			fechaAsamblea =            @fechaAsamblea,
			--activo = @activo,
			idEstatusAsamblea = @idEstatusAsamblea
			WHERE idAsamblea = @idAsamblea
	END

	if @@error = 0
		SELECT 200  as estatus , case when @idAsamblea is null then 'Asamblea agregada exitosamente' else 'Asamblea actualizada extisamente' end mensaje
	else
		SELECT -1  as estatus ,ERROR_MESSAGE() mensaje

END

GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_ACUERDO]    Script Date: 14/02/2020 03:37:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_INSERTAR_ACUERDO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_INSERTAR_ACUERDO] AS' 
END
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SP_INSERTAR_ACUERDO]
@idAcuerdo	int = null,
@descripcion	varchar(500),
@idAsamblea	int,
@noAcuerdo int ,
@fechaAlta	datetime= null

AS
BEGIN

select @fechaAlta  = coalesce(@fechaAlta , getdate())

	 if @idAcuerdo is null
	 BEGIN
		 INSERT INTO Acuerdos (
								descripcion,
								idAsamblea,
								fechaAlta,
								noAcuerdo,
								activo,
								activarVotacion )
		 VALUES (
		 @descripcion,
		 @idAsamblea,	
		 @fechaAlta,
		 @noAcuerdo,
		 1,
		 0
		 )
		 SELECT 200  as estatus , 'registro agregado correctamente' mensaje
	 END
	 ELSE
	 BEGIN
		UPDATE Acuerdos SET 
								descripcion=     @descripcion,
								idAsamblea =	 @idAsamblea,	
								fechaAlta  =	 @fechaAlta
		WHERE idAcuerdo = @idAcuerdo
		SELECT 200  as estatus , 'registro actualizado correctamente' mensaje
	 END

	 if @@error <> 0
		SELECT -1  as estatus ,ERROR_MESSAGE() mensaje
	 
END

GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_EXPEDIENTES]    Script Date: 14/02/2020 03:37:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_INSERTAR_EXPEDIENTES]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_INSERTAR_EXPEDIENTES] AS' 
END
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SP_INSERTAR_EXPEDIENTES]
@idSocio int ,
@docs xml
AS
BEGIN
			--
		    INSERT INTO EXPEDIENTES (nombreDocumento,
									 pathExpediente,
									 idSocio,
									 fechaAlta,
									 extencionArchivo,
									 pesoByte)
			SELECT  
						Cuentas.value('nombreDoc[1]', 'varchar(500)'),
						Cuentas.value('pathExpediente[1]', 'varchar(500)'),
						@idSocio,
						getdate(),
						Cuentas.value('extencionArchivo[1]', 'varchar(500)'),
						Cuentas.value('pesoByte[1]', 'int')
		    FROM 
				@docs.nodes('//ArrayOfExpediente/Expediente') AS XD(Cuentas)


	if @@error = 0
		SELECT 200  as estatus , 'ok' mensaje
	else
		SELECT -1  as estatus ,ERROR_MESSAGE() mensaje
END

GO
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_ACUERDOS]    Script Date: 14/02/2020 03:37:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_OBTENER_ACUERDOS]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_OBTENER_ACUERDOS] AS' 
END
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SP_OBTENER_ACUERDOS]
@idAsamblea int

AS
BEGIN
      SELECT 200  as estatus , 'ok' mensaje

	--SELECT isnull(MAX(isnull(noAcuerdo,0)),0)+1 noAcuerdo from Acuerdos where idAsamblea = @idAsamblea

     select A.* from Acuerdos A
	 where A.idAsamblea = @idAsamblea and activo = 1 order by noAcuerdo asc
	
END

GO
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_ACUERDOS_POR_SOCIO]    Script Date: 14/02/2020 03:37:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_OBTENER_ACUERDOS_POR_SOCIO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_OBTENER_ACUERDOS_POR_SOCIO] AS' 
END
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER  PROCEDURE [dbo].[SP_OBTENER_ACUERDOS_POR_SOCIO]
@idAsamblea int,
@idSocio int  
AS
BEGIN
     SELECT 200  as estatus , 'ok' mensaje
     SELECT  A.*, V.aFavor   ,V.encontra , isnull(v.IdSocio,0) fueVotado from Acuerdos A LEFT JOIN Votos V on A.idAcuerdo = V.idAcuerdo and V.IdSocio = coalesce(@idSocio,V.IdSocio)
	 where A.idAsamblea = @idAsamblea and activo = 1 order by noAcuerdo asc
	
END

GO
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_ASAMBLEAS]    Script Date: 14/02/2020 03:37:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_OBTENER_ASAMBLEAS]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_OBTENER_ASAMBLEAS] AS' 
END
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SP_OBTENER_ASAMBLEAS]
@idAsamblea int = null,
@idEstatusAsamblea int = null,
@fechaMinAsamblea datetime = null,
@FechaMaxAsamblea datetime = null
AS
BEGIN
	SELECT 200  as estatus , 'ok' mensaje
	SELECT A.* , ISNULL(B.acuerdos,0)acuerdos from Asamblea A LEFT JOIN
	(select idAsamblea,  count(idAsamblea) as acuerdos from Acuerdos where activo = 1   group by idAsamblea) B
	on a.idAsamblea = b.idAsamblea and a.activo = 1
	where 
	A.idAsamblea = coalesce(@idAsamblea,A.idAsamblea) AND
	A.idEstatusAsamblea = coalesce(@idEstatusAsamblea,A.idEstatusAsamblea) AND
	  (convert(varchar,A.fechaAsamblea,112) >=  convert(varchar,Coalesce(@fechaMinAsamblea,A. fechaAsamblea) , 112) AND
	  convert(varchar,A.fechaAsamblea,112) <=  convert(varchar,Coalesce(@FechaMaxAsamblea,A. fechaAsamblea) , 112)) AND
	activo = 1
	order by fechaAlta asc
END

GO
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_EXPEDIENTES]    Script Date: 14/02/2020 03:37:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_OBTENER_EXPEDIENTES]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_OBTENER_EXPEDIENTES] AS' 
END
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SP_OBTENER_EXPEDIENTES] 
@idSocio int =null
AS
BEGIN
	select * from Expedientes where idSocio = coalesce(@idSocio,idSocio)

END

GO
/****** Object:  StoredProcedure [dbo].[SP_OBTENER_SOCIOS]    Script Date: 14/02/2020 03:37:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_OBTENER_SOCIOS]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_OBTENER_SOCIOS] AS' 
END
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SP_OBTENER_SOCIOS] 
	@idSocio int = null
AS
BEGIN	 

	SELECT 200  as estatus , 'ok' mensaje
	SELECT * from Socios where idSocio = coalesce(@idSocio, idSocio) and activo = 1
	 order by fechaAlta asc
END

GO
/****** Object:  StoredProcedure [dbo].[SP_REGISTRAR_SOCIO_APP]    Script Date: 14/02/2020 03:37:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_REGISTRAR_SOCIO_APP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_REGISTRAR_SOCIO_APP] AS' 
END
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SP_REGISTRAR_SOCIO_APP]
@contrasena varchar(250),
@idSocio int
AS
BEGIN

		if not exists  (select 1 from Socios where activo = 1 and idSocio = @idSocio)
		begin
				select -1 estatus , 'Datos de Acceso Incorrectos' as mensaje
				return
		end


		if exists  (select 1 from Socios where contrasena <>'' or contrasena = null  and activo = 1 and idSocio = @idSocio)
		begin
				select -1 estatus , 'Gracias por registrarte, Ya puedes iniciar sesion' as mensaje
				return
		end

		UPDATE Socios SET  contrasena = @contrasena where idSocio = @idSocio
		select 200 estatus , 'Te has registrado exitosamente' as mensaje , * from Socios where idSocio = @idSocio
END

GO
/****** Object:  StoredProcedure [dbo].[SP_REGISTRAR_SOCIO_EN_ASAMBLEA]    Script Date: 14/02/2020 03:37:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_REGISTRAR_SOCIO_EN_ASAMBLEA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_REGISTRAR_SOCIO_EN_ASAMBLEA] AS' 
END
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SP_REGISTRAR_SOCIO_EN_ASAMBLEA]
@idSocio int,
@idAsamblea int 
AS
BEGIN
	if not exists (select 1 from SociosEnAsamblea where idSocio = @idSocio and idAsamblea = @idAsamblea )
	begin
		Insert into SociosEnAsamblea (fechaAlta,idSocio,idAsamblea) values (GETDATE(),@idSocio,@idAsamblea)
	end
	select 200 estatus , 'OK' mensaje 

END 

GO
/****** Object:  StoredProcedure [dbo].[SP_VALIDAR_SOCIO_APP]    Script Date: 14/02/2020 03:37:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_VALIDAR_SOCIO_APP]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_VALIDAR_SOCIO_APP] AS' 
END
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SP_VALIDAR_SOCIO_APP] 
@idSocio int,
@contrasena varchar(256)
AS
BEGIN
		if not exists (select 1 from Socios where @idSocio = @idSocio and contrasena  = @contrasena)
		begin
			select -1 as estatus , 'Datos incorrectos' as mensaje
			return 
		end

		select 200 estatus , 'OK' mensaje , * from Socios where idSocio = @idSocio

END

GO
/****** Object:  StoredProcedure [dbo].[SP_VALIDAR_USUARIO]    Script Date: 14/02/2020 03:37:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_VALIDAR_USUARIO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_VALIDAR_USUARIO] AS' 
END
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SP_VALIDAR_USUARIO]
@usuario varchar(250),
@contrasena varchar(250)
AS
BEGIN
		if not exists (select 1 from Usuarios where usuario = @usuario and contrasena = @contrasena)
		begin
			select -1 estatus , 'Datos incorrectos' mensaje
			return;
		end

		select 'Bienvenido' as mensaje , 200 as estatus, * from Usuarios where usuario = @usuario and contrasena = @contrasena
END

GO
/****** Object:  StoredProcedure [dbo].[SP_VOTAR_ACUERDO]    Script Date: 14/02/2020 03:37:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_VOTAR_ACUERDO]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[SP_VOTAR_ACUERDO] AS' 
END
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SP_VOTAR_ACUERDO]
@idAcuerdo int ,
@idAsamblea int ,
@aFavor bit,
@encontra bit,
@idSocio bigint
AS
BEGIN
	
	 delete  from Votos where idAcuerdo = @idAcuerdo  and idAsamblea = @idAsamblea and idSocio =  @idSocio
	 insert into votos (encontra,
						aFavor,
						anulado,
						fechaAlta,
						IdSocio,
						idAcuerdo,
						idAsamblea)
				 values(@encontra,
						@aFavor,
						0,
						getdate(),
						@idSocio,
						@idAcuerdo,
						@idAsamblea)

	Select 200 as estatus ,'Tu voto a sido registrado exitosamente' as mensaje
			
END

GO
