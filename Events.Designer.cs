namespace HublyProject
{
    partial class Events
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
            dayContainer = new FlowLayoutPanel();
            prvsButton = new Button();
            nxtButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            button1 = new Button();
            guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(components);
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // dayContainer
            // 
            dayContainer.Location = new Point(12, 124);
            dayContainer.Name = "dayContainer";
            dayContainer.Size = new Size(1450, 913);
            dayContainer.TabIndex = 2;
            // 
            // prvsButton
            // 
            prvsButton.Location = new Point(469, 7);
            prvsButton.Name = "prvsButton";
            prvsButton.Size = new Size(122, 48);
            prvsButton.TabIndex = 3;
            prvsButton.Text = "Previous";
            prvsButton.UseVisualStyleBackColor = true;
            prvsButton.Click += prvsButton_Click;
            // 
            // nxtButton
            // 
            nxtButton.Location = new Point(791, 9);
            nxtButton.Name = "nxtButton";
            nxtButton.Size = new Size(122, 46);
            nxtButton.TabIndex = 4;
            nxtButton.Text = "Next";
            nxtButton.UseVisualStyleBackColor = true;
            nxtButton.Click += nxtButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(51, 79);
            label1.Name = "label1";
            label1.Size = new Size(115, 32);
            label1.TabIndex = 5;
            label1.Text = "Sunday";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Verdana", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(240, 79);
            label2.Name = "label2";
            label2.Size = new Size(119, 32);
            label2.TabIndex = 6;
            label2.Text = "Monday";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Verdana", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(424, 79);
            label3.Name = "label3";
            label3.Size = new Size(124, 32);
            label3.TabIndex = 7;
            label3.Text = "Tuesday";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Verdana", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(620, 79);
            label4.Name = "label4";
            label4.Size = new Size(169, 32);
            label4.TabIndex = 8;
            label4.Text = "Wednesday";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Verdana", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(848, 79);
            label5.Name = "label5";
            label5.Size = new Size(140, 32);
            label5.TabIndex = 9;
            label5.Text = "Thursday";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Verdana", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(1058, 79);
            label6.Name = "label6";
            label6.Size = new Size(98, 32);
            label6.TabIndex = 10;
            label6.Text = "Friday";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Verdana", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(1243, 79);
            label7.Name = "label7";
            label7.Size = new Size(137, 32);
            label7.TabIndex = 11;
            label7.Text = "Saturday";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Verdana", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(607, 9);
            label8.Name = "label8";
            label8.Size = new Size(167, 32);
            label8.TabIndex = 12;
            label8.Text = "Month Year";
            // 
            // button1
            // 
            button1.Location = new Point(16, 1043);
            button1.Name = "button1";
            button1.Size = new Size(150, 46);
            button1.TabIndex = 13;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // guna2DragControl1
            // 
            guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            guna2DragControl1.TargetControl = this;
            guna2DragControl1.UseTransparentDrag = true;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // Events
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1474, 1111);
            Controls.Add(button1);
            Controls.Add(nxtButton);
            Controls.Add(prvsButton);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dayContainer);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Events";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Events";
            Load += Events_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel dayContainer;
        private Button prvsButton;
        private Button nxtButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Button button1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private System.Windows.Forms.Timer timer1;
    }
}