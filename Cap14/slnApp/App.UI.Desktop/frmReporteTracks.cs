using App.Data.DataAccess;
using App.Data.repository;
using App.Data.Repository.Interface;
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.UI.Desktop
{
    public partial class frmReporteTracks: Form
    {
        public frmReporteTracks()
        {
            InitializeComponent();
            InicializarValores();

        }

        private void Buscar(object sender, EventArgs e)
        {
            Buscar();
        }

        #region Procedimientos propios
        private void Buscar()
        {
            IAppUnitofWork uw = new AppUnitOfWork();
            var tracks = uw.TrackRepository.ReporteTraks(txtNombre.Text.Trim());
            dgvListado.DataSource = tracks;
            dgvListado.Refresh();
            uw.Dispose();
        }

        private void InicializarValores()
        {
            IAppUnitofWork uw = new AppUnitOfWork();

            //Oteniendo informacion de generos
            var genreList = uw.GenreRepository.GetAll().ToList();
            genreList.Insert(0, new Genre()
            {
                GenreId = 0,
                Name = "Todos"
            });
            cboGenero.DataSource = genreList;
            cboGenero.Refresh();



            //Oteniendo informacion de mediaType
            var mediaTyeList = uw.MediaTypeRepository.GetAll().ToList();
            mediaTyeList.Insert(0, new MediaType()
            {
                MediaTypeId = 0,
                Name = "Todos"
            });
            cboMediaType.DataSource = mediaTyeList;
            cboMediaType.Refresh();

            //Libera los recursos
            uw.Dispose();

        }
        #endregion
    }
}
