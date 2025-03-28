using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValidarPartNum.Modelo;
using ValidarPartNum.Controlador;
using ValidarPartNum.Runcard03;


namespace ValidarPartNum
{
    public partial class Form1: Form
    {

        validacion val;
        Ctrl ctrl = new Ctrl();
        bool statusMensaje = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Llenado del combobox de numero de parte
            List<string> lista = new List<string>();

            if (ctrl.obtenerPartNum().Count != 0)
            {
                lista = ctrl.obtenerPartNum();

                foreach(var item in lista)
                {
                    cbxPartNum.Items.Add(item);
                    cbxPartNum.Sorted = true;

                }              
            }
            else
            {
                
                mostrarMensaje("No se pudo obtener los numero de parte", statusMensaje);
            }
        }


        public bool validarNumeroParte(string numeroParte)
        {
            string resultado = string.Empty;

           resultado =  ctrl.validarNumeroPart(numeroParte);

            if(resultado == "Good")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void cbxPartNum_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {           
                if(cbxPartNum.Text.Trim() != string.Empty)
                {


                    if (validarNumeroParte(cbxPartNum.Text.Trim())) {


                        limpiarMensaje();

                        if (obtenerWO(cbxPartNum.Text).Count != 0)
                        {

                            cbxPartNum.Enabled = false;
                            cbxWo.Enabled = true;

                        }
                        else
                        {
                            cbxPartNum.Enabled = true;
                            cbxWo.Enabled = false;

                        }
                    }

                    else
                    {
                        mostrarMensaje("El numero de parte no existe", statusMensaje);
                    }                  
                }
                else
                {
                    mostrarMensaje("Campo vacio favor de llenar los campos", statusMensaje);

                }

            }
        }

        private void cbxPartNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxPartNum.Text.Trim() != string.Empty)
            {

                string numeroParte = cbxPartNum.SelectedItem.ToString();

                limpiarMensaje();

                if (validarNumeroParte(numeroParte))
                {

                    if(obtenerWO(cbxPartNum.Text).Count != 0)
                    {

                                            
                        cbxPartNum.Enabled = false;
                        cbxWo.Enabled = true;
                    }
                    else
                    {

                        cbxPartNum.Enabled = true;
                        cbxWo.Enabled = false;

                    }
                    


                }
                else
                {
                    mostrarMensaje("El numero de parte no existe", statusMensaje);
                }
            }
            else
            {
                mostrarMensaje("No se indico ningun numero de parte", statusMensaje);

            }


        }

        public List<string> obtenerWO(string numParte)
        {
            List<string> lista = new List<string>();

            cbxWo.Items.Clear();

            if (ctrl.obtenerWO(numParte).Count != 0)
            {
                
                lista = ctrl.obtenerWO(cbxPartNum.Text);
                foreach (var item in lista)
                {
                    cbxWo.Items.Add(item);
                    cbxWo.Sorted = true;
                    
                }

            }
            else
            {
                
                mostrarMensaje("No hay ordenes disponibles", statusMensaje);
            }

            return lista;

        }

        private void txtItem_KeyDown(object sender, KeyEventArgs e)
        {

            if(e.KeyCode == Keys.Enter)
            {
                if(cbxPartNum.Text != string.Empty && cbxWo.Text != string.Empty && txtItem.Text.Trim() != string.Empty)
                {
                    List<string> lista = new List<string>();

                    val = new validacion(cbxPartNum.Text, cbxWo.Text, txtItem.Text.Trim());

                    if (ctrl.validarItem(val).Count != 0)
                    {
                        lista = ctrl.validarItem(val);

                        if (lista.Contains(val._item))
                        {
                            statusMensaje = true;
                            mostrarMensaje("Si se encuentra en BOM", statusMensaje);
                            txtItem.Text = string.Empty;
                        }
                        else
                        {
                            mostrarMensaje("No se encontro BOM", statusMensaje = false);
                            
                        }

                    }
                    else
                    {
                        mostrarMensaje("No se encontro BOM", statusMensaje);
                        txtItem.Text = string.Empty;
                    }
                }

                else
                {
                    mostrarMensaje("Favor de llenar todos los campos", statusMensaje);
                }
            }
            
        }

        public void limpiarMensaje()
        {

            // Validar si no hay una ventana antes

            foreach (Control control in panel1.Controls)
            {
                if (control is Form)
                {
                    // Si hay ventana la eliminamos
                    control.Dispose();
                }
            }

        }


        public void mostrarMensaje(string mensaje, bool status)
        {
            // Validar si no hay una ventana antes

            foreach (Control control in panel1.Controls)
            {
                if (control is Form)
                {
                    // Si hay ventana la eliminamos
                    control.Dispose();
                }
            }

            Mensaje fmensaje = new Mensaje(mensaje);

            if (status)
            {
                fmensaje.BackColor = System.Drawing.Color.FromArgb(0, 127, 22); // Color verde para éxito
            }
            else
            {
                fmensaje.BackColor = System.Drawing.Color.FromArgb(146, 0, 4); // Color rojo para error

            }

            fmensaje.TopLevel = false;
            fmensaje.Parent = panel1;
            fmensaje.Size = panel1.ClientSize;
            fmensaje.Show();

        }

        private void cbxWo_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarMensaje();
            cbxWo.Enabled = false;
            txtItem.Enabled = true;

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

            cbxPartNum.Enabled = true;
            cbxPartNum.Text = string.Empty;
            

            cbxWo.Enabled = false;
            cbxWo.Text = string.Empty;
            cbxWo.Items.Clear();

            txtItem.Text = string.Empty;
            txtItem.Enabled = false;

            limpiarMensaje();


        }
    }
}
