/*==============================================================*/
/* DBMS name:      MySQL 5.0                                    */
/* Created on:     21/09/2021 20:06:23                          */
/*==============================================================*/


drop table if exists CATEGORIA;

drop table if exists CLIENTE;

drop table if exists ITEM;

drop table if exists MATERIAL;

drop table if exists PRODUCTO;

drop table if exists VENTA;

/*==============================================================*/
/* Table: CATEGORIA                                             */
/*==============================================================*/
create table CATEGORIA
(
   CATEGORIA            varchar(20) not null,
   DESCRIPCION          varchar(100),
   primary key (CATEGORIA)
);

/*==============================================================*/
/* Table: CLIENTE                                               */
/*==============================================================*/
create table CLIENTE
(
   IDENTIFICACION       varchar(15) not null,
   NOMBRE1              varchar(20) not null,
   NOMBRE2              varchar(20),
   APELLIDO1            varchar(20) not null,
   APELLIDO2            varchar(20),
   DIRECCION            varchar(40) not null,
   TELEFONO             varchar(15) not null,
   EMAIL                varchar(30) not null,
   primary key (IDENTIFICACION)
);

/*==============================================================*/
/* Table: ITEM                                                  */
/*==============================================================*/
create table ITEM
(
   NUMERO               int(10) not null auto_increment,
   CODIGO               varchar(10) not null,
   CANTIDAD             numeric(2,0) not null,
   SUBTOTAL             numeric(10,2) not null,
   DESCUENTO            numeric(5,2),
   primary key (NUMERO, CODIGO)
);

/*==============================================================*/
/* Table: MATERIAL                                              */
/*==============================================================*/
create table MATERIAL
(
   MATERIAL             varchar(15) not null,
   DESCRIPCION          varchar(100),
   primary key (MATERIAL)
);

/*==============================================================*/
/* Table: PRODUCTO                                              */
/*==============================================================*/
create table PRODUCTO
(
   CODIGO               varchar(10) not null,
   NOMBRE               varchar(30) not null,
   STOCK                numeric(4,0),
   PESO                 numeric(7,3),
   TALLA                varchar(3),
   CATEGORIA            varchar(20) not null,
   MATERIAL             varchar(15) not null,
   PRECIO_COMPRA        numeric(10,2) not null,
   PRECIO_VENTA         numeric(10,2) not null,
   ESTADO               varchar(20) not null,
   primary key (CODIGO)
);

/*==============================================================*/
/* Table: VENTA                                                 */
/*==============================================================*/
create table VENTA
(
   NUMERO               int(10) not null auto_increment,
   IDENTIFICACION       varchar(15) not null,
   FECHA                timestamp not null,
   VALOR_TOTAL          numeric(10,2) not null,
   MEDIO_PAGO           varchar(20) not null,
   GANANCIA             numeric(10,2) not null,
   ESTADO               varchar(15) not null,
   primary key (NUMERO)
);

alter table ITEM add constraint FK_PRODUCTO_ITEM foreign key (CODIGO)
      references PRODUCTO (CODIGO) on delete restrict on update restrict;

alter table ITEM add constraint FK_VENTA_ITEM foreign key (NUMERO)
      references VENTA (NUMERO) on delete restrict on update restrict;

alter table PRODUCTO add constraint FK_CATEGORIA_PRODUCTO foreign key (CATEGORIA)
      references CATEGORIA (CATEGORIA) on delete restrict on update restrict;

alter table PRODUCTO add constraint FK_MATERIAL_PRODUCTO foreign key (MATERIAL)
      references MATERIAL (MATERIAL) on delete restrict on update restrict;

alter table VENTA add constraint FK_CLIENTE_VENTA foreign key (IDENTIFICACION)
      references CLIENTE (IDENTIFICACION) on delete restrict on update restrict;

ALTER TABLE VENTAS ADD CHECK (MEDIO_PAGO IN ('EFECTIVO', 'TARJETA_CREDITO', 'TARJETA_DEBITO'));
ALTER TABLE PRODUCTO ADD CHECK (TALLA IN ('UNICA', '3', '4', '4.5', '5', '5.5', '6', '6.5', '7', '8', '9', '10', '11', '12', '13'));
ALTER TABLE PRODCUTO ADD CHECK (ESTADO IN ('ACTIVO','DESCONTINUADO'));
ALTER TABLE VENTA ADD CHECK (ESTADO IN ('PAGADO','ACTIVO', 'CANCELADO'));