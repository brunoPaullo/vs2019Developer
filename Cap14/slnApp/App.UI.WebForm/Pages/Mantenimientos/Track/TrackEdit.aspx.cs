using App.Data.repository;
using App.Data.Repository.Interface;
using ETrack = App.Entities.Base;
using App.UI.WebForm.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;

namespace App.UI.WebForm.Pages.Mantenimientos.Track
{
    public partial class TrackEdit : System.Web.UI.Page
    {
        //private readonly ILog _log = LogManager.GetLogger(typeof(TrackEdit));
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InitValues();
                GetTrack(); 
            }
        }

        private void GetTrack()
        {
            var codigo = Request.QueryString["cod"];
            if (codigo != null)
            {
                var trackId = Convert.ToInt32(codigo);
                using (IAppUnitofWork uw = new AppUnitOfWork())
                {
                    var track = uw.TrackRepository.GetById(trackId);
                    if (track != null)
                    {
                        hdfCodigo.Value = track.TrackId.ToString();
                        txtNombre.Text = track.Name;
                        ddlAlbum.SelectedValue = track.AlbumId.ToString();
                        ddlMedio.SelectedValue = track.MediaTypeId.ToString();
                        ddlGenero.SelectedValue = track.GenreId.ToString();
                        txtCompositor.Text = track.Composer;
                        txtDuracion.Text = track.Milliseconds.ToString();
                        txtPeso.Text = track.Bytes.ToString();
                        txtPrecio.Text = track.UnitPrice.ToString();
                    }
                }
            }
        }

        private void InitValues()
        {
            IAppUnitofWork uw = new AppUnitOfWork();
            var albums = uw.AlbumRepository.GetAll();
            Helpers.ConfigureDropDown(ddlAlbum, "Title", "AlbumId", albums);

            var media = uw.MediaTypeRepository.GetAll();
            Helpers.ConfigureDropDown(ddlMedio, "Name", "MediaTypeId", media);

            var genero = uw.GenreRepository.GetAll();
            Helpers.ConfigureDropDown(ddlGenero, "Name", "GenreId", genero);

            uw.Dispose();
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            SaveTrack();
        }

        private void SaveTrack()
        {
            IAppUnitofWork uw = new AppUnitOfWork();
            var newTrack = new ETrack.Track();
            if (!string.IsNullOrWhiteSpace(hdfCodigo.Value))
            {
                newTrack.TrackId = Convert.ToInt32(hdfCodigo.Value);
            }

            newTrack.Name = txtNombre.Text;
            newTrack.AlbumId = Convert.ToInt32(ddlAlbum.SelectedValue);
            newTrack.MediaTypeId = Convert.ToInt32(ddlMedio.SelectedValue);
            newTrack.GenreId = Convert.ToInt32(ddlGenero.SelectedValue);
            newTrack.Composer = txtCompositor.Text;
            newTrack.Milliseconds = Convert.ToInt32(txtDuracion.Text);
            newTrack.Bytes = Convert.ToInt32(txtPeso.Text);
            newTrack.UnitPrice = Convert.ToInt32(txtPrecio.Text);


            if (newTrack.TrackId == 0)
            {
                uw.TrackRepository.Add(newTrack);
            }
            else
            {
                uw.TrackRepository.Update(newTrack);
            }

            uw.Complete();
            uw.Dispose();
        }

        //public void Page_Error(object sender, EventArgs e)
        //{
        //    Exception ex = Server.GetLastError();
        //    _log.Error(ex);
        //}
    }
}