using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Color_Model_Converter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void limpar_Tela()
        {
            //zera a imagem, caso usem o botão dnv
            picBox_rgb1.Image = null;
            picBox_rgb2.Image = null;

            /*
            //zera o chart, caso usem o botão dnv
            chart_imagem_cortada.Series["Cortada"].Points.Clear();
            chart_imagem_alterada.Series["Cortada"].Points.Clear();
            */
        }

        private void limpar_RGB1_para_frente()
        {
            //zera a imagem, caso usem o botão dnv
            picBox_rgb2.Image = null;

            /*
            //zera o chart, caso usem o botão dnv
            chart_imagem_alterada.Series["Cortada"].Points.Clear();
            */
        }

        private double[,,] RGB1_para_YIQ(Bitmap rgb1)
        {
            int largura_rgb1 = rgb1.Width;
            int altura_rgb1 = rgb1.Height;

            double[,,] YIQ = new double[largura_rgb1, altura_rgb1, 3];

            for (int coluna_rgb1 = 0; coluna_rgb1 < largura_rgb1; coluna_rgb1++)
            {
                for (int linha_rgb1 = 0; linha_rgb1 < altura_rgb1; linha_rgb1++)
                {
                    Color pixel_argb1 = rgb1.GetPixel(coluna_rgb1, linha_rgb1);
                    int vermelho = Convert.ToInt32(pixel_argb1.R.ToString());
                    int verde = Convert.ToInt32(pixel_argb1.G.ToString());
                    int azul = Convert.ToInt32(pixel_argb1.B.ToString());

                    double luminância = (0.299 * vermelho) + (0.587 * verde) + (0.114 * azul);
                    double em_fase = (0.596 * vermelho) - (0.275 * verde) - (0.321 * azul);
                    double quadratura = (0.212 * vermelho) - (0.523 * verde) + (0.311 * azul);

                    YIQ[coluna_rgb1, linha_rgb1, 0] = luminância;
                    YIQ[coluna_rgb1, linha_rgb1, 1] = em_fase;
                    YIQ[coluna_rgb1, linha_rgb1, 2] = quadratura;
                }
            }
            return YIQ;
        }

        private Bitmap YIQ_para_RGB2(double[,,] YIQ)
        {
            int largura_yiq = YIQ.GetLength(0);
            int altura_yiq = YIQ.GetLength(1);

            Bitmap rgb2 = new Bitmap(largura_yiq, altura_yiq);

            for (int coluna_yiq = 0; coluna_yiq < largura_yiq; coluna_yiq++)
            {
                for (int linha_yiq = 0; linha_yiq < altura_yiq; linha_yiq++)
                {
                    double luminância = YIQ[coluna_yiq, linha_yiq, 0];
                    double em_fase = YIQ[coluna_yiq, linha_yiq, 1];
                    double quadratura = YIQ[coluna_yiq, linha_yiq, 2];

                    int vermelho = (int)((1 * luminância) + (0.956 * em_fase) + (0.620 * quadratura));
                    int verde = (int)((1 * luminância) - (0.272 * em_fase) - (0.647 * quadratura));
                    int azul = (int)((1 * luminância) - (1.108 * em_fase) + (1.705 * quadratura));

                    if (vermelho < 0) { vermelho = 0; }
                    if (vermelho > 255) { vermelho = 255; }
                    if (verde < 0) { verde = 0; }
                    if (verde > 255) { verde = 255; }
                    if (azul < 0) { azul = 0; }
                    if (azul > 255) { azul = 255; }

                    Color pixel_argb2 = Color.FromArgb(255, vermelho, verde, azul);
                    rgb2.SetPixel(coluna_yiq, linha_yiq, pixel_argb2);
                }
            }
            return rgb2;
        }

        private Bitmap subtrair_Bitmaps(Bitmap a, Bitmap b)
        {
            int largura_a_b = a.Width;
            int altura_a_b = a.Height;

            Bitmap subtracao = new Bitmap(largura_a_b, altura_a_b);

            for (int coluna_a_b = 0; coluna_a_b < largura_a_b; coluna_a_b++)
            {
                for (int linha_a_b = 0; linha_a_b < altura_a_b; linha_a_b++)
                {
                    Color pixel_argb_a = a.GetPixel(coluna_a_b, linha_a_b);
                    int vermelho_a = Convert.ToInt32(pixel_argb_a.R.ToString());
                    int verde_a = Convert.ToInt32(pixel_argb_a.G.ToString());
                    int azul_a = Convert.ToInt32(pixel_argb_a.B.ToString());

                    Color pixel_argb_b = b.GetPixel(coluna_a_b, linha_a_b);
                    int vermelho_b = Convert.ToInt32(pixel_argb_b.R.ToString());
                    int verde_b = Convert.ToInt32(pixel_argb_b.G.ToString());
                    int azul_b = Convert.ToInt32(pixel_argb_b.B.ToString());

                    int vermelho_sub = (vermelho_a) - (vermelho_b);
                    int verde_sub = (verde_a) - (verde_b);
                    int azul_sub = (azul_a) - (azul_b);

                    Color pixel_sub = Color.FromArgb(255, vermelho_sub, verde_sub, azul_sub);
                    subtracao.SetPixel(coluna_a_b, linha_a_b, pixel_sub);
                }
            }
            return subtracao;
        }

        private double[,,] Clarear_YIQ(double[,,] YIQ)
        {
            int largura_yiq = YIQ.GetLength(0);
            int altura_yiq = YIQ.GetLength(1);

            int constante = Convert.ToInt32(numUD_constante.Value.ToString());

            double[,,] YIQ_claro = new double[largura_yiq, altura_yiq, 3];

            for (int coluna_yiq = 0; coluna_yiq < largura_yiq; coluna_yiq++)
            {
                for (int linha_yiq = 0; linha_yiq < altura_yiq; linha_yiq++)
                {
                    double luminância = YIQ[coluna_yiq, linha_yiq, 0];
                    double em_fase = YIQ[coluna_yiq, linha_yiq, 1];
                    double quadratura = YIQ[coluna_yiq, linha_yiq, 2];

                    YIQ_claro[coluna_yiq, linha_yiq, 0] = luminância + constante;
                    YIQ_claro[coluna_yiq, linha_yiq, 1] = em_fase;
                    YIQ_claro[coluna_yiq, linha_yiq, 2] = quadratura;
                }
            }
            return YIQ_claro;
        }

        private void btn_buscar_imagem_Click(object sender, EventArgs e)
        {
            //abre o open file dialog
            OpenFileDialog dialog_carregar_imagem = new OpenFileDialog();
            dialog_carregar_imagem.Filter = "Image |*.png;*.jpg;*.jpeg";
            if (dialog_carregar_imagem.ShowDialog() == DialogResult.OK)
            {
                limpar_Tela();
                picBox_rgb1.Image = new Bitmap(dialog_carregar_imagem.FileName);
            }
        }

        private void btn_rgb1_para_yiq_para_rgb2_Click(object sender, EventArgs e)
        {
            limpar_RGB1_para_frente();
            Bitmap bitmap_rgb1 = (Bitmap)picBox_rgb1.Image;
            double[,,] YIQ = RGB1_para_YIQ(bitmap_rgb1);
            Bitmap bitmap_rgb2 = YIQ_para_RGB2(YIQ);
            picBox_rgb2.Image = subtrair_Bitmaps(bitmap_rgb1, bitmap_rgb2);
        }

        private void btn_rgb1_para_yiq_com_brilho_para_rgb2_Click(object sender, EventArgs e)
        {
            limpar_RGB1_para_frente();
            Bitmap bitmap_rgb1 = (Bitmap)picBox_rgb1.Image;
            double[,,] YIQ = RGB1_para_YIQ(bitmap_rgb1);
            double[,,] YIQ_claro = Clarear_YIQ(YIQ);
            picBox_rgb2.Image = YIQ_para_RGB2(YIQ_claro);
        }
    }
}