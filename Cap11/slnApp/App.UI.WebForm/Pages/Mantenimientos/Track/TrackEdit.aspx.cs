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
namespace App.UI.WebForm.Pages.Mantenimientos.Track
{
    public partial class TrackEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitValues();
        }

        private void InitValues()
        {
            IAppUnitofWork uw = new AppUnitOfWork();
            var albums = uw.AlbumRepository.GetAll();
            Helpers.ConfigureDropDown(DdlAlbum, "Title", "AlbumId", albums);
           
            var media = uw.MediaTypeRepository.GetAll();
            Helpers.ConfigureDropDown(DdlMedio, "Name", "MediaTypeId", media);

            var genero = uw.GenreRepository.GetAll();
            Helpers.ConfigureDropDown(DdlGenero, "Name", "GenreId", genero);
            
            uw.Dispose();
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            SaveTrack();
        }

        private void SaveTrack()
        {
            IAppUnitofWork uw = new AppUnitOfWork();
            var newTrack = new ETrack.Track()
            {
                Name = TxtNombre.Text,
                AlbumId = Convert.ToInt32(DdlAlbum.SelectedValue),
                MediaTypeId = Convert.ToInt32(DdlMedio.SelectedValue),
                GenreId = Convert.ToInt32(DdlGenero.SelectedValue),
                Composer = TxtCompositor.Text,
                Milliseconds = Convert.ToInt32(TxtDuracion.Text),
                Bytes= Convert.ToInt32(TxtPeso.Text),
                UnitPrice = Convert.ToInt32(TxtPrecio.Text),
            };
            uw.TrackRepository.Add(newTrack);
            uw.Complete();
            uw.Dispose();
        }
    }
}