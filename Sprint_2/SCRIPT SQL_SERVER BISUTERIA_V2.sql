/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     09/10/2021 22:27:54                          */
/*==============================================================*/


if exists (select 1
            from  sysobjects
           where  id = object_id('CATEGORIA')
            and   type = 'U')
   drop table CATEGORIA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CLIENTE')
            and   type = 'U')
   drop table CLIENTE
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ITEM')
            and   name  = 'PRODUCTO_ITEM_FK'
            and   indid > 0
            and   indid < 255)
   drop index ITEM.PRODUCTO_ITEM_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ITEM')
            and   name  = 'VENTA_ITEM_FK'
            and   indid > 0
            and   indid < 255)
   drop index ITEM.VENTA_ITEM_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ITEM')
            and   type = 'U')
   drop table ITEM
go

if exists (select 1
            from  sysobjects
           where  id = object_id('MATERIAL')
            and   type = 'U')
   drop table MATERIAL
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PRODUCTO')
            and   name  = 'MATERIAL_PRODUCTO_FK'
            and   indid > 0
            and   indid < 255)
   drop index PRODUCTO.MATERIAL_PRODUCTO_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PRODUCTO')
            and   name  = 'CATEGORIA_PRODUCTO_FK'
            and   indid > 0
            and   indid < 255)
   drop index PRODUCTO.CATEGORIA_PRODUCTO_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PRODUCTO')
            and   type = 'U')
   drop table PRODUCTO
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('VENTA')
            and   name  = 'CLIENTE_VENTA_FK'
            and   indid > 0
            and   indid < 255)
   drop index VENTA.CLIENTE_VENTA_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VENTA')
            and   type = 'U')
   drop table VENTA
go

/*==============================================================*/
/* Table: CATEGORIA                                             */
/*==============================================================*/
create table CATEGORIA (
   CATEGORIA            varchar(20)          not null,
   DESCRIPCION          varchar(100)         null,
   constraint PK_CATEGORIA primary key nonclustered (CATEGORIA)
)
go

/*==============================================================*/
/* Table: CLIENTE                                               */
/*==============================================================*/
create table CLIENTE (
   IDENTIFICACION       varchar(15)          not null,
   NOMBRE1              varchar(20)          not null,
   NOMBRE2              varchar(20)          null,
   APELLIDO1            varchar(20)          not null,
   APELLIDO2            varchar(20)          null,
   DIRECCION            varchar(40)          not null,
   TELEFONO             varchar(15)          not null,
   EMAIL                varchar(30)          not null,
   constraint PK_CLIENTE primary key nonclustered (IDENTIFICACION)
)
go

/*==============================================================*/
/* Table: ITEM                                                  */
/*==============================================================*/
create table ITEM (
   NUMERO               numeric(10)          identity,
   CODIGO               varchar(10)          not null,
   CANTIDAD             numeric(2,0)         not null,
   SUBTOTAL             numeric(10,2)        not null,
   DESCUENTO            numeric(5,2)         null,
   constraint PK_ITEM primary key nonclustered (NUMERO, CODIGO)
)
go

/*==============================================================*/
/* Index: VENTA_ITEM_FK                                         */
/*==============================================================*/
create index VENTA_ITEM_FK on ITEM (
NUMERO ASC
)
go

/*==============================================================*/
/* Index: PRODUCTO_ITEM_FK                                      */
/*==============================================================*/
create index PRODUCTO_ITEM_FK on ITEM (
CODIGO ASC
)
go

/*==============================================================*/
/* Table: MATERIAL                                              */
/*==============================================================*/
create table MATERIAL (
   MATERIAL             varchar(15)          not null,
   DESCRIPCION          varchar(100)         null,
   constraint PK_MATERIAL primary key nonclustered (MATERIAL)
)
go

/*==============================================================*/
/* Table: PRODUCTO                                              */
/*==============================================================*/
create table PRODUCTO (
   CODIGO               varchar(10)          not null,
   NOMBRE               varchar(30)          not null,
   STOCK                numeric(4)           null,
   PESO                 numeric(7,3)         null,
   TALLA                varchar(3)           null,
   CATEGORIA            varchar(20)          not null,
   MATERIAL             varchar(15)          not null,
   PRECIO_COMPRA        numeric(10,2)        not null,
   PRECIO_VENTA         numeric(10,2)        not null,
   ESTADO               varchar(20)          not null,
   constraint PK_PRODUCTO primary key nonclustered (CODIGO)
)
go

/*==============================================================*/
/* Index: CATEGORIA_PRODUCTO_FK                                 */
/*==============================================================*/
create index CATEGORIA_PRODUCTO_FK on PRODUCTO (
CATEGORIA ASC
)
go

/*==============================================================*/
/* Index: MATERIAL_PRODUCTO_FK                                  */
/*==============================================================*/
create index MATERIAL_PRODUCTO_FK on PRODUCTO (
MATERIAL ASC
)
go

/*==============================================================*/
/* Table: VENTA                                                 */
/*==============================================================*/
create table VENTA (
   NUMERO               numeric(10)          identity,
   IDENTIFICACION       varchar(15)          not null,
   FECHA                timestamp            not null,
   VALOR_TOTAL          numeric(10,2)        not null,
   MEDIO_PAGO           varchar(20)          not null,
   GANANCIA             numeric(10,2)        not null,
   ESTADO               varchar(15)          not null,
   constraint PK_VENTA primary key nonclustered (NUMERO)
)
go

/*==============================================================*/
/* Index: CLIENTE_VENTA_FK                                      */
/*==============================================================*/
create index CLIENTE_VENTA_FK on VENTA (
IDENTIFICACION ASC
)
go

ALTER TABLE VENTA ADD CHECK (MEDIO_PAGO IN ('EFECTIVO', 'TARJETA_CREDITO', 'TARJETA_DEBITO'));
ALTER TABLE PRODUCTO ADD CHECK (TALLA IN ('UNICA', '3', '4', '4.5', '5', '5.5', '6', '6.5', '7', '8', '9', '10', '11', '12', '13'));
ALTER TABLE PRODUCTO ADD CHECK (ESTADO IN ('ACTIVO','DESCONTINUADO'));
ALTER TABLE VENTA ADD CHECK (ESTADO IN ('PAGADO','ACTIVO', 'CANCELADO'));