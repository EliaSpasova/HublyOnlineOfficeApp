namespace HublyProject
{
    partial class EventInfo
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(components);
            guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(components);
            title = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            guna2TextBox1 = new RichTextBox();
            Back = new Button();
            label1 = new Label();
            date = new Label();
            SuspendLayout();
            // 
            // guna2DragControl1
            // 
            guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            guna2DragControl1.TargetControl = this;
            guna2DragControl1.UseTransparentDrag = true;
            // 
            // guna2Elipse1
            // 
            guna2Elipse1.TargetControl = this;
            // 
            // title
            // 
            title.BackColor = Color.Transparent;
            title.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            title.Location = new Point(331, 56);
            title.Name = "title";
            title.Size = new Size(64, 47);
            title.TabIndex = 0;
            title.Text = "title";
            // 
            // guna2Button1
            // 
            guna2Button1.CustomizableEdges = customizableEdges3;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = Color.FromArgb(96, 84, 252);
            guna2Button1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.Location = new Point(12, 632);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Button1.Size = new Size(221, 43);
            guna2Button1.TabIndex = 1;
            guna2Button1.Text = "Delete Event";
            guna2Button1.Visible = false;
            guna2Button1.Click += guna2Button1_Click;
            // 
            // guna2Button2
            // 
            guna2Button2.CustomizableEdges = customizableEdges1;
            guna2Button2.DisabledState.BorderColor = Color.DarkGray;
            guna2Button2.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button2.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button2.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button2.FillColor = Color.FromArgb(96, 84, 252);
            guna2Button2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            guna2Button2.ForeColor = Color.White;
            guna2Button2.Location = new Point(468, 632);
            guna2Button2.Name = "guna2Button2";
            guna2Button2.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Button2.Size = new Size(287, 44);
            guna2Button2.TabIndex = 2;
            guna2Button2.Text = "Update Event";
            guna2Button2.Visible = false;
            guna2Button2.Click += guna2Button2_Click;
            // 
            // guna2TextBox1
            // 
            guna2TextBox1.Location = new Point(165, 109);
            guna2TextBox1.Name = "guna2TextBox1";
            guna2TextBox1.Size = new Size(434, 220);
            guna2TextBox1.TabIndex = 3;
            guna2TextBox1.Text = "";
            // 
            // Back
            // 
            Back.BackColor = Color.White;
            Back.Font = new Font("Segoe UI Semibold", 10.125F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            Back.Location = new Point(12, 12);
            Back.Name = "Back";
            Back.Size = new Size(145, 44);
            Back.TabIndex = 4;
            Back.Text = "Back";
            Back.UseVisualStyleBackColor = false;
            Back.Click += Back_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.875F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(165, 352);
            label1.Name = "label1";
            label1.Size = new Size(123, 40);
            label1.TabIndex = 5;
            label1.Text = "location";
            label1.Click += label1_Click;
            // 
            // date
            // 
            date.AutoSize = true;
            date.Font = new Font("Segoe UI Semibold", 10.875F, FontStyle.Bold, GraphicsUnit.Point);
            date.Location = new Point(165, 417);
            date.Name = "date";
            date.Size = new Size(123, 40);
            date.TabIndex = 6;
            date.Text = "location";
            // 
            // EventInfo
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(767, 688);
            Controls.Add(date);
            Controls.Add(label1);
            Controls.Add(Back);
            Controls.Add(guna2TextBox1);
            Controls.Add(guna2Button2);
            Controls.Add(guna2Button1);
            Controls.Add(title);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EventInfo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EventInfo";
            Load += EventInfo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2HtmlLabel title;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Button Back;
        private RichTextBox guna2TextBox1;
        private Label label1;
        private Label date;
    }
}