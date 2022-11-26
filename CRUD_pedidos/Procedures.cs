using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CRUD_pedidos
{
    public class Procedures
    {
        public string insert_pedido_only(OracleConnection conn, int cliente, string fecha, string direccion)
        {

            //oracleParameter(1) = cmd.Parameters.Add("Date_Start_P", dbType:= OracleDbType.Date, val:= CDate(Me.dt_Start_Date.Text.Trim), ParameterDirection.Input)
            OracleParameter p_idcliente = new OracleParameter();
            p_idcliente.OracleDbType = OracleDbType.Int16;
            p_idcliente.Value = cliente;


            DateTime fec = DateTime.Parse(fecha);
            OracleParameter p_fecha = new OracleParameter();
            p_fecha.OracleDbType = OracleDbType.Date;
            p_fecha.Value = fec;

            OracleParameter p_direccion = new OracleParameter();
            p_direccion.OracleDbType = OracleDbType.Varchar2;
            p_direccion.Value = direccion;

            OracleCommand cmd = new OracleCommand("insert_pedido_only", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(p_idcliente);
            cmd.Parameters.Add(p_fecha);
            cmd.Parameters.Add(p_direccion);

            try
            {
                cmd.ExecuteNonQuery();
                conn.Dispose();

                return "Pedido insertado";
            }
            catch
            {
                return "Error al insertar el nuevo pedido";
            }
        }

        public string read_pedido(OracleConnection conn, int pedido)
        {
            OracleParameter p_idpedido = new OracleParameter();
            p_idpedido.OracleDbType = OracleDbType.Int16;
            p_idpedido.Value = pedido;

            OracleCommand cmd = new OracleCommand("read_pedido", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(p_idpedido);
            cmd.Parameters.Add("registros", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            try
            {
                DataSet ds = new DataSet();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);

                conn.Dispose();

                return JsonConvert.SerializeObject(ds, Formatting.Indented);
            }
            catch (Exception ex)
            {
                return "ERROR al obtener el producto" + ex.Message;
            }

        }

        public string update_pedido_only(OracleConnection conn, int pedido, int cliente, string fecha, string direccion)
        {
            OracleParameter p_idpedido = new OracleParameter();
            p_idpedido.OracleDbType = OracleDbType.Int16;
            p_idpedido.Value = pedido;

            OracleParameter p_idcliente = new OracleParameter();
            p_idcliente.OracleDbType = OracleDbType.Int16;
            p_idcliente.Value = cliente;

            DateTime fec = DateTime.Parse(fecha);
            OracleParameter p_fecha = new OracleParameter();
            p_fecha.OracleDbType = OracleDbType.Date;
            p_fecha.Value = fec;

            OracleParameter p_direccion = new OracleParameter();
            p_direccion.OracleDbType = OracleDbType.Varchar2;
            p_direccion.Value = direccion;

            OracleCommand cmd = new OracleCommand("update_pedido_only", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(p_idpedido);
            cmd.Parameters.Add(p_idcliente);
            cmd.Parameters.Add(p_fecha);
            cmd.Parameters.Add(p_direccion);

            try
            {
                cmd.ExecuteNonQuery();
                conn.Dispose();

                return "Pedido actualizado";
            }
            catch
            {
                return "Error al actualizar el pedido";
            }
        }

        public string delete_pedido(OracleConnection conn, int pedido)
        {
            OracleParameter p_idpedido = new OracleParameter();
            p_idpedido.OracleDbType = OracleDbType.Int16;
            p_idpedido.Value = pedido;

            OracleCommand cmd = new OracleCommand("delete_pedido", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(p_idpedido);

            try
            {
                cmd.ExecuteNonQuery();
                conn.Dispose();

                return "Pedido eliminado";
            }
            catch
            {
                return "Error al eliminar el pedido";
            }
        }

        public string delete_item_pedido(OracleConnection conn, int pedido, int producto)
        {
            OracleParameter p_idpedido = new OracleParameter();
            p_idpedido.OracleDbType = OracleDbType.Int16;
            p_idpedido.Value = pedido;

            OracleParameter p_idproducto = new OracleParameter();
            p_idproducto.OracleDbType = OracleDbType.Int16;
            p_idproducto.Value = producto;

            OracleCommand cmd = new OracleCommand("delete_item_pedido", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(p_idpedido);
            cmd.Parameters.Add(p_idproducto);

            try
            {
                cmd.ExecuteNonQuery();
                conn.Dispose();

                return "Item del pedido eliminado";
            }
            catch
            {
                return "Error al eliminar el item del pedido";
            }
        }

        public string insert_det_pedido_only(OracleConnection conn, int pedido, int producto, int cant)
        {
            OracleParameter p_idpedido = new OracleParameter();
            p_idpedido.OracleDbType = OracleDbType.Int16;
            p_idpedido.Value = pedido;

            OracleParameter p_idproducto = new OracleParameter();
            p_idproducto.OracleDbType = OracleDbType.Int16;
            p_idproducto.Value = producto;

            OracleParameter p_cant = new OracleParameter();
            p_cant.OracleDbType = OracleDbType.Int16;
            p_cant.Value = cant;

            OracleCommand cmd = new OracleCommand("insert_det_pedido_only", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(p_idpedido);
            cmd.Parameters.Add(p_idproducto);
            cmd.Parameters.Add(p_cant);

            try
            {
                cmd.ExecuteNonQuery();
                conn.Dispose();

                return "Detalle pedido insertado";
            }
            catch
            {
                return "Error al insertar el nuevo detalle pedido";
            }
        }

        public string update_det_pedido_only(OracleConnection conn, int pedido, int producto, int new_producto, int new_cantidad )
        {
            OracleParameter p_idpedido = new OracleParameter();
            p_idpedido.OracleDbType = OracleDbType.Int16;
            p_idpedido.Value = pedido;

            OracleParameter p_idproducto = new OracleParameter();
            p_idproducto.OracleDbType = OracleDbType.Int16;
            p_idproducto.Value = producto;

            OracleParameter p_newproducto = new OracleParameter();
            p_newproducto.OracleDbType = OracleDbType.Int16;
            p_newproducto.Value = new_producto;

            OracleParameter p_newcant = new OracleParameter();
            p_newcant.OracleDbType = OracleDbType.Int16;
            p_newcant.Value = new_cantidad;

            OracleCommand cmd = new OracleCommand("update_det_pedido_only", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(p_idpedido);
            cmd.Parameters.Add(p_idproducto);
            cmd.Parameters.Add(p_newproducto);
            cmd.Parameters.Add(p_newcant);

            try
            {
                cmd.ExecuteNonQuery();
                conn.Dispose();

                return "Detalle pedido actualizado";
            }
            catch
            {
                return "Error al actualizar el nuevo detalle pedido";
            }
        }
    }
}