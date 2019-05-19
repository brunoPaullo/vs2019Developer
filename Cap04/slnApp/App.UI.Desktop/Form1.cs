using App.Data.DataAccess;
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
    public partial class frmConsultaTrack : Form
    {
        private readonly TrackDA trackDA = new TrackDA();
        private readonly GenreDA genreDA = new GenreDA();
        private readonly MediaTypeDA mediaTypeDA = new MediaTypeDA();

        public frmConsultaTrack()
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
            var tracks = trackDA.ConsultarTracksQ(
                txtNombre.Text.Trim(),
                (int)cboGenero.SelectedValue,
                (int)cboMediaType.SelectedValue);
            dgvListado.DataSource = tracks;
            dgvListado.Refresh();
        }

        private void InicializarValores()
        {
            //Oteniendo informacion de generos
            var genreList = genreDA.GetAll().ToList();
            genreList.Insert(0, new Genre()
            {
                GenreId = 0,
                Name = "Todos"
            });
            cboGenero.DataSource = genreList;
            cboGenero.Refresh();



            //Oteniendo informacion de mediaType
            var mediaTyeList = mediaTypeDA.GetAll().ToList();
            mediaTyeList.Insert(0, new MediaType()
            {
                MediaTypeId = 0,
                Name = "Todos"
            });
            cboMediaType.DataSource = mediaTyeList;
            cboMediaType.Refresh();
        }
        #endregion
    }
}
