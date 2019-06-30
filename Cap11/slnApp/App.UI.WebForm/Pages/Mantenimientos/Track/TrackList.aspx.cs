using App.Data.repository;
using App.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App.UI.WebForm.Pages.Mantenimientos.Track
{
    public partial class TrackList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            using (IAppUnitofWork uw = new AppUnitOfWork())
            {
                var data = uw.TrackRepository.ReporteTraks("%");
                //Asignando informacion al control datagrid
                GrvListado.DataSource = data;
                GrvListado.DataBind();
            }           
        }
    }
}