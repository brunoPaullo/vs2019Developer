using App.Data.repository;
using App.Data.Repository.Interface;
using App.Entities.Base;
using App.UI.WebForm.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App.UI.WebForm.Pages.Venta
{
    public partial class VentaRegistro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadInit();
            }
        }

        private void LoadInit()
        {
            IAppUnitofWork uw = new AppUnitOfWork();
            var tracks = uw.TrackRepository.GetAll();
            Helpers.ConfigureDropDown(ddlTrack, "Name", "TrackId", tracks);
            uw.Dispose();

            SetDataGrid(ManageSession.SaleDetails);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                var detail = new SaleDetail()
                {
                    TrackId = Convert.ToInt32(ddlTrack.SelectedValue),
                    TrackName = ddlTrack.SelectedItem.Text,
                    UnitPrice = Convert.ToDecimal(txtPrecio.Text),
                    Quantity = Convert.ToInt32(txtCantidad.Text),
                };
                detail.Total = detail.UnitPrice * detail.Quantity;

                var sales = ManageSession.SaleDetails;

                //Usando Linq, verificando duplicidad de producto;
                var trackFound = sales.Where(item => item.TrackId == detail.TrackId).FirstOrDefault();

                if (trackFound != null)
                {
                    litMensajeTrack.Text = "El track ya fué agragado.";
                    return;
                }
                sales.Add(detail);
                //Atualizando el nuevo elemento de la lista en el objeto session
                //session llamada sale
                ManageSession.SaleDetails = sales;

                //Mostrando la informacion en el grid
                SetDataGrid(sales);
            }

        }

        private void SetDataGrid(List<SaleDetail> sales)
        {
            grvPedido.DataSource = sales;
            grvPedido.DataBind();
        }

        protected void ddlTrack_SelectedIndexChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(2000);
            SeleccionarTrack();
        }

        private void SeleccionarTrack()
        {
            var id = Convert.ToInt32(ddlTrack.SelectedValue);
            IAppUnitofWork uw = new AppUnitOfWork();
            var trackSelected = uw.TrackRepository.GetById<int>(id);
            txtPrecio.Text = trackSelected.UnitPrice.ToString();
            uw.Dispose();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void Guardar()
        {
            var invoice = new Invoice()
            {
                CustomerId = 60,
                InvoiceDate = DateTime.Now,
                InvoiceLine = new List<InvoiceLine>()
            };

            decimal invoiceTotal = 0;
            foreach (var item in ManageSession.SaleDetails)
            {
                invoice.InvoiceLine.Add(new InvoiceLine
                {
                    TrackId = item.TrackId,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                });
                //Sumando los totales
                invoiceTotal += item.Total;
            }
            invoice.Total = invoiceTotal;

            //Grabando en BD
            IAppUnitofWork uw = new AppUnitOfWork();
            uw.InvoiceRepository.Add(invoice);
            uw.Complete();
            uw.Dispose();

            if (invoice.InvoiceId > 0)
            {
                ManageSession.SaleDetails = null;
                litMensajeConfirmacion.Text = "La Venta se registró correctamente";
                SetDataGrid(ManageSession.SaleDetails);
            }
        }
    }
}