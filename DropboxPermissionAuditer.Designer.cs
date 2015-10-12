using System.Windows.Forms;
namespace DBPermissionAuditer
{
    partial class DropboxMembershipAuditer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DropboxMembershipAuditer));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbHeaderLine = new System.Windows.Forms.GroupBox();
            this.TTLimit = new MetroFramework.Components.MetroToolTip();
            this.chkTeamFoldersOnly = new MetroFramework.Controls.MetroCheckBox();
            this.chkExternalAccess = new MetroFramework.Controls.MetroCheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SVCsvSave = new System.Windows.Forms.SaveFileDialog();
            this.gbResults = new System.Windows.Forms.GroupBox();
            this.btnClear = new MetroFramework.Controls.MetroButton();
            this.imgLoadingGif = new System.Windows.Forms.PictureBox();
            this.txtStatus = new MetroFramework.Controls.MetroLabel();
            this.DVGResults = new MetroFramework.Controls.MetroGrid();
            this.btnStart = new MetroFramework.Controls.MetroButton();
            this.pbMemberInformationProgress = new MetroFramework.Controls.MetroProgressBar();
            this.gbAccessToken = new System.Windows.Forms.GroupBox();
            this.txtAccessToken = new MetroFramework.Controls.MetroTextBox();
            this.lblAccessToken = new MetroFramework.Controls.MetroLabel();
            this.gbExportCSV = new System.Windows.Forms.GroupBox();
            this.lblCSVinstructions = new System.Windows.Forms.Label();
            this.btnBrowse = new MetroFramework.Controls.MetroButton();
            this.txtExportCSV = new MetroFramework.Controls.MetroTextBox();
            this.lblExportCSV = new MetroFramework.Controls.MetroLabel();
            this.gbResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoadingGif)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DVGResults)).BeginInit();
            this.gbAccessToken.SuspendLayout();
            this.gbExportCSV.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbHeaderLine
            // 
            this.gbHeaderLine.Location = new System.Drawing.Point(25, 58);
            this.gbHeaderLine.Name = "gbHeaderLine";
            this.gbHeaderLine.Size = new System.Drawing.Size(1100, 5);
            this.gbHeaderLine.TabIndex = 0;
            this.gbHeaderLine.TabStop = false;
            // 
            // TTLimit
            // 
            this.TTLimit.Style = MetroFramework.MetroColorStyle.Blue;
            this.TTLimit.StyleManager = null;
            this.TTLimit.Tag = "";
            this.TTLimit.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // chkTeamFoldersOnly
            // 
            this.chkTeamFoldersOnly.AutoSize = true;
            this.chkTeamFoldersOnly.Location = new System.Drawing.Point(19, 57);
            this.chkTeamFoldersOnly.Name = "chkTeamFoldersOnly";
            this.chkTeamFoldersOnly.Size = new System.Drawing.Size(254, 15);
            this.chkTeamFoldersOnly.TabIndex = 5;
            this.chkTeamFoldersOnly.Text = "Include external folders my team can access";
            this.TTLimit.SetToolTip(this.chkTeamFoldersOnly, "Include any external folders your team members have access to\r\nthese will appear " +
        "amongst the various other results returned.");
            this.chkTeamFoldersOnly.UseSelectable = true;
            // 
            // chkExternalAccess
            // 
            this.chkExternalAccess.AutoSize = true;
            this.chkExternalAccess.Location = new System.Drawing.Point(19, 36);
            this.chkExternalAccess.Name = "chkExternalAccess";
            this.chkExternalAccess.Size = new System.Drawing.Size(127, 15);
            this.chkExternalAccess.TabIndex = 4;
            this.chkExternalAccess.Text = "External access only";
            this.TTLimit.SetToolTip(this.chkExternalAccess, "Only show the external users who have access to your teams\r\nfolders");
            this.chkExternalAccess.UseSelectable = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 577);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Copyright 2015 ";
            // 
            // SVCsvSave
            // 
            this.SVCsvSave.FileOk += new System.ComponentModel.CancelEventHandler(this.SVCsvSave_FileOk);
            // 
            // gbResults
            // 
            this.gbResults.Controls.Add(this.btnClear);
            this.gbResults.Controls.Add(this.chkTeamFoldersOnly);
            this.gbResults.Controls.Add(this.chkExternalAccess);
            this.gbResults.Controls.Add(this.imgLoadingGif);
            this.gbResults.Controls.Add(this.txtStatus);
            this.gbResults.Controls.Add(this.DVGResults);
            this.gbResults.Controls.Add(this.btnStart);
            this.gbResults.Controls.Add(this.pbMemberInformationProgress);
            this.gbResults.Location = new System.Drawing.Point(25, 213);
            this.gbResults.Name = "gbResults";
            this.gbResults.Size = new System.Drawing.Size(1119, 359);
            this.gbResults.TabIndex = 2;
            this.gbResults.TabStop = false;
            // 
            // btnClear
            // 
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Location = new System.Drawing.Point(130, 95);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(104, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseSelectable = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // imgLoadingGif
            // 
            this.imgLoadingGif.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.imgLoadingGif.Image = ((System.Drawing.Image)(resources.GetObject("imgLoadingGif.Image")));
            this.imgLoadingGif.Location = new System.Drawing.Point(574, 85);
            this.imgLoadingGif.Name = "imgLoadingGif";
            this.imgLoadingGif.Size = new System.Drawing.Size(37, 33);
            this.imgLoadingGif.TabIndex = 7;
            this.imgLoadingGif.TabStop = false;
            this.imgLoadingGif.Visible = false;
            // 
            // txtStatus
            // 
            this.txtStatus.AutoSize = true;
            this.txtStatus.Location = new System.Drawing.Point(259, 95);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(0, 0);
            this.txtStatus.TabIndex = 6;
            // 
            // DVGResults
            // 
            this.DVGResults.AllowUserToResizeRows = false;
            this.DVGResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DVGResults.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DVGResults.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DVGResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DVGResults.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DVGResults.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.DVGResults.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DVGResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DVGResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DVGResults.DefaultCellStyle = dataGridViewCellStyle2;
            this.DVGResults.EnableHeadersVisualStyles = false;
            this.DVGResults.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.DVGResults.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DVGResults.Location = new System.Drawing.Point(19, 162);
            this.DVGResults.Name = "DVGResults";
            this.DVGResults.ReadOnly = true;
            this.DVGResults.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DVGResults.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DVGResults.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DVGResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DVGResults.Size = new System.Drawing.Size(1094, 191);
            this.DVGResults.TabIndex = 8;
            this.DVGResults.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.Location = new System.Drawing.Point(19, 95);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(105, 23);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseSelectable = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pbMemberInformationProgress
            // 
            this.pbMemberInformationProgress.Location = new System.Drawing.Point(19, 124);
            this.pbMemberInformationProgress.Name = "pbMemberInformationProgress";
            this.pbMemberInformationProgress.Size = new System.Drawing.Size(592, 23);
            this.pbMemberInformationProgress.TabIndex = 8;
            // 
            // gbAccessToken
            // 
            this.gbAccessToken.Controls.Add(this.txtAccessToken);
            this.gbAccessToken.Controls.Add(this.lblAccessToken);
            this.gbAccessToken.Location = new System.Drawing.Point(25, 74);
            this.gbAccessToken.Name = "gbAccessToken";
            this.gbAccessToken.Size = new System.Drawing.Size(611, 133);
            this.gbAccessToken.TabIndex = 0;
            this.gbAccessToken.TabStop = false;
            // 
            // txtAccessToken
            // 
            this.txtAccessToken.Lines = new string[0];
            this.txtAccessToken.Location = new System.Drawing.Point(19, 38);
            this.txtAccessToken.MaxLength = 32767;
            this.txtAccessToken.Name = "txtAccessToken";
            this.txtAccessToken.PasswordChar = '\0';
            this.txtAccessToken.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAccessToken.SelectedText = "";
            this.txtAccessToken.Size = new System.Drawing.Size(297, 23);
            this.txtAccessToken.TabIndex = 1;
            this.txtAccessToken.UseSelectable = true;
            // 
            // lblAccessToken
            // 
            this.lblAccessToken.AutoSize = true;
            this.lblAccessToken.Location = new System.Drawing.Point(19, 16);
            this.lblAccessToken.Name = "lblAccessToken";
            this.lblAccessToken.Size = new System.Drawing.Size(83, 19);
            this.lblAccessToken.TabIndex = 0;
            this.lblAccessToken.Text = "Access token";
            // 
            // gbExportCSV
            // 
            this.gbExportCSV.Controls.Add(this.lblCSVinstructions);
            this.gbExportCSV.Controls.Add(this.btnBrowse);
            this.gbExportCSV.Controls.Add(this.txtExportCSV);
            this.gbExportCSV.Controls.Add(this.lblExportCSV);
            this.gbExportCSV.Location = new System.Drawing.Point(642, 74);
            this.gbExportCSV.Name = "gbExportCSV";
            this.gbExportCSV.Size = new System.Drawing.Size(502, 133);
            this.gbExportCSV.TabIndex = 1;
            this.gbExportCSV.TabStop = false;
            // 
            // lblCSVinstructions
            // 
            this.lblCSVinstructions.AutoSize = true;
            this.lblCSVinstructions.Location = new System.Drawing.Point(18, 77);
            this.lblCSVinstructions.Name = "lblCSVinstructions";
            this.lblCSVinstructions.Size = new System.Drawing.Size(352, 13);
            this.lblCSVinstructions.TabIndex = 13;
            this.lblCSVinstructions.Text = "To export the results please choose a file path prior to starting the auditer.";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowse.Location = new System.Drawing.Point(346, 38);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(137, 23);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseSelectable = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtExportCSV
            // 
            this.txtExportCSV.Lines = new string[0];
            this.txtExportCSV.Location = new System.Drawing.Point(18, 38);
            this.txtExportCSV.MaxLength = 32767;
            this.txtExportCSV.Name = "txtExportCSV";
            this.txtExportCSV.PasswordChar = '\0';
            this.txtExportCSV.ReadOnly = true;
            this.txtExportCSV.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtExportCSV.SelectedText = "";
            this.txtExportCSV.Size = new System.Drawing.Size(297, 23);
            this.txtExportCSV.TabIndex = 2;
            this.txtExportCSV.UseSelectable = true;
            // 
            // lblExportCSV
            // 
            this.lblExportCSV.AutoSize = true;
            this.lblExportCSV.Location = new System.Drawing.Point(18, 16);
            this.lblExportCSV.Name = "lblExportCSV";
            this.lblExportCSV.Size = new System.Drawing.Size(76, 19);
            this.lblExportCSV.TabIndex = 2;
            this.lblExportCSV.Text = "Export CSV";
            // 
            // DropboxMembershipAuditer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1161, 595);
            this.Controls.Add(this.gbExportCSV);
            this.Controls.Add(this.gbAccessToken);
            this.Controls.Add(this.gbResults);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gbHeaderLine);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DropboxMembershipAuditer";
            this.Text = "DB Permission Auditer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.gbResults.ResumeLayout(false);
            this.gbResults.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoadingGif)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DVGResults)).EndInit();
            this.gbAccessToken.ResumeLayout(false);
            this.gbAccessToken.PerformLayout();
            this.gbExportCSV.ResumeLayout(false);
            this.gbExportCSV.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbHeaderLine;
        private MetroFramework.Components.MetroToolTip TTLimit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SaveFileDialog SVCsvSave;
        private System.Windows.Forms.GroupBox gbResults;
        private MetroFramework.Controls.MetroGrid DVGResults;
        private MetroFramework.Controls.MetroButton btnStart;
        private MetroFramework.Controls.MetroProgressBar pbMemberInformationProgress;
        private System.Windows.Forms.GroupBox gbAccessToken;
        private MetroFramework.Controls.MetroTextBox txtAccessToken;
        private MetroFramework.Controls.MetroLabel lblAccessToken;
        private MetroFramework.Controls.MetroLabel txtStatus;
        private System.Windows.Forms.PictureBox imgLoadingGif;
        private MetroFramework.Controls.MetroCheckBox chkExternalAccess;
        private MetroFramework.Controls.MetroCheckBox chkTeamFoldersOnly;
        private System.Windows.Forms.GroupBox gbExportCSV;
        private System.Windows.Forms.Label lblCSVinstructions;
        private MetroFramework.Controls.MetroButton btnBrowse;
        private MetroFramework.Controls.MetroTextBox txtExportCSV;
        private MetroFramework.Controls.MetroLabel lblExportCSV;
        private MetroFramework.Controls.MetroButton btnClear;
    }
}

