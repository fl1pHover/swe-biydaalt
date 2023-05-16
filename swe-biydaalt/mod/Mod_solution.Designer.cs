namespace swe_biydaalt
{
    partial class Mod_solution
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.kryptonPalette1 = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.SuspendLayout();
            // 
            // kryptonPalette1
            // 
            this.kryptonPalette1.ButtonSpecs.FormClose.Image = global::swe_biydaalt.Properties.Resources.mac_close_2_;
            this.kryptonPalette1.ButtonSpecs.FormClose.ImageStates.ImagePressed = global::swe_biydaalt.Properties.Resources.mac_close_2_;
            this.kryptonPalette1.ButtonSpecs.FormClose.ImageStates.ImageTracking = global::swe_biydaalt.Properties.Resources.mac_close_2_;
            this.kryptonPalette1.ButtonSpecs.FormMax.Image = global::swe_biydaalt.Properties.Resources.mac_maximize1;
            this.kryptonPalette1.ButtonSpecs.FormMax.ImageStates.ImagePressed = global::swe_biydaalt.Properties.Resources.mac_maximize1;
            this.kryptonPalette1.ButtonSpecs.FormMax.ImageStates.ImageTracking = global::swe_biydaalt.Properties.Resources.mac_maximize1;
            this.kryptonPalette1.ButtonSpecs.FormMin.Image = global::swe_biydaalt.Properties.Resources.mac_minimize1;
            this.kryptonPalette1.ButtonSpecs.FormMin.ImageStates.ImagePressed = global::swe_biydaalt.Properties.Resources.mac_minimize1;
            this.kryptonPalette1.ButtonSpecs.FormMin.ImageStates.ImageTracking = global::swe_biydaalt.Properties.Resources.mac_minimize1;
            this.kryptonPalette1.FormStyles.FormCommon.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.kryptonPalette1.FormStyles.FormCommon.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.kryptonPalette1.FormStyles.FormCommon.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.FormStyles.FormCommon.StateCommon.Border.Rounding = 20;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Back.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Content.Padding = new System.Windows.Forms.Padding(20, -1, 20, -1);
            // 
            // Mod_solution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 515);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.Name = "Mod_solution";
            this.Palette = this.kryptonPalette1;
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom;
            this.ShowIcon = false;
            this.Text = "Санал хүсэлтийн хариу илгээх";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPalette kryptonPalette1;
    }
}