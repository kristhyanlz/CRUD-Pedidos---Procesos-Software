using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace CRUD_pedidos
{
    /// <summary>
    /// Descripción breve de service_pedidos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class service_pedidos : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public string insert_pedido_only(int cliente, string fecha, string direccion)
        {
            Oracon conn = new Oracon();
            conn.Open();

            //CultureInfo provider = new CultureInfo("en-US");
            //DateTime fecha_date = DateTime.Parse(fecha, provider, DateTimeStyles.AdjustToUniversal);

            Procedures pc = new Procedures();
            return pc.insert_pedido_only(conn.Conn, cliente, fecha, direccion);
        }

        [WebMethod]
        public string read_pedido(int pedido)
        {
            Oracon conn = new Oracon();
            conn.Open();

            Procedures pc = new Procedures();
            return pc.read_pedido(conn.Conn, pedido);
        }

        [WebMethod]
        public string update_pedido_only(int pedido, int cliente, string fecha, string direccion)
        {
            Oracon conn = new Oracon();
            conn.Open();

            //CultureInfo provider = new CultureInfo("en-US");
            //DateTime fecha_date = DateTime.Parse(fecha, provider, DateTimeStyles.AdjustToUniversal);

            Procedures pc = new Procedures();
            return pc.update_pedido_only(conn.Conn, pedido, cliente, fecha, direccion);
        }

        [WebMethod]
        public string delete_pedido(int pedido)
        {
            Oracon conn = new Oracon();
            conn.Open();

            Procedures pc = new Procedures();
            return pc.delete_pedido(conn.Conn, pedido);
        }

        [WebMethod]
        public string delete_item_pedido(int pedido, int producto)
        {
            Oracon conn = new Oracon();
            conn.Open();

            Procedures pc = new Procedures();
            return pc.delete_item_pedido(conn.Conn, pedido, producto);
        }

        [WebMethod]
        public string insert_det_pedido_only(int pedido, int producto, int cantidad)
        {
            Oracon conn = new Oracon();
            conn.Open();

            Procedures pc = new Procedures();
            return pc.insert_det_pedido_only(conn.Conn, pedido, producto, cantidad);
        }

        [WebMethod]
        public string update_det_pedido_only(int pedido, int producto, int new_producto, int new_cantidad)
        {
            Oracon conn = new Oracon();
            conn.Open();

            Procedures pc = new Procedures();
            return pc.update_det_pedido_only(conn.Conn, pedido, producto, new_producto, new_cantidad);
        }
    }
}
