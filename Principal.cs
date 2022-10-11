using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TraductorDiApi;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace SAP_API
{
    public partial class Principal : Form
    {
        PagoBO oPagoBO;
        List<FacturaBO> oFacturaBO;
        CompaniaBO oCompaniaBO;
        DocumentoDAO oDocumentoDAO;
        ListViewItem LVI = new ListViewItem();
        int max = 0;
        public Principal()
        {
            InitializeComponent();
            try
            {
                LlenarConexion(); // Abre la conexion
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Descripción de Error" + ex);
            }
        } 
       private void LlenarConexion()
        {
            oCompaniaBO = new CompaniaBO();
            oCompaniaBO.Server = "PHCRSRVMCARSAP1";
            oCompaniaBO.DbUserName = "R1";
            oCompaniaBO.DbPassword = "1234";
            oCompaniaBO.CompanyDB = "SBO_PIZZAHUT";
            //oCompaniaBO.UserName = "manager";
            //oCompaniaBO.Password = "BigHut76";
            oCompaniaBO.UserName = "PH-SAP";
            oCompaniaBO.Password = "Hut4dm1n@";
        }
        private void Principal_Load(object sender, EventArgs e)
        {
            LstEncabe();
            Cargalista();
        }
        private void PrepararPago()
        {
            try
            {

               

                String Hil_Sql = string.Empty;
                int fila = 0;
                int oDocEntry = 0;
                String VarCarCardCode = string.Empty;
                string VarCuentaServicio= string.Empty;
                string VarCuentaIVA = string.Empty;
                string VarCuentaPago = string.Empty;
                string VarCuentaDife = string.Empty;
                string VarProyecto = string.Empty;
                string VarMensaje = string.Empty;

                progressBar1.Visible = true;
                progressBar1.Minimum = 1;
                progressBar1.Value = 1;
                progressBar1.Step = 1;

                oPagoBO = new PagoBO();
                oDocumentoDAO = new DocumentoDAO(oCompaniaBO);
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SAP_API.Properties.Settings.Conexion"].ConnectionString);
                conn.Open();
                             
                VarCuentaIVA = "_SYS00000000264"; // Cuanta de Impuestos
                               
                for (var f = 0; f <= LstLinea.Items.Count -1; f++)
                {
                  
                    if (LstLinea.Items[f].Checked == true)
                    {
                        VarProyecto = LstLinea.Items[f].SubItems[13].Text;

                        VarCarCardCode = string.Empty;
                        VarCuentaServicio = string.Empty;
                        VarCuentaPago = string.Empty;    
                        VarCuentaDife = string.Empty;

                        switch (LstLinea.Items[f].SubItems[11].Text) //Agregador
                        {
                            case "Rappi":
                                VarCarCardCode = "COR001";
                                VarCuentaServicio = "_SYS00000000663"; // Cuenta de Servicio
                                VarCuentaPago =     "_SYS00000001155";  //Cuenta de Banco
                                VarCuentaDife =     "_SYS00000000818";
                                break;
                            case "Uber":
                                VarCarCardCode = "COR002";
                                VarCuentaServicio = "_SYS00000000599"; // Cuenta de Servicio
                                VarCuentaPago =     "_SYS00000001153";    //Cuenta de Banco
                                VarCuentaDife =     "_SYS00000000816";
                                break;
                            case "Pedidos YA":
                                VarCarCardCode = "COR003";
                                VarCuentaServicio = "_SYS00000000600"; // Cuenta de Servicio
                                VarCuentaPago =     "_SYS00000001156";    //Cuenta de Banco
                                VarCuentaDife =     "_SYS00000000817";
                                break;
                            case "Didi":
                                VarCarCardCode = "COR004";
                                VarCuentaServicio = "_SYS00000000602"; // Cuenta de Servicio
                                VarCuentaPago =     "_SYS00000001154";     //Cuenta de Banco
                                VarCuentaDife =     "_SYS00000000815";
                                break;
                        }
                        //***************************
                        //    oDocEntry             *
                        //***************************
                        oPagoBO.Fechadoc = DateTime.Parse( LstLinea.Items[f].SubItems[2].Text);
                        oDocEntry = Int32.Parse(LstLinea.Items[f].SubItems[9].Text);

                        //*********************************************
                        //   Precio Servicio Uber  PrecioServicioUber *
                        //*********************************************
                        oPagoBO.CardCode = VarCarCardCode;
                        ////oPagoBO.MontoAPagar = Convert.ToDouble(rdr["PrecioServicioUber"]) * -1;
                        oPagoBO.MontoAPagar = Convert.ToDouble(LstLinea.Items[f].SubItems[6].Text);
                        oPagoBO.Cuenta = VarCuentaServicio;
                        oPagoBO.Proyecto = VarProyecto;
                        oFacturaBO = new List<FacturaBO>();
                        oFacturaBO.Add(new FacturaBO { DocEntry = oDocEntry, MontoAPagar = oPagoBO.MontoAPagar  });
                        oPagoBO.oFacturaBO = oFacturaBO;
                        oDocumentoDAO.AgregarPagoRecibido(oPagoBO);

                        //**********************************************
                        //    IVA Precio Servicio  IVAPrecioServicio"  *
                        //**********************************************
                        oPagoBO.CardCode = VarCarCardCode;
                        //oPagoBO.MontoAPagar = Convert.ToDouble(rdr["IVAPrecioServicio"]) * -1;
                        oPagoBO.MontoAPagar = Convert.ToDouble(LstLinea.Items[f].SubItems[7].Text);
                        oPagoBO.Cuenta = VarCuentaIVA;
                        oPagoBO.Proyecto = VarProyecto;
                        oFacturaBO = new List<FacturaBO>();
                        oFacturaBO.Add(new FacturaBO { DocEntry = oDocEntry, MontoAPagar = oPagoBO.MontoAPagar });
                        oPagoBO.oFacturaBO = oFacturaBO;
                        oDocumentoDAO.AgregarPagoRecibido(oPagoBO);

                        //***************************
                        //       Pago               * 
                        //***************************
                        oPagoBO.CardCode = VarCarCardCode;
                        //oPagoBO.MontoAPagar = Convert.ToDouble(rdr["Pago"]);
                        oPagoBO.MontoAPagar = Convert.ToDouble(LstLinea.Items[f].SubItems[8].Text);
                        oPagoBO.Cuenta = VarCuentaPago;
                        oPagoBO.Proyecto = VarProyecto;
                        oFacturaBO = new List<FacturaBO>();
                        //oFacturaBO.Add(new FacturaBO { DocEntry = oDocEntry});
                        oFacturaBO.Add(new FacturaBO { DocEntry = oDocEntry, MontoAPagar = oPagoBO.MontoAPagar });
                        oPagoBO.oFacturaBO = oFacturaBO;
                        oDocumentoDAO.AgregarPagoRecibido(oPagoBO);

                        //***************************
                        //       Diferencia         * 
                        //***************************
                        if (Convert.ToDouble(LstLinea.Items[f].SubItems[12].Text) != 0)
                            { 
                                oPagoBO.CardCode = VarCarCardCode;
                                //oPagoBO.MontoAPagar = Convert.ToDouble(rdr["Pago"]);
                                oPagoBO.MontoAPagar = Convert.ToDouble(LstLinea.Items[f].SubItems[12].Text);
                                oPagoBO.Cuenta = VarCuentaDife;
                                oPagoBO.Proyecto = VarProyecto;
                                oFacturaBO = new List<FacturaBO>();
                                //oFacturaBO.Add(new FacturaBO { DocEntry = oDocEntry});
                                oFacturaBO.Add(new FacturaBO { DocEntry = oDocEntry, MontoAPagar = oPagoBO.MontoAPagar});
                                oPagoBO.oFacturaBO = oFacturaBO;
                                
                        }
                    }
                     oDocumentoDAO.AgregarPagoRecibido(oPagoBO);

                    //if (oPagoBO.ErrorDescripcion.Trim() != "")
                    //{
                    //    MessageBox.Show("Error en SAP: " + oPagoBO.ErrorDescripcion, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}

                        //**************************************************
                        //    Actualiza Campo AplicadoSAP  lo pone en true * 
                        //**************************************************
                        Hil_Sql = "UPDATE UX_TesoAgregadoresFuente SET AplicadoSAP = 1";
                        Hil_Sql += " Where DocEntry = " + oDocEntry;
                        SqlCommand cmdU = new SqlCommand(Hil_Sql, conn);
                        fila += cmdU.ExecuteNonQuery();


                    if (progressBar1.Value < progressBar1.Maximum)
                        {
                            progressBar1.Value += 1;
                            label1.Text = "Registros Procesados --> " + fila.ToString();
                            progressBar1.PerformStep();
                            Application.DoEvents();
                        }
                }
                        Cargalista(); //Cargar datos

                        MessageBox.Show("Se aplicaron " + fila + " Registos");
            }
            catch (Exception ex)

                    {
                                    MessageBox.Show("No se pudo registrar los datos por: " + ex);
                    }

        }
        private void LstEncabe()
        {
            try
            {
                //***********************************
                //Agrega las columnas en el ListView*
                //***********************************
                    ListViewItem LVI = new ListViewItem();        
                    LstLinea.Columns.Add("Ln", 55);              //0
                    LstLinea.Columns.Add("Sucursal", 280);       //1
                    LstLinea.Columns.Add("Fecha", 90);           //2
                    LstLinea.Columns.Add("Pedido", 70);          //3
                    LstLinea.Columns.Add("Modo Entrega", 250);   //4
                    LstLinea.Columns.Add("Canal", 60);           //5
                    LstLinea.Columns.Add("PrecioServicioUber", 160);
                    LstLinea.Columns.Add("IVAPrecioServicio", 160);
                    LstLinea.Columns.Add("Pago", 160);
                    LstLinea.Columns.Add("DocEntry", 70);
                    LstLinea.Columns.Add("DocNum", 90);
                    LstLinea.Columns.Add("Agregador", 80);
                    LstLinea.Columns.Add("Monto SAP", 80);
                    LstLinea.Columns.Add("Proyecto", 40);
                    LstLinea.Columns.Add("Error", 600);
            }
                catch (Exception ex)
               {
                MessageBox.Show("No se pudo registrar los datos por: " + ex);
                }
        }
        private void Cargalista()
        {
            try
            {
                        SqlConnection conna = new SqlConnection(ConfigurationManager.ConnectionStrings["SAP_API.Properties.Settings.Conexion"].ConnectionString);
                        conna.Open();
                        SqlDataReader rdr = null;
                        String Hil_Sql = string.Empty;
                        this.LstLinea.Items.Clear();
                        Hil_Sql = "SELECT CodRest + '-' + NomTienda Tienda, IDPedidoCorto,FechaOrden,Modoentrega,Canal, ";
                        Hil_Sql += "DocEntry, PrecioServicioUber,IVAPrecioServicio,Pago, MontoSAP, MontoCarga, AplicadoSAP,Docnum,TipoAgregador,MontoSap,CodRest FROM ";
                        Hil_Sql += " UX_TesoAgregadoresFuente Where (DocEntry IS NOT NULL) AND (Valida = 1) and (AplicadoSAP = 0) and (MontoSap <> 999999)";
                        SqlCommand cmda = new SqlCommand(Hil_Sql, conna);
                        rdr = cmda.ExecuteReader();

                        //***********************************
                        //Agrega los datos en el  ListView  *
                        //***********************************
                        while (rdr.Read())
                        {
                     
                            max += 1;
                            LVI = new ListViewItem();
                            LVI.Text = Convert.ToString(max);
                            LVI.SubItems.Add((string)(rdr["Tienda"] == null ? "" : rdr["Tienda"]));
                            LVI.SubItems.Add(Convert.ToDateTime(rdr["FechaOrden"]).ToString("dd/MM/yyyy"));
                            LVI.SubItems.Add((string)(rdr["IDPedidoCorto"] == null ? "" : rdr["IDPedidoCorto"]));
                            LVI.SubItems.Add((string)(rdr["Modoentrega"] == null ? "" : rdr["Modoentrega"]));
                            LVI.SubItems.Add((string)(rdr["Canal"] == null ? "00" : rdr["Canal"]));
                            LVI.SubItems.Add(Convert.ToString(Math.Abs((double)rdr["PrecioServicioUber"])));
                            LVI.SubItems.Add(Convert.ToString(Math.Abs((double)rdr["IVAPrecioServicio"])));
                            LVI.SubItems.Add(Convert.ToString(Math.Abs((double)rdr["Pago"])));
                            LVI.SubItems.Add(Convert.ToString(rdr["DocEntry"]));
                            LVI.SubItems.Add(Convert.ToString(rdr["DocNum"]));
                            LVI.SubItems.Add((string)(rdr["TipoAgregador"] == null ? "" : rdr["TipoAgregador"]));
                            LVI.SubItems.Add(Convert.ToString(rdr["MontoSap"]));
                            LVI.SubItems.Add((string)(rdr["CodRest"] == null  ? "" : rdr["CodRest"]));
                            

                            //LVI.SubItems.Add(rdr["NomEmpleado"]);
                            //if (Estado == true)
                            //    LVI.ForeColor = Color.DarkBlue;
                            //else
                            //    LVI.ForeColor = Color.Black;
                        this.LstLinea.Items.Add(LVI);
                        }
                     
                            this.LstLinea.Refresh();
                            rdr.Close();
                            conna.Close();
                            progressBar1.Maximum =max;
            }
                      catch (Exception ex)
                             {
                                 MessageBox.Show("No se pudo registrar los datos por: " + ex);
                       }
        }
        private void CerrarDocumento()
        {
            oDocumentoDAO = new DocumentoDAO(oCompaniaBO);
            oDocumentoDAO.CerrarPedidoCompra(514);
        }
        //#endregion
        private void btn_salir_Click_1(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            for (var f = 0; f <= LstLinea.Items.Count - 1; f++)
            {
                if (LstLinea.Items[f].Checked == true)
                {
                    btn_selecionar.Text = "Seleccionar Todos";
                    LstLinea.Items[f].Checked = false;
                }
                else
                {
                    LstLinea.Items[f].Checked = true;
                    btn_selecionar.Text = "Quitar Todos";
                }
            }
        }

       
        private void bnt_aplicar_Click(object sender, EventArgs e)
        {
            bool Bantera;
            Bantera = false;
                      for (var f = 0; f <= LstLinea.Items.Count - 1; f++)
            {
                if (LstLinea.Items[f].Checked == true)
                {
                    Bantera = true;
                    break; 
                }
                else
                {
                    Bantera = false;
                }
            }

            if (Bantera)
            {
                PrepararPago();
            }
            else
            {
                MessageBox.Show("No se a seleccionado ningùn Item", "Debe Selecionar alguno");
            }

        }

        private void btn_refrescar_Click(object sender, EventArgs e)
        {
            try
            {
                Cargalista();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo registrar los datos por: " + ex);
            }
        }
        //public static bool IsDBNull(this IDataReader dataReader, string columnName)
        //{
        //    return dataReader[columnName] == DBNull.Value;
        //}

        //public static object Iif(Boolean Exprecion, string  TruePart,string falsePart)
        //{

        //    return Exprecion ? TruePart : falsePart;
          
        //}
    }
}
