
namespace MovieLib.WinHost
{
    partial class MovieForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
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
        private void InitializeComponent ()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this._txtTitle = new System.Windows.Forms.TextBox();
            this._btnSave = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this._txtReleaseYear = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._txtDuration = new System.Windows.Forms.TextBox();
            this._chkIsClassic = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this._ddlRating = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this._txtGenre = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this._txtDescription = new System.Windows.Forms.TextBox();
            this._errors = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._errors)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title";
            // 
            // _txtTitle
            // 
            this._txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtTitle.Location = new System.Drawing.Point(124, 12);
            this._txtTitle.Name = "_txtTitle";
            this._txtTitle.Size = new System.Drawing.Size(205, 23);
            this._txtTitle.TabIndex = 1;
            this._txtTitle.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateTitle);
            // 
            // _btnSave
            // 
            this._btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSave.Location = new System.Drawing.Point(328, 285);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(75, 23);
            this._btnSave.TabIndex = 8;
            this._btnSave.Text = "Save";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this.OnSave);
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCancel.CausesValidation = false;
            this._btnCancel.Location = new System.Drawing.Point(409, 285);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 9;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this.OnCancel);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Release Year";
            // 
            // _txtReleaseYear
            // 
            this._txtReleaseYear.Location = new System.Drawing.Point(124, 41);
            this._txtReleaseYear.Name = "_txtReleaseYear";
            this._txtReleaseYear.Size = new System.Drawing.Size(59, 23);
            this._txtReleaseYear.TabIndex = 2;
            this._txtReleaseYear.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateReleaseYear);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Duration (minutes)";
            // 
            // _txtDuration
            // 
            this._txtDuration.Location = new System.Drawing.Point(124, 70);
            this._txtDuration.Name = "_txtDuration";
            this._txtDuration.Size = new System.Drawing.Size(59, 23);
            this._txtDuration.TabIndex = 3;
            this._txtDuration.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateDuration);
            // 
            // _chkIsClassic
            // 
            this._chkIsClassic.AutoSize = true;
            this._chkIsClassic.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._chkIsClassic.Location = new System.Drawing.Point(65, 98);
            this._chkIsClassic.Name = "_chkIsClassic";
            this._chkIsClassic.Size = new System.Drawing.Size(73, 19);
            this._chkIsClassic.TabIndex = 4;
            this._chkIsClassic.Text = "Is Classic";
            this._chkIsClassic.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(77, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Rating";
            // 
            // _ddlRating
            // 
            this._ddlRating.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._ddlRating.FormattingEnabled = true;
            this._ddlRating.Items.AddRange(new object[] {
            "G",
            "PG",
            "PG-13",
            "R",
            "NC-17"});
            this._ddlRating.Location = new System.Drawing.Point(124, 123);
            this._ddlRating.Name = "_ddlRating";
            this._ddlRating.Size = new System.Drawing.Size(100, 23);
            this._ddlRating.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(80, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Genre";
            // 
            // _txtGenre
            // 
            this._txtGenre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtGenre.Location = new System.Drawing.Point(124, 152);
            this._txtGenre.Name = "_txtGenre";
            this._txtGenre.Size = new System.Drawing.Size(100, 23);
            this._txtGenre.TabIndex = 6;
            this._txtGenre.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateGenre);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(51, 181);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Description";
            // 
            // _txtDescription
            // 
            this._txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtDescription.Location = new System.Drawing.Point(124, 181);
            this._txtDescription.Multiline = true;
            this._txtDescription.Name = "_txtDescription";
            this._txtDescription.Size = new System.Drawing.Size(205, 98);
            this._txtDescription.TabIndex = 7;
            // 
            // _errors
            // 
            this._errors.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errors.ContainerControl = this;
            // 
            // MovieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(496, 320);
            this.Controls.Add(this._txtDescription);
            this.Controls.Add(this.label7);
            this.Controls.Add(this._txtGenre);
            this.Controls.Add(this.label6);
            this.Controls.Add(this._ddlRating);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._chkIsClassic);
            this.Controls.Add(this._txtDuration);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._txtReleaseYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnSave);
            this.Controls.Add(this._txtTitle);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(512, 359);
            this.Name = "MovieForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Movie Details";
            ((System.ComponentModel.ISupportInitialize)(this._errors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _txtTitle;
        private System.Windows.Forms.Button _btnSave;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _txtReleaseYear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _txtDuration;
        private System.Windows.Forms.CheckBox _chkIsClassic;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox _ddlRating;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox _txtGenre;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox _txtDescription;
        private System.Windows.Forms.ErrorProvider _errors;
    }
}