using App.Data.repository;
using App.Data.Repository.Interface;
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
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

        }
    }
}