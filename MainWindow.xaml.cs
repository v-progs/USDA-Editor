using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace USDAE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            USDAGenerate();
        }
        void USDAGenerate()
        {
            bool flag = true;
            string Enc = "int inputs:encoding = [enc] (\r\n                    customData = {\r\n                        int default = 0\r\n                    }\r\n                    displayGroup = \"Normal\"\r\n                    displayName = \"Normal Map Encoding\"\r\n                    doc = \"Encoding type for the normal map.  Octahedral for 2 channel textures. tangent_space_dx for 3 channel normals, and tangent_space_ogl for 3 channel normals with an inverted (OpenGL style) G channel.\"\r\n                    hidden = false\r\n                    renderType = \"::Z18E_3A::lss_remaster::notnv::lightspeedrtx::trex::portal1::lss::capture::materials::AperturePBR_Normal::normalmap_encoding\"\r\n                    sdrMetadata = {\r\n                        string __SDR__enum_value = \"octahedral\"\r\n                        string options = \"octahedral:0|tangent_space_ogl:1|tangent_space_dx:2\"\r\n                    }\r\n                )";
            string newValue1 = "\r\n                asset inputs:diffuse_texture = @./name]_Color.dds@ (\r\n                        colorSpace = \"sRGB\"\r\n                        customData = {\r\n                            asset default = @@\r\n                        }\r\n                        displayGroup = \"Diffuse\"\r\n                        displayName = \"Albedo Map\"\r\n                        doc = \"The texture specifying the albedo value and the optional opacity value to use in the alpha channel\"\r\n                        hidden = false\r\n                )";
            string newValue2 = "\r\n                asset inputs:normalmap_texture = @./[name]_NormalDX.dds@ (\r\n                        colorSpace = \"sRGB\"\r\n                        customData = {\r\n                            asset default = @@\r\n                        }\r\n                        displayGroup = \"Normal\"\r\n                        displayName = \"Normal Map\"\r\n                        hidden = false\r\n                )";
            string newValue3 = "\r\n                asset inputs:reflectionroughness_texture = @./[name]_Roughness.dds@ (\r\n                        colorSpace = \"raw\"\r\n                        customData = {\r\n                            asset default = @@\r\n                        }\r\n                        displayGroup = \"Specular\"\r\n                        displayName = \"Roughness Map\"\r\n                        hidden = false\r\n                )";
            string newValue4 = "\r\n                asset inputs:metallic_texture = @./[name]_Metalness.dds@ (\r\n                        colorSpace = \"raw\"\r\n                        customData = {\r\n                            asset default = @@\r\n                        }\r\n                        displayGroup = \"Specular\"\r\n                        displayName = \"Metallic Map\"\r\n                        hidden = false\r\n                )";
            string newValue5 = "\r\n                float inputs:emissive_intensity = [intense] (\r\n                    customData = {\r\n                        float default = 40\r\n                        dictionary range = {\r\n                            float max = 65504\r\n                            float min = 0\r\n                        }\r\n                    }\r\n                    displayGroup = \"Emissive\"\r\n                    displayName = \"Emissive Intensity\"\r\n                    doc = \"Intensity of the emission\"\r\n                    hidden = false\r\n                )\r\n                asset inputs:emissive_mask_texture = @./SubUSDs/[name]_emis.dds@ (\r\n                    customData = {\r\n                        asset default = @@\r\n                    }\r\n                    displayGroup = \"Emissive\"\r\n                    displayName = \"Emissive Mask Map\"\r\n                    doc = \"The texture masking the emissive color\"\r\n                    hidden = false\r\n                )\r\n                bool inputs:enable_emission = 1 (\r\n                    customData = {\r\n                        bool default = 0\r\n                    }\r\n                    displayGroup = \"Emissive\"\r\n                    displayName = \"Enable Emission\"\r\n                    doc = \"Enables the emission of light from the material\"\r\n                    hidden = false\r\n                )";
            string str1 = "over \"mat_[matname]\" (\r\n\r\n        )\r\n        {\r\n            over \"Shader\"\r\n            {\r\n                uniform asset info:mdl:sourceAsset = @AperturePBR_Opacity.mdl@\r\n                [encode] [diff] [norm] [rough] [metal] [emis]\r\n            }\r\n        }";
            if (this.albedo.IsChecked.Value)
                str1 = str1.Replace("[diff]", newValue1);
            if (this.normal.IsChecked.Value)
                str1 = str1.Replace("[norm]", newValue2);
            if (this.roughness.IsChecked.Value)
                str1 = str1.Replace("[rough]", newValue3);
            if (this.metallic.IsChecked.Value)
                str1 = str1.Replace("[metal]", newValue4);
            if (this.emission.IsChecked.Value)
                str1 = str1.Replace("[emis]", newValue5.Replace("[intense]", intense.Text));
            if (!this.albedo.IsChecked.Value & !this.normal.IsChecked.Value & !this.roughness.IsChecked.Value & !this.metallic.IsChecked.Value & !this.emission.IsChecked.Value)
                flag = false;

            if (Encoding.IsChecked.Value)
                str1 = str1.Replace("[encode]", Enc.Replace("[enc]", "2"));
            else
                str1 = str1.Replace("[encode]", Enc.Replace("[enc]", "0"));

            string str2 = str1.Replace("[diff]", "").Replace("[norm]", "").Replace("[rough]", "").Replace("[metal]", "").Replace("[emis]", "");
            if (flag)


                str2 = str2.Replace("[name]", this.tex.Text);
            this.USDAText.Text = str2.Replace("[matname]", this.matid.Text);
        }

        void USDAModels()
        {

            string modelsform = "over \"mesh_[mesh]\" (\r\n            references = @./[mesh_path]@\r\n        )\r\n        {\r\n            token visibility = \"invisible\"\r\n        }";
            USDAModelText.Text = modelsform.Replace("[mesh]", meshid.Text).Replace("[mesh_path]", mesh_path.Text);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            USDAGenerate();
        }

        private void tex_TextChanged(object sender, TextChangedEventArgs e)
        {
            USDAGenerate();
        }

        private void intense_TextChanged(object sender, TextChangedEventArgs e)
        {
            USDAGenerate();
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            this.command.Text = "nvdecompress -format png " + this.PNG.Text + ".dds " + this.PNG.Text + ".png";
        }

        private void Encoding_Checked(object sender, RoutedEventArgs e)
        {
            USDAGenerate();
        }

        private void albedo_Checked(object sender, RoutedEventArgs e)
        {
            USDAGenerate();
        }

        private void normal_Checked(object sender, RoutedEventArgs e)
        {
            USDAGenerate();
        }

        private void roughness_Checked(object sender, RoutedEventArgs e)
        {
            USDAGenerate();
        }

        private void metallic_Checked(object sender, RoutedEventArgs e)
        {
            USDAGenerate();
        }

        private void MeshPath_TextChanged(object sender, TextChangedEventArgs e)
        {
            USDAModels();
        }

        private void MeshID_TextChanged(object sender, TextChangedEventArgs e)
        {
            USDAModels();
        }
    }
}
