/*
create table cliente(
    id_cliente int not null,
    nombre varchar(60),
    direccion varchar(60),
    telefono varchar(20),
    email varchar(30),
    primary key(id_cliente)
);
create table producto(
    id_prod int not null,
    cod_prod varchar(20),
    nombre varchar(60),
    marca varchar(30),
    descripcion varchar(100),
    precio_compra real,
    precio_venta real,
    material varchar(20),
    primary key(id_prod)
);
*/

/*
create table pedido(
    id_pedido int not null,
    id_cliente int not null,
    fecha date,
    dir_entrega varchar(60),
    primary key(id_pedido),
    foreign key (id_cliente) references cliente(id_cliente)
);
*/

create sequence seq_id_pedido
    start with 1
    increment by 1
    nocache
    nocycle;

create or replace procedure insert_pedido_only( 
    idcliente IN pedido.id_cliente%type, 
    fec IN pedido.fecha%type, 
    dir IN pedido.dir_entrega%type )
AS
BEGIN
     INSERT INTO pedido values(
        seq_id_pedido.NEXTVAL,
        idcliente,
        fec,
        dir
    );
    
    COMMIT;
END;
/

create or replace procedure read_pedido(
    idpedido IN pedido.id_pedido%type, 
    registros OUT sys_refcursor)
AS
BEGIN
    open registros for
        select p.id_pedido, id_cliente, fecha, dir_entrega, id_producto, cantidad
        from pedido p
        inner join det_pedido dp
            on dp.id_pedido=p.id_pedido
        where p.id_pedido=idpedido;
END;
/

create or replace procedure update_pedido_only(
    idpedido IN pedido.id_pedido%type,
    idcliente IN pedido.id_cliente%type, 
    fec IN pedido.fecha%type, 
    dir IN pedido.dir_entrega%type ) --, registros out sys_refcursor)
AS
BEGIN
    update pedido p
    set
        p.id_cliente = idcliente,
        p.fecha = fec,
        p.dir_entrega = dir
    where p.id_pedido = idpedido;
    
    commit;
END;

create or replace procedure delete_pedido(idpedido IN pedido.id_pedido%type)
AS
BEGIN

    delete from det_pedido
    where id_pedido=idpedido;
    
    delete from pedido
    where id_pedido=idpedido;
    
    commit;
END;
/

call delete_pedido(4);

-- ### PEDIDO DETALLE ### --
/*
create table det_pedido(
    id_pedido int not null,
    id_producto int not null,
    cantidad int not null,
    primary key (id_pedido, id_producto),
    foreign key(id_pedido) references pedido(id_pedido),
    foreign key(id_producto) references producto(id_prod)
);
*/
create or replace procedure insert_det_pedido_only(
    idpedido IN det_pedido.id_pedido%type,
    idproducto IN det_pedido.id_producto%type, 
    cant IN det_pedido.cantidad%type
)
AS
BEGIN
     INSERT INTO det_pedido values(
        idpedido,
        idproducto,
        cant
    );
    
    COMMIT;
END;
/

create or replace procedure update_det_pedido_only(
    idpedido IN det_pedido.id_pedido%type,
    idproducto IN det_pedido.id_producto%type,
    newproducto IN det_pedido.id_producto%type,
    newcant IN det_pedido.cantidad%type
    )
AS
BEGIN
    update det_pedido p
    set
        p.id_producto = newproducto,
        p.cantidad = newcant
    where p.id_pedido = idpedido and p.id_producto = idproducto;
END;
/

create or replace procedure delete_item_pedido(
    idpedido IN det_pedido.id_pedido%type, 
    idproducto IN det_pedido.id_producto%type)
AS
BEGIN    
    delete from det_pedido
    where id_pedido = idpedido and id_producto = idproducto;
    
    commit;
END;
/