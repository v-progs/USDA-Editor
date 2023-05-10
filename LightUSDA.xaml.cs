using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace USDAE
{
    /// <summary>
    /// Логика взаимодействия для LightUSDA.xaml
    /// </summary>
    public partial class LightUSDA : Window
    {
        public LightUSDA()
        {
            InitializeComponent();
        }
        void USDALights()
        {
            string Rect = "def RectLight \"[name]\" (\r\n                    apiSchemas = [\"ShapingAPI\"]\r\n                )\r\n                {\r\n                    color3f color = ([R], [G], [B])\r\n                    float height = [height]\r\n                    float intensity = [intense]\r\n                    float shaping:cone:angle = [angle]\r\n                    [softness]\r\n                    float shaping:focus\r\n                    color3f shaping:focusTint\r\n                    asset shaping:ies:file\r\n                    float width = [width]\r\n                    double3 xformOp:rotateXYZ = ([XR], [YR], [ZR])\r\n                    double3 xformOp:scale = ([XS], [YS], [ZS])\r\n                    double3 xformOp:translate = ([X], [Y], [Z])\r\n                    uniform token[] xformOpOrder = [\"xformOp:translate\", \"xformOp:rotateXYZ\", \"xformOp:scale\"]\r\n                }\r\n";
            string Sphere = "def SphereLight \"[name]\" (\r\n                apiSchemas = [\"ShapingAPI\"]\r\n            )\r\n            {\r\n                color3f color = ([R], [G], [B])\r\n                float intensity = [intense]\r\n                float radius = [radius]\r\n                float shaping:cone:angle = [angle]\r\n                float shaping:cone:softness\r\n                float shaping:focus\r\n                color3f shaping:focusTint\r\n                asset shaping:ies:file\r\n                double3 xformOp:rotateXYZ = ([XR], [YR], [ZR])\r\n                double3 xformOp:scale = ([XS], [YS], [ZS])\r\n                double3 xformOp:translate = ([X], [Y], [Z])\r\n                uniform token[] xformOpOrder = [\"xformOp:translate\", \"xformOp:rotateXYZ\", \"xformOp:scale\"]\r\n            }";
            if (Sphrect.Text == "Rect")
                USDA_Light.Text = Rect.Replace("[height]", radeight.Text).Replace("[angle]", angle.Text).Replace("[width]", width.Text).Replace("[intense]", intense1.Text).Replace("[name]", Name.Text).Replace("[B]", B.Text).Replace("[G]", G.Text).Replace("[R]", R.Text).Replace("[X]", X.Text).Replace("[Y]", Y.Text).Replace("[Z]", Z.Text).Replace("[XR]", XR.Text).Replace("[YR]", YR.Text).Replace("[ZR]", ZR.Text).Replace("[XS]", XS.Text).Replace("[YS]", YS.Text).Replace("[ZS]", ZS.Text);
                
            else if (Sphrect.Text == "Sphere")
                USDA_Light.Text = Sphere.Replace("[intense]", intense1.Text).Replace("[radius]", radeight.Text).Replace("[name]", Name.Text).Replace("[intense]", intense1.Text).Replace("[B]", B.Text).Replace("[G]", G.Text).Replace("[R]", R.Text).Replace("[X]", X.Text).Replace("[Y]", Y.Text).Replace("[Z]", Z.Text).Replace("[XR]", XR.Text).Replace("[YR]", YR.Text).Replace("[ZR]", ZR.Text).Replace("[XS]", XS.Text).Replace("[YS]", YS.Text).Replace("[ZS]", ZS.Text);
        }

        private void X_TextChanged(object sender, TextChangedEventArgs e)
        {
            USDALights();
        }

        private void ZR_TextChanged(object sender, TextChangedEventArgs e)
        {
            USDALights();
        }

        private void YR_TextChanged(object sender, TextChangedEventArgs e)
        {
            USDALights();
        }

        private void XR_TextChanged(object sender, TextChangedEventArgs e)
        {
            USDALights();
        }

        private void Y_TextChanged(object sender, TextChangedEventArgs e)
        {
            USDALights();
        }

        private void Z_TextChanged(object sender, TextChangedEventArgs e)
        {
            USDALights();
        }

        private void XS_TextChanged(object sender, TextChangedEventArgs e)
        {
            USDALights();
        }

        private void YS_TextChanged(object sender, TextChangedEventArgs e)
        {
            USDALights();
        }

        private void ZS_TextChanged(object sender, TextChangedEventArgs e)
        {
            USDALights();
        }

        private void intense1_TextChanged(object sender, TextChangedEventArgs e)
        {
            USDALights();
        }

        private void radeight_TextChanged(object sender, TextChangedEventArgs e)
        {
            USDALights();
        }

        private void angle_TextChanged(object sender, TextChangedEventArgs e)
        {
            USDALights();
        }

        private void width_TextChanged(object sender, TextChangedEventArgs e)
        {
            USDALights();
        }

        private void light_type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            USDALights();
        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            USDALights();
        }

        private void G_TextChanged(object sender, TextChangedEventArgs e)
        {
            USDALights();
        }

        private void B_TextChanged(object sender, TextChangedEventArgs e)
        {
            USDALights();
        }

        private void light_type_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
